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
## 杂七杂八  
- FixedUpdate functions and suspended Coroutines with WaitForSeconds are not called when timeScale is set to zero.