using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.PostCommands;
using Application.DataTransfer;
using Application.Queries.PostQueries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public PostsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }


        // GET: api/Posts
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPostDto search,[FromServices] IGetPostsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id,[FromServices] IGetPostQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        [Authorize]
        // POST: api/Posts
        [HttpPost]
        public IActionResult Post([FromForm] CreatePostDto dto, [FromServices] ICreatePostCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }



        [Authorize]
        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatePostDto dto, [FromServices] IUpdatePostCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
