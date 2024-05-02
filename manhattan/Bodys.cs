using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;

namespace manhattan
{
    public class Bodys
    {
        public static string folderPatchAño = @""+ manhattan.Properties.Settings.Default.folderPatch;
        public static string pathArchivoDia = folderPatchAño + "\\" + DateTime.Now.ToString("yyyy") +" "+ DateTime.Now.ToString("M") + ".txt";   // Variable de carpeta archivo del dia

        public class Items
        {
            public string ItemCode { get; set; }
        }

        //[Serializable]
        public class Orders
        {
            public int DocEntry  { get; set; }
        }
        public class Response
        {
            public string DocEntry { get; set; }
            public string DocNum { get; set; }
            public string AbsEntry { get; set; }
            public string ExpDate { get; set; }
            public List<Conflicts> conflicts { get; set; }
            public List<BinCodeLocation> ubications { get; set; }
            public List<PurcharsesOrdersOpen> purcharsesOrders { get; set;}
            public List<PabloDocNIds> pabloDocNIds { get; set; }
            public List<NewLines> NewLines { get; set; }
            //public List<MerchandesSlayer> MerchandesSlayer { get; set; }

            //public List<Array>d { get; set;}
        }

        public class Conflicts
        {
            public bool Problems { get; set; }
            public string Description { get; set; }
            public bool Item { get; set; } = false;

        }

        public class NewLines
        {
            //public int DocEntry { get; set; }
            public int BaseLine { get; set; }
            public string LineStatus { get; set; }
        }

        public class PabloDocNIds
        {
            public string docEntry { get; set; }
            public int Id { get; set; }
        }
        public class PurcharsesOrdersOpen
        {
            public int DocEntry { get; set; }
            public int DocNum { get; set; }
            public string CardCode { get; set; }
            public string CardName { get; set; }
            public string DocDate { get; set; }
            public string EntradaAut { get; set; }
            public List<PurchasesOrdersOpenDetails> details { get; set; }
        }

        public class PurchasesOrdersOpenDetails
        {
            public string WhsCode { get; set; }
            public int LineNum { get; set; }
            public string ItemCode { get; set; }
            public string Description { get; set; }
            public string CodeBars { get; set; }
            public double Quantity { get; set; }
            public string LineStatus { get; set; }
        }

        public class Purchases
        {
            public string CardCode { get; set; }
            public string SalesPersonCode { get; set; }
            //public DateTime DocDueDate { get; set; }
            //public DateTime RequriedDate { get; set; }
            public string U_MetodoPago { get; set; }
            public string Comments { get; set; }
            public string U_Sucursal { get; set; }
            public List<DocumentLinesSDK> DocumentLinesSDK { get; set; }
        }

        public class DocumentLinesSDK
        {
            public string ItemCode { get; set; }
            public double Quantity { get; set; }
            public string TaxCode { get; set; }
            public string DiscountPercent { get; set; }
            public double UnitPrice { get; set; }
            public string ListNum { get; set; }

        }

        //public class Login
        //{
        //    public string User { get; set; }
        //    public string Pwd { get; set; }
        //}

        public class OperateStockTransferApproval
        {

            public string FromWarehouseCode { get; set; }
            public List<OperateStockTransferApprovalData> data { get; set; }


        }
        public class OperateStockTransferApprovalData
        {

            
            public string WarehouseCode { get; set; }
            public string ItemCode { get; set; }
            public int Quantity { get; set; }

            public List<OperateStockTransferApprovalBatch> batch { get; set; }
            //public List<OperateStockTransferApprovalBinTo> binTo { get; set; }
            //public List<OperateStockTransferApprovalBinFrom> binFrom { get; set; }

        }

        public class OperateStockTransferApprovalBatch
        {

            public int Quantity { get; set; }
            public string BatchNumber { get; set; }
            public int BinLocation { get; set; }
            public int FromBinLocation { get; set; }



        }
        public class OperateStockTransferApprovalBinTo
        {
            public int BinLocation { get; set; }
            public int Quantity { get; set; }

        }
        public class OperateStockTransferApprovalBinFrom
        {
            public int FromBinLocation { get; set; }
            public int Quantity { get; set; }

        }

