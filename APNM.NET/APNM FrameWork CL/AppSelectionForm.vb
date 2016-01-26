'copyright(c) 2016 Josiah Horton
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class AppSelectionForm

    'Dim directories() As String = Directory.GetDirectories("C:\")
    Dim directories() As String = Directory.GetDirectories(Environment.CurrentDirectory + "\AppProjects")
    Shared AppDirectories() As String = Directory.GetDirectories(Environment.CurrentDirectory + "\AppProjects")
    'Dim files() As String = Directory.GetFiles("C:\", "*.dll")
    Dim files() As String = Directory.GetFiles(Environment.CurrentDirectory + "\AppProjects", "*.apnm")
    Dim APNMFileType
    Shared AppPath As String
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

    Public Sub DirSearch(ByVal sDir As String)
        Dim d As String
        Dim f As String

        Try
            For Each d In Directory.GetDirectories(sDir)
                'For Each f In Directory.GetFiles(d, txtFile.Text)
                For Each f In Directory.GetFiles(d, APNMFileType.Text)
                    'lstFilesFound.Items.Add(f)
                    ListView1.Items.Add(f)
                Next
                DirSearch(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
    End Sub

    Public Sub AppSelectionTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As String
        Dim f As String

        Try
            For Each d In Directory.GetDirectories(Environment.CurrentDirectory + "\AppProjects")
                'For Each f In Directory.GetFiles(d, txtFile.Text)
                For Each f In Directory.GetFiles(d, APNMFileType.Text)
                    'lstFilesFound.Items.Add(f)
                    ListView1.Items.Add(f).ToolTipText = APNMFileType
                Next
                DirSearch(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Private Sub ListView1_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged

    End Sub

    Public Sub OpenSelectedApp()
        'AppBuildTester.FasterBrowser1.Navigate(ProjectDIR + "/" + indexFile)
        'AppBuildTester.FasterBrowser1.Navigate(cz182 + "/index.html")
        'AppBuildTester.Text = ProjName + " - AppBuildTester"
        'AppBuildTester.Visible = True

        'Dim InForm As New Form
        ''InForm.Size.Width.Equals(649)
        ''InForm.Size.Width.Equals(570)
        'InForm.Size.Equals(649, 570)
        'InForm.Text = ProjName
        ''Dim NavigationBar As New AppToolStrip
        ''NavigationBar.Dock = DockStyle.Top
        ''InForm.Contains(NavigationBar)
        ''Dim WBrowser As New WebBrowser
        ''WBrowser.ScriptErrorsSuppressed = True
        'IndexURL = SelectedRoot + "\" + indexFile
        ''WBrowser.Url = New Uri(IndexURL)
        ''WBrowser.Dock = DockStyle.Fill
        ''InForm.Contains(WBrowser)
        'Dim AppContents As New AppWBandN
        'AppContents.WebBrowser1.Url = New Uri(IndexURL)
        'InForm.Contains(AppContents)
        'geticon()
        'InForm.Icon = IconFile
        'InForm.Visible = True

        Dim InForm As New WebAppForm
        'InForm.Size.Width.Equals(649)
        'InForm.Size.Width.Equals(570)
        'InForm.Size.Equals(649, 570)
        InForm.Text = ProjName
        'Dim NavigationBar As New AppToolStrip
        'NavigationBar.Dock = DockStyle.Top
        'InForm.Contains(NavigationBar)
        'Dim WBrowser As New WebBrowser
        'WBrowser.ScriptErrorsSuppressed = True
        IndexURL = SelectedRoot + "\" + indexFile
        'WBrowser.Url = New Uri(IndexURL)
        'WBrowser.Dock = DockStyle.Fill
        'InForm.Contains(WBrowser)
        'Dim AppContents As New AppWBandN
        'AppContents.WebBrowser1.Url = New Uri(IndexURL)
        InForm.WebBrowser1.Url = New Uri(IndexURL)
        'InForm.Contains(AppContents)
        'geticon()
        InForm.Icon = IconFile
        InForm.Visible = True

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'FolderBrowserDialog1.SelectedPath = ListView1.SelectedItems.ToString - "project.apnm"
        'FolderBrowserDialog1.RootFolder = Environment.CurrentDirectory + "\AppProjects"
        'FolderBrowserDialog1.ShowDialog()
        ProjectDIR = FolderBrowserDialog1.SelectedPath
        SelectedRoot = FolderBrowserDialog1.SelectedPath
        'OpenFileDialog1.FileName = FolderBrowserDialog1.SelectedPath + "/project.apnm"
        OpenFileDialog1.FileName = ListView1.SelectedItems.ToString
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
        'Me.Text = ReadLine(5, allLines) + " - AppBuilder"
        ProjName = ReadLine(5, allLines)
        APNMName = ReadLine(6, allLines)
        ProjectVersion = ReadLine(7, allLines)
        INTERNET_ACCESS = ReadLine(12, allLines)
        IconLoca = ReadLine(26, allLines)
        indexFile = ReadLine(30, allLines)

        OpenSelectedApp()
    End Sub
End Class