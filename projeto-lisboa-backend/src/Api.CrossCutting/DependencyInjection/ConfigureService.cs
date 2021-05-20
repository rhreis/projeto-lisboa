using Api.Domain.Interfaces.Services.Items;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IItemService, ItemService>();
            serviceCollection.AddTransient<IItemPhotosService, ItemPhotoService>();
        }
    }
}