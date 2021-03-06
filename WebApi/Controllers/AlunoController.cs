﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public List<Aluno> Get()
        {
            Aluno aluno = new Aluno();
            return aluno.listaAlunos();
        }

        // GET: api/Aluno/5
        public Aluno Get(int id)
        {
            Aluno aluno = new Aluno();

            return aluno.listaAlunos().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Aluno> Post(Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            _aluno.Inserir(aluno);

            return _aluno.listaAlunos();
        }

        // PUT: api/Aluno/5
        public Aluno Put(int id, [FromBody]Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            return _aluno.Atualizar(id, aluno);
        }
        
        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            Aluno _aluno = new Aluno();

            _aluno.Deletar(id);
        }
    }
}
