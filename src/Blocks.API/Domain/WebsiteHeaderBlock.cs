using Blocks.API.Domain.Components;

namespace Blocks.API.Domain
{
    public class WebsiteHeaderBlock : Block
    {
        public string? BusinessName { get; set; }
        public bool? LogoHidden { get; set; }
        public List<string>? NavigationMenu { get; set; }
        public CTAButton? CtaButtonText { get; set; }
    }
}