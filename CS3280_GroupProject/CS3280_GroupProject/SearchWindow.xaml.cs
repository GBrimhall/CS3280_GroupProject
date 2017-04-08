using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace CS3280_GroupProject
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        #region Private Class Variables
        private SearchManager searchQueryManager;
        #endregion


        /// <summary>
        /// Creates a new search window.
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();

            #region Init. Class Variables
            //Setup Search Query Manager
            searchQueryManager = new SearchManager();
            #endregion  

            //Test Setup
            Invoice_Data.ItemsSource = searchQueryManager.GetAllInvoicesView();
        }

        /// <summary>
        /// Clears the invoice data list (DataGrid) when the clear button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Reset datagrid
                Invoice_Data.ItemsSource = searchQueryManager.GetAllInvoicesView();

                //Reset all drop down boxes
                Filter_Number.SelectedItem = null;
                Filter_Date.SelectedItem = null;
                Filter_Total.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pulls up the selected invoice when the select button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
