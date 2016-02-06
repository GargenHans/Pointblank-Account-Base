Imports System.Net
Imports System.IO
Imports Pointblank_Account_Base.Resizer

Public Class ImageViewer
    Public ImageNum As Integer = 0
    Public currentPicacho As Integer = 1
    Dim rs As New Resizer
    Private Sub ImageViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Dim address As String = CurrentPic & "Images.cfg"
        Dim client As WebClient = New WebClient()
        Dim NumbV As String = client.DownloadString(address)
        ImageNum = Int(NumbV)
        If ImageNum = 0 Or ImageNum = Nothing Then
            MsgBox("لا يوجد صور لعرضها هنا !!")
            Me.Close()
        Else
            ShowPics()
        End If

    End Sub
    Private Sub ShowPics()
        Dim client As WebClient = New WebClient()
        Dim Im_getter As Bitmap = Bitmap.FromStream(New MemoryStream(client.DownloadData(CurrentPic & currentPicacho & ".jpg")))
        Me.BackgroundImage = Im_getter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not currentPicacho + 1 > ImageNum Then
            currentPicacho += 1
            Dim client As WebClient = New WebClient()
            Dim Im_getter As Bitmap = Bitmap.FromStream(New MemoryStream(client.DownloadData(CurrentPic & currentPicacho & ".jpg")))
            Me.BackgroundImage = Im_getter
        Else
            MsgBox("لا يوجد صور اخرى لعرضها !!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not currentPicacho = 1 Then
            currentPicacho -= 1
            Dim client As WebClient = New WebClient()
            Dim Im_getter As Bitmap = Bitmap.FromStream(New MemoryStream(client.DownloadData(CurrentPic & currentPicacho & ".jpg")))
            Me.BackgroundImage = Im_getter
        Else
            MsgBox("لا يوجد صور اخرى لعرضها !!")
        End If
    End Sub

    Private Sub ImageViewer_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class