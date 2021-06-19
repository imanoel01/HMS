using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IHMSRepo _repo;

        public BillController(IHMSRepo iHMSRepo )
        {
            _repo =iHMSRepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
          return Ok(_repo.GetBills());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

         [HttpGet("getmetadata")]
        public IActionResult GetMetadata()
        {
            var metaData = Util.GetRoomMetaData();
            return Ok(metaData);
        }
    }
}