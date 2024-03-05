using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.BLL.Services.Interfaces;

namespace NodeTree.API.Controllers
{
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly ITreeNodeService _treeNodeService;
        private readonly IMapper _mapper;

        public NodeController(
            ITreeNodeService treeNodeService,
            IMapper mapper)
        {
            _treeNodeService = treeNodeService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api.user.tree.node.create")]
        public async Task<IActionResult> CreateAsync([FromQuery] CreateNodeRequestModel requestModel)
        {
            await _treeNodeService.CreateAsync(_mapper.Map<CreateNodeRequestDTO>(requestModel));

            return Ok();
        }

        [HttpPost]
        [Route("/api.user.tree.node.delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteNodeRequestModel requestModel)
        {
            await _treeNodeService.DeleteAsync(_mapper.Map<DeleteNodeRequestDTO>(requestModel));

            return Ok();
        }

        [HttpPost]
        [Route("/api.user.tree.node.rename")]
        public async Task<IActionResult> RenameAsync([FromQuery] RenameNodeRequestModel requestModel)
        {
            await _treeNodeService.RenameAsync(_mapper.Map<RenameNodeRequestDTO>(requestModel));

            return Ok();
        }
    }
}