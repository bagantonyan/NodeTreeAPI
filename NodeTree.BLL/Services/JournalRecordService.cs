using AutoMapper;
using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Entities;
using NodeTree.DAL.UnitOfWork;
using NodeTree.Shared.Exceptions;
using NodeTree.Shared.RequestFeatures;

namespace NodeTree.BLL.Services
{
    public class JournalRecordService : IJournalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JournalRecordService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JournalRecordDTO> GetByIdAsync(long recordId)
        {
            var record = await _unitOfWork.JournalRecordRepository.GetByIdAsync(recordId);

            if (record == null)
                throw new NotFoundRecordException();

            return _mapper.Map<JournalRecordDTO>(record);
        }

        public async Task<(IEnumerable<JournalRecordDTO>, long)> GetRangeWithPagingAndFilterAsync(PagingModel paging, FilterModel filter)
        {
            var (records, totalCount) = await _unitOfWork.JournalRecordRepository.GetRangeWithPagingAndFilterAsync(paging, filter);

            return (_mapper.Map<IEnumerable<JournalRecordDTO>>(records), totalCount);
        }

        public async Task CreateAsync(JournalRecord journalRecord)
        {
            _unitOfWork.JournalRecordRepository.Create(journalRecord);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(JournalRecord journalRecord)
        {
            _unitOfWork.JournalRecordRepository.Update(journalRecord);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}