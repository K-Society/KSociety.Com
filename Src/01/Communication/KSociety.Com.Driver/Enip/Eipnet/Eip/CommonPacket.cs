using System;
using System.Collections.Generic;

namespace KSociety.Com.Driver.Enip.Eipnet.Eip;

/// <summary>
/// Common Packet Item Struct Equivalent
/// </summary>
public class CommonPacketItem : IPackable, IExpandable
{
    /// <summary>
    /// Type of the item encapsulated
    /// </summary>
    public ushort TypeId { get; set; }
    /// <summary>
    /// Length in bytes of the data to follow
    /// </summary>
    public ushort Length { get; set; }
    /// <summary>
    /// Data if Length > 0
    /// </summary>
    public byte[] Data { get; set; }

    /// <summary>
    /// Packs the CommonPacketItem into a byte array
    /// </summary>
    /// <returns>Array of byte</returns>
    public byte[] Pack()
    {
        byte[] retVal = new byte[4 + (Data == null ? 0 : Data.Length)];

        Length = (ushort)(Data == null ? 0 : Data.Length);

        Buffer.BlockCopy(BitConverter.GetBytes(TypeId), 0, retVal, 0, 2);
        Buffer.BlockCopy(BitConverter.GetBytes(Length), 0, retVal, 2, 2);
            
        if (Length > 0)
        {
            Buffer.BlockCopy(Data, 0, retVal, 4, Length);
        }

        return retVal;
    }

    /// <summary>
    /// Expands the data array beginning at Offset into a CommonPacketItem
    /// </summary>
    /// <param name="DataArray">Array that holds the raw packet item</param>
    /// <param name="Offset">Offset where the packet begins</param>
    /// <param name="NewOffset">[Out] Offset where the packet ends</param>
    public void Expand(byte[] DataArray, int Offset, out int NewOffset)
    {
        TypeId = BitConverter.ToUInt16(DataArray, Offset);
        Length = BitConverter.ToUInt16(DataArray, Offset + 2);

        if (Length > 0)
        {
            byte[] temp = new byte[Length];
            Buffer.BlockCopy(DataArray, Offset + 4, temp, 0, Length);
            Data = temp;
        }

        NewOffset = Offset + 4 + Length;
    }

    /// <summary>
    /// Returns a null address item
    /// </summary>
    /// <returns>Null Address Item</returns>
    public static CommonPacketItem GetNullAddressItem()
    {
        return new CommonPacketItem();
    }

    /// <summary>
    /// Returns a Connected Address Item
    /// </summary>
    /// <param name="connectionId">Connection Id</param>
    /// <returns>Address Item for the Common Packet Format</returns>
    public static CommonPacketItem GetConnectedAddressItem(uint connectionId)
    {
        CommonPacketItem cpi = new CommonPacketItem();
        cpi.TypeId = (ushort)CommonPacketTypeId.ConnectionBased;
        cpi.Length = 4;
        cpi.Data = BitConverter.GetBytes(connectionId);

        return cpi;
    }

    /// <summary>
    /// Returns a Sequenced Address Item
    /// </summary>
    /// <param name="connectionId">Connection Id</param>
    /// <param name="sequenceNumber">Sequence Number</param>
    /// <returns>Sequenced Address Item for the Common Packet Format</returns>
    public static CommonPacketItem GetSequencedAddressItem(uint connectionId, uint sequenceNumber)
    {
        CommonPacketItem cpi = new CommonPacketItem();
        cpi.TypeId = (ushort)CommonPacketTypeId.SequencedAddressItem;
        cpi.Length = 8;
        byte[] temp = new byte[8];
        Buffer.BlockCopy(BitConverter.GetBytes(connectionId), 0, temp, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(sequenceNumber), 0, temp, 4, 4);
        cpi.Data = temp;

        return cpi;
    }

    /// <summary>
    /// Returns an Unconnected Data Item
    /// </summary>
    /// <param name="message">Message to encapsulate</param>
    /// <returns>Unconnected Data Item for the Common Packet Format</returns>
    public static CommonPacketItem GetUnconnectedDataItem(byte[] message)
    {
        CommonPacketItem cpi = new CommonPacketItem();
        cpi.TypeId = (ushort)CommonPacketTypeId.UnconnectedMessage;
        cpi.Length = (ushort)(message == null ? 0 : message.Length);
        cpi.Data = message;
        return cpi;
    }

