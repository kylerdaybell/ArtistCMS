using KylerAndBrandonCMS2.Data;
using KylerAndBrandonCMS2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        private readonly IConfiguration configuration;

        public CmsUrlConstraint(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(values[routeKey] != null)
            {
                var permalink = values[routeKey].ToString();
                var optionsBuilder = new DbContextOptionsBuilder<CmsContext>();
                optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                var cmsContext = new CmsContext(optionsBuilder.Options);
                var page = cmsContext.Pages.Include(p => p.ParagraphItems).FirstOrDefault(p => p.Name.ToLower() == permalink.ToLower());
                if(page != null)
                {
                    httpContext.Items["cmspage"] = page;
                    return true;
                }
            }
            return false;
        }
    }
}
