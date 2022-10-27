(C-b 被重新映射为 C-x)  
1. 分屏与窗口  
	-	分屏：(更改了映射：C-b -> C-x, " -> i, % -> u)  
		C-x i: Horizontal  
		C-x u: Vertical
	-	在分屏间移动：(更改了映射)  
		Alt + hjkl
	-	关闭分屏：C-d
	-	新建窗口：C-x c
	-	在窗口间切换：C-x p、C-x n  
		或直接切到某一窗口：C-x <number>
2. 会话相关    
	-	脱离当前客户会话（后台运行）：C-x d  
		（如果有多个客户，可用C-x D选择要脱离的客户）
	-	查看所有会话：  
		tmux ls  
	-	连接某个会话：
		tmux attach -t <number>
	-	创建新的会话并命名：  
		tmux new -s <name>
3.	更多
	-	C-x z:make a pane go full screen. Hit C-b z again to shrink it back to its previous size
	-	C-x C-<arrow key>: Resize pane in direction of <arrow key>
	-	C-b ,: Rename the current window
4. resources
	-	[Tmux Cheat Sheet](https://tmuxcheatsheet.com/)
		
