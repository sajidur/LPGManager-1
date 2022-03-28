using AutoMapper;
using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Common
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PurchaseDetailsDtos, PurchaseDetails>().ReverseMap();
            CreateMap<PurchaseMasterDtos, PurchaseMaster>().ReverseMap();
        }
    }
}
