using BusinessLayer;
using DataAccessLayer;
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
    public partial class orderUserControl : UserControl
    {
        readonly ItemBusiness itemBusiness = new ItemBusiness();
        readonly OrderBusiness orderBusiness = new OrderBusiness();
        readonly OrderItemBusiness orderItemBusiness = new OrderItemBusiness();

        List<Order_Items> orderItemList = new List<Order_Items>();
        Orders order;

        private decimal TotalPrice = 0.0M;

        public orderUserControl()
        {
            InitializeComponent();
        }

        private void orderUserControl_Load(object sender, EventArgs e)
        {
            InitializeTableComboBox();
            InitializeFoodComboBox();
            InitializeQuantityPlaceholder();
        }

        public void InitializeTableComboBox()
        {
            for(int i = 1; i <= 10; i++)
            {
                tableNumberComboBox.Items.Add(i.ToString());
            }
        }

        public void InitializeFoodComboBox()
        {
            List<Items> itemList = itemBusiness.GetAllItems();

            for(int i = 0; i < itemList.Count; i++)
            {
                foodComboBox.Items.Add(itemList[i].name + " " + itemList[i].price);
            }
        }

        public void InitializeQuantityPlaceholder()
        {
            quantityTextBox.GotFocus += OnQuantityFocus;
            quantityTextBox.LostFocus += OnQuantityUnfocus;
        }

        public void OnQuantityFocus(object sender, EventArgs e)
        {
            if(quantityTextBox.Text == "Quantity")
            {
                quantityTextBox.Text = "";
            }
        }

        public void OnQuantityUnfocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(quantityTextBox.Text))
                quantityTextBox.Text = "Quantity";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string TableNumber = tableNumberComboBox.Text;
            string FoodValue = foodComboBox.Text;
            string Quantity = quantityTextBox.Text;

            if(TableNumber == string.Empty || FoodValue == string.Empty || Quantity == string.Empty)
            {
                MessageBox.Show("All fields must be filled in!");
                return;
            }
            
            if(!Quantity.All(char.IsDigit))
            {
                MessageBox.Show("Quantity must be a number!");
                return;
            }

            if(orderItemList.Count == 0)
            {
                order = new Orders()
                {
                    customer_id = UserSession.Id,
                    table_number = Convert.ToInt32(TableNumber),
                    time = DateTime.Now
                };
            }

            order.table_number = Convert.ToInt32(TableNumber);

            string FoodName = string.Concat(FoodValue.TakeWhile(c => c < '0' || c > '9'));
            FoodName = FoodName.Trim();
            Items foodItem = itemBusiness.GetItemByName(FoodName);

            Order_Items orderItem = new Order_Items()
            {
                customer_id = UserSession.Id,
                quantity = Convert.ToInt32(Quantity),
                item_id = foodItem.item_id
            };

            TotalPrice += foodItem.price * Convert.ToInt32(Quantity);
            orderItemList.Add(orderItem);

            foodComboBox.SelectedIndex = -1;
            quantityTextBox.Text = "Quantity";

            totalPriceLabel.Text = string.Format("{0}€", TotalPrice.ToString());
            RefreshListBox();
        }

        public void RefreshListBox()
        {
            ordersListBox.Items.Clear();

            string orderString = string.Format("Table number: {0}, Time: {1}", order.table_number, order.time);
            ordersListBox.Items.Add(orderString);

            foreach(Order_Items orderItem in orderItemList)
            {
                Items item = itemBusiness.GetItemById(orderItem.item_id);
                string orderItemString = string.Format("Item: {0}, Price: {1}, Quantity: {2}", item.name, item.price, orderItem.quantity);
                ordersListBox.Items.Add(orderItemString);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(order == null || orderItemList.Count == 0)
            {
                MessageBox.Show("You need to add items before confirming order!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to confirm the order?", "Order Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            order.time = DateTime.Now;
            orderBusiness.InsertOrders(order);
            Orders insertedOrder = orderBusiness.GetLatestOrder();
            foreach(Order_Items orderItem in orderItemList)
            {
                orderItem.order_id = insertedOrder.order_id;
                orderItem.description = string.Empty;
                orderItemBusiness.InsertOrderItems(orderItem);
            }

            SuccessfulOrder();

            order = null;
            orderItemList.Clear();
            TotalPrice = 0.0M;

            ClearFields();
        }

        public void ClearFields()
        {
            tableNumberComboBox.SelectedIndex = -1;
            foodComboBox.SelectedIndex = -1;
            quantityTextBox.Text = "Quantity";
        }

        public void ClearOrderData()
        {
            ClearFields();
            ordersListBox.Items.Clear();
            order = null;
            orderItemList.Clear();
            TotalPrice = 0.0M;
            totalPriceLabel.Text = "0.0€";
        }

        public void SuccessfulOrder()
        {
            ordersListBox.Items.Clear();

            string orderMessage = string.Format("Order Successful");
            ordersListBox.Items.Add(orderMessage);

            string orderString = string.Format("Table number: {0}, Time: {1}", order.table_number, order.time);
            ordersListBox.Items.Add(orderString);

            foreach (Order_Items orderItem in orderItemList)
            {
                Items item = itemBusiness.GetItemById(orderItem.item_id);
                string orderItemString = string.Format("Item: {0}, Price: {1}, Quantity: {2}", item.name, item.price, orderItem.quantity);
                ordersListBox.Items.Add(orderItemString);
            }
            ordersListBox.Items.Add("Total price: " + TotalPrice + "€");
        }

        private void orderHistoryButton_Click(object sender, EventArgs e)
        {
            ClearOrderData();
            List<Orders> ordersList = orderBusiness.GetOrdersByCustomerId(UserSession.Id);
            
            foreach(Orders order in ordersList)
            {
                string orderString = string.Format("Table number: {0}, Time: {1}", order.table_number, order.time);
                ordersListBox.Items.Add(orderString);
                addOrderItemsToListBox(order);
                ordersListBox.Items.Add(Environment.NewLine);
            }
        }

        public void addOrderItemsToListBox(Orders order)
        {
            List<Order_Items> order_Items = orderItemBusiness.GetOrderItemByOrderId(order.order_id);
            decimal TotalPriceOfPreviousOrder = 0.0M;
            foreach (Order_Items orderItem in order_Items)
            {
                Items item = itemBusiness.GetItemById(orderItem.item_id);
                string orderItemString = string.Format("Item: {0}, Price: {1}, Quantity: {2}", item.name, item.price, orderItem.quantity);
                ordersListBox.Items.Add(orderItemString);

                TotalPriceOfPreviousOrder += item.price * Convert.ToInt32(orderItem.quantity);
            }
            ordersListBox.Items.Add("Total price: " + TotalPriceOfPreviousOrder + " €");
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            if(orderItemList.Count == 0)
                return;

            Order_Items LastOrder = orderItemList[orderItemList.Count - 1];
            orderItemList.Remove(LastOrder);

            Items item = itemBusiness.GetItemById(LastOrder.item_id);
            TotalPrice -= item.price * LastOrder.quantity;

            totalPriceLabel.Text = string.Format("{0}€", TotalPrice.ToString());

            foodComboBox.SelectedIndex = -1;
            quantityTextBox.Text = "Quantity";

            RefreshListBox();
        }
    }
}
