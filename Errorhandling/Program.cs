using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ErrorHandling.Exceptions;
using ErrorHandling.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErrorHandling
{
    public class Program
    {
        //this demonstrates how to include an error handling middleware with problemdetails
        //This is usually used in an ASP NET CORE Context
        public async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ErrorHandlingMiddleware>();
            serviceCollection.AddSingleton<DefaultExceptionHandler>();
            serviceCollection.AddSingleton<ProblemDetailsExceptionHandler>();
        }
    }
}