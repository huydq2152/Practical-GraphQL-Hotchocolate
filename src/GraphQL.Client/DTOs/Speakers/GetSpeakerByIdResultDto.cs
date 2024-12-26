using System.Text.Json.Serialization;

namespace Client.WebApi.DTOs.Speakers
{
    public class GetSpeakerByIdResultDto
    {
        [JsonPropertyName("getSpeakerById")]
        public SpeakerDto Speaker { get; set; }
    }
}