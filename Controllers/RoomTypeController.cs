using System;
using AutoMapper;
using AutoWrapper.Wrappers;
using HMS.Data;
using HMS.Dtos;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace HMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _Mapper;

        public RoomTypeController(IHMSRepo iHMS, IMapper iMapper)
        {
            _repository = iHMS;
            _Mapper = iMapper;
        }

        [Authorize]
        [HttpGet()]
        public IActionResult Get()
        {

            var roomType = _repository.getAllRoomTypes();
            //use this if you need to filter out some columns
            var readRoomType = _Mapper.Map<IEnumerable<RoomTypeReadDto>>(roomType);
            //   var  readRoomType = _Mapper.Map<RoomTypeReadDto>(roomType);
            return Ok(readRoomType);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(RoomTypeCreateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RoomTypeReadDto readRoomType = new RoomTypeReadDto();

            _repository.BeginTransaction();
            try
            {
                var room = _Mapper.Map<RoomType>(model);
                _repository.createRoomType(room);
                _repository.saveChanges();
                _repository.CommitTransaction();
                readRoomType = _Mapper.Map<RoomTypeReadDto>(room);

            }
            catch (Exception ex)
            {

                _repository.RollBackTransaction();
                throw new ApiException(ex.Message, 400);
            }

            return Ok(readRoomType);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRoomTypeById(int id)
        {

            if (id == 0)
                return NotFound();

            var roomType = _repository.getRoomType(id);
            if (roomType == null) return NotFound();
            var readRoomType = _Mapper.Map<RoomTypeReadDto>(roomType);

            return Ok(readRoomType);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RoomTypeCreateDto model)
        {
            var roomtypeModelFromRepo = _repository.getRoomType(id);
            if (roomtypeModelFromRepo == null)
                return NotFound();

            var roomtypeUpdateModel = _Mapper.Map(model, roomtypeModelFromRepo);
            _repository.updateRoomType(roomtypeUpdateModel);
            _repository.saveChanges();
            return Ok(roomtypeUpdateModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var roomType = _repository.getRoomType(id);
            if (roomType == null)
                return NotFound();

            _repository.deleteRoomType(roomType);
            _repository.saveChanges();

            return NoContent();
        }



        [HttpGet("getmetadata")]
        public IActionResult GetMetadata()
        {
            var metaData = Util.GetRoomTypeMetaData();
            return Ok(metaData);
        }
    }
}