using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {

        private readonly IBaseBL<State> stateRepository;

        public StateController(IBaseBL<State> context)
        {
            stateRepository = context;
        }




        // GET: api/<StateController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(stateRepository.GetAll());
        }

        // GET api/<StateController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(stateRepository.GetByPrimaryKey(id));
        }

        // POST api/<StateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
