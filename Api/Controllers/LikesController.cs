using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.LikeCommands;
using Application.DataTransfer;
using Application.Queries.LikeQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public LikesController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/Likes
        [HttpGet]
        public IActionResult Get([FromServices] IGetLikesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, 1));
        }

        // GET: api/Likes/5
        [HttpGet("{id}", Name = "GetLike")]
        public IActionResult Get(int id, [FromServices] IGetLikeQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        [Authorize]
        // POST: api/Likes
        [HttpPost]
        public IActionResult Post([FromBody] LikeDto dto,[FromServices] ICreateLikeCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [Authorize]
        // PUT: api/Likes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLikeCommand command)
        {
                _executor.ExecuteCommand(command, id);
                return NoContent();
        }

    }
}
