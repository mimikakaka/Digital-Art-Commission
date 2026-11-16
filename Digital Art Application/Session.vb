Imports System.Collections.Generic
Imports System.Windows.Forms

Module Session
    Public CurrentUserName As String = ""

    Public Sub LogOut()
        If MessageBox.Show("Do you want to log out?", "Log out",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        CurrentUserName = ""

        Dim login As Form = My.Application.ApplicationContext.MainForm

        Dim others As New List(Of Form)
        For Each f As Form In Application.OpenForms
            If f IsNot login Then others.Add(f)
        Next

        Dim loginPage As Homepage = TryCast(login, Homepage)
        If loginPage IsNot Nothing Then
            loginPage.username_txtbox.Clear()
            loginPage.password_txtbox.Clear()
        End If
        login.Show()
        login.Activate()

        login.BeginInvoke(New Action(
            Sub()
                For Each f As Form In others
                    If Not f.IsDisposed Then f.Dispose()
                Next
            End Sub))
    End Sub
End Module