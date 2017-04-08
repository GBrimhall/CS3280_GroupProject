using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject
{
    class ClsQuery
    {
        #region Private Class Variables
        // Connect to the database using private class string
        private string sConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Invoice.mdb";
        private static object itemCode;
        private object itemDesc;
        private object cost;
        #endregion

        #region MainWindow Queries

        /// <summary>
        /// Query for getting all invoices
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string getAllInvoices(string invoiceNum)
        {
            return "SELECT * FROM LineItems" +
                String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);
        }

        /// <summary>
        /// Get all items on an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string getInvoiceItems(string invoiceNum)
        {
            return "SELECT * FROM LineItems" +
                String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);
        }

        /// <summary>
        /// Delete an invoices items
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string deleteInvoiceItems(string invoiceNum)
        {
            return "Delete * FROM LineItems " + 
                String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);            
        }

        /// <summary>
        /// Delete an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string deleteInvoice(string invoiceNum)
        {
            return "Delete * FROM Invoices " + 
                String.Format("WHERE InvoiceNum = '{0}'", invoiceNum);
        }

        /// <summary>
        /// Insert an invoice into the database
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public static string insertInvoice(string invoiceNum, string invoiceDate, string invoiceTotal)
        {
            return String.Format("INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCharge)" +
                "VALUES ({0}, {1}, {2})",
                invoiceNum, invoiceDate, invoiceTotal);
        }

        /// <summary>
        /// Insert an invoices items
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="lineNum"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static string insertLineItems(string invoiceNum, string lineNum, string itemCode)
        {
            return String.Format("INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode)" +
                "VALUES ({0}, {1}, {2})", 
                invoiceNum, lineNum, itemCode);
        }

        /// <summary>
        /// Gets the max invoice num
        /// </summary>
        /// <returns></returns>
        public static string generateInvoiceID()
        {
            return "SELECT MAX(InvoiceNum) FROM Invoices";
        }

        /// <summary>
        /// Get all the items in the database
        /// </summary>
        /// <returns></returns>
        public static string getAllFromItemsDesc()
        {
            return "Select * FROM ItemDesc";
        }

        #endregion

        #region Search Window Queries
        public static string filterDate(string invoiceDate)
        {
            return String.Format("SELECT * FROM INVOICES WHERE InvoiceDate = '{0}';", 
                invoiceDate);
        }

        public static string filterTotal(string total)
        {
            return String.Format("SELECT * FROM INVOICES WHERE TotalCharge = '{0}':", 
                total);
        }

        public static string filterInvoiceNum(string invoiceNum)
        {
            return String.Format("SELECT * FROM INVOICES WHERE InvoiceNum = '{0}';", 
                invoiceNum);
        }

        public static string getDateOptions()
        {
            return String.Format("SELECT InvoiceDate FROM INVOICES;");
        }

        public static string getTotalOptions()
        {
            return String.Format("SELECT TotalCharge FROM INVOICES;");
        }

        public static string getInvoiceOptions()
        {
            return String.Format("SELECT InvoiceNum FROM INVOICE;");
        }

        #endregion

        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public string SelectInvoiceData(string sInvoiceID)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
            return sSQL;
        }

        /// <summary>
        /// creates a dataset to hold the items data
        /// </summary>
        /// <returns></returns>
        public DataView getItemData()
        {
            //Exception handling try catch for dataset
            try
            {
                //Create DataSet to hold query data
                DataSet ds = new DataSet();
                //Setup temp. variable to track number of returned items
                int iRetVal = 0;

                //Setup Query
                string sSQL = "SELECT * FROM ITEMDESC";

                //Setup connection to the database
                using (OleDbConnection conn = new OleDbConnection(sConnString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open Connection
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill dataset
                        adapter.Fill(ds);
                    }
                }

                iRetVal = ds.Tables[0].Rows.Count;

                return ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// creates a dataset to hold the items data that will be changed or updated
        /// </summary>
        /// <returns></returns>
        public DataView addDeleteData()
        {

            try
            {
                //Create DataSet to hold query data
                DataSet ds = new DataSet();
                //Setup temp. variable to track number of returned items
                int iRetVal = 0;

                //Setup Query
                string sSQL = String.Format("INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES('{0}', '{1}', '{2}')",
                itemCode, itemDesc, cost);

                //Setup connection to the database
                using (OleDbConnection conn = new OleDbConnection(sConnString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open Connection
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill dataset
                        adapter.Fill(ds);
                    }
                }

                iRetVal = ds.Tables[1].Rows.Count;

                return ds.Tables[1].DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Update items in list after checking for an empty or null value
        /// </summary>
        /// <returns></returns>
        public string updateItem()
        {
            ////Update Item
            string sSQL = String.Format("INSERT INTO ItemDesc(ItemDesc, Cost) VALUES('{1}', '{2}') WHERE ItemCode = {0}",
            itemCode, itemDesc, cost);
            //private static object itemCode;
            return sSQL;
        }

        /// <summary>
        /// Check to if the value to be edited already exists in the current list 
        /// </summary>
        /// <returns></returns>
        public string doesItemExist()
        {
            //Check for if Item is used in invoices is already there
            string sSQL = String.Format("Select InvoiceNum FROM LineItems WHERE ItemCode = '{0}';", itemCode);
            // Add if statements to handle item already exists in datafield
            return sSQL;
        }
    }
}

