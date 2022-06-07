using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.CommentCommands;
using Application.DataTransfer;
using Application.Queries.CommentQueries;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public CommentsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }


        // GET: api/Comments
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCommentDto search, [FromServices] IGetCommentsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }



        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult Get(int id, [FromServices] IGetCommentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }



        // POST: api/Comments
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDto dto,[FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }


        [Authorize]
        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto, [FromServices] IUpdateCommentCommand command)
        {
            //dto.idUser = _actor.Id;
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
             return NoContent();
        }

    }
}
