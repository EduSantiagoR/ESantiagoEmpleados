using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL.Controllers
{
    [RoutePrefix("api/empleado")]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class EmpleadoController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            return result.Correct ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
        [Route("{claveEmpleado}")]
        [HttpGet]
        public IHttpActionResult GetByClaveEmpleado(string claveEmpleado)
        {
            ML.Result result = BL.Empleado.GetByClaveEmpleado(claveEmpleado);
            return result.Correct ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return result.Correct ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
        [Route("{claveEmpleado}")]
        [HttpPut]
        public IHttpActionResult Update(string claveEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.ClaveEmpleado = claveEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);
            return result.Correct ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
        [Route("{claveEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete(string claveEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(claveEmpleado);
            return result.Correct ? Content(HttpStatusCode.OK, result) : Content(HttpStatusCode.BadRequest, result);
        }
    }
}
