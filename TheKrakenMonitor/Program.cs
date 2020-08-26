using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace TheKrakenMonitor
{
    class Program
    {
        private Alert alert;

        private readonly DiscordSocketClient _client;
        private string token;

        // Discord.Net heavily utilizes TAP for async, so we create
        // an asynchronous context from the beginning.
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
            alert = new Alert(680010006489333805, 680010007072210947, "Test Monitor", "MorganSkilly#0001", "https://morgan.games/", "/html/body/main/article/div[1]/div/div[1]/div[2]/h1/strong", "Hello!");

            Console.WriteLine("Enter Discord API Token: ");
            token = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Connecting...");
            Console.WriteLine();

            // It is recommended to Dispose of a client when you are finished
            // using it, at the end of your app's lifetime.
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            // Tokens should be considered secret data, and never hard-coded.
            try
            {
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Block the program until it is closed.
            await Task.Delay(Timeout.Infinite);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        // The Ready event indicates that the client has opened a
        // connection and it is now safe to access the cache.
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }

        // This is not the recommended way to write a bot - consider
        // reading over the Commands Framework sample.
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            // The bot should never respond to itself.
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content == "!ping")
                await message.Channel.SendMessageAsync("Ping from " + message.Author + " recived successfully - " + DateTime.Now);

            if (message.Content == "!alerts")
                await message.Channel.SendMessageAsync(null, false, alert.info().Build(), null);
        }
    }
}
