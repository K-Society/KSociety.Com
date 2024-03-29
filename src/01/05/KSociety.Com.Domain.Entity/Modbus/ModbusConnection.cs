﻿using System;

namespace KSociety.Com.Domain.Entity.Modbus
{
    public class ModbusConnection : Common.Connection
    {
        //private Dictionary<int, List<S7Tag>> _readTags = new Dictionary<int, List<S7Tag>>();

        #region [Propery]

        //public int? CpuTypeId { get; private set; }
        //public virtual CpuType CpuType { get; private set; }
        //public short? Rack { get; private set; }
        //public short? Slot { get; private set; }
        //public int? ConnectionTypeId { get; private set; }
        //public virtual ConnectionType ConnectionType { get; private set; }

        #endregion

        //

        //public Plc ClientRead { get; private set; }
        //public Plc ClientWrite { get; private set; }

        //


        #region [Constructor]

        public ModbusConnection(
            //int? cpuTypeId,
            //short? rack,
            //short? slot, 
            //int? connectionTypeId
        )
            : base(
                //LogManager.GetCurrentClassLogger()
            )
        {
            //CpuTypeId = cpuTypeId;
            //Rack = rack;
            //Slot = slot;
            //ConnectionTypeId = connectionTypeId;
        }

        public ModbusConnection(
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable
            //int? cpuTypeId,
            //short? rack,
            //short? slot, 
            //int? connectionTypeId
        )
            : base(
                //LogManager.GetCurrentClassLogger(),
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            //CpuTypeId = cpuTypeId;
            //Rack = rack;
            //Slot = slot;
            //ConnectionTypeId = connectionTypeId;

        }

        public ModbusConnection(
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable //
            //int? cpuTypeId,
            //short? rack,
            //short? slot, 
            //int? connectionTypeId
        )
            : base(
                //LogManager.GetCurrentClassLogger(),
                id,
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            //CpuTypeId = cpuTypeId;
            //Rack = rack;
            //Slot = slot;
            //ConnectionTypeId = connectionTypeId;

        }

        //public S7Connection(
        //    int automationTypeId,
        //    string name,
        //    string ip,
        //    bool enable,
        //    bool writeEnable,//
        //    //Guid connectionId,
        //    //Guid stdConnectionId,
        //    int cpuTypeId,
        //    short rack,
        //    short slot, 
        //    int connectionTypeId
        //)
        //    :base(
        //        LogManager.GetCurrentClassLogger(),
        //        //stdConnectionId,
        //        automationTypeId,
        //        name,
        //        ip,
        //        enable,
        //        writeEnable
        //        )
        //{
        //    //S7ConnectionId = connectionId;
        //    //StdConnectionId = stdConnectionId;
        //    CpuTypeId = cpuTypeId;
        //    Rack = rack;
        //    Slot = slot;
        //    ConnectionTypeId = connectionTypeId;
        //    //StdConnection = base;
        //}

        //public S7Connection(
        //    int automationTypeId,
        //    string name,
        //    string ip,
        //    bool enable,
        //    bool writeEnable,//
        //    //Guid s7ConnectionId,
        //    //Guid stdConnectionId,
        //    int cpuTypeId,
        //    short rack,
        //    short slot, 
        //    int connectionTypeId
        //    //Common.Connection stdConnection
        //)
        //    :base(
        //        LogManager.GetCurrentClassLogger(),
        //        //stdConnectionId,
        //        automationTypeId,
        //        name,
        //        ip,
        //        enable,
        //        writeEnable
        //        )
        //{
        //    //S7ConnectionId = s7ConnectionId;
        //    //StdConnectionId = stdConnectionId;
        //    CpuTypeId = cpuTypeId;
        //    Rack = rack;
        //    Slot = slot;
        //    ConnectionTypeId = connectionTypeId;
        //    //StdConnection = stdConnection;
        //}

        //public void Modify(
        //    //Guid stdConnectionId,
        //    int cpuTypeId,
        //    short rack,
        //    short slot, int connectionTypeId
        //)
        //{
        //    //StdConnectionId = stdConnectionId;
        //    CpuTypeId = cpuTypeId;
        //    Rack = rack;
        //    Slot = slot;
        //    ConnectionTypeId = connectionTypeId;
        //}

        #endregion

