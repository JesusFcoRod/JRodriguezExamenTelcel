using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Negocios.Departamento departamento = new Negocios.Departamento();
            Negocios.Result resultDep = Negocios.Departamento.GetAll();

            Negocios.Puesto puesto = new Negocios.Puesto();
            Negocios.Result resultPues = Negocios.Puesto.GetAll();



            Negocios.Empleado empleado = new Negocios.Empleado();
            Negocios.Result result = Negocios.Empleado.GetAll(empleado);
            empleado.Empleados = result.Objects;


            empleado.Departamento = new Negocios.Departamento();
            empleado.Departamento.Departamentos = resultDep.Objects;

            empleado.Puesto = new Negocios.Puesto();
            empleado.Puesto.Puestos = resultPues.Objects;

            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(Negocios.Empleado empleado)
        {
            Negocios.Departamento departamento = new Negocios.Departamento();
            Negocios.Result resultDep = Negocios.Departamento.GetAll();

            Negocios.Puesto puesto = new Negocios.Puesto();
            Negocios.Result resultPues = Negocios.Puesto.GetAll();


            Negocios.Result result = Negocios.Empleado.GetAll(empleado);
            empleado.Empleados = result.Objects;

            empleado.Departamento = new Negocios.Departamento();
            empleado.Departamento.Departamentos = resultDep.Objects;

            empleado.Puesto = new Negocios.Puesto();
            empleado.Puesto.Puestos = resultPues.Objects;


            return View(empleado);
        }

        [HttpPost]
        public ActionResult AddEmpleado(Negocios.Empleado empleado)
        {
            Negocios.Result result = new Negocios.Result();

            if (empleado.EmpleadoID > 0)
            {
                //UPDATE
            }
            else
            {
                result = Negocios.Empleado.Add(empleado);
                ViewBag.Message = "Empleado registrado con exito";
            }

            
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
            
        }

        public ActionResult Delete(int idEmpleado)
        {
            Negocios.Result result = Negocios.Empleado.Delete(idEmpleado);

            if (result.Correct)
            {
                ViewBag.Message = "EMPLEADO ELIMINADO";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "ERROR AL ELIMINAR EL EMPLEADO";
                return PartialView("Modal");
            }
        }
    }
}