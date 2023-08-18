using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.S7
{
    public class WordLen
    {
        public int Id { get; private set; }
        public string WordLenName { get; private set; }
        public string Mean { get; private set; }

        public virtual ICollection<S7Tag> S7Tags { get; set; }
        public virtual ICollection<BlockArea> S7BlockAreas { get; set; }

        public WordLen(int id, string wordLenName, string mean)
        {
            Id = id;
            WordLenName = wordLenName;
            Mean = mean;
        }
    }
}