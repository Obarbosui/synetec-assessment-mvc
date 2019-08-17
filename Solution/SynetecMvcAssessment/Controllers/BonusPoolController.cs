using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Helpers.Controllers;
using InterviewTestTemplatev2.Models;


namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolControllerHelper bonusPoolControllerHelper;

        public BonusPoolController(IBonusPoolControllerHelper bonusPoolControllerHelper)
        {
            this.bonusPoolControllerHelper = bonusPoolControllerHelper;
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            var model = bonusPoolControllerHelper.PrepareBonusPoolCalculatorModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            var result = bonusPoolControllerHelper.PrepareBonusPoolCalculatorResultModel(model.SelectedEmployeeId, model.BonusPoolAmount);

            return View(result);
        }
    }
}