using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFService.Model;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public int codeResult;
       
        IEnumerable<ROL> IService1.GetRolbyId(int id)
        {
            try
            {
                using (var context = new Model.BANKEntities())
                {
                    var rol = new int[] { id };
                    return context.ROL.OrderBy(p => p.id).ToList().Where(p => rol.Contains(p.id)).Select(p => new ROL() { id = p.id, rol1 = p.rol1 });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
