using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Models.Journal;
using NodeTree.BLL.Services.Interfaces;

namespace NodeTree.API.Controllers
{
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalRecordService _journalRecordService;
        private readonly IMapper _mapper;

        public JournalController(
            IJournalRecordService journalRecordService,
            IMapper mapper)
        {
            _journalRecordService = journalRecordService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api.user.journal.getSingle")]
        public async Task<ActionResult<JournalRecordResponseModel>> GetByIdAsync([FromQuery] long recordId)
        {
            var record = await _journalRecordService.GetByIdAsync(recordId);

            return Ok(_mapper.Map<JournalRecordResponseModel>(record));
        }

        //public async Task<ActionResult<>>
    }
}