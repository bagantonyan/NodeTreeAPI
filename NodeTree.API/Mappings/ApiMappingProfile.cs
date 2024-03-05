using AutoMapper;
using NodeTree.API.Models.Journal;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.BLL.DTOs.TreeNodes;

namespace NodeTree.API.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateNodeRequestModel, CreateNodeRequestDTO>();
            CreateMap<DeleteNodeRequestModel, DeleteNodeRequestDTO>();
            CreateMap<RenameNodeRequestModel, RenameNodeRequestDTO>();

            CreateMap<TreeResponseDTO, TreeResponseModel>();

            CreateMap<JournalRecordDTO, JournalRecordResponseModel>();
        }
    }
}