using System;
using System.Collections.Generic;

namespace ProyectoFinalVoleibol.Models
{
    public partial class Integrantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public int IdDt { get; set; }
        public string NumCamiseta { get; set; }
        public string Posicion { get; set; }
        public string Estado { get; set; }
        public int Remate { get; set; }
        public int Saque { get; set; }
        public int Fuerza { get; set; }
        public int Recepcion { get; set; }
        public int Bloqueo { get; set; }
        public int Salto { get; set; }

        public virtual Directortecnico IdDtNavigation { get; set; }
    }
}
