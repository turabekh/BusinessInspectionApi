﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBusinessRepository : IRepositoryBase<Business>
    {
        Task<IEnumerable<Business>> GetAllBusinesses();
        Task<Business> GetBusinessById(int id);
        Task<Business> GetBusinessByBRCCode(string brcCode);
        
    }
}
