using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authorization;
using SMDP;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SMDP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


    public class DataController : ControllerBase
    {
        SmdpContext db = new SmdpContext();
      
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/DailyPrice")]
        
        public dynamic DailyPrice(long a)
         {
            var dailypricelist = db.DailyPrices.Where(i =>
              i.InsCode== a).ToList();
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