using System.Diagnostics;
using Algorithm;



int capacity = 2000000;
var blackList = new BloomFilter<string>(capacity);
var cpfs = new List<string>();
int totalCPF = 1000000;
int blackListCount = (int)(totalCPF * 0.97);
int nonBlackListCount = totalCPF - blackListCount;

// Medir o tempo de processamento
Stopwatch stopwatch = Stopwatch.StartNew();

Process process = Process.GetCurrentProcess();
long memoryBefore = process.WorkingSet64;

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

stopwatch.Stop();
double elapsedTime = stopwatch.Elapsed.TotalSeconds;

long memoryAfter = process.WorkingSet64;
long memoryUsed = memoryAfter - memoryBefore;
double memoryUsedMiB = memoryUsed / (1024.0 * 1024.0);

double accuracy = (double)(truePositives + trueNegatives) / totalCPF * 100;
double falsePositiveRate = (double)falsePositives / nonBlackListCount * 100;
double falseNegativeRate = (double)falseNegatives / blackListCount * 100;

Console.WriteLine($"Total CPFs Processados: {totalCPF}");
Console.WriteLine($"True Positives: {truePositives}");
Console.WriteLine($"False Positives: {falsePositives}");
Console.WriteLine($"True Negatives: {trueNegatives}");
Console.WriteLine($"False Negatives: {falseNegatives}");
Console.WriteLine($"Accuracy: {accuracy:F2}%");
Console.WriteLine($"False Positive Rate: {falsePositiveRate:F2}%");
Console.WriteLine($"False Negative Rate: {falseNegativeRate:F2}%");
Console.WriteLine($"Tempo de Processamento: {elapsedTime:F2} segundos");
Console.WriteLine($"Uso de Memória: {memoryUsedMiB:F2} MiB");