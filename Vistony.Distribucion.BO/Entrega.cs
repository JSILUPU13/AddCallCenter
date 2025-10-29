using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{
    public class enPBXU
    {
        public string Code { get; set; }
        public string U_DocEntry { get; set; }
        public string U_Message { get; set; }
        public string U_TypeSAP { get; set; }
    }
    public class ENActivity
    {
        public string CardCode { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityTime { get; set; }
        public string StartDate { get; set; }
        public string Closed { get; set; }
        public string CloseDate { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Activity { get; set; }
        public string ActivityType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public string DurationType { get; set; }
        public string HandledBy { get; set; }
        public string Details { get; set; }

    }

    public class EntregaConsolidado
    {
        public string U_SYP_DT_CONSOL { get; set; }
        public string U_SYP_DT_FCONSOL { get; set; }
        public string U_SYP_DT_HCONSOL { get; set; }
    }

    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; }
        public string U_SYP_DT_CORRDES { get; set; }
        public string U_SYP_DT_FCDES { get; set; } // fecha 
        public string U_SYP_MDFN { get; set; }
        public string U_SYP_MDVC { get; set; }
        public string U_SYP_DT_AYUDANTE { get; set; }
        public string U_SYP_DT_ESTDES { get; set; }

    }

    public class EstadoDespacho
    {
        public string U_SYP_DT_ESTDES { get; set; }
        public string U_SYP_DT_OCUR { get; set; }
    }
}
