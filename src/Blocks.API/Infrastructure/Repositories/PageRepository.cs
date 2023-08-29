using System.Text.Json;
using Blocks.API.Domain;

namespace Blocks.API.Infrastructure.Repositories
{
    public interface IPageRepository
    {
        Task Create(Page page);
        Task Update(Page page);
        Task<Page?> Get(string key);
    }

    public class PageRepository : IPageRepository
    {
        private readonly string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");

        public Task Create(Page page)
        {
            var filename = $"{page.Key}.json";
            string filePath = Path.Combine(basePath, filename);
            File.WriteAllText(filePath, JsonSerializer.Serialize(page));
            return Task.CompletedTask;
        }

        public Task<Page?> Get(string key)
        {
            var filename = $"{key}.json";
            string filePath = Path.Combine(basePath, filename);
            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);
                var page = JsonSerializer.Deserialize<Page?>(text);
                return Task.FromResult(page);
            }
            Console.WriteLine(filePath);
            return Task.FromResult<Page?>(null);
        }

        public Task Update(Page page)
        {
            var filename = $"{page.Key}.json";
            string filePath = Path.Combine(basePath, filename);
            File.WriteAllText(filePath, JsonSerializer.Serialize(page));
            return Task.CompletedTask;
        }
    }
}