Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class ReviewsForm

    ' The artist whose reviews are shown (set by artist_profile)
    Public Property ArtistUserName As String = ""

    Private ReadOnly summaryLabel As New Label()
    Private ReadOnly reviewList As New Panel()
    Private ReadOnly writePanel As New Panel()
    Private ReadOnly ratingBox As New ComboBox()
    Private ReadOnly commentBox As New TextBox()
    Private ReadOnly submitButton As New Button()
    Private reviews As DataTable
    Private ReadOnly purpleText As Color = Color.FromArgb(148, 93, 155)

    Private Sub ReviewsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Reviews"
        Me.MinimumSize = New Size(700, 520)
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.FromArgb(254, 222, 236)

        reviewList.Dock = DockStyle.Fill
        reviewList.AutoScroll = True

        summaryLabel.Dock = DockStyle.Top
        summaryLabel.Height = 80
        summaryLabel.TextAlign = ContentAlignment.MiddleCenter
        summaryLabel.Font = New Font("Arial Rounded MT Bold", 16)
        summaryLabel.ForeColor = purpleText
        summaryLabel.BackColor = Color.FromArgb(234, 215, 236)

        writePanel.Dock = DockStyle.Bottom
        writePanel.Height = 180
        writePanel.BackColor = Color.FromArgb(234, 215, 236)

        ' The "Fill" control must be added first so the others dock around it
        Me.Controls.Add(reviewList)
        Me.Controls.Add(writePanel)
        Me.Controls.Add(summaryLabel)

        LoadReviews()
        BuildWritePanel()
    End Sub

    Private Sub LoadReviews()
        reviews = GetReviews(ArtistUserName)
        ShowReviews()
    End Sub

    ' ---------- the list of reviews ----------
    Private Sub ShowReviews()
        reviewList.SuspendLayout()
        reviewList.AutoScrollPosition = New Point(0, 0)

        For i As Integer = reviewList.Controls.Count - 1 To 0 Step -1
            reviewList.Controls(i).Dispose()
        Next

        ' Average rating at the top
        Dim total As Double = 0
        For Each row As DataRow In reviews.Rows
            total += Convert.ToDouble(row("rating"))
        Next

        If reviews.Rows.Count = 0 Then
            summaryLabel.Text = "No reviews yet"
        Else
            summaryLabel.Text = String.Format("Rating: {0:0.0} / 5   ({1} review{2})",
                total / reviews.Rows.Count, reviews.Rows.Count,
                If(reviews.Rows.Count = 1, "", "s"))
        End If

        Dim cardWidth As Integer = Math.Max(300, reviewList.ClientSize.Width - 40 - SystemInformation.VerticalScrollBarWidth)
        Dim bodyFont As New Font("Arial Rounded MT Bold", 10)
        Dim y As Integer = 20

        For Each row As DataRow In reviews.Rows
            Dim rating As Integer = Convert.ToInt32(row("rating"))
            Dim reviewText As String = row("comment").ToString()
            Dim textHeight As Integer = TextRenderer.MeasureText(reviewText, bodyFont,
                New Size(cardWidth - 40, 0), TextFormatFlags.WordBreak).Height + 6

            Dim card As New Panel With {
                .Location = New Point(20, y),
                .Size = New Size(cardWidth, 76 + textHeight),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .BackColor = Color.FromArgb(246, 232, 244),
                .BorderStyle = BorderStyle.FixedSingle}

            Dim stars As New Label With {
                .Text = New String(ChrW(&H2605), rating) & New String(ChrW(&H2606), 5 - rating),
                .Font = New Font("Segoe UI Symbol", 14),
                .ForeColor = Color.FromArgb(230, 160, 40),
                .Location = New Point(15, 8),
                .AutoSize = True}

            Dim who As New Label With {
                .Text = row("buyer_user").ToString() & "   |   " &
                        Convert.ToDateTime(row("created_at")).ToString("MMM d, yyyy"),
                .Font = New Font("Arial Rounded MT Bold", 9),
                .ForeColor = purpleText,
                .Location = New Point(15, 40),
                .AutoSize = True}

            Dim body As New Label With {
                .Text = reviewText,
                .Font = bodyFont,
                .ForeColor = Color.FromArgb(113, 77, 130),
                .Location = New Point(15, 66),
                .Size = New Size(cardWidth - 40, textHeight),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

            card.Controls.AddRange(New Control() {stars, who, body})
            reviewList.Controls.Add(card)
            y += card.Height + 12
        Next

        reviewList.ResumeLayout()
    End Sub

    ' ---------- the "write a review" area ----------
    Private Sub BuildWritePanel()
        writePanel.Controls.Clear()

        ' Artists can't review themselves: hide the area
        If String.Equals(Session.CurrentUserName, ArtistUserName, StringComparison.OrdinalIgnoreCase) Then
            writePanel.Visible = False
            Return
        End If

        ' Not allowed (never ordered): show a message instead of the form
        If Not CanReview(ArtistUserName) Then
            Dim note As New Label With {
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Arial Rounded MT Bold", 11),
                .ForeColor = purpleText,
                .Text = "Only buyers who have ordered from this artist can leave a review."}
            writePanel.Controls.Add(note)
            Return
        End If

        Dim rateLabel As New Label With {
            .Text = "Rating", .AutoSize = True, .Location = New Point(20, 16),
            .Font = New Font("Arial Rounded MT Bold", 10), .ForeColor = purpleText}

        ratingBox.DropDownStyle = ComboBoxStyle.DropDownList
        ratingBox.Font = New Font("Arial Rounded MT Bold", 10)
        ratingBox.Items.Clear()
        ratingBox.Items.AddRange(New Object() {"5 stars", "4 stars", "3 stars", "2 stars", "1 star"})
        ratingBox.SelectedIndex = 0
        ratingBox.Location = New Point(20, 44)
        ratingBox.Width = 150

        Dim commentLabel As New Label With {
            .Text = "Your comment", .AutoSize = True, .Location = New Point(190, 16),
            .Font = New Font("Arial Rounded MT Bold", 10), .ForeColor = purpleText}

        commentBox.Multiline = True
        commentBox.MaxLength = 1000
        commentBox.ScrollBars = ScrollBars.Vertical
        commentBox.Font = New Font("Arial Rounded MT Bold", 10)
        commentBox.Location = New Point(190, 44)
        commentBox.Size = New Size(Me.ClientSize.Width - 190 - 170, 110)
        commentBox.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        submitButton.Text = "Submit Review"
        submitButton.Size = New Size(130, 45)
        submitButton.Location = New Point(Me.ClientSize.Width - 150, 44)
        submitButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        submitButton.BackColor = Color.FromArgb(193, 138, 189)
        submitButton.ForeColor = Color.FloralWhite
        submitButton.UseVisualStyleBackColor = False
        submitButton.Font = New Font("Arial Rounded MT Bold", 10)
        RemoveHandler submitButton.Click, AddressOf SubmitReview
        AddHandler submitButton.Click, AddressOf SubmitReview

        ' If this buyer already reviewed, show their old review so they can edit it
        For Each row As DataRow In reviews.Rows
            If String.Equals(row("buyer_user").ToString(), Session.CurrentUserName,
                             StringComparison.OrdinalIgnoreCase) Then
                Dim idx As Integer = 5 - Convert.ToInt32(row("rating"))
                If idx >= 0 AndAlso idx <= 4 Then ratingBox.SelectedIndex = idx
                commentBox.Text = row("comment").ToString()
                submitButton.Text = "Update Review"
            End If
        Next

        writePanel.Controls.AddRange(New Control() {rateLabel, ratingBox, commentLabel, commentBox, submitButton})
    End Sub

    Private Sub SubmitReview(sender As Object, e As EventArgs)
        If commentBox.Text.Trim() = "" Then
            MessageBox.Show("Please write a short comment.")
            Return
        End If

        Dim rating As Integer = Convert.ToInt32(ratingBox.Text.Substring(0, 1))

        If SaveReview(ArtistUserName, rating, commentBox.Text) Then
            MessageBox.Show("Thank you! Your review was saved.", "Review Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadReviews()
            submitButton.Text = "Update Review"
        End If
    End Sub

End Class
