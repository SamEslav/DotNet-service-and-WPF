using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ServiceAppSignalR.Models;

namespace ServiceAppSignalR
{
    public class PopulationHub : Hub
    {

        private readonly MiBaseDeDatosContext _context;

        public PopulationHub(MiBaseDeDatosContext context)
        {
            _context = context;
        }

        public async Task AddPopulation(Population newItem)
        {
            // _context.Populations.Add(newItem);
            // await _context.SaveChangesAsync();
            // await Clients.All.SendAsync("Receive", await _context.Populations.ToListAsync());

            try
            {
                _context.Populations.Add(newItem);
                await _context.SaveChangesAsync();
                await Clients.All.SendAsync("Receive", await _context.Populations.ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AddPopulation: {ex.Message}");
                throw; 
            }

        }

        public async Task UpdatePopulation(Population updatedItem)
        {
            var item = await _context.Populations.FindAsync(updatedItem.Id);
            if (item != null)
            {
                item.Country = updatedItem.Country;
                item.Quantity = updatedItem.Quantity;
                await _context.SaveChangesAsync();
                await Clients.All.SendAsync("Receive", await _context.Populations.ToListAsync());
            }
        }

        public async Task DeletePopulation(int id)
        {
            var item = await _context.Populations.FindAsync(id);
            if (item != null)
            {
                _context.Populations.Remove(item);
                await _context.SaveChangesAsync();
                await Clients.All.SendAsync("Receive", await _context.Populations.ToListAsync());
            }
        }


    }
}
