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
            var initParams = new IntDataProducerParams<Int16> { RangeStart = Int16.MinValue, RangeEnd = Int16.MaxValue };

            var dataProducer = new IntDataProducer<Int16>();
            dataProducer.Init(initParams);

            for(int i = 0; i < 1000; ++i)
            {
                var genValue = dataProducer.NextValue();
                if(genValue < Int16.MinValue || genValue > Int16.MaxValue)
                {
                    Assert.Fail($"Unexpected value {genValue} was generated outside range [{Int16.MinValue}, {Int16.MaxValue}]");
                }
            }
        }

        [Test]
        public void GenerateRandomValueInt32_Success()
        {
            var initParams = new IntDataProducerParams<Int32> { RangeStart = Int32.MinValue, RangeEnd = Int32.MaxValue };

            var dataProducer = new IntDataProducer<Int32>();
            dataProducer.Init(initParams);

            for (int i = 0; i < 1000; ++i)
            {
                var genValue = dataProducer.NextValue();
                if (genValue < Int32.MinValue || genValue > Int32.MaxValue)
                {
                    Assert.Fail($"Unexpected value {genValue} was generated outside range [{Int32.MinValue}, {Int32.MaxValue}]");
                }
            }
        }

        [Test]
        public void GenerateRandomValueInt64_Success()
        {
            var initParams = new IntDataProducerParams<Int64> { RangeStart = Int64.MinValue, RangeEnd = Int64.MaxValue };

            var dataProducer = new IntDataProducer<Int64>();
            dataProducer.Init(initParams);

            for (int i = 0; i < 1000; ++i)
            {
                var genValue = dataProducer.NextValue();
                if (genValue < Int64.MinValue || genValue > Int64.MaxValue)
                {
                    Assert.Fail($"Unexpected value {genValue} was generated outside range [{Int64.MinValue}, {Int64.MaxValue}]");
                }
            }
        }
    }


}