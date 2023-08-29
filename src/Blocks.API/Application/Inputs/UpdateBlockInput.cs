using Blocks.API.Domain.Components;
using Blocks.API.Domain.Enumerations;

namespace Blocks.API.Application.Inputs
{
    public class UpdateBlockInput
    {
        public BlockType? Id { get; set; }
        public string? SectionId { get; set; }
        public int? BlockOrder { get; set; }

        public string? HeadlineText { get; set; }
        public bool DisplayStatus { get; set; }
        public string? Icon { get; set; }
        public string? ButtonEvent { get; set; }


        public string? BusinessName { get; set; }
        public bool? LogoHidden { get; set; }
        public List<string>? NavigationMenu { get; set; }
        public CTAButton? CtaButtonText { get; set; }


        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceImage { get; set; }
        public ServiceCTAButton? ServiceCtaButton { get; set; }

        public string? HeroImage { get; set; }
        public Position? ImageAlignment { get; set; }
        public Position? ContentAlignment { get; set; }
    }


}