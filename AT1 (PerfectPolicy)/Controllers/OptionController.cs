using AT1__PerfectPolicy_.DTO;
using AT1__PerfectPolicy_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        
        #region Setup

        private readonly QuizContext _context;

        public OptionController(QuizContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints
        [HttpGet]
        // GET: OptionController
        public IEnumerable<Option> Get()
        {
            return _context.Options;
        }
        [HttpGet("{id}")]
        // GETALL: OptionController
        public ActionResult<Option> Get(int id)
        {
            if (id == 0)
            {
                return NotFound(new { message = "No entries exist with an ID of 0", attempts = 1, requestedID = id });
            }
            var option = _context.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }
            return option;
        }

        [HttpPost]
        public ActionResult<Option> Post(OptionCreate option)

        {
            if (option == null)
            {
                return BadRequest();
            }

        Option newOption = new Option()
        {
            OptionText = option.OptionText,
            OptionOrderByLetter = option.OptionOrderByLetter,
            OptionOrderByNumber = option.OptionOrderByNumber,
            Answer = option.Answer,
            QuestionID = option.QuestionID
        };

        _context.Options.Add(newOption);
        _context.SaveChanges();

        return CreatedAtAction("Post", newOption);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Option> Put(int id, [FromBody] Option option)
        {
            if (id != option.OptionID)
            {
                return BadRequest();
            }

            _context.Options.Update(option);
            _context.SaveChanges();

            return Ok(option);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var option = _context.Options.Find(id);

            if (option != null)
            {
                _context.Options.Remove(option);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        #endregion

        #region Custom Endpoints

        /// <summary>
        /// Get all options for a given QuestionID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OptionsForQuestionID")]
        public ActionResult OptionsForQuestionID(int id)
        {
            return Ok(_context.Options.Where(c => c.QuestionID == id));
        }

        #endregion

    }
}