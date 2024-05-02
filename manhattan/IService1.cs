using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using static manhattan.Bodys;

namespace manhattan
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        //[OperationContract]
        //[WebInvoke(UriTemplate="Orders", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Bodys.Response CreateOV(Bodys.Orders orden );

        //[OperationContract]
        //[WebInvoke(UriTemplate = "Purchases", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Bodys.Response CreateOC(Bodys.Purchases purchases);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "Login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Bodys.Response LoginSDK(Bodys.Login login);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "OperateStockTransferApproval", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Bodys.Response OperateStockTransferApproval(Bodys.OperateStockTransferApproval OSTA);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "merchandiseReceipt", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       
        //Bodys.Response CreateMR(Bodys.MerchandesHeader CMR);

        [OperationContract]
        [WebInvoke(UriTemplate = "merchandiseReceiptSL", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        Bodys.Response CreateMRSL(MerchandesSlayer CMRSL);

        [OperationContract]
        [WebInvoke(UriTemplate = "OperateStockTransferApprovalSL", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        Bodys.Response OperateStockTransferApprovalSL(StockTransferSlayer OSTASL);

        [OperationContract]
        [WebInvoke(UriTemplate = "AbsEntryLocation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Bodys.Response GetAEL(Bodys.AbsEntryLocation AEL);
        
        [OperationContract]
        [WebInvoke(UriTemplate = "OneBinCodeLocation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Bodys.Response GetOBCL(Bodys.OneBinCodeLocation OBCL);

        [OperationContract]
        [WebInvoke(UriTemplate = "BinCodeLocation", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Bodys.Response GetBC(Bodys.BinCodeLocation BCL);

        [OperationContract]
        [WebInvoke(UriTemplate = "BatchExpDate", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Bodys.Response GetBED(Bodys.BatchExpDate BED);

        [OperationContract]
        [WebInvoke(UriTemplate = "WhsPurchasesOrders", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Bodys.Response GetWPO(Bodys.WhsPurchasesOrders WPO);
    }
}
