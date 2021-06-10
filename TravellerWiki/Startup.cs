using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoardCreator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravellerWiki.Data;
using TravellerWiki.Data.Services;
using TravellerWiki.Data.Services.CareerService;
using CharacterCreatorService = TravellerWiki.Data.CharacterCreation.CharacterCreatorService;

namespace TravellerWiki
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<TravellerNPCService>();
            services.AddSingleton<TravellerSpecialNPCService>();
            services.AddSingleton<TravellerNameService>();
            services.AddSingleton<TravellerNationsCharacterInfoService>();
            services.AddSingleton<TravellerJobBoardService>();
            services.AddSingleton<TravellerMissionGeneratorService>();
            services.AddSingleton<TravellerCareerService>();
            services.AddSingleton<TravellerSkillDisplayService>();
            services.AddSingleton<TravellerFreeFormMagicSystemsService>();
            services.AddSingleton<CharacterCreatorService>();
            services.AddSingleton<MultiPageCharacterCreationService>();
            services.AddSingleton<TravellerComplexCharacterGeneratorService>();

            services.AddSingleton<TravellerMapService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}