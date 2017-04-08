using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Variables
        private InvoiceManager inManager;
        private DateTime selectedDate;
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Init the manager
            inManager = new InvoiceManager();
        }

        /// <summary>
        /// Creates a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Saves the current invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Opens the Invoice Search Window. Wthen the window closes
        /// it checks for a selected invoice and will display the invoice
        /// for editing or deleting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            //Open Search Window
            SearchWindow sw = new SearchWindow();
            sw.Show();

            //On Search Window close check for returned invoice

            //If there is an invoice then load and enable editing of invoice
        }

        /// <summary>
        /// Open the Inventory Management Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditInventory_Click(object sender, RoutedEventArgs e)
        {
            // Open the inventory management window

            //Once inventory management window is closed update item's drop down
        }

        /// <summary>
        /// Adds a new item to the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //Create new invoice ID

            //Display invoice data
        }

        /// <summary>
        /// Deletes the current invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete selected invoice from the database

            //Clear views to defaults
        }

        /// <summary>
        /// Updates the invoice date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            //Check if data selected

            //If so then save date for use when saving invoice
        }
    }
}
