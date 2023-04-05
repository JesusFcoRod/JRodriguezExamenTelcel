using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Departamentos { get; set; }

        public static Negocios.Result GetAll()
        {
            Negocios.Result result = new Negocios.Result();

            try
            {
                using (AccesoDatos.JRodriguezExamenPracticoTelcelEntities contex = new AccesoDatos.JRodriguezExamenPracticoTelcelEntities())
                {
                    var query = contex.DepartamentoGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        Negocios.Departamento departamento = new Negocios.Departamento();
                        departamento.DepartamentoID = item.DepartamentoID;
                        departamento.Descripcion = item.Descripcion;

                        result.Objects.Add(departamento);
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
    }
}
