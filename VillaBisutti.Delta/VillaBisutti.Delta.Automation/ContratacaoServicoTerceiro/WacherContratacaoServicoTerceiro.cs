﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.ContratacaoServicoTerceiro
{
    public class WacherContratacaoServicoTerceiro
    {
        private const string EmailContratacaoTerceiro = "EmailContratacaoServicoTerceiro.txt";
		private const string CabecalhoContratacaoTerceiro = "CabecalhoContratacaoTerceiro.txt";
        public void EmailContratacaoServicoTerceiro()
        {
            string message = Util.ReadFileEmail(EmailContratacaoTerceiro);
			string cabecalho = Util.ReadFileEmail(CabecalhoContratacaoTerceiro);
			StringBuilder builder = new StringBuilder();

			List<model.ItemDecoracaoCerimonialSelecionado> itemDecoracaoCerimonial = ItemEvento.GetItemDecoracaoCerimonial();
			List<model.ItemMontagemSelecionado> itemMontagem = ItemEvento.GetItemMontagem();
			List<model.ItemBebidaSelecionado> itemBebida = ItemEvento.GetItemBebida();
			List<model.ItemBoloDoceBemCasadoSelecionado> itemBoloDoceBemCasado = ItemEvento.GetItemBoloDoceBemCasado();
			List<model.ItemFotoVideoSelecionado> itemFotoVideo = ItemEvento.GetItemFotoVideo();
			List<model.ItemSomIluminacaoSelecionado> itemSomIluminacao = ItemEvento.GetItemSomIluminacao();
            List<model.ItemDecoracaoSelecionado> itemDecoracao = ItemEvento.GetItemDecorao();
            List<model.ItemOutrosItensSelecionado> itemOutrosItens = ItemEvento.GetItemOutrosItens();

			int currentId = 0;
            foreach (model.ItemDecoracaoCerimonialSelecionado item in itemDecoracaoCerimonial)
            {
				if (item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId != currentId)
				{
					currentId = item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonialId;
					builder.AppendLine(item.ItemDecoracaoCerimonial.TipoItemDecoracaoCerimonial.Nome + ":");
				}
				builder.AppendLine(message
					.Replace("{TIPOEVENTO}", item.DecoracaoCerimonial.Evento.TipoEvento.ToString())
					.Replace("{DIA}", item.DecoracaoCerimonial.Evento.Data.ToString("dd/MM"))
					.Replace("{HORA}", item.DecoracaoCerimonial.Evento.Inicio.ToString())
					.Replace("{ITEMNOME}", item.ItemDecoracaoCerimonial.Nome)
					.Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
			currentId = 0;
            foreach (model.ItemMontagemSelecionado item in itemMontagem)
            {
				builder.AppendLine(message
                .Replace("{TIPOEVENTO}", item.Montagem.Evento.TipoEvento.ToString())
					.Replace("{DIA}", item.Montagem.Evento.Data.ToString("dd/MM"))
					.Replace("{HORA}", item.Montagem.Evento.Inicio.ToString())
					.Replace("{TIPOITEMNOME}", item.ItemMontagem.TipoItemMontagem.Nome)
					.Replace("{ITEMNOME}", item.ItemMontagem.Nome)
					.Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
            foreach (model.ItemBebidaSelecionado item in itemBebida)
            {
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.Bebida.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.Bebida.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.Bebida.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemBebida.TipoItemBebida.Nome)
					 .Replace("{ITEMNOME}", item.ItemBebida.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
            foreach (model.ItemBoloDoceBemCasadoSelecionado item in itemBoloDoceBemCasado)
            {
				if (item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId != currentId)
				{
					currentId = item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasadoId;
					builder.AppendLine(item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Nome + ":");
				}
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.BoloDoceBemCasado.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.BoloDoceBemCasado.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.BoloDoceBemCasado.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemBoloDoceBemCasado.TipoItemBoloDoceBemCasado.Nome)
					 .Replace("{ITEMNOME}", item.ItemBoloDoceBemCasado.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
			currentId = 0;

            foreach (model.ItemFotoVideoSelecionado item in itemFotoVideo)
            {
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.FotoVideo.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.FotoVideo.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.FotoVideo.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemFotoVideo.TipoItemFotoVideo.Nome)
					 .Replace("{ITEMNOME}", item.ItemFotoVideo.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
            foreach (model.ItemSomIluminacaoSelecionado item in itemSomIluminacao)
            {
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.SomIluminacao.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.SomIluminacao.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.SomIluminacao.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemSomIluminacao.TipoItemSomIluminacao.Nome)
					 .Replace("{ITEMNOME}", item.ItemSomIluminacao.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
            foreach (model.ItemDecoracaoSelecionado item in itemDecoracao)
            {
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.Decoracao.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.Decoracao.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.Decoracao.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemDecoracao.TipoItemDecoracao.Nome)
					 .Replace("{ITEMNOME}", item.ItemDecoracao.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
            foreach (model.ItemOutrosItensSelecionado item in itemOutrosItens)
            {
				builder.AppendLine(message
				 .Replace("{TIPOEVENTO}", item.OutrosItens.Evento.TipoEvento.ToString())
					 .Replace("{DIA}", item.OutrosItens.Evento.Data.ToString("dd/MM"))
					 .Replace("{HORA}", item.OutrosItens.Evento.Inicio.ToString())
					 .Replace("{TIPOITEMNOME}", item.ItemOutrosItens.TipoItemOutrosItens.Nome)
					 .Replace("{ITEMNOME}", item.ItemOutrosItens.Nome)
					 .Replace("{ITEMSELECIONADOQTDE}", item.Quantidade.ToString()));
            }
			message = builder.ToString();
			string mensagemInteira = cabecalho.Replace("{RESPONSAVELBISUTTI}", Settings.NomeResponsavel) + message;
			Core.Email mail = new Core.Email()
			{
				CCO = new List<string> {"talesdealmeida@gmail.com", "rafael.ravena@gmail.com" },
				Assunto = "F0DA-SE TO MANDANDO UM MONTE DE EMAIL MESMO",
				CorpoEmail = mensagemInteira,
				NomedoRemetente = "Villa Biscate"
			};
			mail.SendMail();
        }	
    }
}
