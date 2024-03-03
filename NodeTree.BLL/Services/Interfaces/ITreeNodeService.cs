using NodeTree.BLL.DTOs.TreeNodes;

namespace NodeTree.BLL.Services.Interfaces
{
    public interface ITreeNodeService
    {
        Task CreateAsync(CreateTreeNodeRequestDTO requestDTO);
    }
}