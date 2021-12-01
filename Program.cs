/*
    01000001 01101100 01110100 01100001 
    Made By Luca
*/


using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
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
            bool failed = await Login();
            if (failed)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Login Failed");
                        Console.WriteLine("Enter Token");
                        File.WriteAllText("token.txt", Console.ReadLine());
                        string token = File.ReadAllText("token.txt");
                        Console.WriteLine("Enter CDN address");
                        File.WriteAllText("cdn.txt", Console.ReadLine());
                        string cdn = File.ReadAllText("cdn.txt");

                        _client = new DiscordSocketClient();
                        _client.Log += Log;
                        var commandHandler = new CommandHandler(_client, new CommandService());
                        await commandHandler.InstallCommandsAsync();
                        await _client.LoginAsync(TokenType.Bot, token);
                        await _client.StartAsync();

                        await Task.Delay(-1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        failed = true;
                    }
                    failed = false;


                }
                while (failed);
            }
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

        private string CheckForCDN()
        {
            string cdn;
            //checks if the token file exists
            if (!File.Exists("cdn.txt"))
            {
                cdn = CreateCDN();
                return cdn;
            }

            cdn = File.ReadAllText("token.txt");

            //if there isnt already a token, prompt the user to enter a token.
            if (cdn.Length < 1)
            {
                cdn = CreateCDN();
                return cdn;
            }

            return cdn;
        }

        private string CreateToken()
        {
            Console.WriteLine("Enter Token");
            File.WriteAllText("token.txt", Console.ReadLine());
            string token = File.ReadAllText("token.txt");
            return token;
        }

        private string CreateCDN()
        {
            Console.WriteLine("Enter CDN address");
            File.WriteAllText("cdn.txt", Console.ReadLine());
            string cdn = File.ReadAllText("cdn.txt");
            return cdn;
        }

        private async Task<bool> Login()
        {
            bool failed;
            try
            {
                string token = CheckForToken();
                string cdn = CheckForCDN();

                _client = new DiscordSocketClient();
                _client.Log += Log;
                var commandHandler = new CommandHandler(_client, new CommandService());
                await commandHandler.InstallCommandsAsync();
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();

                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                failed = true;
                return failed;
            }
            failed = false;
            return failed = false;
        }
    }
}
