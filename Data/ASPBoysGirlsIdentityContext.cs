using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPBoysGirlsIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ASPBoysGirlsIdentity.Areas.Identity.Data;

namespace ASPBoysGirlsIdentity.Data
{
    public class ASPBoysGirlsIdentityContext : DbContext
    {
        public ASPBoysGirlsIdentityContext (DbContextOptions<ASPBoysGirlsIdentityContext> options)
            : base(options)
        {
        }

        public DbSet<ASPBoysGirlsIdentity.Models.StudentTask> StudentTasks { get; set; }

        public DbSet<ASPBoysGirlsIdentity.Models.TeacherTask> TeacherTasks { get; set; }
    }
}
