Public Class frmMain

    'ORIGINALLY WAS A GAME WHERE AN EGG BATTLED A CAT


    Dim rand As Random = New Random
    'i: how many AtkEgg or AtkCat are clicked
    Dim i As Integer
    'Turns: which trk.value is adjusted (Ply or Ply 2's turn)
    Dim Turns As Integer
    'f: random number for loop
    Dim f As Integer
    'Player 1 and 2 health: so I don't go over or under
    Dim P1H As Integer
    Dim P2H As Integer

    'add way to gain back health
    'incoporate humor somehow
    'Change color of buttons to indicate whos going
    'adjust difficulties: speed, amount times clicked
    'Gain Heath button, mess up --> loose health
    'multiple chirps---> randomize what one goes for each situation
    'add tab index---> able to change characters and advacnced settings
    'add single player as well w/ varying difficulties, story made progressivly harder
    'add other buttons, false buttons that have other meanings
    'each characer has different specials
    'If buttons on keyboard are clicked, activate: trap, health, something, based on turn value

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnAtk.BackColor = Color.Red
        btnHeal.BackColor = Color.Red
        btnFake.Visible = False
        btnAtkEgg.Visible = False
        btnAtkCat.Visible = False
        i = 0
        Turns = 1
        lblPly1H.Text = trkPly1.Value
        lblPly2H.Text = trkPly2.Value
        P1H = 100
        P2H = 100

    End Sub
    Private Sub btnAtk_Click(sender As Object, e As EventArgs) Handles btnAtk.Click

        i = 0

        If Turns = 1 Then

            btnFake.Text = "Atk Fake"
            AttackPlayer2()

        Else

            btnFake.Text = "Atk Fake"
            AttackPlayer1()

        End If
    End Sub
    Private Sub btnAtkEgg_Click(sender As Object, e As EventArgs) Handles btnAtkEgg.Click

        i += 1
        btnAtkEgg.Visible = False
        btnFake.Visible = False

    End Sub
    Private Sub btnAtkCat_Click(sender As Object, e As EventArgs) Handles btnAtkCat.Click

        i += 1
        btnAtkCat.Visible = False
        btnFake.Visible = False

    End Sub
    Private Sub AttackPlayer2()

        'turns = 1
        For x = 0 To 3

            btnAtkEgg.Location = New Point(rand.Next(230, 485), rand.Next(60, 345))
            btnAtkEgg.Visible = True
            btnAtkEgg.Select()

            f = rand.Next(0, 4)
            If x = f Then

                btnFake.Location = New Point(rand.Next(230, 485), rand.Next(60, 345))
                btnFake.Visible = True
                btnFake.Select()

            End If

            Delay(0.8)

            'Buttons have come and gone, now time to analyze 

            Select Case True
                Case Turns = 2
                    Exit Sub
                'If btnAtk is clicked 3 times, damage is done
                Case i = 3
                    P2H -= 35
                    If P2H < 0 Then
                        trkPly2.Value = 0
                    Else
                        trkPly2.Value -= 35
                    End If
                    Turns = 2
                    btnAtk.BackColor = Color.DodgerBlue
                    btnHeal.BackColor = Color.DodgerBlue
                    btnFake.Visible = False
                    btnAtkEgg.Visible = False
                    lblPly1.ForeColor = Color.Yellow
                    lblPly1.Text = ("Hey SpaceX, get good at this game, you suck!")
                    Delay(0.85)
                    lblPly1.ForeColor = Color.White
                    lblPly1.Text = ("Hey SpaceX, get good at this game, you suck!")
                    Exit Sub
                Case x = 3 And i < 3
                    P1H -= 30
                    If P1H < 0 Then
                        trkPly1.Value = 0
                    Else
                        trkPly1.Value -= 30
                    End If
                    Turns = 2
                    btnAtk.BackColor = Color.DodgerBlue
                    btnHeal.BackColor = Color.DodgerBlue
                    btnFake.Visible = False
                    btnAtkEgg.Visible = False
                    lblPly2.ForeColor = Color.Yellow
                    lblPly2.Text = ("Wow! You're such a baby Tesla!")
                    Delay(0.85)
                    lblPly2.ForeColor = Color.White
                    lblPly2.Text = ("Wow! You're such a baby Tesla!")
                    Exit Sub
            End Select


        Next

    End Sub
    Private Sub AttackPlayer1()

        'Turns = 2
        For x = 0 To 3

            btnAtkCat.Visible = True
            btnAtkCat.Location = New Point(rand.Next(230, 485), rand.Next(60, 345))
            btnAtkCat.Select()

            f = rand.Next(0, 4)
            If x = f Then
                btnFake.Visible = True
                btnFake.Location = New Point(rand.Next(230, 485), rand.Next(60, 345))
                btnFake.Select()
            End If
            Delay(0.8)
            'Buttons have come and gone, now time to analyze 

            Select Case True
                Case Turns = 1
                    Exit Sub
                'If btnAtk is clicked 3 times, damage is done
                Case i = 3
                    P1H -= 35
                    If P1H < 0 Then
                        trkPly1.Value = 0
                    Else
                        trkPly1.Value -= 35
                    End If
                    Turns = 1
                    btnAtk.BackColor = Color.Red
                    btnHeal.BackColor = Color.Red
                    btnFake.Visible = False
                    btnAtkCat.Visible = False
                    lblPly2.ForeColor = Color.Yellow
                    lblPly2.Text = ("Whats up now Tesla?")
                    Delay(0.75)
                    lblPly2.ForeColor = Color.White
                    lblPly2.Text = ("Whats up now Tesla?")
                    Exit Sub
                Case x = 3 And i < 3
                    P2H -= 30
                    If P2H < 0 Then
                        trkPly2.Value = 0
                    Else
                        trkPly2.Value -= 30
                    End If
                    Turns = 1
                    btnAtk.BackColor = Color.Red
                    btnHeal.BackColor = Color.Red
                    btnFake.Visible = False
                    btnAtkCat.Visible = False
                    lblPly2.ForeColor = Color.Yellow
                    lblPly2.Text = ("You're still going to lose!")
                    Delay(0.75)
                    lblPly2.ForeColor = Color.White
                    lblPly2.Text = ("You're still going to lose!")
                    Exit Sub

            End Select

        Next

    End Sub
    Private Sub btnFake_Click(sender As Object, e As EventArgs) Handles btnFake.Click


        Select Case True
            'AtkCat
            Case Turns = 2

                Turns = 1
                btnAtkCat.Visible = False
                btnFake.Visible = False
                P2H -= 30
                If P2H < 0 Then
                    trkPly2.Value = 0
                Else
                    trkPly2.Value -= 30
                End If
                btnAtk.BackColor = Color.Red
                btnHeal.BackColor = Color.Red
                lblPly2.ForeColor = Color.Yellow
                lblPly2.Text = ("Dang it!")
                Delay(0.85)
                lblPly2.ForeColor = Color.White
                lblPly2.Text = ("Dang it!")

            'AtkEgg
            Case Turns = 1

                Turns = 2
                btnAtkEgg.Visible = False
                btnFake.Visible = False
                btnAtkCat.Visible = False
                P1H -= 30
                If P1H < 0 Then
                    trkPly1.Value = 0
                Else
                    trkPly1.Value -= 30
                End If
                btnAtk.BackColor = Color.DodgerBlue
                btnHeal.BackColor = Color.DodgerBlue
                lblPly1.ForeColor = Color.Yellow
                lblPly1.Text = ("I don't need a lot of health to beat you!")
                Delay(0.85)
                lblPly1.ForeColor = Color.White
                lblPly1.Text = ("I don't need a lot of health to beat you!")

        End Select


    End Sub
    Private Sub btnHeal_Click(sender As Object, e As EventArgs) Handles btnHeal.Click

        Select Case True
            Case Turns = 2

                Turns = 1
                btnAtkCat.Visible = False
                btnFake.Visible = False
                P2H += 30
                If P2H > 100 Then
                    trkPly2.Value = 100
                Else
                    trkPly2.Value += 30
                End If
                btnAtk.BackColor = Color.Red
                btnHeal.BackColor = Color.Red
                lblPly2.ForeColor = Color.Yellow
                lblPly2.Text = ("I don't need to attack; thats how bad you are!")
                Delay(0.75)
                lblPly2.ForeColor = Color.White
                lblPly2.Text = ("I don't need to attack; thats how bad you are!")

            Case Turns = 1

                Turns = 2
                btnAtkEgg.Visible = False
                btnFake.Visible = False
                P1H += 30
                If P1H > 100 Then
                    trkPly1.Value = 100
                Else
                    trkPly1.Value += 30
                End If
                btnAtk.BackColor = Color.DodgerBlue
                btnHeal.BackColor = Color.DodgerBlue
                lblPly1.ForeColor = Color.Yellow
                lblPly1.Text = ("Free health? Why not? Thanks!")
                Delay(0.75)
                lblPly1.ForeColor = Color.White
                lblPly1.Text = ("Free health? Why not? Thanks!")


        End Select

    End Sub
    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click

        TabMain.SelectedIndex = 1

    End Sub
    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() 'Allows windows messages to be processed
        Loop

    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        TabMain.SelectedIndex = 0

    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click

        Me.Close()

    End Sub

    Private Sub trkPly1_ValueChanged(sender As Object, e As EventArgs) Handles trkPly1.ValueChanged

        lblPly1H.Text = trkPly1.Value
        If trkPly1.Value = 0 Then
            MessageBox.Show("SpaceX WINS!")
        End If

    End Sub

    Private Sub trkPly2_ValueChanged(sender As Object, e As EventArgs) Handles trkPly2.ValueChanged

        lblPly2H.Text = trkPly2.Value
        If trkPly2.Value = 0 Then
            MessageBox.Show("Tesla WINS!")
        End If

    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click

        TabMain.SelectedIndex = 0
        btnAtk.BackColor = Color.Red
        btnHeal.BackColor = Color.Red
        btnFake.Visible = False
        btnAtkEgg.Visible = False
        btnAtkCat.Visible = False
        Turns = 1
        lblPly1H.Text = 100
        trkPly1.Value = lblPly1H.Text
        lblPly2H.Text = 100
        trkPly2.Value = lblPly2H.Text
        P1H = 100
        P2H = 100
        lblPly1.Text = "Are you ready to go SpaceX?"
        lblPly2.Text = "I was born ready!"


    End Sub

End Class
