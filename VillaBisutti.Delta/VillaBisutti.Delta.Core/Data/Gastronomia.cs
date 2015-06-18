﻿using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Gastronomia : DataAccessBase<Model.Gastronomia>
	{
		public override void Update(Model.Gastronomia entity)
		{
			Model.Gastronomia original = context.Gastronomia.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Gastronomia entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Gastronomia entity)
		{
			context.Gastronomia.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Gastronomia> GetCollection()
		{
			return context.Gastronomia.ToList();
		}
	}
}
