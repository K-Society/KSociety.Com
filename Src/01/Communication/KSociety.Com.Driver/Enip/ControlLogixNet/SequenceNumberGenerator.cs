namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    internal static class SequenceNumberGenerator
    {

        //private static readonly object LockObject;
        private static ushort _sequenceNum;


        //public static ushort SequenceNumber
        //{
        //    get
        //    {
        //        lock (LockObject)
        //        {
        //            if (_sequenceNum == ushort.MaxValue)
        //                _sequenceNum = ushort.MinValue;
        //            _sequenceNum++;
        //            return _sequenceNum;
        //        }
        //    }
        //}

        public static ushort SequenceNumber(object lockObject)
        {
            lock (lockObject)
            {
                if (_sequenceNum == ushort.MaxValue)
                    _sequenceNum = ushort.MinValue;
                _sequenceNum++;
                return _sequenceNum;
            }            
        }

        //static SequenceNumberGenerator()
        //{
        //    //LockObject = new object();
        //}

    }
}
