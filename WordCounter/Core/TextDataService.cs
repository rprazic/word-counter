using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.Infrastructure;
using WordCounter.Model;

namespace WordCounter.Core
{
    public class TextDataService : ITextDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TextDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TextDataModel>> ReadAll()
        {
            var textDatas = await _unitOfWork.TextData.GetAllAsync();

            if (textDatas == null)
                return new List<TextDataModel>();

            var textDataModels = textDatas.Select(entity => new TextDataModel { Id = entity.Id, Text = entity.Text });
            return textDataModels.ToList();
        }

        public async Task<TextDataModel> Read(int id)
        {
            var textData = await _unitOfWork.TextData.GetAsync(id);

            if (textData == null)
                return new TextDataModel();

            var textDataModel = new TextDataModel { Id = textData.Id, Text = textData.Text };
            return textDataModel;
        }

        public async Task<ResultModel> CountWords(int id)
        {
            var textData = await _unitOfWork.TextData.GetAsync(id);
            var text = textData.Text;

            var counter = new WordCounter(text);
            var count = counter.CountWords();

            return new ResultModel
            {
                Success = true,
                Count = count
            };
        }

        public async Task<ResultModel> CountWords(string text)
        {
            var counter = new WordCounter(text);
            var count = counter.CountWords();

            return new ResultModel
            {
                Success = true,
                Count = count
            };
        }

        public async Task<ResultModel> CountWords(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (extension != ".txt")
                return new ResultModel
                {
                    Success = false,
                    Count = 0
                };

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var text = await reader.ReadToEndAsync();
                var counter = new WordCounter(text);
                var count = counter.CountWords();

                return new ResultModel
                {
                    Success = true,
                    Count = count
                };
            }

        }
    }
}
