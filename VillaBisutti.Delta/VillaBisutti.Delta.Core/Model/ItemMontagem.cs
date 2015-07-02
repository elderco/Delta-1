﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemMontagem : IEntityBase
	{
		public int Id { get; set; }
		[Display(Name = "Nome"), Required]
		public string Nome { get; set; }
		[Display(Name = "Quantidade"), Range(0, 161)]
		public int Quantidade { get; set; }
		public int TipoItemMontagemId { get; set; }
		[Display(Name = "Montagem"), Range(0, 161)]
		public TipoItemMontagem TipoItemMontagem { get; set; }
	}
}
