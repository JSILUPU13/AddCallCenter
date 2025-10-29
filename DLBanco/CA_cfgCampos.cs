using System;

namespace DLBancos
{
    public class CA_ConfigBancos
    {
        public int Depositante_Pos { get; set; }
        public int Depositante_Lon { get; set; }
        public int Fecha_Pos { get; set; }
        public int Fecha_Lon { get; set; }
        public int Recibo1_Pos { get; set; }
        public int Recibo1_Lon { get; set; }
        public int Recibo2_Pos { get; set; }
        public int Recibo2_Lon { get; set; }
        public int Decimal_Pos { get; set; }
        public int Decimal_Lon { get; set; }
        public int Monto_Pos { get; set; }
        public int Monto_Lon { get; set; }
        public int Recibo_Pos { get; set; }
        public int Recibo_Lon { get; set; }

        public int FechaenCabecera { get; set; }
        public int LineaInicio { get; set; }
        public string Indicador { get; set; }

        public string FormatoFecha { get; set; }
        public int GenerarRecibo { get; set; }
    }
}
