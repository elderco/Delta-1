﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class FotoVideo : IEntityBase
	{
		public int Id { get; set; }
		[Key, ForeignKey("Evento")]
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
		public string Observacoes { get; set; }
		public List<ItemFotoVideoSelecionado> Itens { get; set; }
		public List<Foto> Fotos { get; set; }
	}
}
