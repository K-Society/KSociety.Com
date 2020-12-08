using FluentValidation;

namespace KSociety.Com.Domain.Entity.Validator.Common
{
    public class Tag : AbstractValidator<Entity.Common.Tag>
    {
        public Tag()
        {
            RuleFor(tagItem => tagItem.Name).NotNull().Length(1, 50);
            RuleFor(tagItem => tagItem.ConnectionId).NotNull();
            RuleFor(tagItem => tagItem.Enable).NotNull();
            RuleFor(tagItem => tagItem.InputOutput).NotNull().Length(1, 2);
            RuleFor(tagItem => tagItem.AnalogDigitalSignal).NotNull().Length(1, 7);
            RuleFor(tagItem => tagItem.Invoke).NotNull();
            RuleFor(tagItem => tagItem.TagGroupId).NotNull();
        }
    }
}
