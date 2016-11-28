using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandler
{
    public class ErrorHandlern
    {
        public static string HandleExceptions(Exception ex)
        {

            if (ex is SqlException)
            {
                return ex.Message;
            }
            else if (ex is FormatException)
            {
                return "Only numbers in ID";
            }
            else if (ex is OverflowException)
            {
                return "Too many digits in ID";
            }
            else if (ex is ArgumentNullException)
            {
                return "Make a selection first";
            }
            else if (ex is InvalidOperationException)
            {
                return "Invalid operation";
            }
            else if (ex is NullReferenceException)
            {
                return "No record was found";
            }
            return "Your request could not be executed";
        }
    }
}
