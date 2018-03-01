using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoLocadora.Dados;

namespace VideoLocadora.Controllers
{
    public class AluguelController : ApiController
    {
        // GET api/values
        public IList<Models.Aluguel> Get(int IdCliente) 
        {
            List<Models.Aluguel> retorno = new List<Models.Aluguel>();
            using (var context = new Locadora_Modelo())
            {
                var cliente = context.Aluguel.Where(s => s.ID_Cliente == IdCliente).ToList();
                
                foreach (var item in cliente)
                {
                    Models.Aluguel aluguel = new Models.Aluguel();
                    aluguel.ID = item.ID;
                    aluguel.ID_Cliente = item.ID_Cliente;
                    aluguel.Retirada = item.Retirada;
                    aluguel.Devolucao = item.Devolucao;
                    retorno.Add(aluguel);
                }                 
                return retorno;
            }
        }
        public IList<Models.Aluguel> Get()
        {
            List<Models.Aluguel> retorno = new List<Models.Aluguel>();
            using (var context = new Locadora_Modelo())
            {
                var cliente = context.Aluguel.ToList();

                foreach (var item in cliente)
                {
                    Models.Aluguel aluguel = new Models.Aluguel();
                    aluguel.ID = item.ID;
                    aluguel.ID_Cliente = item.ID_Cliente;
                    aluguel.Retirada = item.Retirada;
                    aluguel.Devolucao = item.Devolucao;
                    aluguel.Cliente.Nome = item.Cliente.Nome;

                    foreach (var aluguelMidia in item.Aluguel_Midia)
                    {
                        Models.Midia midia = new Models.Midia();
                        midia.Copias = aluguelMidia.Midia.Copias;
                        midia.ID = aluguelMidia.Midia.ID;
                        midia.Titulo = aluguelMidia.Midia.Titulo;

                        //Models.Aluguel_Midia Aluguel_Midia = new Models.Aluguel_Midia();
                        //Aluguel_Midia.Midia = midia;

                        aluguel.Midias.Add(midia);
                    }
                    retorno.Add(aluguel);
                }
                return retorno;
            }
        }
        // POST api/values
        public Models.Aluguel Post([FromBody] Models.Aluguel dto)
        {           
            using (var context = new Locadora_Modelo())
            {
                var aluguel = new Aluguel();
                
                aluguel.ID_Cliente = dto.ID_Cliente;
                aluguel.Retirada = dto.Retirada;
                aluguel.Devolucao = dto.Devolucao;
                
                foreach (var midiaId in dto.CodigosMidias)
                {
                    Aluguel_Midia almid = new Aluguel_Midia();
                    almid.Aluguel = aluguel;

                    var midia = context.Midia.First(s => s.ID == midiaId);

                    almid.Midia = midia;
                    
                    aluguel.Aluguel_Midia.Add(almid);
                } 


                context.Aluguel.Add(aluguel);
                context.SaveChanges();
                dto.ID = aluguel.ID;
            }
            return dto;           
        }

        

        public Models.Aluguel Put([FromBody] Models.Aluguel dto)
        {
            using (var context = new Locadora_Modelo())
            {
                var aluguel = context.Aluguel.First(s => s.ID == dto.ID);

                var id_midiasDb = aluguel.Aluguel_Midia.Select(s => s.ID_Midia).ToList();
                var codigosRemover = id_midiasDb.Where(s => !dto.CodigosMidias.Contains(s)).ToList();
                
                foreach (var item in codigosRemover)
                {
                    var vinculoExcluir = context.Aluguel_Midia.First(s => s.ID_Midia == item);
                    // aluguel.Aluguel_Midia.FirstOrDefault(s => item==s.ID_Midia);
                    //vinculoExcluir.ID_Midia = null;

                    context.Aluguel_Midia.Remove(vinculoExcluir);
                    //aluguel.Aluguel_Midia.Remove(vinculoExcluir);
                }            

                aluguel.ID_Cliente = dto.ID_Cliente;
                aluguel.Retirada = dto.Retirada;
                aluguel.Devolucao = dto.Devolucao;

                          
                    //var LerMidiaExist = aluguel.Aluguel_Midia.Select(s => s.ID_Midia).ToList();

                    var NewMidia = dto.CodigosMidias.Where(s => !id_midiasDb.Contains(s)).ToList();
                    
                    foreach (var item in NewMidia)
                    {
                        Aluguel_Midia almid = new Aluguel_Midia();
                        almid.Aluguel = aluguel;

                        var midia = context.Midia.First(s => s.ID == item);

                        almid.Midia = midia;

                        aluguel.Aluguel_Midia.Add(almid);
                    }
               

                context.SaveChanges();
                dto.ID = aluguel.ID;

            }
            return dto;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var context = new Locadora_Modelo())
            {                
                var aluguel = context.Aluguel.Where(s => s.ID == id);

                var codalgueis = aluguel.Select(x => x.ID).ToList();
                var aluguelmidia = context.Aluguel_Midia.Where(s => codalgueis.Contains(s.ID_Aluguel));

                context.Aluguel_Midia.RemoveRange(aluguelmidia);
                context.Aluguel.RemoveRange(aluguel);

                context.SaveChanges();
            }
        }
    }
}
