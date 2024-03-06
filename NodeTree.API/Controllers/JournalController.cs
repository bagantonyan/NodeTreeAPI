using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NodeTree.API.Models.Journal;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.Shared.RequestFeatures;

namespace NodeTree.API.Controllers
{
    [Tags("user.journal")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Provides the pagination API. 
        /// Skip means the number of items should be skipped by server. 
        /// Take means the maximum number items should be returned by server. 
        /// All fields of the filter are optional.
        /// </remarks>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.journal.getRange")]
        public async Task<ActionResult<JournalListResponseModel>> GetRangeAsync([FromQuery] PagingModel paging, [FromBody, BindRequired] FilterModel filter)
        {
            var (records, totalCount) = await _journalRecordService.GetRangeWithPagingAndFilterAsync(paging, filter);

            var responseModel = new JournalListResponseModel
            {
                Skip = paging.Skip,
                Count = totalCount,
                Items = _mapper.Map<List<JournalItemResponseModel>>(records)
            };

            return Ok(responseModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the information about an particular event by ID.
        /// </remarks>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api.user.journal.getSingle")]
        public async Task<ActionResult<JournalRecordResponseModel>> GetByIdAsync([FromQuery] long recordId)
        {
            var record = await _journalRecordService.GetByIdAsync(recordId);

            return Ok(_mapper.Map<JournalRecordResponseModel>(record));
        }
    }
}