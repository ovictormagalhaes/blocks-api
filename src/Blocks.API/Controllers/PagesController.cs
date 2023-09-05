using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using Blocks.API.Application;
using Blocks.API.Application.Inputs;
using Blocks.API.Application.Validators;
using Blocks.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/pages")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _pageService;
        private readonly IBlockService _blockService;

        public PagesController(IPageService pageService, IBlockService blockService)
        {
            _pageService = pageService;
            _blockService = blockService;
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> Create([FromRoute] string key)
        {
            var validate = new StringEmptyOrWhiteSpaceValidator().Validate(key);
            if (validate.Errors.Any())
                return BadRequest("Invalid key");

            var currentPage = await _pageService.Get(key);
            if (currentPage is not null)
                return Conflict("Already exists page for this key");

            await _pageService.Create(key);
            return Created(key, "Page created successfully.");
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get([FromRoute] string key)
        {
            var validate = new StringEmptyOrWhiteSpaceValidator().Validate(key);
            if (validate.Errors.Any())
                return BadRequest("Invalid key");

            var currentPage = await _pageService.Get(key);
            if (currentPage is null)
                return NotFound("Not found page for this key");

            return Ok(currentPage);
        }

        [HttpPost("{key}/blocks")]
        public async Task<IActionResult> CreateBlock([FromRoute] string key, [FromBody] CreateBlockInput input)
        {
            var validateKey = new StringEmptyOrWhiteSpaceValidator().Validate(key);
            if (validateKey.Errors.Any())
                return BadRequest("Invalid key");

            var validateInput = new CreateBlockInputValidator().Validate(input);
            if (validateInput.Errors.Any())
                return BadRequest("Invalid body");

            var currentPage = await _pageService.Get(key);
            if (currentPage is null)
                return NotFound("Not found page for this key");

            var block = _blockService.Generate(input);

            if (currentPage.Blocks is null)
                currentPage.Blocks = new List<JsonDocument?>() { block };
            else
                currentPage.Blocks.Add(block);

            await _pageService.Update(currentPage);
            return Ok("Block added successfully.");
        }

        [HttpDelete("{key}/blocks/{blockId}")]
        public async Task<IActionResult> RemoveBlock([FromRoute] string key, [FromRoute] string blockId)
        {
            var validateKey = new StringEmptyOrWhiteSpaceValidator().Validate(key);
            if (validateKey.Errors.Any())
                return BadRequest("Invalid key");

            var validateId = new StringEmptyOrWhiteSpaceValidator().Validate(blockId);
            if (validateId.Errors.Any())
                return BadRequest("Invalid block id");

            var currentPage = await _pageService.Get(key);
            if (currentPage is null)
                return NotFound("Not found page for this key");

            if (currentPage.Blocks is not null)
                for (int i = 0; i < currentPage.Blocks.Count(); i++)
                {
                    var block = currentPage.Blocks[i]?.Deserialize<Block>();

                    if (block is not null && block.Id is not null
                        && ((int)block.Id).ToString().Equals(blockId))
                    {
                        currentPage.Blocks.RemoveAt(i);
                        await _pageService.Update(currentPage);
                        return Ok("Block removed successfully.");
                    }
                }

            return NotFound("Not found blocks for this id");
        }

        [HttpPut("{key}/blocks/{blockId}")]
        public async Task<IActionResult> UpdateBlock([FromRoute] string key, [FromRoute] string blockId, [FromBody] UpdateBlockInput input)
        {
            var validateKey = new StringEmptyOrWhiteSpaceValidator().Validate(key);
            if (validateKey.Errors.Any())
                return BadRequest("Invalid key");

            var validateId = new StringEmptyOrWhiteSpaceValidator().Validate(blockId);
            if (validateId.Errors.Any())
                return BadRequest("Invalid block id");

            var currentPage = await _pageService.Get(key);
            if (currentPage is null)
                return NotFound("Not found page for this key");

            if (currentPage.Blocks is not null)
                for (int i = 0; i < currentPage.Blocks.Count(); i++)
                {
                    var block = currentPage.Blocks[i]?.Deserialize<Block>();

                    if (block is not null && block.Id is not null
                        && ((int)block.Id).ToString().Equals(blockId))
                    {
                        currentPage.Blocks[i] = _blockService.Generate(input);
                        await _pageService.Update(currentPage);
                        return Ok("Block updated successfully.");
                    }
                }

            return NotFound("Not found blocks for this id");
        }
    }
}