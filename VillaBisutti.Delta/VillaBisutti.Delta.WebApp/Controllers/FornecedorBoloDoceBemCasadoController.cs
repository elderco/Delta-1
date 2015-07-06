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
    public class FornecedorBoloDoceBemCasadoController : Controller
    {
        // GET: /FornecedorBoloDoceBemCasado/
        public ActionResult Index()
        {
			return View(new data.FornecedorBoloDoceBemCasado().GetCollection(0));
        }

        // GET: /FornecedorBoloDoceBemCasado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = new data.FornecedorBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FornecedorBoloDoceBemCasado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,NomeFornecedor")] model.FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
				new data.FornecedorBoloDoceBemCasado().Insert(fornecedorbolodocebemcasado);
				return Redirect(Request.UrlReferrer.AbsolutePath);
            }

            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = new data.FornecedorBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
			return View(fornecedorbolodocebemcasado);
        }

        // POST: /FornecedorBoloDoceBemCasado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NomeFornecedor")] model.FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado)
        {
            if (ModelState.IsValid)
            {
				new data.FornecedorBoloDoceBemCasado().Update(fornecedorbolodocebemcasado);
				return Redirect(Request.UrlReferrer.AbsolutePath);
				//return RedirectToAction("Index", "ItemBoloDoceBemCasado");
            }
            return View(fornecedorbolodocebemcasado);
        }

        // GET: /FornecedorBoloDoceBemCasado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.FornecedorBoloDoceBemCasado fornecedorbolodocebemcasado = new data.FornecedorBoloDoceBemCasado().GetElement(id.HasValue ? id.Value : 0);
            if (fornecedorbolodocebemcasado == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorbolodocebemcasado);
        }

        // POST: /FornecedorBoloDoceBemCasado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.FornecedorBoloDoceBemCasado().Delete(id);
			return RedirectToAction("Index", "ItemBoloDoceBemCasado");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
