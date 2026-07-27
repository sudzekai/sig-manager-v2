using Domain.ValueObjects.Roles;

namespace Domain.Models.Roles
{
    public partial class Role
    {
        public RoleId Id
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = RoleId.Default;

        public Name Name
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = Name.Default;

        public void ChangeRoleName(string value)
            => Name = Name.FromValue(value);

        public void ChangeRoleName(Name value)
            => Name = value;

        public DateTime CreatedAt
        {
            get;
            private set
            {
                if (field == value)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = default;
    }
}
