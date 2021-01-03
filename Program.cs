using System;
using System.IO;
using Newtonsoft.Json;
using PassProgram;
using PassProgram.InputInterpretation;

namespace Passy
{
    class Program
    {
        public static IInputCont input;
        static void Main(string[] args)
        {
            Context ctx = new Context();
            Conf config;
            using (StreamReader file = File.OpenText(@".\Config\conf.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                config = (Conf)serializer.Deserialize(file, typeof(Conf));
            }

            //input = new TelegramInput(config.token);
            input = new TestInput();

            Console.WriteLine("Enter command");
            OutsideMessage command = new OutsideMessage();
            Console.WriteLine(config.token);

            ctx.messageEvent += OnCommandCompleted;

            while (command.messageText != "exit"){
                command = input.GetNextCommand();
                if(command.msgId == null)
                    continue;
                else{
                    Console.WriteLine("ID: " + command.msgId);
                    ctx.Execute(command);
                }
            }
        }

        public static void OnCommandCompleted(object sender, OutsideMessage msg)
        {
            input.SendInfo(msg);
        }
    }

    public class Conf
    {
        public string token;
    }
}
