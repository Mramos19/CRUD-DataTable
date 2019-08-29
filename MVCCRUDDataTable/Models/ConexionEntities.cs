using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCCRUDDataTable.Models
{
    public class ConexionEntities : DbContext
    {
        public ConexionEntities() : base("Conexion")
        {
        }

        public DbSet<TblEmpleados> TblEmpleado { get; set; }
    }
}