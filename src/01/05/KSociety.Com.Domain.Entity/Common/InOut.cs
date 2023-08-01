using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.Common
{
    public class InOut
    {
        public string InputOutput { get; private set; }

        public string InputOutputName { get; private set; }

        public virtual ICollection<Tag> Tags { get; set; }

        //public InOut() { }

        public InOut(string inputOutput, string inputOutputName)
        {
            InputOutput = inputOutput;
            InputOutputName = inputOutputName;
        }
    }
}