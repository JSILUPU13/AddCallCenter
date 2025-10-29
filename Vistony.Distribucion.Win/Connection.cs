using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPbouiCOM.Framework;
using Forxap.Framework;
using Forxap.Framework.UI;

using Vistony.Distribucion.Constans;

namespace Vistony.Distribucion.Win
{
    public class Sb1Connection
    {
        /// <summary>
        /// Conecta el AddOn a la instancia de SAP que se encuentra cargada (desarrollo) o en la instancia
        /// que lo invoca en Producción.
        /// </summary>
        /// <returns></returns>
        public static bool ConnectToSAP()
        {
   
            bool ret = true;


            try
            {
                
                
                Sb1Globals.oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
                Sb1Globals.oCompanyService = Sb1Globals.oCompany.GetCompanyService();

                Sb1Globals.DbServerType = Sb1Globals.oCompany.DbServerType.ToString();

                Sb1Globals.Path = System.Windows.Forms.Application.StartupPath;

                Vistony.Distribucion.DAL.BaseDAL.SetDataAccesLayer(Application.SBO_Application, Sb1Globals.oCompany);
                Sb1Initialize.SetFramework(Application.SBO_Application, Sb1Globals.oCompany);//inicializa el framework
                

                Forxap.Framework.ServiceLayer.Sb1Initialize.SetFramework(Application.SBO_Application, Sb1Globals.oCompany);

                Sb1Messages.ShowSuccess(string.Format(AddonMessageInfo.StartLoading), SAPbouiCOM.BoMessageTime.bmt_Short);


                Sb1Globals.UserSignature = Sb1Globals.oCompany.UserSignature;// obtiene el codigo del usuario logeado
                Sb1Globals.UserName = Sb1Globals.oCompany.UserName; // Nombre completo del usuario logeado
                Sb1Globals.CompanyName = Sb1Globals.oCompany.CompanyName; // Nombre de la compañia a la que esta logeado

                

                #region Creación del Menu, Iconos, Tablas, Campos, UDOs,Permisos, Scripts


                Sb1MetaData.AddMenus();/// agrega el menu del addon
            //    Sb1MetaData.AddIcon();// agrega el icono de addon
             //   Sb1MetaData.AddTables();// agrega todas las tablas del addon
             //   Sb1MetaData.AddFields();// agregar todos los campos de las tablas del addon
            //    Sb1MetaData.AddUdos();/// agregar  los udos del addon
          //      Sb1MetaData.AddUserScripts();// agrega los permisos de las ventanas del addon
                
                #endregion

                Sb1Messages.ShowSuccess(string.Format(AddonMessageInfo.FinishLoading), SAPbouiCOM.BoMessageTime.bmt_Short);



                ret = true;
            }
            catch (Exception ex)
            {
              //  if (Messages != null)
              //  Messages.ShowError(ex.Message);
            }



            return ret;

        }// fin del metodo connectToSAP

 



    }// fin de la clase

}// fin del namespace
