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

