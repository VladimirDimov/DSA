﻿namespace PrefixTrie.TrieData
{
    using System.Collections.Generic;

    public interface ITrie
    {
        /// <summary>
        /// Add a word to the Trie.
        /// </summary>
        void AddWord(string word);

        /// <summary>
        /// Remove word from the Trie.
        /// </summary>
        void RemoveWord(string word);

        /// <summary>
        /// Get all words in the Trie.
        /// </summary>
        ICollection<string> GetWords();

        /// <summary>
        /// Get words for given prefix.
        /// </summary>
        ICollection<string> GetWords(string prefix);

        /// <summary>
        /// Returns true or false if the word is present in the Trie.
        /// </summary>
        bool HasWord(string word);

        /// <summary>
        /// Returns the count for the word in the Trie.
        /// </summary>
        int WordCount(string word);

        /// <summary>
        /// Get longest words from the Trie.
        /// </summary>
        ICollection<string> GetLongestWords();

        /// <summary>
        /// Clear all words from the Trie.
        /// </summary>
        void Clear();
    }
}
