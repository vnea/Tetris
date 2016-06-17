' Définition de tous les types de forme
Public Enum Forme
    I
    J
    L
    O
    S
    T
    Z
End Enum

Public Class Tetramino

    ' Attribut(s) de la classe
    Private _forme As Forme         ' Forme de la pièce
    Private _couleur As Color       ' Couleur de la pièce
    Private _numRotation As Integer ' Rotation de la pièce

    Private Const ptRefX As Integer = 1 ' Point de référence en X
    Private Const ptRefY As Integer = 1 ' Point de référence en Y
    Private _posX As Integer            ' Position de la pièce en X
    Private _posY As Integer            ' Position de la pièce en Y

    Private Const MAX_ROTATIONS As Integer = 4                   ' Nombre maximal de rotations
    Private Const MAX_BLOCS As Integer = 4                       ' Nombre maximal de blocs
    Private _tab(MAX_ROTATIONS, MAX_BLOCS, MAX_BLOCS) As Integer ' Tableau 3D pour identifier la pièce



    ' Constructeur(s)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' On initialise la rotation
        _numRotation = 0

        ' On initialise le point de référence
        _posX = ptRefX
        _posY = ptRefY

    End Sub



    ' Accesseur(s) get()

    ''' <summary>
    ''' Retourne la couleur
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCouleur() As Color
        Return _couleur
    End Function

    ''' <summary>
    ''' Retourne la coordonnées en X
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPosX() As Integer
        Return _posX
    End Function

    ''' <summary>
    ''' Retourne la coordonnée en Y
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPosY() As Integer
        Return _posY
    End Function

    ''' <summary>
    ''' Retourne une case du tableau
    ''' </summary>
    ''' <param name="y"></param>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCaseYX(ByVal y As Integer, ByVal x As Integer) As Integer
        Return _tab(_numRotation, y, x)
    End Function



    ' Accesseur(s) set()

    ''' <summary>
    ''' Met une forme
    ''' </summary>
    ''' <param name="forme"></param>
    ''' <remarks></remarks>
    Public Sub setForme(ByRef forme As Forme)
        _forme = forme
    End Sub

    ''' <summary>
    ''' Place la pièce à une certaine position
    ''' </summary>
    ''' <param name="posY"></param>
    ''' <param name="posX"></param>
    ''' <remarks></remarks>
    Public Sub setPosition(ByVal posY As Integer, ByVal posX As Integer)
        _posY = posY
        _posX = posX
    End Sub



    ' Méthode(s) publique(s) de la classe

    ''' <summary>
    ''' Met à la pièce sa rotation par défaut
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialiserRotation()
        _numRotation = 0
    End Sub

    ''' <summary>
    ''' Met à jour la forme et la couleur
    ''' </summary>
    ''' <param name="forme"></param>
    ''' <remarks></remarks>
    Public Sub majFormeCouleur(ByVal forme As Forme)

        ' On commence par mettre des 0 dans tt le tableau
        ' Le 0 correspond à une case vide
        For i As Integer = 0 To MAX_ROTATIONS - 1
            For y As Integer = 0 To MAX_BLOCS - 1
                For x As Integer = 0 To MAX_BLOCS - 1
                    _tab(i, y, x) = 0
                Next
            Next
        Next

        ' On fixe le point de référence (chiffre 2) pour toutes les rotations
        For i As Integer = 0 To MAX_ROTATIONS - 1
            _tab(i, ptRefY, ptRefX) = 2
        Next

        ' Selon la forme, on met à jour le tableau pour représenter la forme de sa pièce et ses rotations
        ' On met aussi à jour la couleur (car la couleur dépend de la forme)
        Select Case forme

            Case forme.I
                ' Mise à jour de la couleur
                _couleur = Color.Green

                ' Rotation 1
                _tab(0, 0, 1) = 1
                _tab(0, 2, 1) = 1
                _tab(0, 3, 1) = 1

                ' Rotation 2
                _tab(1, 1, 0) = 1
                _tab(1, 1, 2) = 1
                _tab(1, 1, 3) = 1

                ' Rotation 3
                _tab(2, 0, 1) = 1
                _tab(2, 2, 1) = 1
                _tab(2, 3, 1) = 1

                ' Rotation 4
                _tab(3, 1, 0) = 1
                _tab(3, 1, 2) = 1
                _tab(3, 1, 3) = 1

            Case forme.J
                ' Mise à jour de la couleur
                _couleur = Color.GreenYellow

                ' Rotation 1
                _tab(0, 0, 1) = 1
                _tab(0, 2, 0) = 1
                _tab(0, 2, 1) = 1

                ' Rotation 2
                _tab(1, 0, 0) = 1
                _tab(1, 1, 0) = 1
                _tab(1, 1, 2) = 1

                ' Rotation 3
                _tab(2, 0, 1) = 1
                _tab(2, 0, 2) = 1
                _tab(2, 2, 1) = 1

                ' Rotaion 4
                _tab(3, 1, 0) = 1
                _tab(3, 1, 2) = 1
                _tab(3, 2, 2) = 1

            Case forme.L
                ' Mise à jour de la couleur
                _couleur = Color.DeepPink

                ' Rotation 1
                _tab(0, 0, 1) = 1
                _tab(0, 2, 2) = 1
                _tab(0, 2, 1) = 1

                ' Rotation 2
                _tab(1, 2, 0) = 1
                _tab(1, 1, 0) = 1
                _tab(1, 1, 2) = 1

                ' Rotation 3
                _tab(2, 0, 1) = 1
                _tab(2, 0, 0) = 1
                _tab(2, 2, 1) = 1

                ' Rotaion 4
                _tab(3, 1, 0) = 1
                _tab(3, 1, 2) = 1
                _tab(3, 0, 2) = 1

            Case forme.O
                ' Mise à jour de la couleur
                _couleur = Color.Yellow

                ' Rotation 1, 2, 3 et 4
                For i As Integer = 0 To MAX_ROTATIONS - 1
                    _tab(i, 0, 0) = 1
                    _tab(i, 0, 1) = 1
                    _tab(i, 1, 0) = 1
                Next

            Case forme.S
                ' Mise à jour de la couleur
                _couleur = Color.BlueViolet

                ' Rotation 1
                _tab(0, 1, 0) = 1
                _tab(0, 0, 1) = 1
                _tab(0, 0, 2) = 1

                ' Rotation 2
                _tab(1, 0, 0) = 1
                _tab(1, 1, 0) = 1
                _tab(1, 2, 1) = 1

                ' Rotation 3
                _tab(2, 1, 0) = 1
                _tab(2, 0, 1) = 1
                _tab(2, 0, 2) = 1

                ' Rotation 4
                _tab(3, 0, 0) = 1
                _tab(3, 1, 0) = 1
                _tab(3, 2, 1) = 1

            Case forme.T
                ' Mise à jour de la couleur
                _couleur = Color.Orange

                ' Rotation 1
                _tab(0, 1, 0) = 1
                _tab(0, 1, 2) = 1
                _tab(0, 2, 1) = 1

                ' Rotation 2
                _tab(1, 0, 1) = 1
                _tab(1, 1, 0) = 1
                _tab(1, 2, 1) = 1

                ' Rotation 3
                _tab(2, 1, 0) = 1
                _tab(2, 1, 2) = 1
                _tab(2, 0, 1) = 1

                ' Rotation 4
                _tab(3, 0, 1) = 1
                _tab(3, 2, 1) = 1
                _tab(3, 1, 2) = 1

            Case forme.Z
                ' Mise à jour de la couleur
                _couleur = Color.Cyan

                ' Rotation 1
                _tab(0, 1, 0) = 1
                _tab(0, 2, 1) = 1
                _tab(0, 2, 2) = 1

                ' Rotation 2
                _tab(1, 0, 1) = 1
                _tab(1, 1, 0) = 1
                _tab(1, 2, 0) = 1

                ' Rotation 3
                _tab(2, 1, 0) = 1
                _tab(2, 2, 1) = 1
                _tab(2, 2, 2) = 1

                ' Rotation 4
                _tab(3, 0, 1) = 1
                _tab(3, 1, 0) = 1
                _tab(3, 2, 0) = 1

            Case Else

        End Select

    End Sub

    ''' <summary>
    ''' Fais une rotation de 90°
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub pivoterDroite()

        ' On incrémente la rotation
        _numRotation += 1

        ' On remet la rotation à 0 si elle dépasse 3
        If (_numRotation > MAX_ROTATIONS - 1) Then
            _numRotation = 0
        End If

    End Sub

    ''' <summary>
    ''' Fais une rotation de -90°
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub pivoterGauche()

        ' On décrémente la rotation
        _numRotation -= 1

        ' Si la rotation est inférieure à 0, on la met à 3
        If (_numRotation < 0) Then
            _numRotation = MAX_ROTATIONS - 1
        End If

    End Sub

    ''' <summary>
    ''' Déplace la pièce selon l'axe X
    ''' </summary>
    ''' <param name="depX"></param>
    ''' <remarks></remarks>
    Public Sub seDeplacerX(ByVal depX As Integer)
        _posX += depX
    End Sub

    ''' <summary>
    ''' Déplace la pièce ver le base selon l'axe Y
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub seDeplacerY()
        _posY += 1
    End Sub

    ''' <summary>
    ''' Place automatiquement la pièce la plus bas possible
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <remarks></remarks>
    Public Sub hardDrop(ByRef grilleJeu(,) As TextBox)

        ' Tant que la pièce peut descendre
        While (peutBougerY(grilleJeu))
            ' On descend la pièce
            seDeplacerY()
        End While
    End Sub

    ''' <summary>
    ''' Dessine la pièce
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <remarks></remarks>
    Public Sub dessiner(ByRef grilleJeu(,) As TextBox)

        ' On parcourt le tableau pour dessiner la pièce
        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' Si la case du tableau n'est pas vide, on la dessine avec sa couleur
                If (getCaseYX(y, x) <> 0) Then
                    grilleJeu(y + _posY, x + _posX).BackColor = _couleur
                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' Efface la pièce
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <remarks></remarks>
    Public Sub effacer(ByRef grilleJeu(,) As TextBox)

        ' On parcourt le tableau pour effacer la pièce
        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' Si le grille du jeu ne contient pas de couleur à cette case, on l'efface
                If (grilleJeu(y + _posY, x + _posX).Tag <> "1") Then
                    grilleJeu(y + _posY, x + _posX).BackColor = Color.Black
                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' Dessine la pièce fantôme (= son ombre)
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <remarks></remarks>
    Public Sub dessinerFantome(ByRef grilleJeu(,) As TextBox)

        ' On enregistre la position actuelle de 
        Dim pos As Integer = _posY

        ' On projette la pièce tout en bas
        hardDrop(grilleJeu)

        ' On parcourt le tableau pour dessiner la pièce fantôme
        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' Si la case acutelle du tableau n'est pas vide, on dessine la pièce fantôme
                If (getCaseYX(y, x) <> 0) Then
                    grilleJeu(y + _posY, x + _posX).BackColor = Color.DarkGray
                End If
            Next
        Next

        ' On rénitialise la position de la pièce
        _posY = pos
    End Sub

    ''' <summary>
    ''' Efface la pièce fantôme
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <remarks></remarks>
    Public Sub effacerFantome(ByRef grilleJeu(,) As TextBox)

        ' On enregistre la position actuelle de 
        Dim pos As Integer = _posY

        ' On projette la pièce tout en bas
        hardDrop(grilleJeu)

        ' On parcourt le tableau pour effacer la pièce fantôme
        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' Si la case du grille de jeu ne contient pas de couleur, on efface la case
                If (grilleJeu(y + _posY, x + _posX).Tag = "0") Then
                    grilleJeu(y + _posY, x + _posX).BackColor = Color.Black
                End If
            Next
        Next

        ' On rénitialise la position de la pièce
        _posY = pos
    End Sub

    ''' <summary>
    ''' Retourne vrai si la pièce peut bouger selon l'axe Y
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <returns>Booléen</returns>
    ''' <remarks></remarks>
    Public Function peutBougerY(ByRef grilleJeu(,) As TextBox) As Boolean

        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' On ne peut pas bouger en Y
                If (getCaseYX(y, x) <> 0 And grilleJeu(y + _posY + 1, x + _posX).Tag = "1") Then
                    Return False
                End If
            Next
        Next

        ' On peut bouger en Y
        Return True

    End Function

    ''' <summary>
    ''' Retourne vrai si la pièce peut bouger selon l'axe X
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <param name="valX"></param>
    ''' <returns>Booléen</returns>
    ''' <remarks></remarks>
    Public Function peutBougerX(ByRef grilleJeu(,) As TextBox, ByVal valX As Integer) As Boolean

        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' On ne peut pas bouger en X
                If (getCaseYX(y, x) <> 0 And grilleJeu(y + _posY, x + _posX + valX).Tag = "1") Then
                    Return False
                End If
            Next
        Next

        ' On peut bouger en X
        Return True

    End Function

    ''' <summary>
    ''' Retourne vrai si la pièce peut faire une rotation
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <returns>Booléen</returns>
    ''' <remarks></remarks>
    Public Function peutTourner(ByRef grilleJeu(,) As TextBox) As Boolean
        Dim tournerOk As Boolean

        ' On pivote la pièce de 90°
        pivoterDroite()

        ' On regarde après la rotation si la pièce se trouve dans une autre pièce
        tournerOk = Not dansUnePiece(grilleJeu)

        ' On repivote la pièce de -90°
        pivoterGauche()

        Return tournerOk
    End Function

    ''' <summary>
    ''' Retourne vrai si la pièce se trouve dans une autre pièce
    ''' </summary>
    ''' <param name="grilleJeu"></param>
    ''' <returns>Booléen</returns>
    ''' <remarks></remarks>
    Public Function dansUnePiece(ByRef grilleJeu(,) As TextBox) As Boolean

        For y As Integer = chercherCoodBlocHaut() To chercherCoodBlocBas()
            For x As Integer = chercherCoodBlocGauche() To chercherCoodBlocDroite()
                ' La pièce se trouve dans une autre pièce
                If (getCaseYX(y, x) <> 0 And grilleJeu(y + _posY, x + _posX).Tag = "1") Then
                    Return True
                End If
            Next
        Next

        ' La pièce ne se trouve pas dans une autre pièce
        Return False

    End Function

    ''' <summary>
    ''' Retourne la coordonnée qui se trouve le plus à gauche du tableau
    ''' </summary>
    ''' <returns>Entier</returns>
    ''' <remarks></remarks>
    Public Function chercherCoodBlocGauche() As Integer
        Dim y, x As Integer

        For x = 0 To MAX_BLOCS - 1
            For y = 0 To MAX_BLOCS - 1
                If (getCaseYX(y, x) <> 0) Then
                    Return x
                End If
            Next
        Next

        ' Pour éviter un warning
        Return -1
    End Function

    ''' <summary>
    ''' Retourne la coordonnée qui se trouve le plus à droite du tableau
    ''' </summary>
    ''' <returns>Entier</returns>
    ''' <remarks></remarks>
    Public Function chercherCoodBlocDroite() As Integer
        Dim y, x As Integer

        For x = MAX_BLOCS - 1 To 0 Step -1
            For y = MAX_BLOCS - 1 To 0 Step -1
                If (getCaseYX(y, x) <> 0) Then
                    Return x
                End If
            Next
        Next

        ' Pour éviter un warning
        Return -1
    End Function

    ''' <summary>
    ''' Retourne la coordonnée qui se trouve le plus haut du tableau
    ''' </summary>
    ''' <returns>Entier</returns>
    ''' <remarks></remarks>
    Public Function chercherCoodBlocHaut() As Integer

        Dim y, x As Integer

        For y = 0 To MAX_BLOCS - 1
            For x = 0 To MAX_BLOCS - 1
                If (getCaseYX(y, x) <> 0) Then
                    Return y
                End If
            Next
        Next

        ' Pour éviter un warning
        Return -1
    End Function

    ''' <summary>
    ''' Retourne la coordonnée qui se trouve le plus bas du tableau
    ''' </summary>
    ''' <returns>Entier</returns>
    ''' <remarks></remarks>
    Public Function chercherCoodBlocBas() As Integer
        Dim y, x As Integer

        For y = MAX_BLOCS - 1 To 0 Step -1
            For x = MAX_BLOCS - 1 To 0 Step -1
                If (getCaseYX(y, x) <> 0) Then
                    Return y
                End If
            Next
        Next

        ' Pour éviter un warning
        Return -1
    End Function

End Class
