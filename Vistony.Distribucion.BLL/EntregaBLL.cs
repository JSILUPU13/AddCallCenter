using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.BLL
{
    public class EntregaBLL : IDisposable
    {
        public SAPbouiCOM.DataTable GetEntrega(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string userName)
        {
            try
            {
                using (EntregaDAL  entregaDAL = new EntregaDAL()  )
                {
                  return    entregaDAL.Entrega(ref oDT, startDate, endDate, consolidado, agencia, userName);
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  bool UpdateEstadoEntrega(string docEntry, dynamic jsonData, ref  string  response )
        {

            bool ret = false;

            try
            {
                using (EntregaDAL entregaDAL = new EntregaDAL())
                {
                    ret = entregaDAL.UpdateEstadoEntrega(docEntry,jsonData, ref response);
                }

            }
            catch (Exception ex)
            {
                ex.Source.ToString();
            }

          
           
                return ret;
          
        }

        public  SAPbouiCOM.DataTable ListPrevDespacho( string startDate, string endDate, string usuario, string chofer, ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
               return  entregaDAL.ListPrevDespacho( startDate, endDate, usuario, chofer, ref oDT);
            }

            
        }

        public SAPbouiCOM.DataTable ListPrevDespachoEdit(string startDate, string endDate, string usuario, string chofer, ref SAPbouiCOM.DataTable oDT)
        {
            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ListPrevDespachoEdit(ref oDT, startDate, endDate, usuario, chofer );
            }
            
        }
        public  string ObtenerSucursal(SAPbouiCOM.DataTable oDT, string usuario)
        {

            using (EntregaDAL entregaDAL = new EntregaDAL())
            {
                return entregaDAL.ObtenerSucursal(oDT, usuario);
            }
        }


        #region Disposable



        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~EntregaBLL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion


    }// fin de la clase


}// fin del namespace
