﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Bebida : IEntityBase
	{
		public int Id { get; set; }
		public List<ItemBebidaSelecionado> ItensBebida { get; set; }
	}
}
