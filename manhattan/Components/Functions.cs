using manhattan.Properties;
using Newtonsoft.Json;
using Sap.Data.Hana;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static manhattan.Bodys;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
//using System.Net.Http;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Net.NetworkInformation;
//using System.Reflection;
//using System.Threading.Tasks;

namespace manhattan.Components
{
    public class Functions
    {
        static string sErrMsg = "";
        static long lRetCode;
        static string retKey = "0";
        static string retType = "0";
        static long retcode = 0;
        public static SAPbobsCOM.Company oCompany = null;

        //Thread backgroundThread = new Thread(new ThreadStart(Bodys.Response CreateMR(Bodys.MerchandesHeader CMR)));

        //public static Bodys.Response OperateStockTransferApproval(Bodys.OperateStockTransferApproval OSTA)
        //{
        //    Bodys.Response resp = new Bodys.Response();
        //    //'Prerequisites: You have set ApprovalTemplates and ApprovalStage by DI or SAP Business One 

        //    int retcode = 0;
        //    string msg = "";
        //    oCompany = new SAPbobsCOM.Company();

        //    Bodys.Login login = new Bodys.Login();

        //    //Login login1 = new Login();

        //    List<Bodys.Login> logins = new List<Bodys.Login>();


        //    DataTable dtServiceLayer = new DataTable();
        //    string IDss = string.Empty;
        //    //if(OSTA.FromWarehouseCode.Equals(01))
        //    //{

        //    //}
        //    try
        //    {
        //        switch (OSTA.FromWarehouseCode)
        //        {
        //            case "01":
        //                Console.WriteLine("GDL");
        //                //oCompany.Server = Settings.Default.Server;

        //                //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                //oCompany.UserName = Settings.Default.Almacen01User;
        //                //oCompany.Password = Settings.Default.Almacen01Pass;

        //                //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;

        //                ////oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English;

        //                //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;


        //                login.CompanyDB = Settings.Default.CompanyDB;
        //                login.Password = Settings.Default.Almacen01Pass;
        //                login.UserName = Settings.Default.Almacen01User;

        //                logins.Add(login);
        //                try
        //                {

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();

        //                    /////////////////////////////////////////////////////////////
        //                    ///
        //                    string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                    string url = "https://hanab1:50000/b1s/v1/Login";
        //                    string json = string.Empty;

        //                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.KeepAlive = true;
        //                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                    httpWebRequest.Accept = "*/*";
        //                    httpWebRequest.ServicePoint.Expect100Continue = false;
        //                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                    httpWebRequest.Method = "POST";

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    { streamWriter.Write(data); }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    //B1Session obj = null;            

        //                    var result = string.Empty;
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        result = streamReader.ReadToEnd();
        //                    }

        //                    json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                    dtServiceLayer = new DataTable();
        //                    dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));                            
        //                    IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                }

        //                catch (Exception ex)
        //                {
        //                    string mensg = ex.ToString();
        //                    Bodys.Conflicts c = new Bodys.Conflicts();
        //                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //                    resp.conflicts = new List<Bodys.Conflicts>();
        //                    c.Problems = true;
        //                    c.Description = "Error al conectar con SAP: " + ex.Message;

        //                    conflicts.Add(c);
        //                    resp.conflicts = conflicts;
        //                    oCompany.Disconnect();
        //                    return resp;
        //                }



        //                break;
        //            case "02":
        //                //Console.WriteLine("CDMX");
        //                //oCompany.Server = Settings.Default.Server;

        //                //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                //oCompany.UserName = Settings.Default.Almacen02User;
        //                //oCompany.Password = Settings.Default.Almacen02Pass;

        //                //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                login.CompanyDB = Settings.Default.CompanyDB;
        //                login.Password = Settings.Default.Almacen02Pass;
        //                login.UserName = Settings.Default.Almacen02User;

        //                logins.Add(login);
        //                try
        //                {

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();

        //                    /////////////////////////////////////////////////////////////
        //                    ///
        //                    string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                    string url = "https://hanab1:50000/b1s/v1/Login";
        //                    string json = string.Empty;

        //                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.KeepAlive = true;
        //                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                    httpWebRequest.Accept = "*/*";
        //                    httpWebRequest.ServicePoint.Expect100Continue = false;
        //                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                    httpWebRequest.Method = "POST";

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    { streamWriter.Write(data); }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    //B1Session obj = null;            

        //                    var result = string.Empty;
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        result = streamReader.ReadToEnd();
        //                    }

        //                    json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                    dtServiceLayer = new DataTable();
        //                    dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                    IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                }

        //                catch (Exception ex)
        //                {
        //                    string mensg = ex.ToString();
        //                    Bodys.Conflicts c = new Bodys.Conflicts();
        //                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //                    resp.conflicts = new List<Bodys.Conflicts>();
        //                    c.Problems = true;
        //                    c.Description = "Error al conectar con SAP: " + ex.Message;

        //                    conflicts.Add(c);
        //                    resp.conflicts = conflicts;
        //                    oCompany.Disconnect();
        //                    return resp;
        //                }

        //                break;
        //            case "03":
        //                //Console.WriteLine("PUEBLA");
        //                //oCompany.Server = Settings.Default.Server;

        //                //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                //oCompany.UserName = Settings.Default.Almacen03User;
        //                //oCompany.Password = Settings.Default.Almacen03Pass;

        //                //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                login.CompanyDB = Settings.Default.CompanyDB;
        //                login.Password = Settings.Default.Almacen03Pass;
        //                login.UserName = Settings.Default.Almacen03User;

        //                logins.Add(login);
        //                try
        //                {

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();

        //                    /////////////////////////////////////////////////////////////
        //                    ///
        //                    string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                    string url = "https://hanab1:50000/b1s/v1/Login";
        //                    string json = string.Empty;

        //                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.KeepAlive = true;
        //                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                    httpWebRequest.Accept = "*/*";
        //                    httpWebRequest.ServicePoint.Expect100Continue = false;
        //                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                    httpWebRequest.Method = "POST";

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    { streamWriter.Write(data); }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    //B1Session obj = null;            

        //                    var result = string.Empty;
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        result = streamReader.ReadToEnd();
        //                    }

        //                    json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                    dtServiceLayer = new DataTable();
        //                    dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                    IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                }

        //                catch (Exception ex)
        //                {
        //                    string mensg = ex.ToString();
        //                    Bodys.Conflicts c = new Bodys.Conflicts();
        //                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //                    resp.conflicts = new List<Bodys.Conflicts>();
        //                    c.Problems = true;
        //                    c.Description = "Error al conectar con SAP: " + ex.Message;

        //                    conflicts.Add(c);
        //                    resp.conflicts = conflicts;
        //                    oCompany.Disconnect();
        //                    return resp;
        //                }


        //                break;
        //            case "04":
        //                //Console.WriteLine("MONTERREY");
        //                //oCompany.Server = Settings.Default.Server;

        //                //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                //oCompany.UserName = Settings.Default.Almacen04User;
        //                //oCompany.Password = Settings.Default.Almacen04Pass;

        //                //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                login.CompanyDB = Settings.Default.CompanyDB;
        //                login.Password = Settings.Default.Almacen04Pass;
        //                login.UserName = Settings.Default.Almacen04User;

        //                logins.Add(login);
        //                try
        //                {

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();

        //                    /////////////////////////////////////////////////////////////
        //                    ///
        //                    string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                    string url = "https://hanab1:50000/b1s/v1/Login";
        //                    string json = string.Empty;

        //                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.KeepAlive = true;
        //                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                    httpWebRequest.Accept = "*/*";
        //                    httpWebRequest.ServicePoint.Expect100Continue = false;
        //                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                    httpWebRequest.Method = "POST";

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    { streamWriter.Write(data); }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    //B1Session obj = null;            

        //                    var result = string.Empty;
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        result = streamReader.ReadToEnd();
        //                    }

        //                    json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                    dtServiceLayer = new DataTable();
        //                    dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                    IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                }

        //                catch (Exception ex)
        //                {
        //                    string mensg = ex.ToString();
        //                    Bodys.Conflicts c = new Bodys.Conflicts();
        //                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //                    resp.conflicts = new List<Bodys.Conflicts>();
        //                    c.Problems = true;
        //                    c.Description = "Error al conectar con SAP: " + ex.Message;

        //                    conflicts.Add(c);
        //                    resp.conflicts = conflicts;
        //                    oCompany.Disconnect();
        //                    return resp;
        //                }


        //                break;
        //            case "05":
        //                //Console.WriteLine("SALTO");
        //                //oCompany.Server = Settings.Default.Server;

        //                //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                ////oCompany.UserName = Settings.Default.Almacen05User;
        //                ////oCompany.Password = Settings.Default.Almacen05Pass;
        //                //oCompany.UserName = Settings.Default.Almacen05User;
        //                //oCompany.Password = Settings.Default.Almacen05Pass;

        //                //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                login.CompanyDB = Settings.Default.CompanyDB;
        //                login.Password = Settings.Default.Almacen05Pass; 
        //                login.UserName = Settings.Default.Almacen05User;

        //                logins.Add(login);
        //                try
        //                {

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();

        //                    /////////////////////////////////////////////////////////////
        //                    ///
        //                    string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                    string url = "https://hanab1:50000/b1s/v1/Login";
        //                    string json = string.Empty;

        //                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                    httpWebRequest.ContentType = "application/json";
        //                    httpWebRequest.KeepAlive = true;
        //                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                    httpWebRequest.Accept = "*/*";
        //                    httpWebRequest.ServicePoint.Expect100Continue = false;
        //                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                    httpWebRequest.Method = "POST";

        //                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                    { streamWriter.Write(data); }

        //                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                    //B1Session obj = null;            

        //                    var result = string.Empty;
        //                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                    {
        //                        result = streamReader.ReadToEnd();
        //                    }

        //                    json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                    dtServiceLayer = new DataTable();
        //                    dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                    IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                }

        //                catch (Exception ex)
        //                {
        //                    string mensg = ex.ToString();
        //                    Bodys.Conflicts c = new Bodys.Conflicts();
        //                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //                    resp.conflicts = new List<Bodys.Conflicts>();
        //                    c.Problems = true;
        //                    c.Description = "Error al conectar con SAP: " + ex.Message;

        //                    conflicts.Add(c);
        //                    resp.conflicts = conflicts;
        //                    oCompany.Disconnect();
        //                    return resp;
        //                }


        //                break;
        //            default:
        //                Console.WriteLine("Inserta un almacen valido");
        //                break;


        //        }

        //        //oCompany.Server = Settings.Default.Server;

        //        //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //        //oCompany.UserName = Settings.Default.UserNameDos;
        //        //oCompany.Password = Settings.Default.PasswordDos;

        //        //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //        //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
        //        //  oCompany.SLDServer = "hanab1:30015";


        //        //lRetCode = oCompany.Connect();

