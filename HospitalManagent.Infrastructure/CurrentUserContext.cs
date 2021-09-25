using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagent.Infrastructure
{
    public class CurrentUserContext
    {
        private readonly IHttpContextAccessor httpContext;

        public CurrentUserContext(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public string GetCurrentUserId()
        {
            var Id = "Sistem User";
            var asd = this.httpContext.HttpContext.User.Claims.ToString();
            var userId = this.httpContext.HttpContext.User.FindFirst("userId").Value;

            if (!string.IsNullOrEmpty(userId))
            {
                Id = userId;
            }

            return Id;
            
        }

    }
}
