using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApiEscola.Domain.Models;
using RestApiEscola.Domain.Services;


namespace RestApiEscola.Controllers
{
    public class EscolaController
    {

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEscolaService service;
        public EmployeesController(IEscolaService service)
        {
            this.service = service;
        }

        // GET: api/Professores
        [HttpGet]
        public List<Professor> Get()
        {
            var professors = service.ListAll();
            return professors;
        }

        // GET: api/Professor/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Professor> Get(int id)
        {
            var professor = service.GetById(id);
            if (professor != null)
                return professor;
            return NotFound();
        }

        // POST: api/Professores
        [HttpPost]
        public Professor Post([FromBody] Professor professor)
        {
            service.Add(professor);
            return professor;
        }

        // PUT: api/Professor/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Professor professor)
        {
            var professorFinded = service.GetById(id);
            if (professorFinded == null)
                return NotFound();
            professor.Id = id;
            service.Update(professor);
            return Ok(professor);
        }

        // DELETE: api/Professor/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var porfessorFinded = service.GetById(id);
            if (porfessorFinded == null)
                return NotFound();
            service.DeleteById(id);
            return Ok();
        }
    }
}
}
 