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
    public class MontagemController : Controller
    {
        // GET: /Montagem/
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            model.Montagem montagem = new data.Montagem().GetElement(id);
            return View(montagem);
        }

        // GET: /Montagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.Montagem montagem = new data.Montagem().GetElement(id.Value);
            if (montagem == null)
            {
                return HttpNotFound();                
            }
            ViewBag.EventoId = id;
            return View(montagem);
        }

        // POST: /Montagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoId, Observacoes")] model.Montagem montagem)
        {
            if (ModelState.IsValid)
            {
                new data.Montagem().Update(montagem);
                return RedirectToAction("Index");
            }
            ViewBag.Id = montagem.Id;
            return View(montagem);
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
