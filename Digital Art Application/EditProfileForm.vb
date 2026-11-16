Imports System.IO
Imports System.Drawing

Public Class EditProfileForm

    Private selectedImage As Image = Nothing
    Public Property ImageChanged As Boolean = False

    Public Property JobTitle As String
        Get
            Return job_txtbox.Text.Trim()
        End Get
        Set(value As String)
            job_txtbox.Text = value
        End Set
    End Property

    Public Property Instagram As String
        Get
            Return insta_txtbox.Text.Trim()
        End Get
        Set(value As String)
            insta_txtbox.Text = value
        End Set
    End Property

    Public Property PlaceName As String
        Get
            Return place_txtbox.Text.Trim()
        End Get
        Set(value As String)
            place_txtbox.Text = value
        End Set
    End Property

    ' Show the current photo when the window opens
    Public Sub SetPhoto(img As Image)
        profile_pic_box.Image = img
    End Sub

    ' The new photo as bytes, ready to save in the database
    Public ReadOnly Property NewImageBytes As Byte()
        Get
            If selectedImage Is Nothing Then Return Nothing
            Using ms As New MemoryStream()
                selectedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Return ms.ToArray()
            End Using
        End Get
    End Property

    ' Shrink big photos so they are small enough to save
    Private Function ResizeImage(src As Image, maxSize As Integer) As Image
        Dim ratio As Double = Math.Min(maxSize / src.Width, maxSize / src.Height)
        If ratio > 1 Then ratio = 1
        Dim w As Integer = CInt(src.Width * ratio)
        Dim h As Integer = CInt(src.Height * ratio)
        Dim bmp As New Bitmap(w, h)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(src, 0, 0, w, h)
        End Using
        Return bmp
    End Function

    Private Sub browse_button_Click(sender As Object, e As EventArgs) Handles browse_button.Click

        Using openFile As New OpenFileDialog()
            openFile.Title = "Choose Your Profile Photo"
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            openFile.Multiselect = False

            If openFile.ShowDialog() <> DialogResult.OK Then Return

            Try
                Using original As Image = Image.FromFile(openFile.FileName)
                    selectedImage = ResizeImage(original, 400)
                End Using
                profile_pic_box.Image = selectedImage
                ImageChanged = True
            Catch ex As Exception
                MessageBox.Show("Could not open that picture: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub save_button_Click(sender As Object, e As EventArgs) Handles save_button.Click

        If job_txtbox.Text.Trim() = "" OrElse
           insta_txtbox.Text.Trim() = "" OrElse
           place_txtbox.Text.Trim() = "" Then
            MessageBox.Show("Please fill in all the boxes.")
            Return
        End If

        If Not SaveFormLink(Session.CurrentUserName, gform_txtbox.Text) Then Return

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cancel_button_Click(sender As Object, e As EventArgs) Handles cancel_button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub CenterPanel()
        edit_panel.Left = (Me.ClientSize.Width - edit_panel.Width) \ 2
        edit_panel.Top = (Me.ClientSize.Height - edit_panel.Height) \ 2
    End Sub

    Private Sub EditProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterPanel()
        gform_txtbox.Text = GetFormLink(Session.CurrentUserName)
    End Sub

    Private Sub EditProfileForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterPanel()
    End Sub

    Public Property FormLink As String
        Get
            Return gform_txtbox.Text.Trim()
        End Get
        Set(value As String)
            gform_txtbox.Text = value
        End Set
    End Property

    Private Sub change_password_button_Click(sender As Object, e As EventArgs) Handles change_password_button.Click
        ShowChangePasswordDialog(Me)
    End Sub
End Class