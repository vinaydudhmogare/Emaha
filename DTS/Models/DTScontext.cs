using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class DTScontext : IdentityDbContext<IdentityUser>
    {

        public DTScontext():base("name=DTSContext")
        {
                
        }
        
    }
}