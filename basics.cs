using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Alta
{
    // Create a module with no prefix
    public class InfoModule : ModuleBase<SocketCommandContext>
	{
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

		[Command("test")]
		[Summary("n/a")]

		public async Task Test()
        {
			var testAuthor = new EmbedAuthorBuilder()
				.WithName("Alta");
			var test = new EmbedBuilder
			{
				Title = "test",
				Description = "test",
				Author = testAuthor,
				Color = Color.Blue
			};
			await ReplyAsync("", false, test.Build());
        }
	}
}

