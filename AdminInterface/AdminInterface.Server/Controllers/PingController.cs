using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AdminInterface.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PingController : ControllerBase
	{
		[HttpGet]
		public IActionResult Ping(string ip)
		{
			if (string.IsNullOrEmpty(ip))
			{
				return BadRequest("Adresse IP manquante.");
			}

			try
			{
				var pingResult = RunPing(ip);
				return Ok(new { result = pingResult });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Erreur lors de l'exécution du ping.", error = ex.Message });
			}
		}

		private string RunPing(string ipAddress)
		{
			var ping = new ProcessStartInfo
			{
				FileName = "ping",
				Arguments = ipAddress,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			var process = new Process { StartInfo = ping };
			process.Start();

			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();

			return output;
		}
	}
}