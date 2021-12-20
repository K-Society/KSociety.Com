using System;
using KSociety.Com.Driver.Enip.Eipnet;
using KSociety.Com.Driver.Enip.Eipnet.Cip;
using KSociety.Com.Driver.Enip.Eipnet.Eip;

namespace KSociety.Com.Driver.Enip.ControlLogixNet;

internal class LogixServices
{
    public static ReadDataServiceRequest BuildLogixReadDataRequest(LogixTag tag, ushort number, out int requestSize)
    {
        if (tag.TagInfo != null && tag.TagInfo.IsStructure == false && tag.TagInfo.Dimensions == 0)
        {
            //Short version
            ushort size = 0;
            switch ((CipType)tag.TagInfo.DataType)
            {
                case CipType.BITS:
                case CipType.BOOL:
                    size = 1; break;
                case CipType.DINT:
                    size = 4; break;
                case CipType.INT:
                    size = 2; break;
                case CipType.LINT:
                    size = 8; break;
                case CipType.REAL:
                    size = 4; break;
                case CipType.SINT:
                    size = 1; break;
                default:
                    return BuildLogixReadDataRequest(tag.Address, number, out requestSize);
            }

            return BuildShortReadDataRequest(tag.TagInfo.MemoryAddress, number, size, out requestSize);
        }
        else
        {
            //Long version
            return BuildLogixReadDataRequest(tag.Address, number, out requestSize);
        }
    }

    public static ReadDataServiceRequest BuildLogixReadDataRequest(string tagAddress, ushort number, out int requestSize)
    {
        byte[] newIOI = Ioi.BuildIOI(tagAddress);
        //Console.WriteLine(BitConverter.ToString(newIOI));
        int pathLen = newIOI.Length;// IOI.BuildIOI(null, tagAddress);
        ReadDataServiceRequest request = new ReadDataServiceRequest();
        request.Service = (byte)ControlNetService.CipReadData; //CIP_ReadDataFragmented
        //request.Service = (byte)ControlNetService.CIP_ReadDataFragmented;
        request.PathSize = (byte)(pathLen / 2);
        byte[] path = new byte[pathLen];
        Buffer.BlockCopy(newIOI, 0, path, 0, newIOI.Length);
        //IOI.BuildIOI(path, tagAddress);
        request.Path = path;
        request.Elements = number;

        requestSize = request.Size;

        return request;
    }

    public static ReadDataServiceRequest BuildLogixReadDataRequestFragment(string tagAddress, ushort number, out int requestSize)
    {
        byte[] newIOI = Ioi.BuildIOI(tagAddress);

        int pathLen = newIOI.Length;// IOI.BuildIOI(null, tagAddress);
        ReadDataServiceRequest request = new ReadDataServiceRequest();
        request.Service = (byte)ControlNetService.CipReadDataFragmented;
        request.PathSize = (byte)(pathLen / 2);
        byte[] path = new byte[pathLen];
        Buffer.BlockCopy(newIOI, 0, path, 0, newIOI.Length);
        //IOI.BuildIOI(path, tagAddress);
        request.Path = path;
        request.Elements = number;

        requestSize = request.Size;

        return request;
    }

    public static ReadDataServiceRequest BuildShortReadDataRequest(uint tagInstance, ushort number, ushort size, out int requestSize)
    {
        byte[] newIOI = Ioi.BuildIOI(tagInstance);

        int pathLen = newIOI.Length;
        ReadDataServiceRequest request = new ReadDataServiceRequest();
        request.Service = 0x4E;// (byte)ControlNetService.CIP_ReadData;
        request.PathSize = 0x03;
        byte[] path = new byte[] { 0x20, 0xB2, 0x25, 0x00, 0x21, 0x00 };
        request.Path = path;
        request.Elements = number;

        byte[] addData = new byte[10 + newIOI.Length];
        addData[0] = 0x02; addData[1] = 0x00; addData[2] = 0x01; addData[3] = 0x01; addData[4] = 0x01;
        addData[5] = (byte)(size & 0xFF); addData[6] = (byte)((size & 0xFF00) >> 8);
        addData[7] = 0x03; addData[8] = 0x20; addData[9] = 0x6B;
        Buffer.BlockCopy(newIOI, 0, addData, 10, newIOI.Length);
        request.AddtlData = addData;

        requestSize = request.Size;

        return request;
    }

