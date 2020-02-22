using Meek.Moe.ZeroChan;
using System;
using System.Threading.Tasks;

namespace Meek.Moe.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            await c.LoginAsync();
            var hm = await c.GetByTagSortedByID("Hatsune Miku", 2656264);
            Console.WriteLine("Hello World!");

        }
    }
}
