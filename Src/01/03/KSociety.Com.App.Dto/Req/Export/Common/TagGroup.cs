using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.Common
{
    [ProtoContract]
    public class TagGroup : ExportReq
    {
        public TagGroup() { }

        public TagGroup(
            string fileName
        )
        {
            FileName = fileName;
        }
    }
}