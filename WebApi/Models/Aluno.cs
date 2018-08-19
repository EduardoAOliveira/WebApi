using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string telefone { get; set; }

        public int RA { get; set; }

        public List<Aluno> listaAlunos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaalunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return listaalunos;
        }

        /// <summary>
        /// Persiste o Aluno no arquivo Json.
        /// </summary>
        /// <param name="listaAlunos"></param>
        /// <returns></returns>
        public bool RescreverArquivo(List<Aluno> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Aluno Inserir(Aluno Aluno)
        {
            var listaAlunos = this.listaAlunos();

            var maxId = listaAlunos.Max(p => p.Id);
            Aluno.Id = maxId + 1; // Busca o ultimo Id
            listaAlunos.Add(Aluno);

            RescreverArquivo(listaAlunos);
            return Aluno;
        }

        public Aluno Atualizar(int Id, Aluno Aluno)
        {
            var listaAlunos = this.listaAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.Id == Aluno.Id);
            if(itemIndex >= 0)
            {
                Aluno.Id = Id;
                listaAlunos[itemIndex] = Aluno;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaAlunos);
            return Aluno;
        }
        public bool Deletar(int Id)
        {
            var listaAlunos = this.listaAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            RescreverArquivo(listaAlunos);
            return true;
        }
    }
}