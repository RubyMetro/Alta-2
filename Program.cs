using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alta
{
    internal class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            string token = CheckForToken();

            _client = new DiscordSocketClient();
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private string CheckForToken()
        {
            string token;
            //checks if the token file exists
            if (!File.Exists("token.txt"))
            {
                token = CreateToken();
                return token;
            }

            token = File.ReadAllText("token.txt");

            //if there isnt already a token, prompt the user to enter a token.
            if (token.Length < 1)
            {
                token = CreateToken();
                return token;
            }

            return token;
        }

        private string CreateToken()
        {
            Console.WriteLine("Enter Token");
            File.WriteAllText("token.txt", Console.ReadLine());
            string token = File.ReadAllText("token.txt");
            return token;
        }
    }
}
