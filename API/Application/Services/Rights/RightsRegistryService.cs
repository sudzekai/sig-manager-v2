using Domain.Models.Rights;
using Domain.ValueObjects.Rights;
using Infrastructure.Queries.Rights;
using Infrastructure.Repositories.Rights;
using Microsoft.Extensions.Logging;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;

namespace Application.Services.Rights
{
    internal class RightsRegistryService(IRightRepository repo, IRightsQuery rights, ILogger logger)
    {
        public async Task RegisterRightsAsync(HashSet<(long id, string code)> rightsToRegister)
        {
            var existingRights = await rights.GetAllAsync(new() { Limit = int.MaxValue });

            var toWrite = rightsToRegister.ToDictionary(x => x.id);
            var toRewrite = new List<(long id, string code)>();

            foreach (var existingRight in existingRights)
            {
                if (!toWrite.TryGetValue(existingRight.Id, out var right))
                    continue;

                if (right.code != existingRight.Code)
                {
                    logger.LogWarning(
                       new AppException(
                           InternalErrors.RightCodeExistingConflict,
                           $"Conflict occurred: existing right with id {existingRight.Id} has different code. Rewriting ({existingRight.Code} -> {right.code})...")
                       .ToString());

                    toRewrite.Add(right);
                    toWrite.Remove(existingRight.Id);

                    continue;
                }

                toWrite.Remove(existingRight.Id);
            }

            foreach (var right in toRewrite)
            {
                await repo.DeleteAsync(RightId.FromValue(right.id));

                await repo.AddAsync(Right.Create(
                    RightId.FromValue(right.id),
                    Code.FromValue(right.code)));
            }

            foreach (var right in toWrite.Values)
            {
                await repo.AddAsync(Right.Create(
                    RightId.FromValue(right.id),
                    Code.FromValue(right.code)));
            }
        }
    }
}
