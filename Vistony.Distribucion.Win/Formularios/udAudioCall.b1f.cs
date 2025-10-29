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
using Vistony.Distribucion.Constans;
using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using System.Media;
using System.Runtime.InteropServices;
using System.Timers;








namespace Vistony.Distribucion.Win.Formularios
{
    [FormAttribute("Vistony.Distribucion.Win.Formularios.udAudioCall", "Formularios/udAudioCall.b1f")]
    class udAudioCall : BaseWizard
    {
        string audio;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public udAudioCall(string extension, string numero, string fecha, string hora, string mensaje, string ruta)
        {
            // Uri myuri = new Uri(audio);
            EditText0.Value = extension;
            EditText1.Value = numero;
            EditText2.Value = fecha;
            EditText3.Value = hora;
            oForm.Title = mensaje;
            //simpleSound = new SoundPlayer(ruta);


            audio = ruta;
            player.URL = audio;
            player.controls.stop();



        }


        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            //this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
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
            try
            {
                oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
                oForm.ScreenCenter(); // centro la pantalla

            }
            catch
            {

            }

        }

        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText3;

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                player.controls.stop();
                if (File.Exists(audio))
                {
                    File.Delete(audio);
                }
            }
            catch

            { }
            oForm.Close();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (Button0.Caption == "Play")
            {
                Sb1Messages.ShowMessage(AddonMessageInfo.PlayAudio);
                Button0.Caption = "Pause";
                player.controls.play();
            }
            else
            {

                Sb1Messages.ShowMessage(AddonMessageInfo.PlayAudio);
                Button0.Caption = "Play";
                player.controls.pause();
            }

        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Sb1Messages.ShowMessage(AddonMessageInfo.StopAudio);
            Button0.Caption = "Play";
            player.controls.stop();
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;


        }

    }
}

