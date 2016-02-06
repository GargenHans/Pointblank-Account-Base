Imports System.IO
Public Class MainV
    Private Sub MainV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        Loader()
    End Sub
    Private Sub Loader()
        CheckFiles()
        CheckOnline()
    End Sub
    Private Sub Link1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel0.LinkClicked
        Dim kl = DLink1
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim kl = DLink2
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim kl = DLink3
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim kl = DLink4
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim kl = DLink5
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim kl = DLink6
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim kl = DLink7
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim kl = DLink8
        If Not kl = "" Then
            Process.Start(kl)
        End If
    End Sub

    Private Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        CurrentPic = PicLink1
        ImageViewer.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CurrentPic = PicLink2
        ImageViewer.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CurrentPic = PicLink3
        ImageViewer.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CurrentPic = PicLink4
        ImageViewer.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CurrentPic = PicLink5
        ImageViewer.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CurrentPic = PicLink6
        ImageViewer.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CurrentPic = PicLink7
        ImageViewer.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CurrentPic = PicLink8
        ImageViewer.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CurrentType = "Accounts1"
        ReadFullInfo("Accounts1", CurrentSize)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CurrentType = "Accounts2"
        ReadFullInfo("Accounts2", CurrentSize)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Loader()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Not MainIndex + 1 >= MaxIndex Then
            funcToo()
        Else
            MsgBox("عذرا لا يوجد صفحات اخرى")
        End If
    End Sub
    Private Sub funcToo()
        If Not (MainIndex + 2) = MaxIndex Then
            MainIndex += 1
            Label30.Text = "الصفحة رقم " & Int(MainIndex) + 1.ToString
            ReadFullInfo(CurrentType, CurrentSize)
        Else

            StepToo()

        End If
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If Not MainIndex = 0 Then
            MainIndex -= 1
            Label30.Text = "الصفحة رقم " & Int(MainIndex) + 1.ToString
            ReadFullInfo(CurrentType)
        Else
            MsgBox("عذرا هذه اول صفحة")
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CurrentType = "Accounts"
        ReadFullInfo("Accounts", CurrentSize)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        SellAccount.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CurrentType = "Accounts3"
        ReadFullInfo("Accounts3", CurrentSize)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        MainIndex = MaxIndex - 2
        StepToo()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        MainIndex = 0
        Label30.Text = "الصفحة رقم " & Int(MainIndex) + 1.ToString
        Dim counter As Integer = 0
        For Each C In File.ReadAllLines("Accounts.DKL")
            counter += 1
        Next
        ReadFullInfo(CurrentType, counter - (Int(counter / 8) * 8))
    End Sub
End Class