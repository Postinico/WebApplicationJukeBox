using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Repositories;
using WebApplicationJukebox.Repositories.doUsuario;
using WebApplicationJukebox.Repositories.nUsuario;

namespace WebApplicationJukeBox
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddResponseCompression();
            services.AddScoped<StoreDataContext, StoreDataContext>();

            services.AddScoped<GeneroRepository, GeneroRepository>();
            services.AddScoped<AlbumRepository, AlbumRepository>();

            services.AddScoped<PerfilRepository, PerfilRepository>();
            services.AddScoped<UsuarioRepository, UsuarioRepository>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Jukebox", Version = "v1" });
            });
        }


        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JukeBox - V1");
            });

            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
