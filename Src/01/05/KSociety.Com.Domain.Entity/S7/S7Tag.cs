using FluentValidation;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Domain.Entity.Common;
//using KSociety.Com.Driver.S7;
//using KSociety.Com.Driver.S7.Types;
using Microsoft.Extensions.Logging;
using S7.Net;
using S7.Net.Types;
using System;
using System.Threading.Tasks;

namespace KSociety.Com.Domain.Entity.S7
{
    public class S7Tag : Common.Tag
    {
        public DataItem DataItemTag { get; private set; }

        #region [Propery]

        public int? DataBlock { get; private set; }

        public int? Offset { get; private set; }

        public byte? BitOfByte { get; private set; }
        public virtual Common.Bit Bit { get; private set; }

        public int? WordLenId { get; private set; }
        public virtual WordLen WordLen { get; private set; }

        public int? AreaId { get; private set; }
        public virtual Area Area { get; private set; }

        public int? StringLength { get; private set; }

        #endregion

        #region [Constructor]
        //For Csv
        public S7Tag(
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId,
            int? dataBlock,
            int? offset,
            byte? bitOfByte,
            int? wordLenId,
            int? areaId,
            int? stringLength
        )
            : base(
                id,
                automationTypeId,
                name,
                connectionId,
                enable,
                inputOutput,
                analogDigitalSignal,
                memoryAddress,
                invoke,
                tagGroupId
            )
        {
            //Console.WriteLine("ForCSV: " + memoryAddress);
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            WordLenId = wordLenId;
            AreaId = areaId;
            StringLength = stringLength;

            var s7TagValidator = new Validator.S7.Tag();
            s7TagValidator.ValidateAndThrow(this);

            SetDataItem();
        }

        public S7Tag(
            ////IEventBus eventBus,
            INotifierMediatorService notifierMediatorService,
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            Connection connection,
            bool enable,
            string inputOutput, 
            string analogDigitalSignal, 
            string memoryAddress,
            bool invoke,
            Guid tagGroupId,
            TagGroup tagGroup,//
            int? dataBlock, 
            int? offset,
            byte? bitOfByte,
            int? wordLenId, 
            int? areaId,
            int? stringLength
        )
            :base(
                ////eventBus,
                ////LogManager.GetCurrentClassLogger(),
                ////new Logger<Tag>(),
                notifierMediatorService,
                id,
                automationTypeId,
                name,
                connectionId,
                connection,
                enable,
                inputOutput,
                analogDigitalSignal,
                memoryAddress,
                invoke,
                tagGroupId,
                tagGroup
                )
        {
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            WordLenId = wordLenId;
            AreaId = areaId;
            StringLength = stringLength;

            var s7TagValidator = new Validator.S7.Tag();
            s7TagValidator.ValidateAndThrow(this);

            SetDataItem();
        }

        //For GUI (Automapper)
        public S7Tag(
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId,
            int? dataBlock,
            int? offset,
            byte? bitOfByte,
            int? wordLenId,
            int? areaId,
            int? stringLength
        )
            : base(
                automationTypeId,
                name,
                connectionId,
                enable,
                inputOutput,
                analogDigitalSignal,
                memoryAddress,
                invoke,
                tagGroupId
            )
        {
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            WordLenId = wordLenId;
            AreaId = areaId;
            StringLength = stringLength;

            var s7TagValidator = new Validator.S7.Tag();
            s7TagValidator.ValidateAndThrow(this);

            //SetDataItem();
        }

        #endregion

        private void SetDataItem()
        {
            try
            {
                DataItemTag = new DataItem
                {
                    //Address = MemoryAddress,
                    DataType = (DataType)(AreaId ?? 132),
                    VarType = (VarType) (WordLenId ?? 0),
                    DB = DataBlock ?? 0,
                    StartByteAdr = Offset ?? 0,
                    BitAdr = BitOfByte ?? 0,
                    Count = 1 //ToDo forse non serve... serve serve
                };

                switch (DataItemTag.VarType)
                {
                    case VarType.String:
                        DataItemTag.Count = StringLength ?? 1;
                        break;

                    case VarType.S7String:
                        DataItemTag.Count = 254;
                        break;

                    default:
                        break;
                }

            }catch(Exception ex)
            {
                Logger.LogWarning("S7Tag SetDataItem: " + ex.Message + " - " + ex.StackTrace);
            }
        }

        public void Modify(
            Guid stdTagId,
            int dataBlock, int offset,
            byte bitOfByte,
            //string memoryAddress,
            int wordLenId, int areaId, int stringLength
        )
        {
            //StdTagId = stdTagId;
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            //Address = address;
            WordLenId = wordLenId;
            AreaId = areaId;
            StringLength = stringLength;

            var tagValidator = new Validator.S7.Tag();
            tagValidator.ValidateAndThrow(this);
        }

