﻿using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using svc = VillaBisutti.Delta.ServiceModel;
using ServiceStack.Common.Web;
using System.Net;

namespace VillaBisutti.Delta.ServiceInterface
{
	public class OutroItem : Service
	{
		public model.OutroItem Get(svc.OutroItem.Get request)
		{
			return new data.OutroItem().GetElement(request.Id);
		}
		public List<model.OutroItem> Get(svc.OutroItem.GetAll request)
		{
			return new data.OutroItem().GetCollection(0);
		}
		public HttpResult Post(svc.OutroItem.New request)
		{
			new data.OutroItem().Insert(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Put(svc.OutroItem.Update request)
		{
			new data.OutroItem().Update(request.entity);
			return new HttpResult(request, HttpStatusCode.OK);
		}
		public HttpResult Delete(svc.OutroItem.Delete request)
		{
			new data.OutroItem().Delete(request.Id);
			return new HttpResult(request, HttpStatusCode.OK);
		}
	}
}