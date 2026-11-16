<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class orders_pendings_ayesha
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.add_orders_ayesha = New System.Windows.Forms.Button()
        Me.back_button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.orders_flow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel1.Controls.Add(Me.add_orders_ayesha)
        Me.Panel1.Controls.Add(Me.back_button)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 109)
        Me.Panel1.TabIndex = 0
        '
        'add_orders_ayesha
        '
        Me.add_orders_ayesha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.add_orders_ayesha.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.add_orders_ayesha.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_orders_ayesha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.add_orders_ayesha.Location = New System.Drawing.Point(1540, 35)
        Me.add_orders_ayesha.Name = "add_orders_ayesha"
        Me.add_orders_ayesha.Size = New System.Drawing.Size(162, 42)
        Me.add_orders_ayesha.TabIndex = 9
        Me.add_orders_ayesha.Text = "Add Orders"
        Me.add_orders_ayesha.UseVisualStyleBackColor = False
        '
        'back_button
        '
        Me.back_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.back_button.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.back_button.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.back_button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.back_button.Location = New System.Drawing.Point(1720, 35)
        Me.back_button.Name = "back_button"
        Me.back_button.Size = New System.Drawing.Size(162, 42)
        Me.back_button.TabIndex = 8
        Me.back_button.Text = "< BACK"
        Me.back_button.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(40, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 50)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "COMMISH"
        '
        'orders_flow
        '
        Me.orders_flow.AutoScroll = True
        Me.orders_flow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.orders_flow.Location = New System.Drawing.Point(0, 109)
        Me.orders_flow.Name = "orders_flow"
        Me.orders_flow.Padding = New System.Windows.Forms.Padding(20)
        Me.orders_flow.Size = New System.Drawing.Size(1924, 946)
        Me.orders_flow.TabIndex = 1
        '
        'orders_pendings_ayesha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.orders_flow)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "orders_pendings_ayesha"
        Me.Text = "Pending Orders"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents add_orders_ayesha As System.Windows.Forms.Button
    Friend WithEvents back_button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents orders_flow As System.Windows.Forms.FlowLayoutPanel

End Class
