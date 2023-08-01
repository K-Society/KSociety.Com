using System;
using System.Threading.Tasks;
using KSociety.Com.Srv.Host.Test.ProtoModel;

namespace KSociety.Com.Srv.Host.Test;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        try
        {
            Configuration.ProtoBufConfiguration();
            TestEventBusRpc testEventBusRpc = new TestEventBusRpc();
            ;
            await testEventBusRpc.SendData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + " " + ex.StackTrace);
        }
    }
}