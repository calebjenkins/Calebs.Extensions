using System;
using System.ComponentModel.DataAnnotations;

namespace Calebs.Extensions.Validators
{

#if NET7_0_OR_GREATER

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class EnumStringValidatorAttribute<T> : ValidationAttribute where T : struct
    {
        private Type enumType;
        private bool ignoreCase;

        public EnumStringValidatorAttribute(bool IgnoreCase = true)
        {
            enumType = typeof(T).IsEnum ? typeof(T) : throw new ArgumentException("Generic T must be an enum type");
            ignoreCase = IgnoreCase;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = value as string;
            if (fieldValue.IsNullOrEmpty())
                return null;

            var fieldName = validationContext.MemberName;
            var valueList = enumType.ToList();

            if (ignoreCase)
            {
                fieldValue = fieldValue.ToUpper();
                valueList.ToUpper();
            }

            var errMessage = valueList.Contains(fieldValue) ? string.Empty : $"{fieldName} was {fieldValue}, but must be set to one of these values: {valueList.ToDelimitedList(", ")}";
            return errMessage.IsNotNullOrEmpty() ? new ValidationResult(errMessage) : null;
        }
    }
#endif

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class EnumStringValidatorAttribute : ValidationAttribute
    {
        private Type enumType;
        private bool ignoreCase;

        public EnumStringValidatorAttribute(Type EnumType, bool IgnoreCase = true)
        {
            enumType = EnumType.IsEnum ? EnumType : throw new ArgumentException(nameof(EnumType) + " must be an enum type");
            ignoreCase = IgnoreCase;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = value as string;
            if (fieldValue.IsNullOrEmpty())
                return null;

            var fieldName = validationContext.MemberName;
            var valueList = enumType.ToList();

            if (ignoreCase)
            {
                fieldValue = fieldValue.ToUpper();
                valueList.ToUpper();
            }

            var errMessage = valueList.Contains(fieldValue) ? string.Empty : $"{fieldName} was {fieldValue}, but must be set to one of these values: {valueList.ToDelimitedList(", ")}";
            return errMessage.IsNotNullOrEmpty() ? new ValidationResult(errMessage) : null;
        }
    }
}
