## 关于函数的this的一个问题
假如有以下代码
```javascript
    function func1(arg) {
        console.log(arg.name)
        console.log(this.name)
    }

    let arg1 = {
        name: 'arg1'
    }

    func1(arg1) //输出：arg1 undefined
    func1.call(arg1) //报错：Uncaught TypeError TypeError: Cannot read properties of undefined (reading 'name')
```
分析：  
- 若直接`func1()`, 则`this`为全局对象(没有`name`属性,输出`undefined`)，`arg`为`arg1`(`name`属性为'`arg1`')  
- 若使用`func1.call()`, 则`call`的第一个参数永远是调用该函数的对象(即`this`), 且不会出现在该函数的形参中.  
  即：`func1.call(obj, arg1, arg2, arg3)`等同于`func1(arg1, arg2, arg3)`且`this`指向`obj1`  
    
  于是，`func1.call(arg1)`就相当于`func1()`且`this`为`arg1`,于是`arg`形参为空, 没有`name`属性，故报错
