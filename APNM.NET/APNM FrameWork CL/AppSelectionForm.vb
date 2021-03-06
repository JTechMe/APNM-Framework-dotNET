﻿'copyright(c) 2016 Josiah Horton
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
    'INTERNET_ACCESS string is discontinued as it has been replaced by a boolean.
    'Shared INTERNET_ACCESS As String
    Shared IconLoca As String
    Shared IconFile As Icon
    Shared indexFile As String
    Shared SelectedRoot As String
    Shared AppForm As New Form
    Shared AppSize As System.Drawing.Size
    Shared IndexURL As String
    'This is where things get complicated...
    Dim currLine As Integer
    Dim allLines As List(Of String) = New List(Of String)
    'Permission booleans
    Dim FRAMEWORK_USE As Boolean
    Dim INTERNET_ACCESS As Boolean
    Dim PROJECT_DIR As Boolean
    Dim LOCAL_FILES As Boolean
    Dim JG_SETTINGS As Boolean
    Dim APNM_SETTINGS As Boolean

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
        'Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()

        'Dim currLine As Integer
        currLine = 2

        'Dim s As String = "foo [123]=ro bar"
        'Dim i As Integer = s.IndexOf("[")
        'Dim f As String = s.Substring(i + 1, s.IndexOf("]", i + 1) - i - 1)

        'Me.Text = ReadLine(5, allLines) + " - AppBuilder"
        'ProjName = ReadLine(5, allLines)
        'APNMName = ReadLine(6, allLines)
        'ProjectVersion = ReadLine(7, allLines)
        'INTERNET_ACCESS = ReadLine(12, allLines)
        'IconLoca = ReadLine(26, allLines)
        'indexFile = ReadLine(30, allLines)

        'The CommentJumpper sub is in the Syntax Subs region and will utilize the other subs in
        'that region to pull the data out of the APNM file.
        CommentJumpper()

        OpenSelectedApp()
    End Sub

