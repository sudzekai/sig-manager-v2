using Domain.Models.Base;
using Domain.ValueObjects.Roles;

namespace Domain.Models.Roles
{
    public partial class Role : DomainModelBase
    {
        public Role(RoleId id, Name name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;

            _initialized = true;
        }

        public Role(Name name, DateTime createdAt)
        {
            Name = name;
            CreatedAt = createdAt;

            _initialized = true;
        }

        public static Role Restore(RoleId id, Name name, DateTime createdAt)
            => new(id, name, createdAt);

        public static Role Create(Name name, DateTime createdAt)
            => new(name, createdAt);
    }
}
