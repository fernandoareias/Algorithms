using System.Collections;
using BenchmarkDotNet.Attributes;

namespace Algorithm;

[MemoryDiagnoser]
public class BloomFilter<T> where T : notnull
{
    private readonly int _hashFunctionCount;
    private readonly BitArray _hashBits;
    private readonly HashFunction _getHashSecondary;

    /// <summary>
    /// Cria um novo filtro de Bloom, especificando uma taxa de erro de 1/capacidade,
    /// usando o tamanho ideal para a estrutura de dados subjacente com base na capacidade desejada e taxa de erro,
    /// bem como o número ideal de funções hash.
    /// Uma função hash secundária será fornecida se o tipo T for string ou int. Caso contrário, uma exceção será lançada.
    /// </summary>
    /// <param name="capacity">O número antecipado de itens a serem adicionados ao filtro de Bloom.</param>
    public BloomFilter(int capacity)
        : this(capacity, null)
    {
    }

    /// <summary>
    /// Cria um novo filtro de Bloom, usando o tamanho ideal para a estrutura de dados subjacente com base na capacidade desejada e taxa de erro,
    /// bem como o número ideal de funções hash.
    /// </summary>
    /// <param name="capacity">O número antecipado de itens a serem adicionados ao filtro de Bloom.</param>
    /// <param name="errorRate">A taxa aceitável de falso-positivo (por exemplo, 0.01F = 1%)</param>
    public BloomFilter(int capacity, float errorRate)
        : this(capacity, errorRate, null)
    {
    }

    /// <summary>
    /// Cria um novo filtro de Bloom, especificando uma taxa de erro de 1/capacidade,
    /// usando o tamanho ideal para a estrutura de dados subjacente com base na capacidade desejada e taxa de erro,
    /// bem como o número ideal de funções hash.
    /// </summary>
    /// <param name="capacity">O número antecipado de itens a serem adicionados ao filtro de Bloom.</param>
    /// <param name="hashFunction">A função para hash dos valores de entrada. Não use GetHashCode().</param>
    public BloomFilter(int capacity, HashFunction hashFunction)
        : this(capacity, BestErrorRate(capacity), hashFunction)
    {
    }

    /// <summary>
    /// Cria um novo filtro de Bloom, usando o tamanho ideal para a estrutura de dados subjacente com base na capacidade desejada e taxa de erro,
    /// bem como o número ideal de funções hash.
    /// </summary>
    /// <param name="capacity">O número antecipado de itens a serem adicionados ao filtro de Bloom.</param>
    /// <param name="errorRate">A taxa aceitável de falso-positivo (por exemplo, 0.01F = 1%)</param>
    /// <param name="hashFunction">A função para hash dos valores de entrada. Não use GetHashCode().</param>
    public BloomFilter(int capacity, float errorRate, HashFunction hashFunction)
        : this(capacity, errorRate, hashFunction, BestM(capacity, errorRate), BestK(capacity, errorRate))
    {
    }

    /// <summary>
    /// Cria um novo filtro de Bloom.
    /// </summary>
    /// <param name="capacity">O número antecipado de itens a serem adicionados ao filtro de Bloom.</param>
    /// <param name="errorRate">A taxa aceitável de falso-positivo (por exemplo, 0.01F = 1%)</param>
    /// <param name="hashFunction">A função para hash dos valores de entrada. Não use GetHashCode().</param>
    /// <param name="m">O número de elementos no BitArray.</param>
    /// <param name="k">O número de funções hash a serem usadas.</param>
    public BloomFilter(int capacity, float errorRate, HashFunction hashFunction, int m, int k)
    { 
        if (capacity < 1)
        {
            throw new ArgumentOutOfRangeException("capacity", capacity, "capacity must be > 0");
        }
 
        if (errorRate >= 1 || errorRate <= 0)
        {
            throw new ArgumentOutOfRangeException("errorRate", errorRate, string.Format("errorRate must be between 0 and 1, exclusive. Was {0}", errorRate));
        }
 
        if (m < 1)
        {
            throw new ArgumentOutOfRangeException(string.Format("Os valores fornecidos de capacidade e taxa de erro resultariam em um array com comprimento > int.MaxValue. Por favor, reduza esses valores. Capacidade: {0}, Taxa de erro: {1}", capacity, errorRate));
        }

        // Define a função hash secundária
        if (hashFunction == null)
        {
            if (typeof(T) == typeof(string))
            {
                this._getHashSecondary = HashString;
            }
            else if (typeof(T) == typeof(int))
            {
                this._getHashSecondary = HashInt32;
            }
            else
            {
                throw new ArgumentNullException("hashFunction", "Por favor, forneça uma função hash para o seu tipo T, quando T não é uma string ou int.");
            }
        }
        else
        {
            this._getHashSecondary = hashFunction;
        }

        this._hashFunctionCount = k;
        this._hashBits = new BitArray(m);
    }

