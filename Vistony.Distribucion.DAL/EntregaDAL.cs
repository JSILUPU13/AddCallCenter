using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SAPbobsCOM;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Newtonsoft.Json;
using RestSharp;


namespace Vistony.Distribucion.DAL
{
    public class EntregaDAL : IDisposable
    {
        public  SAPbouiCOM.DataTable Entrega(ref SAPbouiCOM.DataTable oDT, string startDate, string endDate, string consolidado, string agencia, string userName)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_SEARCHOPERATIONS ('{0}','{1}','{2}','{3}','{4}')", startDate, endDate, consolidado, agencia, userName);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  SAPbouiCOM.DataTable ListPrevDespacho( string startDate, string endDate, string usuario, string chofer, ref SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_LISTPREVASIG ('{0}','{1}','{2}','{3}')", startDate, endDate,  usuario,chofer);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  SAPbouiCOM.DataTable ListPrevDespachoEdit(ref SAPbouiCOM.DataTable oDT, string Desde, string Hasta, string Usuario, string chofer)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_LISTPREVASIG_EDIT ('{0}','{1}','{2}','{3}')", Desde, Hasta, Usuario, chofer);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SAPbouiCOM.DataTable ListPrevDespacho(SAPbouiCOM.DataTable oDT, string Desde, string Hasta, string Usuario, string chofer, int dia)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_LISTPREVASIG ('{0}','{1}','{2}','{3}')", Desde, Hasta, Usuario, chofer);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SAPbouiCOM.DataTable BuscarDespachos(SAPbouiCOM.DataTable oDT, string usuario, string licencia, string fecha, string estado)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_OBTENER_DESPACHOS ('{0}','{1}','{2}','{3}')", usuario, licencia,fecha,estado);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool GrabarHistorial(dynamic jsonData, out string respuesta)
        {
            bool procesoOK;
            try
            {

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("HISTDESPA",  jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    respuesta = "OK";
                    procesoOK = true;
                }
                else
                {
                    respuesta = response.Content.ToString();
                    procesoOK = true;
                }


                return procesoOK;
            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();
                return false;
            }

        }

        public static bool GrabarHistorialCabecera(dynamic jsonData, out string respuesta)
        {
            bool procesoOK;
            try
            {

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic response;
                response = methods.POST("VIS_HIST_DESP_C", jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                if (response.StatusCode.ToString() == "Created")
                {
                    respuesta = "OK";
                    procesoOK = true;
                }
                else
                {
                    respuesta = response.Content.ToString();
                    procesoOK = true;
                }


                return procesoOK;
            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();
                return false;
            }

        }

        public  string ObtenerSucursal(SAPbouiCOM.DataTable oDT, string Usuario)
        {
            string sucursal = string.Empty;
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_OBTENERSUCUSU ('{0}')", Usuario);
                oDT.ExecuteQuery(sSTRSQL);

                if (oDT.Rows.Count > 0)
                {
                    sucursal = oDT.GetString("DATO", 0).ToString();
                }

                return sucursal;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public static String ObtenerCorrelativoDespacho(SAPbouiCOM.DataTable oDT, string Fecha)
        {
            string Sucursal = "";
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_CORR_DESPACHO ('{0}')", Fecha);
                oDT.ExecuteQuery(sSTRSQL);
                Sucursal = oDT.GetString("DATO", 0).ToString();
                return Sucursal;
            }
            catch (Exception ex)
            {
                return null;
            }


        }


        public static int EstadoEntregaVAL(SAPbouiCOM.DataTable oDT, string DocNum)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_DIS_STATEDELIVERY ('{0}')",DocNum);
                //oRecordSet.DoQuery(sSTRSQL);
                oDT.ExecuteQuery(sSTRSQL);
                int filas = 0;
                filas = Convert.ToInt16(oDT.GetValue(0, 0));
                return filas;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }


        public  bool UpdateEstadoEntrega(string docEntry, dynamic jsonData, ref  string response)
        {
            bool ret = false;
            try
            {

                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                dynamic restResponse;
                restResponse = methods.PATCH("DeliveryNotes", Convert.ToInt32(docEntry), jsonData);
                dynamic json2 = JsonConvert.DeserializeObject(restResponse.Content.ToString());

                if (restResponse.StatusCode.ToString() == "" || restResponse.StatusCode.ToString() == "NoContent")
                {
                    response = "OK";
                    ret = true;
                }
                else
                {
                    response = restResponse.Content.ToString();
                    ret = true;
                }


                return ret;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return false;
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
        ~EntregaDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }// fin de la clase

}// fin del namespace
