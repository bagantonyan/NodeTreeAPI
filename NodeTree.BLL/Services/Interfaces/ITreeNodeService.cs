using NodeTree.BLL.DTOs.TreeNodes;

namespace NodeTree.BLL.Services.Interfaces
{
    public interface ITreeNodeService
    {
        Task CreateAsync(CreateNodeRequestDTO requestDTO);

        Task DeleteAsync(DeleteNodeRequestDTO requestDTO);

        Task RenameAsync(RenameNodeRequestDTO requestDTO);

        Task<TreeResponseDTO> GetTreeAsync(string treeName);
    }
}