using Meek.Moe.ZeroChan;
using System;
using System.Threading.Tasks;

namespace Meek.Moe.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var meek = new MeekMoeClient();
            //var hm = await meek.GetRandomImage(Enums.Endpoints.HatsuneMiku);
            
            await c.LoginAsync();
            var hm = await c.GetByTagSortedByPage("Hatsune Miku");
            Console.WriteLine("Hello World!");

        }
    }
}
