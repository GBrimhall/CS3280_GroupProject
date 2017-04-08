using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject
{
    class SearchManager
    {
        #region Private Class Variables
        #endregion

        /// <summary>
        /// Creates a new search query manager that controls all the searching needed for the search
        /// window class.
        /// </summary>
        public SearchManager()
        {

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

                //Setup connection to the database

                //Get query results

                //return query results
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of options for the invoice numbers
        /// </summary>
        /// <returns></returns>
        public DataView filterInvoiceNumberOptions(string invoiceNum)
        {
            try
            {
                //Create DataSet to hold query data

                //Setup connection to the database

                //Get query results

                //return query results
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrives a list of options for date filter
        /// </summary>
        /// <returns></returns>
        public DataView filterDateOptions(string invoiceDate)
        {
            try
            {
                //Create DataSet to hold query data

                //Setup connection to the database

                //Get query results

                //return query results
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of Total Filters
        /// </summary>
        /// <returns></returns>
        public DataView filterTotalOptions(string total)
        {
            try
            {
                //Create DataSet to hold query data

                //Setup connection to the database

                //Get query results

                //return query results
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
