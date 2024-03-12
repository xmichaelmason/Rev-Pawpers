using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyBL ReplyRepository;

        public ReplyController(IReplyBL context)
        {
            ReplyRepository = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllReplies()
        {
            return Ok(ReplyRepository.GetAll());
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(ReplyRepository.GetByPrimaryKey(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("SearchByProfile/{id}")]
        public IActionResult SearchByProfile(int id)
        {
            try
            {
                return Ok(ReplyRepository.SearchByProfileId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("SearchByTopic/{id}")]
        public IActionResult SearchByTopic(int id)
        {
            try
            {
                return Ok(ReplyRepository.SearchByTopicId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }


        // POST <ReplyController>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Reply p_reply)
        {
            ReplyRepository.Create(p_reply);
            ReplyRepository.Save();
            return Created("Reply/Add", p_reply);
        }

        // PUT <ReplyController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Reply p_reply)
        {
            var rep = ReplyRepository.GetByPrimaryKey(id);
            if (rep != null)

            {
                rep.ReplyId = p_reply.ReplyId;
                rep.ReplyMessage = p_reply.ReplyMessage;
                rep.ReplyTimestamp = p_reply.ReplyTimestamp;
                rep.ProfileId = p_reply.ProfileId;
                rep.TopicId = p_reply.TopicId;

                ReplyRepository.Update(rep);
                ReplyRepository.Save();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE <ReplyController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var reply = ReplyRepository.GetByPrimaryKey(id);
                ReplyRepository.Delete(reply);
                ReplyRepository.Save();
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
