using NodeTree.Shared.Enums;

namespace NodeTree.API.Models.ApiModels
{
    public class ApiErrorResponse
    {
        public string Type { get; set; }

        public string Id { get; set; }

        public Data Data { get; set; }
    }

    public class Data
    {
        public string Message { get; set; }
    }
}