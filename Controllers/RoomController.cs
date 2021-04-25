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
    public class RoomController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _Mapper;

        public RoomController(IHMSRepo iHMS, IMapper iMapper)
        {
            _repository = iHMS;
            _Mapper = iMapper;
        }

        [Authorize]
        [HttpGet()]
        public IActionResult Get()
        {

            var room = _repository.getreadRooms();
            // var readRoom = _Mapper.Map<IEnumerable<RoomReadDto>>(room);
            //   var  readRoomType = _Mapper.Map<RoomTypeReadDto>(roomType);
            return Ok(room);
        }
        [HttpGet("freerooms")]
        [Authorize]
        public IActionResult GetFreeRooms()
        {

            var room = _repository.GetFreeRoom();
            var readRoom = _Mapper.Map<IEnumerable<RoomReadDto>>(room);

            return Ok(readRoom);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(RoomCreateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isRoomExits = _repository.getRoom(model.RoomNo);
            if (isRoomExits != null)
            {
                return BadRequest("Room Number Already Exists");
            }
            RoomReadDto readRoom = new RoomReadDto();

            _repository.BeginTransaction();
            try
            {
                var room = _Mapper.Map<Room>(model);
                _repository.createRoom(room);
                _repository.saveChanges();
                _repository.CommitTransaction();
                readRoom = _Mapper.Map<RoomReadDto>(room);

            }
            catch (Exception ex)
            {

                _repository.RollBackTransaction();
                throw new ApiException(ex.Message, 400);
            }

            return Ok(readRoom);
        }
        // [Authorize]
        // [HttpGet("{id}")]
        // public IActionResult GetRoomTypeById(int id)
        // {

        //     if (id == 0)
        //         return NotFound();

        //     var roomType = _repository.getRoomType(id);
        //     if (roomType == null)
        //         return NotFound();
        //     var readRoomType = _Mapper.Map<RoomTypeReadDto>(roomType);

        //     return Ok(readRoomType);

        // }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _repository.getRoom(id);
            var readRoom = _Mapper.Map<RoomReadDto>(room);
            return Ok(readRoom);
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, RoomCreateDto model)
        {
            var room = _repository.getRoom(id);
            if (room == null)
                return NotFound();
            var roomUpdateModel = _Mapper.Map(model, room);

            _repository.updateRoom(roomUpdateModel);
            _repository.saveChanges();
            //sending the updated data model
            var roomUpdatedModel = _Mapper.Map<RoomReadDto>(roomUpdateModel);
            return Ok(roomUpdatedModel);
        }

        [HttpGet("getmetadata")]
        public IActionResult GetMetadata()
        {
            var metaData = Util.GetRoomMetaData();
            return Ok(metaData);
        }
    }
}