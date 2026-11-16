Imports MySql.Data.MySqlClient

Public Class SignUpForm

    Private cardsConnString As String =
        DatabaseConfig.ConnectionString

    Private Sub signup_button_Click(sender As Object, e As EventArgs) Handles signup_button.Click

        If first_txtbox.Text.Trim() = "" OrElse
   last_txtbox.Text.Trim() = "" OrElse
   email_txtbox.Text.Trim() = "" OrElse
   username_txtbox.Text.Trim() = "" OrElse
   password_txtbox.Text = "" Then
            MessageBox.Show("Please fill in all the boxes.")
            Return
        End If

        Try
            Using conn As New MySqlConnection(cardsConnString)
                conn.Open()

                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE user_name = @username"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@username", username_txtbox.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("That username is already taken.")
                        Return
                    End If
                End Using

                Dim insertQuery As String =
    "INSERT INTO users (name, surname, user_name, password, Email) " &
    "VALUES (@name, @surname, @username, @password, @email)"
                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@name", first_txtbox.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@surname", last_txtbox.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@username", username_txtbox.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@password", password_txtbox.Text)
                    insertCmd.Parameters.AddWithValue("@email", email_txtbox.Text.Trim())
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account created! You can log in now.")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Sign up error: " & ex.Message)
        End Try

    End Sub
    Private Sub CenterPanel()
        signup_panel.Left = (Me.ClientSize.Width - signup_panel.Width) \ 2
        signup_panel.Top = (Me.ClientSize.Height - signup_panel.Height) \ 2
    End Sub

    Private Sub SignUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeIn(Me)
        CenterPanel()
        Dim spot As Point = gradientBox.PointToClient(signup_panel.PointToScreen(Point.Empty))
        signup_panel.Parent = gradientBox
        signup_panel.Location = spot
        signup_panel.BackColor = Color.Transparent

    End Sub

    Private Sub SignUpForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterPanel()
    End Sub
    Private Sub back_button_Click(sender As Object, e As EventArgs) Handles back_button.Click
        Me.Close()
    End Sub

    Private Sub signup_panel_Paint(sender As Object, e As PaintEventArgs) Handles signup_panel.Paint

    End Sub


End Class