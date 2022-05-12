using AT1__PerfectPolicy_.DTO;
using AT1__PerfectPolicy_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        #region Setup
        private readonly QuizContext _context;

        public QuizController(QuizContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints

        [HttpGet]
        public ActionResult<IEnumerable<Quiz>> Get()
        {
            return _context.Quizs;
        }

        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            if (id == 0)
            {
                return NotFound(new { message = "No entries exist with an ID of 0", requestedID = id });
            }
            var quiz = _context.Quizs.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return quiz;
        }

        [HttpPost]
        public ActionResult<Quiz> Post(Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest();
            }

            _context.Quizs.Add(quiz);
             _context.SaveChanges();

             return CreatedAtAction("Post", quiz);                     
        }

        [HttpPut("{id}")]
        public ActionResult<Quiz> Put(int id, [FromBody] Quiz quiz)
        {
            if (id != quiz.QuizID)
            {
                return BadRequest();
            }
            
            _context.Quizs.Update(quiz);
            _context.SaveChanges();
            return Ok(quiz);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Quiz quiz = _context.Quizs.Find(id);

            if (quiz != null)
            {

                _context.Quizs.Remove(quiz);
                _context.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        #endregion


    }
}

