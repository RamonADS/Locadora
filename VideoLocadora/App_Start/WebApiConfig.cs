using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.EquivalencyExpression;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace VideoLocadora
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            Mapper.Initialize(cfg => {
                cfg.AddCollectionMappers();
            });
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional , action = RouteParameter.Optional }
            );
        }
    }
}
