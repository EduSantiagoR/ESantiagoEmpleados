using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/departamento")]
    public class DepartamentoController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Departamento.GetAll();
            return (result.Correct) ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
    }
}
