using Domain.Models.Base;
using Domain.ValueObjects.Roles;

namespace Domain.Models.Roles
{
    public partial class Role : DomainModelBase
    {
        private Role(RoleId id, Name name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;

            _initialized = true;
        }

        private Role(Name name)
        {
            Name = name;

            _initialized = true;
        }

        internal static Role Restore(RoleId id, Name name, DateTime createdAt)
            => new(id, name, createdAt);

        public static Role Create(Name name)
            => new(name);
    }
}
