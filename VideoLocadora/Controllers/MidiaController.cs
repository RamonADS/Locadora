using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoLocadora.Dados;

namespace VideoLocadora.Controllers
{
    public class MidiaController : ApiController
    {
        // GET api/values
        public IList<Models.Midia> Get(int id) //MOSTRA TODAS INFO's SOBRE UMA MIDIA ESPECIFICA
        {
            List<Models.Midia> retorno = new List<Models.Midia>();
            using (var context = new Locadora_Modelo())
            {
                var lista = context.Midia.Where(s => s.ID == id).ToList();

                foreach (var item in lista)
                {
                    Models.Midia midia = new Models.Midia();
                    midia.ID = item.ID;
                    midia.Titulo = item.Titulo;
                    midia.Copias = item.Copias;
                    midia.Titulo = midia.Titulo.TrimEnd();

                    retorno.Add(midia);
                }
                return retorno;
            }
        }

        public IList<string> GetMidias() //MOSTRA APENAS O TITULO DE TODAS MIDIAS
        {
            List<string> retorno = new List<string>();
            using (var context = new Locadora_Modelo())
            {
                var lista = context.Midia.ToList();
                
                foreach (var item in lista)
                {
                    Models.Midia midia = new Models.Midia();
                    midia.Titulo = item.Titulo;                   
                    midia.Titulo=midia.Titulo.TrimEnd();
                   retorno.Add(midia.Titulo);
                }
                return retorno;
            }
        }
        
        // GET api/values/5
        public IList<Models.Midia> Get() //MOSTRA TODAS INFO's SOBRE TODAS AS MIDIAS
        {
            List<Models.Midia> retorno = new List<Models.Midia>();
            using (var context = new Locadora_Modelo())
            {
                var lista = context.Midia.ToList();

                foreach (var item in lista)
                {
                    Models.Midia midia = new Models.Midia();
                    midia.ID = item.ID;
                    midia.Titulo = item.Titulo;
                    midia.Copias = item.Copias;
                    
                    retorno.Add(midia);
                }
                return retorno;
            }
        }

        // POST api/values
        public Models.Midia Post([FromBody] Models.Midia dto)
        {
            using (var context = new Locadora_Modelo())
            {
                var midia = new Midia();
                midia.Titulo = dto.Titulo;
                midia.Copias = dto.Copias;
               
                context.Midia.Add(midia);
                context.SaveChanges();
                dto.ID = midia.ID;
            }
            return dto;
        }

        // PUT api/values/5
        public Models.Midia Put([FromBody] Models.Midia dto)
        {
            using (var context = new Locadora_Modelo())
            {
                var midia = context.Midia.First(s => s.ID == dto.ID);

                midia.Titulo = dto.Titulo;
                midia.Copias= dto.Copias;
                
                context.SaveChanges();
                dto.ID = midia.ID;
            }
            return dto;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var context = new Locadora_Modelo())
            {
                var midia = context.Midia.First(s => s.ID == id);

                context.Midia.Remove(midia);
                context.SaveChanges();
            }
        }
    }
}
