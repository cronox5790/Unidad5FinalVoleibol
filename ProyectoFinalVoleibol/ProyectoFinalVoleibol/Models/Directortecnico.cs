using System;
using System.Collections.Generic;

namespace ProyectoFinalVoleibol.Models
{
    public partial class Directortecnico
    {
        public Directortecnico()
        {
            Integrantes = new HashSet<Integrantes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public ulong? Activo { get; set; }
        public int Clave { get; set; }
        public string Equipo { get; set; }
        public int InternacionalesGanados { get; set; }
        public int InternacionalesPerdidos { get; set; }
        public int NacionalesGanados { get; set; }
        public int NacionalesPerdidos { get; set; }
        public string Seleccion { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Integrantes> Integrantes { get; set; }
    }
}
