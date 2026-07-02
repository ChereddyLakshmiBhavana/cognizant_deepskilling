namespace CustomerCommLib;

public class CustomerComm
{
    private readonly IMailSender _mailSender;

    public CustomerComm(IMailSender mailSender)
    {
        _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
    }

    public bool SendMailToCustomer()
    {
        const string toAddress = "customer@demo.com";
        const string message = "Welcome to Cognizant Digital Nurture 5.0";

        return _mailSender.SendMail(toAddress, message);
    }
}
