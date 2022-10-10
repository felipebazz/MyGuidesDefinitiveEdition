using FluentValidation;
using FluentValidation.Results;
using MyGuides.Domain.Abstractions.Validation;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Domain.Abstractions.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity<TId> : Entity where TId : struct
    {
        public TId Id { get; protected set; }

        protected Entity() { }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (!(obj is Entity<TId> entity)) return false;
            return Id.Equals(entity.Id);
        }

        public override int GetHashCode() => base.GetHashCode();
    }

    [ExcludeFromCodeCoverage]
    public abstract class Entity : ValidatableObject
    {
        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            ValidationResult = validator.Validate(entity);
            return Valid;
        }

        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator, Func<AbstractValidator<TEntity>, TEntity, ValidationResult> validation)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            ValidationResult = validation(validator, entity);
            return Valid;
        }
    }
}
