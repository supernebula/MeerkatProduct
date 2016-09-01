using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            var cancellationToken = tokenSource.Token;
            try
            {
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(3);
                }, cancellationToken).ContinueWith(t =>  Trace.WriteLine("IsCanceled:" + t.IsCanceled + ",  t.IsCompleted:" + t.IsCompleted + ",IsFaulted:" + t.IsFaulted) );
                tokenSource.Cancel();
            }
            catch (Exception ex)
            {
                //然而不会捕获，，，
                throw;
            }

        }
    }
}
