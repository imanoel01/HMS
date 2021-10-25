using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HMS.Data;
using HMS.Dtos;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _mapper;

        public RoomStatusController(IHMSRepo repo, IMapper mapper)
        {
            _repository =repo;
            _mapper=mapper;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            // var roomStatus= _repository.GetRoomStatus();
            // var ret=_mapper.Map<IEnumerable<RoomStatusReadDto>>(roomStatus);
            // return Ok();
            
             var roomStatus = _repository.GetRoomStatus();

            return Ok(roomStatus);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           var roomstatus= _repository.GetRoomStatus(id);
           if (roomstatus is null)
           return NotFound();
           var readRoomstatus =_mapper.Map<RoomStatusReadDto>(roomstatus);
           return Ok(readRoomstatus);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(RoomStatusCreateDto roomStatus)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var roomStatusModel= _mapper.Map<RoomStatus>(roomStatus);
            _repository.createRoomStatus(roomStatusModel);
            _repository.saveChanges();
            var readRoomStatus=_mapper.Map<RoomStatusReadDto>(roomStatusModel);

            return Ok(readRoomStatus);
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
            var metaData = Util.GetRoomStatusMetaData();
            return Ok(metaData);
        }
    }
}