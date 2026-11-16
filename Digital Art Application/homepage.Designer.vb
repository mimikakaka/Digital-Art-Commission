<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Homepage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Homepage))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.button = New System.Windows.Forms.Button()
        Me.gradientBox = New System.Windows.Forms.PictureBox()
        Me.username_txtbox = New System.Windows.Forms.TextBox()
        Me.username_label = New System.Windows.Forms.Label()
        Me.password_txtbox = New System.Windows.Forms.TextBox()
        Me.password_label = New System.Windows.Forms.Label()
        Me.Login_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.signup_link_button = New System.Windows.Forms.Button()
        Me.loginGroup = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.leftPanel = New System.Windows.Forms.PictureBox()
        CType(Me.gradientBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loginGroup.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leftPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'button
        '
        Me.button.Location = New System.Drawing.Point(0, 0)
        Me.button.Name = "button"
        Me.button.Size = New System.Drawing.Size(75, 23)
        Me.button.TabIndex = 0
        '
        'gradientBox
        '
        Me.gradientBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gradientBox.BackColor = System.Drawing.Color.Transparent
        Me.gradientBox.Image = CType(resources.GetObject("gradientBox.Image"), System.Drawing.Image)
        Me.gradientBox.Location = New System.Drawing.Point(0, 0)
        Me.gradientBox.Margin = New System.Windows.Forms.Padding(0)
        Me.gradientBox.Name = "gradientBox"
        Me.gradientBox.Size = New System.Drawing.Size(1979, 1077)
        Me.gradientBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.gradientBox.TabIndex = 7
        Me.gradientBox.TabStop = False
        '
        'username_txtbox
        '
        Me.username_txtbox.BackColor = System.Drawing.Color.FloralWhite
        Me.username_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_txtbox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.username_txtbox.Location = New System.Drawing.Point(319, 187)
        Me.username_txtbox.Name = "username_txtbox"
        Me.username_txtbox.Size = New System.Drawing.Size(651, 61)
        Me.username_txtbox.TabIndex = 16
        '
        'username_label
        '
        Me.username_label.AutoSize = True
        Me.username_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.username_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.username_label.Location = New System.Drawing.Point(24, 194)
        Me.username_label.Name = "username_label"
        Me.username_label.Size = New System.Drawing.Size(259, 54)
        Me.username_label.TabIndex = 17
        Me.username_label.Text = "Username"
        '
        'password_txtbox
        '
        Me.password_txtbox.BackColor = System.Drawing.Color.FloralWhite
        Me.password_txtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_txtbox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.password_txtbox.Location = New System.Drawing.Point(319, 267)
        Me.password_txtbox.Name = "password_txtbox"
        Me.password_txtbox.Size = New System.Drawing.Size(651, 61)
        Me.password_txtbox.TabIndex = 18
        '
        'password_label
        '
        Me.password_label.AutoSize = True
        Me.password_label.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.password_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.password_label.Location = New System.Drawing.Point(24, 274)
        Me.password_label.Name = "password_label"
        Me.password_label.Size = New System.Drawing.Size(248, 54)
        Me.password_label.TabIndex = 19
        Me.password_label.Text = "Password"
        '
        'Login_Button
        '
        Me.Login_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Login_Button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login_Button.ForeColor = System.Drawing.Color.FloralWhite
        Me.Login_Button.Location = New System.Drawing.Point(547, 334)
        Me.Login_Button.Name = "Login_Button"
        Me.Login_Button.Size = New System.Drawing.Size(215, 50)
        Me.Login_Button.TabIndex = 20
        Me.Login_Button.Text = "Log In"
        Me.Login_Button.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(446, 411)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Don't have an account?"
        '
        'signup_link_button
        '
        Me.signup_link_button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.signup_link_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signup_link_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.signup_link_button.Location = New System.Drawing.Point(677, 399)
        Me.signup_link_button.Name = "signup_link_button"
        Me.signup_link_button.Size = New System.Drawing.Size(151, 38)
        Me.signup_link_button.TabIndex = 21
        Me.signup_link_button.Text = "Sign Up"
        Me.signup_link_button.UseVisualStyleBackColor = False
        '
        'loginGroup
        '
        Me.loginGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loginGroup.BackColor = System.Drawing.Color.Transparent
        Me.loginGroup.Controls.Add(Me.signup_link_button)
        Me.loginGroup.Controls.Add(Me.Label2)
        Me.loginGroup.Controls.Add(Me.Login_Button)
        Me.loginGroup.Controls.Add(Me.password_label)
        Me.loginGroup.Controls.Add(Me.password_txtbox)
        Me.loginGroup.Controls.Add(Me.username_label)
        Me.loginGroup.Controls.Add(Me.username_txtbox)
        Me.loginGroup.Controls.Add(Me.PictureBox2)
        Me.loginGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.loginGroup.Location = New System.Drawing.Point(857, 227)
        Me.loginGroup.Name = "loginGroup"
        Me.loginGroup.Size = New System.Drawing.Size(983, 481)
        Me.loginGroup.TabIndex = 17
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(360, -24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(569, 228)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 28
        Me.PictureBox2.TabStop = False
        '
        'leftPanel
        '
        Me.leftPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftPanel.Image = CType(resources.GetObject("leftPanel.Image"), System.Drawing.Image)
        Me.leftPanel.Location = New System.Drawing.Point(0, 0)
        Me.leftPanel.Name = "leftPanel"
        Me.leftPanel.Size = New System.Drawing.Size(700, 1055)
        Me.leftPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.leftPanel.TabIndex = 18
        Me.leftPanel.TabStop = False
        '
        'Homepage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.leftPanel)
        Me.Controls.Add(Me.loginGroup)
        Me.Controls.Add(Me.gradientBox)
        Me.Name = "Homepage"
        Me.Text = "Form1"
        CType(Me.gradientBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loginGroup.ResumeLayout(False)
        Me.loginGroup.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leftPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents button As Button
    Friend WithEvents gradientBox As PictureBox
    Friend WithEvents username_txtbox As TextBox
    Friend WithEvents username_label As Label
    Friend WithEvents password_txtbox As TextBox
    Friend WithEvents password_label As Label
    Friend WithEvents Login_Button As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents signup_link_button As Button
    Friend WithEvents loginGroup As Panel
    Friend WithEvents leftPanel As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
