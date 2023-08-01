using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix
{
    [ProtoContract]
    public class LogixConnection : IAppDtoObject<
        App.Dto.Req.Remove.Logix.LogixConnection,
        App.Dto.Req.Add.Logix.LogixConnection,
        App.Dto.Req.Update.Logix.LogixConnection,
        App.Dto.Req.Copy.Logix.LogixConnection>
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] [Browsable(false)] public int AutomationTypeId { get; set; }

        [ProtoMember(3)] public string Name { get; set; }

        [ProtoMember(4)] public string Ip { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        [ProtoMember(6)] public bool WriteEnable { get; set; }

        [ProtoMember(7)] public byte[] Path { get; set; }

        public LogixConnection() { }

        public LogixConnection(
            Guid id,
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable,
            byte[] path
        )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            Path = path;
        }

        public App.Dto.Req.Remove.Logix.LogixConnection GetRemoveReq()
        {
            return new App.Dto.Req.Remove.Logix.LogixConnection(Id);
        }

        public App.Dto.Req.Add.Logix.LogixConnection GetAddReq()
        {
            return new App.Dto.Req.Add.Logix.LogixConnection(AutomationTypeId, Name, Ip, Enable, WriteEnable, Path);
        }

        public App.Dto.Req.Update.Logix.LogixConnection GetUpdateReq()
        {
            return new App.Dto.Req.Update.Logix.LogixConnection(Id, AutomationTypeId, Name, Ip, Enable, WriteEnable,
                Path);
        }

        public App.Dto.Req.Copy.Logix.LogixConnection GetCopyReq()
        {
            return new App.Dto.Req.Copy.Logix.LogixConnection(AutomationTypeId, Name, Ip, Enable, WriteEnable, Path);
        }
    }
}