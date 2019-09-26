using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordCounter.Model;

namespace WordCounter.Core
{
    public interface ITextDataService
    {
        Task<List<TextDataModel>> ReadAll();

        Task<TextDataModel> Read(int id);

        Task<ResultModel> CountWords(int id);

        Task<ResultModel> CountWords(string text);

        Task<ResultModel> CountWords(IFormFile file);
    }
}
