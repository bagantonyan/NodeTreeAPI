using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.DTOs.TreeNodes;
using NodeTree.BLL.Services.Interfaces;

namespace NodeTree.API.Controllers
{
    [Tags("user.tree.node")]
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

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// Create a new node in your tree. 
        /// You must to specify a parent node ID that belongs to your tree. 
        /// A new node name must be unique across all siblings.
        /// </remarks>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.tree.node.create")]
        public async Task<IActionResult> CreateAsync([FromQuery] CreateNodeRequestModel requestModel)
        {
            await _treeNodeService.CreateAsync(_mapper.Map<CreateNodeRequestDTO>(requestModel));

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete an existing node in your tree. 
        /// You must specify a node ID that belongs your tree.
        /// </remarks>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.tree.node.delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteNodeRequestModel requestModel)
        {
            await _treeNodeService.DeleteAsync(_mapper.Map<DeleteNodeRequestDTO>(requestModel));

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Rename an existing node in your tree. 
        /// You must specify a node ID that belongs your tree. 
        /// A new name of the node must be unique across all siblings.
        /// </remarks>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.tree.node.rename")]
        public async Task<IActionResult> RenameAsync([FromQuery] RenameNodeRequestModel requestModel)
        {
            await _treeNodeService.RenameAsync(_mapper.Map<RenameNodeRequestDTO>(requestModel));

            return Ok();
        }
    }
}