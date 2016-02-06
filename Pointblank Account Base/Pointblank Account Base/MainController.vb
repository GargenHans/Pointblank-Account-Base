Imports System.IO
Imports System.Net
Module MainController
    Public MainAccounts As New List(Of AccountFullLine)
    Dim ListRank As New List(Of Integer)
    Dim ListPrise As New List(Of Integer)
    Dim ListCash As New List(Of Integer)
    Public MainAccountsFurTest As New List(Of AccountFullLine)
    Public MainAccountsRanks As New List(Of AccountFullLine)
    Public MainAccountsFurTest2 As New List(Of AccountFullLine)
    Public MainAccountsPrise As New List(Of AccountFullLine)
    Public MainAccountsFurTest3 As New List(Of AccountFullLine)
    Public MainAccountsCash As New List(Of AccountFullLine)
    Public CurrentSize As Integer = 8
    Public CurrentType As String = "Accounts"
    Public MainIndex As Integer = 0
    Public MaxIndex As Integer = 0
    Public DLink1 As String = ""
    Public DLink2 As String = ""
    Public DLink3 As String = ""
    Public DLink4 As String = ""
    Public DLink5 As String = ""
    Public DLink6 As String = ""
    Public DLink7 As String = ""
    Public DLink8 As String = ""
    Public PicLink1 As String = ""
    Public PicLink2 As String = ""
    Public PicLink3 As String = ""
    Public PicLink4 As String = ""
    Public PicLink5 As String = ""
    Public PicLink6 As String = ""
    Public PicLink7 As String = ""
    Public PicLink8 As String = ""
    Public CurrentPic As String = ""
    Public FTPuser As String = "a5550017"
    Public FTPpass As String = "RAPTORMAN2"
    Public Sub SizeThis(ByVal S As Integer)
        MainV.Size = New Size(MainV.Size.Width, (78 + 36 + 36) + (36 * S))
        CurrentSize = S
    End Sub
    Public Sub SetRank(ByVal Picture As PictureBox, ByVal Rank As Integer)
        Picture.BackgroundImage = MainV.Ranks.Images(Rank - 1)
    End Sub
    Public Sub ReadFullInfo(ByVal FileName As String, Optional ByVal Number As Integer = 8)
        If Number = 1 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
        ElseIf Number = 2 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
        ElseIf Number = 3 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
        ElseIf Number = 4 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
            Part4(ReadByLine(FileName, GetNumber(4)))
        ElseIf Number = 5 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
            Part4(ReadByLine(FileName, GetNumber(4)))
            Part5(ReadByLine(FileName, GetNumber(5)))
        ElseIf Number = 6 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
            Part4(ReadByLine(FileName, GetNumber(4)))
            Part5(ReadByLine(FileName, GetNumber(5)))
            Part6(ReadByLine(FileName, GetNumber(6)))
        ElseIf Number = 7 Then
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
            Part4(ReadByLine(FileName, GetNumber(4)))
            Part5(ReadByLine(FileName, GetNumber(5)))
            Part6(ReadByLine(FileName, GetNumber(6)))
            Part7(ReadByLine(FileName, GetNumber(7)))
        Else
            Part1(ReadByLine(FileName, GetNumber(1)))
            Part2(ReadByLine(FileName, GetNumber(2)))
            Part3(ReadByLine(FileName, GetNumber(3)))
            Part4(ReadByLine(FileName, GetNumber(4)))
            Part5(ReadByLine(FileName, GetNumber(5)))
            Part6(ReadByLine(FileName, GetNumber(6)))
            Part7(ReadByLine(FileName, GetNumber(7)))
            Part8(ReadByLine(FileName, GetNumber(8)))
        End If
        SizeThis(Number)
    End Sub
    Public Sub ListByRank()
        For value As Integer = 0 To MainAccountsFurTest.Count - 1
            LoopRemove()
        Next
        For Each Numbaa In ListRank
            Dim r = MainAccounts(Numbaa)
            MainAccountsRanks.Add(r)
        Next
        For Each Kl In MainAccountsRanks
            Dim rea As String = File.ReadAllText("Accounts1.DKL")
            Dim format As String = rea & Kl.Rank.ToString & " " & Kl.AccountName & " " & Kl.Prise & " " & Kl.FullInfo & " " & Kl.Link & " " & Kl.PicLink & " " & Kl.CashDays & vbCrLf

            File.WriteAllText("Accounts1.DKL", format)
        Next
    End Sub
    Public Sub LoopRemove()
        Dim MaxForDis As Integer = -1
        Dim index As Integer = 0
        Dim maxIndex As Integer = 0
        For Each RankT In MainAccountsFurTest
            If RankT.Rank > MaxForDis Then
                MaxForDis = RankT.Rank
                maxIndex = index
            End If
            index += 1
        Next
        ListRank.Add(maxIndex)
        MainAccountsFurTest(maxIndex).Rank = -2
    End Sub
    Public Sub ListByPrise()
        For value As Integer = 0 To MainAccountsFurTest.Count - 1
            LoopRemove2()
        Next
        For Each Numbaa In ListPrise
            Dim r = MainAccounts(Numbaa)
            MainAccountsPrise.Add(r)
        Next
        For Each Kl In MainAccountsPrise
            Dim rea As String = File.ReadAllText("Accounts2.DKL")
            Dim format As String = rea & Kl.Rank.ToString & " " & Kl.AccountName & " " & Kl.Prise & " " & Kl.FullInfo & " " & Kl.Link & " " & Kl.PicLink & " " & Kl.CashDays & vbCrLf

            File.WriteAllText("Accounts2.DKL", format)
        Next
    End Sub
    Public Sub LoopRemove2()
        Dim MaxForDis As Integer = -1
        Dim index As Integer = 0
        Dim maxIndex As Integer = 0
        For Each PriseT In MainAccountsFurTest2
            If PriseT.Prise > MaxForDis Then
                MaxForDis = PriseT.Prise
                maxIndex = index
            End If
            index += 1
        Next
        ListPrise.Add(maxIndex)
        MainAccountsFurTest2(maxIndex).Prise = -2
    End Sub
    Public Sub ListByCash()
        For value As Integer = 0 To MainAccountsFurTest.Count - 1
            LoopRemove3()
        Next
        For Each Numbaa In ListCash
            Dim r = MainAccounts(Numbaa)
            MainAccountsCash.Add(r)
        Next
        For Each Kl In MainAccountsCash
            Dim rea As String = File.ReadAllText("Accounts3.DKL")
            Dim format As String = rea & Kl.Rank.ToString & " " & Kl.AccountName & " " & Kl.Prise & " " & Kl.FullInfo & " " & Kl.Link & " " & Kl.PicLink & " " & Kl.CashDays & vbCrLf

            File.WriteAllText("Accounts3.DKL", format)
        Next
    End Sub
    Public Sub LoopRemove3()
        Dim MaxForDis As Integer = -1
        Dim index As Integer = 0
        Dim maxIndex As Integer = 0
        For Each CashT In MainAccountsFurTest3
            If CashT.CashDays > MaxForDis Then
                MaxForDis = CashT.CashDays
                maxIndex = index
            End If
            index += 1
        Next
        ListCash.Add(maxIndex)
        MainAccountsFurTest3(maxIndex).CashDays = -2
    End Sub

    Public Sub MFunctions()
        For Each Line In File.ReadAllLines("Accounts.DKL")
            Dim Inf = Line.Split()
            Dim _Ret As New AccountFullLine
            _Ret.Rank = Inf(0)
            _Ret.AccountName = Inf(1)
            _Ret.Prise = Inf(2)
            _Ret.FullInfo = Inf(3)
            _Ret.Link = Inf(4)
            _Ret.PicLink = Inf(5)
            _Ret.CashDays = Inf(6)
            MainAccounts.Add(_Ret)

        Next
        For Each Line2 In File.ReadAllLines("Accounts.DKL")
            Dim Inf = Line2.Split()
            Dim _Ret2 As New AccountFullLine
            _Ret2.Rank = Inf(0)
            _Ret2.AccountName = Inf(1)
            _Ret2.Prise = Inf(2)
            _Ret2.FullInfo = Inf(3)
            _Ret2.Link = Inf(4)
            _Ret2.PicLink = Inf(5)
            _Ret2.CashDays = Inf(6)
            MainAccountsFurTest.Add(_Ret2)
        Next
        For Each Line3 In File.ReadAllLines("Accounts.DKL")
            Dim Inf = Line3.Split()
            Dim _Ret3 As New AccountFullLine
            _Ret3.Rank = Inf(0)
            _Ret3.AccountName = Inf(1)
            _Ret3.Prise = Inf(2)
            _Ret3.FullInfo = Inf(3)
            _Ret3.Link = Inf(4)
            _Ret3.PicLink = Inf(5)
            _Ret3.CashDays = Inf(6)
            MainAccountsFurTest2.Add(_Ret3)
        Next
        For Each Line4 In File.ReadAllLines("Accounts.DKL")
            Dim Inf = Line4.Split()
            Dim _Ret4 As New AccountFullLine
            _Ret4.Rank = Inf(0)
            _Ret4.AccountName = Inf(1)
            _Ret4.Prise = Inf(2)
            _Ret4.FullInfo = Inf(3)
            _Ret4.Link = Inf(4)
            _Ret4.PicLink = Inf(5)
            _Ret4.CashDays = Inf(6)
            MainAccountsFurTest3.Add(_Ret4)
        Next
        ListByRank()
        ListByPrise()
        ListByCash()
        Dim counter As Integer = 0
        For Each C In File.ReadAllLines("Accounts.DKL")
            counter += 1
        Next
        If counter >= 8 Then
            ReadFullInfo(CurrentType)
            CurrentSize = 8
        Else
            CurrentSize = counter - (Int(counter / 8) * 8)
            ReadFullInfo(CurrentType, counter - (Int(counter / 8) * 8))
        End If

    End Sub
    Public Function GetNumber(ByVal LineNum)
        Dim _ret As Integer = LineNum + (MainIndex * 8)
        Return _ret
    End Function
    Public Function ReadByLine(ByVal FileName As String, ByVal LinNum As Integer) As AccountFullLine
        Dim str As String() = File.ReadAllLines(FileName & ".DKL")
        Dim Inf = str(LinNum - 1).Split()
        Dim _Ret As New AccountFullLine
        _Ret.Rank = Inf(0)
        _Ret.AccountName = Inf(1)
        _Ret.Prise = Inf(2)
        _Ret.FullInfo = Inf(3)
        _Ret.Link = Inf(4)
        _Ret.PicLink = Inf(5)
        _Ret.CashDays = Inf(6)
        Return _Ret
    End Function
    Public Class AccountFullLine
        Public Rank As Integer
        Public AccountName As String
        Public FullInfo As String
        Public Prise As String
        Public Link As String
        Public PicLink As String
        Public CashDays As Integer
    End Class
    Public Sub Part1(ByVal Acc As AccountFullLine)
        MainV.PictureBox0.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Lab1.Text = Acc.AccountName
        MainV.Cost1.Text = Acc.Prise & " $"
        MainV.Ch1.Checked = GetChecker(Acc.FullInfo)
        DLink1 = Acc.Link
        PicLink1 = Acc.PicLink
        MainV.Label22.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part2(ByVal Acc As AccountFullLine)
        MainV.PictureBox1.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label8.Text = Acc.AccountName
        MainV.Label7.Text = Acc.Prise & " $"
        MainV.CheckBox1.Checked = GetChecker(Acc.FullInfo)
        DLink2 = Acc.Link
        PicLink2 = Acc.PicLink
        MainV.Label23.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part3(ByVal Acc As AccountFullLine)
        MainV.PictureBox2.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label10.Text = Acc.AccountName
        MainV.Label9.Text = Acc.Prise & " $"
        MainV.CheckBox2.Checked = GetChecker(Acc.FullInfo)
        DLink3 = Acc.Link
        PicLink3 = Acc.PicLink
        MainV.Label24.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part4(ByVal Acc As AccountFullLine)
        MainV.PictureBox3.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label12.Text = Acc.AccountName
        MainV.Label11.Text = Acc.Prise & " $"
        MainV.CheckBox3.Checked = GetChecker(Acc.FullInfo)
        DLink4 = Acc.Link
        PicLink4 = Acc.PicLink
        MainV.Label25.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part5(ByVal Acc As AccountFullLine)
        MainV.PictureBox4.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label14.Text = Acc.AccountName
        MainV.Label13.Text = Acc.Prise & " $"
        MainV.CheckBox4.Checked = GetChecker(Acc.FullInfo)
        DLink5 = Acc.Link
        PicLink5 = Acc.PicLink
        MainV.Label26.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part6(ByVal Acc As AccountFullLine)
        MainV.PictureBox5.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label16.Text = Acc.AccountName
        MainV.Label15.Text = Acc.Prise & " $"
        MainV.CheckBox5.Checked = GetChecker(Acc.FullInfo)
        DLink6 = Acc.Link
        PicLink6 = Acc.PicLink
        MainV.Label27.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part7(ByVal Acc As AccountFullLine)
        MainV.PictureBox6.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label18.Text = Acc.AccountName
        MainV.Label17.Text = Acc.Prise & " $"
        MainV.CheckBox6.Checked = GetChecker(Acc.FullInfo)
        DLink7 = Acc.Link
        PicLink7 = Acc.PicLink
        MainV.Label28.Text = Acc.CashDays & "D"
    End Sub
    Public Sub Part8(ByVal Acc As AccountFullLine)
        MainV.PictureBox7.BackgroundImage = MainV.Ranks.Images(Acc.Rank)
        MainV.Label20.Text = Acc.AccountName
        MainV.Label19.Text = Acc.Prise & " $"
        MainV.CheckBox7.Checked = GetChecker(Acc.FullInfo)
        DLink8 = Acc.Link
        PicLink8 = Acc.PicLink
        MainV.Label29.Text = Acc.CashDays & "D"
    End Sub
    Private Function GetChecker(ByVal t As String) As Boolean
        If t = "1" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub CheckFiles()
        If File.Exists("Accounts.DKL") Then
            File.Delete("Accounts.DKL")
        End If
        If Not File.Exists("Accounts1.DKL") Then
            File.Create("Accounts1.DKL").Dispose()
        Else
            File.WriteAllText("Accounts1.DKL", "")
        End If
        If Not File.Exists("Accounts2.DKL") Then
            File.Create("Accounts2.DKL").Dispose()
        Else
            File.WriteAllText("Accounts2.DKL", "")
        End If
        If Not File.Exists("Accounts3.DKL") Then
            File.Create("Accounts3.DKL").Dispose()
        Else
            File.WriteAllText("Accounts3.DKL", "")
        End If
    End Sub
    Private Sub CheckCounters()
        Dim counter As Integer = 0
        For Each C In File.ReadAllLines("Accounts.DKL")
            counter += 1
        Next
        Dim GetIndex As Double = counter / 8
        Dim GetIntIndex As Integer = counter / 8
        If GetIndex = GetIntIndex Then
            MaxIndex = GetIntIndex
        Else
            If GetIndex > 2.5 Then
                MaxIndex = GetIntIndex
            Else
                MaxIndex = GetIntIndex + 1
            End If
        End If
        If counter = 0 Then
            MsgBox("لا يوجد اي حسابات للبيع حاليا !!")
            Dim grclose As Control
            For Each grclose In MainV.Controls
                grclose.Enabled = False
            Next
            MainV.Button11.Enabled = True
            MainV.Button10.Enabled = True
        Else
            For Each grclose In MainV.Controls
                grclose.Enabled = True
            Next
            MFunctions()
        End If
    End Sub
    Public Sub StepToo()
        MainIndex += 1
        MainV.Label30.Text = "الصفحة رقم " & Int(MainIndex) + 1.ToString
        Dim counter As Integer = 0
        For Each C In File.ReadAllLines("Accounts.DKL")
            counter += 1
        Next
        Dim cin As Integer = counter - (Int(counter / 8) * 8)
        If cin = 0 Then
            ReadFullInfo(CurrentType)

        Else
            ReadFullInfo(CurrentType, cin)
        End If

    End Sub
    Public Sub CheckOnline()
        Dim remoteUri As String = "http://pointblank.net16.net/Accounts.cfg"
        Dim fileName As String = "Accounts.DKL"
        Dim myWebClient As New WebClient()
        AddHandler myWebClient.DownloadFileCompleted, AddressOf client_DownloadCompleted
        myWebClient.DownloadFileAsync(New Uri(remoteUri), fileName)
    End Sub
    Private Sub client_DownloadCompleted()
        CheckCounters()
    End Sub
End Module