    /// <summary>
    /// Returns a Connected Data Item
    /// </summary>
    /// <param name="message">Message to encapsulate</param>
    /// <param name="sequenceNumber">Sequence Number</param>
    /// <returns>Connected Data Item for the Common Packet Format</returns>
    public static CommonPacketItem GetConnectedDataItem(byte[] message, ushort sequenceNumber)
    {
        CommonPacketItem cpi = new CommonPacketItem();
        cpi.TypeId = (ushort)CommonPacketTypeId.ConnectedTransportPacket;
        cpi.Length = (ushort)(message == null ? 0 : message.Length);
        byte[] fullMessage = new byte[2 + message.Length];
        //byte[] fullMessage = new byte[6 + Message.Length];
        Buffer.BlockCopy(BitConverter.GetBytes(sequenceNumber), 0, fullMessage, 0, 2);
        Buffer.BlockCopy(message, 0, fullMessage, 2, message.Length);
        cpi.Data = fullMessage;
        return cpi;
    }
}

/// <summary>
/// Common Packet Format
/// </summary>
public class CommonPacket : IPackable, IExpandable
{

    private List<CommonPacketItem> _items = new List<CommonPacketItem>();

    /// <summary>
    /// Number of items, must be at least 2
    /// </summary>
    public ushort ItemCount { get { return (ushort)(_items.Count + 2); } }
    /// <summary>
    /// Address Item
    /// </summary>
    public CommonPacketItem AddressItem { get; set; }
    /// <summary>
    /// Data Item
    /// </summary>
    public CommonPacketItem DataItem { get; set; }
    /// <summary>
    /// Optional Items
    /// </summary>
    public List<CommonPacketItem> OptionalItems { get { return _items; } }

    /// <summary>
    /// Creates a new CommonPacketItem using a Null Address Item and an Unconnected Data Item with a NULL message
    /// </summary>
    public CommonPacket()
    {
        AddressItem = CommonPacketItem.GetNullAddressItem();
        DataItem = CommonPacketItem.GetUnconnectedDataItem(null);
    }

    /// <summary>
    /// Adds an item to the optional items
    /// </summary>
    /// <param name="cpi"></param>
    public void AddItem(CommonPacketItem cpi)
    {
        _items.Add(cpi);
    }

    /// <summary>
    /// Packs the CommonPacket into a byte array
    /// </summary>
    /// <returns>Array of bytes</returns>
    public byte[] Pack()
    {
        List<byte> retVal = new List<byte>();

        retVal.AddRange(BitConverter.GetBytes((ushort)ItemCount));
        retVal.AddRange(AddressItem.Pack());
        retVal.AddRange(DataItem.Pack());

        for (int i = 0; i < _items.Count; i++)
            retVal.AddRange(_items[i].Pack());

        return retVal.ToArray();
    }

    /// <summary>
    /// Expands the byte array into a CommonPacket
    /// </summary>
    /// <param name="dataArray">Array with the Common Packet</param>
    /// <param name="offset">Place in the array the Common Packet begins</param>
    /// <param name="newOffset">Place where the Common Packet ends</param>
    public void Expand(byte[] dataArray, int offset, out int newOffset)
    {
        //First get the count...
        ushort count = BitConverter.ToUInt16(dataArray, offset);
        offset += 2;

        if (count < 2)
            throw new ArgumentOutOfRangeException("Invalid number of items, must be at least 2, value was " + count.ToString());

        AddressItem = new CommonPacketItem();
        AddressItem.Expand(dataArray, offset, out offset);
        //Offset += 2;
        DataItem = new CommonPacketItem();
        DataItem.Expand(dataArray, offset, out offset);

        if (count > 2)
        {
            for (int i = 2; i < count; i++)
            {
                offset += 1;
                CommonPacketItem cpi = new CommonPacketItem();
                cpi.Expand(dataArray, offset, out offset);
            }
        }

        newOffset = offset;
    }
}