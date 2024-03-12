using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicBL topicRepository;

        public TopicController(ITopicBL context)
        {
            topicRepository = context;
        }
        // GET: <TopicController>


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(topicRepository.GetAll());
        }

        [HttpGet("GetAllWithNav")]
        public IActionResult GetAllWithNav()
        {
            return Ok(topicRepository.GetAllWithNav());
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetByPrimaryKey(int id)
        {
            try
            {
                return Ok(topicRepository.GetByPrimaryKey(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("GetWithNav/{id}")]
        public IActionResult GetByIdWithNav(int id)
        {
            try
            {
                return Ok(topicRepository.GetByIdWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }

        }

        [HttpGet("ListByCategory/{id}")]
        public IActionResult ListByCategoryId(int id)
        {
            try
            {
                return Ok(topicRepository.ListByCategoryId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("SearchByName/{query}")]
        public IActionResult SearchByName(string query)
        {
            try
            {
                return Ok(topicRepository.SearchByName(query));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid search field");
            }
        }

        [HttpGet("SearchByBody/{query}")]
        public IActionResult SearchByBody(string query)
        {
            try
            {
                return Ok(topicRepository.SearchByBody(query));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid search field");
            }
        }

        [HttpGet("SearchByProfile/{id}")]
        public IActionResult SearchByProfileId(int id)
        {
            try
            {
                return Ok(topicRepository.SearchByProfileId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid search id");
            }
        }

        // POST <TopicController>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Topic p_topic)
        {
            topicRepository.Create(p_topic);
            topicRepository.Save();
            return Created("Topic/Add", p_topic);
        }

        // PUT <TopicController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Topic p_topic)
        {

            var topic = topicRepository.GetByPrimaryKey(id);
            try
            {
                topic.TopicBody = p_topic.TopicBody;
                topic.TopicId = p_topic.TopicId;
                topic.PostTimestamp = p_topic.PostTimestamp;
                topic.TopicName = p_topic.TopicName;
                topic.ProfileId = p_topic.ProfileId;
                topic.CategoryId = p_topic.CategoryId;

                topicRepository.Update(topic);
                topicRepository.Save();

                return Ok();

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");

            }
        }

        // DELETE <TopicController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var topic = topicRepository.GetByPrimaryKey(id);
                topicRepository.Delete(topic);
                topicRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }
    }
}
