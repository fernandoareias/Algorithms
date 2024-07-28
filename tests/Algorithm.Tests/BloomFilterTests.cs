namespace Algorithm.Tests;

public class BloomFilterTests
{
  [Fact]
    public void ShouldHaveAccuracyMoreThan95Percents()
    {
        int capacity = 2000000;
        var blackList = new BloomFilter<string>(capacity);
        var cpfs = new List<string>();
        int totalCPF = 1000000;
        int blackListCount = (int)(totalCPF * 0.97);
        int nonBlackListCount = totalCPF - blackListCount;
 
        for (int i = 0; i < totalCPF; i++)
        {
            cpfs.Add(CPFGenerator.GerarCPF());
        }
 
        for (int i = 0; i < blackListCount; i++)
        {
            blackList.Add(cpfs[i]);
        }

        int truePositives = 0;
        int falsePositives = 0;
        int trueNegatives = 0;
        int falseNegatives = 0;
 
        for (int i = 0; i < totalCPF; i++)
        {
            bool isInBlackList = blackList.Contains(cpfs[i]);
            if (i < blackListCount)
            {
                if (isInBlackList)
                    truePositives++;
                else
                    falseNegatives++;
            }
            else
            {
                if (isInBlackList)
                    falsePositives++;
                else
                    trueNegatives++;
            }
        }

        double accuracy = (double)(truePositives + trueNegatives) / totalCPF * 100;

        Assert.True(accuracy > 95); 
    }
}