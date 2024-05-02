using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;
using manhattan.Properties;
using SAPbobsCOM;

namespace manhattan
{
    public class ConexionSAP
    {

        public static SAPbobsCOM.Company Open()
        {
            //public static Company Company = null;
            SAPbobsCOM.Company oCompany = null;
            try
            {

                oCompany = new SAPbobsCOM.Company();
                oCompany.Server = Settings.Default.Server;
                oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                oCompany.CompanyDB = Settings.Default.CompanyDB;
                oCompany.UserName = Settings.Default.UserName;
                oCompany.Password = Settings.Default.Password;

                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

                //SAPbobsCOM.Documents oPurchaseOrders = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes);

                return oCompany;

                
            }
            catch (Exception)
            {
                return oCompany;
                //throw;
            }
        }

    }
}