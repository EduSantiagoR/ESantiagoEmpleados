using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoEmpleadosEntities context = new DL.ESantiagoEmpleadosEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.ClaveEmpleado = item.ClaveEmpleado;
                            empleado.Nombre = item.Nombre;
                            empleado.ApellidoPaterno = item.ApellidoPaterno;
                            empleado.ApellidoMaterno = item.ApellidoMaterno;
                            empleado.FechaIngreso = item.FechaIngreso.Value;
                            empleado.FechaNacimiento = item.FechaNacimiento.Value;
                            empleado.Departamento.ClaveDepartamento = item.ClaveDepartamento;
                            empleado.Departamento.Descripcion = item.Descripcion;
                            empleado.Sueldo.SueldoMensual = item.SueldoMensual;
                            empleado.Sueldo.FormaPago = item.FormaPago;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar los empleados.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByClaveEmpleado(string claveEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoEmpleadosEntities context = new DL.ESantiagoEmpleadosEntities())
                {
                    var query = context.EmpleadoGetByClaveEmpleado(claveEmpleado).FirstOrDefault();
                    if (query != null)
                    {
                        result.Object = new object();
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.ClaveEmpleado = query.ClaveEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.FechaIngreso = query.FechaIngreso.Value;
                        empleado.FechaNacimiento = query.FechaNacimiento.Value;
                        empleado.Departamento.ClaveDepartamento = query.ClaveDepartamento;
                        empleado.Departamento.Descripcion = query.Descripcion;
                        empleado.Sueldo.SueldoMensual = query.SueldoMensual;
                        empleado.Sueldo.FormaPago = query.FormaPago;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al consultar el empleado.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoEmpleadosEntities context = new DL.ESantiagoEmpleadosEntities())
                {
                    int rowsAffected = context.EmpleadoAdd(empleado.ClaveEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.FechaIngreso, empleado.FechaNacimiento, empleado.Departamento.ClaveDepartamento, empleado.Sueldo.SueldoMensual, empleado.Sueldo.FormaPago);
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar el empleado.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoEmpleadosEntities context = new DL.ESantiagoEmpleadosEntities())
                {
                    int rowsAffected = context.EmpleadoUpdate(empleado.ClaveEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.FechaIngreso, empleado.FechaNacimiento, empleado.Departamento.ClaveDepartamento, empleado.Sueldo.SueldoMensual, empleado.Sueldo.FormaPago);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al actualizar el empleado.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(string claveEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoEmpleadosEntities context = new DL.ESantiagoEmpleadosEntities())
                {
                    int rowsAffected = context.EmpleadoDelete(claveEmpleado);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al eliminar el empleado.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
