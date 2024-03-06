using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.Services.Interfaces;

namespace NodeTree.API.Controllers
{
    [Tags("user.tree")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeNodeService _treeNodeService;
        private readonly IMapper _mapper;

        public TreeController(
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
        /// Returns your entire tree. If your tree doesn't exist it will be created automatically.
        /// </remarks>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.tree.get")]
        public async Task<ActionResult<TreeResponseModel>> GetTreeAsync([FromQuery] GetTreeRequestModel requestModel)
        {
            var treeDTO = await _treeNodeService.GetTreeAsync(requestModel.TreeName);

            return Ok(_mapper.Map<TreeResponseModel>(treeDTO));
        }
    }
}