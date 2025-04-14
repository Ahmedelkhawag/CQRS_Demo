using CQRS_Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Library.Repos
{
    public interface IItemsRepository
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(int id);
    }
}
