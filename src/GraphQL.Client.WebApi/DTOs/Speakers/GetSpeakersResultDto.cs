using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GraphQL.Client.WebApi.DTOs.Speakers
{
    public class GetSpeakersResultDto
    {
        [JsonPropertyName("getSpeakers")]
        public List<SpeakerDto> Speakers { get; set; }
    }
}