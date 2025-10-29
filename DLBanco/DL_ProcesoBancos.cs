using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DLBancos
{
    public class DL_ProcesoBancos
    {

        public enum Banco
        {
            BCP,
            BBVA,
            INTERBANK,
            SCOTIABANK,
            CJ_PIURA            
        }

        public static CA_ConfigBancos  ConfigurarPlantilla (Banco banco)
        {
            CA_ConfigBancos Plantilla = new CA_ConfigBancos();
            switch (banco)
            {
                case Banco.BCP:
                    Plantilla.LineaInicio = 2;
                    Plantilla.Depositante_Pos = 13;
                    Plantilla.Depositante_Lon = 14;
                    Plantilla.Fecha_Pos = 57;
                    Plantilla.Fecha_Lon = 8;
                    Plantilla.Recibo1_Lon = 7;
                    Plantilla.Recibo1_Pos = 226;
                    Plantilla.Recibo2_Lon = 7;
                    Plantilla.Recibo2_Pos = 196;
                    Plantilla.Decimal_Lon = 2;
                    Plantilla.Decimal_Pos = 86;
                    Plantilla.Monto_Lon = 13;
                    Plantilla.Monto_Pos = 73;
                    Plantilla.Recibo_Lon = 7;
                    Plantilla.Recibo_Pos = 201;
                    Plantilla.FechaenCabecera = 0;
                    Plantilla.Indicador = "DD";
                    Plantilla.FormatoFecha = "YYYYMMDD";
                    Plantilla.GenerarRecibo = 0;
                    break;
                case Banco.BBVA:
                    Plantilla.LineaInicio = 2;
                    Plantilla.Depositante_Pos = 32;
                    Plantilla.Depositante_Lon = 11;
                    Plantilla.Fecha_Pos = 135;
                    Plantilla.Fecha_Lon = 8;
                    Plantilla.Recibo1_Lon = 129;
                    Plantilla.Recibo1_Pos = 6;
                    Plantilla.Recibo2_Lon = 129;
                    Plantilla.Recibo2_Pos = 6;
                    Plantilla.Decimal_Lon = 2;
                    Plantilla.Decimal_Pos = 108;
                    Plantilla.Monto_Lon = 12;
                    Plantilla.Monto_Pos = 96;
                    Plantilla.Recibo_Lon = 6;
                    Plantilla.Recibo_Pos = 129;
                    Plantilla.FechaenCabecera = 0;
                    Plantilla.Indicador = "02";
                    Plantilla.FormatoFecha= "YYYYMMDD";
                    Plantilla.GenerarRecibo = 0;
                    break;
                case Banco.CJ_PIURA:
                    Plantilla.LineaInicio = 2;
                    Plantilla.Depositante_Pos = 62;
                    Plantilla.Depositante_Lon = 11;
                    Plantilla.Fecha_Pos = 162;
                    Plantilla.Fecha_Lon = 8;
                    Plantilla.Recibo1_Lon = 13;
                    Plantilla.Recibo1_Pos = 373;
                    Plantilla.Recibo2_Lon = 13;
                    Plantilla.Recibo2_Pos = 373;
                    Plantilla.Decimal_Lon = 2;
                    Plantilla.Decimal_Pos = 362;
                    Plantilla.Monto_Lon = 10;
                    Plantilla.Monto_Pos = 352;
                    Plantilla.Recibo_Lon = 13;
                    Plantilla.Recibo_Pos = 373;
                    Plantilla.FechaenCabecera = 0;
                    Plantilla.Indicador = "1 ";
                    Plantilla.FormatoFecha="DDMMYYYY";
                    Plantilla.GenerarRecibo = 0;
                    break;
                case Banco.SCOTIABANK:
                    Plantilla.LineaInicio = 1;
                    Plantilla.Depositante_Pos = 75;
                    Plantilla.Depositante_Lon = 9;
                    Plantilla.Fecha_Pos = 140;
                    Plantilla.Fecha_Lon = 8;
                    Plantilla.Recibo1_Lon = 1;
                    Plantilla.Recibo1_Pos = 1;
                    Plantilla.Recibo2_Lon = 1;
                    Plantilla.Recibo2_Pos = 1;
                    Plantilla.Decimal_Lon = 2;
                    Plantilla.Decimal_Pos = 58;
                    Plantilla.Monto_Lon = 10;
                    Plantilla.Monto_Pos = 47;
                    Plantilla.Recibo_Lon = 1;
                    Plantilla.Recibo_Pos = 1;
                    Plantilla.FechaenCabecera = 0;
                    Plantilla.Indicador = "00";
                    Plantilla.FormatoFecha = "YYYYMMDD";
                    Plantilla.GenerarRecibo = 1;
                    break;
                default:
                    Plantilla.LineaInicio = 2;
                    Plantilla.Depositante_Pos = 13;
                    Plantilla.Depositante_Lon = 14;
                    Plantilla.Fecha_Pos = 57;
                    Plantilla.Fecha_Lon = 8;
                    Plantilla.Recibo1_Lon = 7;
                    Plantilla.Recibo1_Pos = 226;
                    Plantilla.Recibo2_Lon = 7;
                    Plantilla.Recibo2_Pos = 196;
                    Plantilla.Decimal_Lon = 2;
                    Plantilla.Decimal_Pos = 86;
                    Plantilla.Monto_Lon = 13;
                    Plantilla.Monto_Pos = 73;
                    Plantilla.Recibo_Lon = 7;
                    Plantilla.Recibo_Pos = 201;
                    Plantilla.FechaenCabecera = 0;
                    Plantilla.Indicador = "DD";
                    break;
            }
            return Plantilla;
        }
        public static List<CA_ListaCampos> RetornaDataBanco(string archivo, Banco banco, out string respuesta)
        {
            string Codigovendedor="";
            string FechaPago="";
            string NumRecibo="";
            double MontoPago = 0;
            int recorrer = 0;
            Int16 filasvalidas = 0;
            DateTime FechapagoDT = DateTime.Now;
            Int64 NumEntero;
            int NumDecimal;

            CA_ConfigBancos PlantillaBanco = new CA_ConfigBancos();
            PlantillaBanco = ConfigurarPlantilla(banco);


            List<CA_ListaCampos> listaData = new List<CA_ListaCampos>();
            
            try
            {
                if (File.Exists(archivo))
                {
                    using (StreamReader lector = new StreamReader(archivo.ToString()))
                    {
                        while (lector.Peek() > -1)
                        {
                            string linea = lector.ReadLine();
                            if (!String.IsNullOrEmpty(linea))
                            {

                                Codigovendedor = "";
                                FechaPago = "";
                                NumRecibo = "";
                                MontoPago = 0;
                                recorrer += 1;
                                NumEntero = 0;
                                NumDecimal = 0;

                                if (recorrer ==1 && PlantillaBanco.FechaenCabecera==1)
                                {
                                    FechaPago = linea.Substring(PlantillaBanco.Fecha_Pos, PlantillaBanco.Fecha_Lon);
                                    if (PlantillaBanco.FormatoFecha == "YYYYMMDD")
                                    {
                                        FechaPago = FechaPago.Substring(6, 2) + "/" + FechaPago.Substring(4, 2) + "/" + FechaPago.Substring(0, 4);
                                    }
                                    else
                                    {
                                        FechaPago = FechaPago.Substring(0, 2) + "/" + FechaPago.Substring(2, 2) + "/" + FechaPago.Substring(4, 4);
                                    }

                                    FechapagoDT = Convert.ToDateTime(FechaPago);
                                    NumRecibo = linea.Substring(PlantillaBanco.Recibo_Pos, PlantillaBanco.Recibo_Lon);
                                }


                                if (linea.Substring(0, 2) == PlantillaBanco.Indicador)
                                {
                                    if (PlantillaBanco.FechaenCabecera == 0)
                                    {
                                        FechaPago = linea.Substring(PlantillaBanco.Fecha_Pos, PlantillaBanco.Fecha_Lon);
                                        if (PlantillaBanco.FormatoFecha == "YYYYMMDD")
                                        {
                                            FechaPago = FechaPago.Substring(6, 2) + "/" + FechaPago.Substring(4, 2) + "/" + FechaPago.Substring(0, 4);
                                        }
                                        else
                                        {
                                            FechaPago = FechaPago.Substring(0, 2) + "/" + FechaPago.Substring(2, 2) + "/" + FechaPago.Substring(4, 4);
                                        }
                                            FechapagoDT = Convert.ToDateTime(FechaPago);
                                        NumRecibo = linea.Substring(PlantillaBanco.Recibo_Pos, PlantillaBanco.Recibo_Lon);
                                        if (NumRecibo.Trim().Length < 5)
                                        {
                                            NumRecibo = linea.Substring(PlantillaBanco.Recibo1_Pos, PlantillaBanco.Recibo1_Lon);
                                        }
                                        if (NumRecibo.Trim().Length < 5)
                                        {
                                            NumRecibo = linea.Substring(PlantillaBanco.Recibo2_Pos, PlantillaBanco.Recibo2_Lon);
                                        }

                                        if (PlantillaBanco.GenerarRecibo == 1)
                                        {
                                            NumRecibo = FechapagoDT.ToString("yyyyMMdd")  + DateTime.Now.ToString("hhmmss") + Codigovendedor;
                                        }

                                    }

                                    NumEntero = Convert.ToInt64(linea.Substring(PlantillaBanco.Monto_Pos, PlantillaBanco.Monto_Lon));
                                    long number1 = 0;
                                    bool canConvert = long.TryParse(linea.Substring(PlantillaBanco.Decimal_Pos, PlantillaBanco.Decimal_Lon), out number1);

                                    if (canConvert)
                                    {
                                        NumDecimal = Convert.ToInt16(linea.Substring(PlantillaBanco.Decimal_Pos, PlantillaBanco.Decimal_Lon));
                                        MontoPago = Convert.ToDouble(NumEntero + "." + NumDecimal);
                                    }
                                    else
                                    {
                                        MontoPago = Convert.ToDouble(MontoPago);
                                    }

                                    Codigovendedor = Convert.ToString(linea.Substring(PlantillaBanco.Depositante_Pos, PlantillaBanco.Depositante_Lon));
                                    if (Codigovendedor.Substring(0, 1) == "0")
                                    {
                                        if (Codigovendedor.Length >= 10)
                                        {
                                            Codigovendedor = Codigovendedor.Substring(1, 10);
                                        }
                                        else
                                        {
                                            Codigovendedor = Codigovendedor.Substring(1, 8);
                                        }
                                            if (Codigovendedor.Substring(0, 1) == "0" && PlantillaBanco.GenerarRecibo == 0)
                                        {
                                            Codigovendedor = Codigovendedor.Substring(2, 8);
                                        }
                                    }
                                    Codigovendedor = Codigovendedor.Trim();

                                    if (Codigovendedor.Length > 10)
                                    {
                                        if (Codigovendedor.Substring(0, 1) == "0")
                                        {
                                            Codigovendedor = Codigovendedor.Substring(1, 10);
                                            if (Codigovendedor.Substring(0, 1) == "0")
                                            {
                                                Codigovendedor = Codigovendedor.Substring(2, 8);
                                            }
                                        }
                                    }

                                }

                                /// VALIDAR SI HAY DATOS
                                if (Codigovendedor != "" && MontoPago !=0 && NumRecibo != "" )
                                {
                                    CA_ListaCampos Data = new CA_ListaCampos();
                                    Data.bancodeposito = banco.ToString();
                                    Data.depositante = Codigovendedor;
                                    Data.fechadeposito = FechapagoDT.ToString("yyyy-MM-dd");
                                    Data.montodeposito = MontoPago.ToString();
                                    Data.recibobanco = NumRecibo;
                                    listaData.Add(Data);
                                    filasvalidas += 1;


                                }


                            }
                        }

                        if (recorrer > 0)
                        {
                            respuesta = "Se leyeron " + (filasvalidas).ToString() + " registros";
                        }
                        else
                        {
                            respuesta = "Archivo Vacío ";
                        }
                    }
                    return listaData;


                }
                else
                {
                    respuesta = "No existe el archivo";
                    return null;
                }
            }

            catch (Exception ex)
            {
                respuesta = ex.ToString();
                return null;
            }
        }
         
    }
}
