using System;
using Demo;
using Grpc.Core;

namespace DemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:5001", ChannelCredentials.Insecure);

            var client = new Demo.Demo.DemoClient(channel);
            String user = "you";

            try
            {
                var reply = client.SayHello(new HelloRequest { Name = user });
                Console.WriteLine("Greeting: " + reply.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
