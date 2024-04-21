using CRUDAPI.DataProducer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CRUDAPI.DataProducer
{
    public class TestDateDataProducer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDatesInRange_Success()
        {
            var initParams = new DateDataProducerParams()
            {
                RangeStart = new DateTime(2023, 1, 1),
                RangeEnd = new DateTime(2023, 12, 31)
            };

            var producer = new DateDataProducer();
            producer.Init(initParams);

            for(int i = 0; i < 1000; ++i)
            {
                var date = producer.NextValue();
                Assert.IsTrue(date >= initParams.RangeStart && date <= initParams.RangeEnd, "Generated date outside the stard/end range");
            }
        }

        [Test]
        public void EqualStartEndDates_Success()
        {
            try
            {
                var initParams = new DateDataProducerParams()
                {
                    RangeStart = new DateTime(2023, 1, 1),
                    RangeEnd = new DateTime(2023, 1, 1)
                };

                var producer = new DateDataProducer();
                producer.Init(initParams);
            }
            catch(ArgumentException argEx)
            {
                Assert.IsTrue(true); // OK - exception expected
            }
            catch(Exception ex)
            {
                Assert.Fail("Exception of type ArgumentException is expected"); 
            }            
        }

        [Test]
        public void StartGreaterThanEndDates_Success()
        {
            try
            {
                var initParams = new DateDataProducerParams()
                {
                    RangeStart = new DateTime(2023, 2, 1),
                    RangeEnd = new DateTime(2023, 1, 1)
                };

                var producer = new DateDataProducer();
                producer.Init(initParams);
            }
            catch (ArgumentException argEx)
            {
                Assert.IsTrue(true); // OK - exception expected
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception of type ArgumentException is expected");
            }
        }
    }
}
