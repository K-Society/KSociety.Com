using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.S7;

public class CpuType //: ValueObject
{
    public int Id { get; private set; }

    public string CpuTypeName { get; private set; }

    public string Mean { get; private set; }

    public virtual ICollection<S7Connection> S7Connections { get; set; }

    //private CpuType() { }

    public CpuType(int id, string cpuTypeName, string mean)
    {
        Id = id;
        CpuTypeName = cpuTypeName;
        Mean = mean;

        //var areaValidator = new Std.Domain.Db.Entity.Validator.S7.Area();
        //areaValidator.ValidateAndThrow(this);
    }

    //protected override IEnumerable<object> GetAtomicValues()
    //{
    //    yield return CpuTypeId;
    //    yield return CpuTypeName;
    //    yield return Mean;
    //}
}