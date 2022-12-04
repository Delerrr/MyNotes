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
* 关于寄存器
	- 寄存器介绍  
    
    - | 寄存器名称 | 简介 |
	| :---: | :---: |
	| "" | 无名寄存器，永远存储上一次的任何和寄存器有关的操作，如"c", "x", "s", "y" 等 |
	| "0 | 存储最近一次yank操作的内容 |
	| "1 ~ "9 | 存储大于等于一行的delete或change操作的内容，"1 存储最近一次该操作，"2是上一次的，以此类推 |
	| "- | 存储最近的小于一行的change或delete操作|
	| "a ~ "z, "A ~ "Z | 仅在用户特别指定它们时才会用到。注：Specify them as lowercase letters to replace their previous contents or as uppercase letters to append to their previous contents.  When the '>' flag is present in 'cpoptions' then a line break is inserted before the appended text.|
	| ". | 存储上一次insert操作的内容 |
	| ": | 存储上一次的command内容。Tips:在命令行模式下键入 @: 会执行上一次命令 |
	| "% | 存储当前文件名(**无路径**)) |
	| "# | 交替文件寄存器 "# 存储着当前 Vim 窗口（Window）的交替文件名(**包含路径**)。交替文件（alternate file）是指 Buffer 中的上一个文件，可通过 Ctrl+^ 来切换交替文件与当前文件。|
	| "_ | 黑洞寄存器。 When writing to this register, nothing happens.  This can be used to delete text without affecting the normal registers.  When reading from this register, nothing is returned. |
	| "= | 表达式寄存器，用于计算vim脚本的返回值。在normal模式下键入 "= 后光标会移入命令行，在此键入表达式后按回车，计算结果会存入该寄存器和无名寄存器。这在我们调试 Vim 脚本时非常有用，比如调用一个函数看它是否有正确的返回值。Tips: 可视为vim自带的计算器 | 
	| "*, "+, "~ | 选择和拖放寄存器。这三个寄存器的行为是和 GUI 相关的。 "* 和 "+ 在 Mac 和 Windows 中，都是指系统剪切板（clipboard）。 在 X11 系统中（绝大多数带有桌面环境的 Linux 发行版），二者是有区别的： "\* 指 X11 中的 PRIMARY 选区，即鼠标选中区域。在桌面系统中可按鼠标中键粘贴。 "+ 指 X11 中的 CLIPBOARD 选区，即系统剪切板。在桌面系统中可按 Ctrl+V 粘贴。 有文本拖拽到 Vim 时，被拖拽的文本被存储在 "~ 中。Vim 默认的行为是将 "~ 中内容插入到光标所在位置。|
	| "/ |  搜索寄存器。用于存储上一次搜索操作的内容 |
	* 随手记
	- 在光标前插入；一个小技巧：按8，再按i，进入插入模式，输入=， 按esc进入命令模式，就会出现8个=。 这在插入分割线时非常有用，如30i+\<esc>就插入了36个+组成的分割线。
	- marks   
		- marks 显示所有标记。   
		- :delmarks a b – 删除标记a和b。  
		- :delmarks a-c – 删除标记a、b和c。  
		- :delmarks a c-f – 删除标记a、c、d、e、f。  
		- :delmarks! – 删除当前缓冲区的所有标记。  
	- n%: 到文件n%的位置。  
	- n|: 把光标移到递n列上。  
	- nG: 到文件第n行。
	- 在inert / command 模式下的粘贴快捷键: \<C-R> [reg_name]  
		如：\<C-R>" 会粘贴系统剪切板的内容

