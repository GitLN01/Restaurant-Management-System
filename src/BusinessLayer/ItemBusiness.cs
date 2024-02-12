using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ItemBusiness
    {
        private readonly ItemRepository itemRepository;

        public ItemBusiness()
        {
            this.itemRepository = new ItemRepository();
        }

        public List<Items> GetAllItems()
        { 
            return this.itemRepository.GetAllItems();
        }

        public Items GetItemByName(string Name)
        {
            return this.itemRepository.GetAllItems().Where(item => item.name == Name).FirstOrDefault();
        }

        public Items GetItemById(int Id)
        {
            return this.itemRepository.GetAllItems().Where(item => item.item_id == Id).FirstOrDefault();
        }
    }
}