        //        //if (lRetCode != 0)
        //        //{
        //        //    sErrMsg = oCompany.GetLastErrorDescription();
        //        //    Console.WriteLine("Error al conectar a SAP" + sErrMsg);
        //        //}
        //        //else
        //        //{
        //        //    Console.WriteLine("Conexion exitosa");
        //        //}

        //        //SAPbobsCOM.Company oCompany = ConexionSAP.Open();
        //        //retcode =  oCompany.Connect();
        //        //oCompanyService = ConexionSAP.GetCompanyService();
        //        //oAdminInfo = ConexionSAP.Company.GetCompanyService().GetAdminInfo();



        //        //'Create StockTransfer which will trigger the approval procedure 

        //        string retKey = "";
        //        string retType = "0";

        //        //////////////////////SERVICE LAYER
        //        string data2 = "{ " +
        //                            "\"StockTransferLines\":[ " +
        //                                "{ " +
        //                                    "\"WarehouseCode\":\"01\", " +
        //                                    "\"FromWarehouseCode\":\"01\", " +
        //                                    "\"ItemCode\":\"ADE-ATOD0001\", " +
        //                                    "\"Quantity\":1, " +
        //                                    "\"BatchNumbers\": [ " +
        //                                        "{ " +
        //                                            "\"BatchNumber\": \"1324\", " +
        //                                            "\"Quantity\": 1, " +
        //                                        "} " +
        //                                    "], " +
        //                                    "\"StockTransferLinesBinAllocations\":[ " +
        //                                        "{ " +
        //                                            "\"BinAbsEntry\": \"2240\", " +
        //                                            "\"Quantity\":1, " +
        //                                            "\"AllowNegativeQuantity\": \"N\", " +
        //                                            "\"SerialAndBatchNumbersBaseLine\": \"0\", " +
        //                                            "\"BinActionType\": 2, " +
        //                                            "\"BaseLineNumber\": 0 " +
        //                                        "}, " +
        //                                        "{ " +
        //                                            "\"BinAbsEntry\": \"1157\", " +
        //                                            "\"Quantity\":1, " +
        //                                            "\"AllowNegativeQuantity\": \"N\", " +
        //                                            "\"SerialAndBatchNumbersBaseLine\": \"0\", " +
        //                                            "\"BinActionType\": 1, " +
        //                                            "\"BaseLineNumber\": 0 " +
        //                                        "} " +
        //                                    "] " +
        //                                "} " +
        //                            "] " +
        //                    "}";
        //        string url2 = "https://hanab1:50000/b1s/v1/StockTransfers";
        //        string json2 = string.Empty;

        //        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url2);
        //        httpWebRequest2.Method = "POST";
        //        httpWebRequest2.ContentType = "application/json";
        //        httpWebRequest2.KeepAlive = true;
        //        httpWebRequest2.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //        httpWebRequest2.Headers.Add("B1S-WCFCompatible", "true");
        //        httpWebRequest2.Headers.Add("B1S-MetadataWithoutSession", "true");
        //        httpWebRequest2.Accept = "*/*";
        //        httpWebRequest2.ServicePoint.Expect100Continue = false;
        //        httpWebRequest2.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //        httpWebRequest2.AutomaticDecompression = DecompressionMethods.GZip;
        //        CookieContainer cookies2 = new CookieContainer();
        //        cookies2.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
        //        cookies2.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
        //        httpWebRequest2.CookieContainer = cookies2;

        //        using (var streamWriter = new StreamWriter(httpWebRequest2.GetRequestStream()))
        //        { streamWriter.Write(data2); }

        //        var httpResponse3 = (HttpWebResponse)httpWebRequest2.GetResponse();

        //        var result2 = string.Empty;
        //        using (var streamReader = new StreamReader(httpResponse3.GetResponseStream()))
        //        {
        //            result2 = streamReader.ReadToEnd();
        //        }

        //        //json2 = "[" + result2.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //        //DataTable dtServiceLayerR = new DataTable();
        //        //dtServiceLayerR = (DataTable)JsonConvert.DeserializeObject(json2.Trim(), (typeof(DataTable)));
        //        //resp.DocEntry = dtServiceLayerR.Rows[0]["DocEntry"].ToString();

        //        //Bodys.Response persona = JsonSerializer.Deserialize<Bodys.Response>(json2);

        //        JObject jsonObject = JObject.Parse(result2);
        //        //JArray jsonArray = JArray.Parse(result2);

        //        //foreach (JObject jsonObject in jsonArray)
        //        //{
        //        //    string DocEntry = (string)jsonObject["DocEntry"];
        //        //    resp.DocEntry = DocEntry;
        //        //}

        //        string DocEntry = (string)jsonObject["DocEntry"];
        //        resp.DocEntry = DocEntry;

        //        return resp;
        //        /////////////////////////////////




        //        //StockTaking oStockTakings = oCompany.GetBusinessObject(BoObjectTypes.oStockTakings);
        //        //StockTransfer oStockTransfer = oCompany.GetBusinessObject(BoObjectTypes.oStockTransfer);


        //        //oStockTransfer.FromWarehouse = OSTA.FromWarehouseCode;


        //        //oStockTransfer.Lines.WarehouseCode = OSTA.data[0].WarehouseCode;
        //        //oStockTransfer.Lines.ItemCode = OSTA.data[0].ItemCode;
        //        //oStockTransfer.Lines.Quantity = OSTA.data[0].Quantity;



        //        //oStockTransfer.Lines.BatchNumbers.Quantity = OSTA.data[0].batch[0].Quantity;
        //        //oStockTransfer.Lines.BatchNumbers.BatchNumber = OSTA.data[0].batch[0].BatchNumber;
        //        //oStockTransfer.Lines.BatchNumbers.Add();

        //        //oStockTransfer.Lines.BinAllocations.BinAbsEntry = OSTA.data[0].batch[0].BinLocation;
        //        //oStockTransfer.Lines.BinAllocations.Quantity = OSTA.data[0].batch[0].Quantity;
        //        //oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
        //        //oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
        //        //oStockTransfer.Lines.BinAllocations.BaseLineNumber = 0;
        //        //oStockTransfer.Lines.BinAllocations.Add();


        //        //oStockTransfer.Lines.BinAllocations.BinAbsEntry = OSTA.data[0].batch[0].FromBinLocation;
        //        //oStockTransfer.Lines.BinAllocations.Quantity = OSTA.data[0].batch[0].Quantity;
        //        //oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
        //        //oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batToWarehouse;
        //        //oStockTransfer.Lines.BinAllocations.BaseLineNumber = 0;
        //        //oStockTransfer.Lines.BinAllocations.Add();

        //        //oStockTransfer.Add();

        //        //lRetCode = oStockTransfer.Add();




        //        /*PUREBA 1*/
        //        //int line = 0, bin = 0;
        //        //oStockTransfer.FromWarehouse = OSTA.FromWarehouseCode;
        //        //oStockTransfer.ToWarehouse = OSTA.FromWarehouseCode;
        //        //foreach (var item in OSTA.data)
        //        //{
        //        //    oStockTransfer.Lines.WarehouseCode = item.WarehouseCode;
        //        //    oStockTransfer.Lines.FromWarehouseCode = item.WarehouseCode; 
        //        //    oStockTransfer.Lines.ItemCode = item.ItemCode;
        //        //    oStockTransfer.Lines.Quantity = item.Quantity;
        //        //    bin = 0;
        //        //    foreach (var itemBatch in item.batch)
        //        //    {
        //        //        oStockTransfer.Lines.BatchNumbers.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BatchNumbers.BatchNumber = itemBatch.BatchNumber;
        //        //        oStockTransfer.Lines.BatchNumbers.Add();

        //        //        oStockTransfer.Lines.BinAllocations.BinAbsEntry = itemBatch.BinLocation;
        //        //        oStockTransfer.Lines.BinAllocations.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //        oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = bin;
        //        //        oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
        //        //        oStockTransfer.Lines.BinAllocations.BaseLineNumber = line;
        //        //        oStockTransfer.Lines.BinAllocations.Add();


        //        //        oStockTransfer.Lines.BinAllocations.BinAbsEntry = itemBatch.FromBinLocation;
        //        //        oStockTransfer.Lines.BinAllocations.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //        oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = bin;
        //        //        oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batToWarehouse;
        //        //        oStockTransfer.Lines.BinAllocations.BaseLineNumber = line;
        //        //        oStockTransfer.Lines.BinAllocations.Add();
        //        //        bin++;
        //        //    }
        //        //    oStockTransfer.Lines.Add();
        //        //    line++;
        //        //}
        //        //oStockTransfer.SaveXML("C:\\xml\\1.xml");
        //        //lRetCode = oStockTransfer.Add();

        //        //if (lRetCode != 0)
        //        //{
        //        //    //Log("Error - " + oCompany.GetLastErrorDescription().ToString());
        //        //    Bodys.Conflicts c = new Bodys.Conflicts();
        //        //    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //        //    resp.conflicts = new List<Bodys.Conflicts>();
        //        //    c.Problems = true;
        //        //    c.Description = "Error - " + oCompany.GetLastErrorDescription().ToString();


        //        //    conflicts.Add(c);
        //        //    resp.conflicts = conflicts;
        //        //    oCompany.Disconnect();
        //        //    return resp;
        //        //}
        //        //else
        //        //{
        //        //    resp.DocEntry = oCompany.GetNewObjectKey();

        //        //    oCompany.Disconnect();
        //        //    return resp;
        //        //}
        //        /*FIN PUREBA 1*/


        //        //oStockTransfer.FromWarehouse = OSTA.FromWarehouseCode;


        //        //foreach (var item in OSTA.data)
        //        //{
        //        //    oStockTransfer.Lines.WarehouseCode = item.WarehouseCode;
        //        //    oStockTransfer.Lines.ItemCode = item.ItemCode;
        //        //    oStockTransfer.Lines.Quantity = item.Quantity;

        //        //    foreach (var itemBatch in item.batch)
        //        //    {
        //        //        oStockTransfer.Lines.BatchNumbers.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BatchNumbers.BatchNumber = itemBatch.BatchNumber;
        //        //        oStockTransfer.Lines.BatchNumbers.Add();

        //        //        oStockTransfer.Lines.BinAllocations.BinAbsEntry = itemBatch.BinLocation;
        //        //        oStockTransfer.Lines.BinAllocations.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //        oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
        //        //        oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
        //        //        oStockTransfer.Lines.BinAllocations.BaseLineNumber = 0;
        //        //        oStockTransfer.Lines.BinAllocations.Add();

