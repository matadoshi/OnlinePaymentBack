﻿using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomers();
    }
}
