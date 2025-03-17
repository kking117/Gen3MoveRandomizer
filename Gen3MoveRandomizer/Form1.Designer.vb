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
        Me.checkbox_rnd_pp = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_effect = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_accuracy = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_power = New System.Windows.Forms.CheckBox()
        Me.checkbox_balance = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.checkbox_rnd_category = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_element = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_name = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstboxgame = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenRomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.checkbox_rnd_name_context = New System.Windows.Forms.CheckBox()
        Me.checkbox_limit_effects = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_anim_context = New System.Windows.Forms.CheckBox()
        Me.checkbox_rnd_anim = New System.Windows.Forms.CheckBox()
        Me.checkbox_ignore_struggle = New System.Windows.Forms.CheckBox()
        Me.checkbox_tweak_semi = New System.Windows.Forms.CheckBox()
        Me.checkbox_buff_normal = New System.Windows.Forms.CheckBox()
        Me.checkbox_mod_priority = New System.Windows.Forms.CheckBox()
        Me.checkbox_mod_accuracy = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rndacc.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'patchfile
        '
        Me.patchfile.Location = New System.Drawing.Point(65, 27)
        Me.patchfile.Name = "patchfile"
        Me.patchfile.ReadOnly = True
        Me.patchfile.Size = New System.Drawing.Size(385, 20)
        Me.patchfile.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Target:"
        '
        'startrand
        '
        Me.startrand.Location = New System.Drawing.Point(21, 53)
        Me.startrand.Name = "startrand"
        Me.startrand.Size = New System.Drawing.Size(177, 48)
        Me.startrand.TabIndex = 2
        Me.startrand.Text = "Randomize"
        Me.startrand.UseVisualStyleBackColor = True
        '
        'rndacc
        '
        Me.rndacc.Controls.Add(Me.checkbox_rnd_pp)
        Me.rndacc.Controls.Add(Me.checkbox_rnd_effect)
        Me.rndacc.Controls.Add(Me.checkbox_rnd_accuracy)
        Me.rndacc.Controls.Add(Me.checkbox_rnd_power)
        Me.rndacc.Location = New System.Drawing.Point(21, 107)
        Me.rndacc.Name = "rndacc"
        Me.rndacc.Size = New System.Drawing.Size(140, 100)
        Me.rndacc.TabIndex = 4
        Me.rndacc.TabStop = False
        Me.rndacc.Text = "Primary Stats + Effect"
        '
        'checkbox_rnd_pp
        '
        Me.checkbox_rnd_pp.AutoSize = True
        Me.checkbox_rnd_pp.Location = New System.Drawing.Point(6, 60)
        Me.checkbox_rnd_pp.Name = "checkbox_rnd_pp"
        Me.checkbox_rnd_pp.Size = New System.Drawing.Size(96, 17)
        Me.checkbox_rnd_pp.TabIndex = 12
        Me.checkbox_rnd_pp.Text = "Randomize PP"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_pp, "Randomizes the PP of moves.")
        Me.checkbox_rnd_pp.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_effect
        '
        Me.checkbox_rnd_effect.AutoSize = True
        Me.checkbox_rnd_effect.Location = New System.Drawing.Point(6, 80)
        Me.checkbox_rnd_effect.Name = "checkbox_rnd_effect"
        Me.checkbox_rnd_effect.Size = New System.Drawing.Size(110, 17)
        Me.checkbox_rnd_effect.TabIndex = 3
        Me.checkbox_rnd_effect.Text = "Randomize Effect"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_effect, "Randomizes the effects of moves." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Also changes the:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Effect Chance" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Target" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fla" &
        "gs (makes contact, ignores protect, etc)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Priority Bracket" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description (matches" &
        " the new effect)")
        Me.checkbox_rnd_effect.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_accuracy
        '
        Me.checkbox_rnd_accuracy.AutoSize = True
        Me.checkbox_rnd_accuracy.Location = New System.Drawing.Point(6, 40)
        Me.checkbox_rnd_accuracy.Name = "checkbox_rnd_accuracy"
        Me.checkbox_rnd_accuracy.Size = New System.Drawing.Size(127, 17)
        Me.checkbox_rnd_accuracy.TabIndex = 11
        Me.checkbox_rnd_accuracy.Text = "Randomize Accuracy"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_accuracy, "Randomizes the accuracy of moves that use it.")
        Me.checkbox_rnd_accuracy.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_power
        '
        Me.checkbox_rnd_power.AutoSize = True
        Me.checkbox_rnd_power.Location = New System.Drawing.Point(6, 20)
        Me.checkbox_rnd_power.Name = "checkbox_rnd_power"
        Me.checkbox_rnd_power.Size = New System.Drawing.Size(112, 17)
        Me.checkbox_rnd_power.TabIndex = 10
        Me.checkbox_rnd_power.Text = "Randomize Power"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_power, "Randomizes the power of moves that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "deal damage.")
        Me.checkbox_rnd_power.UseVisualStyleBackColor = True
        '
        'checkbox_balance
        '
        Me.checkbox_balance.AutoSize = True
        Me.checkbox_balance.Location = New System.Drawing.Point(6, 17)
        Me.checkbox_balance.Name = "checkbox_balance"
        Me.checkbox_balance.Size = New System.Drawing.Size(106, 17)
        Me.checkbox_balance.TabIndex = 13
        Me.checkbox_balance.Text = "Balanced Moves"
        Me.ToolTip1.SetToolTip(Me.checkbox_balance, "Forces all settings in ""Primary Stats + Effect"" to be enabled." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attempts to mak" &
        "e balanced moves for less chaotic playthroughs.")
        Me.checkbox_balance.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.checkbox_rnd_category)
        Me.GroupBox3.Controls.Add(Me.checkbox_rnd_element)
        Me.GroupBox3.Location = New System.Drawing.Point(168, 107)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(140, 100)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Typing + Misc"
        '
        'checkbox_rnd_category
        '
        Me.checkbox_rnd_category.AutoSize = True
        Me.checkbox_rnd_category.Location = New System.Drawing.Point(5, 40)
        Me.checkbox_rnd_category.Name = "checkbox_rnd_category"
        Me.checkbox_rnd_category.Size = New System.Drawing.Size(124, 17)
        Me.checkbox_rnd_category.TabIndex = 4
        Me.checkbox_rnd_category.Text = "Randomize Category"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_category, resources.GetString("checkbox_rnd_category.ToolTip"))
        Me.checkbox_rnd_category.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_element
        '
        Me.checkbox_rnd_element.AutoSize = True
        Me.checkbox_rnd_element.Location = New System.Drawing.Point(5, 20)
        Me.checkbox_rnd_element.Name = "checkbox_rnd_element"
        Me.checkbox_rnd_element.Size = New System.Drawing.Size(106, 17)
        Me.checkbox_rnd_element.TabIndex = 1
        Me.checkbox_rnd_element.Text = "Randomize Type"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_element, "Randomizes the typing of moves.")
        Me.checkbox_rnd_element.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_name
        '
        Me.checkbox_rnd_name.AutoSize = True
        Me.checkbox_rnd_name.Location = New System.Drawing.Point(6, 20)
        Me.checkbox_rnd_name.Name = "checkbox_rnd_name"
        Me.checkbox_rnd_name.Size = New System.Drawing.Size(115, 17)
        Me.checkbox_rnd_name.TabIndex = 0
        Me.checkbox_rnd_name.Text = "Randomize Names"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_name, "Combines two words from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a pool to create a name.")
        Me.checkbox_rnd_name.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstboxgame)
        Me.GroupBox1.Location = New System.Drawing.Point(204, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 48)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ROM Version/Preset"
        '
        'lstboxgame
        '
        Me.lstboxgame.FormattingEnabled = True
        Me.lstboxgame.Items.AddRange(New Object() {"Unsupported", "Custom", "Fire Red USA 1.0", "Emerald USA"})
        Me.lstboxgame.Location = New System.Drawing.Point(8, 19)
        Me.lstboxgame.Name = "lstboxgame"
        Me.lstboxgame.Size = New System.Drawing.Size(228, 21)
        Me.lstboxgame.TabIndex = 0
        Me.lstboxgame.Text = "Unsupported"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(466, 24)
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
        'checkbox_rnd_name_context
        '
        Me.checkbox_rnd_name_context.AutoSize = True
        Me.checkbox_rnd_name_context.Location = New System.Drawing.Point(6, 40)
        Me.checkbox_rnd_name_context.Name = "checkbox_rnd_name_context"
        Me.checkbox_rnd_name_context.Size = New System.Drawing.Size(76, 17)
        Me.checkbox_rnd_name_context.TabIndex = 1
        Me.checkbox_rnd_name_context.Text = "Contextual"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_name_context, "Names moves based on their type and category to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "form somewhat logical names.")
        Me.checkbox_rnd_name_context.UseVisualStyleBackColor = True
        '
        'checkbox_limit_effects
        '
        Me.checkbox_limit_effects.AutoSize = True
        Me.checkbox_limit_effects.Location = New System.Drawing.Point(6, 37)
        Me.checkbox_limit_effects.Name = "checkbox_limit_effects"
        Me.checkbox_limit_effects.Size = New System.Drawing.Size(119, 17)
        Me.checkbox_limit_effects.TabIndex = 15
        Me.checkbox_limit_effects.Text = "Limit Certain Effects"
        Me.ToolTip1.SetToolTip(Me.checkbox_limit_effects, resources.GetString("checkbox_limit_effects.ToolTip"))
        Me.checkbox_limit_effects.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_anim_context
        '
        Me.checkbox_rnd_anim_context.AutoSize = True
        Me.checkbox_rnd_anim_context.Location = New System.Drawing.Point(6, 40)
        Me.checkbox_rnd_anim_context.Name = "checkbox_rnd_anim_context"
        Me.checkbox_rnd_anim_context.Size = New System.Drawing.Size(76, 17)
        Me.checkbox_rnd_anim_context.TabIndex = 1
        Me.checkbox_rnd_anim_context.Text = "Contextual"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_anim_context, "Animations are selected based on their type and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "category rather than completely " &
        "random." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note that some move effects can enforce a specific" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "animation.")
        Me.checkbox_rnd_anim_context.UseVisualStyleBackColor = True
        '
        'checkbox_rnd_anim
        '
        Me.checkbox_rnd_anim.AutoSize = True
        Me.checkbox_rnd_anim.Location = New System.Drawing.Point(6, 20)
        Me.checkbox_rnd_anim.Name = "checkbox_rnd_anim"
        Me.checkbox_rnd_anim.Size = New System.Drawing.Size(133, 17)
        Me.checkbox_rnd_anim.TabIndex = 0
        Me.checkbox_rnd_anim.Text = "Randomize Animations"
        Me.ToolTip1.SetToolTip(Me.checkbox_rnd_anim, "Gives moves a random animation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from the game itself.")
        Me.checkbox_rnd_anim.UseVisualStyleBackColor = True
        '
        'checkbox_ignore_struggle
        '
        Me.checkbox_ignore_struggle.AutoSize = True
        Me.checkbox_ignore_struggle.Location = New System.Drawing.Point(6, 20)
        Me.checkbox_ignore_struggle.Name = "checkbox_ignore_struggle"
        Me.checkbox_ignore_struggle.Size = New System.Drawing.Size(98, 17)
        Me.checkbox_ignore_struggle.TabIndex = 13
        Me.checkbox_ignore_struggle.Text = "Ignore Struggle"
        Me.ToolTip1.SetToolTip(Me.checkbox_ignore_struggle, "The move ""Struggle"" will be left untouched by randomization.")
        Me.checkbox_ignore_struggle.UseVisualStyleBackColor = True
        '
        'checkbox_tweak_semi
        '
        Me.checkbox_tweak_semi.AutoSize = True
        Me.checkbox_tweak_semi.Location = New System.Drawing.Point(6, 40)
        Me.checkbox_tweak_semi.Name = "checkbox_tweak_semi"
        Me.checkbox_tweak_semi.Size = New System.Drawing.Size(114, 17)
        Me.checkbox_tweak_semi.TabIndex = 15
        Me.checkbox_tweak_semi.Text = "Ignore Semi-Invuln"
        Me.ToolTip1.SetToolTip(Me.checkbox_tweak_semi, resources.GetString("checkbox_tweak_semi.ToolTip"))
        Me.checkbox_tweak_semi.UseVisualStyleBackColor = True
        '
        'checkbox_buff_normal
        '
        Me.checkbox_buff_normal.AutoSize = True
        Me.checkbox_buff_normal.Location = New System.Drawing.Point(6, 57)
        Me.checkbox_buff_normal.Name = "checkbox_buff_normal"
        Me.checkbox_buff_normal.Size = New System.Drawing.Size(108, 17)
        Me.checkbox_buff_normal.TabIndex = 16
        Me.checkbox_buff_normal.Text = "Buff Normal Type"
        Me.ToolTip1.SetToolTip(Me.checkbox_buff_normal, "Allows Normal attacks to roll slightly higher stats.")
        Me.checkbox_buff_normal.UseVisualStyleBackColor = True
        '
        'checkbox_mod_priority
        '
        Me.checkbox_mod_priority.AutoSize = True
        Me.checkbox_mod_priority.Location = New System.Drawing.Point(6, 20)
        Me.checkbox_mod_priority.Name = "checkbox_mod_priority"
        Me.checkbox_mod_priority.Size = New System.Drawing.Size(101, 17)
        Me.checkbox_mod_priority.TabIndex = 13
        Me.checkbox_mod_priority.Text = "Upgrade Priority"
        Me.ToolTip1.SetToolTip(Me.checkbox_mod_priority, "Moves with a Priority of 0 can be upgraded" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to +1 Priority.")
        Me.checkbox_mod_priority.UseVisualStyleBackColor = True
        '
        'checkbox_mod_accuracy
        '
        Me.checkbox_mod_accuracy.AutoSize = True
        Me.checkbox_mod_accuracy.Location = New System.Drawing.Point(6, 40)
        Me.checkbox_mod_accuracy.Name = "checkbox_mod_accuracy"
        Me.checkbox_mod_accuracy.Size = New System.Drawing.Size(115, 17)
        Me.checkbox_mod_accuracy.TabIndex = 15
        Me.checkbox_mod_accuracy.Text = "Upgrade Accuracy"
        Me.ToolTip1.SetToolTip(Me.checkbox_mod_accuracy, "HACK FEATURE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Requires a patched ROM that" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "supports bypassing accuracy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "checks wh" &
        "en a move has 0 accuracy." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Moves can be Upgraded to bypass" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "accuracy checks.")
        Me.checkbox_mod_accuracy.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.checkbox_rnd_name_context)
        Me.GroupBox2.Controls.Add(Me.checkbox_rnd_name)
        Me.GroupBox2.Location = New System.Drawing.Point(319, 107)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 97)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Naming"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.checkbox_buff_normal)
        Me.GroupBox4.Controls.Add(Me.checkbox_balance)
        Me.GroupBox4.Controls.Add(Me.checkbox_limit_effects)
        Me.GroupBox4.Location = New System.Drawing.Point(21, 218)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(140, 79)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Balancing"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.checkbox_rnd_anim_context)
        Me.GroupBox6.Controls.Add(Me.checkbox_rnd_anim)
        Me.GroupBox6.Location = New System.Drawing.Point(319, 218)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(140, 79)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Animation"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.checkbox_ignore_struggle)
        Me.GroupBox5.Controls.Add(Me.checkbox_tweak_semi)
        Me.GroupBox5.Location = New System.Drawing.Point(168, 218)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(140, 79)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Move Specific"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.checkbox_mod_priority)
        Me.GroupBox7.Controls.Add(Me.checkbox_mod_accuracy)
        Me.GroupBox7.Location = New System.Drawing.Point(21, 303)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(438, 79)
        Me.GroupBox7.TabIndex = 17
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Other"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 389)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
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
        Me.MaximumSize = New System.Drawing.Size(482, 428)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(482, 428)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gen3MoveRandomizer v1.1.0"
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
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents patchfile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents startrand As System.Windows.Forms.Button
    Friend WithEvents rndacc As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents checkbox_rnd_power As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_accuracy As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_balance As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_pp As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_name As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_element As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_effect As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenRomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents checkbox_rnd_category As System.Windows.Forms.CheckBox
    Friend WithEvents checkbox_rnd_name_context As System.Windows.Forms.CheckBox
    Friend WithEvents lstboxgame As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents checkbox_limit_effects As CheckBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents checkbox_rnd_anim_context As CheckBox
    Friend WithEvents checkbox_rnd_anim As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents checkbox_ignore_struggle As CheckBox
    Friend WithEvents checkbox_tweak_semi As CheckBox
    Friend WithEvents checkbox_buff_normal As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents checkbox_mod_priority As CheckBox
    Friend WithEvents checkbox_mod_accuracy As CheckBox
End Class
