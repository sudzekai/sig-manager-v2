using Domain.Models.Base;
using Domain.ValueObjects.Rights;

namespace Domain.Models.Rights
{
    public partial class Right : DomainModelBase
    {
        private Right(RightId id, Code code)
        {
            Id = id;
            Code = code;

            _initialized = true;
        }

        internal static Right Restore(RightId id, Code code)
            => new(id, code);

        public static Right Create(RightId id, Code code)
            => new(id, code);
    }
}
