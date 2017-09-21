using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssignmentManager.DataAccess
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<Assignment> Assignements { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AssignmentManagerDbContext()
            : base("AssignmentManagerDb")
        {

        }
    }
}