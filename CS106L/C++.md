-	**链表的Push操作：不用Sentinel也能让代码优雅的方法**  
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
	**实际上，不用Sentinel也可以实现上述效果：**  
	```c++
	List** temp= head;    //head是List*类型的指针，初始值为nullptr
	while (*temp != nullptr) {
	  *temp = (*temp) -> next;
	}
	*temp = new List();
	DoSomething(*temp);
	```
	**这里有一点令人疑惑**：在即将执行new语句时，\*temp为nullptr，把刚刚new来的List\*赋给nullptr不会出问题吗？  
	实际上，\*temp是一个List\*变量，它的值为nullptr，new语句之后就把它的值改成了一个指向一块刚开辟的内存的指针。
-	一些关键字是否需要在声明和实现中都书写的问题**
	| 声明需要，实现不需要 | 声明需要， 实现也需要 |
	| -------------------- | --------------------- |
	| friend | const |
	| explicit | |
-	**Why should the copy constructor accept its parameter by reference in C++?**  
	Because if it's not by reference, it's by value. To do that you make a copy, and to do that you call the copy constructor. But to do that, we need to make a new value, so we call the copy constructor, and so on...

	(You would have infinite recursion because "to make a copy, you need to make a copy".)
	
