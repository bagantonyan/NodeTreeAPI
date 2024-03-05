using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Entities;
using NodeTree.DAL.UnitOfWork;

namespace NodeTree.BLL.Services
{
    public class JournalRecordService : IJournalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JournalRecordService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task CreateAsync(JournalRecord requestDTO)
        {
            _unitOfWork.JournalRecordRepository.Create(requestDTO);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
