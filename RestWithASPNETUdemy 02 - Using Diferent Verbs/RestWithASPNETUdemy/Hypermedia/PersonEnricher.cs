using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Hypermedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            return Task.Run(() =>
            {
                var path = "api/v1/persons";
                var url = new { Controller = path, Id = content.Id };
                var urlPost = new { Controller = path };

                var urlBase = urlHelper.ActionContext.HttpContext.Request.Scheme + "://" + urlHelper.ActionContext.HttpContext.Request.Host;

                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.GET,
                    Href = urlBase + urlHelper.RouteUrl("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultGet
                });

                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.POST,
                    Href = urlBase + urlHelper.RouteUrl("DefaultApi", urlPost),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
                });

                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.PUT,
                    Href = urlBase + urlHelper.RouteUrl("DefaultApi", urlPost),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
                });

                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.DELETE,
                    Href = urlBase + urlHelper.RouteUrl("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = "int"
                });
            });
        }
    }
}
