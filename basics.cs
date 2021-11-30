using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alta
{
    // Create a module with no prefix
    public class InfoModule : ModuleBase<SocketCommandContext>
	{
		EmbedFooterBuilder footer = new EmbedFooterBuilder()
			.WithText("use !help for more commands.");
		// ~say hello world -> hello world
		[Command("say")]
		[Summary("Echoes a message.")]
		public Task SayAsync([Remainder][Summary("The text to echo")] string echo)
			=> ReplyAsync(echo);

		// ReplyAsync is a method on ModuleBase 

		[Command("userinfo")]
		[Summary("Returns info about the current user, or the user parameter, if one passed.")]
		[Alias("user", "whois")]
		public async Task UserInfoAsync(
		[Summary("The (optional) user to get info from")]
		SocketUser user = null)
		{
			var userInfo = user ?? Context.Client.CurrentUser;
			await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
		}

		[Command("ping")]
		[Summary("n/a")]

		public async Task Ping()
        {
			var startTime = DateTime.Now;
			var pingAuthor = new EmbedAuthorBuilder()
				.WithName("Alta")
				.WithIconUrl("https://github.com/c-hristian-t/Alta-2/blob/main/images/Profile.png?raw=true");
			var pingEmbed = new EmbedBuilder
			{
				Title = "One Moment...",
				Description = "Retrieving data...",
				Author = pingAuthor,
				Color = Color.Blue
			};
			var message = await ReplyAsync("", false, pingEmbed.Build());

			var endTime = DateTime.Now;

			var ping = endTime - startTime;

			pingEmbed = new EmbedBuilder {
				Title = "System timing details",
				Description =
				$"Message Latency: {ping.Milliseconds}ms",
				Color = Color.Blue,
				Author = pingAuthor,
				Footer = footer
				
            };

			await message.ModifyAsync(msg => msg.Embed = pingEmbed.Build());
        }
	}
}

