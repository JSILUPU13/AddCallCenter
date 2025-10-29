using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.Constans;
using Forxap.Framework.Extensions;

namespace Forxap.Banco.UI.Win.DatosMaestros
{
    [FormAttribute(AddonWinForms.frmEspecies, "DatosMaestros/frmEspecies.b1f")]
    class frmEspecies : BaseUDOForm
    {
        public frmEspecies()
        {

        }


        public static void ShowObject(string code)
        {
            SAPbouiCOM.Form activeForm;
            frmEspecies  form = new frmEspecies();
            form.UIAPIRawForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            form.UIAPIRawForm.SetEditText("5", code);
            form.UIAPIRawForm.Items.Item("1").Click();
            form.Show();

            activeForm = Application.SBO_Application.Forms.ActiveForm;
            activeForm.Freeze(true);
           // activeForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            // ahora busco el Code = CONFIG
          ///  activeForm.SetEditText("5", code);
            // ahora le doy click al boton  Buscar 
          ///  activeForm.Items.Item("1").Click();
            activeForm.Freeze(false);
        }
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        
        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;


    }
}