    /// <summary>
    /// Função delegada que pode ser usada para hash de entrada.
    /// </summary>
    /// <param name="input">Os valores a serem hash.</param>
    /// <returns>O código hash resultante.</returns>
    public delegate int HashFunction(T input);

    /// <summary>
    /// A proporção de bits falsos para verdadeiros no filtro de Bloom.
    /// </summary>
    public double Truthiness
    {
        get
        {
            return (double)this.TrueBits() / this._hashBits.Count;
        }
    }

    /// <summary>
    /// Adiciona um novo item ao filtro de Bloom. Não pode ser removido.
    /// </summary>
    /// <param name="item">O item.</param>
    [Benchmark]
    public void Add(T item)
    {
        // Começa a alterar os bits para cada hash do item
        int primaryHash = item.GetHashCode();
        int secondaryHash = this._getHashSecondary(item);
        for (int i = 0; i < this._hashFunctionCount; i++)
        {
            int hash = this.ComputeHash(primaryHash, secondaryHash, i);
            this._hashBits[hash] = true;
        }
    }

    /// <summary>
    /// Verifica a existência do item no filtro de Bloom para uma determinada probabilidade.
    /// </summary>
    /// <param name="item">O item.</param>
    /// <returns>Um valor booleano indicando se o item está no filtro.</returns>
    [Benchmark]
    public bool Contains(T item)
    {
        int primaryHash = item.GetHashCode();
        int secondaryHash = this._getHashSecondary(item);
        for (int i = 0; i < this._hashFunctionCount; i++)
        {
            int hash = this.ComputeHash(primaryHash, secondaryHash, i);
            if (this._hashBits[hash] == false)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Calcula o melhor valor de k (número de funções hash) baseado na capacidade e taxa de erro.
    /// </summary>
    /// <param name="capacity">A capacidade.</param>
    /// <param name="errorRate">A taxa de erro.</param>
    /// <returns>O melhor valor de k.</returns>
    private static int BestK(int capacity, float errorRate)
    {
        return (int)Math.Round(Math.Log(2.0) * BestM(capacity, errorRate) / capacity);
    }

    /// <summary>
    /// Calcula o melhor valor de m (número de elementos no BitArray) baseado na capacidade e taxa de erro.
    /// </summary>
    /// <param name="capacity">A capacidade.</param>
    /// <param name="errorRate">A taxa de erro.</param>
    /// <returns>O melhor valor de m.</returns>
    private static int BestM(int capacity, float errorRate)
    {
        return (int)Math.Ceiling(capacity * Math.Log(errorRate, (1.0 / Math.Pow(2, Math.Log(2.0)))));
    }

    /// <summary>
    /// Calcula a melhor taxa de erro baseado na capacidade.
    /// </summary>
    /// <param name="capacity">A capacidade.</param>
    /// <returns>A melhor taxa de erro.</returns>
    private static float BestErrorRate(int capacity)
    {
        float c = (float)(1.0 / capacity);
        if (c != 0)
        {
            return c;
        }

        // Padrão se c for 0
        // http://www.cs.princeton.edu/courses/archive/spring02/cs493/lec7.pdf
        return (float)Math.Pow(0.6185, int.MaxValue / capacity);
    }

    /// <summary>
    /// Hash de um inteiro.
    /// </summary>
    /// <param name="input">O inteiro a ser hash.</param>
    /// <returns>O código hash.</returns>
    private int HashInt32(T input)
    {
        return ((int)(object)input).GetHashCode();
    }

    /// <summary>
    /// Hash de uma string.
    /// </summary>
    /// <param name="input">A string a ser hash.</param>
    /// <returns>O código hash.</returns>
    private int HashString(T input)
    {
        return input.GetHashCode();
    }

    /// <summary>
    /// Calcula o hash combinado a partir dos hashes primário e secundário.
    /// </summary>
    /// <param name="primaryHash">O hash primário.</param>
    /// <param name="secondaryHash">O hash secundário.</param>
    /// <param name="i">O índice.</param>
    /// <returns>O hash combinado.</returns>
    private int ComputeHash(int primaryHash, int secondaryHash, int i)
    {
        int resultingHash = (primaryHash + (i * secondaryHash)) % this._hashBits.Count;
        return Math.Abs(resultingHash);
    }

    /// <summary>
    /// Conta o número de bits verdadeiros no filtro de Bloom.
    /// </summary>
    /// <returns>O número de bits verdadeiros.</returns>
    private int TrueBits()
    {
        int count = 0;
        for (int i = 0; i < this._hashBits.Count; i++)
        {
            if (this._hashBits[i])
            {
                count++;
            }
        }
        return count;
    }
}
