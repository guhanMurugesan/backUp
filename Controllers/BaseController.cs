using CleanIndia.Common;
using CleanIndia.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CleanIndia.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LiveMap()
        {
            LiveTrackHandler handler = new LiveTrackHandler();
            var detail = handler.getVoteDetail();
            return View(detail);
        }

        public ActionResult Logon()
        {
            return View();
        }

        public ActionResult ValidateUser(string userId, string password)
        {
            if (userId.Equals(AppConstant.CitizenUserId) && password.Equals(AppConstant.CitizenPassword))
                return Json(AppConstant.HostName+AppConstant.BaseController+ AppConstant.FileHash.ToString() +AppConstant.ViewUserMap);
            else if (userId.Equals(AppConstant.AdminUserID) && password.Equals(AppConstant.AdminPassword))
                return Json(AppConstant.HostName + AppConstant.BaseController + AppConstant.FileHash.ToString() + AppConstant.ViewLiveMap);
            else
                return Json(false);
        }

        public ActionResult ReportIndex(int? reportType)
        {

            return View(reportType);
        }

        public ActionResult PieChart()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "pie",
                  legend: "City Health Status",
                  xValue: new[] { "Low", "Medium", "High", "Concern free" },
                  yValues: new[] { "2", "28", "30", "40" })


              .Write();

            return null;
        }

        public ActionResult BarChart()
        {
            var key = new Chart(width: 600, height: 400)
                  .AddSeries(
                      chartType: "bar",
                      legend: "City Health Status",
                      xValue: new[] { "High", "Medium", "Low", "Concern free" },
                      yValues: new[] { "30", "28", "2", "40" })
                  .Write();

            return null;
        }

        public ActionResult AreawiseChart()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "bar",
                  legend: "City Health Status",
                  yValues: new[] { "22", "28", "30", "20" },
                  xValue: new[] { "Guindy", "Nandambakkam", "Manapakkam", "Porur" })


              .Write();

            return null;
        }

        public ActionResult CityWise()
        {
            var key = new Chart(width: 600, height: 400)
              .AddSeries(
                  chartType: "bar",
                  legend: "City Health Status",
                  xValue: new[] { "Chennai", "Bangalore", "Hyderabad", "Mumbai" },
                  yValues: new[] { "32", "28", "20", "20" })


              .Write();

            return null;
        }

    }
}