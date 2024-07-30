using System;
using Xunit;
using Algorithm;

namespace Algorithm.Tests
{
    public class TrieTests
    {
        [Fact]
        public void InsertWordShouldBeSearchable()
        {
            
            var trie = new Trie();
            
            trie.Insert("hello");
            
            Assert.True(trie.Search("hello"));
        }

        [Fact]
        public void SearchNonExistentWordShouldReturnFalse()
        {
            
            var trie = new Trie();

            
            trie.Insert("hello");

            
            Assert.False(trie.Search("world"));
        }

        [Fact]
        public void StartsWithValidPrefixShouldReturnTrue()
        {
            
            var trie = new Trie();

            
            trie.Insert("hello");

            
            Assert.True(trie.StartsWith("hel"));
        }

        [Fact]
        public void StartsWithInvalidPrefixShouldReturnFalse()
        {
            
            var trie = new Trie();

            
            trie.Insert("hello");

            
            Assert.False(trie.StartsWith("hey"));
        }

        [Fact]
        public void RemoveExistingWordShouldNotBeSearchable()
        {
            
            var trie = new Trie();

            
            trie.Insert("hello");
            trie.Remove("hello");

            
            Assert.False(trie.Search("hello"));
        }

        [Fact]
        public void RemovePartialWordShouldNotAffectOtherWords()
        {
            
            var trie = new Trie();

            
            trie.Insert("hello");
            trie.Insert("helium");
            trie.Remove("helium");

            
            Assert.True(trie.Search("hello"));
            Assert.False(trie.Search("helium"));
        }

        [Fact]
        public void SearchPrefixThatIsAWordShouldReturnTrue()
        {
            
            var trie = new Trie();

            
            trie.Insert("app");
            trie.Insert("apple");

            
            Assert.True(trie.Search("app"));
            Assert.True(trie.Search("apple"));
        }

        [Fact]
        public void RemovePrefixShouldNotAffectOtherWords()
        {
            
            var trie = new Trie();

            
            trie.Insert("app");
            trie.Insert("apple");
            trie.Remove("app");

            
            Assert.False(trie.Search("app"));
            Assert.True(trie.Search("apple"));
        }
    }
}
