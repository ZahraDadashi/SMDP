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
        [HttpGet("/Fund")]
        public dynamic Fund()
        {
            var fundlist = db.Funds.Select(i =>
            new { i }).ToList();
            return fundlist;
        }
        [HttpGet("/Industry")]
        public dynamic Industry()
        {
            var industrylist = db.Industries.Select(i =>
            new { i }).ToList();
            return industrylist;
        }
        [HttpGet("/Instrument")]
        public dynamic Instrument()
        {
            var instrumentlist = db.Instruments.Select(i =>
            new { i }).ToList();
            return instrumentlist;
        }
        [HttpGet("/LetterType")]
        public dynamic LetterType()
        {
            var letterTypelist = db.LetterTypes.Select(i =>
            new { i }).ToList();
            return letterTypelist;
        }

    }
}