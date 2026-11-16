Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Partial Public Class home_buyer
    Inherits System.Windows.Forms.Form

    Private Const ArtistFilter As String = ""

    Public Sub New()
        InitializeComponent()
        FadeIn(Me)
    End Sub

    Private Sub home_buyer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        subcategory_combobox_Setup()

        Me.AutoScroll = False

        cards_flow.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        cards_flow.WrapContents = True
        cards_flow.FlowDirection = FlowDirection.LeftToRight
        cards_flow.AutoScroll = True

        FitCardsArea()
    End Sub
    ' Centers the cards: leftover space is split evenly on the left and right
    Private Sub CenterCards()
        Const cardSlot As Integer = 334   ' card width 304 + margins 15 + 15

        Dim available As Integer = cards_flow.ClientSize.Width
        If available <= 0 Then Return

        Dim columns As Integer = Math.Max(1, available \ cardSlot)
        Dim sidePad As Integer = Math.Max(0, (available - columns * cardSlot) \ 2)

        cards_flow.Padding = New Padding(sidePad, 20, 0, 20)
    End Sub

    Private Sub cards_flow_SizeChanged(sender As Object, e As EventArgs) Handles cards_flow.SizeChanged
        CenterCards()
    End Sub

    ' Remembers where you placed the cards area in the designer
    Private cardsLeft As Integer = -1

    ' Moves the buttons of a bar so the right-most one sits near the window's right edge
    Private Sub PinButtonsRight(bar As Control)
        Const rightMargin As Integer = 40

        Dim maxRight As Integer = 0
        For Each c As Control In bar.Controls
            If TypeOf c Is Button Then maxRight = Math.Max(maxRight, c.Right)
        Next
        If maxRight = 0 Then Return

        Dim shift As Integer = (bar.Width - rightMargin) - maxRight
        For Each c As Control In bar.Controls
            If TypeOf c Is Button Then c.Left += shift
        Next
    End Sub

    Private Sub FitCardsArea()
        Panel1.Left = 0
        Panel1.Width = Me.ClientSize.Width
        Panel5.Left = 0
        Panel5.Width = Me.ClientSize.Width

        PinButtonsRight(Panel1)
        PinButtonsRight(Panel5)

        If cardsLeft < 0 Then cardsLeft = cards_flow.Left

        cards_flow.Left = cardsLeft
        cards_flow.Width = Math.Max(100, Me.ClientSize.Width - cardsLeft)
        cards_flow.Height = Math.Max(100, Me.ClientSize.Height - cards_flow.Top)
    End Sub

    Private Sub subcategory_combobox_Setup()
        subcategory_combox.DropDownStyle = ComboBoxStyle.DropDownList
        subcategory_combox.Items.Clear()
        subcategory_combox.Items.Add("Show All")
        subcategory_combox.SelectedIndex = 0
    End Sub

    ' Reload the cards every time this page is shown (also after BACK),
    ' so new accounts and profile edits appear.
    Private Sub home_buyer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadArtistCards()
    End Sub

    ' ---------------- BUTTONS ----------------
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim orders As New order_status()
        orders.Show()
        Me.Hide()
    End Sub

    Private Sub artist_view_profile_Click(sender As Object, e As EventArgs) Handles artist_view_profile.Click
        Dim profile As New artist_profile()
        profile.Show()
        Me.Hide()
    End Sub

    ' ---------------- FILTER ----------------
    Private Sub subcategory_combox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subcategory_combox.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim selected As String = subcategory_combox.Text

        For Each card As Control In cards_flow.Controls
            card.Visible = (selected = "") OrElse
                           (selected = "Show All") OrElse
                           String.Equals(Convert.ToString(card.Tag), selected,
                                         StringComparison.OrdinalIgnoreCase)
        Next
    End Sub

    ' "Show All" + every job title found on the cards
    Private Sub RefreshFilterList(jobTitles As List(Of String))
        Dim previous As String = subcategory_combox.Text

        subcategory_combox.BeginUpdate()
        subcategory_combox.Items.Clear()
        subcategory_combox.Items.Add("Show All")
        For Each title As String In jobTitles
            subcategory_combox.Items.Add(title)
        Next

        Dim index As Integer = subcategory_combox.Items.IndexOf(previous)
        If index >= 0 Then
            subcategory_combox.SelectedIndex = index
        Else
            subcategory_combox.SelectedIndex = 0
        End If
        subcategory_combox.EndUpdate()
    End Sub

    ' ---------------- LOAD ARTISTS ----------------
    Private Sub LoadArtistCards()
        cards_flow.SuspendLayout()
        ApplyFilter()
        ClearCards()

        Dim jobTitles As New List(Of String)

        Try
            Using conn As New MySqlConnection(cardsConnString)
                conn.Open()

                Dim sql As String =
                    "SELECT user_name, name, surname, job_title, location, profile_image " &
                    "FROM users " & ArtistFilter & " ORDER BY user_name"

                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim userName As String = reader("user_name").ToString()

                            Dim fullName As String =
                                (reader("name").ToString() & " " & reader("surname").ToString()).Trim()
                            If fullName = "" Then fullName = userName

                            Dim job As String = reader("job_title").ToString()
                            If job = "" Then job = "3D Artist"

                            Dim place As String = reader("location").ToString()

                            Dim photo As Image = Nothing
                            If Not IsDBNull(reader("profile_image")) Then
                                photo = BytesToImage(CType(reader("profile_image"), Byte()))
                            End If

                            AddArtistCard(userName, fullName, job, place, photo)

                            If Not jobTitles.Exists(Function(t) String.Equals(t, job, StringComparison.OrdinalIgnoreCase)) Then
                                jobTitles.Add(job)
                            End If

                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load the artists:" & vbCrLf & ex.Message,
                            "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        cards_flow.ResumeLayout()
        RefreshFilterList(jobTitles)
        ApplyFilter()
    End Sub

    Private Sub AddArtistCard(userName As String, displayName As String, jobTitle As String,
                              place As String, photo As Image)

        Dim card As New Panel()
        card.Size = New Size(304, 453)
        card.Margin = New Padding(15)
        card.BackColor = Color.FromArgb(220, 190, 216)
        card.Tag = jobTitle

        Dim pic As New PictureBox()
        pic.Location = New Point(29, 28)
        pic.Size = New Size(243, 190)
        pic.SizeMode = PictureBoxSizeMode.Zoom
        pic.Image = photo

        Dim lblName As New Label()
        lblName.AutoSize = False
        lblName.AutoEllipsis = True
        lblName.Font = New Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        lblName.ForeColor = Color.FromArgb(148, 93, 155)
        lblName.Location = New Point(32, 231)
        lblName.Size = New Size(243, 36)
        lblName.Text = displayName

        Dim lblJob As New Label()
        lblJob.AutoSize = False
        lblJob.AutoEllipsis = True
        lblJob.Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        lblJob.ForeColor = Color.FromArgb(113, 77, 130)
        lblJob.Location = New Point(32, 273)
        lblJob.Size = New Size(243, 24)
        lblJob.Text = jobTitle

        Dim lblPlace As New Label()
        lblPlace.AutoSize = False
        lblPlace.AutoEllipsis = True
        lblPlace.Font = New Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        lblPlace.ForeColor = Color.FromArgb(118, 115, 155)
        lblPlace.Location = New Point(32, 304)
        lblPlace.Size = New Size(243, 70)
        lblPlace.Text = place

        Dim btn As New Button()
        btn.BackColor = Color.FromArgb(193, 138, 189)
        btn.Font = New Font("Arial Rounded MT Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        btn.ForeColor = Color.FloralWhite
        btn.Location = New Point(36, 388)
        btn.Size = New Size(235, 47)
        btn.Text = "View Portfolio"
        btn.UseVisualStyleBackColor = False
        btn.Tag = userName
        AddHandler btn.Click, AddressOf ViewPortfolio_Click

        card.Controls.Add(pic)
        card.Controls.Add(lblName)
        card.Controls.Add(lblJob)
        card.Controls.Add(lblPlace)
        card.Controls.Add(btn)

        cards_flow.Controls.Add(card)
    End Sub

    ' Removes old cards and frees their pictures
    Private Sub ClearCards()
        For i As Integer = cards_flow.Controls.Count - 1 To 0 Step -1
            Dim card As Control = cards_flow.Controls(i)

            For Each child As Control In card.Controls
                Dim pb As PictureBox = TryCast(child, PictureBox)
                If pb IsNot Nothing AndAlso pb.Image IsNot Nothing Then
                    pb.Image.Dispose()
                End If
            Next

            card.Dispose()
        Next
    End Sub

    Private Function BytesToImage(bytes As Byte()) As Image
        Try
            If bytes Is Nothing OrElse bytes.Length = 0 Then Return Nothing

            Using ms As New MemoryStream(bytes)
                Using temp As Image = Image.FromStream(ms)
                    Return New Bitmap(temp)
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    ' ---------------- VIEW PORTFOLIO ----------------
    Private Sub ViewPortfolio_Click(sender As Object, e As EventArgs)
        Dim userName As String = Convert.ToString(DirectCast(sender, Button).Tag)

        Dim profile As New artist_profile()
        profile.ViewedUserName = userName
        profile.Show()
        Me.Hide()
    End Sub

End Class