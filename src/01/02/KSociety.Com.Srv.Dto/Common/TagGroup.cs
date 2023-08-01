using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common
{
    [ProtoContract]
    public class TagGroup : IAppDtoObject<
        App.Dto.Req.Remove.Common.TagGroup,
        App.Dto.Req.Add.Common.TagGroup,
        App.Dto.Req.Update.Common.TagGroup,
        App.Dto.Req.Copy.Common.TagGroup>
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] public string Name { get; set; }

        [ProtoMember(3)] public int Clock { get; set; }

        [ProtoMember(4)] public int Update { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        public TagGroup()
        {

        }

        public TagGroup
        (
            Guid tagGroupId,
            string name,
            int clock,
            int update,
            bool enable
        )
        {
            Id = tagGroupId;
            Name = name;
            Clock = clock;
            Update = update;
            Enable = enable;
        }

        public App.Dto.Req.Remove.Common.TagGroup GetRemoveReq()
        {
            return new App.Dto.Req.Remove.Common.TagGroup(Id);
        }

        public App.Dto.Req.Add.Common.TagGroup GetAddReq()
        {
            return new App.Dto.Req.Add.Common.TagGroup(Name, Clock, Update, Enable);
        }

        public App.Dto.Req.Update.Common.TagGroup GetUpdateReq()
        {
            return new App.Dto.Req.Update.Common.TagGroup(Id, Name, Clock, Update, Enable);
        }


        public App.Dto.Req.Copy.Common.TagGroup GetCopyReq()
        {
            return new App.Dto.Req.Copy.Common.TagGroup(Name, Clock, Update, Enable);
        }
    }
}