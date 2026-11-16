Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module CustomerStore

    Private ReadOnly connString As String =
        DatabaseConfig.ConnectionString

    ' The id column of the users table (same one you set in ReviewStore)
    Private Const UserIdCol As String = "id"

    ' Every username except the logged-in artist
    Private Function GetUserNames() As List(Of String)
        Dim names As New List(Of String)

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT user_name FROM users WHERE user_name <> @me ORDER BY user_name", conn)
                    cmd.Parameters.AddWithValue("@me", Session.CurrentUserName)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        While r.Read()
                            names.Add(r("user_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load users: " & ex.Message)
        End Try

        Return names
    End Function

    ' Small window to choose an existing user. Returns "" if cancelled.
    Public Function PickCustomer() As String
        Dim names As List(Of String) = GetUserNames()

        If names.Count = 0 Then
            MessageBox.Show("There are no other users yet.")
            Return ""
        End If

        Using dlg As New Form()
            dlg.Text = "Add New Order"
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.ClientSize = New Size(420, 150)

            Dim prompt As New Label With {
                .Text = "Choose the customer (an existing user):",
                .AutoSize = True, .Location = New Point(15, 15)}

            Dim box As New ComboBox With {
                .Location = New Point(15, 45), .Width = 390,
                .DropDownStyle = ComboBoxStyle.DropDown,
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                .AutoCompleteSource = AutoCompleteSource.ListItems}
            box.Items.AddRange(names.ToArray())

            Dim okButton As New Button With {
                .Text = "OK", .Location = New Point(225, 100), .Size = New Size(85, 30)}
            Dim cancelButton As New Button With {
                .Text = "Cancel", .Location = New Point(320, 100), .Size = New Size(85, 30),
                .DialogResult = DialogResult.Cancel}

            Dim chosen As String = ""

            AddHandler okButton.Click,
                Sub(s, ev)
                    Dim match As String = names.Find(
                        Function(n) String.Equals(n, box.Text.Trim(), StringComparison.OrdinalIgnoreCase))

                    If match Is Nothing Then
                        MessageBox.Show("That username doesn't exist. Please choose one from the list.")
                        Return
                    End If

                    chosen = match
                    dlg.DialogResult = DialogResult.OK
                End Sub

            dlg.AcceptButton = okButton
            dlg.CancelButton = cancelButton
            dlg.Controls.AddRange(New Control() {prompt, box, okButton, cancelButton})

            If dlg.ShowDialog() = DialogResult.OK Then Return chosen
        End Using

        Return ""
    End Function

    ' Creates a new order from the logged-in artist to an existing customer.
    ' The database insert only works if the customer really exists.
    Public Function AddOrder(customerUser As String, artworkTitle As String) As Boolean
        artworkTitle = artworkTitle.Trim()
        If customerUser = "" OrElse artworkTitle = "" Then Return False

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO orders (order_number, buyer_id, artist_id, artwork_title, status, progress, " &
                    "last_update, location, customer_name, order_date) " &
                    "SELECT LPAD(COALESCE((SELECT MAX(order_id) FROM orders), 0) + 1, 3, '0'), " &
                    "b.`" & UserIdCol & "`, a.`" & UserIdCol & "`, @title, 'Pending', 'Ordered', NOW(), " &
                    "COALESCE(b.location, ''), " &
                    "COALESCE(NULLIF(TRIM(CONCAT_WS(' ', b.name, b.surname)), ''), b.user_name), NOW() " &
                    "FROM users b, users a WHERE b.user_name = @customer AND a.user_name = @artist", conn)
                    cmd.Parameters.AddWithValue("@title", artworkTitle)
                    cmd.Parameters.AddWithValue("@customer", customerUser)
                    cmd.Parameters.AddWithValue("@artist", Session.CurrentUserName)
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not add the order: " & ex.Message)
            Return False
        End Try
    End Function

End Module