    public static ReadDataServiceRequest BuildFragmentedReadDataRequest(string tagAddress, ushort number, uint offset, out int requestSize)
    {
        byte[] newIOI = Ioi.BuildIOI(tagAddress);

        int pathLen = newIOI.Length;// IOI.BuildIOI(null, tagAddress);
        ReadDataServiceRequest request = new ReadDataServiceRequest();
        request.Service = (byte)ControlNetService.CipReadDataFragmented;
        request.PathSize = (byte)(pathLen / 2);
        request.IsFragmented = true;
        request.DataOffset = offset;
        byte[] path = new byte[pathLen];
        Buffer.BlockCopy(newIOI, 0, path, 0, newIOI.Length);
        //IOI.BuildIOI(path, tagAddress);
        request.Path = path;
        request.Elements = number;

        requestSize = request.Size;

        return request;
    }

    public static ReadDataServiceReply ReadLogixDataFragmented(SessionInfo si, string tagAddress, ushort elementCount, uint byteOffset, object syncRoot) //ToDo syncRoot
    {
        int requestSize = 0;
        ReadDataServiceRequest request = BuildFragmentedReadDataRequest(tagAddress, elementCount, byteOffset, out requestSize);

        EncapsRRData rrData = new EncapsRRData();
        rrData.CPF = new CommonPacket();
        rrData.CPF.AddressItem = CommonPacketItem.GetConnectedAddressItem(si.ConnectionParameters.O2T_CID);
        rrData.CPF.DataItem = CommonPacketItem.GetConnectedDataItem(request.Pack(), SequenceNumberGenerator.SequenceNumber(syncRoot));
        rrData.Timeout = 2000;

        EncapsReply reply = si.SendUnitData(rrData.CPF.AddressItem, rrData.CPF.DataItem);

        if (reply == null)
            return null;

        if (reply.Status != 0 && reply.Status != 0x06)
        {
            //si.LastSessionError = (int)reply.Status;
            return null;
        }

        return new ReadDataServiceReply(reply);
    }

    public static ReadDataServiceReply ReadLogixData(SessionInfo si, string tagAddress, ushort elementCount, object syncRoot) //ToDo syncRoot
    {
        int requestSize = 0;
        ReadDataServiceRequest request = BuildLogixReadDataRequest(tagAddress, elementCount, out requestSize);

        EncapsRRData rrData = new EncapsRRData();
        rrData.CPF = new CommonPacket();
        rrData.CPF.AddressItem = CommonPacketItem.GetConnectedAddressItem(si.ConnectionParameters.O2T_CID);
        rrData.CPF.DataItem = CommonPacketItem.GetConnectedDataItem(request.Pack(), SequenceNumberGenerator.SequenceNumber(syncRoot));
        rrData.Timeout = 2000;
        //rrData.Timeout = 20000;

        EncapsReply reply = si.SendUnitData(rrData.CPF.AddressItem, rrData.CPF.DataItem);


        if (reply == null)
            return null;


        if (reply.Status != 0 && reply.Status != 0x06)
        {
                
            //si.LastSessionError = (int)reply.Status;
            return null;
        }

        return new ReadDataServiceReply(reply);
    }

