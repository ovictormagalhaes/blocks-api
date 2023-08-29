using System.Text.Json;
using System.Text.Json.Nodes;

namespace Blocks.API.Domain
{
    public class Page
    {
        public required string Key { get; set; }
        public List<JsonDocument?>? Blocks { get; set; }

        public Page()
        {
            Blocks = new List<JsonDocument?>();
        }
    }
}