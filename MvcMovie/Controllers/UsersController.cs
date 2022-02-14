using System.Data.SqlClient;
using System.Text.Encodings.Web;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(string name, int numTimes = 1)
        {
            SqlReader reader =
                new SqlReader(
                    @"Data Source=DESKTOP-LDL14VM\SQLEXPRESS;Initial Catalog=MYTESTSQL;Integrated Security=True");

            ViewData["Users"] = await reader.GetUsers();

            return View();
        }
    }
}
