using AutoMapper;
using LPGManager.Dtos;
using LPGManager.Models;

namespace LPGManager.Data.Services.Ledger
{
    public class LedgerPostingService: ILedgerPostingService
    {
        private IGenericRepository<LedgerPosting> _ledgerRepository;
        IMapper _mapper;
        public LedgerPostingService(IGenericRepository<LedgerPosting> ledgerRepository, IMapper mapper)
        {
            _ledgerRepository = ledgerRepository;
            _mapper = mapper;
        }
        public LedgerPostingDtos AddAsync(LedgerPostingDtos model)
        {
            LedgerPostingDtos result;
            try
            {
                var item = _mapper.Map<LedgerPosting>(model);
                var inv = _ledgerRepository.FindBy(a => a.LedgerId == item.LedgerId);
                if (inv.Count()>0)
                {
                    item.Balance = (inv.Sum(a=>a.Debit)-inv.Sum(a=>a.Credit))-(item.Debit - item.Credit);
                }
                else
                {
                    item.Balance = item.Debit - item.Credit;
                }
                _ledgerRepository.Insert(item);
                _ledgerRepository.Save();
                return _mapper.Map<LedgerPostingDtos>(item);

            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                  $"{ex}.");
            }

        }
        public List<LedgerPostingDtos> FindByLedgerId(int ledgerId)
        {
           var data= _ledgerRepository.FindBy(a=>a.LedgerId== ledgerId).ToList();
            return _mapper.Map<List<LedgerPostingDtos>>(data);
        }
    }

    public interface ILedgerPostingService
    {
        LedgerPostingDtos AddAsync(LedgerPostingDtos model);
        List<LedgerPostingDtos> FindByLedgerId(int ledgerId);
    }
}