        //public override void WriteValue(string value)
        //{
        //    if (InputOutput.Equals("W") || InputOutput.Equals("RW"))
        //    {
        //        Value = value;
        //        //DataItemTag.Value = value;
        //        EventBus?.Publish(TagWriteEvent);
        //    }
        //}//WriteValue

        public override string ReadTagFromPlc()
        {
            string output = string.Empty;
            try
            {
                if (InputOutput.Equals("R") || InputOutput.Equals("RW"))
                {
                    //Value = value;
                    //DataItemTag.Value = value;
                    var connection = (S7Connection)Connection;

                    //ToDo Use Semafors
                    var result = connection.ClientRead.ReadAsync(DataItemTag.DataType, DataItemTag.DB, DataItemTag.StartByteAdr, DataItemTag.VarType, DataItemTag.Count, DataItemTag.BitAdr);

                    output = result.ToString();
                    //if (connection.WriteEnable)
                    //{
                    //    connection.ClientWrite.Write(DataItemTag);
                    //    output = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return output;
        }

        public override async ValueTask<string> ReadTagFromPlcAsync()
        {
            string output = string.Empty;
            try
            {
                if (InputOutput.Equals("R") || InputOutput.Equals("RW"))
                {
                    //Value = value;
                    //DataItemTag.Value = value;
                    var connection = (S7Connection)Connection;

                    //ToDo Use Semafors
                    var result = await connection.ClientRead.ReadAsync(DataItemTag.DataType, DataItemTag.DB,
                            DataItemTag.StartByteAdr, DataItemTag.VarType, DataItemTag.Count, DataItemTag.BitAdr)
                        .ConfigureAwait(false);

                    output = result.ToString();
                    //if (connection.WriteEnable)
                    //{
                    //    connection.ClientWrite.Write(DataItemTag);
                    //    output = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return output;
        }

        public override bool WriteTagToPlc(string value)
        {
            bool output = false;
            try
            {
                if (InputOutput.Equals("W") || InputOutput.Equals("RW"))
                {
                    UpdateTagValue(value);
                    var connection = (S7Connection)Connection;
                    if (connection.WriteEnable)
                    {
                        connection.ClientWrite.Write(DataItemTag);
                        output = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return output;
        }

        public override async ValueTask<bool> WriteTagToPlcAsync(string value)
        {
            //Logger.LogTrace("WriteTagToPlcAsync: 1" + Name + " " + value);
            bool output = false;
            try
            {
                if (InputOutput.Equals("W") || InputOutput.Equals("RW"))
                {
                    //Logger.LogTrace("WriteTagToPlcAsync: 2" + Name + " " + value);
                    UpdateTagValue(value);
                    var connection = (S7Connection) Connection;
                    if (connection.WriteEnable)
                    {
                        //Logger.LogTrace("WriteTagToPlcAsync: 2" + Name + " " + value);
                        if (DataItemTag is null)
                        {
                            Logger.LogWarning("WriteTagToPlcAsync DataItemTag is null!");
                            return false;
                        }

                        await connection.ClientWrite.WriteAsync(DataItemTag).ConfigureAwait(false);
                        output = true;
                    }
                }
            }
            catch (Exception ex)
            { 
                Logger.LogError("WriteTagToPlcAsync: " + Name + " " + value + " " + ex.Message + " - " + ex.StackTrace);
            }

            return output;
        }

        private void UpdateTagValue(string value)
        {
            Value = value;

            try
            {
                switch (DataItemTag.VarType)
                {
                    case VarType.Bit:
                        DataItemTag.Value = bool.Parse(value);

                        break;

                    case VarType.Word:
                        DataItemTag.Value = UInt16.Parse(value);
                        break;

                    case VarType.DWord:
                        DataItemTag.Value = System.UInt32.Parse(value);
                        break;

                    case VarType.Real:
                        DataItemTag.Value = System.Single.Parse(value);
                        break;

                    case VarType.Byte:
                        DataItemTag.Value = byte.Parse(value);
                        break;
                    case VarType.Int:
                        DataItemTag.Value = Int16.Parse(value);
                        break;
                    case VarType.DInt:
                        DataItemTag.Value = Int32.Parse(value);
                        break;
                    case VarType.String:
                        DataItemTag.Value = value;
                        break;
                    case VarType.S7String:
                        DataItemTag.Value = value;
                        DataItemTag.Count = value.Length; //254; //ToDo
                        break;
                    case VarType.Timer:
                        break;
                    case VarType.Counter:
                        break;
                    default:
                        Logger.LogWarning("UpdateTagValue: " + Name + " No VarType");
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("S7Tag UpdateTagValue: " + Name + " - " + value + " - " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
