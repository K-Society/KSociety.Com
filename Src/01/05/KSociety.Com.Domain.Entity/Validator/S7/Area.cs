using FluentValidation;

namespace KSociety.Com.Domain.Entity.Validator.S7;

public class Area : AbstractValidator<Entity.S7.Area>
{
    public Area()
    {
        RuleFor(areaItem => areaItem.Id).NotNull().NotEmpty(); //.NotNull().NotEmpty().Length(1, 2);
        RuleFor(areaItem => areaItem.AreaName).NotNull().NotEmpty().Length(1, 8);
        RuleFor(areaItem => areaItem.Mean).NotNull().NotEmpty().Length(1, 50);
    }
}