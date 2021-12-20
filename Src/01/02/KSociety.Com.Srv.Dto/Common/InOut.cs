using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common;

[ProtoContract]
public class InOut : IObject
{
    [ProtoMember(1)]
    public string InputOutput { get; set; }

    [ProtoMember(2)]
    public string InputOutputName { get; set; }

    public InOut() { }

    public InOut
    (
        string inputOutput,
        string inputOutputName
    )
    {
        InputOutput = inputOutput;
        InputOutputName = inputOutputName;
    }
}