using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPbobsCOM;

namespace manhattan
{
    public class Conexion
    {
        public static Company Company = null;
        static SAPbobsCOM.Company oCompany = null;

        public static bool Open()
        {
            try
            {
                bool Respuesta = false;

                oCompany = new SAPbobsCOM.Company();
                Console.WriteLine("Preparando...");

                //Nombre o Ip del servidor
                oCompany.Server = "NDB@hanab1:30001";

                oCompany.CompanyDB = "SB1CSL";

                oCompany.UserName = "Desarrollo";
                oCompany.Password = "123456";
                oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;

                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

                var lRetCode = "";

                lRetCode = oCompany.Connect();

                if (lRetCode != 0)
                {
                    sErrMsg = oCompany.GetLastErrorDescription();
                    return "Error al conectar a SAP" + sErrMsg;
                }
                else
                {
                    return "Conexion exitosa";
                }
                return Respuesta;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}