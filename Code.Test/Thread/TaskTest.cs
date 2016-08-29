using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code.Test.Thread
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void ExceptionTest()
        {
            try
            {
                Task.Run(() =>
                {
                    throw new Exception("task");
                });
            }
            catch (Exception ex)
            {
                //然而不会捕获，，，
                throw;
            }

        }
    }
}