        //public class OperateStockTransferApprovalBatch
        //{

        //    public string CardCode { get; set; }
        //    public string ItemCode { get; set; }
        //    public int Quantity { get; set; }
        //    public string FromWarehouseCode { get; set; }
        //    public string WarehouseCode { get; set; }
        //    public string BatchNumber { get; set; }
        //    public int FromBinLocation { get; set; }
        //    public int BinLocation { get; set; }


        //}
        
        public class MerchandesHeader
        {
            //public string alm { get; set; }
            public List<MerchandesiInfo> headers { get; set; }
        }


        public class MerchandesiInfo
        {
            public List<IdsPablito> idsp { get; set; }
            public int docEntry { get; set; }
            public int DocNum { get; set; }
            public string user { get; set; }
            public string almacen { get; set; }
            public string CardCode { get; set; }
            public List<MerchandesiData> data { get; set; }
        }
        public class IdsPablito
        {
            public int ids { get; set; }
        }

        public class MerchandesiData
        {
            public string ItemCode { get; set; }
            public int Quantity { get; set; }
            public int BaseEntry { get; set; }
            public int BaseLine { get; set; }
            public int Warehouse { get; set; }
            public string U_Sucursal { get; set; }
            public List<MerchandesiContent> content { get; set; }
        }

        public class MerchandesiContent
        {
            public string BatchNumber { get; set; }
            public int Quantity { get; set; }
            public string ExpiryDate { get; set; }
            public int binAbsEntry { get; set; }
            public int serialAndBatchNumbersBaseLine { get; set; }
            public int baseLineNumber { get; set; }

        }

        public class AbsEntryLocation
        {
            public string bincode { get; set; }
        }

        public class OneBinCodeLocation
        {
            public string AbsEntry { get; set; }
        }

        public class BinCodeLocation
        {
            public string BinCode { get; set; }
        }

        public class BatchExpDate
        {
            public string Batch { get; set; }
            public string WhsCode { get; set; }
            public string ItemCode { get; set; }
        }

        public class WhsPurchasesOrders
        {
            public string WhsCode { get; set; }
        }

        public class ValidateMail
        {
            public string email { get; set; }
        }

        public class ValidateMailResponse
        {
            public string input { get; set; }

            public List<Results> results { get; set; }
        }

        public class Results
        { 
            public int status { get; set; }
        }

        public class Login
        {
            public string CompanyDB { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
        }

        public class MerchandesSlayer
        {
            public string CardCode { get; set; }
            public string DocDate { get; set; }
            public List<DocumentLines> DocumentLines { get; set; }
        }

        public class DocumentLines
        {
            public string ItemCode { get; set; }
            public int Quantity { get; set; }
            public string BaseType { get; set; }
            public int BaseEntry { get; set; }
            public int BaseLine { get; set; }
            public string Warehouse { get; set; }
            public string U_Sucursal { get; set; }
            public string LineStatus { get; set; }

            public List<BatchNumbers> BatchNumbers { get; set; }

        }

        public class BatchNumbers
        {
            public string BatchNumber { get; set; }
            public int Quantity { get; set; }
            public string ExpiryDate { get; set; }
        }

        public class StockTransferSlayer
        {
            public List<StockTransferLines> StockTransferLines { get; set; }
        }


        public class StockTransferLines
        {
            public string WarehouseCode { get; set; }
            public string FromWarehouseCode { get; set; }
            public string ItemCode { get; set; }
            public int Quantity { get; set; }
            public List<BatchNumbers> BatchNumbers { get; set; }
            public List<StockTransferLinesBinAllocations> StockTransferLinesBinAllocations { get; set; }
        }

        public class StockTransferLinesBinAllocations
        {
            public int BinAbsEntry { get; set; }
            public int Quantity { get; set; }
            public string AllowNegativeQuantity { get; set; }
            public int SerialAndBatchNumbersBaseLine { get; set; }
            public int BinActionType { get; set; }
            public int BaseLineNumber { get; set; }

        }
    }
}