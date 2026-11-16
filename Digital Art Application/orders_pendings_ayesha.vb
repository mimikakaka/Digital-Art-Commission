Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

' Artist's "pending orders" page.
' Shows one card for every Pending order that belongs to the logged-in artist.
Public Class orders_pendings_ayesha

    ' ---- colours (same palette as your designer) ----
    Private ReadOnly TitleColor As Color = Color.FromArgb(116, 53, 117)
    Private ReadOnly TextColor As Color = Color.FromArgb(113, 77, 130)
    Private ReadOnly CardBack As Color = Color.FromArgb(208, 186, 218)
    Private ReadOnly InnerBack As Color = Color.FromArgb(228, 215, 234)
    Private ReadOnly ButtonBack As Color = Color.FromArgb(203, 172, 213)
    Private ReadOnly SmallButtonBack As Color = Color.FromArgb(225, 204, 225)
    Private ReadOnly TagBack As Color = Color.FromArgb(148, 150, 211)
    Private ReadOnly TagText As Color = Color.FromArgb(65, 60, 130)
    Private ReadOnly InactiveColor As Color = Color.FromArgb(210, 210, 210)

    ' Ordered, Sketch, Rendering, Final
    Private ReadOnly StageColors As Color() = {
        Color.FromArgb(193, 140, 204),
        Color.FromArgb(239, 240, 223),
        Color.FromArgb(201, 174, 225),
        Color.FromArgb(184, 217, 224)}

    Private ReadOnly StageMessages As String() = {
        "The order was received and is waiting to be started.",
        "Your artist is currently working on your sketch.",
        "Your artist is currently rendering your artwork.",
        "Your artwork is in its final stage."}

    ' Everything one card needs to remember
    Private Class OrderCard
        Public OrderId As Integer
        Public OrderNumber As String = ""
        Public SavedStage As Integer
        Public SelectedStage As Integer
        Public StagePanels As New List(Of Panel)
        Public StatusMessage As Label
        Public LastUpdate As Label
        Public CustomerName As Label
        Public LocationValue As Label
    End Class

    ' ---------------- LOAD ----------------
    Private Sub orders_pendings_ayesha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeIn(Me)
        Me.WindowState = FormWindowState.Maximized
        LoadOrders()
    End Sub

    ' Rebuilds the whole list from the database
    Private Sub LoadOrders()
        orders_flow.SuspendLayout()

        For i As Integer = orders_flow.Controls.Count - 1 To 0 Step -1
            Dim c As Control = orders_flow.Controls(i)
            orders_flow.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim dt As DataTable = OrderStore.GetPendingOrders()

        If dt.Rows.Count = 0 Then
            orders_flow.Controls.Add(MakeLabel(
                "No pending orders. Click ""Add Orders"" to create one.",
                0, 0, 14.0F, TitleColor))
        Else
            For Each row As DataRow In dt.Rows
                orders_flow.Controls.Add(BuildCard(row))
            Next
        End If

        orders_flow.ResumeLayout()
    End Sub

    ' Safe way to refresh from inside a button on a card (the card gets disposed)
    Private Sub RefreshLater()
        Me.BeginInvoke(New Action(AddressOf LoadOrders))
    End Sub

    ' ---------------- BUILD ONE ORDER CARD ----------------
    Private Function BuildCard(row As DataRow) As Panel
        Dim card As New OrderCard()
        card.OrderId = Convert.ToInt32(row("order_id"))
        card.OrderNumber = Convert.ToString(row("order_number"))
        card.SavedStage = StageIndex(Convert.ToString(row("progress")))
        card.SelectedStage = card.SavedStage

        Dim shell As New Panel With {
            .Size = New Size(774, 445),
            .BackColor = CardBack,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(20)}

        ' --- top part ---
        shell.Controls.Add(MakeLabel("Order #" & card.OrderNumber, 17, 14, 10.8F, TitleColor))
        shell.Controls.Add(MakeLabel("Order Date: " & FormatDate(row("order_date"), "MMM d, yyyy"),
                                     391, 14, 10.8F, TitleColor))

        Dim artwork As Label = MakeLabel(Convert.ToString(row("artwork_title")), 15, 42, 16.2F, TitleColor)
        artwork.AutoSize = False
        artwork.AutoEllipsis = True
        artwork.Size = New Size(360, 34)
        shell.Controls.Add(artwork)

        shell.Controls.Add(MakeLabel("Progression:", 391, 53, 10.8F, TitleColor))
        Dim tag As New Panel With {.BackColor = TagBack, .Location = New Point(519, 48), .Size = New Size(167, 30)}
        Dim tagLabel As Label = MakeLabel("In progress", 0, 4, 10.8F, TagText)
        tagLabel.AutoSize = False
        tagLabel.Size = New Size(167, 24)
        tagLabel.TextAlign = ContentAlignment.MiddleCenter
        tag.Controls.Add(tagLabel)
        shell.Controls.Add(tag)

        ' --- customer + location ---
        shell.Controls.Add(MakeLabel("Customer:", 17, 96, 10.8F, TextColor))
        card.CustomerName = MakeLabel(Convert.ToString(row("customer_name")), 17, 118, 16.2F, TextColor)
        card.CustomerName.AutoSize = False
        card.CustomerName.AutoEllipsis = True
        card.CustomerName.Size = New Size(470, 34)
        shell.Controls.Add(card.CustomerName)

        shell.Controls.Add(MakeLabel("Location:", 17, 160, 10.8F, TextColor))
        card.LocationValue = MakeLabel(Convert.ToString(row("location")), 17, 182, 10.8F, TextColor)
        card.LocationValue.AutoSize = False
        card.LocationValue.AutoEllipsis = True
        card.LocationValue.Size = New Size(470, 26)
        shell.Controls.Add(card.LocationValue)

        Dim changeName As Button = MakeButton("Change Name", 512, 118, 174, 35, True)
        Dim changeLoc As Button = MakeButton("Change Location", 512, 172, 174, 35, True)
        shell.Controls.Add(changeName)
        shell.Controls.Add(changeLoc)

        ' --- commission status section ---
        Dim inner As New Panel With {.BackColor = InnerBack, .Location = New Point(21, 225), .Size = New Size(735, 203)}
        shell.Controls.Add(inner)

        inner.Controls.Add(MakeLabel("Commission Status:", 15, 12, 16.2F, TextColor))

        card.StatusMessage = MakeLabel("", 18, 48, 9.0F, TitleColor)
        inner.Controls.Add(card.StatusMessage)

        ' the four stage boxes - click one to choose the stage, then press Update
        For i As Integer = 0 To OrderStore.StageNames.Length - 1
            Dim idx As Integer = i
            Dim x As Integer = 21 + i * 144

            Dim box As New Panel With {
                .Location = New Point(x, 74), .Size = New Size(129, 42), .Cursor = Cursors.Hand}
            Dim name As Label = MakeLabel(OrderStore.StageNames(i), x, 122, 10.8F, TextColor)
            name.AutoSize = False
            name.Size = New Size(129, 24)
            name.TextAlign = ContentAlignment.MiddleCenter
            name.Cursor = Cursors.Hand

            card.StagePanels.Add(box)
            inner.Controls.Add(box)
            inner.Controls.Add(name)

            AddHandler box.Click, Sub(s, ev) SelectStage(card, idx)
            AddHandler name.Click, Sub(s, ev) SelectStage(card, idx)
        Next

        card.LastUpdate = MakeLabel("Last Update: " & FormatDate(row("last_update"), "MMM d, yyyy h:mm tt"),
                                    15, 172, 9.0F, TitleColor)
        inner.Controls.Add(card.LastUpdate)

        Dim doneBtn As Button = MakeButton("Done", 466, 158, 125, 35, False)
        Dim updateBtn As Button = MakeButton("Update", 597, 158, 125, 35, False)
        inner.Controls.Add(doneBtn)
        inner.Controls.Add(updateBtn)

        SelectStage(card, card.SavedStage)

        ' ---------------- BUTTON CLICKS ----------------
        AddHandler updateBtn.Click,
            Sub(s, ev)
                Dim stage As String = OrderStore.StageNames(card.SelectedStage)
                If OrderStore.UpdateProgress(card.OrderId, stage) Then
                    card.SavedStage = card.SelectedStage
                    card.LastUpdate.Text = "Last Update: " & DateTime.Now.ToString("MMM d, yyyy h:mm tt")
                    MessageBox.Show("Order #" & card.OrderNumber & " is now at: " & stage,
                                    "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Sub

        AddHandler doneBtn.Click,
            Sub(s, ev)
                Dim msg As String = "Mark order #" & card.OrderNumber & " as done? It will leave your pending list."
                If card.SavedStage < OrderStore.StageNames.Length - 1 Then
                    msg = "Order #" & card.OrderNumber & " is still at """ &
                          OrderStore.StageNames(card.SavedStage) & """, not ""Final"" yet." &
                          vbCrLf & vbCrLf & "Mark it as done anyway? It will leave your pending list."
                End If

                If MessageBox.Show(msg, "Mark as Done", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) <> DialogResult.Yes Then Return

                If OrderStore.MarkDone(card.OrderId) Then RefreshLater()
            End Sub

        AddHandler changeName.Click,
            Sub(s, ev)
                Dim newName As String = InputBox("New customer name:", "Change Name", card.CustomerName.Text).Trim()
                If newName = "" OrElse newName = card.CustomerName.Text Then Return
                If newName.Length > 100 Then newName = newName.Substring(0, 100)

                If OrderStore.ChangeCustomerName(card.OrderId, newName) Then
                    card.CustomerName.Text = newName
                End If
            End Sub

        AddHandler changeLoc.Click,
            Sub(s, ev)
                Dim newLoc As String = InputBox("New location:", "Change Location", card.LocationValue.Text).Trim()
                If newLoc = "" OrElse newLoc = card.LocationValue.Text Then Return
                If newLoc.Length > 100 Then newLoc = newLoc.Substring(0, 100)

                If OrderStore.ChangeLocation(card.OrderId, newLoc) Then
                    card.LocationValue.Text = newLoc
                End If
            End Sub

        Return shell
    End Function

    ' Highlights the chosen stage and shows its message (nothing is saved until Update)
    Private Sub SelectStage(card As OrderCard, idx As Integer)
        card.SelectedStage = idx

        For i As Integer = 0 To card.StagePanels.Count - 1
            card.StagePanels(i).BackColor = If(i = idx, StageColors(i), InactiveColor)
        Next

        card.StatusMessage.Text = StageMessages(idx)
    End Sub

    ' ---------------- TOP BUTTONS ----------------
    Private Sub add_orders_ayesha_Click(sender As Object, e As EventArgs) Handles add_orders_ayesha.Click
        Dim customer As String = PickCustomer()
        If customer = "" Then Return

        Dim title As String = InputBox("What is the artwork / commission title?", "Add New Order", "").Trim()
        If title = "" Then Return
        If title.Length > 150 Then title = title.Substring(0, 150)

        If AddOrder(customer, title) Then
            LoadOrders()
            MessageBox.Show("Order added for " & customer & ".", "Order Added",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub back_button_Click(sender As Object, e As EventArgs) Handles back_button.Click
        Dim existing As Form = Nothing

        For Each f As Form In Application.OpenForms
            If TypeOf f Is artist_profile Then
                existing = f
                Exit For
            End If
        Next

        If existing Is Nothing Then existing = New artist_profile()
        existing.Show()
        Me.Close()
    End Sub

    ' ---------------- SMALL HELPERS ----------------
    Private Function StageIndex(progress As String) As Integer
        For i As Integer = 0 To OrderStore.StageNames.Length - 1
            If String.Equals(OrderStore.StageNames(i), progress.Trim(), StringComparison.OrdinalIgnoreCase) Then Return i
        Next
        Return 0
    End Function

    Private Function FormatDate(value As Object, format As String) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return "-"
        Return Convert.ToDateTime(value).ToString(format)
    End Function

    Private Function MakeLabel(text As String, x As Integer, y As Integer, size As Single, color As Color) As Label
        Return New Label With {
            .Text = text,
            .AutoSize = True,
            .Location = New Point(x, y),
            .Font = New Font("Arial Rounded MT Bold", size, FontStyle.Regular, GraphicsUnit.Point),
            .ForeColor = color,
            .BackColor = Color.Transparent}
    End Function

    Private Function MakeButton(text As String, x As Integer, y As Integer,
                                w As Integer, h As Integer, small As Boolean) As Button
        Return New Button With {
            .Text = text,
            .Location = New Point(x, y),
            .Size = New Size(w, h),
            .Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point),
            .ForeColor = TextColor,
            .BackColor = If(small, SmallButtonBack, ButtonBack),
            .UseVisualStyleBackColor = False}
    End Function

End Class
