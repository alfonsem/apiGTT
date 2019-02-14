﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proyectoPrueba.Helpers;
using proyectoPrueba.Models;

namespace proyectoPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UsersController(AppDBContext context)         {             this._context = context;             if (this._context.Users.Count() == 0)             {                 Console.WriteLine("No existen usuarios");                 Users usuario = new Users();                 usuario.username = "Alfonso";                 //usuario.password = "password";
                usuario.password = Encrypt.GetMD5("pass");
                usuario.admin = true;                 this._context.Users.Add(usuario);                 this._context.SaveChanges();             }         }

        // GET api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(long id)
        {
            Users user = this._context.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            value.password = Encrypt.GetMD5(value.password);
            Console.WriteLine(value.password);
            this._context.Users.Add(value);
            this._context.SaveChanges();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Users value)
        {
            Users user = this._context.Users.Find(id);
            user.username = value.username;
            user.password = value.password;
            user.admin = value.admin;
            this._context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Users userEliminar = this._context.Users.Where(
                user => user.id == id).First();
            if (userEliminar == null)
            {
                return "No existe usuario";
            }
            this._context.Remove(userEliminar);
            this._context.SaveChanges();
            return "Se ha borrado -> " + userEliminar.id;
        }
    }
}
