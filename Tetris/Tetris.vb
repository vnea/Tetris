Public Class Tetris

    ' Attributs de la classe
    Private NB_LIGNES As Integer = 24           ' Nombre de lignes
    Private NB_COLONNES As Integer = 12         ' Nombre de colonnes
    Private TAILLE_GRILLE_SUIV As Integer = 6   ' Taille de la grille de la pièce suivante
    Private TAILLE_TXTBOX As Integer = 25       ' Taille d'une TextBox (donc d'une pièce)
    Private Const ORIGINEX As Integer = 5       ' Position de départ de la pièce en X
    Private Const ORIGINEY As Integer = 0       ' Position de départ de la pièce en Y

    Private grilleJeu(NB_LIGNES + 2, NB_COLONNES + 4) As TextBox                    ' Grille du jeu (= grille)
    Private grillePieceSuivante(TAILLE_GRILLE_SUIV, TAILLE_GRILLE_SUIV) As TextBox  ' Grille de la pièce suivante 
    Private piece As New Tetramino                                                  ' Pièce du jeu
    Private formePieceSuivante As Forme                                             ' Forme de la pièce suivante
    Private Const PALIER_NIVEAU As Integer = 1800                                   ' Score à atteindre pour changer de niveau
    Private score, niveau As Integer                                                ' Score du jeu, niveau du jeu
    Private scoreTmp As Integer                                                     ' Score temporaire pour changer de niveau
    Private jeuEnPause, jeuEnCours As Boolean                                       ' Pour savoir si le jeu est en pause/en cours
    Private afficherPieceFantome As Boolean                                         ' Pour savoir si on affiche la pièce fantôme


    ' Méthode(s) privée(s) de la classe
    ''' <summary>
    ''' Charge le jeu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       

        ' Création des deux grilles
        creerGrilleJeu()
        creerGrillePieceSuivante()

        jeuEnCours = False

        ' On stoppe le chronomètre
        timerJeu.Stop()

        'On active l'affiche de la pièce fantôme par défaut
        afficherPieceFantome = True

    End Sub

    ''' <summary>
    ''' Crée la grille du jeu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub creerGrilleJeu()

        ' Gestion de la la position des TextBox dans le panel
        Dim distanceHaut As Integer
        Dim distanceGauche As Integer
        Dim x, y As Integer

        ' Pour chaque ligne et chaque colonne : créer une TextBox et définir ses propriétés
        distanceHaut = 10
        For y = 0 To NB_LIGNES - 1
            distanceGauche = 5
            For x = 0 To NB_COLONNES - 1
                ' créer une textbox de la matrice
                grilleJeu(y, x) = New TextBox
                ' définir les propriétés de la TextBox
                grilleJeu(y, x).Multiline = True 'sinon, la hauteur s'adapte automatiquement à celle de la police
                grilleJeu(y, x).Width = TAILLE_TXTBOX
                grilleJeu(y, x).Height = TAILLE_TXTBOX
                grilleJeu(y, x).BackColor = Color.Black
                grilleJeu(y, x).Enabled = False
                grilleJeu(y, x).Location = New Point(distanceGauche, distanceHaut)
                grilleJeu(y, x).BorderStyle = BorderStyle.FixedSingle
                ' Case vide
                grilleJeu(y, x).Tag = "0"
                ' ajouter la TextBox au Panel 
                pnlJeu.Controls.Add(grilleJeu(y, x))
                ' mettre à jour la position, pour la TextBox suivante
                distanceGauche = distanceGauche + TAILLE_TXTBOX - 2
            Next
            distanceHaut = distanceHaut + TAILLE_TXTBOX - 2
        Next

        ' On n'affiche pas les bordures de la grille du jeu
        For i = 0 To NB_LIGNES - 1
            ' Bordure de gauche
            ' Case remplie
            grilleJeu(i, 0).Tag = "1"
            grilleJeu(i, 0).Visible = False

            'Bordure de droite
            grilleJeu(i, NB_COLONNES - 1).Tag = "1"
            grilleJeu(i, NB_COLONNES - 1).Visible = False
        Next

        For j = 1 To NB_COLONNES - 1
            ' Bordure du bas
            ' Case remplie
            grilleJeu(NB_LIGNES - 1, j).Tag = "1"
            grilleJeu(NB_LIGNES - 1, j).Visible = False

            ' Ligne fictive
            grilleJeu(0, j).Visible = False
        Next

    End Sub

    ''' <summary>
    ''' Créer la grille de la pièce suivante
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub creerGrillePieceSuivante()
        Dim distanceHaut As Integer
        Dim distanceGauche As Integer
        Dim x, y As Integer

        ' Pour chaque ligne et chaque colonne : créer une TextBox et définir ses propriétés
        distanceHaut = 10
        For y = 0 To TAILLE_GRILLE_SUIV - 1
            distanceGauche = 5
            For x = 0 To TAILLE_GRILLE_SUIV - 1
                ' Créer une textbox de la matrice
                grillePieceSuivante(y, x) = New TextBox
                ' Définir les propriétés de la TextBox
                grillePieceSuivante(y, x).Multiline = True 'Sinon, la hauteur s'adapte automatiquement à celle de la police
                grillePieceSuivante(y, x).Width = TAILLE_TXTBOX
                grillePieceSuivante(y, x).Height = TAILLE_TXTBOX
                grillePieceSuivante(y, x).BackColor = Color.Black
                grillePieceSuivante(y, x).Enabled = False
                grillePieceSuivante(y, x).Location = New Point(distanceGauche, distanceHaut)
                grillePieceSuivante(y, x).BorderStyle = BorderStyle.FixedSingle
                ' Ajouter la TextBox au Panel 
                pnlPieceSuivante.Controls.Add(grillePieceSuivante(y, x))
                ' Mettre à jour la position, pour la TextBox suivante
                distanceGauche = distanceGauche + TAILLE_TXTBOX - 2
            Next
            distanceHaut = distanceHaut + TAILLE_TXTBOX - 2
        Next
    End Sub

    ''' <summary>
    ''' Met à jour la grille du jeu : met des 1 aux endroits au il faut pour dire que
    ''' la case de la grille contient un bloc de pièce
    ''' </summary>
    ''' <param name="piece"></param>
    ''' <remarks></remarks>
    Private Sub majgrilleJeu(ByRef piece As Tetramino)

        For y As Integer = piece.chercherCoodBlocHaut() To piece.chercherCoodBlocBas()
            For x As Integer = piece.chercherCoodBlocGauche() To piece.chercherCoodBlocDroite()
                If (piece.getCaseYX(y, x) <> 0) Then
                    grilleJeu(y + piece.getPosY(), x + piece.getPosX()).Tag = "1"
                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' Met à jour le score du jeu
    ''' </summary>
    ''' <param name="nbLignes"></param>
    ''' <remarks></remarks>
    Private Sub majScore(ByVal nbLignes As Integer)
        Select Case nbLignes
            Case 1
                scoreTmp += 40
                score += 40

            Case 2
                scoreTmp += 100
                score += 100

            Case 3
                scoreTmp += 300
                score += 300

            Case 4
                scoreTmp += 1200
                score += 1200
            Case Else
        End Select

        lblScore.Text = "Score " & score
    End Sub

    ''' <summary>
    ''' Efface la grille du jeu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub effacerGrilleJeu()
        Dim x, y As Integer

        For y = 0 To NB_LIGNES - 2
            For x = 1 To NB_COLONNES - 2
                grilleJeu(y, x).Tag = "0"
                grilleJeu(y, x).BackColor = Color.Black
            Next
        Next

    End Sub

    ''' <summary>
    ''' Dessine la pièce suivante
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dessinerPieceSuivante()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 3
                ' On dessine si le bloc de la pièce n'est pas vide
                If (piece.getCaseYX(y, x) <> 0) Then
                    grillePieceSuivante(y + 1, x + 1).BackColor = piece.getCouleur()
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Efface la pièce suivante
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub effacerPieceSuivante()

        ' On met tt en noir
        For y As Integer = 0 To 3
            For x As Integer = 0 To 3
                grillePieceSuivante(y + 1, x + 1).BackColor = Color.Black
            Next
        Next

    End Sub

    ''' <summary>
    ''' Délplace la pièce vers le bas à chaque tick du timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub timerJeu_Tick(sender As System.Object, e As System.EventArgs) Handles timerJeu.Tick

        If (piece.peutBougerY(grilleJeu)) Then ' Si la pièce peut bouger
            ' On efface la pièce
            piece.effacer(grilleJeu)
            ' On la déplace vers le bas
            piece.seDeplacerY()
            ' On dessine la pièce fantôme
            If (afficherPieceFantome) Then
                piece.dessinerFantome(grilleJeu)
            End If
            ' On dessine la pièce
            piece.dessiner(grilleJeu)

        Else  ' Si la pièce ne peut pas bouger, on tire une nouvelle pièce
            majJeu()

        End If

    End Sub

    ''' <summary>
    ''' Met à jour le timer selon le score du jeu, met en même temp à jour le niveau du jeu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub majTimerNiveau()

        ' On regarde si on dépasse bien le palier
        If (scoreTmp >= PALIER_NIVEAU) Then
            ' On vérife que l'intervalle de temps du timer ne peut pas être négatif
            If (timerJeu.Interval - 99 > 0) Then
                ' On met à jour l'intervalle de temps
                timerJeu.Interval -= 99

                ' On met à jour le niveau
                niveau += 1
                lblNiveau.Text = "Niveau " & niveau

                ' On réinitialise le score temporaire
                scoreTmp = 0
            End If
        End If

    End Sub

    ''' <summary>
    ''' Gère les touches du clavier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Tetris_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        ' On ne peut appuyer sur ces touches que si le jeu n'est pas en pause/en cours
        If (jeuEnCours And Not jeuEnPause) Then
            Select Case e.KeyCode

                ' On déplace la pièce vers la gauche
                Case Keys.Left
                    ' Si la pièce peut bouger vers la gauche
                    If (piece.peutBougerX(grilleJeu, -1)) Then
                        piece.effacer(grilleJeu)
                        If (afficherPieceFantome) Then
                            piece.effacerFantome(grilleJeu)
                        End If
                        piece.seDeplacerX(-1)
                        If (afficherPieceFantome) Then
                            piece.dessinerFantome(grilleJeu)
                        End If
                        piece.dessiner(grilleJeu)
                    End If

                    ' On déplace la pièce vers la droite
                Case Keys.Right
                    ' Si la pièce peut bouger vers la droite
                    If (piece.peutBougerX(grilleJeu, 1)) Then
                        piece.effacer(grilleJeu)
                        If (afficherPieceFantome) Then
                            piece.effacerFantome(grilleJeu)
                        End If
                        piece.seDeplacerX(1)
                        If (afficherPieceFantome) Then
                            piece.dessinerFantome(grilleJeu)
                        End If
                        piece.dessiner(grilleJeu)
                    End If

                    ' On déplace la pièce vers le bas
                Case Keys.Down
                    ' Si la pièce peut bouger vers le bas
                    If (piece.peutBougerY(grilleJeu)) Then
                        piece.effacer(grilleJeu)
                        piece.seDeplacerY()
                        piece.dessiner(grilleJeu)
                    End If

                    ' On fait une rotation de la pièce de 90°
                Case Keys.Up
                    ' Si la pièce peut tourner
                    If (piece.peutTourner(grilleJeu)) Then
                        piece.effacer(grilleJeu)
                        If (afficherPieceFantome) Then
                            piece.effacerFantome(grilleJeu)
                        End If
                        piece.pivoterDroite()
                        If (afficherPieceFantome) Then
                            piece.dessinerFantome(grilleJeu)
                        End If
                        piece.dessiner(grilleJeu)
                    End If

                    ' On effectue un hard drop
                Case Keys.Space
                    piece.effacer(grilleJeu)
                    piece.hardDrop(grilleJeu)
                    piece.dessiner(grilleJeu)
                    majJeu()

                Case Else

            End Select
        End If

        Select Case e.KeyCode
            ' On lance une nouvelle partie
            Case Keys.F2
                nouvellePartie(sender, e)

                ' On quitte le jeu
            Case Keys.Escape
                quitterJeu(sender, e)

                ' On met le jeu en pause
            Case Keys.P
                pause(sender, e)

            Case Keys.ShiftKey
                afficherLaPieceFantome(sender, e)

            Case Else
        End Select

    End Sub

    ''' <summary>
    ''' Tire une forme au harsard
    ''' </summary>
    ''' <returns>Forme</returns>
    ''' <remarks></remarks>
    Private Function formeHasard() As Forme
        Dim formeAlea As Forme

        ' Initialise le générateur de nombre aléatoire
        Randomize()

        ' Choisis une forme parmis toute les formes disponibles
        formeAlea = Forme.Z * Rnd()

        Return formeAlea
    End Function

    ''' <summary>
    ''' Tire une nouvelle piece, met à jour la grille, met à jour le score, gère l'état de la partie (perdu ou non)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub majJeu()

        ' On stoppe le timer le temps de tout mettre à jour
        timerJeu.Stop()
        majgrilleJeu(piece)
        ' Efface les lignes et met à jour le score
        majScore(effacerLignes())
        majTimerNiveau()

        ' On place la pièce tout en haut de la grille
        piece.setPosition(ORIGINEY, ORIGINEX)

        ' Si la pièce qui vient d'être créée ne se trouve pas dans une autre pièce
        If (Not piece.dansUnePiece(grilleJeu)) Then
            Dim formePieceSuivanteTmp As Forme

            piece.initialiserRotation()
            effacerPieceSuivante()

            ' On garde la forme de la pièce suivant avant d'en tirer une autre au hasard
            formePieceSuivanteTmp = formePieceSuivante
            ' On tire au hasard une nouvelle forme
            formePieceSuivante = formeHasard()
            piece.majFormeCouleur(formePieceSuivante)
            dessinerPieceSuivante()

            ' On définit la nouvelle forme de la pièce
            piece.majFormeCouleur(formePieceSuivanteTmp)
            If (afficherPieceFantome) Then
                piece.dessinerFantome(grilleJeu)
            End If
            piece.dessiner(grilleJeu)

            ' On peut maintenant relancer le timer
            timerJeu.Start()

            ' Sinon on a perdu
        Else
            ' On stoppe la musique et le timer
            My.Computer.Audio.Stop()
            timerJeu.Stop()
            jeuEnCours = False

            ' On affiche GAME OVER
            pctBoxGameOver.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Retourne vrai si une ligne est remplie
    ''' </summary>
    ''' <param name="numLigne"></param>
    ''' <returns>Booléen</returns>
    ''' <remarks></remarks>
    Private Function ligneRemplie(ByVal numLigne As Integer) As Boolean

        For ind As Integer = 1 To NB_COLONNES - 2
            ' La ligne n'est pas remplie (on a une case vide)
            If (grilleJeu(numLigne, ind).Tag = "0") Then
                Return False
            End If
        Next

        ' La ligne est remplie
        Return True
    End Function

    ''' <summary>
    ''' Retourne la coordonnée Y de la pièce la plus haute
    ''' </summary>
    ''' <returns>Entier</returns>
    ''' <remarks></remarks>
    Private Function coodYPiecePlusHaute() As Integer

        ' On part de la ligne 1 car la ligne 0 est une ligne fictive
        For y = 1 To NB_LIGNES - 2
            For x = 1 To NB_COLONNES - 2
                ' Dès qu'une case est remplie, on retourne la coordonnée Y
                If (grilleJeu(y, x).Tag = "1") Then
                    Return y
                End If
            Next
        Next

        ' Si la grille est vide
        Return NB_LIGNES - 2
    End Function

    ''' <summary>
    ''' Efface les lignes de la grille qui sont remplies
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function effacerLignes() As Integer
        Dim nbLignesEffacees As Integer = 0
        Dim numLigne As Integer = NB_LIGNES - 2

        ' On cherche du bas de la grille jusqu'à la coordonnée Y de la pièce la plus haute
        ' qui se trouve sur la grille
        While (numLigne >= coodYPiecePlusHaute())

            ' Si la ligne est remplie
            If (ligneRemplie(numLigne)) Then

                ' La ligne à laquelle on se trouve devient celle de dessus
                For y As Integer = numLigne To coodYPiecePlusHaute() Step -1
                    For x As Integer = 1 To NB_COLONNES - 2
                        grilleJeu(y, x).Tag = grilleJeu(y - 1, x).Tag
                        grilleJeu(y, x).BackColor = grilleJeu(y - 1, x).BackColor
                    Next
                Next

                ' On met à jour le nombre de ligne effacées
                nbLignesEffacees = nbLignesEffacees + 1
                numLigne = NB_LIGNES - 2
            Else
                numLigne = numLigne - 1
            End If

        End While

        Return nbLignesEffacees
    End Function

    ''' <summary>
    ''' Quitte le jeu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub quitterJeu(sender As System.Object, e As System.EventArgs) Handles QuitterEchapToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Lance une nouvellePartie
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nouvellePartie(sender As System.Object, e As System.EventArgs) Handles NouvellePartieF2ToolStripMenuItem.Click
        ' On lance la musique
        My.Computer.Audio.Play(My.Resources.musique, AudioPlayMode.BackgroundLoop)

        ' On désactive l'affiche du GAME OVER
        pctBoxGameOver.Visible = False
        ' On désactive l'affichage du PAUSE
        lblPause.Visible = False
        effacerGrilleJeu()

        scoreTmp = 0
        score = 0
        niveau = 1
        lblScore.Text = "Score " & score
        lblNiveau.Text = "Niveau " & niveau

        jeuEnCours = True
        jeuEnPause = False

        piece.setPosition(ORIGINEY, ORIGINEX)
        effacerPieceSuivante()
        formePieceSuivante = formeHasard()
        piece.majFormeCouleur(formePieceSuivante)
        dessinerPieceSuivante()
        piece.majFormeCouleur(formeHasard())
        If (afficherPieceFantome) Then
            piece.dessinerFantome(grilleJeu)
        End If
        piece.dessiner(grilleJeu)
        ' On réinitiliase le temps du timer
        timerJeu.Interval = 1000
        timerJeu.Start()
    End Sub

    ''' <summary>
    ''' Met le jeu en pause
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pause(sender As System.Object, e As System.EventArgs) Handles PausePToolStripMenuItem.Click

        ' Si le jeu est bien en cours
        If (jeuEnCours) Then

            ' Si le jeu est déjà en pause
            If (jeuEnPause) Then
                ' On relance la musique
                My.Computer.Audio.Play(My.Resources.musique, AudioPlayMode.BackgroundLoop)
                ' On relance le timer
                timerJeu.Start()
                jeuEnPause = False
                lblPause.Visible = False
            Else
                ' On stoppe la musique
                My.Computer.Audio.Stop()
                ' On stoppe le timer
                timerJeu.Stop()
                jeuEnPause = True
                lblPause.Visible = True
            End If
        End If

    End Sub

    ''' <summary>
    ''' Afficher les commandes du jeu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub afficherCommandes(sender As System.Object, e As System.EventArgs) Handles CommandesToolStripMenuItem.Click
        pause(sender, e)
        MessageBox.Show("Gauche : ←" & Chr(13) & "Droite : →" & Chr(13) & "Bas : ↓" & Chr(13) & "Rotation 90° : ↑" & Chr(13) & "Hard Drop : Espace", "Commandes")
        pause(sender, e)
    End Sub

    ''' <summary>
    ''' Affiche à propos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub aPropos(sender As System.Object, e As System.EventArgs) Handles ÀProposToolStripMenuItem.Click
        pause(sender, e)
        MessageBox.Show("Jeu Tetris", "À propos")
        pause(sender, e)
    End Sub

    ''' <summary>
    ''' Permet d'activer l'affichage de la pièce fantome
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub afficherLaPieceFantome(sender As System.Object, e As System.EventArgs) Handles PièceFantômeShiftToolStripMenuItem.Click
        afficherPieceFantome = Not afficherPieceFantome

        If (jeuEnCours) Then
            ' Si on désactive la pièce fantôme, on l'efface
            If (Not afficherPieceFantome) Then
                piece.effacerFantome(grilleJeu)
            Else
                piece.dessinerFantome(grilleJeu)
            End If
        End If
    End Sub
End Class

