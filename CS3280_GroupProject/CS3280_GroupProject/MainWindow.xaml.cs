using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CS3280_GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Variables
        private InvoiceManager inManager;
        private List<String> invoiceDetails;

        private string newID;
        private string invoiceDate;
        private int selectedRowIndex;
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Init the manager
            inManager = new InvoiceManager();
            invoiceDetails = new List<String>();
        }

        /// <summary>
        /// Creates a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NewInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enable General Controls
                controlsEnabled(true);

                grid.ItemsSource = null;

                //Save Invoice into system
                btn_Date.SelectedDate = DateTime.Today;
                inManager.SaveInvoice(btn_Date.SelectedDate.Value.Date.ToShortDateString(), "0");

                //Get new ID
                newID = inManager.GenerateInvoiceID();
                lb_InvoiceID.Text = String.Format("Invoice #{0}", newID);

                btn_New.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Saves the current invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controlsEnabled(false);
                btn_New.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
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
            try
            {
                //Open Search Window
                SearchWindow sw = new SearchWindow();
                sw.Show();

                //On Search Window close check for returned invoice

                //If there is an invoice then load and enable editing of invoice
                //TODO WAITING FOR GAVIN'S CODE TO BE FINISHED
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Open the Inventory Management Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditInventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Open the inventory management window
                InventoryWindow iw = new InventoryWindow();
                iw.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Adds a new item to the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cm_Item.SelectedItem.Equals("") || cm_Item.SelectedItem == null)
                    return;
                string selectedItemCode = cm_Item.SelectedItem.ToString();
                if (!lb_InvoiceID.Equals("Invoice #0000"))
                {
                    string invoiceNum = lb_InvoiceID.Text.Substring(9);

                    inManager.AddItemToInvoice(invoiceNum,
                        cm_Item.SelectedItem.ToString());

                    //Refresh grid
                    List<String> test = inManager.RetrieveInvoice(lb_InvoiceID.Text.Substring(9), ref invoiceDetails);
                    lb_Total.Text = "Total $" + invoiceDetails[2].ToString();
                    grid.ItemsSource = test.Select(Item => new { Item });

                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Deletes the current invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Disable Controls
                controlsEnabled(false);

                //Delete selected invoice from the database
                if (!lb_InvoiceID.Equals("Invoice #0000"))
                {
                    inManager.DeleteInvoice(lb_InvoiceID.Text.Substring(9));
                    lb_InvoiceID.Text = "Invoice #0000";
                    lb_Total.Text = "Total $0";
                }

                //Clear views to defaults
                grid.ItemsSource = null;
                btn_New.IsEnabled = true;
                btn_Edit.IsEnabled = false;
                btn_DeleteItem.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the invoice date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            //Check if data selected
            if (btn_Date.SelectedDate == null)
                return;

            //Save date
            invoiceDate = btn_Date.SelectedDate.Value.Date.ToShortDateString();
        }

        /// <summary>
        /// Updates the items in the list each time the list is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cm_Item_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                cm_Item.ItemsSource = inManager.populateItemList();

                //Set Selected row
                btn_Add.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Enables controls on the main window form
        /// </summary>
        /// <param name="enabled">Controls Enabled</param>
        private void controlsEnabled(bool enabled)
        {
            try
            {
                //Items Menu
                cm_Item.IsEnabled = enabled;
                cm_Item.SelectedItem = "";

                //Buttons
                btn_Add.IsEnabled = enabled;
                btn_Save.IsEnabled = enabled;
                btn_Delete.IsEnabled = enabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Fills labels and shows data for the item code selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cm_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItemCode = cm_Item.SelectedItem.ToString();
                string[] itemDetails = inManager.RetrieveItem(selectedItemCode);
                tb_Desc.Text = itemDetails[1];
                tb_Price.Text = "$" + itemDetails[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Gets teh selected item data on grid selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (cm_Item.IsEnabled == false)
                    return;

                if (grid.SelectedIndex < 0)
                {
                    btn_Edit.IsEnabled = false;
                    btn_Edit.IsEnabled = true;
                    btn_DeleteItem.IsEnabled = true;
                    return;
                }

                selectedRowIndex = grid.Items.IndexOf(grid.CurrentItem);
                Console.WriteLine(selectedRowIndex);

                string[] garbage = grid.SelectedItem.ToString().Substring(9).Split('0');
                string[] item = garbage[0].Split('-');

                cm_Item.SelectedItem = item[0].Trim();
                tb_Price.Text = item[2].Trim();
                tb_Desc.Text = item[1].Trim();

                btn_Edit.IsEnabled = true;
                btn_DeleteItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
            
        }
        /// <summary>
        /// Edits the selected data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid.SelectedIndex < 0)
                    return;

                string selectedItemCode = cm_Item.SelectedItem.ToString();
                if (!lb_InvoiceID.Equals("Invoice #0000"))
                {
                    string invoiceNum = lb_InvoiceID.Text.Substring(9);

                    Console.WriteLine(selectedRowIndex);
                    inManager.updateItemInDB(invoiceNum, selectedItemCode, (selectedRowIndex + 1).ToString());

                    //Refresh grid
                    grid.ItemsSource = null;
                    List<String> test = inManager.RetrieveInvoice(lb_InvoiceID.Text.Substring(9), ref invoiceDetails);
                    lb_Total.Text = "Total $" + invoiceDetails[2].ToString();
                    grid.ItemsSource = test.Select(Item => new { Item });
                    btn_Edit.IsEnabled = false;
                    btn_DeleteItem.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ":::" + ex.Message);
            }
        }

        /// <summary>
        /// Fires the event for when item is to be deleted form the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(selectedRowIndex);
                inManager.DeleteItemFromInvoice(lb_InvoiceID.Text.Substring(9), (selectedRowIndex + 1).ToString());

                //Refresh grid
                grid.ItemsSource = null;
                List<String> test = inManager.RetrieveInvoice(lb_InvoiceID.Text.Substring(9), ref invoiceDetails);
                lb_Total.Text = "Total $" + invoiceDetails[2].ToString();
                grid.ItemsSource = test.Select(Item => new { Item });
                btn_Edit.IsEnabled = false;
                btn_DeleteItem.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}