        public override void Initiate()
        {
            //Logger.Trace("Domain.Entity.S7.S7Connection Initiate: " + Name);
            //if (CpuTypeId != null)
            //{
            //    ClientRead = new Plc((Std.Com.Driver.S7.CpuType) CpuTypeId, Ip, Rack ?? 0, Slot ?? 0);
            //    TryConnectRead();
            //}

            //if (CpuTypeId != null && WriteEnable)
            //{
            //    ClientWrite = new Plc((Std.Com.Driver.S7.CpuType) CpuTypeId, Ip, Rack ?? 0, Slot ?? 0);
            //    TryConnectWrite();
            //}

            ////Create SubGroups
            //SetTag();

        }

        //public void Initiate(Common.Connection connection)
        //{
        //    //StdConnection = connection;
        //    //Logger.Trace("Domain.Entity.S7.Connection Initiate: " + StdConnection.Name);
        //    //ClientRead = new Plc((Std.Com.Driver.S7.CpuType)CpuTypeId, StdConnection.Ip, Rack, Slot);

        //    //if (StdConnection.WriteEnable)
        //    //{
        //    //    ClientWrite = new Plc((Std.Com.Driver.S7.CpuType)CpuTypeId, StdConnection.Ip, Rack, Slot);
        //    //}

        //    TryConnectRead();
        //}

        //public async void TryConnectRead()
        //{
        //    var policy = Policy
        //        .Handle<Exception>()
        //        //.OrResult<Plc>(r => r.IsConnected == false)
        //        .WaitAndRetryForeverAsync(retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
        //            (ex, time) =>
        //                    {
        //                        //Logger.Warn("TryConnectRead: " + ex.Exception.Message + " - " + ex.Exception.StackTrace);
        //                        Logger.Warn("TryConnectRead: " + ex.Message + " - " + ex.StackTrace);
        //                    }
        //                );

        //    //await policy.Execute(async () => await ClientRead.OpenAsync());

        //    await policy.ExecuteAsync(() => ClientRead.OpenAsync());
        //}

        //public async void TryConnectWrite()
        //{
        //    var policy = Policy
        //        .Handle<Exception>()
        //        //.OrResult<Plc>(r => r.IsConnected == false)
        //        .WaitAndRetryForeverAsync(retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
        //            (ex, time) =>
        //            {
        //                //Logger.Warn("TryConnectRead: " + ex.Exception.Message + " - " + ex.Exception.StackTrace);
        //                Logger.Warn("TryConnectWrite: " + ex.Message + " - " + ex.StackTrace);
        //            }
        //        );

        //    //await policy.Execute(async () => await ClientRead.OpenAsync());

        //    await policy.ExecuteAsync(() => ClientWrite.OpenAsync());
        //}

        //public override async Task ReadTags()
        //{
        //    //StdConnection.Tags
        //    //Logger.Trace("Domain.Entity.S7.S7Connection ReadTags! ");
        //    //Read(_readTags[0]);

        //    foreach (var readTags in _readTags)
        //    {
        //        await Read(readTags.Value);
        //    }
        //    //return Task.CompletedTask;
        //}

        //private void SetTag()
        //{
        //    var readTags = Tags.Where(t => t.InputOutput.Equals("R") || t.InputOutput.Equals("RW")).Cast<S7Tag>().ToList();
        //    var items = 18;

        //    switch (CpuTypeId??0)
        //    {
        //        case 0:
        //        case 10:
        //        case 30:
        //            items = 18;
        //            break;

        //        case 20:
        //        case 40:
        //            items = 20;
        //            break;

        //        default:
        //            break;
        //    }

        //    if (readTags.Count > 20)
        //    {
        //        //ToDo

        //        for (int i = 0; i < readTags.Count() / items; i++)
        //        {
        //            if (!_readTags.ContainsKey(i))
        //            {
        //                _readTags.Add(i, readTags.GetRange(i*items, items));
        //            }
        //        }

        //        if (readTags.Count % items != 0)
        //        {
        //            _readTags.Add(
        //                readTags.Count, 
        //                readTags.GetRange(readTags.Count * items, readTags.Count % items));
        //        }
        //    }
        //    else
        //    {
        //        _readTags.Add(0, readTags);
        //    }
        //}

        //private async Task Read(IReadOnlyList<S7Tag> tagList)
        //{
        //    Task<List<DataItem>> result = ClientRead.ReadMultipleVarsAsync(tagList.Select(t => t.DataItemTag).ToList());

        //    await result;

        //    for (int i = 0; i < tagList.Count; i++)
        //    {
        //        await tagList[i].SetReadValue(result.Result[i].Value.ToString()); //ToDo