        //        //        oStockTransfer.Lines.BinAllocations.BinAbsEntry = itemBatch.FromBinLocation;
        //        //        oStockTransfer.Lines.BinAllocations.Quantity = itemBatch.Quantity;
        //        //        oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //        oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
        //        //        oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
        //        //        oStockTransfer.Lines.BinAllocations.BaseLineNumber = 0;
        //        //        oStockTransfer.Lines.BinAllocations.Add();
        //        //    }
        //        //    //foreach (var itemBinTo in item.binTo)
        //        //    //{
        //        //    //}
        //        //    //foreach (var itemBinFrom in item.binFrom)
        //        //    //{
        //        //    //    oStockTransfer.Lines.BinAllocations.BinAbsEntry = itemBinFrom.FromBinLocation;
        //        //    //    oStockTransfer.Lines.BinAllocations.Quantity = itemBinFrom.Quantity;
        //        //    //    oStockTransfer.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //        //    //    oStockTransfer.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
        //        //    //    oStockTransfer.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
        //        //    //    oStockTransfer.Lines.BinAllocations.BaseLineNumber = 0;
        //        //    //    oStockTransfer.Lines.BinAllocations.Add();
        //        //    //}

        //        //}
        //        //    oStockTransfer.Lines.Add();
        //        //    lRetCode = oStockTransfer.Add();

        //        //    if (lRetCode != 0)
        //        //    {
        //        //        //Log("Error - " + Globals.oCompany.GetLastErrorDescription().ToString());
        //        //        Bodys.Conflicts c = new Bodys.Conflicts();
        //        //        List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //        //        resp.conflicts = new List<Bodys.Conflicts>();
        //        //        c.Problems = true;
        //        //        c.Description = "Error - " + oCompany.GetLastErrorDescription().ToString();


        //        //        conflicts.Add(c);
        //        //        resp.conflicts = conflicts;
        //        //        return resp;
        //        //    }
        //        //    else
        //        //    {
        //        //        resp.DocEntry = oCompany.GetNewObjectKey();

        //        //        oCompany.Disconnect();
        //        //        return resp;
        //        //    }



        //        ////        'Get the approval template 
        //        ////oStockTransfer.SaveXML("C:\\xml\\uno.xml");
        //        //retcode = oStockTransfer.Add();
        //        //if (retcode != 0)
        //        //{
        //        //    resp.conflicts = new List<Bodys.Conflicts>();

        //        //    resp.conflicts.Add(new Bodys.Conflicts
        //        //    {
        //        //        Problems = true,
        //        //        Description = oCompany.GetLastErrorDescription(),
        //        //    });

        //        //    return resp;

        //        //}
        //        //else
        //        //{
        //        //    resp.DocEntry = oCompany.GetNewObjectKey();

        //        //    oCompany.Disconnect();
        //        //    return resp;
        //        //}
        //        return resp;
        //    }
        //    catch (Exception ex)
        //    {
        //        Bodys.Conflicts c = new Bodys.Conflicts();
        //        List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //        resp.conflicts = new List<Bodys.Conflicts>();
        //        c.Problems = true;
        //        c.Description = ex.Message;

        //        string path = Application.CommonAppDataPath + "\\Log.txt";
        //        string texto = c.Description;
        //        File.AppendAllLines(path, new String[] { texto });

        //        conflicts.Add(c);
        //        resp.conflicts = conflicts;
        //        //oCompany.Disconnect();
        //        return resp;
        //    }
        //}

        //public static Bodys.Response CreateMR(Bodys.MerchandesHeader CMR)
        //{

        //    Bodys.Response resp = new Bodys.Response();
            
        //    Bodys.Login login = new Bodys.Login();

        //    //Login login1 = new Login();

        //    List<Bodys.Login> logins = new List<Bodys.Login>();
            
        //    //List<Login> loginList = new List<Login>();
        //    DataTable dtServiceLayer = new DataTable();
        //    string IDss = string.Empty;

        //    oCompany = new SAPbobsCOM.Company();
        //    try
        //    {
        //        //oCompany.Server = Settings.Default.Server;

        //        //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //        //oCompany.UserName = Settings.Default.UserName;
        //        //oCompany.Password = Settings.Default.Password;

        //        //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //        //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
        //        //  oCompany.SLDServer = "hanab1:30015";
        //        //SAPbobsCOM.Documents oGoodsReceipts = (SAPbobsCOM.Documents) Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);
        //        //SAPbobsCOM.Documents oPurchaseOrders = (SAPbobsCOM.Documents) Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
        //        string str = "";
        //        string str2 = "";
                
        //        //resp.pabloDocNIds = new List<Bodys.PabloDocNIds>();
        //        foreach (var header in CMR.headers)
        //        {
                    
        //            switch (header.almacen)
        //            {
        //                case "01":
        //                    //Console.WriteLine("GDL");
        //                    //oCompany.Server = Settings.Default.Server;

        //                    //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                    //oCompany.UserName = Settings.Default.Almacen01User;
        //                    //oCompany.Password = Settings.Default.Almacen01Pass;

        //                    //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                    //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                    //HttpClientHandler clientHandler = new HttpClientHandler();
        //                    //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


        //                    //using (var client = new HttpClient(clientHandler))
        //                    //{

        //                    //    apiTable table = new apiTable();
        //                    //    table.CompanyDB = "SB1PRUEBA";
        //                    //    table.Password = "123456";
        //                    //    table.UserName = "Desarrollo";

        //                    //    string json = JsonConvert.SerializeObject(table);

        //                    //    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //                    //    var response = client.PostAsync("http://hanab1:50001/b1s/v1/Login", httpContent);

        //                    //    str = "" + response.Content + " : " + response.StatusCode;

        //                    //    if (response.IsSuccessStatusCode)
        //                    //    { 
        //                    //    }
        //                    //};

        //                    login.CompanyDB = Settings.Default.CompanyDB;
        //                    login.Password = Settings.Default.Almacen01Pass;
        //                    login.UserName = Settings.Default.Almacen01User;

        //                    logins.Add(login);
        //                    try
        //                    {

        //                        //HttpClientHandler clientHandler = new HttpClientHandler();

        //                        /////////////////////////////////////////////////////////////
        //                        ///
        //                        string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                        //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                        string url = "https://hanab1:50000/b1s/v1/Login";
        //                        string json = string.Empty;

        //                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                        httpWebRequest.ContentType = "application/json";
        //                        httpWebRequest.KeepAlive = true;
        //                        httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                        httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                        httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                        httpWebRequest.Accept = "*/*";
        //                        httpWebRequest.ServicePoint.Expect100Continue = false;
        //                        httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                        httpWebRequest.Method = "POST";

        //                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                        { streamWriter.Write(data); }

        //                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                        //B1Session obj = null;            

        //                        var result = string.Empty;
        //                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                        {
        //                            result = streamReader.ReadToEnd();
        //                        }

        //                        json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                        dtServiceLayer = new DataTable();
        //                        dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();
        //                        //dtServiceLayer = new DataTable();
        //                        //dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        //resultado = result;
        //                        /////////////////////////////////////////////////////////////



        //                        //using (var client = new HttpClient(clientHandler))
        //                        //    {
        //                        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //                        //        string jsonData = JsonConvert.SerializeObject(logins);
        //                        //         var json = jsonData.Replace("[","");
        //                        //         var jsoncom = json.Replace("]","");

        //                        //        StringContent httpContent = new StringContent(JsonConvert.SerializeObject(jsoncom));

        //                        //        var response =  client.PostAsync("https://hanab1:50001/b1s/v1/Login", httpContent);

        //                        ///////////////////////////////////////////////////////////////////
        //                        ///


        //                        ////////////////////////////////////////////////////////////////////


        //                        //JObject Addjson = JObject.Parse(logins.ToString());

        //                        //JArray jsonArray = JArray.Parse(logins.ToString());
        //                        //dynamic jsonData = JsonConvert.SerializeObject(jsonArray[0].ToString());
        //                        //request.Headers.TryAddWithoutValidation("CompanyDB", Settings.Default.CompanyDB);
        //                        //request.Headers.TryAddWithoutValidation("Password", Settings.Default.Password);
        //                        //request.Headers.TryAddWithoutValidation("UserName", Settings.Default.UserName);
        //                        //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //                        //JObject payload = JObject.Parse(loginList);

        //                        ////// Wrap our JSON inside a StringContent object
        //                        //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //                        //request.Content = content;

        //                        ////// Post to the endpoint
        //                        ////var response = await client.PostAsync("Create", content);

        //                        //HttpResponseMessage response = httpClient.SendAsync(request).Result;
        //                        //JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

        //                        //}
        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string msg = ex.ToString();
        //                    }

        //                    break;
        //                case "02":
        //                    //Console.WriteLine("CDMX");
        //                    //oCompany.Server = Settings.Default.Server;

        //                    //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                    //oCompany.UserName = Settings.Default.Almacen02User;
        //                    //oCompany.Password = Settings.Default.Almacen02Pass;

        //                    //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                    //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                    login.CompanyDB = Settings.Default.CompanyDB;
        //                    login.Password = Settings.Default.Almacen02Pass;
        //                    login.UserName = Settings.Default.Almacen02User;

        //                    logins.Add(login);
        //                    try
        //                    {

        //                        //HttpClientHandler clientHandler = new HttpClientHandler();

        //                        /////////////////////////////////////////////////////////////
        //                        ///
        //                        string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                        //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                        string url = "https://hanab1:50000/b1s/v1/Login";
        //                        string json = string.Empty;

        //                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                        httpWebRequest.ContentType = "application/json";
        //                        httpWebRequest.KeepAlive = true;
        //                        httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                        httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                        httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                        httpWebRequest.Accept = "*/*";
        //                        httpWebRequest.ServicePoint.Expect100Continue = false;
        //                        httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                        httpWebRequest.Method = "POST";

        //                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                        { streamWriter.Write(data); }

        //                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                        //B1Session obj = null;            

        //                        var result = string.Empty;
        //                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                        {
        //                            result = streamReader.ReadToEnd();
        //                        }

        //                        json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                        dtServiceLayer = new DataTable();
        //                        dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();
                                
        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string msg = ex.ToString();
        //                    }

        //                    break;
        //                case "03":
        //                    //Console.WriteLine("PUEBLA");
        //                    //oCompany.Server = Settings.Default.Server;

        //                    //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                    //oCompany.UserName = Settings.Default.Almacen03User;
        //                    //oCompany.Password = Settings.Default.Almacen03Pass;

        //                    //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                    //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                    login.CompanyDB = Settings.Default.CompanyDB;
        //                    login.Password = Settings.Default.Almacen03Pass;
        //                    login.UserName = Settings.Default.Almacen03User;

        //                    logins.Add(login);
        //                    try
        //                    {

        //                        //HttpClientHandler clientHandler = new HttpClientHandler();

        //                        /////////////////////////////////////////////////////////////
        //                        ///
        //                        string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                        //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                        string url = "https://hanab1:50000/b1s/v1/Login";
        //                        string json = string.Empty;

        //                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                        httpWebRequest.ContentType = "application/json";
        //                        httpWebRequest.KeepAlive = true;
        //                        httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                        httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                        httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                        httpWebRequest.Accept = "*/*";
        //                        httpWebRequest.ServicePoint.Expect100Continue = false;
        //                        httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                        httpWebRequest.Method = "POST";

        //                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                        { streamWriter.Write(data); }

