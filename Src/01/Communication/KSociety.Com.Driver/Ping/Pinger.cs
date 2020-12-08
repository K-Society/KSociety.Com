using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.InfraSub.Shared.Class;
using KSociety.Com.Driver.Ping.IntegrationEvent.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Driver.Ping
{
    public sealed class Pinger : DisposableObject, IPinger
    {
        #region [Private]
        private readonly ILogger<Pinger> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private CancellationTokenSource Cts { get; set; }
        private const int ConnectTimeout = 2000;

        private readonly IEventBus _eventBus;
        private int _oldStatus = -100;
        private readonly string _routingKey;

        //private ToLog theLogger;
        //private static Logger _theLogger; // = LogManager.GetCurrentClassLogger();
        //private readonly object _sender;
        //private readonly int _pingFault;
        //private int _pingFaultCounter;
        //public event StandardEventHandler StatusPing;
        //public event StandardEventHandler StatusPing2;
        //private int _pingStatusInt = -1;
        //private int _pingOldStatusInt = -2;

        // Flag:

        #endregion

        #region [IO]
        public string HostName { get; set; } = "<not set>";

        public string Address
        {
            get => Ip; set => Ip = value;
        }
        public bool? LastPingSuccessFull { get; set; }

        public bool Status { get; private set; }

        //public bool StatusInt => _pingStatusInt == 1 ? true : false;
        public bool StopPlease { get; set; }

        public int Timeout { get; set; } = 6000;

        public string Ip { get; private set; } = "<not set>";

        public string Name { get; }

        //public Logger TheLogger
        //{
        //    get => _theLogger; set => _theLogger = value;
        //}

        //public object TheSender { get; set; }

        #endregion

        #region [Constructor]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="hostNameOrAddress">192.168.0.1</param>
        /// <param name="name">test</param>
        public Pinger(ILoggerFactory loggerFactory, string hostNameOrAddress, string name)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Pinger>();
            Address = hostNameOrAddress;
            //Cts = new CancellationTokenSource();

            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="hostNameOrAddress">192.168.0.1</param>
        /// <param name="name">test</param>
        /// <param name="eventBus"></param>
        public Pinger(ILoggerFactory loggerFactory, string hostNameOrAddress, string name, IEventBus eventBus)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Pinger>();
            Address = hostNameOrAddress;
            //Cts = new CancellationTokenSource();

            Name = name;
            //_pingFault = -1;
            _eventBus = eventBus;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hostNameOrAddress">192.168.0.1</param>
        ///// <param name="name">test</param>
        //public Pinger(string hostNameOrAddress, string name)
        //{
        //    //_sender = sender;

        //    Address = hostNameOrAddress;
        //    Cts = new CancellationTokenSource();

        //    Name = name;
        //    _pingFault = -1;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="hostNameOrAddress">192.168.0.1</param>
        /// <param name="name">test</param>
        /// <param name="timeout">300 ms</param>
        public Pinger(ILoggerFactory loggerFactory, string hostNameOrAddress, string name, int timeout)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Pinger>();
            Address = hostNameOrAddress;
            //Cts = new CancellationTokenSource();

            Name = name;
            Timeout = timeout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="hostNameOrAddress">192.168.0.1</param>
        /// <param name="name">test</param>
        /// <param name="timeout">300 ms</param>
        /// <param name="eventBus"></param>
        public Pinger(ILoggerFactory loggerFactory, string hostNameOrAddress, string name, int timeout, IEventBus eventBus)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Pinger>();
            Address = hostNameOrAddress;
            //Cts = new CancellationTokenSource();

            Name = name;
            Timeout = timeout;
            //_pingFault = -1;
            _eventBus = eventBus;
        }

        public Pinger(ILoggerFactory loggerFactory, string hostNameOrAddress, string name, int timeout, IEventBus eventBus, string routingKey)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Pinger>();
            Address = hostNameOrAddress;
            //Cts = new CancellationTokenSource();

            Name = name;
            Timeout = timeout;
            //_pingFault = -1;
            _eventBus = eventBus;
            _routingKey = routingKey;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hostNameOrAddress">192.168.0.1</param>
        ///// <param name="name">test</param>
        ///// <param name="timeout">300 ms</param>
        //public Pinger(string hostNameOrAddress, string name, int timeout/*, object sender*/)
        //{
        //    //_sender = sender;

        //    Address = hostNameOrAddress;
        //    Cts = new CancellationTokenSource();

        //    Name = name;
        //    Timeout = timeout;
        //    _pingFault = -1;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="hostNameOrAddress"></param>
        ///// <param name="name">test</param>
        ///// <param name="timeout">300 ms</param>
        ///// <param name="pingFault">3</param>
        //public Pinger(string hostNameOrAddress, string name, int timeout/*, int pingFault*/)
        //{
        //    //_sender = sender;
        //    //_pingFault = pingFault;
        //    Address = hostNameOrAddress;
        //    Cts = new CancellationTokenSource();

        //    Name = name;
        //    Timeout = timeout;
        //}
        #endregion

        #region [Start/Stop]
        public async void Start(CancellationToken cancellationToken = default)
        {
            Cts = new CancellationTokenSource();
            IPAddress ipAddress = await PingerEngine.ResolveAddressAsync(Address).ConfigureAwait(false);
            if (Equals(ipAddress, IPAddress.None)) return;
            CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, Cts.Token);
            StartPing(ipAddress, linkedCts.Token);
        }

        public void Stop()
        {
            Cancel();
        }
        #endregion

        public bool SingleProtocolPing(int port, ProtocolType type)
        {
            bool output = false;
            IPAddress ipAddress = PingerEngine.ResolveAddress(Address);
            Socket pingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, type);
            try
            {
                if (Equals(ipAddress, IPAddress.None)) return false;
                IAsyncResult result = pingSocket.BeginConnect(ipAddress, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(ConnectTimeout, true);
                output = success;
            }
            catch
            {
                output = false;
            }
            finally { pingSocket.Close(); }

            return output;
        }

        private async void StartPing(IPAddress ipAddress, CancellationToken ct)
        {
            Progress<PingerResult> progress = new Progress<PingerResult>(HandleProgress);
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    try
                    {
                        ValueTask pingTask = PingerEngine.ContinuousPingAsync(ipAddress, Timeout, 1000, progress, ct);
                        await pingTask.ConfigureAwait(false);
                    }
                    catch (PingException)
                    {
                        Address = "<unreachable>";
                        LastPingSuccessFull = null;
                    }

                    if (!ct.IsCancellationRequested)
                        await Task.Delay(TimeSpan.FromSeconds(2), ct).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                //_theLogger?.Error(Name + " DisplayReply: " + ex.Message);
            }
        }

        private void HandleProgress(PingerResult res)
        {
            Address = res.Address.ToString();
            Status = res.LastStatus == IPStatus.Success;

            if (_oldStatus == (int) res.LastStatus) return;
            _oldStatus = (int)res.LastStatus;
            try
            {
                var @event = new PingStatusIntegrationEvent(Name, _routingKey, Address, Status);

                _eventBus?.Publish(@event);
            }
            catch (Exception)
            {
                //_theLogger?.Warn(Name + " PING Sender: " + ex.Message);
            }
            //    AverageTime = FormatTime(res.AverageTime);
            //LastPingSuccessfull = res.LastStatus == IPStatus.Success;
            //SuccessRate = FormatSuccessRate(res.PingsSuccessfull, res.PingsTotal);

            //if (LastPingSuccessfull.Value)
            //{
            //    LastTime = FormatTime(res.LastTime);
            //}
            //else
            //{
            //    LastTime = "<na>";
            //}

            //try
            //{
            //    //if (_sender != null)
            //    //{
            //    //    if (_pingOldStatusInt != _pingStatusInt)
            //    //    {
            //    //        if (_pingFault == -1)
            //    //        {
            //    //            if (_pingStatusInt.Equals(1))
            //    //            {
            //    //                //StatusPing?.Invoke(_sender, new StandardEventArgs(true));
            //    //            }
            //    //            else
            //    //            {
            //    //                //StatusPing?.Invoke(_sender, new StandardEventArgs(false));
            //    //            }
            //    //        }
            //    //        else
            //    //        {
            //    //            if (_pingStatusInt.Equals(1))
            //    //            {
            //    //                //StatusPing?.Invoke(_sender, new StandardEventArgs(true));
            //    //            }
            //    //            else
            //    //            {
            //    //                if (_pingFaultCounter >= _pingFault)
            //    //                {
            //    //                    //StatusPing?.Invoke(_sender, new StandardEventArgs(false));
            //    //                }
            //    //            }
            //    //        }

            //    //        //PING_OLDStatus_int = PING_Status_int;
            //    //    }
            //    //}

            //    //if (TheSender != null)
            //    //{
            //    //    if (_pingOldStatusInt != _pingStatusInt)
            //    //    {
            //    //        if (_pingFault == -1)
            //    //        {
            //    //            if (_pingStatusInt.Equals(1))
            //    //            {
            //    //                //StatusPing2?.Invoke(_sender2, new StandardEventArgs(true));
            //    //            }
            //    //            else
            //    //            {
            //    //                //StatusPing2?.Invoke(_sender2, new StandardEventArgs(false));
            //    //            }
            //    //        }
            //    //        else
            //    //        {
            //    //            if (_pingStatusInt.Equals(1))
            //    //            {
            //    //                //StatusPing 28 8 2018
            //    //                //StatusPing2?.Invoke(_sender, new StandardEventArgs(true));
            //    //            }
            //    //            else
            //    //            {
            //    //                if (_pingFaultCounter >= _pingFault)
            //    //                {
            //    //                    //StatusPing 28 8 2018
            //    //                    //StatusPing2?.Invoke(_sender, new StandardEventArgs(false));
            //    //                }
            //    //            }
            //    //        }

            //    //        //PING_OLDStatus_int = PING_Status_int;
            //    //    }
            //    //}

            //    if (_pingOldStatusInt != _pingStatusInt)
            //    {
            //        _pingOldStatusInt = _pingStatusInt;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //_theLogger?.Warn(Name + " PING Sender: " + ex.Message);
            //}
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            return $"{timeSpan.TotalMilliseconds:0} ms";
        }

        private void Cancel()
        {
            _logger?.LogTrace("Pinger Cancel: ");

            try
            {
                if (Cts is null)
                {
                    return;
                }

                Cts.Cancel();
                Cts.Dispose();
            }
            catch (Exception ex)
            {
                _logger?.LogError("Pinger Cancel: " + ex.Message);
            }

        }

        #region [Dispose]
        protected override void DisposeManagedResources()
        {
            Cancel();
        }
        #endregion
    }
}
