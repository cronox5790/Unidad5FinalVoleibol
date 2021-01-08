using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalVoleibol.Models;
using ProyectoFinalVoleibol.Repositories;

namespace ProyectoFinalVoleibol.Services
{
	public class MenuServices
	{
		public IEnumerable<Directortecnico> DirTec { get; private set; }

		public MenuServices()
		{
			using (bdvoleibolContext ctx = new bdvoleibolContext())
			{
				DirectorTecnicoRepository repository = new DirectorTecnicoRepository(ctx);
				DirTec = repository.ObtenerTodo().OrderBy(x =>x.Equipo).ToList();
			}
		}

		

	}
}
