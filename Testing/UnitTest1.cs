using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DepartamentoGetAll()
        {
            ML.Result result = BL.Departamento.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
        [TestMethod]
        public void EmpleadoGetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
        [TestMethod]
        public void EmpleadoGetByClaveEmpleado()
        {
            ML.Result result = BL.Empleado.GetByClaveEmpleado("CDB827");
            Assert.IsNotNull(result.Object);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
    }
}
