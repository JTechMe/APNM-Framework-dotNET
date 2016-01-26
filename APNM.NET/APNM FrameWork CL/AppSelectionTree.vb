'copyright(c) 2016 Josiah Horton
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class AppSelectionTree

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

    Property RootPath() As String
        Get
            Return mRootPath
        End Get
        Set(ByVal value As String)
            mRootPath = value
        End Set
    End Property

    Public Sub TheLoadingBit()
        ' when our component is loaded, we initialize the TreeView by adding the root node
        Dim mRootNode As New TreeNode
        'mRootNode.Text = RootPath
        mRootNode.Text = "AppProjects"
        mRootNode.Tag = RootPath
        'mRootNode.ImageKey = CacheShellIcon(RootPath)
        mRootNode.SelectedImageKey = mRootNode.ImageKey & "-open"
        mRootNode.Nodes.Add("*DUMMY*")
        TreeView1.Nodes.Add(mRootNode)
    End Sub

    Private Sub AppSelectionTree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TheLoadingBit()
    End Sub

    Private Sub TreeView1_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeCollapse
        ' clear the node that is being collapsed
        e.Node.Nodes.Clear()
        ' add a dummy TreeNode to the node being collapsed so it is expandable
        e.Node.Nodes.Add("*DUMMY*")
    End Sub

    Private Sub TreeView1_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        ' clear the argNode so we can re-populate, or else we end up with duplicate nodes
        e.Node.Nodes.Clear()
        ' get the directory representing this node
        Dim mNodeDirectory As IO.DirectoryInfo
        mNodeDirectory = New IO.DirectoryInfo(e.Node.Tag.ToString)
        ' add each directory from the file system that is a child of the argNode that was passed in
        For Each mDirectory As IO.DirectoryInfo In mNodeDirectory.GetDirectories
            ' declare a TreeNode for this directory
            Dim mDirectoryNode As New TreeNode
            ' store the full path to this directory in the directory TreeNode's Tag property
            mDirectoryNode.Tag = mDirectory.FullName
            ' set the directory TreeNodes's display text
            mDirectoryNode.Text = mDirectory.Name
            ' add a dummy TreeNode to the directory node so that it is expandable
            mDirectoryNode.Nodes.Add("*DUMMY*")
            ' get the icon/open icon for this directory
            'mDirectoryNode.ImageKey = CacheShellIcon(mDirectory.FullName)
            mDirectoryNode.SelectedImageKey = mDirectoryNode.ImageKey & "-open"
            ' add this directory treenode to the treenode that is being populated
            e.Node.Nodes.Add(mDirectoryNode)
        Next

        ' add each file from the file system that is a child of the argNode that was passed in
        For Each mFile As IO.FileInfo In mNodeDirectory.GetFiles
            ' declare a TreeNode for this directory
            Dim mFileNode As New TreeNode
            ' store the full path to this directory in the directory TreeNode's Tag property
            mFileNode.Tag = mFile.FullName
            ' set the directory TreeNodes's display text
            mFileNode.Text = mFile.Name
            mFileNode.ToolTipText = mFile.FullName
            ' get the icon/open icon for this file
            'mFileNode.ImageKey = CacheShellIcon(mFile.FullName)
            mFileNode.SelectedImageKey = mFileNode.ImageKey
            'mFileNode.SelectedImageKey = mFileNode.ImageKey & "-open"
            ' add this directory treenode to the treenode that is being populated
            e.Node.Nodes.Add(mFileNode)
        Next

    End Sub

    'Function CacheShellIcon(ByVal argPath As String) As String
    'Dim mKey As String = Nothing
    '' determine the icon key for the file/folder specified in argPath
    'If IO.Directory.Exists(argPath) = True Then
    'mKey = "folder"
    'ElseIf IO.File.Exists(argPath) = True Then
    'mKey = IO.Path.GetExtension(argPath)
    'End If
    '' check if an icon for this key has already been added to the collection
    'If ImageList1.Images.ContainsKey(mKey) = False Then
    'ImageList1.Images.Add(mKey, GetShellIconAsImage(argPath))
    'If mKey = "folder" Then ImageList1.Images.Add(mKey & "-open", GetShellOpenIconAsImage(argPath))
    'End If
    'Return mKey
    'End Function

    Private Sub TreeView1_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        ' only proceed if the node represents a file
        If e.Node.ImageKey = "folder" Then Exit Sub
        If e.Node.Tag = "" Then Exit Sub
        ' try to open the file
        Try
            Process.Start(e.Node.Tag)
        Catch ex As Exception
            MessageBox.Show("Error opening file: " & ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'FolderBrowserDialog1.RootFolder = Environment.CurrentDirectory + "\AppProjects"
        FolderBrowserDialog1.ShowDialog()
        ProjectDIR = FolderBrowserDialog1.SelectedPath
        SelectedRoot = FolderBrowserDialog1.SelectedPath
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
        'Me.Text = ReadLine(5, allLines) + " - AppBuilder"
        ProjName = ReadLine(5, allLines)
        APNMName = ReadLine(6, allLines)
        ProjectVersion = ReadLine(7, allLines)
        INTERNET_ACCESS = ReadLine(12, allLines)
        IconLoca = ReadLine(26, allLines)
        indexFile = ReadLine(30, allLines)

        OpenSelectedApp()
    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

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
        geticon()
        InForm.Icon = IconFile
        InForm.Visible = True

    End Sub

    Private Sub geticon()
        Try
            'Dim url As Uri = New Uri(FasterBrowser1.Url.ToString)
            Dim url As Uri = New Uri(IndexURL)

            If url.HostNameType = UriHostNameType.Dns Then

                ' Get the URL of the favicon
                ' url.Host will return such string as www.google.com
                'Dim iconURL = "http://" & url.Host & "/favicon.ico"
                Dim iconURL = SelectedRoot + "\" + "Icon.ico"
                'Dim iconURL = SelectedRoot & "\" & IconFile

                Dim newFileName As String
                newFileName = "favicon.ico"

                ' Download the favicon
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim favicon = Image.FromStream(stream)
                'Dim bmp As System.Drawing.Image = System.Drawing.Image.FromFile(favicon, True)
                Dim bmp As System.Drawing.Bitmap = favicon
                Dim ico As System.Drawing.Icon = System.Drawing.Icon.FromHandle(bmp.GetHicon())
                'Dim icofs As Stream = File.Create(newFileName)
                'ico.Save(icofs)
                'icofs.Close()

                ' Display the favicon on ToolStripLabel1
                'Me.favicon.Image = favicon
                'My.Icon = ico
                IconFile = ico
            End If
        Catch ex As Exception
            'Me.favicon.Image = Nothing
        End Try
    End Sub
End Class
