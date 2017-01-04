using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steam.Models;

namespace Steam.Context.Tests
{
    [TestClass()]
    public class BestellingSQLTests
    {
        [TestMethod()]
        public void AddBestellingTest()
        {
            BestellingSQL b = new BestellingSQL();
            b.AddBestelling(null, null);
        }
    }
}