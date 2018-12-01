class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool isWord;
    public TrieNode(){
        children = new Dictionary<char, TrieNode>();
        isWord = false;        
    }
}

public class Trie {

    TrieNode trie;

    public Trie() {
        trie = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        TrieNode t = trie;
        foreach (char c in word){
            if (!t.children.ContainsKey(c)){
                t.children.Add(c, new TrieNode());
            }
            t = t.children[c];
        }
        t.isWord = true;
        
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        TrieNode t = trie;
        foreach (char c in word){
            if (!t.children.ContainsKey(c)){
                return false;
            }
            t = t.children[c];
        }  
        return t.isWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        TrieNode t = trie;
        foreach (char c in prefix){
            if (!t.children.ContainsKey(c)){
                return false;
            }
            t = t.children[c];
        }  
        return true;        
    }
}
