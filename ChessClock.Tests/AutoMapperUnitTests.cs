using AutoMapper;
using ChessClock.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClock.Tests
{
    [TestFixture]
    class AutoMapperUnitTests
    {
        [Test]
        public void DalMapperConfigurationUnitTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddDal());
            configuration.AssertConfigurationIsValid();
        }
    }
}
