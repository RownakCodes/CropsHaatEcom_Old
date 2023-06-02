namespace E_Commerce
{
    public class BkashErrorHandeler
    {
        public static string ErrorDetails(string ErrorCode)
        {
            switch (ErrorCode)
            {
                case "2001":
                    return "Invalid App Key";
                case "2002":
                    return "Invalid Payment ID";
                case "2003":
                    return "Process failed";
                case "2004":
                    return "Invalid firstPaymentDate";
                case "2005":
                    return "Invalid frequency";
                case "2006":
                    return "Invalid amount";
                case "2007":
                    return "Invalid currency";
                case "2008":
                    return "Invalid intent";
                case "2009":
                    return "Invalid Wallet";
                case "2010":
                    return "Invalid OTP";
                case "2011":
                    return "Invalid PIN";
                case "2012":
                    return "Invalid Receiver MSISDN";
                case "2013":
                    return "Resend Limit Exceeded";
                case "2014":
                    return "Wrong PIN";
                case "2015":
                    return "Wrong PIN count exceeded";
                case "2016":
                    return "Wrong verification code";
                case "2017":
                    return "Wrong verification limit exceeded";
                case "2018":
                    return "OTP verification time expired";
                case "2019":
                    return "PIN verification time expired";
                case "2020":
                    return "Exception Occurred";
                case "2021":
                    return "Invalid Mandate ID";
                case "2022":
                    return "The mandate does not exist";
                case "2023":
                    return "Insufficient Balance";
                case "2024":
                    return "Exception occurred";
                case "2025":
                    return "Invalid request body";
                case "2026":
                    return "The reversal amount cannot be greater than the original transaction amount";
                case "2027":
                    return "The mandate corresponding to the payer reference number already exists and cannot be created again";
                case "2028":
                    return "Reverse failed because the transaction serial number does not exist";
                case "2029":
                    return "Duplicate for all transactions";
                case "2030":
                    return "Invalid mandate request type";
                case "2031":
                    return "Invalid merchant invoice number";
                case "2032":
                    return "Invalid transfer type";
                case "2033":
                    return "Transaction not found";
                case "2034":
                    return "The transaction cannot be reversed because the original transaction has been reversed";
                case "2035":
                    return "Reverse failed because the initiator has no permission to reverse the transaction";
                case "2036":
                    return "The direct debit mandate is not in Active state";
                case "2037":
                    return "The account of the debit party is in a state which prohibits execution of this transaction";
                case "2038":
                    return "Debit party identity tag prohibits execution of this transaction";
                case "2039":
                    return "The account of the credit party is in a state which prohibits execution of this transaction";
                case "2040":
                    return "Credit party identity tag prohibits execution of this transaction";
                case "2041":
                    return "Credit party identity is in a state which does not support the current service";
                case "2042":
                    return "Reverse failed because the initiator has no permission to reverse the transaction.";
                case "2043":
                    return "The security credential of the subscriber is incorrect.";
                case "2044":
                    return "Identity has not subscribed to a product that contains the expected service or the identity is not in Active status.";
                case "2045":
                    return "The MSISDN of the customer does not exist.";
                case "2046":
                    return "Identity has not subscribed to a product that contains requested service.";
                case "2047":
                    return "TLV Data Format Error";
                case "2048":
                    return "Invalid Payer Reference";
                case "2049":
                    return "Invalid Merchant Callback URL";
                case "2050":
                    return "Agreement already exists between payer and merchant";
                case "2051":
                    return "Invalid Agreement ID";
                case "2052":
                    return "Agreement is in incomplete state";
                case "2053":
                    return "Agreement has already been cancelled";
                case "2054":
                    return "Agreement execution pre-requisite hasn't been met";
                case "2055":
                    return "Invalid Agreement State";
                case "2056":
                    return "Invalid Payment State";
                case "2057":
                    return "Not a bKash Account";
                case "2058":
                    return "Not a Customer Wallet";
                case "2059":
                    return "Multiple OTP request for a single session denied";
                case "2060":
                    return "Payment execution pre-requisite hasn't been met";
                case "2061":
                    return "This action can only be performed by the agreement or payment initiator party";
                case "2062":
                    return "The payment has already been completed";
                case "2063":
                    return "Mode is not valid as per request data";
                case "2064":
                    return "This product mode currently unavailable";
                case "2065":
                    return "Mendatory field missing";
                case "2066":
                    return "Agreement is not shared with other merchant";
                case "2067":
                    return "Invalid permission";
                case "2068":
                    return "Transaction has already been completed";
                case "2069":
                    return "Transaction has already been cancelled";
                case "503":
                    return "System is undergoing maintenance. Please try again later";


            }
            return "Invalid Error Code";
        }

    }
}
