namespace MyGuides.Domain.Abstractions.Validation
{
    public interface IValidatableObject
    {
        bool Valid { get; }
        bool Validate();
    }
}
