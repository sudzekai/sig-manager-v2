using Domain.ValueObjects.Base;
using Shared.Types.Errors;
using Shared.Types.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects.Users
{
    public record PasswordHash : ValueObjectBase
    {
        public readonly string Value;

        private PasswordHash(string value) 
            => Value = value;

        public static PasswordHash FromValue(string value)
            => new(value);

        public override bool IsValid
        { 
            get
            {
                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserErrors.PasswordIsRequired);

                return true;
            }
        }
    }
}
