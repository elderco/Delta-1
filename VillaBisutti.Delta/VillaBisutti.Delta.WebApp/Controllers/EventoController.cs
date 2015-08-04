﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using biz = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    [Authorize]
	public class EventoController : Controller
	{
		private void CriarControlesColecao()
		{
			ViewBag.TipoServico = new SelectList(new data.TipoServico().GetCollection(0), "key", "value");
			ViewBag.TipoEvento = new SelectList(Util.TiposEvento, "key", "value");
			ViewBag.LocalCerimonia = new SelectList(Util.LocalCerimonia, "key", "value");
			ViewBag.LocalId = new SelectList(new data.Local().GetCollection(0), "Id", "NomeCasa");
		}

		// GET: /Evento/ListaPorCasa/5
		public ActionResult ListaPorCasa(int id)
		{
			return View(new data.Evento().GetListaPorCasa(id));
		}
		// GET: /Evento/ListaProducao/5
		public ActionResult ListaProducao(int id)
		{
			return View(new data.Evento().GetListaPorCasaProducao(id, SessionFacade.UsuarioLogado.Id));
		}
		public ActionResult Cabecalho(int id)
		{
			ViewBag.Id = id;
			model.Evento evento = new data.Evento().GetElement(id);
			if (evento == null)
			{
				return HttpNotFound();
			}
			return View(evento);
		}
		// GET: /Evento/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ViewBag.Id = id;
			model.Evento evento = new data.Evento().GetElement(id.Value);
			if (evento == null)
			{
				return HttpNotFound();
			}
			return View(evento);
		}

		// GET: /Evento/Create
		public ActionResult Create()
		{
			ViewData["acesso"] = new biz.Usuario().UsuarioPodeAlterar(SessionFacade.UsuarioLogado, "/Evento/Create/");
			CriarControlesColecao();
			return View();
		}

		// POST: /Evento/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,TipoEvento,LocalId,Data,HorarioInicio,HorarioTermino,Pax,CardapioId,TipoServico,ProdutoraId,PosVendedoraId,NomeResponsavel,CPFResponsavel,EmailContato,TelefoneContato,NomeHomenageados,PerfilFesta,LocalCerimonia,EnderecoCerimonia,ObservacoesCerimonia,Observacoes,EmailBoasVindasEnviado,OSFinalizada")] model.Evento evento)
		{
			new biz.Evento().CriarEvento(evento);
			return RedirectToAction("Details", new { id = evento.Id });
		}

		// GET: /Evento/Edit/5
		public ActionResult Edit(int? id)
		{
			model.Evento evento = new data.Evento().GetElement(id.Value);
			if (evento == null)
			{
				return HttpNotFound();
			}
			return View(evento);
		}

		// POST: /Evento/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edited([Bind(Include = "Id,TipoEvento,LocalId,Data,HorarioInicio,HorarioTermino,Pax,PerfilFesta,CardapioId,TipoServico,ProdutoraId,PosVendedoraId,PossuiAssessoria,ContatoAssessoria,NomeResponsavel,CPFResponsavel,EmailContato,TelefoneContato,NomeHomenageados,Observacoes,LocalCerimonia,EnderecoCerimonia,ObservacoesCerimonia,EmailBoasVindasEnviado,OSFinalizada,OSAprovada")] model.Evento evento)
		{
			new data.Evento().Update(evento);
			return Redirect(Request.UrlReferrer.AbsoluteUri);
		}

		// GET: /Evento/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.Evento evento = new data.Evento().GetElement(id.Value);
			if (evento == null)
			{
				return HttpNotFound();
			}
			return View(evento);
		}

		// POST: /Evento/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.Evento().Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
