using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.Common;

public class AutomationType
{
    //public int AutomationTypeId { get; private set; }
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Mean { get; private set; }

    public virtual ICollection<Connection> Connections { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }

    //private AutomationType() { }

    //public AutomationType(int automationTypeId, string name, string mean)
    public AutomationType(int id, string name, string mean)
    {
        Id = id;
        Name = name;
        Mean = mean;

        //var areaValidator = new Std.Domain.Db.Entity.Validator.S7.Area();
        //areaValidator.ValidateAndThrow(this);
    }
}