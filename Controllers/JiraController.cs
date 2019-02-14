using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proyectoPrueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyectoPrueba.Controllers
{
    [Route("api/[controller]")]
    public class JiraController : Controller
    {
        private readonly AppDBContext _context;

        public JiraController (AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Jira> Post([FromBody]Jira value)
        {
            this._context.Jira.Add(value);
            this._context.SaveChanges();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
