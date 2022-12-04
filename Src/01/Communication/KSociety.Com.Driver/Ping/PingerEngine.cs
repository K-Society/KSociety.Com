using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Driver.Ping
{
    public static class PingerEngine
    {
        public static IPAddress ResolveAddress(string hostNameOrAddress)
        {
            var address = IPAddress.None;
            try
            {
                if (!IPAddress.TryParse(hostNameOrAddress, out address))
                {
                    var addresses = Dns.GetHostAddresses(hostNameOrAddress);
                    address = addresses[0];
                }
            }
            catch
            {
                //
            }

            return address;
        }

        public static async ValueTask<IPAddress> ResolveAddressAsync(string hostNameOrAddress)
        {
            var address = IPAddress.None;
            try
            {
                if (!IPAddress.TryParse(hostNameOrAddress, out address))
                {
                    var addresses = await Dns.GetHostAddressesAsync(hostNameOrAddress);
                    address = addresses[0];
                }
            }
            catch
            {
                //
            }

            return address;
        }

        public static async ValueTask ContinuousPingAsync(IPAddress address, int timeout, int delayBetweenPings,
            IProgress<PingerResult> progress, CancellationToken cancellationToken)
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var result = new PingerResult(address);

                while (!cancellationToken.IsCancellationRequested)
                {
                    System.Net.NetworkInformation.PingReply res = null;
                    try
                    {
                        try
                        {
                            res = await ping.SendPingAsync(address, timeout).ConfigureAwait(false);
                            result.AddResult(res);
                            progress.Report(result);
                            await Task.Delay(delayBetweenPings, cancellationToken).ConfigureAwait(false);
                        }
                        catch (System.Net.NetworkInformation.PingException /*pex*/)
                        {
                            //var s = pex.ToString();
                            result.AddResult(res);
                            progress.Report(result);
                            await Task.Delay(delayBetweenPings, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (Exception /*ex*/)
                    {
                        //res = null;
                        //ex.ToString();
                        result.AddResult(null);
                        progress.Report(result);
                        await Task.Delay(delayBetweenPings, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception /*ex*/)
            {
                //ex.ToString();
            }
        }
    }
}