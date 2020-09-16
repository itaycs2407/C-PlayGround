using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
    


namespace ConsoleApp1
{
    class TeleBot
    {
        static ITelegramBotClient tBot;

        public TeleBot()
        {
            tBot = new TelegramBotClient("1397090921:AAHg4HKgbHNX38_prN01nhS46uL7plqnhJ0");
            var me = tBot.GetMeAsync().Result;
            Console.WriteLine($"{me.FirstName} - {me.LastName} {me.IsBot}");
            tBot.OnMessage += TBot_OnMessage;
            tBot.OnMessage += TBot_OnMessage1;
            tBot.StartReceiving();
           //File.Create(@"c:\\text1.txt");
            
        }

        private void TBot_OnMessage1(object sender, MessageEventArgs e)
        {
            Console.WriteLine("this is from the orhter func|");
        }

        private async void TBot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text!= null)
            {
                Console.WriteLine($"recived text : {e.Message.Chat.Id} {e.Message.Text }");

                await tBot.SendTextMessageAsync(chatId: e.Message.Chat, text: "answer!!" +  e.Message.Text  );
                Console.WriteLine(e.Message.Text);
                File.AppendAllText(@"c:\\text1.txt", e.Message.Text + Environment.NewLine);
                if (e.Message.Text.Contains("ok"))
                {
                    Console.WriteLine("OK!");
                }
            }
        }
    }
}
