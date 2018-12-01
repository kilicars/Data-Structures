public class MinStack {
    
    int min;
    struct Element{
        public int val;
        public int min;
        public Element(int v, int m){
            val = v;
            min = m;
        }
    }

    Stack<Element> stack ;

    public MinStack() {
        stack = new Stack<Element>();
        min = int.MaxValue;
        Console.WriteLine(min);
    }
    
    public void Push(int x) {
        min = Math.Min(min, x);
        stack.Push(new Element(x, min));
    }
    
    public void Pop() {            
        stack.Pop();         
        if (stack.Count == 0){
            min = int.MaxValue;
        }
        else{
            min = stack.Peek().min;
        }
    }
    
    public int Top() {
        return stack.Peek().val;
    }
    
    public int GetMin() {
        return stack.Peek().min;
    }
}
