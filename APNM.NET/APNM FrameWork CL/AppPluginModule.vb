Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Module AppPluginModule

    Public Sub OpenSelector()
        'Dim AppSelectionForm As New Form
        Dim AppPluginSelection As New AppSelectionTree
        AppPluginSelection.Button1.PerformClick()
        'AppSelectionForm.Visible = True
        'AppSelectionTree.OpenSelectedApp()
    End Sub
End Module
