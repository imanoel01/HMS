using AutoMapper;
using HMS.Data;
using HMS.Dtos;
using Microsoft.AspNetCore.Mvc;

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

        // [Authorize]
        [HttpGet]
        public IActionResult Get()
        {

            var roomType = _repository.getAllRoomTypes();
            var readRoomType = _Mapper.Map<RoomTypeReadDto>(roomType);
            return Ok(readRoomType);
        }
    }
}