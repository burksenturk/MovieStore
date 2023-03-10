using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using MovieStore.Business.Mapping;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete;
using MovieStore.DataAccess.Concrete.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MovieStore.Api
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
            services.AddDbContext<MovieStoreContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MovieStoreConnection"));
            }
            );
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieStore.Api", Version = "v1" });
            });

            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IActorRepository, ActorRepository>();
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
           

            services.AddAutoMapper(typeof(CustomAutoMapper));


            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();

            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<ITypeRepository, TypeRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IMovieDirectorRepository, MovieDirectorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStore.Api v1"));
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
