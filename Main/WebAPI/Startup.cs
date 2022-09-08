using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Swagger.Examples;
using WebAPI.Swagger.Examples.ActorDTO;
using WebAPI.Swagger.Examples.CommentDTO;
using WebAPI.Swagger.Examples.Error;
using WebAPI.Swagger.Examples.FullMovieDTO;
using WebAPI.Swagger.Examples.LightActorDTO;
using WebAPI.Swagger.Examples.MovieDTO;
using WebAPI.Swagger.Examples.MovieTypeDTO;
using WebAPI.Swagger.Examples.Operation;
using WebAPI.Swagger.Filters;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleNotFound>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleBadRequest>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleConflict>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleOperation>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseSingleCommentDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationCommentDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleCommentDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationLightActorDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationActorDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseSingleActorDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultipleMovieTypeDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseSingleFullMovieDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationMovieDTO>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindMovieTitle>();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindActorName>();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebAPI",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Aristide LAMBERT & Sami EZZAYRI"
                    }
                });
                c.DocumentFilter<JsonPatchDocumentFilter>();
                c.ExampleFilters();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
