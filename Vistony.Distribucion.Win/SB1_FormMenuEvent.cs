using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;
using Forxap.Banco.UI.Win.Configuracion;


namespace Vistony.Distribucion.Win
{
    public class SB1_FormMenuEvent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_FormMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                
                switch (Application.SBO_Application.Forms.ActiveForm.TypeEx)
                {

                       
                    //case WinForms.frmParametros:
                    //    {

                    //    //    Configuracion.frmParametrizacion.MenuEvent(ref pVal, out BubbleEvent);
                    //    //    break;
                    //    //}


            


                }

            }
            catch (Exception ex)
            {

                // TODO: crear un log de forma asincrona
                //Forxap.Framework.UI.Messages.ShowError(ex.ToString());
            }



        }// fin del metodo FormMenuEvent



    }// fin de la clase

}// fin del namespace
