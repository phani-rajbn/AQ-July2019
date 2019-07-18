# AQ-July2019
Steps for placing the Assembly in GAC
Sign the Assembly->Project Properties->Signing->Click the check box of signing the Assembly and specify the SNK File.
Build the project
Open the Developer Command Prompt for Visual Studio as Administrator. 
Move to the Executing Directory of the DLL where the actual DLL is residing. 
gacutil -i DllName.dll
