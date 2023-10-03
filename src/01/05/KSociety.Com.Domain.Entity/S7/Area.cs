using System.Collections.Generic;
using FluentValidation;

namespace KSociety.Com.Domain.Entity.S7
{
    public class Area
    {
        public int Id { get; private set; }
        public string AreaName { get; private set; }
        public string Mean { get; private set; }

        public virtual ICollection<S7Tag> S7Tags { get; set; }
        public virtual ICollection<BlockArea> S7BlockAreas { get; set; }

        public Area(int id, string areaName, string mean)
        {
            Id = id;
            AreaName = areaName;
            Mean = mean;

            var areaValidator = new Validator.S7.Area();
            areaValidator.ValidateAndThrow(this);
        }
    }
}