        //                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                        //B1Session obj = null;            

        //                        var result = string.Empty;
        //                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                        {
        //                            result = streamReader.ReadToEnd();
        //                        }

        //                        json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                        dtServiceLayer = new DataTable();
        //                        dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string msg = ex.ToString();
        //                    }


        //                    break;
        //                case "04":
        //                    //Console.WriteLine("MONTERREY");
        //                    //oCompany.Server = Settings.Default.Server;

        //                    //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                    //oCompany.UserName = Settings.Default.Almacen04User;
        //                    //oCompany.Password = Settings.Default.Almacen04Pass;

        //                    //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //                    //oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

        //                    login.CompanyDB = Settings.Default.CompanyDB;
        //                    login.Password = Settings.Default.Almacen04Pass;
        //                    login.UserName = Settings.Default.Almacen04User;

        //                    logins.Add(login);
        //                    try
        //                    {

        //                        //HttpClientHandler clientHandler = new HttpClientHandler();

        //                        /////////////////////////////////////////////////////////////
        //                        ///
        //                        string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                        //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                        string url = "https://hanab1:50000/b1s/v1/Login";
        //                        string json = string.Empty;

        //                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                        httpWebRequest.ContentType = "application/json";
        //                        httpWebRequest.KeepAlive = true;
        //                        httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                        httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                        httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                        httpWebRequest.Accept = "*/*";
        //                        httpWebRequest.ServicePoint.Expect100Continue = false;
        //                        httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                        httpWebRequest.Method = "POST";

        //                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                        { streamWriter.Write(data); }

        //                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                        //B1Session obj = null;            

        //                        var result = string.Empty;
        //                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                        {
        //                            result = streamReader.ReadToEnd();
        //                        }

        //                        json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                        dtServiceLayer = new DataTable();
        //                        dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string msg = ex.ToString();
        //                    }

        //                    break;
        //                case "05":
        //                    //Console.WriteLine("SALTO");
        //                    //oCompany.Server = Settings.Default.Server;

        //                    //oCompany.CompanyDB = Settings.Default.CompanyDB;

        //                    //oCompany.UserName = Settings.Default.Almacen05User;
        //                    //oCompany.Password = Settings.Default.Almacen05Pass;

        //                    //oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;

        //                    login.CompanyDB = Settings.Default.CompanyDB;
        //                    login.Password = Settings.Default.Almacen05Pass;
        //                    login.UserName = Settings.Default.Almacen05User;

        //                    logins.Add(login);
        //                    try
        //                    {

        //                        //HttpClientHandler clientHandler = new HttpClientHandler();

        //                        /////////////////////////////////////////////////////////////
        //                        ///
        //                        string data = "{    \"CompanyDB\": \"" + login.CompanyDB + "\",    \"UserName\": \"" + login.UserName + "\",       \"Password\": \"" + login.Password + "\"}";
        //                        //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //                        string url = "https://hanab1:50000/b1s/v1/Login";
        //                        string json = string.Empty;

        //                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

        //                        httpWebRequest.ContentType = "application/json";
        //                        httpWebRequest.KeepAlive = true;
        //                        httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //                        httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
        //                        httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
        //                        httpWebRequest.Accept = "*/*";
        //                        httpWebRequest.ServicePoint.Expect100Continue = false;
        //                        httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //                        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
        //                        httpWebRequest.Method = "POST";

        //                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //                        { streamWriter.Write(data); }

        //                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //                        //B1Session obj = null;            

        //                        var result = string.Empty;
        //                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //                        {
        //                            result = streamReader.ReadToEnd();
        //                        }

        //                        json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
        //                        dtServiceLayer = new DataTable();
        //                        dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
        //                        IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        string msg = ex.ToString();
        //                    }

        //                    oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
        //                    break;
        //                default:
        //                    Console.WriteLine("Inserta un almacen valido");
        //                    break;


        //            }



        //            //lRetCode = oCompany.Connect();

        //            //if (lRetCode != 0)
        //            //{
        //            //    sErrMsg = oCompany.GetLastErrorDescription();
        //            //    Bodys.Conflicts c = new Bodys.Conflicts();
        //            //    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //            //    resp.conflicts = new List<Bodys.Conflicts>();
        //            //    c.Problems = true;
        //            //    c.Description = "Error al conectar a SAP " + sErrMsg;


        //            //    conflicts.Add(c);
        //            //    resp.conflicts = conflicts;
        //            //    return resp;
        //            //}

        //            SAPbobsCOM.CompanyService oCompanyService;
        //            SAPbobsCOM.AdminInfo oAdminInfo;

        //            //try
        //            //{
        //            //    oCompanyService = oCompany.GetCompanyService();
        //            //    oAdminInfo = oCompany.GetCompanyService().GetAdminInfo();

        //            //    //oCompanyService
        //            //    //oAdminInfo.CloseCountedRowsWithoutConfirmation
        //            //    //oAdminInfo.PurchaseOrderConfirmed
        //            //    //oAdminInfo.RestrictOrders
        //            //    oAdminInfo.EnableUpdateDocAfterApproval = SAPbobsCOM.BoYesNoEnum.tYES;
        //            //    oAdminInfo.EnableUpdateDraftDuringApproval = SAPbobsCOM.BoYesNoEnum.tYES;
        //            //    oAdminInfo.EnableAuthorizerUpdatePendingDraft = SAPbobsCOM.BoYesNoEnum.tYES;


        //            //    oCompanyService.UpdateAdminInfo(oAdminInfo);

        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //    MessageBox.Show(ex.Message);
        //            //    Console.WriteLine(ex.Message);
        //            //    //string path = Application.CommonAppDataPath + "\\Log.txt";
        //            //    //string texto = c.Description;
        //            //    //File.AppendAllLines(path, new String[] { texto });
        //            //}




        //            //SAPbobsCOM.Documents oPurchaseOrders = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
        //            //SAPbobsCOM.Documents oPurchaseDeliveryNotes = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);

        //            Bodys.PabloDocNIds pdid = new Bodys.PabloDocNIds();
        //            List<Bodys.PabloDocNIds> idss = new List<Bodys.PabloDocNIds>();

        //            //oPurchaseOrders.GetByKey(header.docEntry);

        //            //if (oPurchaseOrders.UserFields.Fields.Item("U_EntradaAut").Value == "1")
        //            //{
        //            //    oPurchaseOrders.UserFields.Fields.Item("U_EntradaAut").Value = "2";
        //            //    lRetCode = oPurchaseOrders.Update();

        //            //    if (lRetCode != 0)
        //            //    {
        //            //        sErrMsg = oCompany.GetLastErrorDescription();
        //            //        Bodys.Conflicts c = new Bodys.Conflicts();
        //            //        List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //            //        resp.conflicts = new List<Bodys.Conflicts>();
        //            //        c.Problems = true;
        //            //        c.Description = "Error al actualizar U_EntradaAut" + sErrMsg;


        //            //        conflicts.Add(c);
        //            //        resp.conflicts = conflicts;
        //            //        return resp;
        //            //    }
        //            //}
        //            //156
        //            var docEntry = 298;
        //            string data2 = "{    \"U_EntradaAut\": \"" + 2 + "\"}";
        //            //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //            string url2 = "https://hanab1:50000/b1s/v1/PurchaseOrders(" + docEntry + ")";
        //            string json2 = string.Empty;

        //            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url2);
        //            httpWebRequest2.Method = "PATCH";
        //            httpWebRequest2.ContentType = "application/json";
        //            httpWebRequest2.KeepAlive = true;
        //            httpWebRequest2.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //            httpWebRequest2.Headers.Add("B1S-WCFCompatible", "true");
        //            httpWebRequest2.Headers.Add("B1S-MetadataWithoutSession", "true");
        //            httpWebRequest2.Accept = "*/*";
        //            httpWebRequest2.ServicePoint.Expect100Continue = false;
        //            httpWebRequest2.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //            httpWebRequest2.AutomaticDecompression = DecompressionMethods.GZip;
        //            CookieContainer cookies = new CookieContainer();
        //            cookies.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
        //            cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
        //            httpWebRequest2.CookieContainer = cookies;

        //            using (var streamWriter = new StreamWriter(httpWebRequest2.GetRequestStream()))
        //            { streamWriter.Write(data2); }

        //            var httpResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();

        //            var result2 = string.Empty;
        //            using (var streamReader = new StreamReader(httpResponse2.GetResponseStream()))
        //            {
        //                result2 = streamReader.ReadToEnd();
        //            }

        //            json2 = "[" + result2.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";

        //            //////////////////////////////////////////////////////////
        //            ///
        //            string data3 = "{ " +
        //                                "\"CardCode\":" + header.CardCode + "" +
        //                                "\"DocDate\": \"2023-09-26\", " +
        //                                "\"DocumentLines\": [ " +
        //                                    "{ " +
        //                                        "\"ItemCode\": \"ADE-ATOD0001\", " +
        //                                        "\"Quantity\": \"10\", " +
        //                                        "\"Warehouse\": \"01\", " +
        //                                        "\"U_Sucursal\": \"01\", " +
        //                                        "\"BatchNumbers\": [ " +
        //                                            "{ " +
        //                                                "\"BatchNumber\": \"1324\", " +
        //                                                "\"Quantity\": \"10\", " +
        //                                                "\"ExpiryDate\": \"2025-09-26\" " +
        //                                            "} " +
        //                                        "] " +
        //                                    "} " +
        //                                "] " +
        //                            "}";
        //            ////////////////////////////////////////////////////////////
        //            //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
        //            string url3 = "https://hanab1:50000/b1s/v1/PurchaseDeliveryNotes";
        //            string json3 = string.Empty;

        //            HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(url3);
        //            httpWebRequest3.Method = "POST";
        //            httpWebRequest3.ContentType = "application/json";
        //            httpWebRequest3.KeepAlive = true;
        //            httpWebRequest3.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        //            httpWebRequest3.Headers.Add("B1S-WCFCompatible", "true");
        //            httpWebRequest3.Headers.Add("B1S-MetadataWithoutSession", "true");
        //            httpWebRequest3.Accept = "*/*";
        //            httpWebRequest3.ServicePoint.Expect100Continue = false;
        //            httpWebRequest3.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        //            httpWebRequest3.AutomaticDecompression = DecompressionMethods.GZip;
        //            CookieContainer cookies2 = new CookieContainer();
        //            cookies2.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
        //            cookies2.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
        //            httpWebRequest3.CookieContainer = cookies;

        //            using (var streamWriter = new StreamWriter(httpWebRequest3.GetRequestStream()))
        //            { streamWriter.Write(data3); }

        //            var httpResponse3 = (HttpWebResponse)httpWebRequest3.GetResponse();

        //            var result3 = string.Empty;
        //            using (var streamReader = new StreamReader(httpResponse3.GetResponseStream()))
        //            {
        //                result3 = streamReader.ReadToEnd();
        //            }

