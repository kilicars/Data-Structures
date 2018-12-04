public class LRUCache {
    
    public class DoubleListNode{
        public int key;
        public int val;
        public DoubleListNode prev;
        public DoubleListNode next;
        public DoubleListNode(int key, int val){
            this.key = key;
            this.val = val;
        }
    }

    int capacity;
    int count;
    Dictionary<int, DoubleListNode> dict;
    DoubleListNode head;
    DoubleListNode tail;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.count = 0;
        dict = new Dictionary<int, DoubleListNode>();
        //fake and head tail to be safe
        head = new DoubleListNode(0,0);
        tail = new DoubleListNode(0,0);
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) {
        if (dict.ContainsKey(key)){
            if (tail.prev.key != key){
                //remove it from current place and add to the end (before the tail)
                UpdateUsedNode(dict[key]);               
            }
            return dict[key].val;
        }
        else{
            return -1;
        }
    }
    
    public void Put(int key, int value) {       
        //update value and add to the end of the list if exists
        if (dict.ContainsKey(key)){
            UpdateCache(key, value);
        }
        //insert the new key
        else{
            //increment the size
            count++;
            //if size is over capacity then remove the first node (after the head) from the list        
            if (count > capacity){
                RemoveFromCache(head.next);
            } 
            AddToCache(key,value);         
        }       
    }
    
    private void AddToCache(int key, int value){            
        //add to the end of the list       
        var newNode = new DoubleListNode(key, value);        
        AddToEnd(newNode);        
        //add to the dictionary        
        dict.Add(key, newNode);          
    }
    
    private void UpdateCache(int key, int value){           
        dict[key].val = value;       
        UpdateUsedNode(dict[key]);
    }
    
    private void RemoveFromCache(DoubleListNode node){                
        RemoveNode(node);        
        dict.Remove(node.key);        
        count--;        
    }
    
    private void AddToEnd(DoubleListNode node){                   
        var beforeTail = tail.prev;        
        node.prev = beforeTail;        
        beforeTail.next = node;        
        tail.prev = node;       
        node.next = tail;        
    }
    
    private void RemoveNode(DoubleListNode node){        
        var before = node.prev;
        before.next = node.next;
        node.next.prev = before;    
    }
    
    private void UpdateUsedNode(DoubleListNode node){                    
        RemoveNode(node);       
        AddToEnd(node);
    }    
}
