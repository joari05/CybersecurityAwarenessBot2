using CybersecurityChatbot.Chatbot;
using CybersecurityChatbot.Services;
using System;
using System.Threading;

namespace CybersecurityChatbot.Chatbot
{
    public class ChatbotEngine
    {
        private ResponseService responseService;
        private string userName;
        private bool isRunning;

        public ChatbotEngine()
        {
            responseService = new ResponseService();
            isRunning = true;
        }

        public void Start()
        {
            try
            {
                // Play voice greeting
                PlayVoiceGreeting();

                // Display ASCII art
                Console.Clear();
                AsciiArt.DisplayLogo();
                Thread.Sleep(1000);
                AsciiArt.DisplayShield();
                Thread.Sleep(1000);

                // Welcome message
                Console.Clear();
                UIFormatter.DrawBorder("WELCOME TO MY CHAT, I'M HERE FOR WHATEVER YOU NEED");

                // Get user name
                GetUserName();

                // Main conversation loop
                RunConversation();
            }
            catch (Exception ex)
            {
                UIFormatter.WriteLineColored($"An error occurred: {ex.Message}", ConsoleColor.Red);
            }
        }

        private void PlayVoiceGreeting()
        {
            var voiceGreeting = new VoiceGreeting();
            voiceGreeting.PlayGreeting();
        }

        private void GetUserName()
        {
            UIFormatter.WriteColored("\n🤖 Bot: ", ConsoleColor.Cyan);
            UIFormatter.WriteWithDelay("Hello! What's your name? ", 30);

            UIFormatter.WriteColored("You: ", ConsoleColor.Green);
            userName = Console.ReadLine()?.Trim();

            while (string.IsNullOrWhiteSpace(userName))
            {
                UIFormatter.WriteLineColored("\n🤖 Bot: I didn't catch that. Please tell me your name:", ConsoleColor.Yellow);
                UIFormatter.WriteColored("You: ", ConsoleColor.Green);
                userName = Console.ReadLine()?.Trim();
            }

            UIFormatter.DrawSeparator();
            UIFormatter.WriteColored("\n🤖 Bot: ", ConsoleColor.Cyan);
            UIFormatter.WriteWithDelay($"Nice to meet you, {userName}! I'm your Cybersecurity Awareness Assistant.", 40);
            Thread.Sleep(500);

            UIFormatter.WriteColored("\n🤖 Bot: ", ConsoleColor.Cyan);
            UIFormatter.WriteWithDelay("I'm here to help you learn about online safety. Feel free to ask me anything!", 40);
        }

        private void RunConversation()
        {
            UIFormatter.DrawSectionHeader("CONVERSATION");
            responseService.DisplayHelp();

            while (isRunning)
            {
                UIFormatter.DrawSeparator();
                UIFormatter.WriteColored($"{userName}: ", ConsoleColor.Green);
                string userInput = Console.ReadLine();

                if (userInput?.ToLower() == "exit")
                {
                    isRunning = false;
                }

                UIFormatter.WriteColored("\n🤖 Bot: ", ConsoleColor.Cyan);
                string response = responseService.GetResponse(userInput, userName);

                // Type out the response with delay
                UIFormatter.WriteWithDelay(response, 30);
                Console.WriteLine();
            }

            // Farewell message
            UIFormatter.DrawSectionHeader("GOODBYE");
            UIFormatter.WriteColored("\n🤖 Bot: ", ConsoleColor.Cyan);
            UIFormatter.WriteWithDelay($"Thanks for chatting, {userName}! Remember to stay safe online! 🛡️", 40);
            UIFormatter.DrawFooter();
        }
    }
}