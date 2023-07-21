using ElectronNET.API;
using Microsoft.EntityFrameworkCore;
using testebanco.Data;
using Microsoft.AspNetCore.Builder;


namespace voltandoclassestartup
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
            services.AddControllersWithViews();
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                 ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            if (HybridSupport.IsElectronActive)
            {
                CreateElectronWindow();
            }
        }

        private async void CreateElectronWindow()
        {
            var window = await Electron.WindowManager.CreateWindowAsync();
            window.OnClosed += Window_OnClosed;
            window.OnMaximize += Window_OnMaximize;
        }

        private void Window_OnClosed()
        {
            Electron.App.Exit();
        }

        private void Window_OnMaximize()
        {
            Electron.Dialog.ShowErrorBox("Demo Maximized event", "Hi, You just maximized your Electron App's Window");
        }
    }
}