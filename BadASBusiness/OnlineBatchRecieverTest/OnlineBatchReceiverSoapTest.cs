using NUnit.Framework;
using OnlineBatchReceiver;

namespace OnlineBatchRecieverTest
{
    [TestFixture]
    public class OnlineBatchReceiverSoapTest
    {
        [Test]
        public void ReceiveOnlineBatchExternalAttachment_Returns_FAILED_DO_NOT_RETRY_When_InvalidXml()
        {
            var target = new OnlineBatchReceiverSoap();

            var result = target.ReceiveOnlineBatchExternalAttachment("user", "", "", 0, "", null);
            Assert.IsTrue(result.Contains(resultCodeType.FAILED_DO_NOT_RETRY.ToString()));
        }

    }
}
