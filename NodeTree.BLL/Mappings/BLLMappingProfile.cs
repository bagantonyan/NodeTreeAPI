﻿using AutoMapper;
using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.DAL.Entities;

namespace NodeTree.BLL.Mappings
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<CreateNodeRequestDTO, TreeNode>()
                .ForMember(dst => dst.Name, options => options.MapFrom(src => src.NodeName));

            CreateMap<TreeNode, TreeResponseDTO>();
        }
    }
}