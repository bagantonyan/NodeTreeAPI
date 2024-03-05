﻿using AutoMapper;
using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Entities;
using NodeTree.DAL.UnitOfWork;
using NodeTree.Shared.Exceptions;

namespace NodeTree.BLL.Services
{
    public class TreeNodeService : ITreeNodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TreeNodeService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TreeResponseDTO> GetTreeAsync(string treeName)
        {
            var treeNodes = await _unitOfWork.TreeNodeRepository.GetTreeNodesAsync(treeName);

            var nodeTree = treeNodes.Where(n => n.Name == treeName && n.ParentNodeId == null).SingleOrDefault();

            return _mapper.Map<TreeResponseDTO>(nodeTree);
        }

        public async Task CreateAsync(CreateNodeRequestDTO requestDTO)
        {
            await ValidateNodeData(requestDTO.ParentNodeId, requestDTO.TreeName);

            await CheckDuplicates(requestDTO.ParentNodeId, requestDTO.NodeName);

            _unitOfWork.TreeNodeRepository.Create(_mapper.Map<TreeNode>(requestDTO));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(DeleteNodeRequestDTO requestDTO)
        {
            await ValidateNodeData(requestDTO.NodeId, requestDTO.TreeName);

            var treeNode = await _unitOfWork.TreeNodeRepository
                .GetByIdAsync(requestDTO.NodeId, trackChanges: true, includeChildren: true);

            if (treeNode.Children.Count > 0)
                throw new SecureException("You have to delete all children nodes first");

            _unitOfWork.TreeNodeRepository.Delete(treeNode);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RenameAsync(RenameNodeRequestDTO requestDTO)
        {
            await ValidateNodeData(requestDTO.NodeId, requestDTO.TreeName);

            var treeNode = await _unitOfWork.TreeNodeRepository.GetByIdAsync(requestDTO.NodeId, trackChanges: true);

            await CheckDuplicates(treeNode.ParentNodeId.Value, requestDTO.NewNodeName);

            treeNode.Name = requestDTO.NewNodeName;

            _unitOfWork.TreeNodeRepository.Update(treeNode);

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task ValidateNodeData(int nodeId, string treeName)
        {
            var treeNode = await _unitOfWork.TreeNodeRepository.GetByIdAsync(nodeId);

            if (treeNode == null)
                throw new SecureException($"Node with ID = {nodeId} was not found");

            var rootNode = await _unitOfWork.TreeNodeRepository.GetRootNodeByNameAsync(treeName);

            if (rootNode == null)
                throw new SecureException($"Requested node was found, but it doesn't belong to your tree");
            else
            {
                var treeNodes = await _unitOfWork.TreeNodeRepository.GetTreeNodesAsync(treeName);

                if (!treeNodes.Any(n => n.Id == nodeId))
                    throw new SecureException($"Requested node was found, but it doesn't belong to your tree");
            }
        }

        private async Task CheckDuplicates(int parentNodeId, string nodeName)
        {
            var siblingNodes = await _unitOfWork.TreeNodeRepository.GetByIdAsync(parentNodeId, includeChildren: true);

            if (siblingNodes.Children.Select(n => n.Name).ToHashSet().Contains(nodeName))
                throw new SecureException($"Duplicate name");
        }
    }
}