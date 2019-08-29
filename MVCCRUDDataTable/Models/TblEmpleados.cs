using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUDDataTable.Models
{
    public class TblEmpleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage ="Campo Requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Range(1, 100, ErrorMessage = "La edad debe estar entre 1 y 100 años")]
        public int Edad { get; set; }       
        [Required(ErrorMessage = "Campo Requerido")]
        public string Oficio { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        //[DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public decimal Salario { get; set; }        
    }
}