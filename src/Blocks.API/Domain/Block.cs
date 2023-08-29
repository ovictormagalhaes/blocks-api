using Blocks.API.Domain.Enumerations;

namespace Blocks.API.Domain
{
    public class Block
    {
        public BlockType? Id { get; set; }
        public int? BlockOrder { get; set; }

        public string? HeadlineText { get; set; }
        public bool DisplayStatus { get; set; }
        public string? Icon { get; set; }
        public string? ButtonEvent { get; set; }

        public Block()
        {
            DisplayStatus = true;
        }
    }
}