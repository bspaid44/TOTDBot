using Discord;
using Discord.WebSocket;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;
using TOTDBot.Commands;

namespace TOTDBot
{
    public class Program
    {
        public static async Task Main()
        {
           
            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "{YOUR TOKEN}",
                TokenType = DSharpPlus.TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<TotdModule>();

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
