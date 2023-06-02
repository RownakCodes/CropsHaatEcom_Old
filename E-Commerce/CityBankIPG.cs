using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace E_Commerce
{
    public class TheCityBankIPG
    {

        public static string CityBankMerchant = "9107629784";
        public static string CityBankproxy = "";
        public static string CityBankproxyauth = "";
        public static string CityBankUserName = "cropshaat";
        public static string CityBankPassword = "123456Aa";
        public static string CityBankBaseUrl = "https://ecomm-webservice.thecitybank.com:7788/";
        // public static string CityBankBaseUrl = "https://sandbox.thecitybank.com:7788/";
        public static string CityBankServiceUrltoken = CityBankBaseUrl + "transaction/token";
        public static string CityBankServiceUrlEcom = CityBankBaseUrl + "transaction/createorder";
        public static string CityBankGetOrderDetailsUrl = CityBankBaseUrl + "transaction/getorderdetailsapi";
        // public static string CityBankCertPath = "D:/DEVELOPMENT/Git/cropshaatecom/E-Commerce/wwwroot/";
        public static string CityBankCertPath = "./";
        // public static string CallbackServer = "https://localhost:5001/";
        public static string CallbackServer = "https://www.cropshaat.com/";
        public static string GetToken() 
        {
            var url = CityBankBaseUrl + "transaction/token";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Method = "POST";

            httpRequest.Accept = ".s";
            httpRequest.ContentType = "application/json";
            httpRequest.ServerCertificateValidationCallback = (e, r, c, n) => true;

            var pfxPath = CityBankCertPath + "13.250.70.239.pfx";
            //var pfxPath = CityBankCertPath + "13.250.70.239.pfx";
            X509Certificate2 cert = new X509Certificate2(pfxPath, "02468");


            httpRequest.ClientCertificates.Add(cert);



            string data = $@"
                        {{
                                
                                 ""userName"": ""{CityBankUserName}"",
                               
                                 ""password"": ""{CityBankPassword}""
                             
                        }}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                dynamic output = JsonConvert.DeserializeObject(result);
                PostData.InsertApiResponder("CityBank", "debuger", output.transactionId);
                return output.transactionId;


            }


        }
    }
}
