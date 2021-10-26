using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("[controller]")]
    public class Debug : Controller
    {
        [HttpGet("ping")]
        public IActionResult Index()
        {
            return Ok("Pong");
        }

        [HttpGet("database")]
        public IActionResult Database()
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=lefttuesday;uid=root;pwd=20277evs;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                cnn.Close();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("conneciton good");
        }
    }
}
