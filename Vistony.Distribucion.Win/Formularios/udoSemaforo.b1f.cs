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
using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("Vistony.Distribucion.Win.Formularios.udoSemaforo", "Formularios/udoSemaforo.b1f")]
    class udoSemaforo : BaseWizard
    {
        public udoSemaforo()
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
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.LoadBefore += new LoadBeforeHandler(this.Form_LoadBefore);

        }

        private SAPbouiCOM.Grid Grid0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();

            string Usuario = "ecolonia";// Sb1Globals.UserName;
            bool Permiso = DAL.BaseDAL.PerfilUsuarioSuper(Usuario);
            Button2.Item.Visible = Permiso;

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
           
        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string Mensaje = AddonMessageInfo.Message100;
                bool Respuesta = Sb1Messages.ShowQuestion(Mensaje);
                if (Respuesta)
                {
                    oForm.Freeze(true);
                    string usuario = "ecolonia";// Sb1Globals.UserName;
                    Thread mythr = new Thread(llamadoSemaforo);
                    mythr.Name = "semaforo";
                    mythr.Start(usuario);
                    mythr.IsBackground = true;
                    
                }
            }
            catch
            { }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void llamadoSemaforo(object usuario)
        {
            Sb1Messages.ShowMessage(AddonMessageInfo.AddWaitMessage);
            //Vistony.Distribucion.DAL.BaseDAL.CallSemaforo(usuario.ToString());
            
            Sb1Messages.ShowMessage(AddonMessageInfo.Message103);
            Sb1Messages.ShowMessageBoxWarning(AddonMessageInfo.Message103);
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                string Usuario = "ecolonia";
                //string Usuario = Sb1Globals.UserName;
                SAPbouiCOM.DataTable dt = oForm.GetDataTable("DT_0");
                dt.Clear();
                oForm.Freeze(true);
                DataBLL.getData(ref dt,Usuario);
                SetFormatGrid();
            }
            catch
            { }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private string NombreMes(int Mes)
        {
            int MesINT = Convert.ToInt16(Mes)-1;
            string MesDEF = DateTime.Now.AddMonths(-MesINT).ToString("MMMM yyyy");
            MesDEF = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(MesDEF);
            return MesDEF;
        }

        private void SetFormatGrid()
        {

            //Grid0.AssignLineNro();
            
            //Grid0.Columns.Item("DocEntry").Visible = false;
            //Grid0.Columns.Item("Tipo").Visible = false;
            Grid0.Columns.Item(0).LinkedObjectType(Grid0, "CODVDE", "53");
            Grid0.Columns.Item("CODCLI").LinkedObjectType(Grid0, "CODCLI", "2");
            Grid0.Columns.Item("CODVDE").TitleObject.Caption = "Código";
            Grid0.Columns.Item("NOMVDE").TitleObject.Caption = "Nombre";
            Grid0.Columns.Item("CODCLI").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("CLIENTE").TitleObject.Caption = "Nombre SN";
            Grid0.Columns.Item("DIRECCION").TitleObject.Caption = "Dirección";
            Grid0.Columns.Item("TELEFONO").TitleObject.Caption = "Teléfono";
            Grid0.Columns.Item("MES_1").TitleObject.Caption = NombreMes(1);
            Grid0.Columns.Item("MES_1").RightJustified = true;
            Grid0.Columns.Item("MES_2").TitleObject.Caption = NombreMes(2);
            Grid0.Columns.Item("MES_2").RightJustified = true;
            Grid0.Columns.Item("MES_3").TitleObject.Caption = NombreMes(3);
            Grid0.Columns.Item("MES_3").RightJustified = true;
            Grid0.Columns.Item("MES_4").TitleObject.Caption = NombreMes(4);
            Grid0.Columns.Item("MES_4").RightJustified = true;
            Grid0.Columns.Item("MES_5").TitleObject.Caption = NombreMes(5);
            Grid0.Columns.Item("MES_5").RightJustified = true;
            Grid0.Columns.Item("MES_6").TitleObject.Caption = NombreMes(6);
            Grid0.Columns.Item("MES_6").RightJustified = true;
            Grid0.Columns.Item("MES_7").TitleObject.Caption = NombreMes(7);
            Grid0.Columns.Item("MES_7").RightJustified = true;
            Grid0.Columns.Item("MES_8").TitleObject.Caption = NombreMes(8);
            Grid0.Columns.Item("MES_8").RightJustified = true;
            Grid0.Columns.Item("MES_9").TitleObject.Caption = NombreMes(9);
            Grid0.Columns.Item("MES_9").RightJustified = true;
            Grid0.Columns.Item("MES_10").TitleObject.Caption = NombreMes(10);
            Grid0.Columns.Item("MES_10").RightJustified = true;
            Grid0.Columns.Item("MES_11").TitleObject.Caption = NombreMes(11);
            Grid0.Columns.Item("MES_11").RightJustified = true;
            Grid0.Columns.Item("MES_12").TitleObject.Caption = NombreMes(12);
            Grid0.Columns.Item("MES_12").RightJustified = true;

            Grid0.Columns.Item("VIS_DISTRITO").TitleObject.Caption = "Distrito";
            Grid0.Columns.Item("VIS_DEPARTAMENTO").TitleObject.Caption = "Departamento";
            Grid0.Columns.Item("VIS_PROVINCIA").TitleObject.Caption = "Provincia";
            
            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = false;
            Grid0.AutoResizeColumns();

            // ampliio el ancho de la columna
            Grid0.RowHeaders.Width += 15;
        }

        private void Form_LoadBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            string Usuario = "ecolonia";// Sb1Globals.UserName;
            bool Permiso = DAL.BaseDAL.TienePermisoSemaforo(Usuario);
            if (!Permiso)
            {
                Sb1Messages.ShowMessage(AddonMessageInfo.Message101);
            }

            BubbleEvent = Permiso;
            //throw new System.NotImplementedException();

        }

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }
    }
}
