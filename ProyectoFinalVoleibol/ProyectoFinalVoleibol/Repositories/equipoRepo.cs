using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalVoleibol.Models;

namespace ProyectoFinalVoleibol.Repositories
{
	public class EquiposRepository : Repository<Directortecnico>
	{
		public EquiposRepository(bdvoleibolContext context) : base(context)
		{

		}

		//public override IEnumerable<Directortecnico> GetAll()
		//{
		//	return Context.Directortecnico.OrderBy(x => x.Equipo);
		//}

	}
}
