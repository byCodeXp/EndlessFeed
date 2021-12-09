using System.Text.Json;

namespace API.Contracts.Responses.v1
{
    public class FailedResponseV1
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}