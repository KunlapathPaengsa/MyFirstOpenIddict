using System.Text.Json.Serialization;

namespace MyFirstOpenIddictCommon.Web.DTOs
{
    //
    // Summary:
    //     Response error result
    public class ErrorResponseResult
    {
        //public ErrorResponseResult();

        //
        // Summary:
        //     Error id
        [JsonPropertyName("id")]
        public string Id { get; set; }
        //
        // Summary:
        //     Error code
        [JsonPropertyName("code")]
        public string Code { get; set; }
        //
        // Summary:
        //     List/Array/String of error message.
        [JsonPropertyName("message")]
        public object Message { get; set; }
    }
}
