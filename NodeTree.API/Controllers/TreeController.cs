using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.TreeNode;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Entities;

namespace NodeTree.API.Controllers
{
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

        [HttpPost]
        [Route("/api.user.tree.get")]
        public async Task<ActionResult<TreeResponseModel>> GetAsync(string treeName)
        {
            var treeDTO = await _treeNodeService.GetTreeAsync(treeName);

            return Ok(_mapper.Map<TreeResponseModel>(treeDTO));
        }
    }
}