using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BookVO>> Get()
        {
            var entities = _bookBusiness.GetAll();
            return Ok(entities);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BookVO> Get(long id)
        {
            var book = _bookBusiness.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<BookVO> Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<BookVO> Put([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            var updatedBook = _bookBusiness.Update(book);

            if (updatedBook == null)
                return BadRequest();

            return new ObjectResult(updatedBook);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);

            return NoContent();
        }

    }
}
