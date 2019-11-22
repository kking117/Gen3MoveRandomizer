<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.patchfile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.startrand = New System.Windows.Forms.Button()
        Me.rndacc = New System.Windows.Forms.GroupBox()
        Me.balancestats = New System.Windows.Forms.CheckBox()
        Me.rndpp = New System.Windows.Forms.CheckBox()
        Me.rndaccurate = New System.Windows.Forms.CheckBox()
        Me.rndpower = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rndcat = New System.Windows.Forms.CheckBox()
        Me.rndeffect = New System.Windows.Forms.CheckBox()
        Me.rndtarget = New System.Windows.Forms.CheckBox()
        Me.rndtype = New System.Windows.Forms.CheckBox()
        Me.rndname = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstboxgame = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenRomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.context = New System.Windows.Forms.CheckBox()
        Me.rounder = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rndacc.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'patchfile
        '
        Me.patchfile.Location = New System.Drawing.Point(55, 27)
        Me.patchfile.Name = "patchfile"
        Me.patchfile.ReadOnly = True
        Me.patchfile.Size = New System.Drawing.Size(312, 20)
        Me.patchfile.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Target:"
        '
        'startrand
        '
        Me.startrand.Location = New System.Drawing.Point(373, 27)
        Me.startrand.Name = "startrand"
        Me.startrand.Size = New System.Drawing.Size(75, 23)
        Me.startrand.TabIndex = 2
        Me.startrand.Text = "Randomize"
        Me.startrand.UseVisualStyleBackColor = True
        '
        'rndacc
        '
        Me.rndacc.Controls.Add(Me.balancestats)
        Me.rndacc.Controls.Add(Me.rndpp)
        Me.rndacc.Controls.Add(Me.rndaccurate)
        Me.rndacc.Controls.Add(Me.rndpower)
        Me.rndacc.Location = New System.Drawing.Point(21, 53)
        Me.rndacc.Name = "rndacc"
        Me.rndacc.Size = New System.Drawing.Size(141, 118)
        Me.rndacc.TabIndex = 4
        Me.rndacc.TabStop = False
        Me.rndacc.Text = "Power, Accuracy and PP"
        '
        'balancestats
        '
        Me.balancestats.AutoSize = True
        Me.balancestats.Location = New System.Drawing.Point(6, 93)
        Me.balancestats.Name = "balancestats"
        Me.balancestats.Size = New System.Drawing.Size(121, 17)
        Me.balancestats.TabIndex = 13
        Me.balancestats.Text = "Balance Randomize"
        Me.ToolTip1.SetToolTip(Me.balancestats, "This forces all three options on." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attempts to balance out the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Power, Accuracy, " & _
                "PP and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Effect Chance to create" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "reasonable/balanced attacks.")
        Me.balancestats.UseVisualStyleBackColor = True
        '
        'rndpp
        '
        Me.rndpp.AutoSize = True
        Me.rndpp.Location = New System.Drawing.Point(6, 71)
        Me.rndpp.Name = "rndpp"
        Me.rndpp.Size = New System.Drawing.Size(96, 17)
        Me.rndpp.TabIndex = 12
        Me.rndpp.Text = "Randomize PP"
        Me.ToolTip1.SetToolTip(Me.rndpp, "Randomizes the total PP moves" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "have.")
        Me.rndpp.UseVisualStyleBackColor = True
        '
        'rndaccurate
        '
        Me.rndaccurate.AutoSize = True
        Me.rndaccurate.Location = New System.Drawing.Point(6, 48)
        Me.rndaccurate.Name = "rndaccurate"
        Me.rndaccurate.Size = New System.Drawing.Size(127, 17)
        Me.rndaccurate.TabIndex = 11
        Me.rndaccurate.Text = "Randomize Accuracy"
        Me.ToolTip1.SetToolTip(Me.rndaccurate, "Randomizes the accuracy of moves" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that depend on accuracy.")
        Me.rndaccurate.UseVisualStyleBackColor = True
        '
        'rndpower
        '
        Me.rndpower.AutoSize = True
        Me.rndpower.Location = New System.Drawing.Point(6, 25)
        Me.rndpower.Name = "rndpower"
        Me.rndpower.Size = New System.Drawing.Size(112, 17)
        Me.rndpower.TabIndex = 10
        Me.rndpower.Text = "Randomize Power"
        Me.ToolTip1.SetToolTip(Me.rndpower, "Randomizes the power of moves that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "deal damage.")
        Me.rndpower.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rndcat)
        Me.GroupBox3.Controls.Add(Me.rndeffect)
        Me.GroupBox3.Controls.Add(Me.rndtarget)
        Me.GroupBox3.Controls.Add(Me.rndtype)
        Me.GroupBox3.Location = New System.Drawing.Point(168, 54)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(141, 117)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Effects and Other"
        '
        'rndcat
        '
        Me.rndcat.AutoSize = True
        Me.rndcat.Location = New System.Drawing.Point(5, 89)
        Me.rndcat.Name = "rndcat"
        Me.rndcat.Size = New System.Drawing.Size(124, 17)
        Me.rndcat.TabIndex = 4
        Me.rndcat.Text = "Randomize Category"
        Me.ToolTip1.SetToolTip(Me.rndcat, resources.GetString("rndcat.ToolTip"))
        Me.rndcat.UseVisualStyleBackColor = True
        '
        'rndeffect
        '
        Me.rndeffect.AutoSize = True
        Me.rndeffect.Location = New System.Drawing.Point(5, 68)
        Me.rndeffect.Name = "rndeffect"
        Me.rndeffect.Size = New System.Drawing.Size(110, 17)
        Me.rndeffect.TabIndex = 3
        Me.rndeffect.Text = "Randomize Effect"
        Me.ToolTip1.SetToolTip(Me.rndeffect, "Randomizes the effect of the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "move and its effect chance" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as well as flags like" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
                "wether it makes contact" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "or not." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(It will also change the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "description of the" & _
                " move" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to match the effect!)")
        Me.rndeffect.UseVisualStyleBackColor = True
        '
        'rndtarget
        '
        Me.rndtarget.AutoSize = True
        Me.rndtarget.Location = New System.Drawing.Point(5, 47)
        Me.rndtarget.Name = "rndtarget"
        Me.rndtarget.Size = New System.Drawing.Size(113, 17)
        Me.rndtarget.TabIndex = 2
        Me.rndtarget.Text = "Randomize Target"
        Me.ToolTip1.SetToolTip(Me.rndtarget, "Randomizes the target(s) of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the attack." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(This will not make stat" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "boosting mo" & _
                "ves target" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "enemies or damaging" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "moves target the user.)")
        Me.rndtarget.UseVisualStyleBackColor = True
        '
        'rndtype
        '
        Me.rndtype.AutoSize = True
        Me.rndtype.Location = New System.Drawing.Point(5, 24)
        Me.rndtype.Name = "rndtype"
        Me.rndtype.Size = New System.Drawing.Size(106, 17)
        Me.rndtype.TabIndex = 1
        Me.rndtype.Text = "Randomize Type"
        Me.ToolTip1.SetToolTip(Me.rndtype, "Randomizes the attack's type." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Moves that are ??? type will" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "always have a bas" & _
                "e power of 10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if they deal damage due to how" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Gen 3 games work.)")
        Me.rndtype.UseVisualStyleBackColor = True
        '
        'rndname
        '
        Me.rndname.AutoSize = True
        Me.rndname.Location = New System.Drawing.Point(6, 16)
        Me.rndname.Name = "rndname"
        Me.rndname.Size = New System.Drawing.Size(115, 17)
        Me.rndname.TabIndex = 0
        Me.rndname.Text = "Randomize Names"
        Me.ToolTip1.SetToolTip(Me.rndname, "Combines two words from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a pool to create a name." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(This isn't context sensitiv" & _
                "e" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "so you could get a move" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "called FirePunch despite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "being water type)")
        Me.rndname.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstboxgame)
        Me.GroupBox1.Location = New System.Drawing.Point(315, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(135, 53)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ROM Version/Info"
        '
        'lstboxgame
        '
        Me.lstboxgame.FormattingEnabled = True
        Me.lstboxgame.Items.AddRange(New Object() {"None/Unsupported", "Ruby (U) 1.1", "Sapphire (U)  1.1", "Emerald (U)", "Fire Red (U) 1.0", "Fire Red (U) 1.1", "Leaf Green (U) 1.1"})
        Me.lstboxgame.Location = New System.Drawing.Point(8, 19)
        Me.lstboxgame.Name = "lstboxgame"
        Me.lstboxgame.Size = New System.Drawing.Size(121, 21)
        Me.lstboxgame.TabIndex = 0
        Me.lstboxgame.Text = "None/Unsupported"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(476, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenRomToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenRomToolStripMenuItem
        '
        Me.OpenRomToolStripMenuItem.Name = "OpenRomToolStripMenuItem"
        Me.OpenRomToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.OpenRomToolStripMenuItem.Text = "Open Rom"
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFile"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'context
        '
        Me.context.AutoSize = True
        Me.context.Location = New System.Drawing.Point(6, 36)
        Me.context.Name = "context"
        Me.context.Size = New System.Drawing.Size(76, 17)
        Me.context.TabIndex = 1
        Me.context.Text = "Contextual"
        Me.ToolTip1.SetToolTip(Me.context, "Actually renames" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "attacks based on their" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "type and category.")
        Me.context.UseVisualStyleBackColor = True
        '
        'rounder
        '
        Me.rounder.AutoSize = True
        Me.rounder.Location = New System.Drawing.Point(6, 16)
        Me.rounder.Name = "rounder"
        Me.rounder.Size = New System.Drawing.Size(97, 17)
        Me.rounder.TabIndex = 14
        Me.rounder.Text = "Rounded Stats"
        Me.ToolTip1.SetToolTip(Me.rounder, resources.GetString("rounder.ToolTip"))
        Me.rounder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.context)
        Me.GroupBox2.Controls.Add(Me.rndname)
        Me.GroupBox2.Location = New System.Drawing.Point(315, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(135, 58)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Naming"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rounder)
        Me.GroupBox4.Location = New System.Drawing.Point(21, 177)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(429, 39)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Last Minute Feature"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 239)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.rndacc)
        Me.Controls.Add(Me.startrand)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.patchfile)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(482, 268)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(482, 268)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gen3MoveRandomizer"
        Me.rndacc.ResumeLayout(False)
        Me.rndacc.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents patchfile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents startrand As System.Windows.Forms.Button
    Friend WithEvents rndacc As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rndpower As System.Windows.Forms.CheckBox
    Friend WithEvents rndaccurate As System.Windows.Forms.CheckBox
    Friend WithEvents balancestats As System.Windows.Forms.CheckBox
    Friend WithEvents rndpp As System.Windows.Forms.CheckBox
    Friend WithEvents rndname As System.Windows.Forms.CheckBox
    Friend WithEvents rndtype As System.Windows.Forms.CheckBox
    Friend WithEvents rndeffect As System.Windows.Forms.CheckBox
    Friend WithEvents rndtarget As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenRomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rndcat As System.Windows.Forms.CheckBox
    Friend WithEvents context As System.Windows.Forms.CheckBox
    Friend WithEvents lstboxgame As System.Windows.Forms.ComboBox
    Friend WithEvents rounder As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox

End Class
