using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConverter.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void Should_Convert_From_a_Base_to_Another()
        {
            //arrange
            var base17Number = 10;
            //act
            var base2Number = Converter.Convert(base17Number, 2, 17);

            //assert
            Assert.That(base2Number, Is.EqualTo("10001"));
        }
    }
}
