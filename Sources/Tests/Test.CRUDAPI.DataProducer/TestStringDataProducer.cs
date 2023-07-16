using CRUDAPI.DataProducer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CRUDAPI.DataProducer
{
    public class TestStringDataProducer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateString_ZeroChars_ExceptionThrown()
        {
            try
            {
                var initParams = new StringDataProducerParams() { MaxLength = 0 };

                var strProducer = new StringDataProducer();
                strProducer.Init(initParams);

                Assert.Fail("ArgumentException expected but StringDataProducer was created");
            }
            catch(ArgumentException argEx)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail($"ArgumentException expected but other exception was thrown: {ex}");
            }
        }

        [Test]
        public void GenerateString_OneChar_Success()
        {
            var initParams = new StringDataProducerParams() { MaxLength = 1 };

            var strProducer = new StringDataProducer();
            strProducer.Init(initParams);

            var s = strProducer.NextValue();

            Assert.AreEqual(s.Length, 1);
        }

        [TestCase((uint)10)]
        [TestCase((uint)100)]
        [TestCase((uint)1000)]
        public void GenerateString_ManyChars_Success(uint length)
        {
            var initParams = new StringDataProducerParams() { MaxLength = length };

            var strProducer = new StringDataProducer();
            strProducer.Init(initParams);

            var s = strProducer.NextValue();

            Assert.LessOrEqual(s.Length, length);
        }
    }
}
