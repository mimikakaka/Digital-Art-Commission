Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module ReviewStore

    Private ReadOnly connString As String =
        DatabaseConfig.ConnectionString
    ' ===== CHANGE THESE if your table or column names differ =====
    Private Const UsersTable As String = "users"
    Private Const UserIdCol As String = "id"      ' the id column in the users table
    Private Const OrdersTable As String = "orders"
    Private Const OrderBuyerCol As String = "buyer_id"
    Private Const OrderArtistCol As String = "artist_id"
    Private Const OrderStatusCol As String = "status"
    ' Leave "" if any order counts. Use e.g. "Completed" to require a finished order.
    Private Const RequiredStatus As String = ""

    Private Function OrderExistsSql() As String
        Dim sql As String =
            "SELECT 1 FROM `" & OrdersTable & "` o " &
            "WHERE o.`" & OrderBuyerCol & "` = " &
            "(SELECT `" & UserIdCol & "` FROM `" & UsersTable & "` WHERE user_name = @buyer LIMIT 1) " &
            "AND o.`" & OrderArtistCol & "` = " &
            "(SELECT `" & UserIdCol & "` FROM `" & UsersTable & "` WHERE user_name = @artist LIMIT 1)"

        If RequiredStatus <> "" Then
            sql &= " AND o.`" & OrderStatusCol & "` = '" & RequiredStatus & "'"
        End If

        Return sql
    End Function

    ' True only if the logged-in user has ordered from this artist (and isn't the artist)
    Public Function CanReview(artistUser As String) As Boolean
        Dim buyer As String = Session.CurrentUserName

        If buyer = "" OrElse artistUser = "" OrElse
           String.Equals(buyer, artistUser, StringComparison.OrdinalIgnoreCase) Then Return False

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT EXISTS(" & OrderExistsSql() & ")", conn)
                    cmd.Parameters.AddWithValue("@buyer", buyer)
                    cmd.Parameters.AddWithValue("@artist", artistUser)
                    Return Convert.ToInt32(cmd.ExecuteScalar()) = 1
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not check your orders: " & ex.Message)
            Return False
        End Try
    End Function

    ' Saves (or updates) the logged-in buyer's review. The order check is also
    ' built into the INSERT itself, so it can't be skipped.
    Public Function SaveReview(artistUser As String, rating As Integer, reviewText As String) As Boolean
        reviewText = reviewText.Trim()
        If rating < 1 OrElse rating > 5 OrElse reviewText = "" Then Return False
        If reviewText.Length > 1000 Then reviewText = reviewText.Substring(0, 1000)

        If Not CanReview(artistUser) Then
            MessageBox.Show("Only buyers who have ordered from this artist can leave a review.")
            Return False
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO reviews (artist_user, buyer_user, rating, `comment`) " &
                    "SELECT @artist, @buyer, @rating, @text FROM DUAL " &
                    "WHERE EXISTS (" & OrderExistsSql() & ") " &
                    "ON DUPLICATE KEY UPDATE rating = @rating, `comment` = @text", conn)
                    cmd.Parameters.AddWithValue("@artist", artistUser)
                    cmd.Parameters.AddWithValue("@buyer", Session.CurrentUserName)
                    cmd.Parameters.AddWithValue("@rating", rating)
                    cmd.Parameters.AddWithValue("@text", reviewText)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Could not save the review: " & ex.Message)
            Return False
        End Try
    End Function

    ' All reviews for an artist, newest first
    Public Function GetReviews(artistUser As String) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using da As New MySqlDataAdapter(
                    "SELECT buyer_user, rating, `comment`, created_at FROM reviews " &
                    "WHERE artist_user = @a ORDER BY created_at DESC", conn)
                    da.SelectCommand.Parameters.AddWithValue("@a", artistUser)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load reviews: " & ex.Message)
        End Try

        Return dt
    End Function

End Module