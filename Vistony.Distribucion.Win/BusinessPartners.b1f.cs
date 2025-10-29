using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.DAL;
using Forxap.Framework.UI;

using Vistony.Distribucion.Win;
using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.Win
{
    [FormAttribute("134", "BusinessPartners.b1f")]
    class BusinessPartners : SystemFormBase
    {
        public BusinessPartners()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.txtcliente = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.txttelefono1 = ((SAPbouiCOM.EditText)(this.GetItem("43").Specific));
            this.txttelefono2 = ((SAPbouiCOM.EditText)(this.GetItem("45").Specific));
            this.txttelefono3 = ((SAPbouiCOM.EditText)(this.GetItem("51").Specific));
            //  this.datatabla = ((SAPbouiCOM.DataTable)(this.GetItem("DT_0").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private SAPbouiCOM.Button Button0;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {

            string Cliente = txtcliente.Value;
            string Telefono1 = txttelefono1.Value;
            string Telefono2 = txttelefono2.Value;
            string Celular = txttelefono3.Value;

            Dictionary<string, string> listObject;
            listObject = BaseDAL.ListarClientesExistencias(Cliente, Telefono1, Telefono2, Celular);
            //this.

            if (listObject.Count > 0)
            {
                BubbleEvent = false;
                string DatosCliente = "";
                foreach (var item in listObject)
                {
                    DatosCliente = DatosCliente + item.Key + " - " + item.Value; ;
                }

                Sb1Messages.ShowMessageBoxWarning("Existe otro cliente con el mismo teléfono: " + DatosCliente);
            }
            else
            {
                BubbleEvent = true;
            }

            
           // throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            //oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
        }
        private SAPbouiCOM.EditText txtcliente;
        private SAPbouiCOM.EditText txttelefono1;
        private SAPbouiCOM.EditText txttelefono2;
        private SAPbouiCOM.EditText txttelefono3;
        private SAPbouiCOM.DataTable datatabla;


        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {




        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }
    }
}
