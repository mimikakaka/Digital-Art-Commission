Imports MySql.Data.MySqlClient

Public Class Homepage

    Private ReadOnly cardsConnString As String =
        DatabaseConfig.ConnectionString

    Private Sub Homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        password_txtbox.UseSystemPasswordChar = True
        FadeIn(Me)
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles login_button.Click

        If username_txtbox.Text.Trim() = "" OrElse password_txtbox.Text = "" Then

            MessageBox.Show("Please enter your username and password.",
                            "Missing Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Return

        End If

        Try

            Using mysqlConn As New MySqlConnection(cardsConnString)

                mysqlConn.Open()

                Const query As String =
                    "SELECT COUNT(*) FROM users " &
                    "WHERE user_name = @username " &
                    "AND password = @password"

                Using command As New MySqlCommand(query, mysqlConn)

                    command.Parameters.AddWithValue("@username", username_txtbox.Text.Trim())
                    command.Parameters.AddWithValue("@password", password_txtbox.Text)

                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                    If count = 1 Then
                        Session.CurrentUserName = username_txtbox.Text.Trim()

                        MessageBox.Show("Login Successful!",
                                        "Welcome",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)

                        option_page.Show()
                        Me.Hide()

                    Else

                        MessageBox.Show("Invalid Username or Password.",
                                        "Login Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)

                        password_txtbox.Clear()
                        password_txtbox.Focus()

                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show("Database Connection Error: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Homepage_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        loginGroup.Parent = gradientBox
        loginGroup.BackColor = Color.Transparent
    End Sub

    ' Centers the login box in the area to the right of the purple panel
    Private Sub CenterLogin()
        leftPanel.Width = CInt(Me.ClientSize.Width * 0.37)

        Dim areaLeft As Integer = leftPanel.Right
        Dim areaWidth As Integer = Me.ClientSize.Width - areaLeft

        Dim x As Integer = areaLeft + (areaWidth - loginGroup.Width) \ 2
        Dim y As Integer = (Me.ClientSize.Height - loginGroup.Height) \ 2

        loginGroup.Location = loginGroup.Parent.PointToClient(Me.PointToScreen(New Point(x, y)))
    End Sub

    Private Sub gradientBox_Click(sender As Object, e As EventArgs) Handles gradientBox.Click

    End Sub

    Private Sub signup_link_button_Click(sender As Object, e As EventArgs) Handles signup_link_button.Click
        Me.Hide()
        SignUpForm.ShowDialog()
        Me.Show()
    End Sub

End Class