using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Nancy;

namespace FP.XmasSample2015.XmasTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = HostFactory.New(x =>
            {
                x.Service<XmasTimerService>(s =>
                {
                    s.ConstructUsing(settings => new XmasTimerService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                    s.WithNancyEndpoint(x, c =>
                    {
                        c.AddHost(port: 12345);
                        c.CreateUrlReservationsOnInstall();
                        c.DeleteReservationsOnUnInstall();
                    });
                });
                x.StartAutomatically();
                x.SetServiceName("XmasTimerService");
                x.RunAsNetworkService();
            });

            host.Run();
        }
    }
}
