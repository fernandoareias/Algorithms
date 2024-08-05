namespace Algorithm;

public class VectorClock
{
    private Dictionary<string, int> _clock;

    public VectorClock()
    {
        _clock = new Dictionary<string, int>();
    }

    // Incrementa o contador para o nó especificado
    public void Increment(string nodeId)
    {
        if (_clock.ContainsKey(nodeId))
        {
            _clock[nodeId]++;
        }
        else
        {
            _clock[nodeId] = 1;
        }
    }

    // Atualiza o relógio vetorial com outro relógio vetorial
    public void Update(VectorClock other)
    {
        foreach (var entry in other._clock)
        {
            if (_clock.ContainsKey(entry.Key))
            {
                _clock[entry.Key] = Math.Max(_clock[entry.Key], entry.Value);
            }
            else
            {
                _clock[entry.Key] = entry.Value;
            }
        }
    }

    // Verifica se este relógio vetorial é menor que outro relógio vetorial
    public bool IsLessThan(VectorClock other)
    {
        foreach (var entry in _clock)
        {
            if (entry.Value > other._clock.GetValueOrDefault(entry.Key, 0))
            {
                return false;
            }
        }
        return _clock.Keys.Count < other._clock.Keys.Count;
    }

    // Verifica se este relógio vetorial é igual a outro relógio vetorial
    public bool IsEqual(VectorClock other)
    {
        return _clock.OrderBy(kv => kv.Key).SequenceEqual(other._clock.OrderBy(kv => kv.Key));
    }

    // Obtém o valor do relógio para um nó específico
    public int GetValue(string nodeId)
    {
        return _clock.GetValueOrDefault(nodeId, 0);
    }

    // Representação do relógio vetorial como string
    public override string ToString()
    {
        return string.Join(", ", _clock.Select(kv => $"{kv.Key}: {kv.Value}"));
    }
}
