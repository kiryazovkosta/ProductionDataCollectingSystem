﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CollectingProductionDataSystem.Data.Contracts;
using CollectingProductionDataSystem.Models;
using CollectingProductionDataSystem.Models.Inventories;
using CollectingProductionDataSystem.Models.Nomenclatures;
using CollectingProductionDataSystem.Web.AppStart;
using CollectingProductionDataSystem.Web.ViewModels.Tank;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.Owin;

namespace CollectingProductionDataSystem.Web.Controllers
{
    public class TestsController : BaseController
    {
        public TestsController(IProductionData dataParam)
            : base(dataParam)
        { }

        public ActionResult Index()
        {
            return View(this.UserProfile);
        }

        [Authorize]
        public ActionResult Test()
        {
            // add product
            var pr1 = new Product() { Name = "Added Product", ProductTypeId = 1 };
            this.data.Products.Add(pr1);

            //modify product
            var pr = this.data.Products.GetById(5);
            pr.Name = "Modified Product Name";
            this.data.Products.Update(pr);

            //delete product
            this.data.Products.Delete(4);

            this.data.SaveChanges(this.UserProfile.User.UserName);
            return View((object)"Success");
        }

        [Authorize]
        [HttpGet]
        public ActionResult TankChange()
        {
            var record = this.data.TanksData.All().FirstOrDefault(r => r.Id == 1);
            return View(record);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TankChange(TankData model)
        {
            if (ModelState.IsValid)
            {
                //this.data.TanksData.Update(model);
                this.data.SaveChanges(this.UserProfile.User.UserName);
                return RedirectToAction("TankChange");
            }

            return View(model);

        }

        [HttpGet]
        public ActionResult TankData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ReadTank([DataSourceRequest]DataSourceRequest request)
        {
            var dbResult = this.data.TanksData.All().Include(x=>x.TankConfig).ToDataSourceResult(request, ModelState);
            dbResult.Data = Mapper.Map<IEnumerable<TankData>, IEnumerable<TankDataViewModel>>((IEnumerable<TankData>)dbResult.Data);
            return Json(dbResult);
        }
    }

}