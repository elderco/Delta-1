﻿using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.FotoVideo
{
	[Route("/fotovideos/{Id}", "GET")]
	public class Get : IReturn<model.FotoVideo>
	{
		public int Id { get; set; }
	}
	[Route("/fotovideos", "GET")]
	public class GetAll : IReturn<List<model.FotoVideo>> { }
	[Route("/fotovideos", "POST")]
	public class New
	{
		public model.FotoVideo entity { get; set; }
	}
	[Route("/fotovideos", "PUT")]
	public class Update
	{
		public model.FotoVideo entity { get; set; }
	}
	[Route("/fotovideos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
