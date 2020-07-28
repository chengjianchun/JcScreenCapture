; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "JcScreenCapture"
!define PRODUCT_VERSION "1.0.0"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\JcScreenCapture.exe"

; MUI 1.67 compatible ------
!include "MUI.nsh"
!include "nsProcess.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\JcScreenCapture.exe"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "JcScreenCapture_Setup_${PRODUCT_VERSION}.exe"
InstallDir "$PROGRAMFILES\JcScreenCapture"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "E:\Data\Projects\github\JcScreenCapture\JcScreenCapture\bin\Release\JcScreenCapture.exe"

  CreateShortCut "$INSTDIR\JcScreenCapture.lnk" "$INSTDIR\JcScreenCapture.exe"
SectionEnd

Section "MSI 3.1" SEC02 #NOTE should be installed before CRredist.msi
DetailPrint "..Installing MSI 3.1"
GetDLLVersion "$SYSDIR\msi.dll" $R0 $R1
IntOp $R2 $R0 / 0x00010000 ; $R2 now contains major version
IntOp $R3 $R0 & 0x0000FFFF ; $R3 now contains minor version
IntOp $R4 $R1 / 0x00010000 ; $R4 now contains release
IntOp $R5 $R1 & 0x0000FFFF ; $R5 now contains build
StrCpy $0 "$R2.$R3.$R4.$R5" ; $0 now contains string like "1.2.0.192"
${IF} $0 < "3.1"
;options
SetOutPath "$TEMP"
SetOverwrite on
;file work
File "E:\Data\Projects\github\JcScreenCapture\setup\WindowsInstaller-KB893803-v2-x86.exe"
ExecWait '$TEMP\WindowsInstaller-KB893803-v2-x86.exe /quiet /norestart' $0
DetailPrint "..MSI 3.1 exit code = '$0'"
Delete "$TEMP\WindowsInstaller-KB893803-v2-x86.exe"
${Else}
DetailPrint "..MSI 3.1 already installed !!"
${EndIf}
SectionEnd

Section "NET Framework 2.0" SEC03
;registry
ReadRegDWORD $0 HKLM 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727' Install
${If} $0 == ''
DetailPrint "..Installing NET Framework"
;options
SetOutPath "$TEMP"
SetOverwrite on
;file work
File "E:\Data\Projects\github\JcScreenCapture\setup\dotnetfx.exe"
ExecWait '$TEMP\dotnetfx.exe /q:a /c:$\"install /q$\"' $0
DetailPrint "..NET Framework 2.0 exit code = '$0'"
Delete "$TEMP\dotnetfx.exe"
${Else}
DetailPrint "..NET Framework 2.0 already installed !!"
${EndIf}
SectionEnd

Section "vcredist_x86" SEC04
;registry
ReadRegDWORD $0 HKLM 'SOFTWARE\Classes\Installer\Products\1D5E3C0FEDA1E123187686FED06E995A' Version
${If} $0 == ''
DetailPrint "..Installing vcredist_x86"
;options
SetOutPath "$TEMP"
SetOverwrite on
;file work
File "E:\Data\Projects\github\JcScreenCapture\setup\vcredist_x86.exe"
ExecWait '$TEMP\vcredist_x86.exe /q /norestart' $0
DetailPrint "..vcredist_x86 exit code = '$0'"
Delete "$TEMP\vcredist_x86.exe"
${Else}
DetailPrint "..vcredist_x86 already installed !!"
${EndIf}
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\JcScreenCapture.exe"
SectionEnd

Function .onInit
	nsProcess::_CloseProcess "JcScreenCapture.exe"
	nsProcess::_Unload
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully uninstalled."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Do you want to uninstall $(^Name) ?" IDYES +2
  Abort
	nsProcess::_CloseProcess "JcScreenCapture.exe"
	nsProcess::_Unload
FunctionEnd

Section Uninstall
	SetShellVarContext all
  Delete "$SMSTARTUP\JcScreenCapture.lnk"

  RMDir /r /REBOOTOK "$INSTDIR"

  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd