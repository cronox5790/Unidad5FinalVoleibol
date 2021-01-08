using System;
using System.Collections.Generic;

namespace ProyectoFinalVoleibol.Models
{
    public partial class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int Clave { get; set; }
    }
}
