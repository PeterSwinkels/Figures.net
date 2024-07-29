<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceWindow
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
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.OptionMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnimateFiguresMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DrawRadiiMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionMainMenu, Me.InformationMainMenu})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(284, 24)
        Me.MenuBar.TabIndex = 0
        Me.MenuBar.Text = "MenuStrip1"
        '
        'OptionMainMenu
        '
        Me.OptionMainMenu.AutoToolTip = True
        Me.OptionMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnimateFiguresMenu, Me.DrawRadiiMenu})
        Me.OptionMainMenu.Name = "OptionMainMenu"
        Me.OptionMainMenu.Size = New System.Drawing.Size(61, 20)
        Me.OptionMainMenu.Text = "&Options"
        '
        'AnimateFiguresMenu
        '
        Me.AnimateFiguresMenu.Name = "AnimateFiguresMenu"
        Me.AnimateFiguresMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AnimateFiguresMenu.Size = New System.Drawing.Size(202, 22)
        Me.AnimateFiguresMenu.Text = "&Animate Figures"
        '
        'DrawRadiiMenu
        '
        Me.DrawRadiiMenu.Name = "DrawRadiiMenu"
        Me.DrawRadiiMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.DrawRadiiMenu.Size = New System.Drawing.Size(202, 22)
        Me.DrawRadiiMenu.Text = "&Draw Radii"
        '
        'InformationMainMenu
        '
        Me.InformationMainMenu.Name = "InformationMainMenu"
        Me.InformationMainMenu.Size = New System.Drawing.Size(82, 20)
        Me.InformationMainMenu.Text = "&Information"
        '
        'InterfaceWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.MenuBar)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuBar
        Me.Name = "InterfaceWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionMainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnimateFiguresMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DrawRadiiMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformationMainMenu As System.Windows.Forms.ToolStripMenuItem
End Class
