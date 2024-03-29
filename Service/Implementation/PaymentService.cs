﻿using AutoMapper;
using DomainModels.Entities;
using DomainModels.Enum;
using Microsoft.AspNetCore.Hosting;
using Repository.Repository.Interfaces;
using RestSharp;
using RestSharp.Deserializers;
using Service.DTO.Payment;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly string _merchant;
        private readonly string _currency;
        private readonly string _pingUrl;
        private readonly string _decline;
        private readonly string _url;
        private readonly RestClient _client;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IRepository<Transaction> _repository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public PaymentService(IWebHostEnvironment hostEnvironment, IRepository<Transaction> repository, IRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _hostEnvironment = hostEnvironment;

            _merchant = "E1000010";
            _currency = "944";
            _pingUrl = "https://localhost:44319/payment/approve";
            _url = "https://tstpg.kapitalbank.az:5443/exec";
            _client = new RestClient(_url);

            var certPath = Path.Combine(_hostEnvironment.WebRootPath, "certificates/otelx-dev.pfx");


            var certificates = new X509Certificate2(File.ReadAllBytes(certPath), _merchant, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            _client.ClientCertificates = new X509CertificateCollection{
                certificates
            };
            _repository = repository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Transaction model)
        {
            await _repository.AddAsync(model);
        }

        public async Task<PaymentOrderResponseTkkpg> CreatePayment(CreatePaymentRequest createPayment)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var rawXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<TKKPG>" +
                "<Request>" +
                "<Operation>CreateOrder</Operation>" +
                "<Language>" + createPayment.LanguageCode + "</Language>" +
                "<Order>" +
                "<OrderType>Purchase</OrderType>" +
                "<Merchant>" + _merchant + "</Merchant>" +
                "<Amount>" + createPayment.Amount + "</Amount>" +
                "<CancelURL>" + _pingUrl + createPayment.Platform + "/decline</CancelURL>" +
                "<Currency>" + _currency + "</Currency>" +
                "<Description>" + createPayment.Description + "</Description>" +
                "<ApproveURL>" + _pingUrl + createPayment.Platform + "/approve</ApproveURL>" +
                "<DeclineURL>" + _pingUrl + createPayment.Platform + "/decline</DeclineURL>" +
                "</Order>" +
                "</Request>" +
                "</TKKPG>";

            var request = new RestRequest(Method.POST);

            request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

            var response = await _client.ExecuteAsync(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            var deserializer = new XmlDeserializer();
            return deserializer.Deserialize<PaymentOrderResponseTkkpg>(response);
        }

        public async Task<PaymentOrderStatusResponseTkkpg> GetPaymentStatus(PaymentStatusRequest paymentStatus)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var rawXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<TKKPG>" +
                "<Request>" +
                "<Operation>GetOrderStatus</Operation>" +
                "<Language>AZ</Language>" +
                "<Order>" +
                "<Merchant>" + _merchant + "</Merchant>" +
                "<OrderID>" + paymentStatus.PaymentOrderId + "</OrderID>" +
                "</Order>" +
                "<SessionID>" + paymentStatus.PaymentSessionId + "</SessionID>" +
                "</Request>" +
                "</TKKPG>";

            var request = new RestRequest(Method.POST);

            request.AddParameter("application/xml", rawXml, ParameterType.RequestBody);

            var response = await _client.ExecuteAsync(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            var deserializer = new XmlDeserializer();
            return deserializer.Deserialize<PaymentOrderStatusResponseTkkpg>(response);
        }

        public async Task PostAsync(PaymentPostDto model)
        {
            Invoice invoice = _mapper.Map<Invoice>(model);

            invoice.Card.CVV = model.Card.CVV;
            invoice.User.FullName = model.FullName;
            invoice.Card.Number = model.Card.Number;
            invoice.Card.ExpirationDate = model.Card.ExpirationDate;
            invoice.Transaction.OrderStatus = OrderStatus.Pending;
            await _invoiceRepository.AddAsync(invoice);
        }

    }

}
