using KSociety.Com.Driver.Enip.Eipnet.Cip;
using KSociety.Com.Driver.Enip.Eipnet.Eip;

namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    internal class WriteDataServiceReply
    {
        public byte Service { get; internal set; }
        public byte Reserved { get; internal set; }
        public ushort Status { get; internal set; }

        public WriteDataServiceReply(EncapsReply reply)
        {
            EncapsRRData rrData = new EncapsRRData();

            CommonPacket cpf = new CommonPacket();
            int temp = 0;
            rrData.Expand(reply.EncapsData, 0, out temp);
            cpf = rrData.CPF;

            MessageRouterResponse response = new MessageRouterResponse();
            response.Expand(cpf.DataItem.Data, 2, out temp);

            if (response.GeneralStatus != 0)
                return;

            Service = response.ReplyService;
            Status = response.GeneralStatus;
        }
    }
}
