using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.Common
{
    [ProtoContract]
    public class Connection : ImportReq
    {
        public Connection() { }

        public Connection(
            string fileName,
            byte[] byteArray
        )
        {
            FileName = fileName;
            ByteArray = byteArray;
            //var array = new byte[byteArray.Length];
            //Buffer.BlockCopy(byteArray, 0, array, 0, byteArray.Length);
            //ByteArray = array;
        }
    }
}
