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
    [FormAttribute("Vistony.Distribucion.Win.Formularios.AtencionClientes", "Formularios/AtencionClientes.b1f")]
    class AtencionClientes : BaseWizard
    {
        public AtencionClientes()
        {
            oForm.State = SAPbouiCOM.BoFormStateEnum.fs_Maximized;
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.Grid Grid0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            oForm.Close();
        }

        private void llamadahilo()
        {
            string Usuario = Sb1Globals.UserName;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            int Dias = Convert.ToInt16(EditText0.Value);
            Vistony.Distribucion.DAL.BaseDAL.CallClientesSAtencion(ref oDT,Usuario, Dias);
            SetFormatGrid();
        }



        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                    if (EditText0.Value== "")
                        {
                            Sb1Messages.ShowError(AddonMessageInfo.Message102);
                            EditText0.SetFocus();
                            return;
                        }
                
                    oForm.Freeze(true);
                    Thread mythr = new Thread(llamadahilo);
                    mythr.Name = "semaforo";
                    mythr.Start();
                    mythr.IsBackground = true;
                    //Button0.Item.Click();
               
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
            Grid0.Columns.Item(9).LinkedObjectType(Grid0, "CodigoVendedor", "53");
            Grid0.Columns.Item("CodigoSN").LinkedObjectType(Grid0, "CodigoSN", "2");
            Grid0.Columns.Item("CodigoSN").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("NombreSN").TitleObject.Caption = "Nombre SN";




            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = false;
            Grid0.AutoResizeColumns();

            // ampliio el ancho de la columna
            Grid0.RowHeaders.Width += 15;


        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }
    }
}