        //            json3 = "[" + result3.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";

        //            //////////////////////////////////////////////////////

        //            //var httpGetResponse = (HttpWebResponse)httpWebRequest2.GetResponse();
        //            //var result2 = string.Empty;
        //            //using (var streamReader = new StreamReader(httpGetResponse.GetResponseStream()))
        //            //{
        //            //    result2 = streamReader.ReadToEnd();
        //            //}
        //            //using (var streamWriter = new StreamWriter(httpWebRequest2.GetRequestStream()))

        //            //{ streamWriter.Write(data2); }
        //            //var httpResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
        //            ////B1Session obj = null;            


        //            //oPurchaseDeliveryNotes.CardCode = oPurchaseOrders.CardCode;
        //            //oPurchaseDeliveryNotes.CardName = oPurchaseOrders.CardName;
        //            //oPurchaseDeliveryNotes.DocDate = DateTime.Today;
        //            //oPurchaseDeliveryNotes.TaxDate = DateTime.Today;
        //            //oPurchaseDeliveryNotes.DocDueDate = DateTime.Today;



        //            //foreach (var item in header.data)
        //            //{
        //            //    var entry = header.docEntry;
        //            //    var line = item.baseline;

        //            //    var price = oPurchaseOrders.Lines.Price;
        //            //    var tax = oPurchaseOrders.Lines.TaxCode;

        //            //    oPurchaseDeliveryNotes.Lines.ItemCode = item.itemcode;
        //            //    oPurchaseDeliveryNotes.Lines.ItemDescription = item.itemname;
        //            //    oPurchaseDeliveryNotes.Lines.BaseType = 22;
        //            //    oPurchaseDeliveryNotes.Lines.BaseEntry = header.docEntry;
        //            //    oPurchaseDeliveryNotes.Lines.BaseLine = item.baseline;
        //            //    oPurchaseDeliveryNotes.Lines.Quantity = item.quantity;
        //            //    //oPurchaseDeliveryNotes.Lines.Price = oPurchaseOrders.Lines.Price;
        //            //    oPurchaseDeliveryNotes.Lines.Price = oPurchaseOrders.Lines.Price;
        //            //    oPurchaseDeliveryNotes.Lines.WarehouseCode = header.almacen;
        //            //    oPurchaseDeliveryNotes.Lines.TaxCode = oPurchaseOrders.Lines.TaxCode;
        //            //    oPurchaseDeliveryNotes.UserFields.Fields.Item("U_Sucursal").Value = header.almacen;
        //            //    //oPurchaseDeliveryNotes.UserFields.Fields.Item("U_Almacen").Value = CMR.almacen;

        //            //    foreach (var itemContent in item.content)
        //            //    {
        //            //        oPurchaseDeliveryNotes.Lines.BatchNumbers.BatchNumber = itemContent.num_lote;
        //            //        oPurchaseDeliveryNotes.Lines.BatchNumbers.Quantity = itemContent.quantity;
        //            //        oPurchaseDeliveryNotes.Lines.BatchNumbers.ExpiryDate = DateTime.Parse(itemContent.expiration_date);
        //            //        oPurchaseDeliveryNotes.Lines.BatchNumbers.Add();

        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.BinAbsEntry = itemContent.binAbsEntry;
        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.Quantity = itemContent.quantity;
        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.AllowNegativeQuantity = BoYesNoEnum.tNO;
        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = itemContent.serialAndBatchNumbersBaseLine;
        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.BaseLineNumber = itemContent.baseLineNumber;

        //            //        //oPurchaseDeliveryNotes.Lines.BinAllocations.Add();


        //            //    }

        //            //    oPurchaseDeliveryNotes.Lines.Add();
        //            //    oPurchaseDeliveryNotes.Comments = oPurchaseOrders.Comments;


        //            //}
        //            //oPurchaseDeliveryNotes.SaveXML("C:\\xml\\1.xml");

        //            //lRetCode = oPurchaseDeliveryNotes.Add();

        //            ////SAPbobsCOM.CompanyService oCompanyService;
        //            ////SAPbobsCOM.AdminInfo oAdminInfo;


        //            //if (lRetCode != 0)
        //            //{
        //            //    //Log("Error - " + Globals.oCompany.GetLastErrorDescription().ToString());
        //            //    Bodys.Conflicts c = new Bodys.Conflicts();
        //            //    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //            //    resp.conflicts = new List<Bodys.Conflicts>();
        //            //    c.Problems = true;
        //            //    c.Description = "Error - " + oCompany.GetLastErrorDescription().ToString();


        //            //    conflicts.Add(c);
        //            //    resp.conflicts = conflicts;
        //            //    lRetCode = 0;
        //            //    oPurchaseOrders = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
        //            //    oPurchaseDeliveryNotes = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);
        //            //    try
        //            //    {
        //            //        oCompanyService = oCompany.GetCompanyService();
        //            //        oAdminInfo = oCompany.GetCompanyService().GetAdminInfo();

        //            //        //oCompanyService
        //            //        //oAdminInfo.CloseCountedRowsWithoutConfirmation
        //            //        //oAdminInfo.PurchaseOrderConfirmed
        //            //        //oAdminInfo.RestrictOrders
        //            //        oAdminInfo.EnableUpdateDocAfterApproval = SAPbobsCOM.BoYesNoEnum.tNO;
        //            //        oAdminInfo.EnableUpdateDraftDuringApproval = SAPbobsCOM.BoYesNoEnum.tNO;
        //            //        oAdminInfo.EnableAuthorizerUpdatePendingDraft = SAPbobsCOM.BoYesNoEnum.tNO;

        //            //        oCompanyService.UpdateAdminInfo(oAdminInfo);

        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        MessageBox.Show(ex.Message);
        //            //        //Console.WriteLine(ex.Message);
        //            //        string path = Application.CommonAppDataPath + "\\Log.txt";
        //            //        string texto = c.Description;
        //            //        File.AppendAllLines(path, new String[] { texto });
        //            //    }
        //            //    oCompany.Disconnect();
        //            //    //return resp;
        //            //}
        //            //else
        //            //{
        //            //    foreach (var pablito in header.idsp)
        //            //    {
        //            //        pdid.Id = pablito.ids;
        //            //        pdid.docEntry = oCompany.GetNewObjectKey();
        //            //        idss.Add(pdid);
        //            //        pdid = new Bodys.PabloDocNIds();
        //            //    }
        //            ////pdid.docEntry = oCompany.GetNewObjectKey();
        //            //resp.pabloDocNIds = idss;
        //            ////Bodys.PabloDocNIds pdi = new Bodys.PabloDocNIds();
        //            ////List<Bodys.PabloDocNIds> pablo = new List<Bodys.PabloDocNIds>();
        //            ////resp.pabloDocNIds = new List<Bodys.PabloDocNIds>();
        //            ////pdi.Id = header.ids();
        //            ////pdi.docEntry = oCompany.GetNewObjectKey();
        //            //resp.DocEntry = oCompany.GetNewObjectKey();
        //            //lRetCode = 0;
        //            //oPurchaseOrders = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
        //            //oPurchaseDeliveryNotes = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes);
        //            //oCompany.Disconnect();
        //            //return resp;
        //            //}
        //        }



        //        return resp;

        //    }
        //    catch (Exception ex)
        //    {
        //        Bodys.Conflicts c = new Bodys.Conflicts();
        //        List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
        //        resp.conflicts = new List<Bodys.Conflicts>();
        //        c.Problems = true;
        //        c.Description = ex.ToString();
        //        manhattan.Logs.Logs.LogSinConexion(c.Description);

        //        string path = Application.CommonAppDataPath + "\\Log.txt";
        //        string texto = c.Description;
        //        File.AppendAllLines(path, new String[] { texto });

        //        conflicts.Add(c);
        //        resp.conflicts = conflicts;
        //        oCompany.Disconnect();
        //        return resp;
        //    }

        //}

        public static Bodys.Response CreateMRSL(MerchandesSlayer CMRSL)
        {
            Bodys.Response resp = new Bodys.Response();

            //DataTable dtServiceLayer = new DataTable();
            //DataTable dtServiceLayer = new DataTable();
            string IDss = string.Empty;
            //JObject prueba = (JObject)jsonObject;
            bool Status = false;
            //CMRSL= ValidateLineStatus(CMRSL, ref hola);
            //if (hola)
            //    return resp;


            var Warehouse = CMRSL.DocumentLines.FirstOrDefault().Warehouse;
            

            var jsonObject = JsonConvert.SerializeObject(CMRSL);

            //string Warehouse = (string)prueba["Warehouse"];

            string data = string.Empty;
            //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
            string url = string.Empty;
            string json = string.Empty;
            var result = string.Empty;
            string DocNum = string.Empty;
            var request = 0;
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpResponse;
            CookieContainer cookies = new CookieContainer();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
            //JObject jsonObject = JObject.Parse(CMRSL);
            List<Bodys.Items> Items = new List<Bodys.Items>();


            try
            {
                Bodys.NewLines l = new Bodys.NewLines();
                List<Bodys.NewLines> NewLines = new List<Bodys.NewLines>();
                try
                {
                    //HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
                    conn.Close();
                    conn.Open();
                    string VLS = string.Empty;

                    resp.NewLines = new List<Bodys.NewLines>();
                    for (int i = 0; i < CMRSL.DocumentLines.Count; i++)
                    {

                        //request = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;


                        string queryVLS = "SELECT \"LineStatus\" " +
                                           "FROM " + manhattan.Properties.Settings.Default.CompanyDB + ".POR1 " +
                                           "WHERE \"LineNum\" IN (" + CMRSL.DocumentLines[i].BaseLine.ToString() + ") AND \"DocEntry\" = " + CMRSL.DocumentLines[i].BaseEntry.ToString();
                        HanaCommand cmdVLS = new HanaCommand(queryVLS, conn);
                        HanaDataReader readerVLS = cmdVLS.ExecuteReader();
                        json = "";


                        if (readerVLS.HasRows)
                        {
                            while (readerVLS.Read())
                            {
                                json = readerVLS.GetString(0);

                                if (json == "C")
                                    Status = true;

                                CMRSL.DocumentLines[i].LineStatus = json;
                                l.BaseLine = CMRSL.DocumentLines[i].BaseLine;
                                l.LineStatus = CMRSL.DocumentLines[i].LineStatus;
                                NewLines.Add(l);
                                resp.DocEntry = CMRSL.DocumentLines[i].BaseEntry.ToString();
                                resp.NewLines = NewLines;
                                l = new Bodys.NewLines();
                            }
                        }

                    }
                    conn.Close();
                    if (Status)
                    {
                        //resp.MerchandesSlayer = CMRSL;
                        return resp;
                    }
                    else
                    {
                        l = new Bodys.NewLines();
                        NewLines = new List<Bodys.NewLines>();
                        resp.NewLines = new List<Bodys.NewLines>();
                    }
                }
                catch (WebException ex)
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    using (WebResponse response = ex.Response)
                    {
                        // TODO: Handle response being null
                        //HttpWebResponse httpResponse = (HttpWebResponse)response;
                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data2 = response.GetResponseStream())
                        using (var reader2 = new StreamReader(data2))
                        {
                            c.Description = reader2.ReadToEnd();
                            manhattan.Logs.Logs.LogSinConexion(c.Description);
                            //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                            //Log(model.error.message.value);
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                        }
                    }
                    return resp;

                }




