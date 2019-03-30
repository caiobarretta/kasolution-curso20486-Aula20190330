using FN.Store.UI.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FN.Store.UI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultSignInScheme =
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Auth/Signin";
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Use(async (ctx, next) => 
            {
                await next.Invoke();
                if (ctx.Response.StatusCode == 404)
                    await ctx.Response.WriteAsync("404");
            });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
