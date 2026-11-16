<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUpForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignUpForm))
        Me.gradientBox = New System.Windows.Forms.PictureBox()
        Me.signup_panel = New System.Windows.Forms.Panel()
        Me.back_button = New System.Windows.Forms.Button()
        Me.signup_button = New System.Windows.Forms.Button()
        Me.confirm_txtbox = New System.Windows.Forms.TextBox()
        Me.confirm_label = New System.Windows.Forms.Label()
        Me.password_label = New System.Windows.Forms.Label()
        Me.password_txtbox = New System.Windows.Forms.TextBox()
        Me.username_label = New System.Windows.Forms.Label()
        Me.username_txtbox = New System.Windows.Forms.TextBox()
        Me.email_label = New System.Windows.Forms.Label()
        Me.email_txtbox = New System.Windows.Forms.TextBox()
        Me.first_label = New System.Windows.Forms.Label()
        Me.first_txtbox = New System.Windows.Forms.TextBox()
        Me.last_label = New System.Windows.Forms.Label()
        Me.last_txtbox = New System.Windows.Forms.TextBox()
        CType(Me.gradientBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.signup_panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'gradientBox
        '
        Me.gradientBox.BackColor = System.Drawing.Color.Transparent
        Me.gradientBox.Image = CType(resources.GetObject("gradientBox.Image"), System.Drawing.Image)
        Me.gradientBox.Location = New System.Drawing.Point(-6, -13)
        Me.gradientBox.Name = "gradientBox"
        Me.gradientBox.Size = New System.Drawing.Size(2074, 1187)
        Me.gradientBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.gradientBox.TabIndex = 8
        Me.gradientBox.TabStop = False
        '
        'signup_panel
        '
        Me.signup_panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.signup_panel.Controls.Add(Me.last_label)
        Me.signup_panel.Controls.Add(Me.last_txtbox)
        Me.signup_panel.Controls.Add(Me.first_label)
        Me.signup_panel.Controls.Add(Me.first_txtbox)
        Me.signup_panel.Controls.Add(Me.back_button)
        Me.signup_panel.Controls.Add(Me.signup_button)
        Me.signup_panel.Controls.Add(Me.confirm_txtbox)
        Me.signup_panel.Controls.Add(Me.confirm_label)
        Me.signup_panel.Controls.Add(Me.password_label)
        Me.signup_panel.Controls.Add(Me.password_txtbox)
        Me.signup_panel.Controls.Add(Me.username_label)
        Me.signup_panel.Controls.Add(Me.username_txtbox)
        Me.signup_panel.Controls.Add(Me.email_label)
        Me.signup_panel.Controls.Add(Me.email_txtbox)
        Me.signup_panel.Location = New System.Drawing.Point(396, 182)
        Me.signup_panel.Name = "signup_panel"
        Me.signup_panel.Size = New System.Drawing.Size(1312, 567)
        Me.signup_panel.TabIndex = 19
        '
        'back_button
        '
        Me.back_button.BackColor = System.Drawing.Color.LemonChiffon
        Me.back_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.back_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.back_button.Location = New System.Drawing.Point(901, 416)
        Me.back_button.Name = "back_button"
        Me.back_button.Size = New System.Drawing.Size(130, 42)
        Me.back_button.TabIndex = 28
        Me.back_button.Text = "BACK"
        Me.back_button.UseVisualStyleBackColor = False
        '
        'signup_button
        '
        Me.signup_button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.signup_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signup_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.signup_button.Location = New System.Drawing.Point(756, 416)
        Me.signup_button.Name = "signup_button"
        Me.signup_button.Size = New System.Drawing.Size(130, 42)
        Me.signup_button.TabIndex = 21
        Me.signup_button.Text = "Sign Up"
        Me.signup_button.UseVisualStyleBackColor = False
        '
        'confirm_txtbox
        '
        Me.confirm_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirm_txtbox.Location = New System.Drawing.Point(425, 356)
        Me.confirm_txtbox.Name = "confirm_txtbox"
        Me.confirm_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.confirm_txtbox.TabIndex = 26
        Me.confirm_txtbox.UseSystemPasswordChar = True
        '
        'confirm_label
        '
        Me.confirm_label.AutoSize = True
        Me.confirm_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.confirm_label.Cursor = System.Windows.Forms.Cursors.Default
        Me.confirm_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirm_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.confirm_label.Location = New System.Drawing.Point(85, 353)
        Me.confirm_label.Name = "confirm_label"
        Me.confirm_label.Size = New System.Drawing.Size(312, 38)
        Me.confirm_label.TabIndex = 25
        Me.confirm_label.Text = "Confirm Password"
        '
        'password_label
        '
        Me.password_label.AutoSize = True
        Me.password_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.password_label.Cursor = System.Windows.Forms.Cursors.Default
        Me.password_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.password_label.Location = New System.Drawing.Point(226, 305)
        Me.password_label.Name = "password_label"
        Me.password_label.Size = New System.Drawing.Size(177, 38)
        Me.password_label.TabIndex = 24
        Me.password_label.Text = "Password"
        '
        'password_txtbox
        '
        Me.password_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_txtbox.Location = New System.Drawing.Point(425, 305)
        Me.password_txtbox.Name = "password_txtbox"
        Me.password_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.password_txtbox.TabIndex = 23
        Me.password_txtbox.UseSystemPasswordChar = True
        '
        'username_label
        '
        Me.username_label.AutoSize = True
        Me.username_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.username_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.username_label.Location = New System.Drawing.Point(220, 254)
        Me.username_label.Name = "username_label"
        Me.username_label.Size = New System.Drawing.Size(183, 38)
        Me.username_label.TabIndex = 22
        Me.username_label.Text = "Username"
        '
        'username_txtbox
        '
        Me.username_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_txtbox.Location = New System.Drawing.Point(425, 254)
        Me.username_txtbox.Name = "username_txtbox"
        Me.username_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.username_txtbox.TabIndex = 21
        '
        'email_label
        '
        Me.email_label.AutoSize = True
        Me.email_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.email_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.email_label.Location = New System.Drawing.Point(299, 107)
        Me.email_label.Name = "email_label"
        Me.email_label.Size = New System.Drawing.Size(106, 38)
        Me.email_label.TabIndex = 20
        Me.email_label.Text = "Email"
        '
        'email_txtbox
        '
        Me.email_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_txtbox.Location = New System.Drawing.Point(425, 101)
        Me.email_txtbox.Name = "email_txtbox"
        Me.email_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.email_txtbox.TabIndex = 19
        '
        'first_label
        '
        Me.first_label.AutoSize = True
        Me.first_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.first_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.first_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.first_label.Location = New System.Drawing.Point(211, 159)
        Me.first_label.Name = "first_label"
        Me.first_label.Size = New System.Drawing.Size(192, 38)
        Me.first_label.TabIndex = 30
        Me.first_label.Text = "First Name"
        '
        'first_txtbox
        '
        Me.first_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.first_txtbox.Location = New System.Drawing.Point(425, 152)
        Me.first_txtbox.MaxLength = 50
        Me.first_txtbox.Name = "first_txtbox"
        Me.first_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.first_txtbox.TabIndex = 29
        '
        'last_label
        '
        Me.last_label.AutoSize = True
        Me.last_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.last_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.last_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.last_label.Location = New System.Drawing.Point(214, 206)
        Me.last_label.Name = "last_label"
        Me.last_label.Size = New System.Drawing.Size(189, 38)
        Me.last_label.TabIndex = 32
        Me.last_label.Text = "Last Name"
        '
        'last_txtbox
        '
        Me.last_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.last_txtbox.Location = New System.Drawing.Point(425, 203)
        Me.last_txtbox.MaxLength = 50
        Me.last_txtbox.Name = "last_txtbox"
        Me.last_txtbox.Size = New System.Drawing.Size(604, 45)
        Me.last_txtbox.TabIndex = 31
        '
        'SignUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.signup_panel)
        Me.Controls.Add(Me.gradientBox)
        Me.Name = "SignUpForm"
        Me.Text = "SignUpForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gradientBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.signup_panel.ResumeLayout(False)
        Me.signup_panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gradientBox As PictureBox
    Friend WithEvents signup_panel As Panel
    Friend WithEvents back_button As Button
    Friend WithEvents signup_button As Button
    Friend WithEvents confirm_txtbox As TextBox
    Friend WithEvents confirm_label As Label
    Friend WithEvents password_label As Label
    Friend WithEvents password_txtbox As TextBox
    Friend WithEvents username_label As Label
    Friend WithEvents username_txtbox As TextBox
    Friend WithEvents email_label As Label
    Friend WithEvents email_txtbox As TextBox
    Friend WithEvents last_label As Label
    Friend WithEvents last_txtbox As TextBox
    Friend WithEvents first_label As Label
    Friend WithEvents first_txtbox As TextBox
End Class
