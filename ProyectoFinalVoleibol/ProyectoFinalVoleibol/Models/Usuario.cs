using System;
using System.Collections.Generic;

namespace ProyectoFinalVoleibol.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NomUser { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int Codigo { get; set; }
        public ulong Activo { get; set; }
    }
}