                l = new Bodys.NewLines();
                NewLines = new List<Bodys.NewLines>();
                resp.NewLines = new List<Bodys.NewLines>();


                Bodys.Response respc = new Bodys.Response();
                //HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
                conn.Close();
                conn.Open();
                request = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;


                string query = "SELECT \"DocStatus\" " +
                                "FROM " + manhattan.Properties.Settings.Default.CompanyDB + ".OPOR " +
                                "WHERE \"DocEntry\" = '" + request + "'";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
                json = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        json = reader.GetString(0);

                    }
                }
                conn.Close();
                if (json == "C")
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    c.Description = "La orden se encuentra cerrada";
                    conn.Close();
                    conflicts.Add(c);
                    resp.conflicts = conflicts;
                    return resp;
                }
                conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
                conn.Close();
                conn.Open();
                request = CMRSL.DocumentLines.FirstOrDefault().BaseLine;
                var request3 = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;
                var bl = string.Empty;
                foreach (var item in CMRSL.DocumentLines)
                {
                    bl += item.BaseLine.ToString() + ",";
                }
                if (bl.Length > 1)
                    bl = bl.Substring(0, bl.Length - 1);

                query = "SELECT DISTINCT \"LineStatus\" " +
                                   "FROM " + manhattan.Properties.Settings.Default.CompanyDB + ".POR1 " +
                                   "WHERE \"LineNum\" IN (" + bl + ") AND \"DocEntry\" = " + request3;
                cmd = new HanaCommand(query, conn);
                reader = cmd.ExecuteReader();
                json = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        json = reader.GetString(0);
                        if (json == "C")
                        {
                            Bodys.Conflicts c = new Bodys.Conflicts();
                            List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                            resp.conflicts = new List<Bodys.Conflicts>();
                            c.Problems = true;
                            c.Description = "Las lineas se encuentran cerradas";
                            conn.Close();
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                            return resp;
                        }
                    }
                }
                conn.Close();
                if (json == "C")
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    c.Description = "La orden se encuentra cerrada";
                    conn.Close();
                    conflicts.Add(c);
                    resp.conflicts = conflicts;
                    return resp;
                }
                try
                {

                    switch (Warehouse)
                    {
                        case "01":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen01User + "\",       \"Password\": \"" + Settings.Default.Almacen01Pass + "\"}";

                            break;
                        case "02":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen02User + "\",       \"Password\": \"" + Settings.Default.Almacen02Pass + "\"}";

                            break;
                        case "03":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen03User + "\",       \"Password\": \"" + Settings.Default.Almacen03Pass + "\"}";

                            break;
                        case "04":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen04User + "\",       \"Password\": \"" + Settings.Default.Almacen04Pass + "\"}";

                            break;
                        case "05":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen05User + "\",       \"Password\": \"" + Settings.Default.Almacen05Pass + "\"}";

                            break;


                    }

                    url = "https://hanab1:50000/b1s/v1/Login";
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    { streamWriter.Write(data); }

                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //B1Session obj = null;            

                    result = string.Empty;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();


                        var sesion = JsonConvert.DeserializeObject<dynamic>(result);
                        IDss = sesion["SessionId"];

                    }
                    //json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
                    //dtServiceLayer = new DataTable();
                    //dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
                    //IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();
                }
                catch (WebException ex)
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    using (WebResponse response = ex.Response)
                    {
                        // TODO: Handle response being null
                        //HttpWebResponse httpResponse = (HttpWebResponse)response;
                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data2 = response.GetResponseStream())
                        using (var reader2 = new StreamReader(data2))
                        {
                            c.Description = reader2.ReadToEnd();
                            manhattan.Logs.Logs.LogSinConexion(c.Description);
                            //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                            //Log(model.error.message.value);
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                        }
                    }
                    return resp;

                }


                /////////////////////////////////////////////////////////////////////////////////////////////////
                ///CAMBIAR A AUTORIZADO LA ORDEN DE COMPRA
                ////////////////////////////////////////////////////////////////////////////////////////////////
                //try
                //{

                //    //jsonObject = CMRSL;

                //    //string DocEntry = (string)jsonObject["BaseEntry"];
                //    var DocEntry = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;
                //    data = "{    \"U_EntradaAut\": \"" + 2 + "\"}";
                //    //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
                //    url = "https://hanab1:50000/b1s/v1/PurchaseOrders(" + DocEntry + ")";
                //    json = string.Empty;

                //    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //    httpWebRequest.Method = "PATCH";
                //    httpWebRequest.ContentType = "application/json";
                //    httpWebRequest.KeepAlive = true;
                //    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                //    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                //    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                //    httpWebRequest.Accept = "*/*";
                //    httpWebRequest.ServicePoint.Expect100Continue = false;
                //    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                //    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                //    cookies = new CookieContainer();
                //    cookies.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
                //    cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
                //    httpWebRequest.CookieContainer = cookies;

                //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //    { streamWriter.Write(data); }

                //    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //    result = string.Empty;
                //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //    {
                //        result = streamReader.ReadToEnd();
                //    }
                //}
                //catch (WebException ex)
                //{
                //    Bodys.Conflicts c = new Bodys.Conflicts();
                //    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                //    resp.conflicts = new List<Bodys.Conflicts>();
                //    c.Problems = true;

                //    using (WebResponse response = ex.Response)
                //    {

                //        using (Stream data2 = response.GetResponseStream())
                //        using (var readererror = new StreamReader(data2))
                //        {
                //            c.Description = readererror.ReadToEnd();
                //            //c.Description = response.ToString();
                //            manhattan.Logs.Logs.LogSinConexion(c.Description);

                //            string path = Application.CommonAppDataPath + "\\Log.txt";
                //            string texto = c.Description;
                //            File.AppendAllLines(path, new String[] { texto });

                //            conflicts.Add(c);
                //            resp.conflicts = conflicts;

                //        }
                //    }


                //    return resp;
                //}



                ///////////////////////////////////////////////////////////////////////////
                ///ENTRADA DE MERCANCIA
                //////////////////////////////////////////////////////////////////////////

                try
                {

                    //data = (string)jsonObject[CMRSL]; ;
                    var DocEntry = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;

                    jsonObject = JsonConvert.SerializeObject(CMRSL);
                    data = jsonObject;

                    url = "https://hanab1:50000/b1s/v1/PurchaseDeliveryNotes";
                    json = string.Empty;

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    cookies = new CookieContainer();
                    cookies.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
                    cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
                    httpWebRequest.CookieContainer = cookies;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    { streamWriter.Write(data); }

                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    result = string.Empty;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }

                    //var docnum = JsonConvert.DeserializeObject<dynamic>(result);
                    //DocNum = docnum["Comments"];

                    Bodys.Response respc2 = new Bodys.Response();
                    HanaConnection conn2 = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

                    conn2.Open();
                    var request2 = DocEntry;


                    string query2 = "SELECT \"DocNum\" " +
                                "FROM " + manhattan.Properties.Settings.Default.CompanyDB + ".OPOR " +
                                "WHERE \"DocEntry\" = '" + request2 + "'";
                    HanaCommand cmd2 = new HanaCommand(query2, conn2);
                    HanaDataReader reader2 = cmd2.ExecuteReader();
                    json = "";

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            json = reader2.GetString(0);

                        }
                    }
                    conn2.Close();
                    //HanaDataAdapter data = new HanaDataAdapter(cmd);
                    //DataTable tabla = new DataTable();
                    resp.DocNum = json;
                    return resp;

                    //resp.DocNum = DocNum;

                    //return resp;
                }
                catch (WebException ex)
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    using (WebResponse response = ex.Response)
                    {
                        // TODO: Handle response being null
                        //HttpWebResponse httpResponse = (HttpWebResponse)response;
                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data2 = response.GetResponseStream())
                        using (var reader2 = new StreamReader(data2))
                        {
                            c.Description = reader2.ReadToEnd();
                            manhattan.Logs.Logs.LogSinConexion(c.Description);
                            //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                            //Log(model.error.message.value);
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                        }
                    }
                    return resp;

                }
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }
        }

        public static Bodys.Response OperateStockTransferApprovalSL(StockTransferSlayer OSTASL)
        {
            Bodys.Response resp = new Bodys.Response();

            //DataTable dtServiceLayer = new DataTable();
            //DataTable dtServiceLayer = new DataTable();
            string IDss = string.Empty;
            //JObject prueba = (JObject)jsonObject;
            var jsonObject = JsonConvert.SerializeObject(OSTASL);
            //var Warehouse = OSTASL.WarehouseCode;

            var Warehouse = OSTASL.StockTransferLines.FirstOrDefault().WarehouseCode;


            //var jsonObject = JsonConvert.SerializeObject(OSTASL);

            //string Warehouse = (string)prueba["Warehouse"];

            string data = string.Empty;
            //string url = "https://" + Variables.Dominio + ":" + Variables.Puerto + "/b1s/v1/Login";
            string url = string.Empty;
            string json = string.Empty;
            var result = string.Empty;
            string DocNum = string.Empty;
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpResponse;
            CookieContainer cookies = new CookieContainer();
            try
            {

                try
                {

                    switch (Warehouse)
                    {
                        case "01":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen01User + "\",       \"Password\": \"" + Settings.Default.Almacen01Pass + "\"}";

                            break;
                        case "02":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen02User + "\",       \"Password\": \"" + Settings.Default.Almacen02Pass + "\"}";

                            break;
                        case "03":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen03User + "\",       \"Password\": \"" + Settings.Default.Almacen03Pass + "\"}";

                            break;
                        case "04":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen04User + "\",       \"Password\": \"" + Settings.Default.Almacen04Pass + "\"}";

                            break;
                        case "05":
                            data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.Almacen05User + "\",       \"Password\": \"" + Settings.Default.Almacen05Pass + "\"}";

                            break;


                    }

                    url = "https://hanab1:50000/b1s/v1/Login";
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    { streamWriter.Write(data); }

                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //B1Session obj = null;            

                    result = string.Empty;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();


                        var sesion = JsonConvert.DeserializeObject<dynamic>(result);
                        IDss = sesion["SessionId"];

                    }
                    //json = "[" + result.Replace("\n", "").Replace("[", "\"").Replace("]", "\"") + "]";
                    //dtServiceLayer = new DataTable();
                    //dtServiceLayer = (DataTable)JsonConvert.DeserializeObject(json.Trim(), (typeof(DataTable)));
                    //IDss = dtServiceLayer.Rows[0]["SessionId"].ToString();

                }
                catch (WebException ex)
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    using (WebResponse response = ex.Response)
                    {
                        // TODO: Handle response being null
                        //HttpWebResponse httpResponse = (HttpWebResponse)response;
                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data2 = response.GetResponseStream())
                        using (var reader2 = new StreamReader(data2))
                        {
                            c.Description = reader2.ReadToEnd();
                            manhattan.Logs.Logs.LogSinConexion(c.Description);
                            //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                            //Log(model.error.message.value);
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                        }
                    }
                    return resp;

                }

                /////////////////////////////////////////////////////////////
                ///Transferencia
                ////////////////////////////////////////////////////////////

                try
                {
                    jsonObject = JsonConvert.SerializeObject(OSTASL);
                    data = jsonObject;

                    url = "https://hanab1:50000/b1s/v1/StockTransfers";
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    httpWebRequest.Method = "POST";
                    cookies = new CookieContainer();
                    cookies.Add(new Cookie("B1SESSION", IDss) { Domain = "hanab1" });
                    cookies.Add(new Cookie("ROUTEID", ".node1") { Domain = "hanab1" });
                    httpWebRequest.CookieContainer = cookies;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    { streamWriter.Write(data); }

                    httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //B1Session obj = null;            

                    result = string.Empty;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();


                        var sesion = JsonConvert.DeserializeObject<dynamic>(result);
                        IDss = sesion["DocNum"];

                    }
                    resp.DocNum = IDss;
                    return resp;
                }
                catch (WebException ex)
                {
                    Bodys.Conflicts c = new Bodys.Conflicts();
                    List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                    resp.conflicts = new List<Bodys.Conflicts>();
                    c.Problems = true;
                    using (WebResponse response = ex.Response)
                    {
                        // TODO: Handle response being null
                        //HttpWebResponse httpResponse = (HttpWebResponse)response;
                        //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data2 = response.GetResponseStream())
                        using (var reader2 = new StreamReader(data2))
                        {
                            c.Description = reader2.ReadToEnd();
                            manhattan.Logs.Logs.LogSinConexion(c.Description);
                            //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                            //Log(model.error.message.value);
                            conflicts.Add(c);
                            resp.conflicts = conflicts;
                        }
                    }
                    return resp;

                }
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }
        }

        public static bool ItemCodeConsult(string ItemCode)
        {
            bool val = false;
            string msj = "";
            var data = "{    \"CompanyDB\": \"" + Settings.Default.CompanyDB + "\",    \"UserName\": \"" + Settings.Default.UserName + "\",       \"Password\": \"" + Settings.Default.Password + "\"}";
            var IDss = "";
            try
            {
                try
                {
                    var url = "https://hanab1:50000/b1s/v1/Login";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                    httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    { streamWriter.Write(data); }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //B1Session obj = null;            

                    var result = string.Empty;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();


                        var sesion = JsonConvert.DeserializeObject<dynamic>(result);
                        IDss = sesion["SessionId"];

                    }
                    //HttpWebResponse httpResponse;

                    var WebReq = (HttpWebRequest)WebRequest.Create("https://hanab1:50000/b1s/v1/Items('" + ItemCode + "')");
                    WebReq.ContentType = "application/json;odata=minimalmetadata;charset=utf8";
                    WebReq.Method = "get";
                    WebReq.KeepAlive = true;
                    WebReq.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                    WebReq.Accept = "application/json;odata=minimalmetadata";
                    WebReq.ServicePoint.Expect100Continue = false;
                    WebReq.Headers.Add("Cookie", "B1SESSION=" + IDss + "; ROUTEID=.node2");
                    WebReq.AllowAutoRedirect = true;
                    WebReq.Timeout = 10000000;

                    httpResponse = (HttpWebResponse)WebReq.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {

                        var res = streamReader.ReadToEnd();

                        JObject jsonObject = JObject.Parse(res);

                        string valid = jsonObject["Valid"].ToString();

                        if (valid == "tYES")
                        {
                            val = true;
                        }

                    }

                }
                catch (Exception ex)
                {
                    msj = ex.ToString();
                }
            }
            catch (Exception x)
            {
                msj = "Error: " + x.ToString();

            }

            return val;

        }

        public static Bodys.Response GetAEL(Bodys.AbsEntryLocation AEL)
        {
            Bodys.Response resp = new Bodys.Response();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Open();
            string request = AEL.bincode;
            request = request.Remove(0, 1);
            try
            {
                string query = "SELECT \"BinCode\" " +
                            "FROM "+manhattan.Properties.Settings.Default.CompanyDB+".OBIN " +
                            "WHERE \"AbsEntry\" = '" + request + "'";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
                var json = "";
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        json = reader.GetString(0);

                    }
                }
                
                //HanaDataAdapter data = new HanaDataAdapter(cmd);
                //DataTable tabla = new DataTable();
                resp.AbsEntry = json;
                return resp;
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }

        }
        public static Bodys.Response GetOBCL(Bodys.OneBinCodeLocation OBCL)
        {
            Bodys.Response resp = new Bodys.Response();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Open();
            string request = OBCL.AbsEntry;
            //request = request.Remove(0, 1);
            try
            {
                string query = "SELECT \"AbsEntry\" " +
                            "FROM "+manhattan.Properties.Settings.Default.CompanyDB+".OBIN " +
                            "WHERE \"BinCode\" = '" + request + "'";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
                var json = "";
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        json = reader.GetString(0);

                    }
                }
                
                //HanaDataAdapter data = new HanaDataAdapter(cmd);
                //DataTable tabla = new DataTable();
                resp.AbsEntry = json;
                return resp;
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }

        }

        public static Bodys.Response GetBC(Bodys.BinCodeLocation BCL)
        {
            Bodys.Response resp = new Bodys.Response();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
            var request = BCL.BinCode;
            conn.Open();
            
            try
            {
                string query = "SELECT \"BinCode\" " +
                              "FROM "+manhattan.Properties.Settings.Default.CompanyDB+".OBIN " +
                              "WHERE \"WhsCode\" = '" + request + "'"  +
                              "AND (\"SL1Code\" = 'A' OR \"SL1Code\" = 'B' OR \"SL1Code\" = 'C' OR \"SL2Code\" = 'COMPRAS' OR \"SL1Code\" = 'RECIBO')";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
              
                List<Bodys.BinCodeLocation> ub = new List<Bodys.BinCodeLocation>();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //json = reader.GetString(x);
                        
                       
                        ub.Add(new Bodys.BinCodeLocation
                        {
                            BinCode = reader.GetString(0),
                        });
                    }
                }

                //HanaDataAdapter data = new HanaDataAdapter(cmd);
                //DataTable tabla = new DataTable();
                resp.ubications = ub;
                return resp;
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }
        }

        public static Bodys.Response GetBED(Bodys.BatchExpDate BED)
        {
            Bodys.Response resp = new Bodys.Response();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Open();
            var WhsCode = BED.WhsCode;
            var BatchNum = BED.Batch;
            var ItemCode = BED.ItemCode;
            //SB1CSL
            try
            {
                string query = "SELECT DISTINCT \"ExpDate\" " +
                                "FROM " + manhattan.Properties.Settings.Default.CompanyDB+".OIBT \r\n" +
                                "WHERE \"WhsCode\" = '" + WhsCode + "'" +
                                "AND \"BatchNum\" = '" + BatchNum + "'" +
                                "AND \"ItemCode\" = '" + ItemCode + "'" +
                                "AND \"Quantity\" > 0";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
                var json = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        json = reader.GetString(0);

                    }
                }

                //HanaDataAdapter data = new HanaDataAdapter(cmd);
                //DataTable tabla = new DataTable();
                resp.ExpDate = json;
                return resp;
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }

        }

        public static Bodys.Response GetWPO(Bodys.WhsPurchasesOrders WPO)
        {
            Bodys.Response resp = new Bodys.Response();
            HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");

            conn.Open();
            var WhsCode = WPO.WhsCode;
            
            //SB1CSL
            try
            {
                string query = "SELECT DISTINCT " +
                                "T0.\"DocEntry\", " +
                                "T0.\"DocNum\", " +
                                "T0.\"CardCode\", " +
                                "T0.\"CardName\", " +
                                "T0.\"DocDate\", " +
                                "T0.\"U_EntradaAut\", " +
                                "T1.\"WhsCode\", " +
                                "T1.\"LineNum\", " +
                                "T1.\"ItemCode\" , " +
                                "T1.\"Dscription\" , " +
                                "IFNULL(T1.\"CodeBars\",'0') ," +
                                "T1.\"Quantity\", " +
                                "T1.\"LineStatus\"" +
                                "FROM "+manhattan.Properties.Settings.Default.CompanyDB+".OPOR T0 " +
                                "INNER JOIN "+manhattan.Properties.Settings.Default.CompanyDB+".POR1 T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" " +
                                "WHERE T0.\"DocStatus\"= 'O' AND T1.\"WhsCode\" = '" + WhsCode + "'" +
                                "ORDER BY T0.\"DocNum\", T1.\"LineNum\"";
                HanaCommand cmd = new HanaCommand(query, conn);
                HanaDataReader reader = cmd.ExecuteReader();
                int x = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        x++;
                    }
                }
                var json = "";

                cmd = new HanaCommand(query, conn);
                reader = cmd.ExecuteReader();

                List<Bodys.PurcharsesOrdersOpen> poo = new List<Bodys.PurcharsesOrdersOpen>();
                Bodys.PurcharsesOrdersOpen lista = new Bodys.PurcharsesOrdersOpen();
                lista.details = new List<Bodys.PurchasesOrdersOpenDetails>();
                Bodys.PurchasesOrdersOpenDetails detalle = new Bodys.PurchasesOrdersOpenDetails();
                if (reader.HasRows)
                {
                    int documento = 0;
                    int y = 0;
                    while (reader.Read())
                    {
                        //json = reader.GetString(x);
                        //var resprespp = reader.GetInt32(0);
                        //int perro = Convert.ToInt32(reader.GetString(11));

                        //double perro = Convert.ToInt32(Convert.ToDouble(reader.GetString(11)));

                        //int perros = reader.GetInt32.Parse(11);
                        //if (documento != reader.GetInt32(0))
                        //{
                        if (documento != 0 && documento != reader.GetInt32(0))
                        {
                            poo.Add(lista);
                           
                            lista = new Bodys.PurcharsesOrdersOpen();
                            lista.details = new List<Bodys.PurchasesOrdersOpenDetails>();
                            detalle = new Bodys.PurchasesOrdersOpenDetails();
                        }
                        documento = reader.GetInt32(0);

                        lista.DocEntry = reader.GetInt32(0);
                        lista.DocNum = reader.GetInt32(1);
                        lista.CardCode = reader.GetString(2);
                        lista.CardName = reader.GetString(3);
                        lista.DocDate = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                        lista.EntradaAut = reader.GetString(5);


                        if (documento == reader.GetInt32(0))
                        {
                            detalle.WhsCode = reader.GetString(6);
                            detalle.LineNum = reader.GetInt32(7);
                            detalle.ItemCode = reader.GetString(8);
                            detalle.Description = reader.GetString(9);
                            detalle.CodeBars = reader.GetString(10);
                            detalle.Quantity = Convert.ToInt32(Convert.ToDouble(reader.GetString(11)));
                            //Quantity = Convert.ToInt32(reader.GetString(11)),
                            detalle.LineStatus = reader.GetString(12);
                            y++;
                            lista.details.Add(detalle);
                            detalle = new Bodys.PurchasesOrdersOpenDetails();
                        }
                        if (x == y)
                        {
                            poo.Add(lista);

                            lista = new Bodys.PurcharsesOrdersOpen();
                            lista.details = new List<Bodys.PurchasesOrdersOpenDetails>();
                            detalle = new Bodys.PurchasesOrdersOpenDetails();
                        }
                        //}
                        //else
                        //{
                        //    detalle.WhsCode = reader.GetString(6);
                        //    detalle.LineNum = reader.GetInt32(7);
                        //    detalle.ItemCode = reader.GetString(8);
                        //    detalle.Description = reader.GetString(9);
                        //    detalle.CodeBars = reader.GetString(10);
                        //    detalle.Quantity = Convert.ToInt32(Convert.ToDouble(reader.GetString(11)));
                        //    //Quantity = Convert.ToInt32(reader.GetString(11)),
                        //    detalle.LineStatus = reader.GetString(12);

                        //    lista.details.Add(detalle);
                        //}
                        //poo.Add(new Bodys.PurcharsesOrdersOpen
                        //{
                        //    DocEntry = reader.GetInt32(0),
                        //    DocNum = reader.GetInt32(1),
                        //    CardCode = reader.GetString(2),
                        //    CardName = reader.GetString(3),
                        //    DocDate = reader.GetDateTime(4).ToString("yyyy-MM-dd"),
                        //    EntradaAut = reader.GetString(5),
                        //    WhsCode = reader.GetString(6),
                        //    LineNum = reader.GetInt32(7),
                        //    ItemCode = reader.GetString(8),
                        //    Description = reader.GetString(9),
                        //    CodeBars = reader.GetString(10),
                        //    Quantity = Convert.ToInt32(Convert.ToDouble(reader.GetString(11))),
                        //    //Quantity = Convert.ToInt32(reader.GetString(11)),
                        //    LineStatus = reader.GetString(12)

                        //});

                    }
                }

                //HanaDataAdapter data = new HanaDataAdapter(cmd);
                //DataTable tabla = new DataTable();
                resp.purcharsesOrders = poo;
                return resp;
            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }

        }

        //public static SAPbobsCOM.Company LoginSDK(Bodys.Login login)
        //{
        //    try
        //    {
        //        oCompany = new SAPbobsCOM.Company();



        //        oCompany.Server = Settings.Default.Server;

        //        oCompany.CompanyDB = Settings.Default.CompanyDB;

        //        oCompany.UserName = login.User;
        //        oCompany.Password = login.Pwd;

        //        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



        //        oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
        //        //  oCompany.SLDServer = "hanab1:30015";


        //        int lRetCode = oCompany.Connect();

        //        if (lRetCode != 0)
        //        {
        //            sErrMsg = oCompany.GetLastErrorDescription();
        //            Console.WriteLine("Error al conectar a SAP" + sErrMsg);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Conexion exitosa");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        sErrMsg = ex.Message;

        //        string path = Application.CommonAppDataPath + "\\Log.txt";
        //        string texto = ex.Message;
        //        File.AppendAllLines(path, new String[] { texto });
        //    }

        //    return oCompany;
        //}

        //public static MerchandesSlayer ValidateLineStatus(MerchandesSlayer VLS , ref bool Status)
        //{
        //    try
        //    {
        //        HanaConnection conn = new HanaConnection("Server=Hanab1:30013;UserID=SYSTEM;Password=B1AdminH2;Database=NDB");
        //        conn.Close();
        //        conn.Open();
        //        string json = string.Empty;
        //        for (int i = 0; i < VLS.DocumentLines.Count; i++)
        //        {

        //            //request = CMRSL.DocumentLines.FirstOrDefault().BaseEntry;


        //            string query = "SELECT DISTINCT \"LineStatus\" " +
        //                               "FROM " + manhattan.Properties.Settings.Default.CompanyDB + ".POR1 " +
        //                               "WHERE \"LineNum\" IN (" + VLS.DocumentLines[i].BaseLine.ToString() + ") AND \"DocEntry\" = " + VLS.DocumentLines[i].BaseEntry.ToString();
        //            HanaCommand cmd = new HanaCommand(query, conn);
        //            HanaDataReader reader = cmd.ExecuteReader();
        //            json = "";

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    json = reader.GetString(0);
        //                    if (json == "C")
        //                    { 
        //                        VLS.DocumentLines[i].StatusLine = json;
        //                        Status = true;
        //                    }
        //                }
        //            }

        //        }

        //        conn.Close();
        //        return VLS;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public static Bodys.Response CreateOV(Bodys.Orders Request)
        {
            // Bodys.Orders oOrderDoc = new Bodys.Orders();
            Bodys.Response resp = new Bodys.Response();
          
            ///SAPbobsCOM.Company oCompany = ConexionSAP.Open();
       
            //if (result != 0)
            //{
            //    resp.conflicts = new List<Bodys.Conflicts>();

            //    resp.conflicts.Add(new Bodys.Conflicts
            //    {
            //        Problems = true,
            //        Description = "Hubo un error en la conexion: " + oCompany.GetLastErrorDescription(),
            //    });
            //    return resp;
            //}

            oCompany = new SAPbobsCOM.Company();

          

            oCompany.Server = Settings.Default.Server;

            oCompany.CompanyDB = Settings.Default.CompanyDB;

            oCompany.UserName = Settings.Default.UserName;
            oCompany.Password = Settings.Default.Password;
            
            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;

            

            oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            //  oCompany.SLDServer = "hanab1:30015";


            lRetCode = oCompany.Connect();

            if (lRetCode != 0)
            {
                sErrMsg = oCompany.GetLastErrorDescription();
                Console.WriteLine("Error al conectar a SAP" + sErrMsg);
            }
            else
            {
                Console.WriteLine("Conexion exitosa");
            }

           



            try
            {
               SAPbobsCOM.Documents oDrafts = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts);
           




                oDrafts.GetByKey(Request.DocEntry);


                lRetCode = oDrafts.SaveDraftToDocument();

                if (lRetCode!=0)
                {
                    resp.conflicts = new List<Bodys.Conflicts>();

                    resp.conflicts.Add(new Bodys.Conflicts
                    {
                        Problems = true,
                        Description = oCompany.GetLastErrorDescription(),
                    });

                    return resp;
                }
                else
                {
                    SAPbobsCOM.Company Ocompany = null;
                    HanaConnection conn = new HanaConnection(Settings.Default.HanaConnection);
                    HanaCommand cmd = new HanaCommand();
                    HanaDataReader reader;
                    var DocNum = 0;

                    retKey = oCompany.GetNewObjectKey();
                    retType = oCompany.GetNewObjectType();

                    string sQuery = "SELECT T0.\"DocNum\" FROM "+Settings.Default.CompanyDB+".ORDR T0 WHERE T0.\"DocEntry\" =  '" + retKey + "' \r\n";
                    conn.Open();
                    cmd= new HanaCommand(sQuery,conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                         reader.Read();
                        DocNum = reader.GetInt32(0);    
                    }



                    conn.Close();
                    resp.DocEntry=DocNum.ToString();

                    oCompany.Disconnect();
                    return resp;

                   
                }
              

            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }


        }

        public static Bodys.Response CreateOC(Bodys.Purchases purchases)
        {
            Bodys.Response resp = new Bodys.Response();

            

            oCompany = new SAPbobsCOM.Company();



            oCompany.Server = Settings.Default.Server;

            oCompany.CompanyDB = Settings.Default.CompanyDB;

            oCompany.UserName = Settings.Default.UserName;
            oCompany.Password = Settings.Default.Password;

            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;



            oCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            //  oCompany.SLDServer = "hanab1:30015";


            lRetCode = oCompany.Connect();

            if (lRetCode != 0)
            {
                sErrMsg = oCompany.GetLastErrorDescription();
                Console.WriteLine("Error al conectar a SAP" + sErrMsg);
            }
            else
            {
                Console.WriteLine("Conexion exitosa");
            }





            try
            {
               SAPbobsCOM.Documents oPurchaseOrders = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);


                oPurchaseOrders.CardCode = purchases.CardCode;
                oPurchaseOrders.DocDueDate = DateTime.Now;
                oPurchaseOrders.TaxDate = DateTime.Now;
                oPurchaseOrders.Comments = purchases.Comments;
                oPurchaseOrders.UserFields.Fields.Item("U_Sucursal").Value = purchases.U_Sucursal;
                oPurchaseOrders.UserFields.Fields.Item("U_MetodoPago").Value = purchases.U_MetodoPago;

                foreach (var item in purchases.DocumentLinesSDK)
                {
                    oPurchaseOrders.Lines.ItemCode = item.ItemCode;
                    oPurchaseOrders.Lines.Quantity = item.Quantity;
                    oPurchaseOrders.Lines.TaxCode= item.TaxCode;
                    oPurchaseOrders.Lines.UnitPrice = item.UnitPrice;
                    //oPurchaseOrders.Lines.li
                    oPurchaseOrders.Lines.Add();
                }

                lRetCode = oPurchaseOrders.Add();
                if (lRetCode != 0)
                {
                    resp.conflicts = new List<Bodys.Conflicts>();

                    resp.conflicts.Add(new Bodys.Conflicts
                    {
                        Problems = true,
                        Description = oCompany.GetLastErrorDescription(),
                    });

                    return resp;
                }
                else
                {
                    resp.DocEntry = "Documento generado";
                    return resp;
                }


            }
            catch (WebException ex)
            {
                Bodys.Conflicts c = new Bodys.Conflicts();
                List<Bodys.Conflicts> conflicts = new List<Bodys.Conflicts>();
                resp.conflicts = new List<Bodys.Conflicts>();
                c.Problems = true;
                using (WebResponse response = ex.Response)
                {
                    // TODO: Handle response being null
                    //HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data2 = response.GetResponseStream())
                    using (var reader2 = new StreamReader(data2))
                    {
                        c.Description = reader2.ReadToEnd();
                        manhattan.Logs.Logs.LogSinConexion(c.Description);
                        //var model = JsonConvert.DeserializeObject<DL.listas.errores>(text);
                        //Log(model.error.message.value);
                        conflicts.Add(c);
                        resp.conflicts = conflicts;
                    }
                }
                return resp;

            }


        }

    }

    //public class Login
    //{
    //    public string CompanyDB { get; set; }
    //    public string Password { get; set; }
    //    public string UserName { get; set; }
    //}

}