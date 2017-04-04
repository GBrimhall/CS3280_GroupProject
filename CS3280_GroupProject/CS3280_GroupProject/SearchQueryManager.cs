using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject
{
    class SearchQueryManager
    {
        #region Private Class Variables
        private string sConnString;
        #endregion

        /// <summary>
        /// Creates a new search query manager that controls all the searching needed for the search
        /// window class.
        /// </summary>
        public SearchQueryManager()
        {
            //Create the database connection string
            sConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Invoice.mdb";
        }

        /// <summary>
        /// Queries the invoice database and pulls all of the invoices
        /// </summary>
        /// <returns></returns>
        public DataView GetAllInvoicesView()
        {
            try
            {
                //Create DataSet to hold query data
                DataSet ds = new DataSet();
                //Setup temp. variable to track number of returned items
                int iRetVal = 0;

                //Setup Query
                string sSQL = "SELECT * FROM INVOICES";

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
    }
  }
