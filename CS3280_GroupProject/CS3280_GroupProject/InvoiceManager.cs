using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject
{
    /// <summary>
    /// This class goes along with the Invoice Main Menu. It controls all business logic for the main menu.
    /// </summary>
    class InvoiceManager
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InvoiceManager()
        {

        }

        /// <summary>
        /// Retreives an invoice from the database with the
        /// ID provided
        /// </summary>
        /// <param name="invoiceNum">ID of invoice to retrieve</param>
        /// <returns>Returns an invoice as a dataset structure</returns>
        public DataSet RetrieveInvoice(string invoiceNum)
        {
            try
            {
                //Make connection to database

                //Get Invoice
                string sSql = "SELECT * FROM Invoices" +
                    String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);

                //Get Invoice Items
                sSql = "SELECT * FROM LineItems" +
                    String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);

                //Return invoice as dataset
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the invoice with the corresponding invoice ID
        /// from the database.
        /// </summary>
        /// <param name="invoiceNum">The invoice ID</param>
        /// <returns></returns>
        public void DeleteInvoice(string invoiceNum)
        {
            try
            {
                //Make connection to database

                //Delete invoice line items
                string sSQL = "Delete * FROM LineItems " +
                    String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);

                //Delete Invoice
                sSQL = "Delete * FROM Invoices " +
                    String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes in an invoice in the form of a dataset and saves it
        /// to the database
        /// </summary>
        /// <param name="invoiceDataSet">The invoice in a dataset structure</param>
        public void SaveInvoice(DataSet invoiceDataSet)
        {
            try
            {
                //Make connection to database

                //Save invoice
                string sSQL = String.Format("INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCharge) VALUES ({0}, {1}, {2})", 
                    invoiceNum, invoiceDate, invoiceTotal);

                //Save line items
                sSQL = String.Format("INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) VALUES ({0}, {1}, {2})",
                                    invoiceNum, lineNum, itemCode);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Connects to the database and calculates the next invoice ID then
        /// returns it.
        /// </summary>
        /// <returns>Returns a new invoice ID as a string</returns>
        public string GenerateInvoiceID()
        {
            try
            {
                //Make connection to database

                //Calculate invoice ID
                string sSQL = "SELECT MAX(InvoiceNum) FROM Invoices";

                //return ID as string
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Connects to the database and generates a list of
        /// items from the Inventory Table.
        /// </summary>
        /// <returns>List of Items from Inventory Table</returns>
        public List<String> UpdateItemList()
        {
            try
            {
                //Make connection to database

                //Get Items
                string sSQL = "Select * FROM ItemDesc";

                //Create list of items

                //Return list
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retreives an item from the database with the
        /// item ID provided
        /// </summary>
        /// <param name="itemID">ID of item to retrieve</param>
        /// <returns>returns an item as a dataset structure</returns>
        public DataSet RetrieveItem(string itemID)
        {
            try
            {
                //Make connection to database

                //Get item
                string sSQL = String.Format("SELECT * FROM LineItems WHERE ItemCode = '{0}'", itemCode);

                //Return item data as dataset
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the item to the invoice
        /// </summary>
        /// <param name="itemID">ID of the item to add</param>
        public void AddItemToInvoice(string itemID)
        {
            try
            {
                //Make connection to database

                //Get item

                //Save item to invoice
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the item from the invoice
        /// </summary>
        /// <param name="itemID">ID of the item to remove</param>
        public void DeleteItemFromInvoice(string itemID)
        {
            try
            {
                //Make connection to database

                //Get item

                //Remove item to invoice
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
