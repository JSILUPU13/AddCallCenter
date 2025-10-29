using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Vistony.Distribucion.Constans;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using System.Media;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using Vistony.Distribucion.DAL;
namespace Vistony.Distribucion.Win
{
    [FormAttribute("651", "SystemForm1.b1f")]
    class SystemForm1 : SystemFormBase
    {

        SAPbouiCOM.Form oForm;
        SAPbouiCOM.DBDataSource oDBDataSource;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public SystemForm1()
        {

        }

        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);


        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button2.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button2_ChooseFromListAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oDBDataSource = oForm.DataSources.DBDataSources.Item("OCLG");
            EditText0.Value = oDBDataSource.GetValue("U_VIS_RegisterPBX", 0);
            string Usuario = Sb1Globals.UserName;
            string nivelacceso  = BaseDAL.CallAccessUser(Usuario);
            VisualizaeControlCDR(nivelacceso);

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textoCDR = EditText0.Value;
            string archivofin;

            if (Button0.Caption == "Reproducir")
            {
                Button0.Caption = "Pausar";
                player.controls.play();
            }
            else
            {
                Button0.Caption = "Reproducir";
                player.controls.pause();
            }

        }


        private bool TraerLlamadaYeaster(string RegistroLlamada, out string ArchivoFinal)
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
                                File.WriteAllBytes(Path.GetTempPath() + RegistroLlamada, bytes);

                                if (response.StatusCode.ToString() == "OK")
                                {
                                    if (File.Exists(Path.GetTempPath() + RegistroLlamada))
                                    {
                                        Sb1Messages.ShowMessage(AddonMessageInfo.AddFinishMessage);
                                        oForm.Freeze(false);
                                        ArchivoFinal = Path.GetTempPath() + RegistroLlamada;
                                        return true;

                                    }
                                    else
                                    {
                                        ArchivoFinal = "";
                                        return false;
                                    }

                                }

                                else
                                {
                                    ArchivoFinal = "";
                                    return false;
                                }


                            }
                            else
                            {
                                ArchivoFinal = "";
                                return false;
                            }
                        }
                        else
                        {
                            ArchivoFinal = "";
                            return false;
                        }
                    }
                    else
                    {
                        ArchivoFinal = "";
                        return false;
                    }
                }
                else
                {
                    ArchivoFinal = "";
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {

                oForm.Freeze(false);
                ArchivoFinal = "";
                return false;
                Sb1Messages.ShowError(ex.Message);
            }
            finally
            {
                oForm.Freeze(false);
            }


        }

        private bool DescargarLlamadaYeaster(string RegistroLlamada, out string ArchivoFinal)
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
                                    string archivo = GetDownloadsPath() + "\\"+RegistroLlamada;
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
                                File.WriteAllBytes(GetDownloadsPath()  +"\\" + RegistroLlamada, bytes);

                                if (response.StatusCode.ToString() == "OK")
                                {
                                    Sb1Messages.ShowMessage(AddonMessageInfo.AddFinishDownload + GetDownloadsPath() + "\\" + RegistroLlamada);
                                    oForm.Freeze(false);
                                    ArchivoFinal = GetDownloadsPath() + "\\" + RegistroLlamada;
                                    return true;


                                }

                                else
                                {
                                    ArchivoFinal = "";
                                    return false;
                                }


                            }
                            else
                            {
                                ArchivoFinal = "";
                                return false;
                            }
                        }
                        else
                        {
                            ArchivoFinal = "";
                            return false;
                        }
                    }
                    else
                    {
                        ArchivoFinal = "";
                        return false;
                    }
                }
                else
                {
                    ArchivoFinal = "";
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {

                oForm.Freeze(false);
                ArchivoFinal = "";
                return false;
                Sb1Messages.ShowError(ex.Message);
            }
            finally
            {
                oForm.Freeze(false);
            }


        }

        public static string GetDownloadsPath()
        {
            if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

            IntPtr pathPtr = IntPtr.Zero;

            try
            {
                SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                return Marshal.PtrToStringUni(pathPtr);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pathPtr);
            }
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Button0.Caption = "Reproducir";
            player.controls.stop();

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                EditText0.Value = oDBDataSource.GetValue("U_VIS_RegisterPBX", 0);
                if (player.URL != "")
                {
                    if (File.Exists(player.URL))
                    {
                        File.Delete(player.URL);
                    }
                }
                ActivarDescargas(false);
            }
            catch
            { }
        }

        private void ActivarDescargas(Boolean sw)
        {
            Button0.Item.Enabled = sw;
            Button1.Item.Enabled = sw;
            Button2.Item.Enabled = sw;
            Button3.Item.Enabled = !sw;
        }

        private void VisualizaeControlCDR(string nivel)
        { 
            switch (nivel)
            {
                case "1":
                    Button0.Item.Visible = true;
                    Button1.Item.Visible = true;
                    Button2.Item.Visible = true;
                    Button3.Item.Visible = false;
                    break;
                case "2":
                    Button0.Item.Visible = true;
                    Button1.Item.Visible = true;
                    Button2.Item.Visible = true;
                    Button3.Item.Visible = true;
                    break;
                default :
                    Button0.Item.Visible = false;
                    Button1.Item.Visible = false;
                    Button2.Item.Visible = false;
                    Button3.Item.Visible = false;
                    break;

            }


        }

        private SAPbouiCOM.Button Button3;

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string textoCDR = EditText0.Value;
            string archivofin;

            Button0.Caption = "Reproducir";

            if (textoCDR == "")
            {
                Sb1Messages.ShowMessageBoxWarning("No hay archivo a reproducir");
                return;
            }
            if (TraerLlamadaYeaster(textoCDR, out archivofin))
            {
                if (archivofin != "")
                {
                    ActivarDescargas(true);
                    player.URL = archivofin;
                    player.controls.stop();
                }
            }

        }

        private void Button2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
        }

            private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


            string archivo = EditText0.Value;
            string rpta = "";
            if (archivo != "")
            {
                if (!DescargarLlamadaYeaster(archivo, out rpta))
                {
                    Sb1Messages.ShowError("No se pudo descargar el archivo", SAPbouiCOM.BoMessageTime.bmt_Short);
                }

            }

        }
    }
}