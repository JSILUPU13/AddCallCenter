using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.Distribucion.DAL;

namespace Vistony.Distribucion.BLL
{
    public class DataBLL
    {
        public static void getData(ref DataTable data, string usuario)
        {
            try
            {
                string query = string.Format("CALL P_VIST_CALL_SEMAFORO_WORK_NEW_V2('{0}')",usuario);
                using (Vistony.Distribucion.DAL.DataDAL dt = new DataDAL())
                {
                    dt.CallSemaforo(data, query);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
