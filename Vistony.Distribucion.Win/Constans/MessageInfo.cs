using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.Constans
{
    public class AddonMessageInfo
    {

        public const string AddonName = "Addon Vistony Call Center ";

        public const string SAPNotRunning = AddonName + "SAP Business One, no se encuentra corriendo ";
        
        public const string StartLoading = AddonName + "Iniciando Carga ..." ;
        public const string FinishLoading = AddonName + "Carga Finalizada ...";
        public const string NotRowFound = AddonName + "No se encontraron datos con los criterios seleccionados";

        public const string Message001 = AddonName + "Iniciando Carga de Menu...";
        public const string Message002 = AddonName + "Finalizado Carga de Menu...";
        public const string Message003 = AddonName + "Error al Cargar el Menu";
        
        public const string Message004 = AddonName + "Iniciando Carga de Tablas...";
        public const string Message005 = AddonName + "Finalizado Carga de Tablas...";
        public const string Message006 = AddonName + "Error al Cargar Tablas...";
 
        public const string Message007 = AddonName + "Iniciando Carga de Campos...";
        public const string Message008 = AddonName + "Finalizado Carga de Campos...";
        public const string Message009 = AddonName + "Error al Cargar Campos...";

        public const string Message010 = AddonName + "Iniciando Registro de Objetos de Usuario...";
        public const string Message011 = AddonName + "Finalizado Registro de Objetos de Usuario...";
        public const string Message012 = AddonName + "Error al Registrar Objeto de Usuario...";

        public const string Message013 = AddonName + "Iniciando Carga de Permisos de usuario...";
        public const string Message014 = AddonName + "Finalizado Carga de Permisos de Usuario...";
        public const string Message015 = AddonName + "Error al Cargar permisos de Usuario...";

        public const string Message016 = AddonName + "Iniciando Carga de Scripts de usuario...";
        public const string Message017 = AddonName + "Finalizado Carga de Scripts de Usuario...";
        public const string Message018 = AddonName + "Error al Cargar scripts de Usuario...";

        public const string Message019 = AddonName + "Iniciando Carga de Icono ...";
        public const string Message020 = AddonName + "Finalizado Carga de Icono...";
        public const string Message021 = AddonName + "Error al Cargar icono de Addon...";        


        public const string Message100 = "¿Seguro/a de actualizar el semáforo en estos momentos?";
        public const string Message101 = "Ud. No cuenta con los permisos para entrar a esta opción";
        public const string Message102 = "Ingrese una cantidad valida";
        public const string Message103 = "Semáforo Actualizado correctamente";

        public const string Message104 = "Faltan Datos";
        public const string Message105 = "Rango de fechas invalido";
        public const string Message106 = "No selecciono ningún registro";
        public const string Message107 = "Proceso correcto ";
        public const string Message108 = "No se proceso ";
        public const string Message109 = "Creando Actividad: ";

        public const string AddWaitMessage= "Procesando información, favor espere...";
        public const string AddFinishMessage = "Proceso culminado";
        public const string AddFinishDownload = "Descarga disponible en: ";
        public const string MessageQuestion = "¿Desea procesar la información seleccionada?";

        public const string MessagePlayer = "¿Desea reproducir el audio seleccionado?";

        public const string PlayAudio = "Reproduciendo audio...";
        public const string StopAudio = "Audio Detenido";
        public const string PauseAudio = "Audio Pausado";






        public const string QueryStatusDelivery = "CALL SP_VIS_GETSTATUSDELIVERY()";
        public const string QueryListSuccess = "CALL SP_VIS_DIS_LIST_OCURRENCIAS()";
        public const string QueryConsolited = "CALL SP_VIS_DIS_GETSTATE()";
        public const string QueryDays = "CALL SP_VIS_DIS_GETDAYS()";

        public const string UrlSAPTRV = "http://localhost:24687/api/TRV";
        public const string UrlSAPActivities = "http://localhost:24687/api/Activity";
        public const string UrlSAPPBX = "http://localhost:24687/api/PBXU";

        public const string LoginYeaster = "https://192.168.254.3:8088/api/v2.0.0/login";
        public const string RandomYeaster = "https://192.168.254.3:8088/api/v2.0.0/recording/get_random?token=";
        public const string DownloadYeaster = "https://192.168.254.3:8088/api/v2.0.0/recording/download?recording=";
    }// fin de la clase


}// fin del namespace
