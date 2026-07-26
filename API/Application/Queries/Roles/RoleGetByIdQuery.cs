using Shared.Dtos.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Roles
{
    public record RoleGetByIdQuery(long Id) : IQuery;
}
