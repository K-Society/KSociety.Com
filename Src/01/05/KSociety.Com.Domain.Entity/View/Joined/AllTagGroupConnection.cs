using System;

namespace KSociety.Com.Domain.Entity.View.Joined;

public class AllTagGroupConnection
{
    #region [Propery]

    //public Guid StdTagId { get; private set; }

    public Guid Id { get; private set; }

    public string TagName { get; private set; }

    public Guid ConnectionId { get; private set; }

    public string ConnectionName { get; private set; }

    public int AutomationTypeId { get; private set; }

    public string AutomationName { get; private set; }

    public string Ip { get; private set; }

    public bool WriteEnable { get; private set; }

    public string InputOutput { get; private set; }

    public string AnalogDigitalSignal { get; private set; }

    public bool Invoke { get; private set; }

    public Guid TagGroupId { get; private set; }

    public string TagGroupName { get; private set; }

    public int Clock { get; private set; }

    public int Update { get; private set; }

    public int DataBlock { get; private set; }

    public int Offset { get; private set; }

    public byte BitOfByte { get; private set; }

    public string MemoryAddress { get; private set; }

    public int WordLenId { get; private set; }

    public string WordLenName { get; private set; }

    public int AreaId { get; private set; }

    public string AreaName { get; private set; }

    public int StringLength { get; private set; }

    //public string TagPath { get; private set; }

    #endregion

    public AllTagGroupConnection(
        //Guid stdTagId,
        Guid id,
        string tagName,
        Guid connectionId,
        string connectionName,
        int automationTypeId,
        string automationName,
        string ip,
        bool writeEnable,
        string inputOutput,
        string analogDigitalSignal,
        bool invoke,
        Guid tagGroupId,
        string tagGroupName,
        int clock,
        int update,
        int dataBlock,
        int offset,
        byte bitOfByte,
        string memoryAddress,
        int wordLenId,
        string wordLenName,
        int areaId,
        string areaName,
        int stringLength
        //string tagPath
    )
    {
        //StdTagId = stdTagId;
        Id = id;
        TagName = tagName;
        ConnectionId = connectionId;
        ConnectionName = connectionName;
        AutomationTypeId = automationTypeId;
        AutomationName = automationName;
        Ip = ip;
        WriteEnable = writeEnable;
        InputOutput = inputOutput;
        AnalogDigitalSignal = analogDigitalSignal;
        Invoke = invoke;
        TagGroupId = tagGroupId;
        TagGroupName = tagGroupName;
        Clock = clock;
        Update = update;
        DataBlock = dataBlock;
        Offset = offset;
        BitOfByte = bitOfByte;
        MemoryAddress = memoryAddress;
        WordLenId = wordLenId;
        WordLenName = wordLenName;
        AreaId = areaId;
        AreaName = areaName;
        StringLength = stringLength;
        //TagPath = tagPath;
    }
}