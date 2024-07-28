namespace Algorithm.Tests;

public class FraudDetectorTests
{
    [Fact]
    public void DetectsFraudWhenIpAccessesTooManyCpfs()
    {
        var threshold = 5;
        var fraudDetector = new FraudDetector(threshold);
        var ip = "192.168.1.1";

        fraudDetector.AddTransaction(ip, "123.456.789-00");
        fraudDetector.AddTransaction(ip, "123.456.789-01");
        fraudDetector.AddTransaction(ip, "123.456.789-02");
        fraudDetector.AddTransaction(ip, "123.456.789-03");
        fraudDetector.AddTransaction(ip, "123.456.789-04");
        fraudDetector.AddTransaction(ip, "123.456.789-05");

        Assert.True(fraudDetector.IsPotentialFraud(ip));
    }

    [Fact]
    public void DoesNotDetectFraudWhenIpAccessesFewCpfs()
    {
        var threshold = 5;
        var fraudDetector = new FraudDetector(threshold);
        var ip = "192.168.1.1";

        fraudDetector.AddTransaction(ip, "123.456.789-00");
        fraudDetector.AddTransaction(ip, "123.456.789-01");
        fraudDetector.AddTransaction(ip, "123.456.789-02");
        fraudDetector.AddTransaction(ip, "123.456.789-03");

        Assert.False(fraudDetector.IsPotentialFraud(ip));
    }
}
