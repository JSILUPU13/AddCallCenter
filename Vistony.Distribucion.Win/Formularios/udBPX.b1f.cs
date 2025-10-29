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
using Newtonsoft.Json;
using System.Net;
using RestSharp;

namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("Vistony.Distribucion.Win.Formularios.udBPX", "Formularios/udBPX.b1f")]
    class udBPX : BaseWizard
    {
        public udBPX()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText0_ClickAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_7").Specific));
            this.Grid0.LinkPressedBefore += new SAPbouiCOM._IGridEvents_LinkPressedBeforeEventHandler(this.Grid0_LinkPressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button1.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button1_ChooseFromListAfter);
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_4").Specific));
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
            EditText1.Value = DateTime.Now.AddDays(-3).ToString("yyyyMMdd");
            EditText2.Value = DateTime.Now.ToString("yyyyMMdd");
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button1;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
         //   throw new System.NotImplementedException();

        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                
                Sb1Messages.ShowMessage(AddonMessageInfo.AddWaitMessage);
                string Usuario = Sb1Globals.UserName;
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
                //int Dias = Convert.ToInt16(EditText0.Value);
                oForm.Freeze(true);
                Vistony.Distribucion.DAL.BaseDAL.CallLlamadasPBX(EditText0.Value, EditText1.Value, EditText2.Value, Usuario, ref oDT);
                SetFormatGrid();
            }
            catch
            { }
            finally
            {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage(AddonMessageInfo.AddFinishMessage);
            }

        }

        private void SetFormatGrid()
        {

            // Grid0.AssignLineNro();

            //Grid0.Columns.Item("DocEntry").Visible = false;
            //Grid0.Columns.Item("Code").Visible = false;
            Grid0.Columns.Item("Fecha1").Visible = false;
            Grid0.Columns.Item("UserID").Visible = false;
            Grid0.Columns.Item("Clave").Visible = false;
            Grid0.Columns.Item("Duracion").Visible = false;
            Grid0.Columns.Item("depa").Visible = false;
            Grid0.Columns.Item("Motivo").Visible = false;
            //Grid0.Columns.Item(9).LinkedObjectType(Grid0, "Vendedor", "53");
            //Grid0.Columns.Item("CodigoSN").LinkedObjectType(Grid0, "CodigoSN", "2");
            //Grid0.Columns.Item("ItemCode").LinkedObjectType(Grid0, "ItemCode", "4");
            Grid0.Columns.Item("CodigoSN").TitleObject.Caption = "Código SN";
            Grid0.Columns.Item("NombreSN").TitleObject.Caption = "Nombre SN";
            Grid0.Columns.Item("salesPrson").LinkedObjectType(Grid0, "salesPrson", "53");
            Grid0.Columns.Item("CodigoSN").LinkedObjectType(Grid0, "CodigoSN", "2");
            Grid0.Columns.Item("CodActividad").LinkedObjectType(Grid0, "CodActividad", "33");
            Grid0.Columns.Item("Registro").LinkedObjectType(Grid0, "Registro", "2");
            Grid0.Columns.Item("salesPrson").TitleObject.Caption = "Cod Ejecutivo";
            Grid0.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid0.Columns.Item(0).TitleObject.Caption = "";

            Grid0.ReadOnlyColumns();
            Grid0.Columns.Item(0).Editable = true;
            //Grid0.AssignLineNro();
            Grid0.AutoResizeColumns();

            // ampliio el ancho de la columna
            //Grid0.RowHeaders.Width += 15;


        }

        private static bool EnviaJSON(string DataJson, string URL, out string mensaje)
        {
            try
            {

                var url = URL;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";
                var data = DataJson;

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                dynamic objs;
                bool Resultado = false;
                objs = JsonConvert.DeserializeObject(result.ToString());
                dynamic leer = result.ToString();

                if (result.ToString().IndexOf("error")<= 0)
                {
                    Resultado = true;
                }
                mensaje = result.ToString();

                return Resultado;


            }
            catch (WebException ex)
            {
                mensaje = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                return false;
                //MessageBox.Show(Convert.ToString(ex));
            }
        }

        private static bool EnviaJSONPATCH(string DataJson, string URL, out string mensaje)
        {
            try
            {

                var url = URL;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";
                var data = DataJson;

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                dynamic objs;
                bool Resultado = false;
                objs = JsonConvert.DeserializeObject(result.ToString());
                dynamic leer = result.ToString();

                if (result.ToString().IndexOf("error") == 0)
                {
                    Resultado = true;
                }
                mensaje = result.ToString();

                return Resultado;


            }
            catch (WebException ex)
            {
                mensaje = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                return false;
                //MessageBox.Show(Convert.ToString(ex));
            }
        }


        private void Button1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                int contador = 0;
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {
                    if (Grid0.DataTable.GetString("''", row) == "Y" && Grid0.DataTable.GetString("EstadoSAP", row) != "M")
                    {
                        contador += 1;
                    }
                }
                if (contador == 0)
                {
                    Sb1Messages.ShowError(AddonMessageInfo.Message106);
                    return;
                }
                bool mensajeQ = Sb1Messages.ShowQuestion(AddonMessageInfo.MessageQuestion);
                if (!mensajeQ)
                {
                    return;
                }
                
                Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                for (int row = 0; row <= Grid0.Rows.Count - 1; row++)
                {

                    if (Grid0.DataTable.GetString("''", row) == "Y" && Grid0.DataTable.GetString("EstadoSAP", row) != "M")
                    {
                        if (Grid0.DataTable.GetString("CodigoSN", row).ToString() != "" && Grid0.DataTable.GetString("UserID",row).ToString() !="0")
                        {

                            oForm.Freeze(true);
                            Sb1Messages.ShowMessage(AddonMessageInfo.AddWaitMessage);
                            ENActivity enActividad = new ENActivity();
                            enActividad.Activity = "cn_Conversation";
                            DateTime HoraT = Convert.ToDateTime(Grid0.DataTable.GetString("Hora", row).ToString());
                            string HoraF = HoraT.AddSeconds(Convert.ToInt32(Grid0.DataTable.GetString("Duracion", row))).ToString("HH:mm:ss");
                            enActividad.ActivityDate = Grid0.DataTable.GetString("Fecha1", row).ToString();
                            enActividad.ActivityTime = Grid0.DataTable.GetString("Hora", row).ToString();
                            enActividad.ActivityType = "2";
                            enActividad.CardCode = Grid0.DataTable.GetString("CodigoSN", row).ToString();
                            enActividad.Closed = "tYES";
                            enActividad.CloseDate = Grid0.DataTable.GetString("Fecha1", row).ToString();
                            enActividad.Details = "Llamada " + Grid0.DataTable.GetString("Estado", row).ToString();
  
                            enActividad.StartDate = Grid0.DataTable.GetString("Fecha1", row).ToString();
                            enActividad.StartTime = Grid0.DataTable.GetString("Hora", row).ToString();
                            enActividad.Duration = Grid0.DataTable.GetString("Duracion", row).ToString();
                            enActividad.DurationType = "du_Seconds";
                            //enActividad.EndTime = enActividad.StartTime + enActividad.Duration;  //Grid0.DataTable.GetString("Estado", row).ToString() == "Contestada" ? HoraF : HoraT.ToString("HH:mm:ss");
                            enActividad.HandledBy = Grid0.DataTable.GetString("UserID", row).ToString();
                            enActividad.Phone = Grid0.DataTable.GetString("NumeroSN", row).ToString();
                            
                            
                            enActividad.Subject = Grid0.DataTable.GetString("Motivo", row).ToString();
                            dynamic jsonData = JsonConvert.SerializeObject(enActividad);
                            dynamic response;
                            string mensaje = "";

                            response = methods.POST("Activities", jsonData);
                            dynamic json2;
                            json2 = JsonConvert.DeserializeObject(response.Content.ToString());

                            Sb1Messages.ShowMessage(AddonMessageInfo.Message109 + enActividad.CardCode);
                            if (response.StatusCode.ToString() == "Created")
                            {
                                mensaje = json2["ActivityCode"].ToString();
                                Sb1Messages.ShowMessage(AddonMessageInfo.Message109 + mensaje);
                                Grid0.DataTable.SetValue("Respuesta", row, "Migrado");
                                Grid0.DataTable.SetValue("CodActividad", row, mensaje.Replace(@"""", ""));
                                Grid0.DataTable.SetValue("EstadoSAP", row, "Migrado");

                                enPBXU enPBX = new enPBXU();
                                enPBX.Code = Grid0.DataTable.GetString("Code", row).ToString();
                                enPBX.U_DocEntry = mensaje.Replace(@"""", "");
                                enPBX.U_Message = "Migrado";
                                enPBX.U_TypeSAP = "M";
                                dynamic PBXjsonData = JsonConvert.SerializeObject(enPBX);
                                dynamic response2;
                                response2 = methods.PATCH("VISTPBX", Convert.ToInt32(enPBX.Code), PBXjsonData);
                                dynamic json3;
                                json3 = JsonConvert.DeserializeObject(response2.Content.ToString());
                                Grid0.DataTable.SetValue(0, row, "N");
                                Sb1Messages.ShowMessage(AddonMessageInfo.AddWaitMessage);
                                oForm.Freeze(false);
                                /////OK
                            }
                            else
                            {
                                Sb1Messages.ShowError(AddonMessageInfo.Message108 + mensaje);
                                Grid0.DataTable.SetValue(0, row, "N");
                                oForm.Freeze(false);
                            }
                        }
                        else
                        {
                            Grid0.DataTable.SetValue("Respuesta", row, "Faltan Datos");
                            Grid0.DataTable.SetValue("EstadoSAP", row, "Error");
                            Grid0.DataTable.SetValue(0, row, "N");
                            oForm.Freeze(false);
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
                Sb1Messages.ShowMessage(AddonMessageInfo.FinishLoading);
            }

        }

        private void EditText0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
         //   throw new System.NotImplementedException();

        }

        private SAPbouiCOM.LinkedButton LinkedButton0;

        private void Grid0_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.EditTextColumn col = null;


            // verifico en que columna hicieron click  en el linkedbutton
            if (pVal.ColUID == "Registro")

            {

                //int rowSelected = Grid0.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                int rowSelected = pVal.Row;
                int rowIndex = rowSelected;
                string Codigo = Grid0.DataTable.GetValue("Registro", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                string Extension = Grid0.DataTable.GetValue("Extension", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                string Numero = Grid0.DataTable.GetValue("NumeroSN", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                string Fecha = Grid0.DataTable.GetValue("Fecha", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                string Hora = Grid0.DataTable.GetValue("Hora", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                string Tipo = Grid0.DataTable.GetValue("Tipo", Grid0.GetDataTableRowIndex(rowIndex)).ToString();

                // quito por un instante el codigo de objeto al cual esta relacionado el linkedbutton
                col = ((SAPbouiCOM.EditTextColumn)(Grid0.Columns.Item(1)));
                col.LinkedObjectType = "";// 

                bool consulta = Sb1Messages.ShowQuestion(AddonMessageInfo.MessagePlayer);
                if (consulta)
                {
                    TraerLlamadaYeaster(Codigo,Extension,Numero,Fecha,Hora,Tipo);
                }
                BubbleEvent = false;

            }
        }

        private void TraerLlamadaYeaster(string RegistroLlamada, string Extension, string Numero, string Fecha, string Hora, string Tipo)
        {


                string Token = "";
                string Random = "";
                string Recording = "";
                IRestResponse response = null;

                var client = new RestClient(AddonMessageInfo.LoginYeaster);

                var request = new RestRequest(Method.POST);
                var request2 = new RestRequest(Method.POST);
                var request3 = new RestRequest(Method.GET);


                try

                {
                    Sb1Messages.ShowMessage(AddonMessageInfo.AddWaitMessage);
                    oForm.Freeze(true);

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
                            var client2 = new RestClient(AddonMessageInfo.RandomYeaster + Token);
                            request2.AddParameter
                            ("text/plain",
                           @"{""recording"": """ + RegistroLlamada + @" ""}", ParameterType.RequestBody);
                            request2.RequestFormat = DataFormat.Json;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                            response = client2.Execute(request2);
                            if (response.StatusCode.ToString() == "OK")
                            {
                                dynamic json2 = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ToString());

                                Random = json2["random"].ToString();
                                Recording = json2["recording"].ToString();
                            if (Random != "")
                                {

                                try
                                {
                                    string archivo = Path.GetTempPath() + RegistroLlamada;
                                    if (File.Exists(archivo))
                                    {
                                        File.Delete(archivo);
                                    }
                                }
                                catch
                                { }
                                string downloadURL = AddonMessageInfo.DownloadYeaster + Recording + "&random=" + Random + "&token=" + Token;
                                RestClient cliente = new RestClient(downloadURL);
                                RestRequest respuesta = new RestRequest(string.Empty, Method.GET);
                                var bytes = cliente.DownloadData(respuesta);
                                File.WriteAllBytes(Path.GetTempPath() + RegistroLlamada , bytes);

                                if (response.StatusCode.ToString() == "OK")
                                    {
                                    if (File.Exists(Path.GetTempPath() + RegistroLlamada))
                                    {
                                        Sb1Messages.ShowMessage(AddonMessageInfo.AddFinishMessage);
                                        udAudioCall formllamada = new udAudioCall(Extension, Numero, Fecha, Hora, "Llamada " + Tipo, Path.GetTempPath() + RegistroLlamada);
                                        oForm.Freeze(false);
                                        formllamada.Show();
                                    }

                                    }

                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    
                    oForm.Freeze(false);
                    Sb1Messages.ShowError(ex.Message);
            }
                finally
                {
                    oForm.Freeze(false);
                }


        }
    }
}
