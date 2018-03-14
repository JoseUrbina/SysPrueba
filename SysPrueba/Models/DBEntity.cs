using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SysPrueba.Models
{
    public class DBEntity : DbContext
    {
        public DBEntity() : base("defaultConection")
        {
        }

        public DbSet<Estudiante> Estudiante { get; set; }

        public DbSet<Telefono> Telefono { get; set; }
    }
}