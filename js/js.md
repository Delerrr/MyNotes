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
## 关于原型函数与实例函数的一个问题
先看以下代码
```javascript
class Obj {
    constructor(name, age) {
        this.name = name
        this.age = age
    }

    func() {
        console.log('I\'m an instance method.')
    }
}

Obj.prototype.func = function() {
    console.log('I\'m a prototype method')
}

var obj = new Obj('obj', 23)
obj.func() //输出：I'm a ptototype method.
```
输出结果说明实际调用的是原型方法，而理论上应该先调用实例方法，实例方法不存在再找原型方法，不是吗？  
实际上，上述声明的"实例方法"实际上就是原型方法。不信可以试一下：
```javascript
class Obj {
    constructor(name, age) {
        this.name = name
        this.age = age
    }

    func() {
        console.log('I\'m an instance method.')
    }
}

var obj = new Obj('obj', 23)
console.log(obj.func === obj.__proto__.func)  //输出：true
```
咦，原来这样真的是原型方法。那么怎样声明实例方法呢？看以下代码:
```javascript
class Obj {
    constructor(name, age) {
        this.name = name
        this.age = age
        this.func = function() {
            console.log('I\'m an instance method.')
        }
    }
}
```
破案！