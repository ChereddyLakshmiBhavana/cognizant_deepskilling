using Moq;

namespace CustomerComm.Tests;

[TestFixture]
public class CustomerCommTests
{
    private Mock<global::CustomerCommLib.IMailSender> _mailSenderMock = null!;
    private global::CustomerCommLib.CustomerComm _customerComm = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mailSenderMock = new Mock<global::CustomerCommLib.IMailSender>();
        _mailSenderMock
            .Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _customerComm = new global::CustomerCommLib.CustomerComm(_mailSenderMock.Object);
    }

    [Test]
    public void SendMailToCustomer_ShouldReturnTrue_WhenSendMailReturnsTrue()
    {
        var result = _customerComm.SendMailToCustomer();

        Assert.That(result, Is.True);
        _mailSenderMock.Verify(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}