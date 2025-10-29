using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using SAPbobsCOM;
using Forxap.Framework.Extensions;


using Forxap.Framework.Extensions;
using Vistony.Distribucion.Win;
using Vistony.Distribucion.BLL;

namespace Vistony.Distribucion.Win
{
    public class Utils
    {

        public static void LoadQueryDynamic(ref SAPbouiCOM.ComboBox oComboBox, string Query)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.ValidValues.GetQueryCombos(Query);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }
                oComboBox.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
                // oComboBox.Item.DisplayDesc = true;
            }

        }



        /// <summary>
        /// /
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableName"></param>
        public static void LoadMiscelaneo(ref SAPbouiCOM.ComboBox oComboBox, string tableName)
        {

            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.Sb1Users.GetListFromUDT(tableName);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }


            }
        }

        /// Carga un combobox dentro de una grilla 
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadMiscelaneo(ref SAPbouiCOM.Column oColumn, string tableName)
        {
            Dictionary<string, string> listObject;
            if (oColumn != null)
            {
                if (oColumn.Type == SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX)
                {


                    listObject = Forxap.Framework.DI.Sb1Users.GetListFromUDT(tableName);
                    foreach (var item in listObject)
                    {
                        oColumn.ValidValues.Add(item.Key, item.Value);
                    }
                }
            }

        }



       
        public static bool findDataTable(SAPbouiCOM.DataTable datatable, string numeroPedido, string lineaPedido)
        {
            bool ret = false;

            string nroPedido = string.Empty;
            string linea = string.Empty;

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                nroPedido = datatable.GetValue("DocEntry", i).ToString();
                linea = datatable.GetValue("Lin", i).ToString();

                if ((numeroPedido == nroPedido) && (lineaPedido == linea))
                {
                    ret = true;
                }
            }


            return ret;
        }




        public static bool InitConfig()
        {
            SAPbobsCOM.Recordset recordSet = null;
            string code = string.Empty;
            bool ret = false;


            recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {

                string strSQL = "''";

                strSQL = string.Format("Select  \"Code\" From \"@FXP_DEMO_OADM\" where \"Code\" = 'CONFIG'  ");

                recordSet.DoQuery(strSQL);


                code = recordSet.Fields.Item("Code").Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }

            // si no existe el registro de la configuración lo debo agregar
            if (code.Length == 0)
            {

                SAPbobsCOM.GeneralService oGeneralService = null;
                SAPbobsCOM.GeneralData oGeneralData = null;
                SAPbobsCOM.GeneralData oChild = null;
                SAPbobsCOM.GeneralDataCollection oChildren = null;
                SAPbobsCOM.GeneralDataParams oGeneralParams = null;


                oGeneralService = Sb1Globals.oCompanyService.GetGeneralService("FXP_DEMO_OADM");


                oGeneralParams = ((SAPbobsCOM.GeneralDataParams)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams)));


                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);

                //     oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                oGeneralData.SetProperty("Code", "CONFIG");



                oGeneralService.Add(oGeneralData);




                //Specify data for main UDO






                //

            }
            else
            {
                ret = true;
            }

            return ret;
        }



        /// <summary>
        /// asigna el numero de registro dentro del Grid en la primera columna pone la númeracion
        /// verifica ´primero que existan registros
        /// </summary>
        /// <param name="oGrid"></param>
        /// <param name="oForm"></param>
        public static int AssignLineNro(ref SAPbouiCOM.Form oForm, ref SAPbouiCOM.Grid oGrid , ref double? totalWeight)
        {
            //SAPbouiCOM.Form oForm = oApplication.Forms.ActiveForm;
           
            int rowIndex = 0;
           

            if (oGrid == null)
                throw new ArgumentNullException("oGrid");


            try
            {


                oForm.Freeze(true);




                if (!oGrid.DataTable.IsEmpty)
                {

                    for (rowIndex = 0; rowIndex <= oGrid.DataTable.Rows.Count - 1; rowIndex++)
                    {
                        oGrid.Columns.Item("RowsHeader").TitleObject.Caption = "#";
                        oGrid.RowHeaders.SetText(rowIndex , (rowIndex + 1 ).ToString());
                       
                        totalWeight += oGrid.DataTable.GetDouble("Peso", rowIndex);
                    }
                }

                
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }

            finally
            {
                oForm.Freeze(false);
            }
            // retorna el número de documentos seleccionados
            return rowIndex ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oForm"></param>
        /// <param name="oGrid"></param>
        /// <param name="totalWeight"></param>
        /// <param name="rowsSelected"></param>
        /// <returns></returns>
        public static int CheckRows( SAPbouiCOM.Form oForm,  SAPbouiCOM.Grid oGrid, ref double? totalWeight, ref int rowsSelected )
        {
            
            int rowIndex = 0;
            string newValue = "N";
            string oldValue = "Y";

            if (oGrid == null)
                throw new ArgumentNullException("oGrid");


            try
            {


                oForm.Freeze(true);




                if (!oGrid.DataTable.IsEmpty)
                {

                    for (rowIndex = 0; rowIndex <= oGrid.DataTable.Rows.Count - 1; rowIndex++)
                    {
                        // obtengo el valor si esta checkeado o no 
                        oldValue = oGrid.DataTable.GetString("Marca", rowIndex);

                        if (oldValue == "Y")
                        {
                            newValue = "N";
                            // obtengo el peso total del documento y le resto al total
                            totalWeight -= oGrid.DataTable.GetDouble("Peso", rowIndex);
                        }
                        else
                        {
                            newValue = "Y";
                            // obtengo el peso total del documento y le resto al total
                            totalWeight += oGrid.DataTable.GetDouble("Peso", rowIndex);
                        }

                        oGrid.DataTable.SetValue("Marca", rowIndex, newValue);

                        

                      
                    }
                }


            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }

            finally
            {
                oForm.Freeze(false);
            }

            return rowIndex;
        }


        public static string GetSucursal(SAPbouiCOM.DataTable oDT, string usuario )
        {


            using (EntregaBLL entregaBLL = new EntregaBLL())
            {
                return entregaBLL.ObtenerSucursal(oDT, usuario);
            }
        }

    }// fin de la clase

}// fin del namespace