        //    }
        //}//Read

        //private async Task HandleAsync(S7Tag tag)
        //{
        //    //await Task.Factory.StartNew(() =>
        //    //{               
        //    try
        //    {
        //        //await s7Tag.UpdateValueAsync();
        //        //_s7Plc.S7Group.Logger.Info("S7MVar Handle: " + s7Tag.DBTag.TagName + s7Tag.Value);

        //        if (s7Tag.DbTag.TagName.Equals("WatchDogRead"))
        //        {
        //            await WatchDogAsync(); //ToDo
        //            //await _s7Plc.S7Group.HandleItemAsync(s7Tag, DateTime.Now);
        //        }
        //        else
        //        {
        //            await _s7Plc.S7Group.HandleItemAsync(s7Tag, DateTime.Now);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //_s7Plc.S7Group.Logger.Error("S7MVar Handle: " + s7Tag.DbTag.TagName + " " + ex.Message);
        //    }
        //    //});
        //}

        //private void SetGroups(KeyValuePair<string, S7MVar> s7MVar, int bytes)
        //    {
        //        //S7Engine.Logger.Fatal("SetGroups: " + s7MVar.Key);
        //        try
        //        {
        //            var tagRead = TagReadList.Where(x => x.DbTag.ConnName.Equals(s7MVar.Key)).ToList();

        //            if (tagRead.Count > bytes)
        //            {
        //                for (int i = 0; i < tagRead.Count() / bytes; i++)
        //                {
        //                    if (DictionaryTagReadMVar.ContainsKey(s7MVar.Key))
        //                    {
        //                        if (!DictionaryTagReadMVar[s7MVar.Key].ContainsKey(i))
        //                        {
        //                            DictionaryTagReadMVar[s7MVar.Key].Add(i, tagRead.GetRange(i * bytes, bytes));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        DictionaryTagReadMVar.Add(s7MVar.Key, new Dictionary<int, List<S7Tag>>());
        //                        DictionaryTagReadMVar[s7MVar.Key].Add(i, tagRead.GetRange(i * bytes, bytes));
        //                    }
        //                }

        //                if (tagRead.Count % bytes != 0)
        //                {
        //                    DictionaryTagReadMVar[s7MVar.Key].Add(DictionaryTagReadMVar[s7MVar.Key].Count,
        //                        tagRead.GetRange(DictionaryTagReadMVar[s7MVar.Key].Count * bytes,
        //                            tagRead.Count % bytes));

        //                }
        //            }
        //            else
        //            {
        //                DictionaryTagReadMVar.Add(s7MVar.Key, new Dictionary<int, List<S7Tag>>());
        //                DictionaryTagReadMVar[s7MVar.Key].Add(0, tagRead);
        //            }

        //            var tagWrite = TagWriteList.Where(x => x.DbTag.ConnName.Equals(s7MVar.Key)).ToList();

        //            if (tagWrite.Count > bytes)
        //            {
        //                for (int i = 0; i < tagWrite.Count() / bytes; i++)
        //                {
        //                    if (DictionaryTagWriteMVar.ContainsKey(s7MVar.Key))
        //                    {
        //                        if (!DictionaryTagWriteMVar[s7MVar.Key].ContainsKey(i))
        //                        {
        //                            DictionaryTagWriteMVar[s7MVar.Key].Add(i, tagWrite.GetRange(i * bytes, bytes));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        DictionaryTagWriteMVar.Add(s7MVar.Key, new Dictionary<int, List<S7Tag>>());
        //                        DictionaryTagWriteMVar[s7MVar.Key].Add(i, tagWrite.GetRange(i * bytes, bytes));
        //                    }
        //                }

        //                if (tagWrite.Count % bytes != 0)
        //                {
        //                    DictionaryTagWriteMVar[s7MVar.Key].Add(DictionaryTagWriteMVar[s7MVar.Key].Count,
        //                        tagWrite.GetRange(DictionaryTagWriteMVar[s7MVar.Key].Count * bytes,
        //                            tagWrite.Count % bytes));
        //                }
        //            }
        //            else
        //            {
        //                DictionaryTagWriteMVar.Add(s7MVar.Key, new Dictionary<int, List<S7Tag>>());
        //                DictionaryTagWriteMVar[s7MVar.Key].Add(0, tagWrite);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            S7Engine.Logger.Error("S7Group SetGroups: " + ex.Message);
        //        }
        //    }
    }
}