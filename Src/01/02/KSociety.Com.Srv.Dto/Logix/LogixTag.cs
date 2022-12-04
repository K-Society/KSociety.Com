using System;
using System.ComponentModel;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Logix
{
    [ProtoContract]
    public class LogixTag : IAppDtoObject<
        App.Dto.Req.Remove.Logix.LogixTag,
        App.Dto.Req.Add.Logix.LogixTag,
        App.Dto.Req.Update.Logix.LogixTag,
        App.Dto.Req.Copy.Logix.LogixTag>
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [ProtoMember(2)] [Browsable(false)] public int AutomationTypeId { get; set; }

        [ProtoMember(3)] public string Name { get; set; }

        [ProtoMember(4), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid ConnectionId { get; set; }

        [ProtoMember(5)] public bool Enable { get; set; }

        [ProtoMember(6)] public string InputOutput { get; set; }

        [ProtoMember(7)] public string AnalogDigitalSignal { get; set; }

        [ProtoMember(8)] public string MemoryAddress { get; set; }

        [ProtoMember(9)] public bool Invoke { get; set; }

        [ProtoMember(10), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid TagGroupId { get; set; }

        public LogixTag()
        {

        }

        public LogixTag
        (
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable, string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId
        )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            ConnectionId = connectionId;
            Enable = enable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;
        }

        public App.Dto.Req.Remove.Logix.LogixTag GetRemoveReq()
        {
            return new App.Dto.Req.Remove.Logix.LogixTag(Id);
        }

        public App.Dto.Req.Add.Logix.LogixTag GetAddReq()
        {
            return new App.Dto.Req.Add.Logix.LogixTag(
                AutomationTypeId,
                Name,
                ConnectionId,
                Enable,
                InputOutput,
                AnalogDigitalSignal,
                MemoryAddress,
                Invoke,
                TagGroupId
            );
        }

        public App.Dto.Req.Update.Logix.LogixTag GetUpdateReq()
        {
            return new App.Dto.Req.Update.Logix.LogixTag(
                Id,
                AutomationTypeId,
                Name,
                ConnectionId,
                Enable,
                InputOutput,
                AnalogDigitalSignal,
                MemoryAddress,
                Invoke,
                TagGroupId
            );
        }

        public App.Dto.Req.Copy.Logix.LogixTag GetCopyReq()
        {
            return new App.Dto.Req.Copy.Logix.LogixTag(
                AutomationTypeId,
                Name,
                ConnectionId,
                Enable,
                InputOutput,
                AnalogDigitalSignal,
                MemoryAddress,
                Invoke,
                TagGroupId
            );
        }
    }
}