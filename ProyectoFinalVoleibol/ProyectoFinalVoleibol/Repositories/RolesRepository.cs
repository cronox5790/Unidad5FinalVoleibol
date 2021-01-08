using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinalVoleibol.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalVoleibol.Repositories
{
    public class RolesRepository<T> where T : class
    {
        public bdvoleibolContext Context { get; set; }
        public RolesRepository(bdvoleibolContext context)
        {
            Context = context;
        }
        public virtual IEnumerable<T> ObtenerTodo()
        {
            return Context.Set<T>();
        }
        public T ObtenerPorId(object id)
        {
            return Context.Find<T>(id);
        }
        public virtual T GetById(int id)
        {
            return Context.Find<T>(id);
        }
        public virtual void Insertar(T entidad)
        {
            if (Validaciones(entidad))
            {
                Context.Add(entidad);
                Context.SaveChanges();
            }
        }
        public virtual void EditarI(T entidad)
        {
            if (Validaciones(entidad))
            {
                Context.Update<T>(entidad);
                Context.SaveChanges();
            }
        }
        public virtual void Eliminar(T entidad)
        {
            Context.Remove<T>(entidad);
            Context.SaveChanges();
        }

        public virtual bool Validaciones(T entidad)
        {
            return true;
        }
    }

    public class DirectorTecnicoRepository : RolesRepository<Directortecnico>
    {
        
        public DirectorTecnicoRepository(bdvoleibolContext context) : base(context) { }

      
        public Directortecnico ObtenerIntegrantesPorDt(int IdDt)
        {
            return Context.Directortecnico.Include(x => x.Integrantes).FirstOrDefault(x => x.Id == IdDt);
        }

        public Directortecnico ObtenerDtPorClave(int Clave)
        {
            return Context.Directortecnico.FirstOrDefault(x => x.Clave == Clave);
        }
        public override bool Validaciones(Directortecnico Dt)
        {
            if (string.IsNullOrWhiteSpace(Dt.Nombre))
                throw new Exception("Ingrese el nombre.");

            if (string.IsNullOrWhiteSpace(Dt.Contrasena))
                throw new Exception("Ingrese la contraseña.");

            if (string.IsNullOrWhiteSpace(Dt.Equipo))
                throw new Exception("Ingrese el nombre del equipo.");

            if (Dt.Clave <= 0)
                throw new Exception("Ingrese la clave del director tecnico.");

            if (Dt.Clave.ToString().Length > 4)
                throw new Exception("La clave no debe exceder los 4 dígitos.");

            if (Dt.Clave.ToString().Length < 4)
                throw new Exception("La clave debe ser de 4 dígitos.");

            return true;
        }
    }
    public class IntegrantesRepository : RolesRepository<Integrantes>
    {
        public IntegrantesRepository(bdvoleibolContext context) : base(context) { }

        public Integrantes ObtenerIntegrantesPorNombres(string nombre, string id)
        {
            return Context.Integrantes.FirstOrDefault(x => x.Nombre.ToLower() == nombre.ToString());
        }
        public Integrantes ObtenerIntegrantesPorNombre(string nombre)
        {
            return Context.Integrantes.FirstOrDefault(x => x.Nombre.ToLower() == nombre.ToString());
        }
        public Integrantes GetIntegrantesPorNombre(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            return Context.Integrantes
                .Include(x => x.IdDtNavigation)
                .FirstOrDefault(x => x.Nombre == nombre);
        }
        public IEnumerable<Integrantes> ObtenerIntegrantesxDt(string nombre)
        {
            return Context.Integrantes.Where(x => x.IdDtNavigation.Equipo==nombre);
        }

        public override bool Validaciones(Integrantes integrante)
        {
            if (string.IsNullOrEmpty(integrante.Nombre))
                throw new Exception("Ingrese el nombre del integrante.");

            if (string.IsNullOrEmpty(integrante.Genero))
                throw new Exception("Ingrese el genero del integrante.");

            if (integrante.Edad <= 0)
                throw new Exception("Ingrese la edad del integrante.");

            if (integrante.ToString() == null || integrante.IdDt <= 0)
                throw new Exception("Debe asignar un Director tecnico.");

            if (string.IsNullOrEmpty(integrante.NumCamiseta))
                throw new Exception("Ingrese el número de camiseta del integrante.");

            if (string.IsNullOrEmpty(integrante.Posicion))
                throw new Exception("Ingrese la posicion del jugador.");

            if (string.IsNullOrEmpty(integrante.Estado))
                throw new Exception("El jugador es de la plantilla oficial o banca?.");


            if (integrante.Fuerza < 0 || integrante.Fuerza > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");
            if (integrante.Remate < 0 || integrante.Remate > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");
            if (integrante.Recepcion < 0 || integrante.Recepcion > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");
            if (integrante.Bloqueo < 0 || integrante.Bloqueo > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");
            if (integrante.Salto < 0 || integrante.Salto > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");
            if (integrante.Saque < 0 || integrante.Saque > 10)
                throw new Exception("Los valores de la estadistica deben de ser entre 0 y 10.");


            return true;
        }

    }
}