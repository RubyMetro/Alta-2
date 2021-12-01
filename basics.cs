using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Alta
{
    // Create a module with no prefix
    public class InfoModule : ModuleBase<SocketCommandContext>
	{
        string cdn = File.ReadAllText("cdn.txt");
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
			//await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
			var userinfoauthor = new EmbedAuthorBuilder()
				.WithName(userInfo.Username)
				.WithIconUrl(userInfo.GetAvatarUrl());
			var userInfoEmbed = new EmbedBuilder
			{
				Title = "User Information",
				Description = $"Username:\t{userInfo.Username}\n" +
				$"Discriminator:\t#{userInfo.Discriminator}\n" +
				$"Joined discord on:\t{userInfo.CreatedAt}",
				Color = Color.Blue,
				ThumbnailUrl = $"{cdn}a_user.png",
				Author = userinfoauthor,
				Footer = footer

			};
			var message = await ReplyAsync("", false, userInfoEmbed.Build());
		}

		[Command("status")]
		[Summary("n/a")]

		public async Task Ping()
        {
			var startTime = DateTime.Now;
			var pingAuthor = new EmbedAuthorBuilder()
				.WithName("Alta")
				.WithIconUrl($"{cdn}a_profile.png");
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

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cdn + "a_banner.png");

			Stopwatch timer = new Stopwatch();
			timer.Start();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			timer.Stop();

			TimeSpan cdnLatency = timer.Elapsed;

			int uptime = Environment.TickCount;
			uptime = uptime / 1000 / 60 / 60 / 24;

			TimeSpan clientUptime = DateTime.Now - Process.GetCurrentProcess().StartTime;

			pingEmbed = new EmbedBuilder {
				Title = "System details",
				Description =
				$"Message Latency:		{ping.Milliseconds}ms\n" +
				$"Gateway:				{Context.Client.Latency}ms\n" +
				$"Current CDN:			{cdn}\n" +
				$"CDN response time:	{(int)cdnLatency.TotalMilliseconds}ms\n" +
				$"System uptime:		{uptime} days\n" +
				$"Client uptime:		{(int)clientUptime.TotalDays} days",
				Color = Color.Blue,
				ThumbnailUrl = $"{cdn}a_server.png",
				Author = pingAuthor,
				Footer = footer
				
            };

			await message.ModifyAsync(msg => msg.Embed = pingEmbed.Build());
        }
	}
}

