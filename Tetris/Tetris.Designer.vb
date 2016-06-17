<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tetris
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tetris))
        Me.pnlJeu = New System.Windows.Forms.Panel()
        Me.timerJeu = New System.Windows.Forms.Timer(Me.components)
        Me.barreMenu = New System.Windows.Forms.MenuStrip()
        Me.JeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouvellePartieF2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PausePToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterEchapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PièceFantômeShiftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÀProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.pnlPieceSuivante = New System.Windows.Forms.Panel()
        Me.lblNext = New System.Windows.Forms.Label()
        Me.pctBoxGameOver = New System.Windows.Forms.PictureBox()
        Me.lblPause = New System.Windows.Forms.Label()
        Me.lblNiveau = New System.Windows.Forms.Label()
        Me.barreMenu.SuspendLayout()
        CType(Me.pctBoxGameOver, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlJeu
        '
        Me.pnlJeu.AutoSize = True
        Me.pnlJeu.BackColor = System.Drawing.Color.Transparent
        Me.pnlJeu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlJeu.Location = New System.Drawing.Point(10, 140)
        Me.pnlJeu.Name = "pnlJeu"
        Me.pnlJeu.Size = New System.Drawing.Size(158, 58)
        Me.pnlJeu.TabIndex = 0
        '
        'timerJeu
        '
        Me.timerJeu.Enabled = True
        Me.timerJeu.Interval = 1000
        '
        'barreMenu
        '
        Me.barreMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JeuToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.barreMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.barreMenu.Location = New System.Drawing.Point(0, 0)
        Me.barreMenu.Name = "barreMenu"
        Me.barreMenu.Size = New System.Drawing.Size(477, 24)
        Me.barreMenu.TabIndex = 1
        '
        'JeuToolStripMenuItem
        '
        Me.JeuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouvellePartieF2ToolStripMenuItem, Me.PausePToolStripMenuItem, Me.QuitterEchapToolStripMenuItem})
        Me.JeuToolStripMenuItem.Name = "JeuToolStripMenuItem"
        Me.JeuToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.JeuToolStripMenuItem.Text = "Jeu"
        '
        'NouvellePartieF2ToolStripMenuItem
        '
        Me.NouvellePartieF2ToolStripMenuItem.Name = "NouvellePartieF2ToolStripMenuItem"
        Me.NouvellePartieF2ToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.NouvellePartieF2ToolStripMenuItem.Text = "Nouvelle partie (F2)"
        '
        'PausePToolStripMenuItem
        '
        Me.PausePToolStripMenuItem.Name = "PausePToolStripMenuItem"
        Me.PausePToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PausePToolStripMenuItem.Text = "Pause (P)"
        '
        'QuitterEchapToolStripMenuItem
        '
        Me.QuitterEchapToolStripMenuItem.Name = "QuitterEchapToolStripMenuItem"
        Me.QuitterEchapToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.QuitterEchapToolStripMenuItem.Text = "Quitter (Echap)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PièceFantômeShiftToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'PièceFantômeShiftToolStripMenuItem
        '
        Me.PièceFantômeShiftToolStripMenuItem.Name = "PièceFantômeShiftToolStripMenuItem"
        Me.PièceFantômeShiftToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PièceFantômeShiftToolStripMenuItem.Text = "Pièce fantôme (Shift)"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommandesToolStripMenuItem, Me.ÀProposToolStripMenuItem})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'CommandesToolStripMenuItem
        '
        Me.CommandesToolStripMenuItem.Name = "CommandesToolStripMenuItem"
        Me.CommandesToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CommandesToolStripMenuItem.Text = "Commandes"
        '
        'ÀProposToolStripMenuItem
        '
        Me.ÀProposToolStripMenuItem.Name = "ÀProposToolStripMenuItem"
        Me.ÀProposToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ÀProposToolStripMenuItem.Text = "À propos"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.BackColor = System.Drawing.Color.Transparent
        Me.lblScore.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.Color.Yellow
        Me.lblScore.Location = New System.Drawing.Point(306, 316)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(60, 21)
        Me.lblScore.TabIndex = 2
        Me.lblScore.Text = "Score 0"
        '
        'pnlPieceSuivante
        '
        Me.pnlPieceSuivante.AutoSize = True
        Me.pnlPieceSuivante.BackColor = System.Drawing.Color.Transparent
        Me.pnlPieceSuivante.Location = New System.Drawing.Point(306, 107)
        Me.pnlPieceSuivante.Name = "pnlPieceSuivante"
        Me.pnlPieceSuivante.Size = New System.Drawing.Size(148, 107)
        Me.pnlPieceSuivante.TabIndex = 3
        '
        'lblNext
        '
        Me.lblNext.AutoSize = True
        Me.lblNext.BackColor = System.Drawing.Color.Transparent
        Me.lblNext.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNext.ForeColor = System.Drawing.Color.Yellow
        Me.lblNext.Location = New System.Drawing.Point(306, 84)
        Me.lblNext.Name = "lblNext"
        Me.lblNext.Size = New System.Drawing.Size(40, 21)
        Me.lblNext.TabIndex = 5
        Me.lblNext.Text = "Next"
        '
        'pctBoxGameOver
        '
        Me.pctBoxGameOver.BackColor = System.Drawing.Color.Transparent
        Me.pctBoxGameOver.Image = CType(resources.GetObject("pctBoxGameOver.Image"), System.Drawing.Image)
        Me.pctBoxGameOver.Location = New System.Drawing.Point(60, 360)
        Me.pctBoxGameOver.Name = "pctBoxGameOver"
        Me.pctBoxGameOver.Size = New System.Drawing.Size(190, 135)
        Me.pctBoxGameOver.TabIndex = 6
        Me.pctBoxGameOver.TabStop = False
        Me.pctBoxGameOver.Visible = False
        '
        'lblPause
        '
        Me.lblPause.AutoSize = True
        Me.lblPause.BackColor = System.Drawing.Color.Black
        Me.lblPause.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPause.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPause.Location = New System.Drawing.Point(110, 414)
        Me.lblPause.Name = "lblPause"
        Me.lblPause.Size = New System.Drawing.Size(92, 34)
        Me.lblPause.TabIndex = 7
        Me.lblPause.Text = "PAUSE"
        Me.lblPause.Visible = False
        '
        'lblNiveau
        '
        Me.lblNiveau.AutoSize = True
        Me.lblNiveau.BackColor = System.Drawing.Color.Transparent
        Me.lblNiveau.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNiveau.ForeColor = System.Drawing.Color.Yellow
        Me.lblNiveau.Location = New System.Drawing.Point(306, 278)
        Me.lblNiveau.Name = "lblNiveau"
        Me.lblNiveau.Size = New System.Drawing.Size(70, 21)
        Me.lblNiveau.TabIndex = 8
        Me.lblNiveau.Text = "Niveau 1"
        '
        'Tetris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(477, 751)
        Me.Controls.Add(Me.lblNiveau)
        Me.Controls.Add(Me.lblPause)
        Me.Controls.Add(Me.pctBoxGameOver)
        Me.Controls.Add(Me.lblNext)
        Me.Controls.Add(Me.pnlPieceSuivante)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.pnlJeu)
        Me.Controls.Add(Me.barreMenu)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.barreMenu
        Me.Name = "Tetris"
        Me.Text = "Tetris"
        Me.barreMenu.ResumeLayout(False)
        Me.barreMenu.PerformLayout()
        CType(Me.pctBoxGameOver, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlJeu As System.Windows.Forms.Panel
    Friend WithEvents timerJeu As System.Windows.Forms.Timer
    Friend WithEvents barreMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents JeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvellePartieF2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PausePToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterEchapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents pnlPieceSuivante As System.Windows.Forms.Panel
    Friend WithEvents lblNext As System.Windows.Forms.Label
    Friend WithEvents pctBoxGameOver As System.Windows.Forms.PictureBox
    Friend WithEvents lblPause As System.Windows.Forms.Label
    Friend WithEvents PièceFantômeShiftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommandesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÀProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblNiveau As System.Windows.Forms.Label

End Class
