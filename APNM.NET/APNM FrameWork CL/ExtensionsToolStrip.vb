'copyright(c) 2016 Josiah Horton
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class ExtensionsToolStrip

    Shared mIcons As New Hashtable
    Shared mRootPath As String = Environment.CurrentDirectory + "\AppProjects"
    Shared projectAPNM As String = Environment.CurrentDirectory + "\AppProjects\AppProject1"
    Shared ProjectDIR As String
    Shared ProjName As String
    Shared APNMName As String
    Shared ProjectVersion
    Shared INTERNET_ACCESS As String
    Shared IconLoca As String
    Shared IconFile As Icon
    Shared indexFile As String
    Shared SelectedRoot As String
    Shared AppForm As New Form
    Shared AppSize As System.Drawing.Size
    Shared IndexURL As String

    Private Sub ExtentionsToolStrip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
