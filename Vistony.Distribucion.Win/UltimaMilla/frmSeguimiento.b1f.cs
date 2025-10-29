using SAPbouiCOM.Framework;
using System.Drawing;
using Forxap.Framework.Extensions;


using WebBrowser = SHDocVw.WebBrowser;




namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("Vistony.Distribucion.Win.UltimaMilla.frmSeguimiento", "UltimaMilla/frmSeguimiento.b1f")]
    class frmSeguimiento : UserFormBase
    {
        SAPbouiCOM.Item oItemX;
        SHDocVw.WebBrowser oWebX;
        SAPbouiCOM.ActiveX oActiveX;
        SAPbouiCOM.Form oForm;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;

        public frmSeguimiento()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_10").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_11").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_17").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);

            EditText1.SetNow();
            EditText0.SetValue("30");
            EditText2.SetValue("2359");
            EditText1.SetFocus();
            StaticText8.SetBold();
            StaticText9.SetBold();
            // porcentaje


            SetPercentage(82);// porcentaje de avance
            SetProgress(376, 460); //avance
            Successful(293); // entregas exitosas
            UnSuccessful(83);// entregas no  exitosas

            ResizeControls();

            InitializeGrid();

            //oItemX = this.UIAPIRawForm.Items.Add("Browser", SAPbouiCOM.BoFormItemTypes.it_ACTIVE_X);

            //oItemX.Height = this.UIAPIRawForm.Height - 400;

            //oItemX.Width = this.UIAPIRawForm.Width - 200;

            // oActiveX = oItem.Specific

            // oActiveX.ClassID = "Shell.Explorer.2"

            // oWeb = oActiveX.Object // i got error this line

            // oWeb.Navigate("http://emergys.co.in/")



        }




        private void SetProgress(int progress,int count )
        {
            StaticText2.SetBold();// etiqueta
            StaticText5.SetColor(Color.Blue);
            StaticText5.SetHeight(50);
            StaticText5.SetSize(50);
            StaticText5.Caption = string.Format("{0} / {1} ", progress, count);
            
        }

        private void UnSuccessful(int value)
        {
            StaticText3.SetBold();//etiqueta
            StaticText4.SetColor(Color.Red);
            StaticText4.SetHeight(50);
            StaticText4.SetSize(50);
            StaticText4.Caption = value.ToString();
        }

        private void Successful(int value)
        {
            StaticText10.SetBold();// etiqueta
            StaticText11.SetColor(Color.Black);
            StaticText11.SetHeight(50);
            StaticText11.SetSize(50);
            StaticText11.Caption = value.ToString();
        }
        private void SetPercentage(int value)
        {
            StaticText6.SetBold();// etiqueta
            StaticText7.SetHeight(50);
            StaticText7.SetSize(50);
            StaticText7.Caption = string.Format("{0} %", value.ToString());

        }



        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            ResizeControls();
        }

        private void ResizeControls()
        {
            StaticText8.Item.Top = Grid0.Item.Top - 20;
            StaticText8.Item.Left = Grid0.Item.Left;
            Grid0.Item.Width = oForm.Width - 30;
            Grid1.Item.Width = oForm.Width - 30;

            StaticText9.Item.Top = Grid0.Item.Top + Grid0.Item.Height + 20;
            Grid1.Item.Top  = StaticText9.Item.Top + 20;

            StaticText9.Item.Left = Grid1.Item.Left;

            StaticText2.Item.Left = ((oForm.Width - 30) / 2); //avance
            StaticText5.Item.Left = ((oForm.Width - 30) / 2);

            StaticText6.Item.Left = ((oForm.Width - 30) / 3); // porcentaje etiqueta
            StaticText7.Item.Left =  ((oForm.Width - 30) / 3);// porcenyaje monto

            StaticText4.Item.Left = StaticText3.Item.Left;
           
        }

        private void InitializeGrid()
        {
            Grid0.DataTable.Columns.Add("Vehículo", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Chofer", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Fecha inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Hora inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid0.DataTable.Columns.Add("Feccha termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Hora termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Total exitosos", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid0.DataTable.Columns.Add("Total no exitosos", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            
        
            Grid0.Columns.Item(0).Editable = false;
            Grid0.Columns.Item(1).Editable = false;
            Grid0.Columns.Item(2).Editable = false;
            Grid0.Columns.Item(3).Editable = false;
            Grid0.Columns.Item(4).Editable = false;
            Grid0.Columns.Item(5).Editable = false;
            Grid0.Columns.Item(6).Editable = false;
            Grid0.Columns.Item(7).Editable = false;


            // Detalle de las entregas
            Grid1.DataTable.Columns.Add("Código SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nombre SN", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Dirección", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Nro. guía entrega", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nro. pedido", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Nro. factura", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Hora estimada", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

            Grid1.DataTable.Columns.Add("Hora inicio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Hora termino", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            
            Grid1.DataTable.Columns.Add("Tiempo de atención", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("Estado", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
            Grid1.DataTable.Columns.Add("comentarios", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);


            Grid1.Columns.Item(0).Editable = false;
            Grid1.Columns.Item(1).Editable = false;
            Grid1.Columns.Item(2).Editable = false;
            Grid1.Columns.Item(3).Editable = false;
            Grid1.Columns.Item(4).Editable = false;
            Grid1.Columns.Item(5).Editable = false;
            Grid1.Columns.Item(6).Editable = false;
            Grid1.Columns.Item(7).Editable = false;
            Grid1.Columns.Item(8).Editable = false;
            Grid1.Columns.Item(9).Editable = false;
            Grid1.Columns.Item(10).Editable = false;
            Grid1.Columns.Item(11).Editable = false;


            Grid0.AutoResizeColumns();
            Grid1.AutoResizeColumns();
        }

        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
           // throw new System.NotImplementedException();

        }
    }
}
