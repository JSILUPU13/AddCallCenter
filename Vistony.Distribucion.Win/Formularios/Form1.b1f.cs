using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SAPbouiCOM.Framework;
using RestSharp;
using System.IO;
using Vistony.Distribucion.Win.Formularios;
using Vistony.Distribucion.Win.Asistentes;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;


namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("Vistony.Distribucion.Win.Formularios.Form1", "Formularios/Form1.b1f")]
    class Form1 : BaseWizard
    {
        public Form1()
        {
            EditText1.Value = DateTime.Now.ToString("yyyyMMdd");
            EditText2.Value = DateTime.Now.AddDays(1).ToString("yyyyMMdd"); 
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ChooseFromListBefore += new SAPbouiCOM._IButtonEvents_ChooseFromListBeforeEventHandler(this.Button0_ChooseFromListBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_1").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.EditText0.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText0_ClickAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.EditText1.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText1_ClickAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.EditText2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText2_ClickAfter);
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

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
        }

        private SAPbouiCOM.Grid Grid0;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string Extension = EditText0.Value;
            string fecha1 = EditText1.Value.ToString().Substring(0, 4) + "-" + EditText1.Value.ToString().Substring(4, 2) + "-" + EditText1.Value.ToString().Substring(6, 2);
            string fecha2 = EditText2.Value.ToString().Substring(0, 4) + "-" + EditText2.Value.ToString().Substring(4, 2) + "-" + EditText2.Value.ToString().Substring(6, 2);
            

            string Token = "";
            string Random = "";
            IRestResponse response = null;

            var client = new RestClient("https://192.168.254.3:8088/api/v2.0.0/login");

            var request = new RestRequest(Method.POST);
            var request2 = new RestRequest(Method.POST);
            var request3 = new RestRequest(Method.GET);


            try
            {
                client.Proxy = System.Net.WebRequest.GetSystemWebProxy();

                oForm.Freeze(true);
                request.AddParameter
                    ("text/plain",
                   @"{""username"": ""api"",""password"": ""0f86a09646273f7d3e6820bc976db07d"",""port"": ""8260""}", ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = client.Execute(request);

                if (response.StatusCode.ToString() == "OK")
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                    Token = json["token"].ToString();
                    if (Token != "")
                    {
                        var client2 = new RestClient("https://192.168.254.3:8088/api/v2.0.0/cdr/get_random?token=" + Token);
                        request2.AddParameter
                        ("text/plain",
                       @"{""number"": """ + Extension + @""",""starttime"": """+fecha1+ @" 00:00:00"",""endtime"": """+ fecha2+ @" 00:00:00""}", ParameterType.RequestBody);
                        request2.RequestFormat = DataFormat.Json;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                        response = client2.Execute(request2);
                        if (response.StatusCode.ToString() == "OK")
                        {
                            dynamic json2 = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                            Random = json2["random"].ToString();
                            if (Random != "")
                            {
                                var client3 = new RestClient("https://192.168.254.3:8088/api/v2.0.0/cdr/download?number=" + Extension + "&starttime="+ fecha1+ "%2000:00:00&endtime="+ fecha2+"%2000:00:00&token=" + Token + "&random=" + Random);
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                                response = client3.Execute(request3);
                                if (response.StatusCode.ToString() == "OK")
                                {

                                    SAPbouiCOM.DataTable data = oForm.GetDataTable("DT_0");
                                    data.Clear();
                                    var columns = data.Columns;
                                    columns.Add("callid", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("timestart", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("callfrom", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("callto", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("callduraction", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("talkduraction", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("srctrunkname", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("dsttrunkname", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("status", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("type", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("pincode", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("recording", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("didnumber", SAPbouiCOM.BoFieldsType.ft_Text);
                                    columns.Add("sn", SAPbouiCOM.BoFieldsType.ft_Text);
                                    data.Rows.Clear();

                                    dynamic json3 = response.Content.ToString();
                                    Int32 i = 0;
                                    using (StringReader reader = new StringReader(json3))
                                    {
                                        string line;
                                        while ((line = reader.ReadLine()) != null)
                                        {

                                            if (i > 0)
                                            {
                                                string[] valores = line.Split(',');
                                                data.Rows.Add();
                                                data.SetValue(0, i - 1, valores[0]);
                                                data.SetValue(1, i - 1, valores[1]);
                                                data.SetValue(2, i - 1, valores[2]);
                                                data.SetValue(3, i - 1, valores[3]);
                                                data.SetValue(4, i - 1, valores[4]);
                                                data.SetValue(5, i - 1, valores[5]);
                                                data.SetValue(6, i - 1, valores[6]);
                                                data.SetValue(7, i - 1, valores[7]);
                                                data.SetValue(8, i - 1, valores[8]);
                                                data.SetValue(9, i - 1, valores[9]);
                                                data.SetValue(10, i - 1, valores[10]);
                                                data.SetValue(11, i - 1, valores[11]);
                                                data.SetValue(12, i - 1, valores[12]);
                                                data.SetValue(13, i - 1, valores[13]);

                                            }
                                            i++;


                                        }
                                    }

                                    /////////////////
                                    Grid0.Columns.Item(0).TitleObject.Caption = "Id Registro";
                                    Grid0.Columns.Item(1).TitleObject.Caption = "Hora";
                                    Grid0.Columns.Item(2).TitleObject.Caption = "origen";
                                    Grid0.Columns.Item(3).TitleObject.Caption = "Destino";
                                    Grid0.Columns.Item(4).TitleObject.Caption = "Duración";
                                    Grid0.Columns.Item(5).TitleObject.Caption = "Duración Enlace";
                                    Grid0.Columns.Item(6).TitleObject.Caption = "Troncal Origen";
                                    Grid0.Columns.Item(7).TitleObject.Caption = "Troncal Destino";
                                    Grid0.Columns.Item(8).TitleObject.Caption = "Estado";
                                    Grid0.Columns.Item(9).TitleObject.Caption = "Tipo";
                                    Grid0.Columns.Item(10).TitleObject.Caption = "Clave";
                                    Grid0.Columns.Item(11).TitleObject.Caption = "Registro Llamada";
                                    Grid0.Columns.Item(12).TitleObject.Caption = "DID";
                                    Grid0.Columns.Item(13).TitleObject.Caption = "SN";
                                    Grid0.AutoResizeColumns();
                                    Grid0.ReadOnlyColumns();


                                }

                            }
                        }
                    }
                }

            }
            catch
            {

            }
            finally
            {
                oForm.Freeze(false);
            }

            }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;

        private void Button0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
 
            // throw new System.NotImplementedException();

        }

        private void EditText0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }
    }
}
