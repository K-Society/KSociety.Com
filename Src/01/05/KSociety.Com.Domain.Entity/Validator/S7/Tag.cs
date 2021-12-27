using FluentValidation;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Entity.Validator.S7;

public class Tag : AbstractValidator<S7Tag>
{
    public Tag()
    {
        //RuleFor(tagItem => tagItem.DataBlock).NotNull();
        //RuleFor(tagItem => tagItem.Offset).NotNull();
        //RuleFor(tagItem => tagItem.BitOfByte).NotNull().InclusiveBetween(0, 7);
        //RuleFor(tagItem => tagItem.Name).NotNull().NotEmpty().Length(1, 50);
        //RuleFor(tagItem => tagItem.Enable).NotNull();
        //RuleFor(tagItem => tagItem.Address).NotNull().Length(1, 50);
        //RuleFor(tagItem => tagItem.WordLenId).NotNull().NotEmpty().Length(1, 12);
        //RuleFor(tagItem => tagItem.AreaId).NotNull().NotEmpty().Length(1, 8);
    }
}