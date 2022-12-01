* buffer操作 [reference link](https://dev.to/iggredible/using-buffers-windows-and-tabs-efficiently-in-vim-56jc)
    * :ls 列出所有buffer
    * :bd N 删除序号为N的buffer
    * :bd filename 删除名字为filename的buffer
    * :bp 跳到下一个buffer
    * :bn 跳到上一个buffer
    * :bN 跳到序号为N的buffer, 如：b3
    * :sbN 新建分屏，并在新分屏中打开序号为N的buffer
    * :b filename 跳到名字为filename的buffer     
    * Jump between your last 'position' with \<Ctrl-O\> and \<Ctrl-i\>. This is not buffer specific, but it works.   
    * \<Ctrl-^\> Toggle between previous file  
* tab  
    * \<Ctrl-w\>T  
      open a buffer in a new tab page removing it from the split
    * gt   
      move right to another tab 
    * gT  
      move left to another tab 
    * \<Ctrl-^\> Toggle between previous file, also works with tabs
    * :tabnew [++opt选项] ［＋cmd］ 文件  
      建立对指定文件新的tab
    * :tabc  
      关闭当前的tab
    * :tabo   
      关闭所有其他的tab
    * :tabs  
      查看所有打开的tab
    * :tabp   
      前一个
    * :tabn   
      后一个
    * :tab ball  
      display all buffers in tabs
    * :tab sbN   
      在新table中打开序号为N的buffer
* t 与 f (**t**ill and **f**ind) 
  - **fx** jumps to the next **x** on the line  
  - **tx** jumps to the character just before the next **x** on the line
  - You can use **Fx** and **Tx** to reach the previous **x**  
  - You can use **2fx** to jump to the second **
  - **;**	Repeat latest f, t, F or T \[count\] times.
  - **,** opposite position from **;**
x** on the line
  - **useful tips**  
    - **cT=** will change every thing before the equation sign on the line 
    - **ct)** will change all parameters between the **)** and the cursor   
    btw, **ci(** is more usefull when all parameters are needed to be changed
* 随手记
	- 在光标前插入；一个小技巧：按8，再按i，进入插入模式，输入=， 按esc进入命令模式，就会出现8个=。 这在插入分割线时非常有用，如30i+<esc>就插入了36个+组成的分割线。
	- marks   
		- marks 显示所有标记。   
		   - :delmarks a b – 删除标记a和b。  
		  - :delmarks a-c – 删除标记a、b和c。  
		  - :delmarks a c-f – 删除标记a、c、d、e、f。  
		  - :delmarks! – 删除当前缓冲区的所有标记。  
	- n%: 到文件n%的位置。  
	- n|: 把光标移到递n列上。  
	- nG: 到文件第n行。
