using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.Common;

public class AnalogDigital
{
    public string AnalogDigitalSignal { get; private set; }

    public virtual ICollection<Tag> Tags { get; set; }

    //public AnalogDigital() { }

    public AnalogDigital(string analogDigitalSignal)
    {
        AnalogDigitalSignal = analogDigitalSignal;
    }
}