namespace apiCorreos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Servicios_Correo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public int Lanzamiento { get; set; }

        [Required]
        [StringLength(30)]
        public string Propietario { get; set; }

        [Required]
        [StringLength(30)]
        public string Desarrollador { get; set; }
    }
}
