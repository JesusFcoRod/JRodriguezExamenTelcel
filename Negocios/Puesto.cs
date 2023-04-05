using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Puesto
    {
        public int IdPuesto { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }

        public static Negocios.Result GetAll()
        {
            Negocios.Result result = new Negocios.Result();

            try
            {
                using (AccesoDatos.JRodriguezExamenPracticoTelcelEntities contex = new AccesoDatos.JRodriguezExamenPracticoTelcelEntities())
                {
                    var query = contex.PuestoGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        Negocios.Puesto puesto = new Negocios.Puesto();
                        puesto.IdPuesto = item.IdPuesto;
                        puesto.Descripcion = item.Descripcion;

                        result.Objects.Add(puesto);
                    }
                    result.Correct = true;
                }

            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
