using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDB.SMDPModels;


namespace SMDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        SmdpContext db = new SmdpContext();
      
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/DailyPrice")]
        public dynamic DailyPrice()
         {
            var dailypricelist = db.DailyPrices.Select(i =>
            new { i }).ToList();
            return dailypricelist;          
          }        
    }
}