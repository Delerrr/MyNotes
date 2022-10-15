- 链表的Push操作：不用Sentinel也能让代码优雅的方法	
  在链表的Push操作中，如果不使用哨兵节点，则需判断头结点是否为空，这样就多了一个判断特殊情的if分支，很不优雅。  
  如果使用Sentinel则不用单独考虑这种特殊情况：  
  ```c++
  List* temp = Sentinel;
  while (temp -> next != nullptr) {
      temp = temp -> next;
  }
  temp -> next = new List();
  DoSomething(temp -> next);
  ```
  **实际上，不用Sentinel也可以实现上效果：**  
  ```c++
  List\*\* temp= head;    //head是List\*类型的指针，初始值为nullptr
  while (\*temp != nullptr) {
      \*temp = (\*temp) -> next;
  }
  *temp = new List();
  DoSomething(*temp);
  ```
  **这里有一点令人疑惑**：在即将执行new语句时，\*temp为nullptr，把刚刚new来的List\*赋给nullptr不会出问题吗？  
  实际上，\*temp是一个List\*变量，它的值为nullptr，new语句之后就把它的值改成了一个指向一块刚开辟的内存的指针。
