'copyright(c) 2016 Josiah Horton
Imports System.IO

Public Class WebAppForm

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

    Shared Sub WebAppForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AxWebBrowser1.Silent = True

        'FolderBrowserDialog1.RootFolder = APNMThings.AppsRoot
        'FolderBrowserDialog1.ShowDialog()

        ''AppBuildTester.FasterBrowser1.Navigate(ProjectDIR + "/" + indexFile)
        'AxWebBrowser1.Navigate(cz182 + "/index.html")
        'Text = ProjName + " - AppBuildTester"
        'Visible = True

    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Public Sub AppFolderBrowse()

        'FolderBrowserDialog1.RootFolder = Environment.CurrentDirectory + "\AppProjects"
        FolderBrowserDialog1.RootFolder = APNMThings.AppRoot
        FolderBrowserDialog1.ShowDialog()
        ProjectDIR = FolderBrowserDialog1.SelectedPath
        cz182 = FolderBrowserDialog1.SelectedPath
        OpenFileDialog1.FileName = FolderBrowserDialog1.SelectedPath + "/project.apnm"
        OpenFileDialog1.OpenFile()
        'FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        'ToolStripButton1.Enabled = True
        'All this does is set up the OpenFileDialog for the .apnm file type
        'OpenFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\AppProjects"
        'OpenFileDialog1.DefaultExt = "apnm"
        'OpenFileDialog1.FileName = ""
        'OpenFileDialog1.Filter = "Project Files (*.apnm)|*.apnm|All Files (*.*)|*.*"
        'OpenFileDialog1.Multiselect = False
        'OpenFileDialog1.ShowDialog()
        'This changes the mRootPath string to the root path of the selected project.apnm file (will probably be replaced)
        'mRootPath = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        projectAPNM = OpenFileDialog1.FileName
        'Dim APNMText As String = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        Dim reader As New System.IO.StreamReader(projectAPNM)
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Me.Text = ReadLine(5, allLines) + " - AppBuilder"
        ProjName = ReadLine(5, allLines)
        APNMName = ReadLine(6, allLines)
        ProjectVersion = ReadLine(7, allLines)
        INTERNET_ACCESS = ReadLine(12, allLines)
        IconLoca = ReadLine(26, allLines)
        indexFile = ReadLine(30, allLines)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If WebBrowser1.CanGoBack Then
            WebBrowser1.GoBack()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If WebBrowser1.CanGoForward Then
            WebBrowser1.GoForward()
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        TextBox1.Text = WebBrowser1.Url.ToString
    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        TextBox1.Text = WebBrowser1.Url.ToString
    End Sub
End Class