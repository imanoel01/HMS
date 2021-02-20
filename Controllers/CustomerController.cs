using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using HMS.Data;
using HMS.Dtos;
using HMS.Helpers;
using HMS.Model;
using HMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHMSRepo _repository;
        private readonly IMapper _mapper;

        public CustomerController(IHMSRepo iHMSRepo, IMapper iMapper)
        {
            _repository = iHMSRepo;
            _mapper = iMapper;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var customer = _repository.getAllCustomers();

            return Ok(customer);
        }

        [HttpGet("id/{phone}")]
        public IActionResult Get(string phone)
        {
            var customer = _repository.getCustomerByNamePhoneEmail(phone);
            var readCustomer = _mapper.Map<ReadCustomerDto>(customer);
            return Ok(readCustomer);
        }

        [HttpPost]
        public IActionResult Post(CreateCustomerDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ReadCustomerDto readDto = new ReadCustomerDto();
            try
            {
                _repository.BeginTransaction();
                var customer = _mapper.Map<Customer>(model);
                customer.DateCreated = DateTime.Now;
                _repository.createCustomer(customer);
                _repository.saveChanges();
                readDto = _mapper.Map<ReadCustomerDto>(customer);

                _repository.CommitTransaction();
            
}
            catch (Exception ex)
            {
_repository.RollBackTransaction();
                throw new ApiException(ex.Message,400);
            }


            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}