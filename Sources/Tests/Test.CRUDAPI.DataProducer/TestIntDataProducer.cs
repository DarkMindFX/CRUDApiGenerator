using CRUDAPI.DataProducer;
using NUnit.Framework;
using System;

namespace Test.CRUDAPI.DataProducer
{
    public class TestIntDataProducer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateInt16IntDataProducer_Success()
        {
            var dataProducer = new IntDataProducer<Int16>();

            Assert.True(true);
        }

        [Test]
        public void CreateInt32IntDataProducer_Success()
        {
            var dataProducer = new IntDataProducer<Int32>();

            Assert.True(true);
        }

        [Test]
        public void CreateInt64IntDataProducer_Success()
        {
            var dataProducer = new IntDataProducer<Int64>();

            Assert.True(true);
        }

        [Test]
        public void CreateIntDataProducer_UnsupportedType_Exception()
        {
            try
            {
                var dataProducer = new IntDataProducer<bool>();

                Assert.Fail("ArgumentException expected but IntDataProducer was created");
            }
            catch(ArgumentException argEx)
            {
                Assert.True(true);
            }
            catch(Exception ex)
            {
                Assert.Fail($"ArgumentException expected but other exception was thrown: {ex}");
            }
        }

        [Test]
        public void GenerateRandomValueInt16_Success()
        {

        }
    }
}