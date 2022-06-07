using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.HashTagCommands;
using Application.Commands.PostCommands;
using Application.DataTransfer;
using Application.Queries.HashTagQueries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HashTagsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public HashTagsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/HashTags
        [HttpGet]
        public IActionResult Get([FromQuery] SearchHashTagDto search,[FromServices] IGetHashTagsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));

        }

        // GET: api/HashTags/5
        [HttpGet("{id}", Name = "GetHashTag")]
        public IActionResult Get(int id, [FromServices] IGetHashTagQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }


        // POST: api/HashTags
        [HttpPost]
        public IActionResult Post([FromBody] CreateHashTagDto dto, [FromServices] ICreateHashTagCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HashTagDto dto, [FromServices] IUpdateHashTagCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteHashTagCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

    }
}
