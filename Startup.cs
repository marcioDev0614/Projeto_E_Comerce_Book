using LivroEC_V2.Areas.Admin.Servicos;
using LivroEC_V2.Data;
using LivroEC_V2.Models;
using LivroEC_V2.Repositorio;
using LivroEC_V2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Globalization;


namespace LivroEC_V2
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
            // Serviço que invoca a string de conexão para o banco de dados, via arquivo appsettings.json
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddControllersWithViews();

            // Serciço de paginação
            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName= "pageindex";
            });

            // Serviço que invoca a autenticação de usuário
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BancoContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Código para alterar a complexidade de senhas do identity
                // Default Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

            });

            // Habilitando o Memory Cache e Sessão - Middeware
            services.AddMemoryCache();
            services.AddSession();

            // Servições que declarão o acesso ao banco de dados via repositorio ou serviçõs.
            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddTransient<ILivroRepositorio, LivroRepositorio>();
            services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<ReletorioVendasServicos>();

            // Politica do perfil admin
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", 
                    politica =>
                {
                    politica.RequireRole("Admin");
                });
            });

            // Serviço para recuperar uma instância de HttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            var enUS = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            app.UseRequestLocalization(localizationOptions);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            // Cria os perfis
            seedUserRoleInitial.SeedRoles();

            // Cria os usuário e atribui oao perfil
            seedUserRoleInitial.SeedUsers();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
            );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
