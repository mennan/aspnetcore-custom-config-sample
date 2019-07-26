using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCustomConfigSample.Models;
using aspnetcore_custom_config_sample.Model;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreCustomConfigSample.Controllers
{
	public class HomeController : Controller
	{
		private readonly IConfiguration _appSettings;

		public HomeController(IConfiguration config)
		{
			_appSettings = config;
		}

		public IActionResult Index()
		{
			ViewBag.AppName = _appSettings.GetSection("AppName").Value;
			ViewBag.AppVersion = _appSettings.GetSection("AppVersion").Value;

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
