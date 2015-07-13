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

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class SomIluminacaoController : Controller
    {
        // GET: /SomIluminacao/
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            model.SomIluminacao somiluminacao = new data.SomIluminacao().GetElement(id);
            return View(somiluminacao);
        }

        // GET: /SomIluminacao/Details/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.SomIluminacao somiluminacao = new data.SomIluminacao().GetElement(id.Value);
            if (somiluminacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = id;
            return View(somiluminacao);
        }

        // POST: /Bebida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited([Bind(Include = "EventoId,Id,Observacoes")] model.SomIluminacao somiluminacao)
        {
            new data.SomIluminacao().Update(somiluminacao);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}