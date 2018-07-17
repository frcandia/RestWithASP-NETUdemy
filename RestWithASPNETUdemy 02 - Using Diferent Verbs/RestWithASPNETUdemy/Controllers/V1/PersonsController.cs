using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;

namespace RestWithASPNETUdemy.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_personBusiness.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(long id)
        {
            var person = _personBusiness.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<Person> Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            var updatedPerson = _personBusiness.Update(person);

            if (updatedPerson == null)
                return BadRequest();

            return new ObjectResult(updatedPerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
