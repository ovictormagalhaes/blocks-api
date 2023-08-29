using Blocks.API.Domain.Components;

namespace Blocks.API.Domain
{
    public class ServicesBlock : Block
    {
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceImage { get; set; }
        public ServiceCTAButton? ServiceCtaButton { get; set; }
    }
}