using DomainModels.Entities;
using Service.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Service.Interfaces
{
        public interface IPaymentService
        {
            Task<PaymentOrderResponseTkkpg> CreatePayment(CreatePaymentRequest createPayment);
            Task<PaymentOrderStatusResponseTkkpg> GetPaymentStatus(PaymentStatusRequest paymentStatusRequest);
            Task AddAsync(Transaction model);
        Task PostAsync(PaymentPostDto model);
        }

    #region New payment region
    public class CreatePaymentRequest
        {
            public string Platform;
            public string LanguageCode { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
        }

        [XmlRoot(ElementName = "Order")]
        public class PaymentOrderResponsePayload
        {
            [XmlElement(ElementName = "OrderID")]
            public string OrderId { get; set; }
            [XmlElement(ElementName = "SessionID")]
            public string SessionId { get; set; }
            [XmlElement(ElementName = "URL")]
            public string Url { get; set; }
        }

        [XmlRoot(ElementName = "Response")]
        public class PaymentOrderResponse
        {
            [XmlElement(ElementName = "Operation")]
            public string Operation { get; set; }
            [XmlElement(ElementName = "Status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "Order")]
            public PaymentOrderResponsePayload Order { get; set; }
        }

        [XmlRoot(ElementName = "TKKPG")]
        public class PaymentOrderResponseTkkpg
        {
            [XmlElement(ElementName = "Response")]
            public PaymentOrderResponse Response { get; set; }
        }
        #endregion

        #region Get payment info

        public class PaymentStatusRequest
        {
            public string LanguageCode { get; set; }
            public string PaymentOrderId { get; set; }
            public string PaymentSessionId { get; set; }
        }

        [XmlRoot(ElementName = "Order")]
        public class PaymentOrderStatusResponsePayload
        {
            [XmlElement(ElementName = "OrderID")]
            public string OrderId { get; set; }
            [XmlElement(ElementName = "OrderStatus")]
            public string OrderStatus { get; set; }
        }

        [XmlRoot(ElementName = "AdditionalInfo")]
        public class AdditionalInfo
        {
            [XmlElement(ElementName = "Receipt")]
            public string Receipt { get; set; }
        }

        [XmlRoot(ElementName = "Response")]
        public class PaymentOrderStatusResponse
        {
            [XmlElement(ElementName = "Operation")]
            public string Operation { get; set; }
            [XmlElement(ElementName = "Status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "Order")]
            public PaymentOrderStatusResponsePayload Order { get; set; }
            [XmlElement(ElementName = "AdditionalInfo")]
            public AdditionalInfo AdditionalInfo { get; set; }
        }

        [XmlRoot(ElementName = "TKKPG")]
        public class PaymentOrderStatusResponseTkkpg
        {
            [XmlElement(ElementName = "Response")]
            public PaymentOrderStatusResponse Response { get; set; }
        }

        public static class PaymentStatus
        {
            public static string Created => "CREATED";
            public static string OnLock => "ON-LOCK";
            public static string OnPayment => "ON-PAYMENT";
            public static string Approved => "APPROVED";
            public static string Cancelled => "CANCELLED";
            public static string Declined => "DECLINED";
            public static string Expired => "EXPIRED";

            public static string[] Payable => new[] { "CANCELLED", "DECLINED", "EXPIRED" };
            public static string[] NonPayable => new[] { "ON-LOCK", "ON-PAYMENT", "APPROVED" };

        }

        public static class PaymentOrderStatus
        {
            public static string Successful => "00";
            public static string InvalidRequest => "30";
            public static string Unauthorized => "10";
            public static string Invalid => "54";
            public static string SystemError => "96";
        }

        #endregion
}
