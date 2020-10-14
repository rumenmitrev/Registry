﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Registry.Web.Models;
using Registry.Web.Models.DTO;
using Registry.Web.Services.Ports;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Registry.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("share")]
    public class ShareController : ControllerBaseEx
    {
        private readonly IShareManager _shareManager;
        private readonly ILogger<ShareController> _logger;

        public ShareController(IShareManager shareManager, ILogger<ShareController> logger)
        {
            _shareManager = shareManager;
            _logger = logger;
        }

        [HttpPost("init")]
        public async Task<IActionResult> Init([FromForm]ShareInitDto parameters)
        {
            try
            {
                _logger.LogDebug($"Share controller Init('{parameters}')");

                var initRes = await _shareManager.Initialize(parameters);

                return Ok(initRes);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in Share controller Init('{parameters}')");

                return ExceptionResult(ex);
            }
        }

        [HttpPost("upload/{token}")]
        public async Task<IActionResult> Upload(string token, [FromForm] string path, IFormFile file)
        {
            try
            {

                _logger.LogDebug($"Share controller Upload('{token}', '{path}', '{file?.FileName}')");

                if (file == null)
                    return BadRequest(new ErrorResponse("No file uploaded"));
                
                await using var memory = new MemoryStream();
                await file.CopyToAsync(memory);
                
                var res = await _shareManager.Upload(token, path, memory.ToArray());

                return Ok(res);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in Share controller Upload('{token}', '{path}', '{file?.FileName}')");

                return ExceptionResult(ex);
            }
        }

        [HttpPost("commit/{token}")]
        public async Task<IActionResult> Commit(string token)
        {
            try
            {

                _logger.LogDebug($"Share controller Commit('{token}')");

                var res = await _shareManager.Commit(token);

                return Ok(res);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in Share controller Commit('{token}')");

                return ExceptionResult(ex);
            }
        }

    }
}
