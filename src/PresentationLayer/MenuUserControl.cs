using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MenuUserControl : UserControl
    {
        readonly ItemBusiness itemBusiness = new ItemBusiness();

        public MenuUserControl()
        {
            InitializeComponent();
        }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {
            List<Items> itemsList = itemBusiness.GetAllItems();
            foodListBox.Items.Clear();
            drinkListBox.Items.Clear();

            foreach(Items item in itemsList)
            {
                string itemString = string.Format("{0} ({1}) - {2}€", item.name, item.category, item.price);
                if(item.category == "Drink")
                    drinkListBox.Items.Add(itemString);
                else
                    foodListBox.Items.Add(itemString);
            }
        }
    }
}
