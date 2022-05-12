using AT1__PerfectPolicy_.DTO;
using AT1__PerfectPolicy_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        #region Setup

        private readonly QuizContext _context;

        public QuestionController(QuizContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints

        [HttpGet]
        
        public IEnumerable<Question> Get()
        {
            return _context.Questions;
        }

        [HttpGet("{id}")]
        public ActionResult<Question>Get(int id)
        {
            var question = _context.Questions.Find(id);

            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        [HttpPost]
        public ActionResult<Question> Post(QuestionCreate question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            Question newQuestion = new Question()
                {
                    QuestionTopic = question.QuestionTopic,
                    QuestionText = question.QuestionText,
                    QuestionImage = question.QuestionImage,
                    Title = question.Title
            };

            _context.Questions.Add(newQuestion);
            _context.SaveChanges();

            return CreatedAtAction("Post", newQuestion);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Question> Put(int id, Question question)
        {
            if (id != question.QuestionID)
            {
                return BadRequest();
            }

            _context.Questions.Update(question);
            _context.SaveChanges();

            return Ok(question);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete (int id)
        {
            var question = _context.Questions.Find(id);

            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();

                return Ok();
            }
            
            return NotFound(new { message = "No item with that ID could be found" });
        }

        #endregion

        #region Custom Endpoints

        /// <summary>
        /// Get all Questions for a given QuizID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QuestionsForQuizTitle")]

        public ActionResult QuestionsForQuizTitle(string id)
        {
            return Ok(_context.Questions.Where(c => c.Title == id));
        }

        #endregion

    }
}
