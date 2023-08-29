using Blocks.API.Domain.Enumerations;

namespace Blocks.API.Domain
{
    public class WebsiteHeroBlock : Block
    {
        public string? HeroImage { get; set; }
        public Position? ImageAlignment { get; set; }
        public Position? ContentAlignment { get; set; }
    }
}