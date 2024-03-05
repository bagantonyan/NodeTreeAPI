using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.BLL.Services.Interfaces;

namespace NodeTree.API.Controllers
{
    [ApiController]
    [Route("/api.user.tree.node.")]
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
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromQuery] CreateNodeRequestModel requestModel)
        {
            await _treeNodeService.CreateAsync(_mapper.Map<CreateNodeRequestDTO>(requestModel));

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteNodeRequestModel requestModel)
        {
            await _treeNodeService.DeleteAsync(_mapper.Map<DeleteNodeRequestDTO>(requestModel));

            return Ok();
        }

        [HttpPost]
        [Route("rename")]
        public async Task<IActionResult> RenameAsync([FromQuery] RenameNodeRequestModel requestModel)
        {
            await _treeNodeService.RenameAsync(_mapper.Map<RenameNodeRequestDTO>(requestModel));

            return Ok();
        }
    }
}