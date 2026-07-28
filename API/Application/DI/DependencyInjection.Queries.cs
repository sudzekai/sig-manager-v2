using Application.Queries.Cars;
using Application.QueryHandlers.Cars;
using Shared.Dtos.Cars;
using Application.Queries.Parks;
using Application.QueryHandlers.Parks;
using Shared.Dtos.Parks;
using Application.Queries.Positions;
using Application.QueryHandlers.Positions;
using Shared.Dtos.Positions;
using Application.Queries.Products;
using Application.QueryHandlers.Products;
using Shared.Dtos.Products;
using Application.Queries.Rights;
using Application.QueryHandlers.Rights;
using Shared.Dtos.Rights;
using Application.Queries.Roles;
using Application.QueryHandlers.Roles;
using Shared.Dtos.Roles;
using Application.Queries.Users;
using Application.QueryHandlers.Users;
using Shared.Dtos.Users;
using Application.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Types.Exceptions;
using Shared.Utilities.Extensions;

namespace Application.DI
{
    public static partial class DependencyInjection
    {
        private static readonly Dictionary<Type, Type> _queryHandlers = new()
        {
            [typeof(IQueryHandler<CarGetAllQuery, CarSimpleDto[]>)] = typeof(CarGetAllHandler),
            [typeof(IQueryHandler<CarGetByIdQuery, CarDto>)] = typeof(CarGetByIdHandler),

            [typeof(IQueryHandler<ParkGetAllQuery, ParkSimpleDto[]>)] = typeof(ParkGetAllHandler),
            [typeof(IQueryHandler<ParkGetByIdQuery, ParkDto>)] = typeof(ParkGetByIdHandler),

            [typeof(IQueryHandler<PositionGetAllQuery, PositionSimpleDto[]>)] = typeof(PositionGetAllHandler),
            [typeof(IQueryHandler<PositionGetByIdQuery, PositionDto>)] = typeof(PositionGetByIdHandler),

            [typeof(IQueryHandler<ProductGetAllQuery, ProductSimpleDto[]>)] = typeof(ProductGetAllHandler),
            [typeof(IQueryHandler<ProductGetByIdQuery, ProductDto>)] = typeof(ProductGetByIdHandler),

            [typeof(IQueryHandler<RightGetAllQuery, RightSimpleDto[]>)] = typeof(RightGetAllHandler),
            [typeof(IQueryHandler<RightGetByIdQuery, RightDto>)] = typeof(RightGetByIdHandler),

            [typeof(IQueryHandler<RoleGetAllQuery, RoleSimpleDto[]>)] = typeof(RoleGetAllHandler),
            [typeof(IQueryHandler<RoleGetByIdQuery, RoleDto>)] = typeof(RoleGetByIdHandler),

            [typeof(IQueryHandler<UserGetAllQuery, UserSimpleDto[]>)] = typeof(UserGetAllHandler),
            [typeof(IQueryHandler<UserGetByIdQuery, UserDto>)] = typeof(UserGetByIdHandler),
        };

        public static IServiceCollection AddQueryHandlers(this IServiceCollection services, ILogger logger)
        {
            foreach (var (service, implementation) in _queryHandlers)
            {
                try
                {
                    services.AddScopedСhecked(service, implementation);
                }
                catch (AppException ex)
                {
                    logger.LogWarning(ex.ToString());
                }
            }

            return services;
        }
    }
}
