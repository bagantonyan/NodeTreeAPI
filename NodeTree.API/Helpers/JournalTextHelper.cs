using Microsoft.Extensions.Primitives;

namespace NodeTree.API.Helpers
{
    public static class JournalTextHelper
    {
        public static string GetRecordText(long requestId, string path, Dictionary<string, StringValues> parameters, string stackTrace)
        {
            return $"Request ID = {requestId}\r\n" +
                   $"Path = {path}\r\n" +
                   parameters.Select(x => string.Format("{0}{1}{2}", x.Key, " = ", x.Value + "\r\n")) +
                   stackTrace;
        }
    }
}