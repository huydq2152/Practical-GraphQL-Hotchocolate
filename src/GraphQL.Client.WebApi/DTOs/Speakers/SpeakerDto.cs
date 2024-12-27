using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.WebApi.DTOs.Speakers
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Bio { get; set; }
        
        public string WebSite { get; set; }
    }
}
