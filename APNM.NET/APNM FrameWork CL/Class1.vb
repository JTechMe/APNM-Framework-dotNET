Imports System.IO

Public Class Class1

    Private mIcons As New Hashtable
    Private mRootPath As String = Environment.CurrentDirectory + "\AppProjects"
    Public projectAPNM As String = Environment.CurrentDirectory + "\AppProjects\AppProject1"
    Public ProjectDIR As String
    Public ProjName As String
    Public APNMName As String
    Public ProjectVersion
    Public INTERNET_ACCESS As String
    Public IconLoca As String
    'Public IconFile As Icon
    Public indexFile As String
    Public cz182 As String

    Property RootPath() As String
        Get
            Return mRootPath
        End Get
        Set(ByVal value As String)
            mRootPath = value
        End Set
    End Property

    Public Sub WebApp()

    End Sub

    Public Sub PluginBrowser()

    End Sub
End Class
