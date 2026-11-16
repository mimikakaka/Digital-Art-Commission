Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class artist_profile
    Private ReadOnly cardsConnString As String =
        DatabaseConfig.ConnectionString

    Public Property ViewedUserName As String = ""

    Private ReadOnly Property ProfileUserName As String
        Get
            Return If(ViewedUserName <> "", ViewedUserName, Session.CurrentUserName)
        End Get
    End Property

    Private ReadOnly Property IsOwnProfile As Boolean
        Get
            Return ViewedUserName = "" OrElse
                   String.Equals(ViewedUserName, Session.CurrentUserName, StringComparison.OrdinalIgnoreCase)
        End Get
    End Property

    Private uiScale As Single = 1.0F

    Private Class ArtworkCard
        Public Property ArtworkId As Integer
        Public Property CardPanel As Panel
        Public Property ArtworkPicture As PictureBox
        Public Property TitleLabel As Label
        Public Property TypeLabel As Label
    End Class

    Private ReadOnly artworkList As New List(Of ArtworkCard)

    Private Sub ayesha_artist_profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SmoothDraw(Me)
        Me.Opacity = 0
        Me.WindowState = FormWindowState.Maximized

        profile_picture_ayesha_picture_box.SizeMode = PictureBoxSizeMode.Zoom
        profile_picture_ayesha_picture_box.BorderStyle = BorderStyle.FixedSingle

        artworks_flow_layout_panel.AutoScroll = True
        artworks_flow_layout_panel.WrapContents = True
        artworks_flow_layout_panel.FlowDirection = FlowDirection.LeftToRight
        artworks_flow_layout_panel.BackColor = Color.MistyRose

        subcategory_combobox.Items.Clear()
        subcategory_combobox.Items.Add("All Types")
        subcategory_combobox.SelectedIndex = 0

        LoadProfile()

        If Not IsOwnProfile Then
            edit_profile_button.Visible = False
            add_artworks_ayesha_artist_bttn.Visible = False
        End If

        LoadArtworks()
    End Sub

    Private Function RunSql(sql As String, ParamArray args() As Object) As Long
        Try
            Using conn As New MySqlConnection(cardsConnString)
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    For i As Integer = 0 To args.Length - 2 Step 2
                        cmd.Parameters.AddWithValue(args(i).ToString(), args(i + 1))
                    Next
                    cmd.ExecuteNonQuery()
                    Return cmd.LastInsertedId
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
            Return -1
        End Try
    End Function

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

    Private Function PickImage(title As String, ByRef bytes As Byte()) As Image
        Using dlg As New OpenFileDialog()
            dlg.Title = title
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If dlg.ShowDialog() <> DialogResult.OK Then Return Nothing

            Dim original As Image = BytesToImage(File.ReadAllBytes(dlg.FileName))
            If original Is Nothing Then
                MessageBox.Show("That file could not be read as an image.")
                Return Nothing
            End If

            bytes = ShrinkToBytes(original, 1600, 85)
            original.Dispose()
            Return BytesToImage(bytes)
        End Using
    End Function

    Private Function ShrinkToBytes(src As Image, maxSide As Integer, quality As Long) As Byte()
        Dim scale As Double = Math.Min(1.0, maxSide / CDbl(Math.Max(src.Width, src.Height)))
        Dim w As Integer = Math.Max(1, CInt(src.Width * scale))
        Dim h As Integer = Math.Max(1, CInt(src.Height * scale))

        Using bmp As New Bitmap(w, h)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(src, 0, 0, w, h)
            End Using

            Dim jpeg As System.Drawing.Imaging.ImageCodecInfo = Nothing
            For Each codec As System.Drawing.Imaging.ImageCodecInfo In System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
                If codec.MimeType = "image/jpeg" Then jpeg = codec
            Next

            Using ep As New System.Drawing.Imaging.EncoderParameters(1)
                ep.Param(0) = New System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality)
                Using ms As New MemoryStream()
                    bmp.Save(ms, jpeg, ep)
                    Return ms.ToArray()
                End Using
            End Using
        End Using
    End Function

    Private Sub LoadArtworks()
        If ProfileUserName = "" Then Return

        Try
            Using conn As New MySqlConnection(cardsConnString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT artwork_id, title, art_type, image FROM artworks " &
                    "WHERE user_name = @u ORDER BY artwork_id", conn)
                    cmd.Parameters.AddWithValue("@u", ProfileUserName)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            CreateArtworkCard(Convert.ToInt32(reader("artwork_id")),
                                              BytesToThumb(CType(reader("image"), Byte()), 500),
                                              reader("title").ToString(),
                                              reader("art_type").ToString())
                        End While
                    End Using
                End Using
            End Using
            UpdateTypeList()
        Catch ex As Exception
            MessageBox.Show("Could not load artworks: " & ex.Message)
        End Try
    End Sub
    Private Function BytesToThumb(bytes As Byte(), maxSide As Integer) As Image
        Try
            If bytes Is Nothing OrElse bytes.Length = 0 Then Return Nothing
            Using ms As New MemoryStream(bytes)
                Using src As Image = Image.FromStream(ms)
                    Dim scale As Double = Math.Min(1.0, maxSide / CDbl(Math.Max(src.Width, src.Height)))
                    Dim w As Integer = Math.Max(1, CInt(src.Width * scale))
                    Dim h As Integer = Math.Max(1, CInt(src.Height * scale))
                    Dim bmp As New Bitmap(w, h)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
                        g.DrawImage(src, 0, 0, w, h)
                    End Using
                    Return bmp
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function
    Private Sub add_artworks_ayesha_artist_bttn_Click(sender As Object, e As EventArgs) Handles add_artworks_ayesha_artist_bttn.Click
        If ProfileUserName = "" Then
            MessageBox.Show("Please log in first.")
            Return
        End If

        Dim bytes As Byte() = Nothing
        Dim img As Image = PickImage("Select Your Artwork", bytes)
        If img Is Nothing Then Return

        Dim artTitle As String = Interaction.InputBox("Enter your artwork title:", "New Artwork", "Untitled Artwork").Trim()
        If artTitle = "" Then Return

        Dim artType As String = Interaction.InputBox("Enter your artwork type:", "Artwork Type", "Digital Art").Trim()
        If artType = "" Then Return

        Dim newId As Long = RunSql(
            "INSERT INTO artworks (user_name, title, art_type, image) VALUES (@u, @t, @ty, @img)",
            "@u", ProfileUserName, "@t", artTitle, "@ty", artType, "@img", bytes)
        If newId < 0 Then Return

        CreateArtworkCard(CInt(newId), img, artTitle, artType)
        UpdateTypeList()
        MessageBox.Show("Artwork successfully added!", "Artwork Added",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function MakeLabel(text As String, x As Integer, y As Integer,
                               w As Integer, h As Integer, fontSize As Single) As Label
        Return New Label With {
            .Text = text, .Location = New Point(x, y), .Size = New Size(w, h),
            .Font = New Font("Arial Rounded MT Bold", fontSize),
            .ForeColor = Color.FromArgb(151, 91, 151), .AutoEllipsis = True}
    End Function

    Private Function MakeButton(text As String, y As Integer, onClick As Action) As Button
        Dim b As New Button With {
            .Text = text, .Location = New Point(245, y), .Size = New Size(175, 30),
            .Font = New Font("Arial Rounded MT Bold", 9),
            .BackColor = Color.LemonChiffon, .ForeColor = Color.FromArgb(151, 91, 151),
            .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
        b.FlatAppearance.BorderSize = 0
        AddHandler b.Click, Sub(s, ev) onClick()
        Return b
    End Function

    Private Sub CreateArtworkCard(artworkId As Integer, artworkImage As Image,
                                  artworkTitle As String, artworkType As String)

        Dim card As New ArtworkCard With {.ArtworkId = artworkId}

        card.CardPanel = New Panel With {
            .Size = New Size(556, 306), .BackColor = Color.FromArgb(246, 232, 244),
            .BorderStyle = BorderStyle.FixedSingle, .Margin = New Padding(12)}

        card.ArtworkPicture = New PictureBox With {
            .Location = New Point(0, 0), .Size = New Size(234, 304),
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BackColor = Color.FromArgb(246, 232, 244), .Image = artworkImage}

        card.TitleLabel = MakeLabel(artworkTitle, 242, 35, 295, 38, 16)
        card.TypeLabel = MakeLabel(artworkType, 245, 77, 295, 28, 10)

        card.CardPanel.Controls.AddRange(New Control() {card.ArtworkPicture, card.TitleLabel, card.TypeLabel})

        If IsOwnProfile Then
            card.CardPanel.Controls.Add(MakeButton("Change Title", 125, Sub() EditArtworkTitle(card)))
            card.CardPanel.Controls.Add(MakeButton("Change Type", 165, Sub() EditArtworkType(card)))
            card.CardPanel.Controls.Add(MakeButton("Change Artwork", 205, Sub() ReplaceArtworkImage(card)))
        End If

        artworkList.Add(card)
        ScaleTree(card.CardPanel, uiScale)
        artworks_flow_layout_panel.Controls.Add(card.CardPanel)
    End Sub

    Private Sub EditArtworkTitle(card As ArtworkCard)
        Dim newTitle As String = Interaction.InputBox("Enter your new artwork title:",
                                    "Change Artwork Title", card.TitleLabel.Text).Trim()
        If newTitle = "" Then Return

        If RunSql("UPDATE artworks SET title = @t WHERE artwork_id = @id AND user_name = @u",
                  "@t", newTitle, "@id", card.ArtworkId, "@u", ProfileUserName) >= 0 Then
            card.TitleLabel.Text = newTitle
        End If
    End Sub

    Private Sub EditArtworkType(card As ArtworkCard)
        Dim newType As String = Interaction.InputBox("Enter your new artwork type:",
                                    "Change Artwork Type", card.TypeLabel.Text).Trim()
        If newType = "" Then Return

        If RunSql("UPDATE artworks SET art_type = @ty WHERE artwork_id = @id AND user_name = @u",
                  "@ty", newType, "@id", card.ArtworkId, "@u", ProfileUserName) >= 0 Then
            card.TypeLabel.Text = newType
            UpdateTypeList()
        End If
    End Sub

    Private Sub ReplaceArtworkImage(card As ArtworkCard)
        Dim bytes As Byte() = Nothing
        Dim img As Image = PickImage("Replace Artwork Image", bytes)
        If img Is Nothing Then Return

        If RunSql("UPDATE artworks SET image = @img WHERE artwork_id = @id AND user_name = @u",
                  "@img", bytes, "@id", card.ArtworkId, "@u", ProfileUserName) < 0 Then Return

        Dim oldImage As Image = card.ArtworkPicture.Image
        card.ArtworkPicture.Image = img
        If oldImage IsNot Nothing Then oldImage.Dispose()

        MessageBox.Show("Artwork image successfully replaced!", "Artwork Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UpdateTypeList()
        Dim selected As String = If(subcategory_combobox.SelectedItem Is Nothing,
                                    "All Types", subcategory_combobox.SelectedItem.ToString())

        subcategory_combobox.BeginUpdate()
        subcategory_combobox.Items.Clear()
        subcategory_combobox.Items.Add("All Types")

        For Each card As ArtworkCard In artworkList
            Dim t As String = card.TypeLabel.Text
            Dim found As Boolean = False
            For Each item As Object In subcategory_combobox.Items
                If String.Equals(item.ToString(), t, StringComparison.OrdinalIgnoreCase) Then found = True
            Next
            If Not found Then subcategory_combobox.Items.Add(t)
        Next

        Dim index As Integer = subcategory_combobox.Items.IndexOf(selected)
        subcategory_combobox.SelectedIndex = If(index >= 0, index, 0)
        subcategory_combobox.EndUpdate()
    End Sub

    Private Sub FilterArtworkTypes(sender As Object, e As EventArgs) Handles subcategory_combobox.SelectedIndexChanged
        If subcategory_combobox.SelectedItem Is Nothing Then Return
        Dim selected As String = subcategory_combobox.SelectedItem.ToString()

        For Each card As ArtworkCard In artworkList
            card.CardPanel.Visible = (selected = "All Types") OrElse
                String.Equals(card.TypeLabel.Text, selected, StringComparison.OrdinalIgnoreCase)
        Next
    End Sub

    Private Sub LoadProfile()
        If ProfileUserName = "" Then Return

        Try
            Using conn As New MySqlConnection(cardsConnString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT name, surname, Email, job_title, instagram, location, profile_image " &
                    "FROM users WHERE user_name = @u", conn)
                    cmd.Parameters.AddWithValue("@u", ProfileUserName)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then Return

                        Dim fullName As String = (reader("name").ToString() & " " & reader("surname").ToString()).Trim()
                        ayesha_name_profile_artist_txt.Text = If(fullName = "", ProfileUserName, fullName)

                        profile_email_label.Text = Fallback(reader("Email"), "No email yet")
                        Label10.Text = Fallback(reader("job_title"), "Artist")
                        Label20.Text = Fallback(reader("instagram"), "No Instagram yet")
                        Label14.Text = Fallback(reader("location"), "No location yet")

                        Dim oldImage As Image = profile_picture_ayesha_picture_box.Image
                        profile_picture_ayesha_picture_box.Image =
                            If(IsDBNull(reader("profile_image")), Nothing,
                               BytesToImage(CType(reader("profile_image"), Byte())))
                        If oldImage IsNot Nothing Then oldImage.Dispose()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load profile: " & ex.Message)
        End Try
    End Sub

    Private Function Fallback(value As Object, defaultText As String) As String
        Dim s As String = Convert.ToString(value)
        Return If(s = "", defaultText, s)
    End Function

    Private Sub edit_profile_button_Click(sender As Object, e As EventArgs) Handles edit_profile_button.Click
        If Session.CurrentUserName = "" Then Return

        Dim newJob, newInsta, newPlace As String
        Dim changedImage As Boolean
        Dim imageBytes As Byte() = Nothing

        Using dlg As New EditProfileForm()
            dlg.JobTitle = If(Label10.Text = "Artist", "", Label10.Text)
            dlg.Instagram = If(Label20.Text.StartsWith("No "), "", Label20.Text)
            dlg.PlaceName = If(Label14.Text.StartsWith("No "), "", Label14.Text)

            If profile_picture_ayesha_picture_box.Image IsNot Nothing Then
                dlg.SetPhoto(New Bitmap(profile_picture_ayesha_picture_box.Image))
            End If

            If dlg.ShowDialog() <> DialogResult.OK Then Return

            newJob = dlg.JobTitle
            newInsta = dlg.Instagram
            newPlace = dlg.PlaceName
            changedImage = dlg.ImageChanged
            imageBytes = dlg.NewImageBytes
        End Using

        Dim sql As String = "UPDATE users SET job_title = @job, instagram = @insta, location = @place" &
                            If(changedImage, ", profile_image = @img", "") & " WHERE user_name = @u"

        Dim result As Long
        If changedImage Then
            result = RunSql(sql, "@job", newJob, "@insta", newInsta, "@place", newPlace,
                            "@img", imageBytes, "@u", Session.CurrentUserName)
        Else
            result = RunSql(sql, "@job", newJob, "@insta", newInsta, "@place", newPlace,
                            "@u", Session.CurrentUserName)
        End If
        If result < 0 Then Return

        LoadProfile()
        MessageBox.Show("Profile updated!", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub backtohome_button_Click(sender As Object, e As EventArgs) Handles backtohome_button.Click
        Dim home As New home_buyer()
        home.Show()
        Me.Close()
    End Sub

    Private Sub PlaceBackButton()
        Const cornerMargin As Integer = 30
        backtohome_button.Left = backtohome_button.Parent.ClientSize.Width - backtohome_button.Width - cornerMargin
        backtohome_button.Top = 10
    End Sub

    Private Sub artist_profile_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        uiScale = FitFormToWidth(Me)
        PlaceBackButton()
        FadeIn(Me)
    End Sub

    Private Sub artist_profile_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If backtohome_button IsNot Nothing Then PlaceBackButton()
    End Sub

    Private Sub ayesha_artist_profile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If profile_picture_ayesha_picture_box.Image IsNot Nothing Then
            profile_picture_ayesha_picture_box.Image.Dispose()
            profile_picture_ayesha_picture_box.Image = Nothing
        End If

        For Each card As ArtworkCard In artworkList
            If card.ArtworkPicture.Image IsNot Nothing Then card.ArtworkPicture.Image.Dispose()
        Next
        artworkList.Clear()
    End Sub

    Private Sub soapy_comms_next_bttn_Click(sender As Object, e As EventArgs) Handles soapy_comms_next_bttn.Click
        Dim link As String = GetFormLink(ProfileUserName)

        If link = "" OrElse Not IsValidFormLink(link) Then
            MessageBox.Show(If(IsOwnProfile,
                               "You haven't added a commission form yet. Add one in Edit Profile.",
                               "This artist hasn't added a commission form yet."),
                            "No Form Yet", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Process.Start(New ProcessStartInfo(link) With {.UseShellExecute = True})
    End Sub

    Private Sub soapy_reviews_next_bttn_Click(sender As Object, e As EventArgs) Handles soapy_reviews_next_bttn.Click
        Using f As New ReviewsForm()
            f.ArtistUserName = ProfileUserName
            f.ShowDialog()
        End Using
    End Sub

    Private Sub orders_pending_next_bttn_Click(sender As Object, e As EventArgs) Handles orders_pending_next_bttn.Click
        Dim pending As New orders_pendings_ayesha()
        pending.Show()
        Me.Hide()
    End Sub

    Private Sub logout_button_Click(sender As Object, e As EventArgs) Handles logout_button.Click
        LogOut()
    End Sub
End Class