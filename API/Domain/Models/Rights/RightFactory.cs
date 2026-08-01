using Domain.Models.Rights.Codes;
using Domain.ValueObjects.Rights;
using Shared.Internal;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;

namespace Domain.Models.Rights
{
    public class RightFactory
    {
        private static HashSet<(long code, string key)> _codes = [];

        private RightFactory(int entity, string entityName)
        {
            Entity = entity;
            EntityName = entityName;
        }

        public int Entity { get; private set; }

        public string EntityName { get; private set; }

        public int Property { get; private set; }

        public string? PropertyName { get; private set; }

        public PermissionScope Scope { get; private set; } = PermissionScope.None;

        public PermissionAction Action { get; private set; } = PermissionAction.None;

        public PermissionLevel Level { get; private set; } = PermissionLevel.Default;

        public string? Code;

        public static RightFactory Create(int entity, string entityName)
            => new(entity, entityName);

        public RightFactory WithProperty(int property, string propertyName)
        {
            Property = property;
            PropertyName = propertyName;

            return this;
        }

        public RightFactory ScopeAll()
        {
            Scope = PermissionScope.All;
            return this;
        }

        public RightFactory ScopeOwn()
        {
            Scope = PermissionScope.Own;
            return this;
        }

        public RightFactory AllowsGet()
        {
            Action = PermissionAction.Get;
            return this;
        }

        public RightFactory AllowsCreate()
        {
            Action = PermissionAction.Create;
            return this;
        }

        public RightFactory AllowsUpdate()
        {
            Action = PermissionAction.Update;
            return this;
        }

        public RightFactory AllowsDelete()
        {
            Action = PermissionAction.Delete;
            return this;
        }

        public RightFactory LevelAdmin()
        {
            Level = PermissionLevel.Admin;
            return this;
        }

        public static implicit operator Right(RightFactory factory)
        {
            var parts = new List<string>
            {
                factory.EntityName.ToUpper()
            };

            if (factory.PropertyName is not null)
                parts.Add(factory.PropertyName.ToUpper());

            if (factory.Level != PermissionLevel.Default)
                parts.Add(factory.Level.ToString().ToUpper());

            if (factory.Scope != PermissionScope.None)
                parts.Add(factory.Scope.ToString().ToUpper());

            if (factory.Action != PermissionAction.None)
                parts.Add(factory.Action.ToString().ToUpper());

            var code = string.Join(".", parts);

            var right = Right.Restore(
                RightId.FromValue($"{factory.Entity}{factory.Property}{(int)factory.Level}{(int)factory.Scope}{(int)factory.Action}".ToInt()),
                ValueObjects.Rights.Code.FromValue(code)
            );

            if (!_codes.Add(right.Id.Value))
                throw new AppException(InternalErrors.RightCodeAlreadyExists, $"Right code {right.Code.Value} already exists");

            if (!_keys.Add(right.Code.Value))
                throw new AppException(InternalErrors.RightCodeAlreadyExists, $"Right key {right.Code.Value} already exists");

            return right;
        }

        public void PrintAllRights(TextWriter writer)
        {
            long[] codes = [.. _codes];
            string[] keys = [.. _keys];
            
            writer.WriteLine($"CODE;KEY;");
            
            for (int i = 0; i < codes.Length; i++)
                writer.WriteLine($"{codes[i]};{keys[i]}");
        }
    }
}
