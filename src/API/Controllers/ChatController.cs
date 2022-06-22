using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Middleware;
using Application.Behaviours;
using Application.Contracts.Domain.DTOs;
using Application.Features.Queries;
using Domain.ChatEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns Chat history by minutes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetChatByMin")]
        [ProducesResponseType(typeof(IEnumerable<ChatEventResponses>), statusCode: 200)]
        public async Task<IActionResult> GetChatByMin()
        {
            try
            {
                var result =  await _mediator.Send(new GetChatByMinQuery());

                if(result?.Any() == true)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                if (ex is HttpStatusException httpException)
                {
                    return StatusCode((int) httpException.Status, httpException.Message);
                }else{
                    return BadRequest(ex.Message);
                }
            }
        }

        /// <summary>
        /// Returns Chat history by hours.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetChatByHour")]
        [ProducesResponseType(typeof(IEnumerable<ChatEventResponses>), statusCode: 200)]
        public async Task<IActionResult> GetChatByHour()
        {
            try
            {
                var result =  await _mediator.Send(new GetChatByHourQuery());

                if(result?.Any() == true)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                if (ex is HttpStatusException httpException)
                {
                    return StatusCode((int) httpException.Status, httpException.Message);
                }else{
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}