    public static ReadDataServiceReply ReadLogixDataFragment(SessionInfo si, string tagAddress, ushort elementCount, object syncRoot) //ToDo syncRoot
    {
        int requestSize = 0;
        ReadDataServiceRequest request = BuildLogixReadDataRequestFragment(tagAddress, elementCount, out requestSize);

        EncapsRRData rrData = new EncapsRRData();
        rrData.CPF = new CommonPacket();
        rrData.CPF.AddressItem = CommonPacketItem.GetConnectedAddressItem(si.ConnectionParameters.O2T_CID);
        rrData.CPF.DataItem = CommonPacketItem.GetConnectedDataItem(request.Pack(), SequenceNumberGenerator.SequenceNumber(syncRoot));
        rrData.Timeout = 2000;

        EncapsReply reply = si.SendUnitData(rrData.CPF.AddressItem, rrData.CPF.DataItem);

        if (reply == null)
            return null;

        if (reply.Status != 0 && reply.Status != 0x06)
        {
            //si.LastSessionError = (int)reply.Status;
            return null;
        }

        return new ReadDataServiceReply(reply);
    }

#if MONO
		public static WriteDataServiceRequest BuildLogixWriteDataRequest(string tagAddress, ushort dataType, ushort elementCount, byte[] data)
		{
			return BuildLogixWriteDataRequest(tagAddress, dataType, elementCount, data, 0x0000);
		}
#endif
#if MONO
		public static WriteDataServiceRequest BuildLogixWriteDataRequest(string tagAddress, ushort dataType, ushort elementCount, byte[] data, ushort structHandle)
#else
    public static WriteDataServiceRequest BuildLogixWriteDataRequest(string tagAddress, ushort dataType, ushort elementCount, byte[] data, ushort structHandle = 0x0000)
#endif
    {
        byte[] newIOI = Ioi.BuildIOI(tagAddress);

        int pathLen = newIOI.Length;
        WriteDataServiceRequest request = new WriteDataServiceRequest();
        request.Service = (byte)ControlNetService.CipWriteData;
        request.PathSize = (byte)(pathLen / 2);
        byte[] path = new byte[pathLen];
        Buffer.BlockCopy(newIOI, 0, path, 0, newIOI.Length);
        request.Path = path;
        request.Elements = elementCount;
        request.DataType = dataType;
        request.StructHandle = structHandle;
        request.Data = data;

        return request;
    }
		
#if MONO
		public static WriteDataServiceRequest BuildFragmentedWriteRequest(string tagAddress, ushort dataType, ushort elementCount, uint offset, byte[] data)
		{
			return BuildFragmentedWriteRequest(tagAddress, dataType, elementCount, offset, data, 0x0000);
		}
#endif
#if MONO
		public static WriteDataServiceRequest BuildFragmentedWriteRequest(string tagAddress, ushort dataType, ushort elementCount, uint offset, byte[] data, ushort structHandle)
#else
    public static WriteDataServiceRequest BuildFragmentedWriteRequest(string tagAddress, ushort dataType, ushort elementCount, uint offset, byte[] data, ushort structHandle = 0x0000)
#endif
    {
        byte[] newIOI = Ioi.BuildIOI(tagAddress);

        int pathLen = newIOI.Length;
        WriteDataServiceRequest request = new WriteDataServiceRequest();
        request.Service = (byte)ControlNetService.CipWriteDataFragmented;
        request.PathSize = (byte)(pathLen / 2);
        byte[] path = new byte[pathLen];
        Buffer.BlockCopy(newIOI, 0, path, 0, newIOI.Length);
        request.Path = path;
        request.Elements = elementCount;
        request.DataType = dataType;
        request.StructHandle = structHandle;
        request.IsFragmented = true;
        request.Offset = offset;
        request.Data = data;

        return request;
    }
		
#if MONO
		public static WriteDataServiceReply WriteLogixData(SessionInfo si, string tagAddress, ushort dataType, ushort elementCount, byte[] data)
		{
			return WriteLogixData(si, tagAddress, dataType, elementCount, data, 0x0000);
		}
#endif
#if MONO
		public static WriteDataServiceReply WriteLogixData(SessionInfo si, string tagAddress, ushort dataType, ushort elementCount, byte[] data, ushort structHandle)
#else
    public static WriteDataServiceReply WriteLogixData(SessionInfo si, string tagAddress, ushort dataType, ushort elementCount, byte[] data, object syncRoot, ushort structHandle = 0x0000) //ToDo syncRoot
#endif
    {
        WriteDataServiceRequest request = BuildLogixWriteDataRequest(tagAddress, dataType, elementCount, data, structHandle);

        EncapsRRData rrData = new EncapsRRData();
        rrData.CPF = new CommonPacket();
        rrData.CPF.AddressItem = CommonPacketItem.GetConnectedAddressItem(si.ConnectionParameters.O2T_CID);
        rrData.CPF.DataItem = CommonPacketItem.GetConnectedDataItem(request.Pack(), SequenceNumberGenerator.SequenceNumber(syncRoot));
        rrData.Timeout = 2000;

        EncapsReply reply = si.SendUnitData(rrData.CPF.AddressItem, rrData.CPF.DataItem);

        if (reply == null)
            return null;

        if (reply.Status != 0)
        {
            return null;
        }

        return new WriteDataServiceReply(reply);
    }

}