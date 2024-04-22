using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOTDBot.Commands
{
    public class TotdModule : BaseCommandModule
    {
        [Command("totd")]
        public async Task GetTotd(CommandContext ctx)
        {
            string url = "https://trackmania.exchange/mapsearch2/search?api=on&format=json&mode=25";

            Api api = new Api();
            var maps = await api.Totd(url);
            var Totd = maps.results[0];
            string url2 = $"https://trackmania.exchange/maps/thumbnail/{Totd.TrackID}";
            Totd.AuthorTime = Math.Round(Totd.AuthorTime / 1000, 3);

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder
            {
                Title = "Track of the Day",
                Description = $"{Totd.Name} by {Totd.Username}\nAuthor Time: {Totd.AuthorTime}",
                Color = new DiscordColor(0x00ff00),
                ImageUrl = url2,
            };

            await ctx.RespondAsync(embed);
        }
    }
}
