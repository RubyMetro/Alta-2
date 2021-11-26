using Discord.Commands;
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
	}
}
