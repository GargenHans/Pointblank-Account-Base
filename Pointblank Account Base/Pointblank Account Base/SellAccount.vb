Imports System.Net
Imports System.IO
Public Class SellAccount
    Public RankIndex As Integer = 0
    Public folderLink As String = ""
    Public Extravaganza As Integer = 0
    Private Sub SellAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        PictureBox1.BackgroundImage = MainV.Ranks.Images(RankIndex)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not RankIndex = MainV.Ranks.Images.Count() - 1 Then
            RankIndex += 1
            PictureBox1.BackgroundImage = MainV.Ranks.Images(RankIndex)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not RankIndex = 0 Then
            RankIndex -= 1
            PictureBox1.BackgroundImage = MainV.Ranks.Images(RankIndex)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsReadyToUpload() Then
            StartUploading()
        End If
    End Sub
    Private Function IsReadyToUpload() As Boolean
        If TextBox1.Text = "" Then
            Return False
        ElseIf TextBox2.Text = "" Then
            Return False

        ElseIf TextBox3.Text = "" Then
            Return False
        ElseIf TextBox4.Text = "" Then
            Return False
        ElseIf TextBox5.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            CheckBox2.Checked = False
        Else
            CheckBox2.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RankIndex = 49
        PictureBox1.BackgroundImage = MainV.Ranks.Images(RankIndex)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RankIndex = 0
        PictureBox1.BackgroundImage = MainV.Ranks.Images(RankIndex)
    End Sub

    Private Sub TextBox5_Click(sender As Object, e As EventArgs) Handles TextBox5.Click
        MsgBox("يجب عليك وضع جميع صور الحساب في ملف خاص . ومن ثم اختيار هذا الملف." & vbCrLf & "يجب ان تكون الصوره بصيغة .JPG")
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            TextBox5.Text = folderDlg.SelectedPath
            folderLink = folderDlg.SelectedPath
        End If
    End Sub
    Private Sub StartUploading()
        Dim address As String = "http://pointblank.net16.net/AccountsNumber.cfg"
        Dim client As WebClient = New WebClient()
        Dim NumbV As String = client.DownloadString(address)
        Extravaganza = Int(NumbV)
        Dim fn As String = "ftp://pointblank.net16.net/public_html/Accs/" & (Extravaganza + 1).ToString
        FtpFolderCreate(fn, FTPuser, FTPpass)
        UploadNewString()
    End Sub
    Private Function FtpFolderCreate(folder_name As String, username As String, password As String) As Boolean
        Dim request As Net.FtpWebRequest = CType(FtpWebRequest.Create(folder_name), FtpWebRequest)
        request.Credentials = New NetworkCredential(username, password)
        request.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
            End Using

        Catch ex As WebException
            Dim response As FtpWebResponse = DirectCast(ex.Response, FtpWebResponse)
            MsgBox(ex.Message)
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                Return False
            End If
        End Try
        Return True
    End Function
    Private Sub UploadNewString()
        Dim c As New WebClient
        c.Credentials = New NetworkCredential(FTPuser, FTPpass)
        c.UploadString("ftp: //pointblank.net16.net/public_html/AccountsNumber.cfg", (Extravaganza + 1).ToString)
        c.Dispose()
        UploadAllImages()
    End Sub
    Private Sub UploadAllImages()
        Dim cn As Integer = 0
        For Each File In Directory.GetFiles(folderLink)
            cn += 1
            'Dim c As New WebClient
            'c.Credentials = New NetworkCredential(FTPuser, FTPpass)
            ' MsgBox("ftp://pointblank.net16.net/Accs" & (Extravaganza + 1).ToString & "/" & cn & Path.GetExtension(File))
            'MsgBox(File)
            UploadFile(File, ("ftp://pointblank.net16.net/public_html/Accs/" & (Extravaganza + 1).ToString & "/" & cn & Path.GetExtension(File)), FTPuser, FTPpass)
            'c.Dispose()
        Next
        FinishThingsUp()
    End Sub
    Private Sub FinishThingsUp()
        Dim cn As Integer = 0
        For Each File In Directory.GetFiles(folderLink)
            cn += 1
        Next
        If Not File.Exists("Images.DKL") Then
            File.Create("Images.DKL").Dispose()
            File.WriteAllText("Images.DKL", cn)
        Else
            File.WriteAllText("Images.DKL", "")
            File.WriteAllText("Images.DKL", cn)
        End If
        UploadFile("Images.DKL", ("ftp://pointblank.net16.net/public_html/Accs/" & (Extravaganza + 1).ToString & "/Images.cfg"), FTPuser, FTPpass)
        FinalStep()
    End Sub
    Private Sub FinalStep()
        Dim address As String = "http://pointblank.net16.net/Accounts.cfg"
        Dim client As WebClient = New WebClient()
        Dim Complete As String = client.DownloadString(address)
        Dim fullFormat As String = Complete & vbCrLf & RankIndex & " " & TextBox1.Text & " " & TextBox2.Text & " " & GetInfoStatic() & " " & TextBox3.Text & " " & GetTheLink() & " " & TextBox4.Text
        Dim c As New WebClient
        c.Credentials = New NetworkCredential(FTPuser, FTPpass)
        c.UploadString("ftp://pointblank.net16.net/public_html/Accounts.cfg", fullFormat)
        c.Dispose()
        MsgBox("Uploading Finished !!")
        Me.Close()
    End Sub
    Private Function GetInfoStatic()
        If CheckBox1.Checked Then
            Return "1"
        Else
            Return "0"
        End If
    End Function
    Private Function GetTheLink()
        Return "http://pointblank.net16.net/Accs/" & (Extravaganza + 1).ToString & "/"
    End Function
    Public Sub UploadFile(ByVal _FileName As String, ByVal _UploadPath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)
        Dim _FileInfo As New System.IO.FileInfo(_FileName)
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)
        _FtpWebRequest.KeepAlive = False

        _FtpWebRequest.Timeout = 30000
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        _FtpWebRequest.UseBinary = True
        _FtpWebRequest.ContentLength = _FileInfo.Length

        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte
        Dim _FileStream As System.IO.FileStream = _FileInfo.OpenRead()

        Try
            Dim _Stream As System.IO.Stream = _FtpWebRequest.GetRequestStream()
            Dim contentLen As Integer = _FileStream.Read(buff, 0, buffLength)
            Do While contentLen <> 0
                _Stream.Write(buff, 0, contentLen)
                contentLen = _FileStream.Read(buff, 0, buffLength)
            Loop
            _Stream.Close()
            _Stream.Dispose()
            _FileStream.Close()
            _FileStream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class