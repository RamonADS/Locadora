using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoLocadora.Dados;

namespace VideoLocadora.Controllers
{
    public class ClienteController : ApiController
    {
        // GET api/values
        public IList<Models.Cliente> Get()
        {
            List<Models.Cliente> retorno = new List<Models.Cliente>();
            using (var context = new Locadora_Modelo())
            {
                var list = context.Cliente.ToList();

                foreach (var item in list)
                {
                    Models.Cliente aluguel = new Models.Cliente();
                    aluguel.ID = item.ID;
                    aluguel.Nome = item.Nome;
                    aluguel.CPF = item.CPF;
                    aluguel.Nome = aluguel.Nome.TrimEnd();
                    retorno.Add(aluguel);
                }
                return retorno;
            }
        }
        public IList<Models.Cliente> Get(int id)
        {
            List<Models.Cliente> retorno = new List<Models.Cliente>();
            using (var context = new Locadora_Modelo())
            {
                var list = context.Cliente.Where(s => s.ID == id).ToList();

                foreach (var item in list)
                {
                    Models.Cliente cliente = new Models.Cliente();
                    cliente.ID = item.ID;
                    cliente.Nome = item.Nome;
                    cliente.CPF = item.CPF;
                    cliente.Nome = cliente.Nome.TrimEnd();
                    retorno.Add(cliente);
                }
                return retorno;
            }
        }

        // POST api/values
        public Models.Cliente Post([FromBody] Models.Cliente dto)
        {
            using (var context = new Locadora_Modelo())
            {
                var cliente = new Cliente();
                cliente.ID= dto.ID;
                cliente.Nome = dto.Nome;
                cliente.CPF = dto.CPF;

                context.Cliente.Add(cliente);
                context.SaveChanges();
                dto.ID = cliente.ID;
            }
            return dto;
        }

        // PUT api/values/5
        public Models.Cliente Put([FromBody] Models.Cliente dto)
        {
            using (var context = new Locadora_Modelo())
            {
                var cliente = context.Cliente.First(s => s.ID == dto.ID);

                cliente.ID = dto.ID;
                cliente.Nome = dto.Nome;
                cliente.CPF = dto.CPF;

                context.SaveChanges();
                dto.ID = cliente.ID;
            }
            return dto;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var contexto = new Locadora_Modelo())
            {
                var cliente = contexto.Cliente.First(s => s.ID == id);
                var aluguel = contexto.Aluguel.Where(s => s.ID_Cliente == id);
                
                var codalgueis= aluguel.Select(x => x.ID).ToList();
                var aluguelmidia = contexto.Aluguel_Midia.Where(s => codalgueis.Contains(s.ID_Aluguel));

                contexto.Aluguel_Midia.RemoveRange(aluguelmidia);
                contexto.Aluguel.RemoveRange(aluguel);
                contexto.Cliente.Remove(cliente);

                contexto.SaveChanges();
            }
        }
    }
}
