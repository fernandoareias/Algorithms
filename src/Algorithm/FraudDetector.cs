namespace Algorithm;

public class FraudDetector
{
    private readonly Dictionary<string, HyperLogLog<string>> ipToCpfMap;
    private readonly double threshold;

    public FraudDetector(double threshold)
    {
        this.ipToCpfMap = new Dictionary<string, HyperLogLog<string>>();
        this.threshold = threshold;
    }

    public void AddTransaction(string ip, string cpf)
    {
        if (!ipToCpfMap.ContainsKey(ip))
        {
            ipToCpfMap[ip] = new HyperLogLog<string>();
        }

        ipToCpfMap[ip].Add(cpf);
    }

    public bool IsPotentialFraud(string ip)
    {
        if (!ipToCpfMap.ContainsKey(ip))
        {
            return false;
        }

        return ipToCpfMap[ip].Cardinality() > threshold;
    }
}
