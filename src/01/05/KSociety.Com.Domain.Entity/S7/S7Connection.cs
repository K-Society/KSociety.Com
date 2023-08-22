using Microsoft.Extensions.Logging;
using Polly;
using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace KSociety.Com.Domain.Entity.S7
{
    public class S7Connection : Common.Connection
    {
        private Dictionary<int, List<S7Tag>> _readTags = new Dictionary<int, List<S7Tag>>();

        #region [Propery]

        public int? CpuTypeId { get; private set; }
        public virtual CpuType CpuType { get; private set; }
        public short? Rack { get; private set; }
        public short? Slot { get; private set; }
        public int? ConnectionTypeId { get; private set; }
        public virtual ConnectionType ConnectionType { get; private set; }

        #endregion

        public Plc ClientRead { get; private set; }
        public Plc ClientWrite { get; private set; }


        #region [Constructor]

        //For Csv
        public S7Connection(
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable, //
            int? cpuTypeId,
            short? rack,
            short? slot,
            int? connectionTypeId
        )
            : base(
                id,
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;

        }

        public S7Connection(
            int? cpuTypeId,
            short? rack,
            short? slot,
            int? connectionTypeId
        )
        {
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
        }

        public S7Connection(
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            int? cpuTypeId,
            short? rack,
            short? slot,
            int? connectionTypeId
        )
            : base(
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;

        }

        public S7Connection(
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable, //
            int cpuTypeId,
            short rack,
            short slot,
            int connectionTypeId
        )
            : base(
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            CpuTypeId = cpuTypeId;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
        }

        #endregion

        public override void Initiate()
        {
            Logger?.LogTrace("Domain.Entity.S7.S7Connection Initiate: " + Name);
            if (CpuTypeId != null)
            {
                ClientRead = new Plc((global::S7.Net.CpuType)CpuTypeId, Ip, Rack ?? 0, Slot ?? 0);
                TryConnectRead();
            }

            if (CpuTypeId != null && WriteEnable)
            {
                ClientWrite = new Plc((global::S7.Net.CpuType)CpuTypeId, Ip, Rack ?? 0, Slot ?? 0);
                TryConnectWrite();
            }

            //Create SubGroups
            SetTag();

        }

        public async void TryConnectRead()
        {
            var policy = Policy
                .Handle<Exception>()
                //.OrResult<Plc>(r => r.IsConnected == false)
                .WaitAndRetryForeverAsync(retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, time) =>
                    {
                        //Logger.Warn("TryConnectRead: " + ex.Exception.Message + " - " + ex.Exception.StackTrace);
                        Logger.LogWarning("TryConnectRead: " + ex.Message + " - " + ex.StackTrace);
                    }
                );

            await policy.ExecuteAsync(() => ClientRead.OpenAsync()).ConfigureAwait(false);
        }

        public async void TryConnectWrite()
        {
            var policy = Policy
                .Handle<Exception>()
                //.OrResult<Plc>(r => r.IsConnected == false)
                .WaitAndRetryForeverAsync(retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, time) =>
                    {
                        //Logger.Warn("TryConnectRead: " + ex.Exception.Message + " - " + ex.Exception.StackTrace);
                        Logger.LogWarning("TryConnectWrite: " + ex.Message + " - " + ex.StackTrace);
                    }
                );

            //await policy.Execute(async () => await ClientRead.OpenAsync());

            await policy.ExecuteAsync(() => ClientWrite.OpenAsync()).ConfigureAwait(false);
        }

        public override async ValueTask ReadTags()
        {
            //StdConnection.Tags
            //Logger.LogTrace("Domain.Entity.S7.S7Connection ReadTags! ");
            //Read(_readTags[0]);

            foreach (var readTags in _readTags)
            {
                await Read(readTags.Value).ConfigureAwait(false);
            }
            //return Task.CompletedTask;
        }

        private void SetTag()
        {
            try
            {
                var readTags = Tags.Where(t => t.Invoke && (t.InputOutput.Equals("R") || t.InputOutput.Equals("RW")))
                    .Cast<S7Tag>()
                    .ToList();
                var items = 18;

                switch (CpuTypeId ?? 0)
                {
                    case 0:
                    case 10:
                    case 30:
                        items = 18;
                        break;

                    case 20:
                    case 40:
                        items = 20;
                        break;

                    default:
                        break;
                }

                if (readTags.Count > 20)
                {
                    //ToDo
                    //Logger.Error("SetTag: 1");
                    for (int i = 0; i < readTags.Count / items; i++)
                    {
                        //Logger.Error("SetTag: 1: " + i);
                        if (!_readTags.ContainsKey(i))
                        {
                            _readTags.Add(i, readTags.GetRange(i * items, items));
                        }
                    }

                    if (readTags.Count % items != 0)
                    {
                        //Logger.Error("SetTag: 2: " + readTags.Count / items * items + " - " + readTags.Count % items);
                        _readTags.Add(
                            readTags.Count,
                            readTags.GetRange(readTags.Count / items * items, readTags.Count % items));
                        //Logger.Error("SetTag: 22");
                    }
                }
                else
                {
                    //Logger.Error("SetTag: 3");
                    _readTags.Add(0, readTags);
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("SetTag: " + ex.Message + " - " + ex.StackTrace);
            }
        }

        private async ValueTask Read(IReadOnlyList<S7Tag> tagList)
        {
            await ReadSemaphore.WaitAsync();
            Task<List<DataItem>> result = null;

            try
            {
                result =
                    ClientRead.ReadMultipleVarsAsync(tagList.Select(t => t.DataItemTag).ToList());

                await result.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger?.LogError("Read: " + ex.Message + " - " + ex.StackTrace);
            }
            finally
            {
                ReadSemaphore.Release();
            }

            if (result != null)
            {
                var currentTime = DateTime.Now;
                for (int i = 0; i < tagList.Count; i++)
                {
                    await tagList[i].SetReadValue(result.Result[i].Value.ToString(), currentTime)
                        .ConfigureAwait(false); //ToDo
                }
            }
        } //Read

        public override bool ConnectionStatusRead()
        {
            return ClientRead.IsConnected;
        }

        public override bool ConnectionStatusWrite()
        {
            return WriteEnable && ClientWrite.IsConnected;
        }
    }
}