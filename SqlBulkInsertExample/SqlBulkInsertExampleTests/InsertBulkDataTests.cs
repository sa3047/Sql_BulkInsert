using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SqlBulkInsertExample.Tests
{
    [TestClass()]
    public class InsertBulkDataTests
    {
        /// <summary>
        /// Tests Connection string is null
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertDataTest()
        {
            //Arrange
            InsertBulkData insertData = new InsertBulkData(string.Empty);

            //Act
            insertData.InsertData();


        }
    }
}