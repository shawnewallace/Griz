using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Griz.Core.Extensions;
using NUnit.Framework;

namespace Griz.Tests.Unit.ExtensionTests.StringExtensionTests
{
    [TestFixture]
    public class LeftTests
    {
        [Test]
        public void when_using_a_valid_string()
        {
            Assert.That("SUBSTRING".Left(3) == "SUB");
        }

        [Test]
        public void when_using_a_short_string()
        {
            Assert.That("SUB".Left(3) == "SUB");
        }

        [Test]
        public void when_using_a_really_short_string()
        {
            Assert.That("SUB".Left(40) == "SUB");
        }

        [Test]
        public void when_using_a_small_numer()
        {
            Assert.That("SUB".Left(0) == "SUB");
        }
        [Test]
        public void when_using_a_negative_numer()
        {
            Assert.That("SUB".Left(-10) == "SUB");
        }
    }
}
