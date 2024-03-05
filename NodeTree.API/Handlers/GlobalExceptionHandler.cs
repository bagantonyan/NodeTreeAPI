using Microsoft.AspNetCore.Diagnostics;
using NodeTree.API.Helpers;
using NodeTree.API.Models.ApiModels;
using NodeTree.BLL.Services.Interfaces;
using NodeTree.DAL.Entities;
using NodeTree.Shared.Enums;
using NodeTree.Shared.Exceptions;

namespace NodeTree.API.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            ApiErrorResponse errorResponse;
            var journalRecord = new JournalRecord();

            try
            {
                var _journalRecordService = httpContext.RequestServices.GetRequiredService<IJournalRecordService>();
                await _journalRecordService.CreateAsync(journalRecord);

                var parameters = httpContext.Request.Query.ToDictionary();

                journalRecord.Text = JournalTextHelper
                    .GetRecordText(journalRecord.EventId, httpContext.Request.Path, parameters, exception.StackTrace);
                await _journalRecordService.UpdateAsync(journalRecord);
            }
            catch (Exception)
            {
                errorResponse = new ApiErrorResponse
                {
                    Type = ExceptionType.Exception.ToString(),
                    Id = journalRecord.EventId.ToString(),
                    Data = new Data { Message = $"Internal server error ID = {journalRecord.EventId}" }
                };
            }

            switch (exception)
            {
                case SecureException:
                    {
                        errorResponse = new ApiErrorResponse
                        {
                            Type = ExceptionType.Secure.ToString(),
                            Id = journalRecord.EventId.ToString(),
                            Data = new Data { Message = exception.Message }
                        };
                        break;
                    }
                default:
                    {
                        errorResponse = new ApiErrorResponse
                        {
                            Type = ExceptionType.Exception.ToString(),
                            Id = journalRecord.EventId.ToString(),
                            Data = new Data { Message = $"Internal server error ID = {journalRecord.EventId}" }
                        };
                        break;
                    }
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}