using System;
using System.Collections;

namespace KSociety.Com.Driver.Modbus
{
    public class ModbusTAG
    {
        #region [Private]
        private string name = " ";
        private byte unit = 0;
        private UInt16 startAdress = 22000;
        private byte size = 1;
        //private byte sizeString = 126;
        private UInt16 id = 3;
        //private int value = 0;
        //private PLC plc = null;
        private Master MBmaster;
        private byte[] data;
        private byte[] readOut;
        private byte[] readOutString = new byte[255];
        private char[] spazio = { ' ' };
        private int[] myWord = new int[1];
        private BitArray bits1 = new BitArray(new bool[] { false, false, false, false, false, false, false, false });
        //private BitArray bits2 = new BitArray(new bool[] { false, false, false, false, false, false, false, false });
        #endregion
        #region [IO]
        public UInt16 ID
        {
            get => id; set => id = value;
        }

        public UInt16 StartAddress
        {
            get => startAdress; set => startAdress = value;
        }

        public string Name
        {
            get => name; set => name = value;
        }

        public byte Unit
        {
            get => unit; set => unit = value;
        }
        public byte Length
        {
            get => size; set => size = value;
        }

        public bool Bit => GetDataBit();
        public int Value => GetDataInt(); public int Value2 => GetDataInt2();
        public string ValueString => GetDataString();
        public Int16 WriteValue
        {
            set => WriteDataInt(value);
        }

        public bool WriteBit
        {
            set => WriteDataBit(value);
        }
        //public PLC Plc
        //{
        //    get { return this.plc; }
        //    set { this.plc = value; }
        //}
        #endregion

        public ModbusTAG(Master myMaster, string myName, UInt16 myUnit, UInt16 mySize, int SStartAdress)
        {
            Name = myName;
            Unit = (byte)myUnit;
            Length = (byte)mySize;
            //if (Name.Equals("WatchDogIN")) { StartAddress = ReadStartAdr(SStartAdress, 1); }
            //else if (Name.Equals("WatchDogOUT")) { StartAddress = ReadStartAdr(SStartAdress, 1); }
            //else
            //{
            StartAddress = ReadStartAdr(SStartAdress);
            //}
            //Plc = myPLC;
            MBmaster = myMaster;
            readOut = new byte[4];
            readOutString = new byte[255];

            MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);
            MBmaster.OnException += new Master.ExceptionData(MBmaster_OnException);
        }

        private byte StringToUnit(string _unit)
        {
            byte output = 0;
            if(_unit.Equals("0X"))
            {
                output = 0;
            }
            return output;
        }

        private byte StringToSize(string _size)
        {
            byte output = 0;
            if (_size.Equals("bit"))
            {
                id = 1;
                output = 1;
            }
            return output;
        }

