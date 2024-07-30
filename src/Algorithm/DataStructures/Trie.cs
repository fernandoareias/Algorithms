namespace Algorithm
{
    public class TrieNode
    {
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public TrieNode[] Children { get; set; }

        public TrieNode(char value)
        {
            Value = value;
            IsEndOfWord = false;
            Children = new TrieNode[26]; // Para caracteres 'a' a 'z'
        }
    }

    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode(' ');
        }

        /// <summary>
        /// O(n)
        /// Insere uma palavra na trie.
        /// </summary>
        /// <param name="word">A palavra a ser inserida.</param>
        public void Insert(string word)
        {
            var current = root;
            foreach (var c in word)
            {
                int index = c - 'a';
                if (current.Children[index] == null)
                {
                    current.Children[index] = new TrieNode(c);
                }

                current = current.Children[index];
            }

            current.IsEndOfWord = true;
        }

        /// <summary>
        /// O(n)
        /// Verifica se uma palavra está na trie.
        /// </summary>
        /// <param name="word">A palavra a ser verificada.</param>
        /// <returns>True se a palavra estiver na trie, caso contrário, False.</returns>
        public bool Search(string word)
        {
            var current = root;
            foreach (var c in word)
            {
                int index = c - 'a';
                if (current.Children[index] == null)
                {
                    return false;
                }

                current = current.Children[index];
            }

            return current.IsEndOfWord;
        }

        /// <summary>
        /// O(p)
        /// Verifica se existe alguma palavra na trie que começa com o prefixo dado.
        /// </summary>
        /// <param name="prefix">O prefixo a ser verificado.</param>
        /// <returns>True se existir uma palavra que começa com o prefixo, caso contrário, False.</returns>
        public bool StartsWith(string prefix)
        {
            var current = root;
            foreach (var c in prefix)
            {
                int index = c - 'a';
                if (current.Children[index] == null)
                {
                    return false;
                }

                current = current.Children[index];
            }

            return true;
        }

        /// <summary>
        /// O(n)
        /// Remove uma palavra da trie.
        /// </summary>
        /// <param name="word">A palavra a ser removida.</param>
        public void Remove(string word)
        {
            Remove(root, word, 0);
        }

        /// <summary>
        /// Remove recursivamente uma palavra da trie.
        /// </summary>
        /// <param name="current">O nó atual.</param>
        /// <param name="word">A palavra a ser removida.</param>
        /// <param name="index">O índice atual na palavra.</param>
        /// <returns>True se o nó atual deve ser removido, caso contrário, False.</returns>
        private bool Remove(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.IsEndOfWord)
                {
                    return false;
                }

                current.IsEndOfWord = false;
                return current.Children.All(child => child == null);
            }

            char c = word[index];
            int i = c - 'a';
            if (current.Children[i] == null)
            {
                return false;
            }

            bool shouldRemoveCurrentNode = Remove(current.Children[i], word, index + 1);

            if (shouldRemoveCurrentNode)
            {
                current.Children[i] = null;
                return current.Children.All(child => child == null) && !current.IsEndOfWord;
            }

            return false;
        }
    }
}
