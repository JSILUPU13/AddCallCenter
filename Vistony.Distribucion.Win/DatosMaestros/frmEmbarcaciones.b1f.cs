using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Forxap.Banco.UI.Win;
using Forxap.Framework.Constants;
using Forxap.Banco.UI.Constans;
using Forxap.Banco.UI.Win;
using Forxap.Framework.UI;

namespace Forxap.Banco.UI.Win.DatosMaestros
{
    [FormAttribute(AddonWinForms.frmEmbarcaciones, "DatosMaestros/frmEmbarcaciones.b1f")]
    class frmEmbarcaciones : BaseUDOForm     
    {
        private SAPbouiCOM.Column oColumn = null;
         
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.LinkedButton LinkedButton3;
        private SAPbouiCOM.Folder fld01;
        private SAPbouiCOM.Folder fld02;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Matrix Matrix2;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox ComboBox1;
        public frmEmbarcaciones()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.btnOK = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("4").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_2").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_13").Specific));
            this.LinkedButton3 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_14").Specific));
            this.LinkedButton3.ClickAfter += new SAPbouiCOM._ILinkedButtonEvents_ClickAfterEventHandler(this.LinkedButton3_ClickAfter);
            this.fld01 = ((SAPbouiCOM.Folder)(this.GetItem("Item_16").Specific));
            this.fld01.DoubleClickBefore += new SAPbouiCOM._IFolderEvents_DoubleClickBeforeEventHandler(this.Folder0_DoubleClickBefore);
            this.fld01.PressedBefore += new SAPbouiCOM._IFolderEvents_PressedBeforeEventHandler(this.Folder0_PressedBefore);
            this.fld01.ClickBefore += new SAPbouiCOM._IFolderEvents_ClickBeforeEventHandler(this.Folder0_ClickBefore);
            this.fld01.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.Folder0_ClickAfter);
            this.fld01.Select();
            this.fld02 = ((SAPbouiCOM.Folder)(this.GetItem("Item_17").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_8").Specific));
            this.Matrix1.ValidateBefore += new SAPbouiCOM._IMatrixEvents_ValidateBeforeEventHandler(this.Matrix1_ValidateBefore);
            this.Matrix1.DatasourceLoadAfter += new SAPbouiCOM._IMatrixEvents_DatasourceLoadAfterEventHandler(this.Matrix1_DatasourceLoadAfter);
            this.Matrix1.KeyDownAfter += new SAPbouiCOM._IMatrixEvents_KeyDownAfterEventHandler(this.Matrix1_KeyDownAfter);
            this.Matrix1.PickerClickedBefore += new SAPbouiCOM._IMatrixEvents_PickerClickedBeforeEventHandler(this.Matrix1_PickerClickedBefore);
            this.Matrix1.CollapsePressedAfter += new SAPbouiCOM._IMatrixEvents_CollapsePressedAfterEventHandler(this.Matrix1_CollapsePressedAfter);
            this.Matrix1.ClickAfter += new SAPbouiCOM._IMatrixEvents_ClickAfterEventHandler(this.Matrix1_ClickAfter);
            this.Matrix1.PressedAfter += new SAPbouiCOM._IMatrixEvents_PressedAfterEventHandler(this.Matrix1_PressedAfter);
            this.Matrix1.MatrixLoadAfter += new SAPbouiCOM._IMatrixEvents_MatrixLoadAfterEventHandler(this.Matrix1_MatrixLoadAfter);
            this.Matrix1.LinkPressedBefore += new SAPbouiCOM._IMatrixEvents_LinkPressedBeforeEventHandler(this.Matrix1_LinkPressedBefore);
            this.Matrix1.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix1_ChooseFromListAfter);
            this.Matrix1.DoubleClickBefore += new SAPbouiCOM._IMatrixEvents_DoubleClickBeforeEventHandler(this.Matrix1_DoubleClickBefore);
            this.Matrix1.PressedBefore += new SAPbouiCOM._IMatrixEvents_PressedBeforeEventHandler(this.Matrix1_PressedBefore);
            this.Matrix1.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.Matrix1_LostFocusAfter);
            this.Matrix1.GotFocusAfter += new SAPbouiCOM._IMatrixEvents_GotFocusAfterEventHandler(this.Matrix1_GotFocusAfter);
            this.Matrix1.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix1_ClickBefore);
            this.Matrix2 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_9").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_18").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.ClickAfter += new SAPbouiCOM.Framework.FormBase.ClickAfterHandler(this.Form_ClickAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickAfter += new SAPbouiCOM.Framework.FormBase.RightClickAfterHandler(this.Form_RightClickAfter);
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DeactivateBefore += new SAPbouiCOM.Framework.FormBase.DeactivateBeforeHandler(this.Form_DeactivateBefore);
            this.VisibleAfter += new SAPbouiCOM.Framework.FormBase.VisibleAfterHandler(this.Form_VisibleAfter);
            this.ClickBefore += new ClickBeforeHandler(this.Form_ClickBefore);

        }

       
        private void OnCustomInitialize()
        {
          
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.EnabledMenuMatrix();
            oForm.GetSupplier("CFL_2");
            Utils.LoadMiscelaneo(ref ComboBox0,AddonUserTables.TipoEmbarcacion);
            Utils.LoadMiscelaneo(ref ComboBox1, AddonUserTables.Toneladas);
            Matrix1.AddRow(1);
            Matrix2.AddRow(1);

        
            oColumn =  Matrix1.Columns.Item("Col_0");
            Utils.LoadMiscelaneo(ref oColumn, AddonUserTables.TipoPesca);


            oColumn = Matrix2.Columns.Item("Col_0");
            Utils.LoadMiscelaneo(ref oColumn, AddonUserTables.AparejosPesca);


         //   Matrix1.AssignLineNro();
            Matrix2.AssignLineNro();

            
            
        }

        /// <summary>
        ///  Valida regla de negocio para este formulario
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            bool ret = true;
            // regla debo obtener los años de fabricación

            return ret;
            
        }

        private void LinkedButton0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            frmCapitanes.ShowObject(EditText3.GetString().Trim());
        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {


        }




        private void LinkedButton3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
             frmCapitanes.ShowObject(EditText3.GetString());
        }

        public static void ShowObject(string code)
        {
            SAPbouiCOM.Form activeForm;
            frmEmbarcaciones   form = new frmEmbarcaciones();
            
            form.Show();

            activeForm = Application.SBO_Application.Forms.ActiveForm;
            activeForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            // ahora busco el Code = CONFIG
            activeForm.SetEditText("5", code);
            // ahora le doy click al boton  Buscar 
            activeForm.Items.Item("1").Click();

        }



        //public static void MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        //{
        //    BubbleEvent = true;


        //    // Menu Agregar Linea en el matrix
        //    if (pVal.MenuUID == SboMenuItem.mnuAdd_Row && pVal.BeforeAction == true)
        //    {
        //        //AddRow();
        //    }
        //    // Menu eliminar linea en el matrix
        //    if (pVal.MenuUID == SboMenuItem.mnuDelete_Row && pVal.BeforeAction == true)
        //    {
        //        //DeleteRow();
        //    }

        //}


        private void Matrix1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = Validate();
            Matrix1.AssignLineNro();
        }

        private void Matrix1_GotFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            return;
        }

        private void Matrix1_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          

        }

        private void Matrix1_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = Validate();
            
        }

        private void Matrix1_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = Validate();
            
        }


        private static void DeleteRow()
        {

        }

        private static void AddRow()
        {
            // VERIFICAR QUE TAB SE ENCUENTRA ACTIVO
          



            if ( oForm.GetFolder("Item_16").Selected)
            {
                SAPbouiCOM.Matrix oMatrix = oForm.GetMatrix("Item_8");
                // accedo al datasource del formulario 
                SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource(AddonUserTables.Barcos1);
                int rowCount = 0;

                rowCount = oDatasource.Offset;

                rowCount = rowCount + 1;

                oDatasource.InsertRecord(oDatasource.Size);
                oDatasource.Offset = oDatasource.Size - 1;

                int position = 0;

                position = oMatrix.VisualRowCount;


                oMatrix.AddRow(1, rowCount);

                //    oMatrix.SetFocusNewRow();
                oMatrix.AssignLineNro();
            }

            else if (oForm.GetFolder("Item_17").Selected)
            {
                Forxap.Framework.UI.Sb1Messages.ShowMessageBox("Seleccionado : Aparejos");
            }

        }


        public static void MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            

            BubbleEvent = true;
            oForm.GetMatrix("Item_8").AssignLineNro();
          
            // Menu Agregar Linea en el matrix
            if (pVal.MenuUID == SboMenuItem.AddRow && pVal.BeforeAction == true)
            {
                
 
                AddRow();
                BubbleEvent = true;

            }
            // Menu eliminar linea en el matrix
            if (pVal.MenuUID == SboMenuItem.DeleteRow && pVal.BeforeAction == true)
            {
                DeleteRow();
                BubbleEvent = true;

            }

        }

        private void Matrix1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // columna Codigo de especie desde donde se llama al CFL
            if (pVal.ColUID == "Col_1")
            {
                SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));

                SAPbouiCOM.DBDataSource dataSource = oForm.GetDBDataSource(AddonUserTables.Barcos1);

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        dataSource.SetString("U_EspecieCode", pVal.Row -1, chooseFromListEvent.SelectedObjects.GetValue("Code", 0).ToString());

                        dataSource.SetString("U_EspecieName", pVal.Row - 1, chooseFromListEvent.SelectedObjects.GetValue("Name", 0).ToString());
                    }
                }

            }
        }

        private void Matrix1_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
            
            if(pVal.ColUID =="Col_1")
            {


                frmEspecies.ShowObject(Matrix1.GetValueFromEditText("Col_1", pVal.Row));
            }
        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
         //   Matrix1.AssignLineNro();
        }

        private void Form_ClickAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
          //  Matrix1.AssignLineNro();
        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            
        }

        private void Matrix1_MatrixLoadAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          //  Matrix1.AssignLineNro();
        }

        private void Matrix1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
         //   Matrix1.AssignLineNro();
        }

        private void Matrix1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          //  Matrix1.AssignLineNro();
        }

        private void Matrix1_CollapsePressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          //  Matrix1.AssignLineNro();
        }

        private void Matrix1_PickerClickedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  Matrix1.AssignLineNro();
        }

        private void Matrix1_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // Matrix1.AssignLineNro();
        }

        private void Matrix1_DatasourceLoadAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // Matrix1.AssignLineNro();
        }

        private void Form_RightClickAfter(ref SAPbouiCOM.ContextMenuInfo eventInfo)
        {
 //           Matrix0.AssignLineNro();

        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
         //   Matrix1.AssignLineNro();
        }

        private void Folder0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
         //   Matrix2.AssignLineNro();
        }

        private void Folder0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  Matrix1.AssignLineNro();

        }

        private void Folder0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
         //   Matrix1.AssignLineNro();

        }

        private void Folder0_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  Matrix1.AssignLineNro();

        }

        private void Form_DeactivateBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // Matrix1.AssignLineNro();
        }

        private void Form_VisibleAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // Matrix1.AssignLineNro();
        }

        private void Form_ClickBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            switch (pVal.ItemUID)
            {
                case "fld1":
                   Matrix1.AssignLineNro();
                    break;
                case "fld2":
                    oForm.PaneLevel = 2;
                    break;
                case "fld3":
                    oForm.PaneLevel = 3;
                    break;
                case "fld4":
                    oForm.PaneLevel = 4;
                    break;
                case "fld5":
                    oForm.PaneLevel = 5;
                    break;
                default:
                    break;
            }
        }

        private void Matrix1_ValidateBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            int row = 0;
 
            row =  pVal.Row;

            if (pVal.ColUID == "Col_2")
            {
                if (Matrix1.GetValueFromEditText("Col_2", pVal.Row).Length <10  );
                {
                    if (Sb1Messages.ShowQuestion("Código debe ser mayor a 10 digitos, Desea Continuar"))
                    {
                        Sb1Messages.ShowSuccess("Exito total"); 
                    }
                }
            }

            BubbleEvent = true;
            
        }
    }
}
