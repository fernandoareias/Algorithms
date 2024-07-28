using Algorithm.Utils;

namespace Algorithm;


public class HyperLogLog<T> where T : notnull
{
    private const int P = 16;
    private const double AlphaMM = 0.7213 / (1 + 1.079 / (1 << P)) * (1 << P) * (1 << P);
    private readonly int[] registers;
    private readonly int m;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="HyperLogLog{T}"/>.
    /// </summary>
    public HyperLogLog()
    {
        m = 1 << P;
        registers = new int[m];
    }

    /// <summary>
    /// Mescla dois HyperLogLogs para formar uma união HLL.
    /// </summary>
    /// <param name="first">O primeiro HLL.</param>
    /// <param name="second">O segundo HLL.</param>
    /// <returns>Um HyperLogLog com os valores combinados dos dois conjuntos de registros.</returns>
    public static HyperLogLog<T> Merge(HyperLogLog<T> first, HyperLogLog<T> second)
    {
        if (first.m != second.m)
        {
            throw new ArgumentException("Não é possível mesclar HyperLogLogs com diferentes precisões.");
        }

        var output = new HyperLogLog<T>();
        for (var i = 0; i < first.m; i++)
        {
            output.registers[i] = Math.Max(first.registers[i], second.registers[i]);
        }
        return output;
    }

    /// <summary>
    /// Adiciona um item ao HyperLogLog.
    /// </summary>
    /// <param name="item">O item a ser adicionado.</param>
    public void Add(T item)
    {
        var x = MurmurHash3.Hash32(item.GetHashCode());
        var j = x >> (32 - P);
        var w = (x << P) | (1 << (P - 1));
        var rho = 1;

        while ((w & 0x80000000) == 0)
        {
            rho++;
            w <<= 1;
        }

        registers[j] = Math.Max(registers[j], rho);
    }

    /// <summary>
    /// Determina a cardinalidade aproximada do HyperLogLog.
    /// </summary>
    /// <returns>A cardinalidade aproximada.</returns>
    public double Cardinality()
    {
        double z = 0.0;
        int v = 0;
        
        for (int i = 0; i < m; i++)
        {
            z += 1.0 / (1 << registers[i]);
            if (registers[i] == 0) v++;
        }

        double estimate = AlphaMM / z;

        // Correção para pequenos intervalos
        if (estimate <= 2.5 * m)
        {
            if (v > 0)
            {
                estimate = m * Math.Log((double)m / v);
            }
        }
        // Correção para grandes intervalos
        else if (estimate > (1 / 30.0) * int.MaxValue)
        {
            estimate = -(int.MaxValue) * Math.Log(1.0 - (estimate / int.MaxValue));
        }

        return estimate;
    }
}
