ECHO OFF
CLS 
ECHO This file copies only CHANGED files in your source code folder into
ECHO the shared code folder. 
ECHO.
ECHO Note this CMD file must be customized to specify both your own working folder
ECHO and the destination sub folder in the \\SQWDARTD01\e\Code\ folder.
ECHO Press Ctrl+C to cancel, or 
PAUSE 

xcopy C:\Work\DDT_ToolBox\DDTToolbox\*.*  \\SQWDARTD01\e\Code\VB\DDTToolBox\*.* /d /s /y
explorer.exe  \\SQWDARTD01\e\Code\VB\DDTToolBox\

