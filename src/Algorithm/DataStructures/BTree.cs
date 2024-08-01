namespace Algorithm;

public class KeyValuePair<TKey, TValue> where TKey : IComparable<TKey>
{
    private KeyValuePair()
    {
    }

    public TKey Key { get; private set; }
    public TValue Value { get; private set; }

    public KeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}

public class BTreeNode<TKey, TValue> where TKey : IComparable<TKey>
{
    public List<KeyValuePair<TKey, TValue>> KeyValues { get; private set; } =  new List<KeyValuePair<TKey, TValue>>();
    public List<BTreeNode<TKey, TValue>> Children { get; private set; } = new List<BTreeNode<TKey, TValue>>();
    
    /// <summary>
    /// Indica se o nó é uma folha
    /// </summary>
    public bool IsLeaf { get; private set; }
    
    /// <summary>
    /// Grau mínimo do nó
    /// </summary>
    public int Degree { get; private set; }
    
    
    public BTreeNode(int degree, bool isLeaf)
    {
        Degree = degree;
        IsLeaf = isLeaf;
    }

    public void InsertNonFull(TKey key, TValue value)
    {
        // Indice para percorrer a lista de chaves
        int i = KeyValues.Count - 1;

        if (IsLeaf)
        {
            // Adiciona um espaço extra para o novo par chave-valor
            KeyValues.Add(null);

            // Move as chaves maiores para a direita
            while (i >= 0 && key.CompareTo(KeyValues[i].Key)  < 0)
            {
                KeyValues[i + 1] = KeyValues[i];
                i--;
            }
            
            // Adiciona o novo par chave-valor
            KeyValues[i + 1] = new KeyValuePair<TKey, TValue>(key, value); 
        }
        else
        {
            // Encontra o filho apropriado
            while (i >= 0 && key.CompareTo(KeyValues[i].Key) < 0) 
                i--;
            
            i++;
            // Verifica se o filho está cheio
            if (Children[i].KeyValues.Count == 2 * Degree - 1) 
            {
                SplitChild(i); // Divide o filho se necessário
                if (key.CompareTo(KeyValues[i].Key) > 0)
                    i++;
            }

            Children[i].InsertNonFull(key, value); 
        }
    }
    
    public void SplitChild(int index)
    {
        // Obtém o filho que será dividido
        var child = Children[index]; 
    
        var newChild = new BTreeNode<TKey, TValue>(child.Degree, child.IsLeaf);
    
        // Índice da chave mediana
        int medianIndex = Degree - 1; 

        // Move a chave mediana para este nó
        KeyValues.Insert(index, child.KeyValues[medianIndex]);

        // Move a segunda metade das chaves e filhos do filho para o novo filho
        newChild.KeyValues.AddRange(child.KeyValues.GetRange(medianIndex + 1, child.KeyValues.Count - medianIndex - 1));

        if (!child.IsLeaf)
        {
            newChild.Children.AddRange(child.Children.GetRange(medianIndex + 1, child.Children.Count - medianIndex - 1));
        }

        // Remove a segunda metade das chaves e filhos do filho
        // Certifique-se de que os intervalos são válidos antes de remover
        int keyValuesCountToRemove = child.KeyValues.Count - medianIndex - 1;
        if (keyValuesCountToRemove > 0)
        {
            child.KeyValues.RemoveRange(medianIndex, keyValuesCountToRemove);
        }

        int childrenCountToRemove = child.Children.Count - medianIndex - 1;
        if (childrenCountToRemove > 0)
        {
            child.Children.RemoveRange(medianIndex + 1, childrenCountToRemove);
        }

        // Insere o novo filho na lista de filhos
        Children.Insert(index + 1, newChild); 
    }

}


public class BTree<TKey, TValue> where TKey : IComparable<TKey>
{
    /// <summary>
    /// Nó raiz da B-Tree
    /// </summary>
    private BTreeNode<TKey, TValue> Root; 
    
    /// <summary>
    /// Grau mínimo da árvore
    /// </summary>
    private int Degree; 
    
    public BTree(int degree)
    {
        Degree = degree; 
        Root = new BTreeNode<TKey, TValue>(degree, true); // Cria o nó raiz como folha
    }
    
    public void Insert(TKey key, TValue value)
    {
        var root = Root;
        
        bool rootNodeIsFull = root.KeyValues.Count == 2 * Degree - 1;
        if (rootNodeIsFull) 
        {
            // Cria um novo nó raiz
            var newRoot = new BTreeNode<TKey, TValue>(Degree, false); 
            newRoot.Children.Add(root); 
            newRoot.SplitChild(0); 
            Root = newRoot; 
        }
        Root.InsertNonFull(key, value); // Insere a chave-valor no nó raiz
    }
    
    public TValue SearchWithRecursion(TKey key)
    {
        return SearchWithRecursion(Root, key); 
    }

    /// <summary>
    /// Busca recursivamente um valor associado a uma chave usando recursao.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    private TValue SearchWithRecursion(BTreeNode<TKey, TValue> node, TKey key)
    {
        int i = 0;
        while (i < node.KeyValues.Count && key.CompareTo(node.KeyValues[i].Key) > 0) // Encontra o índice da chave
            i++;

        if (i < node.KeyValues.Count && key.CompareTo(node.KeyValues[i].Key) == 0) // Verifica se a chave foi encontrada
            return node.KeyValues[i].Value;

        if (node.IsLeaf) // Se o nó é uma folha e a chave não foi encontrada
            throw new KeyNotFoundException("Chave não encontrada na árvore.");

        return SearchWithRecursion(node.Children[i], key); // Continua a busca no filho apropriado
    }
    
    /// <summary>
    /// Sem recursao
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public TValue Search(TKey key)
    {
        BTreeNode<TKey, TValue> node = Root;
    
        while (node != null)
        {
            int i = 0;
        
            // Encontra o índice da chave no nó atual
            while (i < node.KeyValues.Count && key.CompareTo(node.KeyValues[i].Key) > 0)
                i++;
        
            // Verifica se a chave foi encontrada
            if (i < node.KeyValues.Count && key.CompareTo(node.KeyValues[i].Key) == 0)
                return node.KeyValues[i].Value;
        
            // Se o nó é uma folha e a chave não foi encontrada
            if (node.IsLeaf)
                throw new KeyNotFoundException("Chave não encontrada na árvore.");
        
            node = node.Children[i];
        }
    
        throw new KeyNotFoundException("Chave não encontrada na árvore."); 
    }
}