'copyright(c) 2016 Josiah Horton
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Module AppExstensionModule

    Dim mIcons As New Hashtable
    Dim mRootPath As String = Environment.CurrentDirectory + "\AppProjects"
    Dim ExtesionsDIR As String
    Dim projectAPNM As String = Environment.CurrentDirectory + "\AppProjects\AppProject1"
    Dim ProjectDIR As String
    Dim ProjName As String
    Dim APNMName As String
    Dim ProjectVersion
    Dim INTERNET_ACCESS As String
    Dim IconLoca As String
    Dim IconFile As Icon
    Dim indexFile As String
    Dim SelectedRoot As String
    Dim AppForm As New Form
    Dim AppSize As System.Drawing.Size
    Dim IndexURL As String
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

    'Public Sub ExtensionConfig()

    'End Sub
End Module
