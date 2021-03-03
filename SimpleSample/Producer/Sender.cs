using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            
            using(var connetion = factory.CreateConnection())
            using (var channel = connetion.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "getting started with .net core rabbitmq";
                var body = Encoding.UTF8.GetBytes(message);
                
                channel.BasicPublish("", "BasicTest", null, body);
                
                Console.WriteLine("sent messaage {0}...", message);
            }
            
            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
    }
}
