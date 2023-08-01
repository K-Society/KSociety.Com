using System;

namespace KSociety.Com.Domain.Entity.S7
{
    public class BlockArea
    {
        public Guid Id { get; private set; }
        public int DataBlock { get; private set; }
        public int AreaId { get; private set; }
        public virtual Area Area { get; private set; }
        public int WordLenId { get; private set; }
        public virtual WordLen WordLen { get; private set; }
        public int Start { get; private set; }
        public int Amount { get; private set; }
        public bool Enable { get; private set; }
        public string Name { get; private set; }
        public Guid ConnectionId { get; private set; }
        public virtual S7Connection Connection { get; private set; }

        ////[StringLength(8)]
        ////[Required]
        //public string AreaId { get; private set; }
        //public Area Area { get; private set; }

        //[StringLength(12)]
        //[Required]
        //public string WordLenId { get; private set; }
        //public WordLen WordLen { get; private set; }

        //private BlockArea() { }

        public BlockArea(
            bool enable,
            int areaId,
            int dataBlock, int start, int amount,
            int wordLenId,
            string name,
            Guid connectionId
        )
        {
            Enable = enable;
            AreaId = areaId;
            DataBlock = dataBlock;
            Start = start;
            Amount = amount;
            WordLenId = wordLenId;
            Name = name;
            ConnectionId = connectionId;
        }
    }
}