using System.Collections.Generic;
using System.Text.Json.Serialization;
using GraphQL.Client.WebApi.DTOs.Common;

namespace GraphQL.Client.WebApi.DTOs.Speakers
{
    public class AddSpeakerResultDto
    {
        [JsonPropertyName("addSpeaker")]
        public AddSpeakerResultData AddSpeakerResultData { get; set; }
    }
    
    public class AddSpeakerResultData
    {
        public SpeakerDto Speaker { get; set; }
        public List<UserError> Errors { get; set; }
    }
}