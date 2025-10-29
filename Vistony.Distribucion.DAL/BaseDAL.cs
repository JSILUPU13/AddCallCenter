using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.DAL
{
    public class BaseDAL
    {

       public static SAPbobsCOM.Company oCompany;
       private static SAPbouiCOM.Application oApplication;
       

       public static bool SetDataAccesLayer(SAPbouiCOM.Application application, SAPbobsCOM.Company company)
       {
           bool ret = false;
           try
           {
               oApplication = application;
               oCompany = company;
               ret = true;
           }
           catch (Exception exception)        /// <summary>
           {

               throw;
           }
           ;

           return ret;
       }

        public static Dictionary<string, string> ListarClientesExistencias(string Cliente, 
            string Telefono1, string Telefono2, string Celular)
        {
           // SAPbobsCOM.Recordset oRecordSet = new SAPbobsCOM.Recordset();

            try
            {
                Dictionary<string, string> listObject = new Dictionary<string, string>();
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sSTRSQL = String.Format("CALL P_VIS_CALL_BUSCARCLIENTE ('{0}','{1}','{2}','{3}')", Cliente, Telefono1, Telefono2, Celular);
                oRecordSet.DoQuery(sSTRSQL);

                while (!oRecordSet.EoF)
                {
                    if (oRecordSet.Fields.Item(0).Value.ToString().Trim().Length > 0)
                        listObject.Add(oRecordSet.Fields.Item(0).Value.ToString().Trim(), oRecordSet.Fields.Item(1).Value.ToString().Trim());
                    oRecordSet.MoveNext();
                }


                return listObject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         
        public static SAPbouiCOM.DataTable SemaforoSelect(SAPbouiCOM.DataTable oDT, string usuario)
        {
            try
            {
                string sSTRSQL = String.Format("CALL P_VIST_CALL_CLIENTES_SATENCION ('{0}')", usuario);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void CallSemaforo(ref SAPbouiCOM.DataTable oDT,string Usuario)
        {
            try
            {
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                SAPbobsCOM.Recordset oRecordSet1 = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                //SAPbouiCOM.DataTable odt = new SAPbouiCOM.DataTable();
                //string sSTRSQL = String.Format("CALL P_VIST_CALL_SEMAFORO_WORK_AGENTE ('{0}')", Usuario);
                string sSTRSQL = String.Format("CALL P_VIST_CALL_SEMAFORO_WORK_NEW_WALTER()");
                //oRecordSet.DoQuery(sSTRSQL);
                oDT.ExecuteQuery(sSTRSQL);
            }
            
            catch (Exception ex)
            {

            }


        }

        public static bool  ActualizarSemaforo(string Usuario, string Cliente, string Direccion)
        {
            try
            {
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sSTRSQL = String.Format("CALL P_VIST_CALL_SEMAFORO_WORK_PASO2 ('{0}', '{1}','{2}')", Usuario,Cliente,Direccion);
                oRecordSet.DoQuery(sSTRSQL);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }


        }



        public static SAPbouiCOM.DataTable CallClientesSAtencion(ref SAPbouiCOM.DataTable oDT, string Usuario,int Dias)
        {
            try
            {
                string sSTRSQL = String.Format("CALL P_VIST_CALL_CLIENTES_SATENCION ('{0}','{1}')", Usuario, Dias);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string CallAccessUser(string Usuario)
        {
            try
            {
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sSTRSQL = String.Format("CALL SP_VIS_CALL_USERCDR ('{0}')", Usuario);
                oRecordSet.DoQuery(sSTRSQL);
                string Permiso = oRecordSet.Fields.Item(0).Value.ToString();
                return Permiso;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SAPbouiCOM.DataTable CallVentaArticulos(ref SAPbouiCOM.DataTable oDT, string Usuario, 
            string Item, string fecha1, string fecha2)
        {
            try
            {
                string sSTRSQL = String.Format("CALL P_VIST_CALL_PRODUCTOS_ATENCION_V2 ('{0}','{1}', '{2}','{3}')", Usuario, Item,fecha1,fecha2);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SAPbouiCOM.DataTable CallLlamadasPBX(string extension, string fecha1, string fecha2, string Usuario, ref SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string sSTRSQL = String.Format("CALL SP_VIS_CALL_CENTRAL ('{0}','{1}','{2}','{3}')",extension,fecha1, fecha2, Usuario);
                oDT.ExecuteQuery(sSTRSQL);
                return oDT;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool TienePermisoSemaforo(string Usuario)
        {
            try
            {
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sSTRSQL = String.Format("CALL SP_VIS_CALL_VALIDAUSUARIO ('{0}')",Usuario);
                oRecordSet.DoQuery(sSTRSQL);
                string Permiso = oRecordSet.Fields.Item(0).Value.ToString();
                if (Permiso == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PerfilUsuarioSuper(string Usuario)
        {
            try
            {
                SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sSTRSQL = String.Format("CALL SP_VIS_CALL_VALIDAPERFILUSUARIO ('{0}')", Usuario);
                oRecordSet.DoQuery(sSTRSQL);
                string Permiso = oRecordSet.Fields.Item(0).Value.ToString();
                if (Permiso == "83")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
