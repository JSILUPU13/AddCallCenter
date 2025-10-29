using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.UI;
namespace Vistony.Distribucion.Win.DatosMaestros
{
    [FormAttribute("150", "DatosMaestros/SystemForm1.b1f")]
    class SystemForm1 : SystemFormBase
    {
        public SystemForm1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_0").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("U_VIS_CodeBrand").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("1000001").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("U_VIS_CatCorp").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("1000002").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("U_VIS_FamCorp").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("1000003").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("U_VIS_SubFam").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("1000004").Specific));
            this.ComboBox4 = ((SAPbouiCOM.ComboBox)(this.GetItem("U_VIS_Corp_Line").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("1000005").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Folder Folder0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.ComboBox ComboBox3;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.ComboBox ComboBox4;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.Button Button0;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Sb1Messages.ShowMessageBox("Hoola Mundno");
        }

        private SAPbouiCOM.Folder Folder1;
    }
}
