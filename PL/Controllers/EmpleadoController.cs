using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empleados = new List<object>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44379/api/");
                var taskResponse = client.GetAsync("empleado");
                taskResponse.Wait();
                var resultService = taskResponse.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsStringAsync();
                    readTask.Wait();

                    dynamic jsonResult = JObject.Parse(readTask.Result.ToString());
                    foreach(var item in jsonResult.Objects)
                    {
                        ML.Empleado empleadoResult = new ML.Empleado();
                        empleadoResult.ClaveEmpleado = item.ClaveEmpleado;
                        empleadoResult.Nombre = item.Nombre;
                        empleadoResult.ApellidoPaterno = item.ApellidoPaterno;
                        empleadoResult.ApellidoMaterno = item.ApellidoMaterno;
                        empleadoResult.FechaIngreso = item.FechaIngreso;
                        empleadoResult.FechaNacimiento = item.FechaNacimiento;
                        empleadoResult.Departamento.ClaveDepartamento = item.Departamento.ClaveDepartamento;
                        empleadoResult.Departamento.Descripcion = item.Departamento.Descripcion;
                        empleadoResult.Sueldo.SueldoMensual = item.Sueldo.SueldoMensual;
                        empleadoResult.Sueldo.FormaPago = item.Sueldo.FormaPago;

                        empleado.Empleados.Add(empleadoResult);
                    }
                }
            }
            return View(empleado);
        }
        [HttpGet]
        public ActionResult Form(string claveEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            if(claveEmpleado != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44379/api/");
                    var taskResponse = client.GetAsync($"empleado/{claveEmpleado}");
                    taskResponse.Wait();
                    var resultService = taskResponse.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        var readTask = resultService.Content.ReadAsStringAsync();
                        readTask.Wait();

                        dynamic jsonResult = JObject.Parse(readTask.Result.ToString());
                        empleado.ClaveEmpleado = jsonResult.Object.ClaveEmpleado;
                        empleado.Nombre = jsonResult.Object.Nombre;
                        empleado.ApellidoPaterno = jsonResult.Object.ApellidoPaterno;
                        empleado.ApellidoMaterno = jsonResult.Object.ApellidoMaterno;
                        empleado.FechaIngreso = jsonResult.Object.FechaIngreso;
                        empleado.FechaNacimiento = jsonResult.Object.FechaNacimiento;
                        empleado.Departamento.ClaveDepartamento = jsonResult.Object.Departamento.ClaveDepartamento;
                        empleado.Departamento.Descripcion = jsonResult.Object.Departamento.Descripcion;
                        empleado.Sueldo.SueldoMensual = jsonResult.Object.Sueldo.SueldoMensual;
                        empleado.Sueldo.FormaPago = jsonResult.Object.Sueldo.FormaPago;
                    }
                }
            }
            empleado.Departamento.Departamentos = new List<object>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44379/api/");
                var taskResponse = client.GetAsync("departamento");
                taskResponse.Wait();
                var resultService = taskResponse.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsStringAsync();
                    readTask.Wait();

                    dynamic jsonResult = JObject.Parse(readTask.Result.ToString());
                    foreach(var item in jsonResult.Objects)
                    {
                        ML.Departamento departamento = new ML.Departamento();
                        departamento.ClaveDepartamento = item.ClaveDepartamento;
                        departamento.Descripcion = item.Descripcion;
                        empleado.Departamento.Departamentos.Add(departamento);
                    }
                }
            }
            return View(empleado);
        }
        [HttpPost]
        public ActionResult Form(ML.Empleado empleado, string action)
        {
            if(action == "add")
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44379/api/");
                    var taskResponse = client.PostAsJsonAsync("empleado", empleado);
                    taskResponse.Wait();

                    var resultService = taskResponse.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Empleado agregado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar el empleado.";
                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44379/api/");
                    var taskResponse = client.PutAsJsonAsync($"empleado/{empleado.ClaveEmpleado}", empleado);
                    taskResponse.Wait();

                    var resultService = taskResponse.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Empleado actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar el empleado.";
                    }
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(string claveEmpleado)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44379/api/");
                var taskResponse = client.DeleteAsync($"empleado/{claveEmpleado}");
                taskResponse.Wait();
                var resultService = taskResponse.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Empleado eliminado correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al eliminar el empleado.";
                }
            }
            return PartialView("Modal");
        }
        
    }
}