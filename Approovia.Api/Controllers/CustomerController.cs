using Approovia.Core.ApiResponse;
using Approovia.Core.Interface.Repositories;
using Approovia.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Approovia.Core.Utility.Constants;

namespace Approovia.Api.Controllers
{
    public class CustomerController : ControllerBase
    {

        private readonly IMongoRepository<Customer> _customerRepository;

        public CustomerController(IMongoRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("CreateDriver")]
        public async Task<IActionResult> CreateDriver(Customer customer)
        {
            try
            {

                if (customer == null)

                    return BadRequest();

                var CreatedCustomer = await _customerRepository.Create(customer);
                if (CreatedCustomer != null)
                {
                    // return Ok(CreatedDriver.DriverDto);
                    return Ok(new ResponseModel<object>
                    {
                        RequestSuccessful = true,
                        ResponseCode = ResponseCodes.Successful,
                        Message = $"Your Comments was succesfully Sent.",
                        ResponseData = CreatedCustomer
                    });
                }
                return Ok();

                //return CreatedAtAction(nameof(CreateDriver), new
                //{
                //    id = CreatedDriver.DriverId,
                //    //Name = CreatedDriverr.Name,
                //    //SiteId = CreatedDriverr.SiteId,
                //    //EmployeeNumber = CreatedDriverr.EmployeeNumber
                //}, CreatedDriver);


            }


            catch (Exception)
            {
                // return StatusCode(StatusCodes.Status500InternalServerError, "could not create Driver"); this also works.

                return BadRequest(new ResponseModel<object>
                {
                    ResponseCode = ResponseCodes.Failed,
                    Message = "Failed. You Were unable to Send Your Comments"
                });
            }


        }

    }
}
