using System;
using KSociety.Com.Driver.Enip.Eipnet.Eip;

namespace KSociety.Com.Driver.Enip.Eipnet.Cip;

public static class MessageRouter
{

    public static MessageRouterRequest BuildMR_Request(byte service, byte[] path, byte requestPathSize, byte[] requestData)
    {
        MessageRouterRequest request = new MessageRouterRequest();
        request.Service = service;
        request.Request_Path_Size = (byte)(requestPathSize / 2 + (requestPathSize % 2));
        request.Request_Path = path;
        Buffer.BlockCopy(path, 0, request.Request_Path, 0, path.Length);
        request.Request_Data = requestData;

        return request;
    }

    public static EncapsReply SendMR_Request(Eip.SessionInfo session, MessageRouterRequest request)
    {
        CommonPacketItem dataItem = CommonPacketItem.GetUnconnectedDataItem(request.Pack());

        EncapsReply response = session.SendRRData(CommonPacketItem.GetNullAddressItem(), dataItem);

        return response;
    }

    public static EncapsReply SendMR_Request(Eip.SessionInfo si, byte service,
        byte[] path, byte[] requestBytes)
    {
        MessageRouterRequest request = BuildMR_Request(service, path, (byte)path.Length, requestBytes);

        return SendMR_Request(si, request);
    }

}