        public ModbusTAG(Master myMaster, string myName, string myUnit, string mySize, int SStartAdress, int subAdress)
        {
            Name = myName;
            Unit = StringToUnit(myUnit);
            Length = StringToSize(mySize);
            //if (Name.Equals("WatchDogIN")) { StartAddress = ReadStartAdr(SStartAdress, 1); }
            //else if (Name.Equals("WatchDogOUT")) { StartAddress = ReadStartAdr(SStartAdress, 1); }
            //else
            //{
            StartAddress = ReadStartAdr(SStartAdress, subAdress);
            //}
            //Plc = myPLC;
            MBmaster = myMaster;
            readOut = new byte[4];
            readOutString = new byte[255];

            MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);
            MBmaster.OnException += new Master.ExceptionData(MBmaster_OnException);
        }

        //public TAG(Master myMaster, string myName, UInt16 myUnit, UInt16 mySize, int SStartAdress, int wd)
        //{
        //    Name = myName;
        //    Unit = (byte)myUnit;
        //    Length = (byte)mySize;
        //    StartAddress = ReadStartAdr(SStartAdress);
        //    //Plc = myPLC;
        //    MBmaster = myMaster;
        //    readOut = new byte[4];
        //    readOutString = new byte[255];

        //    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
        //}

        public void WriteDataInt(Int16 myData)
        {

            byte[] byteArray = BitConverter.GetBytes(myData);

            try
            {
                data = new Byte[2];
                data[0] = byteArray[1];
                data[1] = byteArray[0];

                MBmaster.WriteSingleRegister(7, unit, StartAddress, data);
                
            }
            catch (Exception)
            {
                //Global.myLog.Log(5, " TAG WriteData: " + ex.ToString());
            }
        }

        public void WriteDataBit(bool myData)
        {

            //byte[] byteArray = BitConverter.GetBytes(myData);

            try
            {
                //data = new Byte[2];
                //data[0] = byteArray[1];
                //data[1] = byteArray[0];

                //MBmaster.WriteSingleRegister(7, unit, StartAddress, data);

                MBmaster.WriteSingleCoils(5, unit, StartAddress, myData);

            }
            catch (Exception)
            {
                //Global.myLog.Log(5, " TAG WriteData: " + ex.ToString());
            }
        }

        private string GetDataString()
        {
            string myOut = String.Empty;// new string("");
            byte[] temp = new byte[250];
            //int[] word = new int[1];
            byte b;
            int ii;

            try
            {
                //MBmaster.ReadHoldingRegister()
                MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length, ref readOutString);
                //myOut = new Encoding.ASCII.GetString(readOutString, 0, readOutString.Length);

                //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                //if(readOutString.)
                //myOut = //encoding.GetString(readOutString);

                //readOutString.CopyTo(myOut, 0);
                for (int i = 0; i < readOutString.Length; i++)
                {
                    ii = i;
                    b = readOutString[i];
                    if ((i % 2) == 0) //numero Pari
                    {
                        temp[ii + 1] = b;
                    }
                    else
                    {
                        temp[ii - 1] = b;
                    }
                }

                foreach (byte bb in temp)
                {
                    myOut += (Char)bb;
                }

            }
            catch (Exception) { /* Global.myLog.Log(5, " TAG GetString: " + ex.ToString()); */}
            //myOut = BitConverter.ToInt32(readOut, 0);
            return myOut.TrimEnd(spazio);
        }

        private bool GetDataBit()
        {
            bool output = false;
            //int myOut = 0;
            int[] word = new int[1];

            byte[] myByte = new byte[Length];
            //byte[] readOut = 

            try
            {
                //MBmaster.ReadHoldingRegister()
                MBmaster.ReadCoils(ID, unit, StartAddress, Length, ref myByte);
                bits1 = new BitArray(myByte);
                output = bits1[0];
                //bits2 = new BitArray(readOut[1]);
                //Global.myLog.Log(4, " GetData: " + readOut.ToString());
                //if (readOut.Length < 2) return;
                //word = new int[readOut.Length / 2];
                //for (int x = 0; x < 2; x = x + 2)
                //{
                //    //Global.myLog.Log(4, " GetData: " + readOut[x].ToString());
                //    word[x / 2] = readOut[x] * 256 + readOut[x + 1];
                //}
                //foreach (bool b in bits1)
                //{
                //    Global.myLog.Log(4, " B1: " + b.ToString());
                //}

                //foreach (bool b in bits2)
                //{
                //    Global.myLog.Log(4, " B2: " + b.ToString());
                //}

            }
            catch (Exception) { /*Global.myLog.Log(5, " TAG GetData: " + ex.ToString()); word[0] = -1; */}
            //myOut = BitConverter.ToInt32(readOut, 0);
            return output;
        }



        private int GetDataInt()
        {
            //int myOut = 0;
            int[] word = new int[1];

            //byte[] readOut = 

            try
            {
                //MBmaster.ReadHoldingRegister()
                MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length, ref readOut);
                //bits1 = new BitArray(readOut);
                //bits2 = new BitArray(readOut[1]);
                //Global.myLog.Log(4, " GetData: " + readOut.ToString());
                //if (readOut.Length < 2) return;
                //word = new int[readOut.Length / 2];
                for (int x = 0; x < 2; x = x + 2)
                {
                    //Global.myLog.Log(4, " GetData: " + readOut[x].ToString());
                    word[x / 2] = readOut[x] * 256 + readOut[x + 1];
                }
                //foreach (bool b in bits1)
                //{
                //    Global.myLog.Log(4, " B1: " + b.ToString());
                //}

                //foreach (bool b in bits2)
                //{
                //    Global.myLog.Log(4, " B2: " + b.ToString());
                //}

            }
            catch (Exception) { /*Global.myLog.Log(5, " TAG GetData: " + ex.ToString()); word[0] = -1; */}
            //myOut = BitConverter.ToInt32(readOut, 0);
            return word[0];
        }

        public int GetDataInt2()
        {
            //Global.errorModbus = true;
            //int myOut = 0;
            int[] word = new int[1];

            //byte[] readOut = 

            try
            {
                //MBmaster.ReadHoldingRegister()
                MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length/*, ref readOut*/);

            }
            catch (Exception) {/* Global.myLog.Log(5, " TAG GetData2: " + ex.ToString()); myWord[0] = -1;*/ }
            //myOut = BitConverter.ToInt32(readOut, 0);
            return myWord[0];
        }

        private ushort ReadStartAdr(int myAdress, int subadress)
        {
            ushort output = 0;
            // Convert hex numbers into decimal
            //if (myAdress.IndexOf("0x", 0, myAdress.Length) == 0)
            //{
            //    string str = myAdress.Replace("0x", "");
            //    ushort hex = Convert.ToUInt16(str, 16);
            //    return hex;
            //}
            //else
            //{

            UInt16 myInt = Convert.ToUInt16(myAdress);
            UInt16 myIntSub = Convert.ToUInt16(subadress);
            //if (myInt != 0)
            //{
            //    myInt = (UInt16)(myInt - 1);
            //}
            //else
            //{
            //    myInt = 1;
            //}
            output = (ushort)(myInt + myIntSub);
            return output;
            //}
        }

        private ushort ReadStartAdr(int myAdress)
        {
            ushort output = 0;
            // Convert hex numbers into decimal
            //if (myAdress.IndexOf("0x", 0, myAdress.Length) == 0)
            //{
            //    string str = myAdress.Replace("0x", "");
            //    ushort hex = Convert.ToUInt16(str, 16);
            //    return hex;
            //}
            //else
            //{

            UInt16 myInt = Convert.ToUInt16(myAdress);
            
            if (myInt != 0)
            {
                myInt = (UInt16)(myInt - 1);
            }
            else
            {
                myInt = 1;
            }
            output = myInt;
            return output;
            //}
        }

        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            for (int x = 0; x < 2; x = x + 2)
            {
                //Global.myLog.Log(4, " GetData: " + readOut[x].ToString());
                myWord[x / 2] = values[x] * 256 + values[x + 1];
            }

        }

        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; /*Global.errorModbus = false;*/ break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; /*Global.errorModbus = false;*/ break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; /*Global.errorModbus = false;*/ break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; /* Global.errorModbus = false;*/ break;
                case Master.excAck: exc += "Acknoledge!"; /*Global.errorModbus = false;*/ break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; /*Global.errorModbus = false;*/ break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; /* Global.errorModbus = false; */ break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; /* Global.errorModbus = false; */ break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; /*Global.errorModbus = false;*/ break;
            }

            //MessageBox.Show(exc, "Modbus slave exception");
            //Global.myLog.Log(5, exc);
        }
    }
}
