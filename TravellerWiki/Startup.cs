using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravellerCharacter.Character_Services;
using TravellerCharacter.Character_Services.Career_Service;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerFactionSystem;
using TravellerGalaxyGenertor;
using VoicesFromTheVoidArticles;
using WikiServices.DataServices;
using WikiServices.InformationServices;
using CharacterCreatorService = TravellerCharacter.CharacterCreator.CharacterCreation.CharacterCreatorService;

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
            services.AddSingleton<TravellerVoicesFromTheVoidService>();
            services.AddSingleton<HighVersianService>();
            services.AddSingleton<TravellerItemStoreService>();
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
            services.AddSingleton<TravellerCharacterStorageService>();
            services.AddSingleton<TravellerCareerCreatorService>();
            services.AddSingleton<TravellerFactionService>();
            services.AddSingleton<WikiArticleService>();

            services.AddSingleton<TravellerComplexCharacterGeneratorService>();

            services.AddSingleton<TravellerMapService>();
            services.AddSingleton<TravellerSubsectorGeneratorService>();
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
                endpoints.MapControllerRoute(
                    name: "Subsector Image Request",
                    pattern: "{controller=SubsectorImageGenerator}/{action=GetImage}/{imageID?}");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}