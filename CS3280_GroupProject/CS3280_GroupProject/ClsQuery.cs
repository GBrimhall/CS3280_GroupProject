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
        #region Class Variables
        // Connect to the database using private class string
        public static string sConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Invoice.mdb";
        private static object itemCode;
        private object itemDesc;
        private object cost;
        #endregion

        #region MainWindow Queries

        /// <summary>
        /// Gets an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string getInvoice(string invoiceNum)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = 5000";
        }

        /// <summary>
        /// Get all items on an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string getInvoiceItems(string invoiceNum)
        {
            return "SELECT ItemDesc.ItemCode, ItemDesc.ItemDesc, ItemDesc.COST " +
                "FROM ItemDesc, LineItems, Invoices " +
                "WHERE Invoices.InvoiceNum = LineItems.InvoiceNum AND LineItems.ItemCode = ItemDesc.ItemCode " +
                String.Format("AND Invoices.InvoiceNum = {0};", invoiceNum);
        }

        /// <summary>
        /// Updates a line item on the invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="itemCode"></param>
        /// <param name="lineNum"></param>
        /// <returns></returns>
        public static string updateInvoiceItem(string invoiceNum, string itemCode, string lineNum)
        {
            return "UPDATE LineItems " +
                String.Format("SET ItemCode = '{0}' ", itemCode) +
                String.Format("WHERE (LineItemNum = {0} ", lineNum) +
                String.Format("AND InvoiceNum = {0})", invoiceNum);
        }

        /// <summary>
        /// Delete an invoices items
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string deleteAllInvoiceItems(string invoiceNum)
        {
            return "Delete * FROM LineItems " +
                String.Format("WHERE InvoiceNum = {0}", invoiceNum);
        }

        /// <summary>
        /// Deletes an item from an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="lineItemNum"></param>
        /// <returns></returns>
        public static string deleteInvoiceItem(string invoiceNum, string lineItemNum)
        {
            return "Delete FROM LineItems " +
                string.Format("WHERE LineItemNum = {0} AND ", lineItemNum) +
                string.Format("InvoiceNum = {0}", invoiceNum);
        }

        /// <summary>
        /// Delete an invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string deleteInvoice(string invoiceNum)
        {
            return "Delete * FROM Invoices " +
                String.Format("WHERE InvoiceNum = {0}", invoiceNum);
        }

        /// <summary>
        /// Insert an invoice into the database
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public static string insertInvoice(string invoiceDate, string invoiceTotal)
        {
            return String.Format("INSERT INTO Invoices (InvoiceDate, TotalCharge)" +
                "VALUES (#{0}#, {1})", invoiceDate, invoiceTotal);
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
            return String.Format("INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                "VALUES ({0}, {1}, '{2}')", invoiceNum, lineNum, itemCode);
        }

        /// <summary>
        /// Gets the max invoice num
        /// </summary>
        /// <returns></returns>
        public static string generateInvoiceID()
        {
            return "SELECT MAX(InvoiceNum) FROM Invoices";
        }

        public static string getNextLineNum(string invoiceNum)
        {
            return "SELECT MAX(LineItemNum) FROM LineItems WHERE InvoiceNum = " + invoiceNum;
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

        /// <summary>
        /// Query for getting all invoices
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public static string getAllInvoices(string invoiceNum)
        {
            return "SELECT * FROM LineItems " +
                String.Format("WHERE InvoiceNum = {0};", invoiceNum);
        }

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
            return String.Format("SELECT * FROM INVOICES WHERE InvoiceNum = {0};",
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

        #region Inventory Window Queries
        public static string updateItem(string itemDesc, string cost, string itemCode)
        {
            return String.Format("UPDATE ItemDesc SET ItemDesc = '{0}', SET Cost = '{1}';" +
                "WHERE ItemCode = '{2}'",
                itemDesc, cost, itemCode);
        }

        public static string addNewItem(string itemCode, string itemDesc, string cost)
        {
            return String.Format("INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost)" +
                "VALUES ({0}, {1}, {2});", itemCode, itemDesc, cost);
        }

        public static string deleteItem(string itemCode)
        {
            return String.Format("DELETE FROM ItemDesc WHERE ItemCode = '{0}';", itemCode);
        }

        public static string getItem(string itemCode)
        {
            return String.Format("SELECT * FROM ItemDesc WHERE ItemCode = '{0}';", itemCode);
        }
        #endregion

        public static string getConnString()
        {
            return sConnString;
        }
    }
}

