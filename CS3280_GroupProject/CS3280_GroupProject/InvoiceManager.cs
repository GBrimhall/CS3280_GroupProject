using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
        public List<String> RetrieveInvoice(string invoiceNum, ref List<String> invoiceData)
        {
            try
            {
                //Clear List
                invoiceData.Clear();
                int iRet = 0;
                double total = 0;

                //Items list
                List<String> invoiceItems = new List<String>();

                //Get Invoice
                DataSet ds = ExecuteSQLStatement(ClsQuery.getInvoice("5001"), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Add invoice date
                    invoiceData.Add(dr[1].ToString());
                    //Add invoice total
                    invoiceData.Add(dr[2].ToString());
                }

                //Get Invoice Items
                ds = ExecuteSQLStatement(ClsQuery.getInvoiceItems(invoiceNum), ref iRet);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Add price
                    int stringNum;
                    Int32.TryParse(dr[2].ToString(), out stringNum);
                    total += stringNum;

                    //Add item to list
                    invoiceItems.Add(string.Format("{0} - {1} - ${2}", dr[0], dr[1], dr[2]));

                }
                invoiceData.Add(total.ToString());

                //Return invoice as dataset
                return invoiceItems;
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
                //Delete invoice line items
                ExecuteNonQuery(ClsQuery.deleteInvoiceItems(invoiceNum));

                //Delete Invoice
                ExecuteNonQuery(ClsQuery.deleteInvoice(invoiceNum));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes in an invoice in the form of a dataset and saves it
        /// to the database
        /// </summary>
        /// <param name="invoiceDataSet">The invoice in a dataset structure</param>
        public void SaveInvoice(string date, string total)
        {
            try
            {
                ExecuteNonQuery(ClsQuery.insertInvoice(date, total));

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
                int iRet = 0;
                int mID = 0;

                //Get Invoice Max ID from data
                DataSet ds = ExecuteSQLStatement(ClsQuery.generateInvoiceID(), ref iRet);
                Int32.TryParse(ds.Tables[0].Rows[0].ItemArray[0].ToString(), out mID);
                string newID = (mID + 1).ToString();
                //return ID as string
                return newID;
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
        public List<String> populateItemList()
        {
            try
            {
                //Make a new list
                List<String> items = new List<String>();
                int iRet = 0;
                //Send query
                DataSet ds = ExecuteSQLStatement(ClsQuery.getAllFromItemsDesc(), ref iRet);

                //Populate list
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    items.Add(dr[0].ToString());
                }

                //Return list
                return items;
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
        public string[] RetrieveItem(string itemID)
        {
            try
            {
                //Make a new list
                string[] itemDetails = new string[3];
                int iRet = 0;

                DataSet ds = ExecuteSQLStatement(ClsQuery.getItem(itemID), ref iRet);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Item Code
                    itemDetails[0] = dr[0].ToString();
                    //Item Desc
                    itemDetails[1] = dr[1].ToString();
                    //Item Price
                    itemDetails[2] = dr[2].ToString();
                }
                return itemDetails;
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
        public void AddItemToInvoice(string invoiceNum, string itemID)
        {
            try
            {
                int iRet = 0;
                DataSet ds = ExecuteSQLStatement(ClsQuery.getNextLineNum(invoiceNum), ref iRet);
                string nextLine = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                int lineNum = 1;
                Int32.TryParse(nextLine, out lineNum);

                //Add line item
                //If there are no line items set it to the first line
                if (nextLine.Equals(""))
                    nextLine = "1";
                lineNum++;
                nextLine = lineNum.ToString();

                ExecuteNonQuery(ClsQuery.insertLineItems(invoiceNum, nextLine, itemID));                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateItemInDB(string invoiceNum, string itemID, string lineNum)
        {
            try
            {
                ExecuteNonQuery(ClsQuery.updateInvoiceItem(invoiceNum, itemID, lineNum));
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

        #region SQL Exe

        /// <summary>
        /// SQL Executer with return values
        /// </summary>
        /// <param name="sSQL"></param>
        /// <param name="iRetVal"></param>
        /// <returns></returns>
        private DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(ClsQuery.getConnString()))
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

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQL executer with no expected return values
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        private int ExecuteNonQuery(string sSQL)
        {
            try
            {
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(ClsQuery.getConnString()))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    iNumRows = cmd.ExecuteNonQuery();
                }

                return iNumRows;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
