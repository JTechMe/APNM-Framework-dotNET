'copyright(c) 2016 Josiah Horton
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Module AppPluginModule

    'Dim FormText As String

    Public Sub OpenSelector()
        'Dim AppSelectionForm As New Form
        Dim AppPluginSelection As New AppSelectionTree
        AppPluginSelection.Button1.PerformClick()
        'AppSelectionForm.Visible = True
        'AppSelectionTree.OpenSelectedApp()
    End Sub

    Public Sub OpenSelectionForm()
        Dim SelectionForm As New AppSelectionForm
        SelectionForm.Visible = True
    End Sub
End Module
