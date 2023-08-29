using System.Text.Json;
using Blocks.API.Application.Inputs;
using Blocks.API.Domain;
using Blocks.API.Domain.Enumerations;
using Blocks.API.Infrastructure.Repositories;

namespace Blocks.API.Application
{
    public interface IBlockService
    {
        JsonDocument Generate(CreateBlockInput input);
        JsonDocument Generate(UpdateBlockInput input);
    }

    public class BlockService : IBlockService
    {
        public JsonDocument Generate(CreateBlockInput input)
        {
            if (input.Id is BlockType.WebsiteHeader)
            {
                return JsonSerializer.SerializeToDocument(new WebsiteHeaderBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent,
                    BusinessName = input.BusinessName,
                    LogoHidden = input.LogoHidden,
                    NavigationMenu = input.NavigationMenu,
                    CtaButtonText = input.CtaButtonText
                });
            }
            if (input.Id is BlockType.WebsiteHeroBlock)
            {
                return JsonSerializer.SerializeToDocument(new WebsiteHeroBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent
                });
            }
            if (input.Id is BlockType.ServicesBlock)
            {
                return JsonSerializer.SerializeToDocument(new ServicesBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent
                });
            }

            throw new Exception("Invalid type");
        }

        public JsonDocument Generate(UpdateBlockInput input)
        {
            if (input.Id is BlockType.WebsiteHeader)
            {
                return JsonSerializer.SerializeToDocument(new WebsiteHeaderBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent,
                    BusinessName = input.BusinessName,
                    LogoHidden = input.LogoHidden,
                    NavigationMenu = input.NavigationMenu,
                    CtaButtonText = input.CtaButtonText
                });
            }
            if (input.Id is BlockType.WebsiteHeroBlock)
            {
                return JsonSerializer.SerializeToDocument(new WebsiteHeroBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent
                });
            }
            if (input.Id is BlockType.ServicesBlock)
            {
                return JsonSerializer.SerializeToDocument(new ServicesBlock()
                {
                    Id = input.Id,
                    BlockOrder = input.BlockOrder,
                    HeadlineText = input.HeadlineText,
                    DisplayStatus = input.DisplayStatus,
                    Icon = input.Icon,
                    ButtonEvent = input.ButtonEvent
                });
            }

            throw new Exception("Invalid type");
        }


    }
}