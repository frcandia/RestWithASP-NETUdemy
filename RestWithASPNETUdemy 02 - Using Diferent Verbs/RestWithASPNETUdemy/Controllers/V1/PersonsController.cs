using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<IEnumerable<PersonVO>> Get()
        {
            return Ok(_personBusiness.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> Get(long id)
        {
            var person = _personBusiness.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var updatedPerson = _personBusiness.Update(person);

            if (updatedPerson == null)
                return BadRequest();

            return new ObjectResult(updatedPerson);
        }

        // PATCH api/values/5
        [HttpPatch]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> Patch([FromBody] PersonVO person)
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
