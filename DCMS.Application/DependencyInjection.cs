using DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DCMS.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace DCMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here

            services.AddTransient<IMediator, SimpleMediator>();

            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
            services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, GetDentalOfficeDetailQueryHandler>();

            return services;
        }
    }
}
