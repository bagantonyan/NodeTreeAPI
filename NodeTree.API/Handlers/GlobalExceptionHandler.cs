using Microsoft.AspNetCore.Diagnostics;
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
            var _journalRecordService = httpContext.RequestServices.GetRequiredService<IJournalRecordService>();
            var test = new JournalRecord { Text = exception.Message };

            await _journalRecordService.CreateAsync(test);

            ApiErrorResponse errorResponse;

            switch (exception)
            {
                case SecureException:
                    {
                        errorResponse = new ApiErrorResponse
                        {
                            Type = ExceptionType.Secure.ToString(),
                            Id = test.EventId.ToString(),
                            Data = new Data { Message = exception.Message }
                        };
                        break;
                    }
                default:
                    {
                        errorResponse = new ApiErrorResponse
                        {
                            Type = ExceptionType.Exception.ToString(),
                            Id = test.EventId.ToString(),
                            Data = new Data { Message = $"Internal server error ID = {httpContext.TraceIdentifier}" }
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