using Domain.ValueObjects.Rights;

namespace Domain.Models.Rights
{
    public partial class Right
    {
        public RightId Id
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
        } = RightId.Default;

        public Code Code
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
        } = Code.Default;

        public void ChangeCode(string value)
            => Code = Code.FromValue(value);

        public void ChangeCode(Code value)
            => Code = value;
    }
}