#Region "Syntax Subs"
    'This sub will check the current line of the doc for any comments and skip to the next line.
    Public Sub CommentJumpper()
        'isComment is a string that will be checked for any comment signs.
        Dim isComment As String
        'This will set the value of isComment to the same value of the current line in the doc.
        isComment = ReadLine(currLine, allLines)
        'This will search for the comment in the current line.
        If isComment.Contains("~") Then
            'This skips the comment line and sets the current line to the current line plus 1.
            currLine = currLine + 1
            'This repeats the sub.
            CommentJumpper()
        Else
            isComment = ReadLine(currLine, allLines)
            'This sets the project name to the project name in the APNM file.
            ProjName = isComment
            currLine = currLine + 1
            isComment = ReadLine(currLine, allLines)
            'This sets the package name (or APNMName) to the package identified in the APNM file.
            APNMName = isComment
            currLine = currLine + 1
            isComment = ReadLine(currLine, allLines)
            'This sets the project version to the version string in the APNM file.
            ProjectVersion = isComment
            currLine = currLine + 1

            'This starts the configHandler sub to start handling the config refferences.
            ConfigHandler()
            'This will set the value of isComment to the same value of the current line in the doc.
            isComment = ReadLine(currLine, allLines)
            'This will search for the comment in the current line.
            If isComment.Contains("~") Then
                'This skips the comment line and sets the current line to the current line plus 1.
                currLine = currLine + 1
                'This repeats the sub.
                CommentJumpper()
            Else
                'This starts the TagHandler to make sense of the tags in the APNM file.
                TagHandler()
                'This will set the value of isComment to the same value of the current line in the doc.
                isComment = ReadLine(currLine, allLines)
                'This will search for the comment in the current line.
                If isComment.Contains("~") Then
                    'This skips the comment line and sets the current line to the current line plus 1.
                    currLine = currLine + 1
                    'This repeats the sub.
                    CommentJumpper()
                Else
                    'TagHandler()

                End If
            End If
        End If
    End Sub

    'This sub will check for APNM config file calls and then runs the attached sub.
    Public Sub ConfigHandler()
        Dim isConfig As String
        isConfig = ReadLine(currLine, allLines)
        If isConfig.Contains("!") Then
            'Dim s As String = "foo [123]=ro bar"
            Dim i As Integer = isConfig.IndexOf("!")
            Dim configResult As String = isConfig.Substring(i + 1, isConfig.IndexOf("!", i + 1) - i - 1)
            'This checks to see if the config file is the permissions file.
            If configResult = "permissions" Then
                currLine = currLine + 1
                'This starts the PermHandler sub to set the boolean values of the permission variables.
                PermHandler()
            Else
                currLine = currLine + 1
            End If
        Else
            currLine = currLine + 1
        End If
    End Sub

    'This sub will set the values of the permission booleans from the APNM manifest.
    Public Sub PermHandler()
        Dim isPerm As String
        isPerm = ReadLine(currLine, allLines)
        If isPerm.Contains("+") Then
            If isPerm.Contains("FRAMEWORK_USE") Then
                FRAMEWORK_USE = True
                currLine = currLine + 1
                isPerm = ReadLine(currLine, allLines)
                PermHandler()
            Else
                If isPerm.Contains("INTERNET_ACCESS") Then
                    INTERNET_ACCESS = True
                    currLine = currLine + 1
                    isPerm = ReadLine(currLine, allLines)
                    PermHandler()
                Else
                    If isPerm.Contains("PROJECT_DIR") Then
                        PROJECT_DIR = True
                        currLine = currLine + 1
                        isPerm = ReadLine(currLine, allLines)
                        PermHandler()
                    Else
                        If isPerm.Contains("LOCAL_FILES") Then
                            LOCAL_FILES = True
                            currLine = currLine + 1
                            isPerm = ReadLine(currLine, allLines)
                            PermHandler()
                        Else
                            If isPerm.Contains("JG_SETTINGS") Then
                                JG_SETTINGS = True
                                currLine = currLine + 1
                                isPerm = ReadLine(currLine, allLines)
                                PermHandler()
                            Else
                                If isPerm.Contains("APNM_SETTINGS") Then
                                    APNM_SETTINGS = True
                                    currLine = currLine + 1
                                    isPerm = ReadLine(currLine, allLines)
                                    PermHandler()
                                Else
                                    currLine = currLine + 1
                                    isPerm = ReadLine(currLine, allLines)
                                    PermHandler()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If isPerm.Contains("-") Then
                If isPerm.Contains("FRAMEWORK_USE") Then
                    FRAMEWORK_USE = False
                    currLine = currLine + 1
                    isPerm = ReadLine(currLine, allLines)
                    PermHandler()
                Else
                    If isPerm.Contains("INTERNET_ACCESS") Then
                        INTERNET_ACCESS = False
                        currLine = currLine + 1
                        isPerm = ReadLine(currLine, allLines)
                        PermHandler()
                    Else
                        If isPerm.Contains("PROJECT_DIR") Then
                            PROJECT_DIR = False
                            currLine = currLine + 1
                            isPerm = ReadLine(currLine, allLines)
                            PermHandler()
                        Else
                            If isPerm.Contains("LOCAL_FILES") Then
                                LOCAL_FILES = False
                                currLine = currLine + 1
                                isPerm = ReadLine(currLine, allLines)
                                PermHandler()
                            Else
                                If isPerm.Contains("JG_SETTINGS") Then
                                    JG_SETTINGS = False
                                    currLine = currLine + 1
                                    isPerm = ReadLine(currLine, allLines)
                                    PermHandler()
                                Else
                                    If isPerm.Contains("APNM_SETTINGS") Then
                                        APNM_SETTINGS = False
                                        currLine = currLine + 1
                                        isPerm = ReadLine(currLine, allLines)
                                        PermHandler()
                                    Else
                                        currLine = currLine + 1
                                        isPerm = ReadLine(currLine, allLines)
                                        PermHandler()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                'If isPerm = "!permissions!" Then
                currLine = currLine + 1
                isPerm = ReadLine(currLine, allLines)
                'End If
            End If
        End If
    End Sub

    Public Sub TagHandler()
        Dim isTag As String
        isTag = ReadLine(currLine, allLines)
        If isTag.Contains("<") Then
            'Dim s As String = "foo [123]=ro bar"
            Dim i As Integer = isTag.IndexOf("<")
            Dim tagResult As String = isTag.Substring(i + 1, isTag.IndexOf(">", i + 1) - i - 1)
            'This checks to see if the config file is the permissions file.
            If tagResult = "iconfile" Then
                currLine = currLine + 1
                isTag = ReadLine(currLine, allLines)
                If isTag.Contains(".ico") Then
                    IconLoca = isTag
                End If
            Else
                If tagResult = "index" Then
                    currLine = currLine + 1
                    isTag = ReadLine(currLine, allLines)
                    If isTag.Contains(".html" Or ".htm") Then
                        indexFile = isTag
                    End If
                End If
                currLine = currLine + 1
                isTag = ReadLine(currLine, allLines)
            End If
        Else
            currLine = currLine + 1
            isTag = ReadLine(currLine, allLines)
        End If
    End Sub
#End Region
End Class