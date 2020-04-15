using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using Microsoft.FeatureManagement.Mvc;

namespace core.mvc.featuremanagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFeatureManagement()
                .AddFeatureFilter<TimeWindowFilter>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Feature name as in app settings
            // app.UseForFeature("Alpha", a => a.Use(next => async ctx => await ctx.Response.WriteAsync("Running in alpha")));

            app.UseRouting();

            app.UseEndpoints(ep => ep.MapDefaultControllerRoute());
        }
    }

    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManagerSnapshot featureManager)
            => _featureManager = featureManager;

        [HttpGet]
        [FeatureGate("OpenHours")]
        public async Task<string> IndexAsync()
        {
            string response = "we are open";
            if (await _featureManager.IsEnabledAsync("Alpha"))
                response = $"WARN: Running in Alpha\n{response}";

            return response;
        }

    }
}
