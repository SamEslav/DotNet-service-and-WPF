
using Microsoft.AspNetCore.SignalR;
using ServiceAppSignalR.Models;

namespace ServiceAppSignalR
{
    public class PopulationHostedService: IHostedService, IDisposable
    {
        private readonly IHubContext<PopulationHub> _populationHub;
        private Timer _timer;

        public PopulationHostedService(IHubContext<PopulationHub> populationHub)
        {
            _populationHub = populationHub;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendInfo, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void SendInfo(object state)
        {
            IEnumerable<Population> population;
            using (var context = new MiBaseDeDatosContext())
            {
                population = context.Populations.ToList();
            }

            _populationHub.Clients.All.SendAsync("Receive", population);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
