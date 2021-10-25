using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using HMS;
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

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repository.getCustomerById(id);
            var readCustomer = _mapper.Map<ReadCustomerDto>(customer);
            return Ok(readCustomer);
        }

        [Authorize]
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
                //customer.DateCreated = DateTime.Now;
                _repository.createCustomer(customer);
                _repository.saveChanges();
                _repository.CommitTransaction();
                readDto = _mapper.Map<ReadCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                _repository.RollBackTransaction();
                throw new ApiException(ex.Message, 400);
            }


            return Ok(readDto);
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, CreateCustomerDto  model)
        {
            var customerModelFromRepo= _repository.getCustomerById(id);
            if (customerModelFromRepo==null)
            return NotFound();

          var customerUpdateModel=  _mapper.Map(model,customerModelFromRepo);
            _repository.updateCustomer(customerUpdateModel);
            _repository.saveChanges();
            return Ok(customerUpdateModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _repository.getCustomerById(id);
            if(customer ==null)
                return NotFound();

            _repository.deleteCustomer(customer);
            _repository.saveChanges();

            return NoContent();
        }

        [HttpGet("getmetadata")]
        public IActionResult GetMetadata()
        {
            var metaData = Util.GetCustomerMetaData();
            return Ok(metaData);
        }
    }
}