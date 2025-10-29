using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using System.IO;
using System.Data;
using System.ComponentModel;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;

using Vistony.Distribucion.Win.Formularios;
using Vistony.Distribucion.Win.Asistentes;

using Vistony.Distribucion.BO;
using Vistony.Distribucion.BLL;
using Vistony.Distribucion.Constans;
using System.Threading;
using System.Globalization;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("Vistony.Distribucion.Win.Formularios.udoProductos", "Formularios/udoProductos.b1f")]
    class udoProductos : BaseWizard
    {
        public udoProductos()
        {
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
            EditText1.Value = DateTime.Now.AddMonths(-1).ToString("yyyyMMdd");
            EditText2.Value = DateTime.Now.ToString("yyyyMMdd");


        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText0.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.EditText0_ChooseFromListBefore);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button1.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button1_ChooseFromListAfter);
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText3.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText3_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText3;

        private void EditText3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText0.Value = chooseFromListEvent.SelectedObjects.GetValue("ItemCode", 0).ToString();
                        EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("ItemName", 0).ToString();
                          }
                }

            }
            catch (Exception ex)
            {
                // Sb1Messages.ShowError(string.Format(ex.ToString()), SAPbouiCOM.BoMessageTime.bmt_Short);

            }

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string itemcode = EditText0.Value;
                string fecha1 = EditText1.Value;
                string fecha2 = EditText2.Value;

                if (itemcode == "")
                {
                    Sb1Messages.ShowWarning(AddonMessageInfo.Message104);
                    EditText0.SetFocus();
                    return;
                }

                if (fecha1 == "")
                {
                    Sb1Messages.ShowWarning(AddonMessageInfo.Message104);
                    EditText1.SetFocus();
                    return;
                }

                if (fecha2 == "")
                {
                    Sb1Messages.ShowWarning(AddonMessageInfo.Message104);
                    EditText2.SetFocus();
                    return;
                }

               /* if (Convert.ToDateTime(fecha1) > Convert.ToDateTime(fecha2))
                {
                    Sb1Messages.ShowWarning(AddonMessageInfo.Message105);
                    EditText1.SetFocus();
                    return;
                }*/

                oForm.Freeze(true);
                string Usuario = Sb1Globals.UserName;
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                //int Dias = Convert.ToInt16(EditText0.Value);
                Vistony.Distribucion.DAL.BaseDAL.CallVentaArticulos(ref oDT, Usuario, itemcode, fecha1, fecha2);
                SetFormatGrid();
            }
            catch
            { }
            finally
            {
                oForm.Freeze(false);
            }

        }

        private void SetFormatGrid()
        {

            // Grid0.AssignLineNro();

            //Grid0.Columns.Item("DocEntry").Visible = false;
            //Grid0.Columns.Item("Tipo").Visible = false;
            Grid0.Columns.Item(9).LinkedObjectType(Grid0, "Vendedor", "53");
            Grid0.Columns.Item("CodigoSN").LinkedObjectType(Grid0, "CodigoSN", "2");
            Grid0.Columns.Item("ItemCode").LinkedObjectType(Grid0, "ItemCode", "4");
            Grid0.Columns.Item("CodigoSN").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("NombreSN").TitleObject.Caption = "Nombre SN";




            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = false;
            Grid0.AutoResizeColumns();

            // ampliio el ancho de la columna
            Grid0.RowHeaders.Width += 15;


        }

        private void Button1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            oForm.Close();
        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }
    }
}
