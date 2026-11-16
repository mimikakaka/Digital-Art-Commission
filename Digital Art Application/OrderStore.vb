Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

' Database operations for the artist's pending-orders screen.
Module OrderStore

    Private ReadOnly connString As String =
        DatabaseConfig.ConnectionString

    Private Const UserIdColumn As String = "id"

    Public ReadOnly StageNames As String() = {"Ordered", "Sketch", "Rendering", "Final"}

    Private Function CurrentArtistId(conn As MySqlConnection) As Object
        Using cmd As New MySqlCommand(
            "SELECT `" & UserIdColumn & "` FROM users WHERE user_name = @user LIMIT 1", conn)
            cmd.Parameters.AddWithValue("@user", Session.CurrentUserName)
            Return cmd.ExecuteScalar()
        End Using
    End Function

    Public Function GetPendingOrders() As DataTable
        Dim result As New DataTable()
        If String.IsNullOrWhiteSpace(Session.CurrentUserName) Then Return result

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim artistId As Object = CurrentArtistId(conn)
                If artistId Is Nothing OrElse Convert.IsDBNull(artistId) Then Return result

                Const sql As String =
                    "SELECT order_id, order_number, artwork_title, order_date, progress, " &
                    "customer_name, location, last_update FROM orders " &
                    "WHERE artist_id = @artist AND status = 'Pending' " &
                    "ORDER BY order_date DESC, order_id DESC"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@artist", artistId)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(result)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load pending orders: " & ex.Message,
                            "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return result
    End Function

    Public Function UpdateProgress(orderId As Integer, stage As String) As Boolean
        If Array.IndexOf(StageNames, stage) < 0 Then Return False
        Return ExecuteOwnedOrderUpdate(
            "UPDATE orders SET progress = @value, last_update = NOW() " &
            "WHERE order_id = @id AND artist_id = @artist AND status = 'Pending'",
            orderId, "@value", stage, "update the order progress")
    End Function

    Public Function MarkDone(orderId As Integer) As Boolean
        Return ExecuteOwnedOrderUpdate(
            "UPDATE orders SET status = 'Completed', progress = 'Final', last_update = NOW() " &
            "WHERE order_id = @id AND artist_id = @artist AND status = 'Pending'",
            orderId, Nothing, Nothing, "mark the order as completed")
    End Function

    Public Function ChangeCustomerName(orderId As Integer, customerName As String) As Boolean
        customerName = If(customerName, String.Empty).Trim()
        If customerName = String.Empty Then Return False
        If customerName.Length > 100 Then customerName = customerName.Substring(0, 100)
        Return ExecuteOwnedOrderUpdate(
            "UPDATE orders SET customer_name = @value, last_update = NOW() " &
            "WHERE order_id = @id AND artist_id = @artist AND status = 'Pending'",
            orderId, "@value", customerName, "change the customer name")
    End Function

    Public Function ChangeLocation(orderId As Integer, location As String) As Boolean
        location = If(location, String.Empty).Trim()
        If location.Length > 255 Then location = location.Substring(0, 255)
        Return ExecuteOwnedOrderUpdate(
            "UPDATE orders SET location = @value, last_update = NOW() " &
            "WHERE order_id = @id AND artist_id = @artist AND status = 'Pending'",
            orderId, "@value", location, "change the order location")
    End Function

    Private Function ExecuteOwnedOrderUpdate(sql As String, orderId As Integer,
                                             valueParameter As String, value As Object,
                                             operation As String) As Boolean
        If orderId <= 0 OrElse String.IsNullOrWhiteSpace(Session.CurrentUserName) Then Return False

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim artistId As Object = CurrentArtistId(conn)
                If artistId Is Nothing OrElse Convert.IsDBNull(artistId) Then Return False

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", orderId)
                    cmd.Parameters.AddWithValue("@artist", artistId)
                    If Not String.IsNullOrEmpty(valueParameter) Then
                        cmd.Parameters.AddWithValue(valueParameter, value)
                    End If
                    If cmd.ExecuteNonQuery() = 1 Then Return True
                End Using
            End Using
            MessageBox.Show("The order was not changed. It may no longer be pending or may not belong to your account.",
                            "Order Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Could not " & operation & ": " & ex.Message,
                            "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

End Module
