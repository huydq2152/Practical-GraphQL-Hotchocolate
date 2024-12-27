using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Abstractions;
using GraphQL.Client.WebApi.DTOs.Speakers;
using GraphQL.Client.WebApi.Queries.Speakers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQL.Client.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeakersController : ControllerBase
    {
        private readonly ILogger<SpeakersController> _logger;
        private readonly IGraphQLClient _client;

        public SpeakersController(
            ILogger<SpeakersController> logger,
            IGraphQLClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult> GetSpeakers()
        {
            try
            {
                var result = await _client.SendQueryAsync<GetSpeakersResultDto>(Queries.Speakers.GetSpeakers.Value);

                if (result.Errors != null && result.Errors.Any())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok(result.Data.Speakers);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSpeakersById([FromRoute] int id)
        {
            try
            {
                var query = new GraphQLRequest
                {
                    Query = GetSpeakerById.Value,
                    Variables = new
                    {
                        id = id
                    }
                };

                var result = await _client.SendQueryAsync<GetSpeakerByIdResultDto>(query);

                if (result.Errors != null && result.Errors.Any())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok(result.Data.Speaker);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddSpeaker(
            [FromBody] SpeakerDto speakerDto)
        {
            try
            {
                var query = new GraphQLRequest
                {
                    Query = Queries.Speakers.AddSpeaker.Value,
                    Variables = new
                    {
                        name = speakerDto.Name,
                        bio = speakerDto.Bio,
                        webSite = speakerDto.WebSite
                    }
                };

                var result = await _client.SendMutationAsync<AddSpeakerResultDto>(query);

                if (result.Errors != null && result.Errors.Any())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok(result.Data.AddSpeakerResultData);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong", e);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
    }
}