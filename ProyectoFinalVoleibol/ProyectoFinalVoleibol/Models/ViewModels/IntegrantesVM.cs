using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalVoleibol.Models.ViewModels
{
    public class IntegrantesVM
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

        public Integrantes Integrantes { get; set; }
       
        public IFormFile Archivo { get; set; }

        public string Imagen { get; set; }

        public Directortecnico Directortecnico { get; set; }
        public IEnumerable<Directortecnico> directortecnicos { get; set; }
    }
}
