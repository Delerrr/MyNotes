##  关于Emmet ([网页链接](https://code.z01.com/emmet/))  
- 自增符号$与@的搭配使用：
	1. 负号"-": 倒序  
		缩写:  
		```html
		ul>li.item$@-*5
		```  
		展开后:  
		```html
		<ul>
			<li class="item5"></li>
			<li class="item4"></li>
			<li class="item3"></li>
			<li class="item2"></li>
			<li class="item1"></li>
		</ul>
		```
	2. @num: 从num开始计数  
		缩写:  
		```html
		ul>li.item$@3*5
		```
		展开后:
		```html
		<ul>
			<li class="item3"></li>
			<li class="item4"></li>
			<li class="item5"></li>
			<li class="item6"></li>
			<li class="item7"></li>
		</ul>
		```



