Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module FormLinkStore

    Private ReadOnly connString As String =
        DatabaseConfig.ConnectionString

    ' Empty is allowed (removes the link). Otherwise it must be a Google Forms link.
    Public Function IsValidFormLink(link As String) As Boolean
        If link = "" Then Return True
        Return link.StartsWith("https://docs.google.com/forms/", StringComparison.OrdinalIgnoreCase) OrElse
               link.StartsWith("https://forms.gle/", StringComparison.OrdinalIgnoreCase)
    End Function

    ' Saves the link. Only works for the logged-in user's own account.
    Public Function SaveFormLink(userName As String, link As String) As Boolean
        link = link.Trim()

        If userName = "" OrElse
           Not String.Equals(userName, Session.CurrentUserName, StringComparison.OrdinalIgnoreCase) Then Return False

        If Not IsValidFormLink(link) Then
            MessageBox.Show("Please paste a Google Forms link. It starts with " &
                            "https://docs.google.com/forms or https://forms.gle")
            Return False
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE users SET gform_link = @l WHERE user_name = @u", conn)
                    cmd.Parameters.AddWithValue("@l", If(link = "", CObj(DBNull.Value), CObj(link)))
                    cmd.Parameters.AddWithValue("@u", userName)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Could not save the link: " & ex.Message)
            Return False
        End Try
    End Function

    ' Gets an artist's saved link ("" if none)
    Public Function GetFormLink(userName As String) As String
        If userName = "" Then Return ""

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT gform_link FROM users WHERE user_name = @u", conn)
                    cmd.Parameters.AddWithValue("@u", userName)
                    Return Convert.ToString(cmd.ExecuteScalar())
                End Using
            End Using
        Catch
            Return ""
        End Try
    End Function

End Module