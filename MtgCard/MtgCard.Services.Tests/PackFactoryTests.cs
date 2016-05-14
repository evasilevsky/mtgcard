using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Services.Tests
{
    [TestFixture]
    public class PackFactoryTests
    {
        [TestCase("KTK")]
        public void BuildRandomPackFromSet(string setName)
        {
            var packFactory = new PackFactory();

            var result = packFactory.BuildRandomPackFromSet(setName);
        }
    }
}
