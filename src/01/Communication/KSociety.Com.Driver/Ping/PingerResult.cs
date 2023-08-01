using System;
using System.Net;
using System.Net.NetworkInformation;
using KSociety.Base.InfraSub.Shared.Class;

namespace KSociety.Com.Driver.Ping
{
    public sealed class PingerResult : DisposableObject
    {
        public IPAddress Address { get; private set; }
        public int PingsTotal { get; private set; }
        public int PingsSuccessFull { get; private set; }
        public TimeSpan AverageTime { get; private set; }
        public TimeSpan LastTime { get; private set; }
        public IPStatus LastStatus { get; private set; }

        public PingerResult(IPAddress address)
        {
            Address = address;

            LastStatus = IPStatus.Unknown;
        }

        internal void AddResult(PingReply res)
        {
            if (res == null)
            {
                LastStatus = IPStatus.Unknown;
                LastTime = TimeSpan.Zero;
            }
            else
            {

                PingsTotal++;
                LastStatus = res.Status;

                if (res.Status == IPStatus.Success)
                {
                    PingsSuccessFull++;
                    LastTime = TimeSpan.FromMilliseconds(res.RoundtripTime);
                    if (PingsSuccessFull == 1)
                        AverageTime = LastTime;
                    else
                    {
                        var oldAverage = AverageTime.TotalMilliseconds;
                        AverageTime =
                            TimeSpan.FromMilliseconds(oldAverage + (res.RoundtripTime - oldAverage) / PingsSuccessFull);
                    }
                }
                else
                {
                    LastTime = TimeSpan.Zero;
                }
            }

        }

        protected override void DisposeManagedResources()
        {

        }
    }
}