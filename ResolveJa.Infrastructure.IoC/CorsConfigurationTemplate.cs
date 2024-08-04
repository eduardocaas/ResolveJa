using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Infrastructure.IoC
{
    public static class CorsConfigurationTemplate
    {
        public static Action<CorsOptions> ConfigureLocal(string policy)
        {
            return options => options.AddPolicy(name: policy,
                policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://LOCALHOST")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        }


    }
}
