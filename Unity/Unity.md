## Some Attributes
- \[Serializable\]   
  make a struct or class to be shown on the inspector
- \[SerialiazeField\]  
  similar to above, but is used for a private
- \[HideInspector\]  
   prevent the Inspector
 from showing the property, even if it is public.
- \[Header("some text")\]  
  show a header above on the inspector
- \[Multiline\]  
  when applied to a string field, we can write multilines other than just one single line on the inspector 
- \[TextArea\]  
  similar to the above, but will give you a textbox other than just a thin bar
- \[Range(lb, ub)\]  
  when applied to the health (a float value), for example, will limit the range of it to \[lb, ub\]
- \[Tooltip("tip text")\]  
  show the tip text when your cursor stay on the field on the inspector  
- \[HelpURL("Some URL")\] 
  change the help URL to your customed URL
- \[DisallowMultipleComponent\]  
  applied to the head of the class, will prevent you from add more than one of this script as a component on a game object 
- \[RequireComponent(typeof(someType))\]  
   applied to the head of the class, will prevent you from removing the component typeof "sometype" from a gameobject, if it don't have such a component, it will add one automatically
- \[ExecuteInEiditMode\]  
  applied to the head of the class, will execute the script in edit mode(not in playing mode). For example, when used for the camera controller(which is used for following the player), your camera will follow your player even in edit mode when you drag your player
- \[UnityEditor.MenuItem("some Path")\]  
  when used for a method, it will execute the method when you click it and it will be shown on the customed path of the menu bar on the top of the screen
- \[System.Obsolete("some text")\]
    **it's a predefined attribute by C#** [see here](https://www.cnblogs.com/hans_gis/archive/2011/11/19/2255592.html)
## 如何在不继承Monobehaviuor的类中使用协同？  
	首先，在这个类中正常编写协同程序，然后使用一个继承了Monobehaviuor的类来调用这个协同。  
	如： SceneController.instance.StartCoroutine(YourCoroutine(args));  
	[原文链接](https://answers.unity.com/questions/161084/coroutine-without-monobehaviour.html)

## 关于角色移动(rb.addForce()、transform.Translate()等)  
  [StackExchange链接](https://gamedev.stackexchange.com/questions/169678/is-rigidbody-needed-and-what-move-function-to-use-in-2d-games), [demo链接](https://philipptheprogrammer.itch.io/unity-tutorial-how-to-move-your-player), demo源码：见resources文件夹

  |                 方法                 |                   特性/优点                    |               缺点               |                              备注                              |
  | :----------------------------------: | :--------------------------------------------: | :------------------------------: | :------------------------------------------------------------: |
  |   `transform.translate = position`   |                精准的即时的位移                |         易发生"卡墙"Bug          |   一般不要用，但可以用于飞行射击游戏里的飞机、一些魔法特效等   |
  |        `transform.Translate`         |               同上，但考虑了旋转               |               同上               | 同上, 但由于有旋转的影响，应该可以用于一些特殊的游戏操作机制中 |
  |      `rigidbody.MovePosition()`      |   和上面的相比，考虑了碰撞，不易出“卡墙”Bug    | 每次调用后都会把物体的速度设为0  |   建议不要在每一帧都调用，否则会使外力对物体的影响老是被清零   |
  |     `rigidbody.velocity = speed`     | 可以使物体的速度发生即时的变化, 可用于角色跳跃 | 和上一个差不多，会改掉原有的速度 |     这个不好，建议用下一个来替代(velocity += acceleration)     |
  | `rigidbody.velocity += acceleration` |                      同上                      |           没有明显缺点           |                     这个挺好，可以优先考虑                     |
  |        `rigidbody.AddForce()`        |                最真实的物理效果                |       可能会不好控制，难说       |                            能用尽用                            |
## 关于父子物体transform的计算问题
首先，在`Unity`物体属性面板中显示的`Position`、`Rotation`、`Scale`均为`localPosition`、`localRotation`、`localScale`.(没有`parent`的物体以世界为`parent`)
假设有`Father`和`Son`两个物体(各自独立，不为父子关系).  
```
注意：以下讨论的前提是所有物体的Rotation均为0且始终不变，否则结果会不一样
```
初始时，`Father`的坐标为$(Ax, Ay , Az)$, `Scale`为$(Am, An, At)$; `Son`的坐标为$(ax, ay , az)$, `Scale`为$(am, an, at)$.  
现在，在`hierarchy`中，把`Son`设置为`Father`的子物体, 则:  
- 父、子物体的世界坐标与世界缩放均不变
- 父物体的世界坐标与世界缩放均不变
- 子物体的`localScale`变为$(\frac{am}{Am}, \frac{an}{An}, \frac{at}{At})$
- 子物体的`localPosition`变为$(\frac{ax-Ax}{Am}, \frac{ay-Ay}{An}, \frac{az-Az}{At})$  
  
然后  
1. 改变父物体的`Position`和`Scale`, 则：  
   - 子物体的`localPosition`和`localScale`均不变
   - 子物体的世界坐标变化的**大小**与父物体的世界坐标的变化的**大小**相同
   - 子物体的世界缩放(`lossyScale`)与父物体的世界缩放的变化的**比例**相同，但大小不一定相同(如:父物体由(1, 2, 3)变为(2, 4, 3), 则子物体(由(1, 1, 1)变为(2, 2, 1)))  
2. 或者，改变子物体的`localScale`和`localPosition`  
   则子物体的`worldPosition`和`worldScale`的**变化值**为`localScale`和`localPosition`的**变化值**乘以父物体的`Scale`:
   - 若子物体的`localScale`由(s1, s2, s3)变为(s4, s5, s6), 而父物体的`Scale`为(S1, S2, S3)  
     则子物体的`lossyScale`的**变化值**为$(s4 - s1) \cdot S1$、 $(s5 - s2) \cdot S2$、 $(s6 - s3) \cdot S3$
   - 子物体的`position`变化类似。

## 杂七杂八  
- FixedUpdate functions and suspended Coroutines with WaitForSeconds are not called when timeScale is set to zero.
