Design and implementation of a data structure for [Least Recently Used (LRU)](https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU) cache. 

It supports the following operations:

**Get(key)** - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.

**Put(key, value)** - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

Both operations are done in **O(1)** time complexity.


LRUCache object is instantiated and called as such:
 
 ```
 LRUCache obj = new LRUCache(capacity); 
 int param_1 = obj.Get(key);
 obj.Put(key,value);
 ```
 
 This is the solution for the [LeetCode problem 146 - LRU Cache](https://leetcode.com/problems/lru-cache/description/).
 
