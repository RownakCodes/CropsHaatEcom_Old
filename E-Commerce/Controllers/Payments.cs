using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.Controllers
{
    public class Payments : Controller
    {
        public IActionResult CitybankPayment(string Invoice)
        {
            string result = CityBankIPG.CityBankGetOrderDetails(
                               GetData.GetOrderID_PaymentIDfromIPG(Invoice),
                               GetData.GetSessionID_TrXIDfromIPG(Invoice)
                
                            );
            dynamic Responce = JsonConvert.DeserializeObject(result);
            
            if (Responce.orderStatus =="APPROVED")
            {
                dbUpdater.OrderStatusUpdater(Invoice, "Order Placed");
                dbUpdater.PaymentMethodUpdater(Invoice, "Card");
                TempData["success"] = "Payment Accepted" ;
                TempData["Header"] = "ORDER PLACED";
            }
            if (Responce.orderStatus == "CANCELED")
            {
                dbUpdater.OrderStatusUpdater(Invoice, "Card Payment Cancelled");
                dbUpdater.PaymentMethodUpdater(Invoice, "Card");
                TempData["Error"] = "Payment failure";
                TempData["Header"] = "ORDER PLACED";
            }
            if (Responce.orderStatus == "DECLINED")
            {
                dbUpdater.OrderStatusUpdater(Invoice, "Card Payment Declined");
                dbUpdater.PaymentMethodUpdater(Invoice, "Card");
                TempData["Error"] = "Payment failure";
                TempData["Header"] = "ORDER PLACED";
            }


            return RedirectToAction("Index", "Home");
        }
      
        
        public IActionResult BkashError(string ErrorCode)
        {

            TempData["Error"] = "Payment failure";
            TempData["Header"] = BkashErrorHandeler.ErrorDetails(ErrorCode);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult BkashExecutePayment(string paymentID, string status)
        {
            if(status== "success")
            {
                string Responce = BkashPGW.Execute(paymentID);
                if (int.TryParse(Responce, out _))
                {
                    dbUpdater.OrderStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "BKash Payment Error");
                    return RedirectToAction("BkashError", "Payments", new { ErrorCode = Responce });
                }
                dbUpdater.OrderStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "Order Placed");
                dbUpdater.PaymentMethodUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "Bkash");
                TempData["success"] = "trxID: " + Responce;
                TempData["Header"] = "ORDER PLACED";
            }
            if(status== "failure")
            {

                dbUpdater.OrderStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "BKash Payment Error");
                TempData["Error"] = "Payment failure";
                TempData["Header"] = "ORDER PLACED";
            }
            if(status== "cancel")
            {

                dbUpdater.OrderStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "BKash Payment Cancelled");
                TempData["Error"] = "Payment Cancelled";
                TempData["Header"] = "ORDER PLACED";
            }
            
            
            return RedirectToAction("Index", "Home");
        }
      
        
        
        public IActionResult ApplicationBkashError(string ErrorCode)
        {

            TempData["Error"] = "Payment failure";
            TempData["Header"] = BkashErrorHandeler.ErrorDetails(ErrorCode);
            return RedirectToAction("Delegates", "Home");
        }

        public IActionResult ApplicationBkashExecutePayment(string paymentID, string status)
        {
            if(status== "success")
            {
                string applicationID = GetData.GetInvoiceIDfromIPG(paymentID);
                string Responce = BkashPGW.Execute(paymentID);
                if (int.TryParse(Responce, out _))
                {
                    dbUpdater.ApplicationStatusUpdater(applicationID, "BKash Payment Error");
                    return RedirectToAction("ApplicationBkashError", "Payments", new { ErrorCode = Responce });
                }
                dbUpdater.ApplicationStatusUpdater(applicationID, "Payment Done");


                SMS.SendQuickSms(GetData.GetPhoneNumberOfDelegatesApplication(applicationID),
                    "Congratulations " + GetData.GetNameOfDelegatesApplication(applicationID) + ",\n"
                    +"Your Application of Crops Haat Delegates is placed. You Will be Updated Soon,\n" +
                    "Your Application ID: "+applicationID +
                    "\nRegards,\n" +
                    "Crops Haat Team"

                    );

                SMS.SendQuickSmsAdmin("New Delegated Application Placed.\nApplication ID : "+applicationID);
                TempData["success"] = "trxID: " + Responce;
                TempData["Header"] = "APPLICATION PLACED";
            }
            if(status== "failure")
            {

                dbUpdater.ApplicationStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "BKash Payment Error");
                TempData["Error"] = "Payment failure";
                TempData["Header"] = "ERROR!";
            }
            if(status== "cancel")
            {

                dbUpdater.ApplicationStatusUpdater(GetData.GetInvoiceIDfromIPG(paymentID), "BKash Payment Cancelled");
                TempData["Error"] = "Payment Cancelled";
                TempData["Header"] = "ERROR!";
            }
            
            
            return RedirectToAction("Delegates", "Home");
        }







    }
}
