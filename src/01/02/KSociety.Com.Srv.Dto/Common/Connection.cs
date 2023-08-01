using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common
{
    [ProtoContract]
    public class Connection : IAppDtoObject<
        App.Dto.Req.Remove.Common.Connection,
        App.Dto.Req.Add.Common.Connection,
        App.Dto.Req.Update.Common.Connection,
        App.Dto.Req.Copy.Common.Connection>
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public int AutomationTypeId { get; set; }

        [ProtoMember(3)] public string Name { get; set; }

        [ProtoMember(4)] public string Ip { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        [ProtoMember(6)] public bool WriteEnable { get; set; }

        public Connection()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KSociety.Com.Srv.Dto.Common.Connection" /> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="automationTypeId"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="enable"></param>
        /// <param name="writeEnable"></param>
        public Connection(
            Guid id,
            int automationTypeId,
            string name, string ip,
            bool enable, bool writeEnable
        )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        public App.Dto.Req.Remove.Common.Connection GetRemoveReq()
        {
            return new App.Dto.Req.Remove.Common.Connection(Id);
        }

        public App.Dto.Req.Add.Common.Connection GetAddReq()
        {
            return new App.Dto.Req.Add.Common.Connection(AutomationTypeId, Name, Ip, Enable, WriteEnable);
        }

        public App.Dto.Req.Update.Common.Connection GetUpdateReq()
        {
            return new App.Dto.Req.Update.Common.Connection(Id, AutomationTypeId, Name, Ip, Enable, WriteEnable);
        }

        public App.Dto.Req.Copy.Common.Connection GetCopyReq()
        {
            return new App.Dto.Req.Copy.Common.Connection(AutomationTypeId, Name, Ip, Enable, WriteEnable);
        }
    }
}