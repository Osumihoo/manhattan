using manhattan.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static manhattan.Bodys;

namespace manhattan
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        //public Bodys.Response CreateOV(Bodys.Orders orden)
        //{
        //    try
        //    {
        //        Bodys.Response response = Functions.CreateOV(orden);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

        //public Bodys.Response CreateOC(Bodys.Purchases purchases)
        //{
        //    try
        //    {
        //        Bodys.Response response = Functions.CreateOC(purchases);
        //        return response;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public Bodys.Response LoginSDK(Bodys.Login login)
        //{
        //    try
        //    {
        //        SAPbobsCOM.Company oCompany = Functions.LoginSDK(login);
        //        Bodys.Response resp = new Bodys.Response();

        //        return resp;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public Bodys.Response OperateStockTransferApproval(Bodys.OperateStockTransferApproval OSTA)
        //{
        //    try
        //    {
        //        Bodys.Response transfer = Functions.OperateStockTransferApproval(OSTA);

        //        return transfer;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public Bodys.Response CreateMR(Bodys.MerchandesHeader CMR)
        //{
        //    try
        //    {
        //        Bodys.Response response = Functions.CreateMR(CMR);
        //        return response;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public Bodys.Response CreateMRSL(MerchandesSlayer CMRSL)
        {
            try
            {

                Bodys.Response response = Functions.CreateMRSL(CMRSL);
                return response;

            }
            catch (Exception ex)
            {
                //manhattan.Logs.Logs.LogSinConexion(ex.ToString());

                return null;
            }
        }

        public Bodys.Response OperateStockTransferApprovalSL(StockTransferSlayer OSTASL)
        {
            try
            {
                Bodys.Response response = Functions.OperateStockTransferApprovalSL(OSTASL);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Bodys.Response GetAEL(Bodys.AbsEntryLocation AEL)
        {
            try
            {
                Bodys.Response response = Functions.GetAEL(AEL);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Bodys.Response GetOBCL(Bodys.OneBinCodeLocation OBCL)
        {
            try
            {
                Bodys.Response response = Functions.GetOBCL(OBCL);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Bodys.Response GetBC(Bodys.BinCodeLocation BCL)
        {
            try
            {
                Bodys.Response response = Functions.GetBC(BCL);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Bodys.Response GetBED(Bodys.BatchExpDate BED)
        {
            try
            {
                Bodys.Response response = Functions.GetBED(BED);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Bodys.Response GetWPO(Bodys.WhsPurchasesOrders WPO)
        {
            try
            {
                Bodys.Response response = Functions.GetWPO(WPO);
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
