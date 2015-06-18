﻿using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class Usuario : DataAccessBase<Model.Usuario>
	{
		public override void Update(Model.Usuario entity)
		{
			Model.Usuario original = context.Usuario.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.Usuario entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.Usuario entity)
		{
			context.Usuario.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.Usuario> GetCollection()
		{
			return context.Usuario.ToList();
		}
	}
}
