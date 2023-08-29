using System.Text.Json;
using Blocks.API.Domain;
using Blocks.API.Infrastructure.Repositories;

namespace Blocks.API.Application
{
    public interface IPageService
    {
        Task Create(string key);
        Task<Page?> Get(string key);
        Task Update(Page page);
    }

    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public Task Create(string key)
        {
            var page = new Page
            {
                Key = key,
                Blocks = new List<JsonDocument?>()
            };

            _pageRepository.Create(page);

            return Task.CompletedTask;
        }

        public Task<Page?> Get(string key)
        {
            return _pageRepository.Get(key);
        }

        public Task Update(Page page)
        {
            _pageRepository.Update(page);

            return Task.CompletedTask;
        }
    }
}