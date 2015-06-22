﻿using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemGastronomia
{
	[Route("/tipo-item-gastronomia/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemGastronomia>
	{
		public int Id { get; set; }
	}
	[Route("/tipo-item-gastronomia", "GET")]
	public class GetAll : IReturn<List<model.TipoItemGastronomia>> { }
	[Route("/tipo-item-gastronomia", "POST")]
	public class New
	{
		public model.TipoItemGastronomia entity { get; set; }
	}
	[Route("/tipo-item-gastronomia", "PUT")]
	public class Update
	{
		public model.TipoItemGastronomia entity { get; set; }
	}
	[Route("/tipo-item-gastronomia/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
