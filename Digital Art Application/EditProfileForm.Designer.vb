<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditProfileForm
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditProfileForm))
        Me.edit_panel = New System.Windows.Forms.Panel()
        Me.Form = New System.Windows.Forms.Label()
        Me.gform_txtbox = New System.Windows.Forms.TextBox()
        Me.job_txtbox = New System.Windows.Forms.ComboBox()
        Me.browse_button = New System.Windows.Forms.Button()
        Me.profile_pic_box = New System.Windows.Forms.PictureBox()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.save_button = New System.Windows.Forms.Button()
        Me.place_txtbox = New System.Windows.Forms.TextBox()
        Me.place_label = New System.Windows.Forms.Label()
        Me.insta_txtbox = New System.Windows.Forms.TextBox()
        Me.insta_label = New System.Windows.Forms.Label()
        Me.job_label = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.change_password_button = New System.Windows.Forms.Button()
        Me.edit_panel.SuspendLayout()
        CType(Me.profile_pic_box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit_panel
        '
        Me.edit_panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edit_panel.BackColor = System.Drawing.Color.Transparent
        Me.edit_panel.Controls.Add(Me.change_password_button)
        Me.edit_panel.Controls.Add(Me.Label1)
        Me.edit_panel.Controls.Add(Me.Form)
        Me.edit_panel.Controls.Add(Me.gform_txtbox)
        Me.edit_panel.Controls.Add(Me.job_txtbox)
        Me.edit_panel.Controls.Add(Me.browse_button)
        Me.edit_panel.Controls.Add(Me.profile_pic_box)
        Me.edit_panel.Controls.Add(Me.cancel_button)
        Me.edit_panel.Controls.Add(Me.save_button)
        Me.edit_panel.Controls.Add(Me.place_txtbox)
        Me.edit_panel.Controls.Add(Me.place_label)
        Me.edit_panel.Controls.Add(Me.insta_txtbox)
        Me.edit_panel.Controls.Add(Me.insta_label)
        Me.edit_panel.Controls.Add(Me.job_label)
        Me.edit_panel.Location = New System.Drawing.Point(151, 136)
        Me.edit_panel.Name = "edit_panel"
        Me.edit_panel.Size = New System.Drawing.Size(978, 658)
        Me.edit_panel.TabIndex = 8
        '
        'Form
        '
        Me.Form.AutoSize = True
        Me.Form.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Form.Location = New System.Drawing.Point(83, 427)
        Me.Form.Name = "Form"
        Me.Form.Size = New System.Drawing.Size(100, 38)
        Me.Form.TabIndex = 21
        Me.Form.Text = "Form"
        '
        'gform_txtbox
        '
        Me.gform_txtbox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gform_txtbox.Location = New System.Drawing.Point(285, 419)
        Me.gform_txtbox.Name = "gform_txtbox"
        Me.gform_txtbox.Size = New System.Drawing.Size(450, 46)
        Me.gform_txtbox.TabIndex = 20
        '
        'job_txtbox
        '
        Me.job_txtbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.job_txtbox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.job_txtbox.FormattingEnabled = True
        Me.job_txtbox.Items.AddRange(New Object() {"2D Artist", "3D Artist"})
        Me.job_txtbox.Location = New System.Drawing.Point(285, 268)
        Me.job_txtbox.Name = "job_txtbox"
        Me.job_txtbox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.job_txtbox.Size = New System.Drawing.Size(450, 46)
        Me.job_txtbox.TabIndex = 19
        '
        'browse_button
        '
        Me.browse_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browse_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.browse_button.Location = New System.Drawing.Point(347, 217)
        Me.browse_button.Name = "browse_button"
        Me.browse_button.Size = New System.Drawing.Size(216, 40)
        Me.browse_button.TabIndex = 18
        Me.browse_button.Text = "Choose Photo"
        Me.browse_button.UseVisualStyleBackColor = True
        '
        'profile_pic_box
        '
        Me.profile_pic_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.profile_pic_box.Location = New System.Drawing.Point(378, 61)
        Me.profile_pic_box.Name = "profile_pic_box"
        Me.profile_pic_box.Size = New System.Drawing.Size(150, 150)
        Me.profile_pic_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.profile_pic_box.TabIndex = 17
        Me.profile_pic_box.TabStop = False
        '
        'cancel_button
        '
        Me.cancel_button.BackColor = System.Drawing.Color.LemonChiffon
        Me.cancel_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel_button.Location = New System.Drawing.Point(438, 544)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.Size = New System.Drawing.Size(137, 40)
        Me.cancel_button.TabIndex = 15
        Me.cancel_button.Text = "Cancel"
        Me.cancel_button.UseVisualStyleBackColor = False
        '
        'save_button
        '
        Me.save_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_button.Location = New System.Drawing.Point(331, 544)
        Me.save_button.Name = "save_button"
        Me.save_button.Size = New System.Drawing.Size(101, 40)
        Me.save_button.TabIndex = 14
        Me.save_button.Text = "Save"
        Me.save_button.UseVisualStyleBackColor = True
        '
        'place_txtbox
        '
        Me.place_txtbox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.place_txtbox.Location = New System.Drawing.Point(285, 367)
        Me.place_txtbox.Name = "place_txtbox"
        Me.place_txtbox.Size = New System.Drawing.Size(450, 46)
        Me.place_txtbox.TabIndex = 13
        '
        'place_label
        '
        Me.place_label.AutoSize = True
        Me.place_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.place_label.Location = New System.Drawing.Point(83, 375)
        Me.place_label.Name = "place_label"
        Me.place_label.Size = New System.Drawing.Size(158, 38)
        Me.place_label.TabIndex = 12
        Me.place_label.Text = "Location"
        '
        'insta_txtbox
        '
        Me.insta_txtbox.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insta_txtbox.Location = New System.Drawing.Point(285, 317)
        Me.insta_txtbox.Name = "insta_txtbox"
        Me.insta_txtbox.Size = New System.Drawing.Size(450, 46)
        Me.insta_txtbox.TabIndex = 11
        '
        'insta_label
        '
        Me.insta_label.AutoSize = True
        Me.insta_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insta_label.Location = New System.Drawing.Point(83, 325)
        Me.insta_label.Name = "insta_label"
        Me.insta_label.Size = New System.Drawing.Size(181, 38)
        Me.insta_label.TabIndex = 10
        Me.insta_label.Text = "Instagram"
        '
        'job_label
        '
        Me.job_label.AutoSize = True
        Me.job_label.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.job_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.job_label.Location = New System.Drawing.Point(83, 276)
        Me.job_label.Name = "job_label"
        Me.job_label.Size = New System.Drawing.Size(156, 38)
        Me.job_label.TabIndex = 8
        Me.job_label.Text = "Job Title"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1942, 1102)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 479)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 38)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Change Password"
        '
        'change_password_button
        '
        Me.change_password_button.BackColor = System.Drawing.Color.LemonChiffon
        Me.change_password_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.change_password_button.Location = New System.Drawing.Point(399, 479)
        Me.change_password_button.Name = "change_password_button"
        Me.change_password_button.Size = New System.Drawing.Size(336, 40)
        Me.change_password_button.TabIndex = 24
        Me.change_password_button.Text = "Change Password"
        Me.change_password_button.UseVisualStyleBackColor = False
        '
        'EditProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.edit_panel)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.Name = "EditProfileForm"
        Me.Text = "EditProfileForm"
        Me.edit_panel.ResumeLayout(False)
        Me.edit_panel.PerformLayout()
        CType(Me.profile_pic_box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents edit_panel As Panel
    Friend WithEvents cancel_button As Button
    Friend WithEvents save_button As Button
    Friend WithEvents place_txtbox As TextBox
    Friend WithEvents place_label As Label
    Friend WithEvents insta_txtbox As TextBox
    Friend WithEvents insta_label As Label
    Friend WithEvents job_label As Label
    Friend WithEvents profile_pic_box As PictureBox
    Friend WithEvents browse_button As Button
    Friend WithEvents job_txtbox As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents gform_txtbox As TextBox
    Friend WithEvents Form As Label
    Friend WithEvents change_password_button As Button
    Friend WithEvents Label1 As Label
End Class
