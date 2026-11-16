Imports System.Windows
Imports MySql.Data.MySqlClient

Public Class home_buyer
    Inherits System.Windows.Forms.Form

    Private cardsConnString As String =
        DatabaseConfig.ConnectionString

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home_buyer))
        Me.login_button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.artist_view_profile = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.subcategory_combox = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cards_flow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'login_button
        '
        Me.login_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.login_button.BackColor = System.Drawing.Color.LemonChiffon
        Me.login_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.login_button.Location = New System.Drawing.Point(1726, 11)
        Me.login_button.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.login_button.Name = "login_button"
        Me.login_button.Size = New System.Drawing.Size(172, 45)
        Me.login_button.TabIndex = 4
        Me.login_button.Text = "BACK"
        Me.login_button.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Panel1.Controls.Add(Me.login_button)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2155, 90)
        Me.Panel1.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.artist_view_profile)
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Controls.Add(Me.subcategory_combox)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Location = New System.Drawing.Point(0, 72)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(2155, 58)
        Me.Panel5.TabIndex = 9
        '
        'artist_view_profile
        '
        Me.artist_view_profile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.artist_view_profile.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.artist_view_profile.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.artist_view_profile.ForeColor = System.Drawing.Color.FloralWhite
        Me.artist_view_profile.Location = New System.Drawing.Point(1728, 5)
        Me.artist_view_profile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.artist_view_profile.Name = "artist_view_profile"
        Me.artist_view_profile.Size = New System.Drawing.Size(172, 48)
        Me.artist_view_profile.TabIndex = 12
        Me.artist_view_profile.Text = "PROFILE"
        Me.artist_view_profile.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Button5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button5.Location = New System.Drawing.Point(1550, 5)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(172, 49)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "ORDER STATUS"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'subcategory_combox
        '
        Me.subcategory_combox.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.subcategory_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subcategory_combox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subcategory_combox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.subcategory_combox.FormattingEnabled = True
        Me.subcategory_combox.Items.AddRange(New Object() {"2D Artist", "3D Artist"})
        Me.subcategory_combox.Location = New System.Drawing.Point(315, 12)
        Me.subcategory_combox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.subcategory_combox.Name = "subcategory_combox"
        Me.subcategory_combox.Size = New System.Drawing.Size(224, 33)
        Me.subcategory_combox.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(35, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(252, 34)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "SUBCATEGORY"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 1055)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'cards_flow
        '
        Me.cards_flow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cards_flow.Location = New System.Drawing.Point(365, 150)
        Me.cards_flow.Margin = New System.Windows.Forms.Padding(0)
        Me.cards_flow.Name = "cards_flow"
        Me.cards_flow.Padding = New System.Windows.Forms.Padding(20)
        Me.cards_flow.Size = New System.Drawing.Size(1533, 893)
        Me.cards_flow.TabIndex = 11
        '
        'home_buyer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.cards_flow)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "home_buyer"
        Me.Text = "Form3"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub username_label_Click(sender As Object, e As EventArgs)

    End Sub

    Friend WithEvents login_button As Button
    Friend WithEvents Panel1 As Panel

    Friend WithEvents Panel5 As Panel
    Friend WithEvents subcategory_combox As ComboBox
    Friend WithEvents Label12 As Label

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub
    Private Sub login_button_Click(sender As Object, e As EventArgs) Handles login_button.Click

        Dim categoryPage As New option_page()
        categoryPage.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form3_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        subcategory_combox.Items.Clear()

        subcategory_combox.Items.Add("Show All")
        subcategory_combox.Items.Add("3D Modeling")
        subcategory_combox.Items.Add("Character Design")
        subcategory_combox.Items.Add("Illustration")
        subcategory_combox.Items.Add("Digital Painting")


        subcategory_combox.SelectedIndex = -1

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AutoScroll = False
        Me.AutoScrollMinSize = New Size(0, 1000)

    End Sub

    Friend WithEvents Button5 As Button


    Friend WithEvents artist_view_profile As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cards_flow As FlowLayoutPanel
End Class
