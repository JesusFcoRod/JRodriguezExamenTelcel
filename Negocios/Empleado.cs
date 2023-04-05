using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public Negocios.Puesto Puesto { get; set; }
        public Negocios.Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }

        public static Negocios.Result Add(Negocios.Empleado empleado)
        {
            Negocios.Result result = new Negocios.Result();

            try
            {
                using (AccesoDatos.JRodriguezExamenPracticoTelcelEntities contex = new AccesoDatos.JRodriguezExamenPracticoTelcelEntities())
                {
                    var query = contex.EmpleadoAdd(empleado.Nombre, empleado.Puesto.IdPuesto, empleado.Departamento.DepartamentoID);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Negocios.Result GetAll(Negocios.Empleado empleado)
        {
            Negocios.Result result = new Negocios.Result();

            try
            {
                using (AccesoDatos.JRodriguezExamenPracticoTelcelEntities contex = new AccesoDatos.JRodriguezExamenPracticoTelcelEntities())
                {
                    if (empleado.Nombre == null)
                    {
                        empleado.Nombre = "";
                    }
                    var query = contex.EmpleadoGetAll(empleado.Nombre).ToList();
                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        Negocios.Empleado empleadoItem = new Negocios.Empleado();
                        empleadoItem.EmpleadoID = item.EmpleadoID;
                        empleadoItem.Nombre = item.Nombre;

                        empleadoItem.Puesto = new Negocios.Puesto();
                        empleadoItem.Puesto.IdPuesto = item.IdPuesto;
                        empleadoItem.Puesto.Descripcion = item.Puesto;

                        empleadoItem.Departamento = new Negocios.Departamento();
                        empleadoItem.Departamento.DepartamentoID = item.DepartamentoID;
                        empleadoItem.Departamento.Descripcion = item.Departamento;

                        result.Objects.Add(empleadoItem);
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Negocios.Result Delete(int EmpleadoID)
        {
            Negocios.Result result = new Negocios.Result();

            try
            {
                using (AccesoDatos.JRodriguezExamenPracticoTelcelEntities contex = new AccesoDatos.JRodriguezExamenPracticoTelcelEntities())
                {
                    var query = contex.EmpleadoDelete(EmpleadoID);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
