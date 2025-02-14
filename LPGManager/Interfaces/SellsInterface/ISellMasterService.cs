﻿using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Interfaces.SellsInterface
{
    public interface ISellMasterService
    {
     
        List<SellMasterDtos> GetAllAsync(long tenantId);
        List<SellMasterDtos> GetAllAsyncByCustomerId(int customerId);
        List<SellMasterDtos> GetAllAsync(long startDate, long endDate, long tenantId);
        SellMasterDtos GetAsync(long id);
        SellMaster AddAsync(SellMasterDtos model);
        Task<SellMaster> DueReceive(List<DueReceiveDtos> dueReceives, User user);
        Task<SellMaster> UpdateAsync(SellMasterDtos model);
        Task DeleteAsync(long id);
        Task<SellMaster> Delivery(DeliveryDtos sellMaster);
    }
}
