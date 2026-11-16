Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

' Change-password feature (used by the Edit Profile window).
Module PasswordStore

    Private ReadOnly connString As String =
        "Server=localhost;Port=3306;Database=digicomms_data;Uid=root;Pwd=;"

    ' Shortest new password allowed. Change the number if you want.
    Private Const MinLength As Integer = 5

    ' Saves the new password, but ONLY if the current password is correct
    ' and the user is changing their own account.
    Private Function ChangePassword(currentPw As String, newPw As String) As Boolean
        If Session.CurrentUserName = "" Then Return False

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "UPDATE users SET password = @new WHERE user_name = @u AND password = @old", conn)
                    cmd.Parameters.AddWithValue("@new", newPw)
                    cmd.Parameters.AddWithValue("@u", Session.CurrentUserName)
                    cmd.Parameters.AddWithValue("@old", currentPw)
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not change the password: " & ex.Message)
            Return False
        End Try
    End Function

    ' Makes one "caption + hidden text box" pair on the dialog
    Private Function AddField(dlg As Form, caption As String, y As Integer) As TextBox
        dlg.Controls.Add(New Label With {
            .Text = caption, .AutoSize = True, .Location = New Point(20, y)})

        Dim box As New TextBox With {
            .Location = New Point(20, y + 22), .Width = 340,
            .UseSystemPasswordChar = True}
        dlg.Controls.Add(box)
        Return box
    End Function

    ' Small window with three boxes: current, new, confirm
    Public Sub ShowChangePasswordDialog(owner As IWin32Window)

        If Session.CurrentUserName = "" Then
            MessageBox.Show("Please log in first.")
            Return
        End If

        Using dlg As New Form()
            dlg.Text = "Change Password"
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.ClientSize = New Size(380, 260)

            Dim oldBox As TextBox = AddField(dlg, "Current password:", 15)
            Dim newBox As TextBox = AddField(dlg, "New password:", 75)
            Dim confirmBox As TextBox = AddField(dlg, "Confirm new password:", 135)

            Dim okButton As New Button With {
                .Text = "Save", .Location = New Point(190, 205), .Size = New Size(85, 32)}
            Dim cancelButton As New Button With {
                .Text = "Cancel", .Location = New Point(280, 205), .Size = New Size(85, 32),
                .DialogResult = DialogResult.Cancel}

            AddHandler okButton.Click,
                Sub(s, ev)
                    If oldBox.Text = "" OrElse newBox.Text = "" OrElse confirmBox.Text = "" Then
                        MessageBox.Show("Please fill in all the boxes.")
                        Return
                    End If

                    If newBox.Text.Length < MinLength Then
                        MessageBox.Show("The new password must be at least " & MinLength & " characters.")
                        Return
                    End If

                    If newBox.Text <> confirmBox.Text Then
                        MessageBox.Show("The new passwords do not match.")
                        Return
                    End If

                    If newBox.Text = oldBox.Text Then
                        MessageBox.Show("The new password must be different from the current one.")
                        Return
                    End If

                    If ChangePassword(oldBox.Text, newBox.Text) Then
                        MessageBox.Show("Your password was changed.", "Change Password",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dlg.DialogResult = DialogResult.OK
                    Else
                        MessageBox.Show("The current password is not correct.")
                        oldBox.Clear()
                        oldBox.Focus()
                    End If
                End Sub

            dlg.AcceptButton = okButton
            dlg.CancelButton = cancelButton
            dlg.Controls.AddRange(New Control() {okButton, cancelButton})

            dlg.ShowDialog(owner)
        End Using
    End Sub

End Module
