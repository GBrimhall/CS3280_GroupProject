using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS3280_GroupProject
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        // Create an instance of the class
        private ClsQuery invQueryManager;

        /// <summary>
        /// 
        /// </summary>
        public InventoryWindow()
        {
            InitializeComponent();
            invQueryManager = new ClsQuery();
        }

        /// <summary>
        /// Queries the invoice item description and pulls all of the item codes
        /// </summary>
        /// <returns></returns>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Query_Data.ItemsSource = invQueryManager.getItemData();
        }

        /// <summary>
        /// Selects item to add/delete item in the list using the item code eg. cost and item description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDelete_Click_1(object sender, RoutedEventArgs e)
        {
            // Need to add/change item description and cost
            invQueryManager.addDeleteData();
        }


        /// <summary>
        /// Button to cancel and close the current inventory window
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // close the current window and returns to previous
            this.Close();
        }
    }
}
