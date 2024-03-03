using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.UnitOfWork;

namespace NodeTree.BLL.Services
{
    public class TreeNodeService : ITreeNodeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreeNodeService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task CreateAsync(CreateTreeNodeRequestDTO requestDTO)
        {
            var rootNode = await _unitOfWork.TreeNodeRepository.GetRootNodeByNameAsync(requestDTO.TreeName);


        }
    }
}
