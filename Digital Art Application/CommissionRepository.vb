
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class CommissionRepository

    ' CHANGE THIS TO YOUR ACTUAL DATABASE NAME
    Private ReadOnly cardsConnString As String =
   DatabaseConfig.ConnectionString

    ' TEST MYSQL CONNECTION
    Public Function TestConnection() As Boolean

        Using conn As New MySqlConnection(cardsConnString)
            conn.Open()
            Return True
        End Using

    End Function

    ' GET COMMISSION INFORMATION
    Public Function GetCommission(orderNo As String) As DataTable

        Dim dt As New DataTable()

        Using conn As New MySqlConnection(cardsConnString)

            Dim query As String =
                "SELECT commission_id, order_number, artwork_title, artist_name, " &
                "order_date, commission_status, last_updated " &
                "FROM commissions WHERE order_number = @orderNo"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@orderNo", orderNo)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using

            End Using

        End Using

        Return dt

    End Function

    ' UPDATE COMMISSION STATUS
    Public Sub UpdateCommissionStatus(
        orderNo As String,
        newStatus As String
    )

        Using conn As New MySqlConnection(cardsConnString)

            conn.Open()

            Dim query As String =
                "UPDATE commissions SET commission_status = @status, " &
                "last_updated = NOW() WHERE order_number = @orderNo"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@orderNo", orderNo)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

End Class