using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using HMS.Data;
using HMS.Dtos;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _mapper;

        public ReservationController(IHMSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {

            var reservation = _repository.GetReservations();
            var readReservation = _mapper.Map<IEnumerable<ReservationReadDto>>(reservation);

            return Ok(readReservation);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _repository.GetReservation(id);
            var readCustomer = _mapper.Map<ReservationReadDto>(reservation);
            return Ok(reservation);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(CreateReservationDto model)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ReservationReadDto readDto = new ReservationReadDto();
            try
            {

                //mark room as booked
                //might want to differientiate online and admin  end points but 
                //use the same implementation
                // online user's reservation room should still be free until they make payment
                //perphaps there should be a setup that tell us how long an online room should 
                //remain booked before  successful transaction is confirmed.
                _repository.BeginTransaction();
                var reservation = _mapper.Map<Reservation>(model);
                reservation.DateCreated = DateTime.Now;
                reservation.ReservationDate = DateTime.Now;
_repository.updateRoomStatus(reservation.RoomId,RoomStatusEnum.BookedPaid);
                _repository.createReservation(reservation);
                _repository.saveChanges();
                _repository.CommitTransaction();
                readDto = _mapper.Map<ReservationReadDto>(reservation);
            }
            catch (Exception ex)
            {
                _repository.RollBackTransaction();
                throw new ApiException(ex.Message, 400);
            }

            return Ok(readDto);

        }

        [HttpPut("{id}")]
        public void Put(int id, UpdateReservationDto value)
        {
            //if the bill is settled  we can not not modified it
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("getmetadata")]
        public IActionResult GetMetadata()
        {
            var metaData = Util.GetReservationMetaData();
            return Ok(metaData);
        }
    }
}