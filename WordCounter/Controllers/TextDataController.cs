using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordCounter.Core;
using WordCounter.Model;

namespace WordCounter.Controllers
{
    [Route("api/[controller]")]
    public class TextDataController : Controller
    {
        private readonly ITextDataService _textDataService;

        public TextDataController(ITextDataService textDataService)
        {
            _textDataService = textDataService;
        }

        [HttpGet("[action]")]
        public async Task<List<TextDataModel>> ReadAll()
        {
            return await _textDataService.ReadAll();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CountWords(int id)
        {
            var result = await _textDataService.CountWords(id);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CountWords(string text)
        {
            var result = await _textDataService.CountWords(text);
            return Ok(result);
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public async Task<IActionResult> CountWords(IFormFile file)
        {
            var result = await _textDataService.CountWords(file);
            return Ok(result);
        }
    }
}
