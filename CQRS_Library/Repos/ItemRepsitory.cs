using CQRS_Library.Data;
using CQRS_Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.Repos
{
    public class ItemRepsitory : IItemsRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepsitory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(Item item)
        {
            await _context.Items.AddAsync(item);
             await _context.SaveChangesAsync();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetAllItems()
        {

            var items =await _context.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public Task UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
