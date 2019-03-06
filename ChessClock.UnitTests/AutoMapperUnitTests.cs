using AutoMapper;
using ChessClock.Configuration;
using NUnit.Framework;

namespace ChessClock.UnitTests
{
    [TestFixture]
    class AutoMapperUnitTests
    {
        [Test]
        public void DalMapperConfigurationUnitTest()
        {
            Mapper.Initialize(m => m.AddDal());
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        [Test]
        public void ApiMapperConfigurationUnitTest()
        {
            Mapper.Initialize(m => m.AddApi());
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
