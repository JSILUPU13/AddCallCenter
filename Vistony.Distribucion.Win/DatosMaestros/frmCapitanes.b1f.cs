using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.Distribucion.Constans;
using Vistony.Distribucion.Win;

namespace Forxap.Banco.UI.Win.DatosMaestros
{
    [FormAttribute(AddonWinForms.frmCapitanes, "DatosMaestros/frmCapitanes.b1f")]
    class frmCapitanes : BaseUDOForm
    {
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText txtKey;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.LinkedButton LinkedButton0;
       
        public frmCapitanes()
        {
        }

        public static void  ShowObject( string code)
        {
            SAPbouiCOM.Form activeForm;
            frmCapitanes form = new frmCapitanes();
            //form.UIAPIRawForm
            form.Show();

            activeForm = Application.SBO_Application.Forms.ActiveForm;
            activeForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            // ahora busco el Code = CONFIG
            activeForm.SetEditText("5",code);
            // ahora le doy click al boton  Buscar 
            activeForm.Items.Item("1").Click();

            

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.btnOK = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("4").Specific));
            this.txtKey = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_6").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LayoutKeyBefore += new LayoutKeyBeforeHandler(this.Form_LayoutKeyBefore);

        }

 

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ReportType = "CTR2";// LayoutForms.frmCapitanes;
        }

        private void Form_LayoutKeyBefore(ref SAPbouiCOM.LayoutKeyInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                eventInfo.LayoutKey = oForm.GetString("5");
            }
            catch (Exception ex)
            {
                BubbleEvent = false;
                // debo trabajar las excepciones y escribirlo en un log
            }

        }



        private void imprimirFormato(int docEntry, string layoutId = "PKG10011")
        {
            try
            {
                SAPbobsCOM.CompanyService oCompanyService = Sb1Globals.oCompany.GetCompanyService();
                SAPbobsCOM.ReportLayoutsService oReportLayoutService = (SAPbobsCOM.ReportLayoutsService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportLayoutsService);
                SAPbobsCOM.ReportLayoutPrintParams oPrintParam = (SAPbobsCOM.ReportLayoutPrintParams)oReportLayoutService.GetDataInterface(SAPbobsCOM.ReportLayoutsServiceDataInterfaces.rlsdiReportLayoutPrintParams);

                oPrintParam.LayoutCode = layoutId; //codigo del formato importado en SAP
                oPrintParam.DocEntry = docEntry; //parametro que se envia al crystal, DocEntry de la transaccion

                oReportLayoutService.Print(oPrintParam);

            }
            catch (Exception ex)
            {
            //    StackTrace stackTrace = new StackTrace();
              //  gestionarExcepcion(ex, stackTrace);
            }
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText4;
     
    }
}
