Imports System.IO

Public Class Form1
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim bw As BinaryWriter

    Dim sr As StreamWriter

    Dim MoveName As String = String.Empty

    Dim effect As Integer
    Dim random As Integer

    Dim Typing As Integer
    Dim PP As Integer
    Dim EffectProc As Integer
    Dim Targets As Integer

    Dim DoesDamage As Boolean
    Dim UserMove As Boolean
    Dim SpecialTarget As Boolean
    Dim Snatchable As Boolean
    Dim Blockable As Boolean
    Dim Priority As Integer
    Dim AttackType As Integer
    'o = none
    '1 = spikes
    '2 = selfdestruct moves
    '3 = recoil moves/damaging moves that lower user's stats
    '4 = charge/recharge moves
    '5 = nevermiss
    '6 = more damage w/ more hp
    '7 = more damage w/ less hp
    '8 = 2-hit moves
    '9 = 3-hit moves
    '10 = 2-5 hit moves
    '11 = good status moves/status moves that don't need much pp
    '12 = 1-hit ko moves
    '13 = curse
    '14 = nature power
    '15 = hidden power and moves that have unique damage formulas
    Dim EffectChance As Integer
    '0 = none
    '1 = should be a small chance
    '2 = should be a medium chance
    '3 = should be a high chance
    Dim Cato As Integer
    '0 = physical
    '1 = special
    '2 = status
    Dim Power As Integer
    Dim Accuracy As Integer

    Dim GameType As Integer = -1
    '0 = ruby u 1.0
    '1 = sapphire u 1.0
    '2 = emerald u
    '3 = fire red u 1.0
    '4 = leaf green u 1.1
    '5 = fire red u 1.1
    '6 = leaf green u 1.0
    '7 = ruby u 1.1
    '8 = sapphire u 1.1

    Dim spoilerfile As String = Application.StartupPath & "\spoilers.txt"
    Dim Bugtext As String = Application.StartupPath & "\RandomNames\Bug.txt"
    Dim Darktext As String = Application.StartupPath & "\RandomNames\Dark.txt"
    Dim Dragontext As String = Application.StartupPath & "\RandomNames\Dragon.txt"
    Dim Electrictext As String = Application.StartupPath & "\RandomNames\Electric.txt"
    Dim Fighttext As String = Application.StartupPath & "\RandomNames\Fight.txt"
    Dim Firetext As String = Application.StartupPath & "\RandomNames\Fire.txt"
    Dim Flyingtext As String = Application.StartupPath & "\RandomNames\Flying.txt"
    Dim Ghosttext As String = Application.StartupPath & "\RandomNames\Ghost.txt"
    Dim Grasstext As String = Application.StartupPath & "\RandomNames\Grass.txt"
    Dim Icetext As String = Application.StartupPath & "\RandomNames\Ice.txt"
    Dim Poisontext As String = Application.StartupPath & "\RandomNames\Poison.txt"
    Dim Psychictext As String = Application.StartupPath & "\RandomNames\Psychic.txt"
    Dim Rocktext As String = Application.StartupPath & "\RandomNames\Rock.txt"
    Dim Groundtext As String = Application.StartupPath & "\RandomNames\Ground.txt"
    Dim Steeltext As String = Application.StartupPath & "\RandomNames\Steel.txt"
    Dim Watertext As String = Application.StartupPath & "\RandomNames\Water.txt"
    Dim Normaltext As String = Application.StartupPath & "\RandomNames\Neutral.txt"
    Dim Phytext As String = Application.StartupPath & "\RandomNames\2Physical.txt"
    Dim Spetext As String = Application.StartupPath & "\RandomNames\2Special.txt"
    Dim Statustext As String = Application.StartupPath & "\RandomNames\2Status.txt"
    Dim Userstatustext As String = Application.StartupPath & "\RandomNames\2SelfStatus.txt"
    'array stuff, kill me
    Dim bugarray(100) As String
    Dim darkarray(100) As String
    Dim dragonarray(100) As String
    Dim electricarray(100) As String
    Dim fightarray(100) As String
    Dim firearray(100) As String
    Dim flyingarray(100) As String
    Dim ghostarray(100) As String
    Dim grassarray(100) As String
    Dim groundarray(100) As String
    Dim icearray(100) As String
    Dim normalarray(200) As String
    Dim poisonarray(100) As String
    Dim psychicarray(100) As String
    Dim rockarray(100) As String
    Dim steelarray(100) As String
    Dim waterarray(100) As String
    Dim physicalarray(7, 200) As String
    Dim specialarray(7, 200) As String
    Dim statusarray(7, 200) As String
    Dim userstatusarray(7, 200) As String
    Dim firstwordarry(1800) As String
    Dim secondwordarray(7, 800) As String
    Dim maxbug As Integer
    Dim maxdark As Integer
    Dim maxdragon As Integer
    Dim maxelectric As Integer
    Dim maxfight As Integer
    Dim maxfire As Integer
    Dim maxflying As Integer
    Dim maxghost As Integer
    Dim maxgrass As Integer
    Dim maxground As Integer
    Dim maxice As Integer
    Dim maxnormal As Integer
    Dim maxpoison As Integer
    Dim maxpsychic As Integer
    Dim maxrock As Integer
    Dim maxsteel As Integer
    Dim maxwater As Integer
    Dim maxfirst As Integer
    Dim maxphy(7) As Integer
    Dim maxspe(7) As Integer
    Dim maxstatus(7) As Integer
    Dim maxuserstatus(7) As Integer
    Dim maxsecond(7) As Integer



    Private Sub LoadRomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenRomToolStripMenuItem.Click
        OpenFile.Title = "Select ROM File"
        OpenFile.InitialDirectory = Application.StartupPath
        OpenFile.Filter = "GBA Files|*.gba"

        If OpenFile.ShowDialog() = DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(System.IO.Path.GetFullPath(OpenFile.FileName)) Then
                patchfile.Text = System.IO.Path.GetFullPath(OpenFile.FileName)
                Dim address As String
                Dim versionhex As String = ""
                fs = New FileStream(patchfile.Text, FileMode.Open)
                br = New BinaryReader(fs)
                address = &HAC
                br.BaseStream.Seek(address, SeekOrigin.Begin)
                versionhex = br.ReadByte()
                address += 1
                br.BaseStream.Seek(address, SeekOrigin.Begin)
                versionhex &= br.ReadByte()
                address += 1
                br.BaseStream.Seek(address, SeekOrigin.Begin)
                versionhex &= br.ReadByte()
                address += 1
                br.BaseStream.Seek(address, SeekOrigin.Begin)
                versionhex &= br.ReadByte()
                Select Case versionhex
                    Case "65888669"
                        address = &H1E2810
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex = br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        If versionhex = "50484850" Then
                            'GameType = 0
                            'lstboxgame.Text = "Ruby (U) 1.0"
                            MessageBox.Show("This appears to be a Pokemon Ruby ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                        Else
                            address = &H1E2828
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex = br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            If versionhex = "50484850" Then
                                GameType = 7
                                lstboxgame.Text = "Ruby (U) 1.1"
                            Else
                                MessageBox.Show("This appears to be a Pokemon Ruby ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                            End If
                        End If
                    Case "65888069"
                        address = &H1E27A0
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex = br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        If versionhex = "50484850" Then
                            'GameType = 1
                            'lstboxgame.Text = "Sapphire (U) 1.0"
                            MessageBox.Show("This appears to be a Pokemon Sapphire ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                        Else
                            address = &H1E27B8
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex = br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            If versionhex = "50484850" Then
                                GameType = 8
                                lstboxgame.Text = "Sapphire (U) 1.1"
                            Else
                                MessageBox.Show("This appears to be a Pokemon Sapphire ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                            End If
                        End If
                    Case "66806969"
                        address = &H2E9534
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex = br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        If versionhex = "50484853" Then
                            GameType = 2
                            lstboxgame.Text = "Emerald (U)"
                        Else
                            MessageBox.Show("This appears to be a Pokemon Emerald ROM," & vbNewLine & "however it doesn't seem to be US ROM." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                        End If
                    Case "66808269"
                        address = &H1E9F14
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex = br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        If versionhex = "50484852" Then
                            GameType = 3
                            lstboxgame.Text = "Fire Red (U) 1.0"
                        Else
                            address = &H1E9F84
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex = br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            If versionhex = "50484852" Then
                                GameType = 5
                                lstboxgame.Text = "Fire Red (U) 1.1"
                            Else
                                MessageBox.Show("This appears to be a Pokemon Fire Red ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                            End If
                        End If
                    Case "66807169"
                        address = &H1E9F60
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex = br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        address += 1
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        versionhex &= br.ReadByte()
                        If versionhex = "50484852" Then
                            GameType = 4
                            lstboxgame.Text = "Leaf Green (U) 1.1"
                        Else
                            address = &H1E9EF0
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex = br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            address += 1
                            br.BaseStream.Seek(address, SeekOrigin.Begin)
                            versionhex &= br.ReadByte()
                            If versionhex = "50484852" Then
                                'GameType = 6
                                'lstboxgame.Text = "Leaf Green (U) 1.0"
                                MessageBox.Show("This appears to be a Pokemon Leaf Green ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                            Else
                                MessageBox.Show("This appears to be a Pokemon Leaf Green ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                            End If
                        End If
                    Case Else
                        MessageBox.Show("ROM version doesn't match up with supported versions." & vbNewLine & "If this is wrong try manually correcting it" & vbNewLine & "with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                End Select
                br.Close()
                fs.Close()

            Else
                MsgBox("File doesn't exist!")
            End If
        End If
    End Sub

    Private Sub startrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startrand.Click
        If My.Computer.FileSystem.FileExists(patchfile.Text) And GameType >= 0 Then
            Randomize()
            Dim address As String
            fs = New FileStream(patchfile.Text, FileMode.Open)
            br = New BinaryReader(fs)
            bw = New BinaryWriter(fs)

            Dim index As Integer = 1
            Dim value As Byte
            Dim movedesc As String
            Dim textline As Integer = 0
            Dim canrename As Boolean = True

            If System.IO.File.Exists(spoilerfile) Then
                sr = New StreamWriter(spoilerfile)
            Else
                File.Create(spoilerfile).Dispose()
                sr = New StreamWriter(spoilerfile)
            End If

            If rndname.Checked Then
                If System.IO.File.Exists(Bugtext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Darktext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Dragontext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Electrictext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Fighttext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Firetext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Flyingtext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Ghosttext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Grasstext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Groundtext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Icetext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Normaltext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Poisontext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Psychictext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Rocktext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Steeltext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Watertext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Phytext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Spetext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Statustext) = False Then
                    canrename = False
                ElseIf System.IO.File.Exists(Userstatustext) = False Then
                    canrename = False
                End If
                If canrename = False Then
                    rndname.Checked = False
                    MsgBox("Missing renaming file(s), cannot rename moves!")
                Else
                    Call SetupNameArray("")
                End If
            End If


            Do While (index <= 354)


                Select Case GameType
                    Case 2
                        address = &H31C898 + (12 * index)
                    Case 3
                        address = &H250C04 + (12 * index)
                    Case 4
                        address = &H250C50 + (12 * index)
                    Case 5
                        address = &H250C74 + (12 * index)
                    Case 7
                        address = &H1FB144 + (12 * index)
                    Case 8
                        address = &H1FB0D4 + (12 * index)
                End Select


                AttackType = 0
                Priority = 0
                DoesDamage = True
                UserMove = False
                SpecialTarget = False
                Snatchable = False
                Blockable = True
                movedesc = ""
                EffectChance = 0
                Power = 0
                Accuracy = 0
                effect = 0
                Cato = -1

                'Move Effect
                If rndeffect.Checked Then
                    effect = CInt(Math.Floor((255 - 1 + 1) * Rnd())) + 1
                Else 'we still need to figure out the move's effect to properly randomize it
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    effect = br.ReadByte()
                End If
                Select Case effect
                    Case 1 'sleep
                        value = 1
                        DoesDamage = False
                        Cato = 2
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618A0D)
                            Case 3
                                Call ChangeDesc(index, &H8483426)
                            Case 4
                                Call ChangeDesc(index, &H8482D72)
                            Case 5
                                Call ChangeDesc(index, &H8483486)
                            Case 7
                                Call ChangeDesc(index, &H83BCEE8)
                        End Select
                    Case 2 'poison + dmg
                        value = 2
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86188D3)
                            Case 3
                                Call ChangeDesc(index, &H8483249)
                            Case 4
                                Call ChangeDesc(index, &H8482B95)
                            Case 5
                                Call ChangeDesc(index, &H84832A9)
                            Case 7
                                Call ChangeDesc(index, &H83BCDAE)
                        End Select
                    Case 3 'drain hp
                        value = 3
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618ECB)
                            Case 3
                                Call ChangeDesc(index, &H8483AC5)
                            Case 4
                                Call ChangeDesc(index, &H84833CE)
                            Case 5
                                Call ChangeDesc(index, &H8483AE2)
                            Case 7
                                Call ChangeDesc(index, &H83BD374)
                        End Select
                    Case 4 'burn + dmg
                        value = 4
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86182C9)
                            Case 3
                                Call ChangeDesc(index, &H84829C9)
                            Case 4
                                Call ChangeDesc(index, &H8482F0E)
                            Case 5
                                Call ChangeDesc(index, &H8483622)
                            Case 7
                                Call ChangeDesc(index, &H83BD00E)
                        End Select
                    Case 5 'freeze + dmg
                        value = 5
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86182EE)
                            Case 3
                                Call ChangeDesc(index, &H8482A11)
                            Case 4
                                Call ChangeDesc(index, &H848306B)
                            Case 5
                                Call ChangeDesc(index, &H848377F)
                            Case 7
                                Call ChangeDesc(index, &H83BD0F5)
                        End Select
                    Case 6 'para + dmg
                        value = 6
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618314)
                            Case 3
                                Call ChangeDesc(index, &H8482A53)
                            Case 4
                                Call ChangeDesc(index, &H84829EE)
                            Case 5
                                Call ChangeDesc(index, &H8483E9E)
                            Case 7
                                Call ChangeDesc(index, &H83BD62E)
                        End Select
                    Case 7 'selfdestruct
                        value = 7
                        AttackType = 2
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86197F0)
                            Case 3
                                Call ChangeDesc(index, &H84847A2)
                            Case 4
                                Call ChangeDesc(index, &H84840EE)
                            Case 5
                                Call ChangeDesc(index, &H8484802)
                            Case 7
                                Call ChangeDesc(index, &H83BDCCB)
                        End Select
                    Case 8 'dream eater
                        value = 8
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619B46)
                            Case 3
                                Call ChangeDesc(index, &H8484C75)
                            Case 4
                                Call ChangeDesc(index, &H84845C1)
                            Case 5
                                Call ChangeDesc(index, &H8484CD5)
                            Case 7
                                Call ChangeDesc(index, &H83BE01F)
                        End Select
                    Case 9 'mirror move
                        value = 9
                        Cato = 2
                        DoesDamage = False
                        SpecialTarget = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86197C2)
                            Case 3
                                Call ChangeDesc(index, &H848475E)
                            Case 4
                                Call ChangeDesc(index, &H84840AA)
                            Case 5
                                Call ChangeDesc(index, &H84847BE)
                            Case 7
                                Call ChangeDesc(index, &H83BDC9D)
                        End Select
                    Case 10 '+atk 1
                        value = 10
                        Cato = 2
                        UserMove = True
                        DoesDamage = False
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C18D)
                            Case 3
                                Call ChangeDesc(index, &H84881E1)
                            Case 4
                                Call ChangeDesc(index, &H8487B2D)
                            Case 5
                                Call ChangeDesc(index, &H8488241)
                            Case 7
                                Call ChangeDesc(index, &H83C065C)
                        End Select
                    Case 11 '+def 1
                        value = 11
                        Cato = 2
                        UserMove = True
                        DoesDamage = False
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861953D)
                            Case 3
                                Call ChangeDesc(index, &H84843E5)
                            Case 4
                                Call ChangeDesc(index, &H8483D31)
                            Case 5
                                Call ChangeDesc(index, &H8484445)
                            Case 7
                                Call ChangeDesc(index, &H83BDA18)
                        End Select
                    Case 13 '+sp.atk 1
                        value = 13
                        Cato = 2
                        UserMove = True
                        DoesDamage = False
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618F31)
                            Case 3
                                Call ChangeDesc(index, &H8483B57)
                            Case 4
                                Call ChangeDesc(index, &H84834A3)
                            Case 5
                                Call ChangeDesc(index, &H8483BB7)
                            Case 7
                                Call ChangeDesc(index, &H83BD40C)
                        End Select
                    Case 16 '+eva 1
                        value = 16
                        Cato = 2
                        UserMove = True
                        DoesDamage = False
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86194E4)
                            Case 3
                                Call ChangeDesc(index, &H8484353)
                            Case 4
                                Call ChangeDesc(index, &H8483C9F)
                            Case 5
                                Call ChangeDesc(index, &H84843B3)
                            Case 7
                                Call ChangeDesc(index, &H83BD9BF)
                        End Select
                    Case 17 'never miss
                        value = 17
                        AttackType = 5
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86199A1)
                            Case 3
                                Call ChangeDesc(index, &H8484A15)
                            Case 4
                                Call ChangeDesc(index, &H8484361)
                            Case 5
                                Call ChangeDesc(index, &H8484A75)
                            Case 7
                                Call ChangeDesc(index, &H83BDE7A)
                        End Select
                    Case 18 '-atk 1
                        value = 18
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86189BD)
                            Case 3
                                Call ChangeDesc(index, &H8483397)
                            Case 4
                                Call ChangeDesc(index, &H8482CE3)
                            Case 5
                                Call ChangeDesc(index, &H84833F7)
                            Case 7
                                Call ChangeDesc(index, &H83BCE98)
                        End Select
                    Case 19 '-def 1
                        value = 19
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86188A9)
                            Case 3
                                Call ChangeDesc(index, &H8483203)
                            Case 4
                                Call ChangeDesc(index, &H8482B4F)
                            Case 5
                                Call ChangeDesc(index, &H8483263)
                            Case 7
                                Call ChangeDesc(index, &H83BCD84)
                        End Select
                    Case 20 '-spd 1
                        value = 20
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861908B)
                            Case 3
                                Call ChangeDesc(index, &H8483D24)
                            Case 4
                                Call ChangeDesc(index, &H8483670)
                            Case 5
                                Call ChangeDesc(index, &H8483D84)
                            Case 7
                                Call ChangeDesc(index, &H83BD566)
                        End Select
                    Case 23 '-acc 1
                        value = 23
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619D3F)
                            Case 3
                                Call ChangeDesc(index, &H8484F20)
                            Case 4
                                Call ChangeDesc(index, &H8482856)
                            Case 5
                                Call ChangeDesc(index, &H84844D6)
                            Case 7
                                Call ChangeDesc(index, &H83BCB7B)
                        End Select
                    Case 24 '-eva 1
                        value = 24
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AD42)
                            Case 3
                                Call ChangeDesc(index, &H8486579)
                            Case 4
                                Call ChangeDesc(index, &H8485EC5)
                            Case 5
                                Call ChangeDesc(index, &H84865D9)
                            Case 7
                                Call ChangeDesc(index, &H83BF215)
                        End Select
                    Case 25 'haze
                        value = 25
                        Cato = 2
                        UserMove = True
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86196C1)
                            Case 3
                                Call ChangeDesc(index, &H8484606)
                            Case 4
                                Call ChangeDesc(index, &H8483F52)
                            Case 5
                                Call ChangeDesc(index, &H8484666)
                            Case 7
                                Call ChangeDesc(index, &H83BDB9C)
                        End Select
                    Case 26 'bide
                        value = 26
                        UserMove = True
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861975E)
                            Case 3
                                Call ChangeDesc(index, &H84846D3)
                            Case 4
                                Call ChangeDesc(index, &H848401F)
                            Case 5
                                Call ChangeDesc(index, &H8484733)
                            Case 7
                                Call ChangeDesc(index, &H83BDC39)
                        End Select
                    Case 27 'outrage
                        value = 27
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618847)
                            Case 3
                                Call ChangeDesc(index, &H8483178)
                            Case 4
                                Call ChangeDesc(index, &H848567C)
                            Case 5
                                Call ChangeDesc(index, &H8485D90)
                            Case 7
                                Call ChangeDesc(index, &H83BEC47)
                        End Select
                    Case 28 'whirlwind
                        value = 28
                        Cato = 2
                        DoesDamage = False
                        Priority = 250
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86184B8)
                            Case 3
                                Call ChangeDesc(index, &H8482C89)
                            Case 4
                                Call ChangeDesc(index, &H84825D5)
                            Case 5
                                Call ChangeDesc(index, &H8482CE9)
                            Case 7
                                Call ChangeDesc(index, &H83BC993)
                        End Select
                    Case 29 'hit 2-5
                        value = 29
                        AttackType = 10
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618219)
                            Case 3
                                Call ChangeDesc(index, &H84828BD)
                            Case 4
                                Call ChangeDesc(index, &H848291C)
                            Case 5
                                Call ChangeDesc(index, &H8483030)
                            Case 7
                                Call ChangeDesc(index, &H83BCBFD)
                        End Select
                    Case 30 'conversion
                        value = 30
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619F93)
                            Case 3
                                Call ChangeDesc(index, &H8485277)
                            Case 4
                                Call ChangeDesc(index, &H8484BC3)
                            Case 5
                                Call ChangeDesc(index, &H84852D7)
                            Case 7
                                Call ChangeDesc(index, &H83BE46C)
                        End Select
                    Case 31 'flinch
                        value = 31
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861898E)
                            Case 3
                                Call ChangeDesc(index, &H8483358)
                            Case 4
                                Call ChangeDesc(index, &H8482CA4)
                            Case 5
                                Call ChangeDesc(index, &H84833B8)
                            Case 7
                                Call ChangeDesc(index, &H83BCE69)
                        End Select
                    Case 32 'recover
                        value = 32
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619512)
                            Case 3
                                Call ChangeDesc(index, &H8484398)
                            Case 4
                                Call ChangeDesc(index, &H8483CE4)
                            Case 5
                                Call ChangeDesc(index, &H84843F8)
                            Case 7
                                Call ChangeDesc(index, &H83BD9ED)
                        End Select
                    Case 33 'toxic
                        value = 33
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86192AD)
                            Case 3
                                Call ChangeDesc(index, &H848400F)
                            Case 4
                                Call ChangeDesc(index, &H848395B)
                            Case 5
                                Call ChangeDesc(index, &H848406F)
                            Case 7
                                Call ChangeDesc(index, &H83BD788)
                        End Select
                    Case 34 'pay day
                        value = 34
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618296)
                            Case 3
                                Call ChangeDesc(index, &H8482985)
                            Case 4
                                Call ChangeDesc(index, &H84822D1)
                            Case 5
                                Call ChangeDesc(index, &H84829E5)
                            Case 7
                                Call ChangeDesc(index, &H83BC771)
                        End Select
                    Case 35 'light screen
                        value = 35
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861968D)
                            Case 3
                                Call ChangeDesc(index, &H84845C5)
                            Case 4
                                Call ChangeDesc(index, &H8483F11)
                            Case 5
                                Call ChangeDesc(index, &H8484625)
                            Case 7
                                Call ChangeDesc(index, &H83BDB68)
                        End Select
                    Case 36 'tri attack
                        value = 36
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619FC5)
                            Case 3
                                Call ChangeDesc(index, &H84852B8)
                            Case 4
                                Call ChangeDesc(index, &H8484C04)
                            Case 5
                                Call ChangeDesc(index, &H8485318)
                            Case 7
                                Call ChangeDesc(index, &H83BE49D)
                        End Select
                    Case 37 'rest
                        value = 37
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619ED1)
                            Case 3
                                Call ChangeDesc(index, &H848515E)
                            Case 4
                                Call ChangeDesc(index, &H8484AAA)
                            Case 5
                                Call ChangeDesc(index, &H84851BE)
                            Case 7
                                Call ChangeDesc(index, &H83BE3AA)
                        End Select
                    Case 38 '1-hit ko
                        value = 38
                        AttackType = 12
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618753)
                            Case 3
                                Call ChangeDesc(index, &H8483014)
                            Case 4
                                Call ChangeDesc(index, &H8482960)
                            Case 5
                                Call ChangeDesc(index, &H8483074)
                            Case 7
                                Call ChangeDesc(index, &H83BCC2E)
                        End Select
                    Case 39 'razor wind
                        value = 39
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86183C9)
                            Case 3
                                Call ChangeDesc(index, &H8482B46)
                            Case 4
                                Call ChangeDesc(index, &H8482492)
                            Case 5
                                Call ChangeDesc(index, &H8482BA6)
                            Case 7
                                Call ChangeDesc(index, &H83BC8A4)
                        End Select
                    Case 40 'super fang
                        value = 40
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619FF2)
                            Case 3
                                Call ChangeDesc(index, &H8485301)
                            Case 4
                                Call ChangeDesc(index, &H8484C4D)
                            Case 5
                                Call ChangeDesc(index, &H8485361)
                            Case 7
                                Call ChangeDesc(index, &H83BE4CA)
                        End Select
                    Case 41 'dragon rage
                        value = 41
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86190BA)
                            Case 3
                                Call ChangeDesc(index, &H8483D6B)
                            Case 4
                                Call ChangeDesc(index, &H84836B7)
                            Case 5
                                Call ChangeDesc(index, &H8483DCB)
                            Case 7
                                Call ChangeDesc(index, &H83BD595)
                        End Select
                    Case 42 'traping move bind
                        value = 42
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618522)
                            Case 3
                                Call ChangeDesc(index, &H8482D1D)
                            Case 4
                                Call ChangeDesc(index, &H8482669)
                            Case 5
                                Call ChangeDesc(index, &H8482D7D)
                            Case 7
                                Call ChangeDesc(index, &H83BC9FD)
                        End Select
                    Case 43 'high crit
                        value = 43
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A027)
                            Case 3
                                Call ChangeDesc(index, &H848533C)
                            Case 4
                                Call ChangeDesc(index, &H8484C88)
                            Case 5
                                Call ChangeDesc(index, &H848539C)
                            Case 7
                                Call ChangeDesc(index, &H83BE4FF)
                        End Select
                    Case 44 'hit twice
                        value = 44
                        AttackType = 8
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86185DF)
                            Case 3
                                Call ChangeDesc(index, &H8482E08)
                            Case 4
                                Call ChangeDesc(index, &H8482754)
                            Case 5
                                Call ChangeDesc(index, &H8482E68)
                            Case 7
                                Call ChangeDesc(index, &H83BCABA)
                        End Select
                    Case 45 'jump kick
                        value = 45
                        AttackType = 3
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618642)
                            Case 3
                                Call ChangeDesc(index, &H8482E83)
                            Case 4
                                Call ChangeDesc(index, &H84827CF)
                            Case 5
                                Call ChangeDesc(index, &H8482EE3)
                            Case 7
                                Call ChangeDesc(index, &H83BCB1D)
                        End Select
                    Case 46 'mist
                        value = 46
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618B63)
                            Case 3
                                Call ChangeDesc(index, &H8483606)
                            Case 4
                                Call ChangeDesc(index, &H8482F52)
                            Case 5
                                Call ChangeDesc(index, &H8483666)
                            Case 7
                                Call ChangeDesc(index, &H83BD03E)
                        End Select
                    Case 47 'focus energy
                        value = 47
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861972F)
                            Case 3
                                Call ChangeDesc(index, &H8484689)
                            Case 4
                                Call ChangeDesc(index, &H8483FD5)
                            Case 5
                                Call ChangeDesc(index, &H84846E9)
                            Case 7
                                Call ChangeDesc(index, &H83BDC0A)
                        End Select
                    Case 48 '1/4 recoil
                        value = 48
                        AttackType = 3
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618814)
                            Case 3
                                Call ChangeDesc(index, &H8483130)
                            Case 4
                                Call ChangeDesc(index, &H8482A7C)
                            Case 5
                                Call ChangeDesc(index, &H8483190)
                            Case 7
                                Call ChangeDesc(index, &H83BCCEF)
                        End Select
                    Case 49 'confusion
                        value = 49
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618A40)
                            Case 3
                                Call ChangeDesc(index, &H848346C)
                            Case 4
                                Call ChangeDesc(index, &H8483E01)
                            Case 5
                                Call ChangeDesc(index, &H8484515)
                            Case 7
                                Call ChangeDesc(index, &H83BDAA8)
                        End Select
                    Case 50 '+atk 2
                        value = 50
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86183FD)
                            Case 3
                                Call ChangeDesc(index, &H8482B94)
                            Case 4
                                Call ChangeDesc(index, &H84824E0)
                            Case 5
                                Call ChangeDesc(index, &H8482BF4)
                            Case 7
                                Call ChangeDesc(index, &H83BC8D8)
                        End Select
                    Case 51 '+def 2
                        value = 51
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C130)
                            Case 3
                                Call ChangeDesc(index, &H8488153)
                            Case 4
                                Call ChangeDesc(index, &H8487A9F)
                            Case 5
                                Call ChangeDesc(index, &H84881B3)
                            Case 7
                                Call ChangeDesc(index, &H83C05FF)
                        End Select
                    Case 52 '+spd 2
                        value = 52
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619391)
                            Case 3
                                Call ChangeDesc(index, &H8484165)
                            Case 4
                                Call ChangeDesc(index, &H8483AB1)
                            Case 5
                                Call ChangeDesc(index, &H84841C5)
                            Case 7
                                Call ChangeDesc(index, &H83BD86C)
                        End Select
                    Case 53 '+sp.atk 2
                        value = 53
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B96D)
                            Case 3
                                Call ChangeDesc(index, &H84876A7)
                            Case 4
                                Call ChangeDesc(index, &H8486FF3)
                            Case 5
                                Call ChangeDesc(index, &H8487707)
                            Case 7
                                Call ChangeDesc(index, &H83BFE3C)
                        End Select
                    Case 54 '+sp.def 2
                        value = 54
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619A59)
                            Case 3
                                Call ChangeDesc(index, &H8484B27)
                            Case 4
                                Call ChangeDesc(index, &H8484473)
                            Case 5
                                Call ChangeDesc(index, &H8484B87)
                            Case 7
                                Call ChangeDesc(index, &H83BDF32)
                        End Select
                    Case 57 'transform
                        value = 57
                        Cato = 2
                        DoesDamage = False
                        Blockable = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619C76)
                            Case 3
                                Call ChangeDesc(index, &H8484E18)
                            Case 4
                                Call ChangeDesc(index, &H8484764)
                            Case 5
                                Call ChangeDesc(index, &H8484E78)
                            Case 7
                                Call ChangeDesc(index, &H83BE14F)
                        End Select
                    Case 58 '-atk2
                        value = 58
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B9FE)
                            Case 3
                                Call ChangeDesc(index, &H8487771)
                            Case 4
                                Call ChangeDesc(index, &H84870BD)
                            Case 5
                                Call ChangeDesc(index, &H84877D1)
                            Case 7
                                Call ChangeDesc(index, &H83BFECD)
                        End Select
                    Case 59 '-def 2
                        value = 59
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86194AF)
                            Case 3
                                Call ChangeDesc(index, &H848430A)
                            Case 4
                                Call ChangeDesc(index, &H8483C56)
                            Case 5
                                Call ChangeDesc(index, &H848436A)
                            Case 7
                                Call ChangeDesc(index, &H83BD98A)
                        End Select
                    Case 60 '-spd 2
                        value = 60
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A455)
                            Case 3
                                Call ChangeDesc(index, &H84858E2)
                            Case 4
                                Call ChangeDesc(index, &H848522E)
                            Case 5
                                Call ChangeDesc(index, &H8485942)
                            Case 7
                                Call ChangeDesc(index, &H83BE92D)
                        End Select
                    Case 62 '-sp.def 2
                        value = 62
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BE4D)
                            Case 3
                                Call ChangeDesc(index, &H8487D68)
                            Case 4
                                Call ChangeDesc(index, &H848750B)
                            Case 5
                                Call ChangeDesc(index, &H8487C1F)
                            Case 7
                                Call ChangeDesc(index, &H83C031C)
                        End Select
                    Case 65 'reflect
                        value = 65
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86196F8)
                            Case 3
                                Call ChangeDesc(index, &H8484647)
                            Case 4
                                Call ChangeDesc(index, &H8483F93)
                            Case 5
                                Call ChangeDesc(index, &H84846A7)
                            Case 7
                                Call ChangeDesc(index, &H83BDBD3)
                        End Select
                    Case 66 'poison
                        value = 66
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618FC8)
                            Case 3
                                Call ChangeDesc(index, &H8483C22)
                            Case 4
                                Call ChangeDesc(index, &H848356E)
                            Case 5
                                Call ChangeDesc(index, &H8483C82)
                            Case 7
                                Call ChangeDesc(index, &H83BD4A3)
                        End Select
                    Case 67 'paralyze
                        value = 67
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619189)
                            Case 3
                                Call ChangeDesc(index, &H8483E80)
                            Case 4
                                Call ChangeDesc(index, &H84837CC)
                            Case 5
                                Call ChangeDesc(index, &H8483EE0)
                            Case 7
                                Call ChangeDesc(index, &H83BD664)
                        End Select
                    Case 68 '-atk 1 + dmg
                        value = 68
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618CE0)
                            Case 3
                                Call ChangeDesc(index, &H848382A)
                            Case 4
                                Call ChangeDesc(index, &H8483176)
                            Case 5
                                Call ChangeDesc(index, &H848388A)
                            Case 7
                                Call ChangeDesc(index, &H83BD1BB)
                        End Select
                    Case 69 '-def 1 + dmg
                        value = 69
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AD69)
                            Case 3
                                Call ChangeDesc(index, &H84865BF)
                            Case 4
                                Call ChangeDesc(index, &H8485F0B)
                            Case 5
                                Call ChangeDesc(index, &H848661F)
                            Case 7
                                Call ChangeDesc(index, &H83BF23C)
                        End Select
                    Case 70 '-spd 1 + dmg
                        value = 70
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619CAB)
                            Case 3
                                Call ChangeDesc(index, &H8484E60)
                            Case 4
                                Call ChangeDesc(index, &H8487C8D)
                            Case 5
                                Call ChangeDesc(index, &H84883A1)
                            Case 7
                                Call ChangeDesc(index, &H83C0748)
                        End Select
                    Case 71 '-sp.atk 1 + dmg
                        value = 71
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B9CC)
                            Case 3
                                Call ChangeDesc(index, &H848772D)
                            Case 4
                                Call ChangeDesc(index, &H8487079)
                            Case 5
                                Call ChangeDesc(index, &H848778D)
                            Case 7
                                Call ChangeDesc(index, &H83BFE9B)
                        End Select
                    Case 72 '-sp.def 1 + dmg
                        value = 72
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B060)
                            Case 3
                                Call ChangeDesc(index, &H8486A1B)
                            Case 4
                                Call ChangeDesc(index, &H8487032)
                            Case 5
                                Call ChangeDesc(index, &H8487746)
                            Case 7
                                Call ChangeDesc(index, &H83BFE69)
                        End Select
                    Case 73 '-acc 1 + dmg
                        value = 73
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A54C)
                            Case 3
                                Call ChangeDesc(index, &H8485A30)
                            Case 4
                                Call ChangeDesc(index, &H848537C)
                            Case 5
                                Call ChangeDesc(index, &H8485A90)
                            Case 7
                                Call ChangeDesc(index, &H83BEA24)
                        End Select
                    Case 75 'sky attack
                        value = 75
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619C41)
                            Case 3
                                Call ChangeDesc(index, &H8484DCD)
                            Case 4
                                Call ChangeDesc(index, &H8484719)
                            Case 5
                                Call ChangeDesc(index, &H8484E2D)
                            Case 7
                                Call ChangeDesc(index, &H83BE11A)
                        End Select
                    Case 76 'confuse + dmg
                        value = 76
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619CDF)
                            Case 3
                                Call ChangeDesc(index, &H8484EA4)
                            Case 4
                                Call ChangeDesc(index, &H84830ED)
                            Case 5
                                Call ChangeDesc(index, &H8483801)
                            Case 7
                                Call ChangeDesc(index, &H83BD15C)
                        End Select
                    Case 77 'hit twice + poison
                        value = 77
                        AttackType = 8
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618905)
                            Case 3
                                Call ChangeDesc(index, &H848328B)
                            Case 4
                                Call ChangeDesc(index, &H8482BD7)
                            Case 5
                                Call ChangeDesc(index, &H84832EB)
                            Case 7
                                Call ChangeDesc(index, &H83BCDE0)
                        End Select
                    Case 78 'vital throw
                        value = 78
                        AttackType = 5
                        Priority = 255
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861ADCB)
                            Case 3
                                Call ChangeDesc(index, &H8486651)
                            Case 4
                                Call ChangeDesc(index, &H8485F9D)
                            Case 5
                                Call ChangeDesc(index, &H84866B1)
                            Case 7
                                Call ChangeDesc(index, &H83BF29E)
                        End Select
                    Case 79 'subsitute
                        value = 79
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A05F)
                            Case 3
                                Call ChangeDesc(index, &H8485382)
                            Case 4
                                Call ChangeDesc(index, &H8484CCE)
                            Case 5
                                Call ChangeDesc(index, &H84853E2)
                            Case 7
                                Call ChangeDesc(index, &H83BE537)
                        End Select
                    Case 80 'recharge
                        value = 80
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618D14)
                            Case 3
                                Call ChangeDesc(index, &H848386D)
                            Case 4
                                Call ChangeDesc(index, &H84831B9)
                            Case 5
                                Call ChangeDesc(index, &H84838CD)
                            Case 7
                                Call ChangeDesc(index, &H83BD1EF)
                        End Select
                    Case 81 'rage
                        value = 81
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86193EE)
                            Case 3
                                Call ChangeDesc(index, &H84841E9)
                            Case 4
                                Call ChangeDesc(index, &H8483B35)
                            Case 5
                                Call ChangeDesc(index, &H8484249)
                            Case 7
                                Call ChangeDesc(index, &H83BD8C9)
                        End Select
                    Case 82 'mimic
                        value = 82
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861947E)
                            Case 3
                                Call ChangeDesc(index, &H84842C0)
                            Case 4
                                Call ChangeDesc(index, &H8483C0C)
                            Case 5
                                Call ChangeDesc(index, &H8484320)
                            Case 7
                                Call ChangeDesc(index, &H83BD959)
                        End Select
                    Case 83 'metronome
                        value = 83
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861978E)
                            Case 3
                                Call ChangeDesc(index, &H8484715)
                            Case 4
                                Call ChangeDesc(index, &H8484061)
                            Case 5
                                Call ChangeDesc(index, &H8484775)
                            Case 7
                                Call ChangeDesc(index, &H83BDC69)
                        End Select
                    Case 84 'leechlife
                        value = 84
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619BDB)
                            Case 3
                                Call ChangeDesc(index, &H8484D42)
                            Case 4
                                Call ChangeDesc(index, &H848468E)
                            Case 5
                                Call ChangeDesc(index, &H8484DA2)
                            Case 7
                                Call ChangeDesc(index, &H83BE0B4)
                        End Select
                    Case 85 'splash
                        value = 85
                    Case 86 'disable
                        value = 86
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618AAB)
                            Case 3
                                Call ChangeDesc(index, &H84834ED)
                            Case 4
                                Call ChangeDesc(index, &H8482E39)
                            Case 5
                                Call ChangeDesc(index, &H848354D)
                            Case 7
                                Call ChangeDesc(index, &H83BCF86)
                        End Select
                    Case 87 'damage = lvl
                        value = 87
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618E3F)
                            Case 3
                                Call ChangeDesc(index, &H84839F8)
                            Case 4
                                Call ChangeDesc(index, &H8483344)
                            Case 5
                                Call ChangeDesc(index, &H8483A58)
                            Case 7
                                Call ChangeDesc(index, &H83BD31A)
                        End Select
                    Case 88 'psywave
                        value = 88
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619D74)
                            Case 3
                                Call ChangeDesc(index, &H8484F6A)
                            Case 4
                                Call ChangeDesc(index, &H84848B6)
                            Case 5
                                Call ChangeDesc(index, &H8484FCA)
                            Case 7
                                Call ChangeDesc(index, &H83BE24D)
                        End Select
                    Case 89 'counter
                        value = 89
                        Cato = 0
                        DoesDamage = False
                        SpecialTarget = True
                        AttackType = 15
                        Priority = 251
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618E0C)
                            Case 3
                                Call ChangeDesc(index, &H84839AE)
                            Case 4
                                Call ChangeDesc(index, &H84832FA)
                            Case 5
                                Call ChangeDesc(index, &H8483A0E)
                            Case 7
                                Call ChangeDesc(index, &H83BD2E7)
                        End Select
                    Case 90 'encore
                        value = 90
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861ACA8)
                            Case 3
                                Call ChangeDesc(index, &H848649F)
                            Case 4
                                Call ChangeDesc(index, &H8485DEB)
                            Case 5
                                Call ChangeDesc(index, &H84864FF)
                            Case 7
                                Call ChangeDesc(index, &H83BF17B)
                        End Select
                    Case 91 'pain split
                        value = 91
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AB46)
                            Case 3
                                Call ChangeDesc(index, &H84862AB)
                            Case 4
                                Call ChangeDesc(index, &H8485BF7)
                            Case 5
                                Call ChangeDesc(index, &H848630B)
                            Case 7
                                Call ChangeDesc(index, &H83BF019)
                        End Select
                    Case 92 'snore
                        value = 92
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A22F)
                            Case 3
                                Call ChangeDesc(index, &H84855E9)
                            Case 4
                                Call ChangeDesc(index, &H8484F35)
                            Case 5
                                Call ChangeDesc(index, &H8485649)
                            Case 7
                                Call ChangeDesc(index, &H83BE707)
                        End Select
                    Case 93 'Conversion 2
                        value = 93
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A2C0)
                            Case 3
                                Call ChangeDesc(index, &H84856C1)
                            Case 4
                                Call ChangeDesc(index, &H848500D)
                            Case 5
                                Call ChangeDesc(index, &H8485721)
                            Case 7
                                Call ChangeDesc(index, &H83BE798)
                        End Select
                    Case 94 'lock-on
                        value = 94
                        Cato = 2
                        DoesDamage = False
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A73C)
                            Case 3
                                Call ChangeDesc(index, &H8485CF0)
                            Case 4
                                Call ChangeDesc(index, &H848563C)
                            Case 5
                                Call ChangeDesc(index, &H8485D50)
                            Case 7
                                Call ChangeDesc(index, &H83BEC15)
                        End Select
                    Case 95 'sketch
                        value = 95
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A0CF)
                            Case 3
                                Call ChangeDesc(index, &H8485405)
                            Case 4
                                Call ChangeDesc(index, &H8484D51)
                            Case 5
                                Call ChangeDesc(index, &H8485465)
                            Case 7
                                Call ChangeDesc(index, &H83BE5A7)
                        End Select
                    Case 97 'sleep talk
                        value = 97
                        Cato = 2
                        DoesDamage = False
                        SpecialTarget = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AA1D)
                            Case 3
                                Call ChangeDesc(index, &H8486105)
                            Case 4
                                Call ChangeDesc(index, &H8485A51)
                            Case 5
                                Call ChangeDesc(index, &H8486165)
                            Case 7
                                Call ChangeDesc(index, &H83BEEF6)
                        End Select
                    Case 98 'desting bond
                        value = 98
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A644)
                            Case 3
                                Call ChangeDesc(index, &H8485B9C)
                            Case 4
                                Call ChangeDesc(index, &H84854E8)
                            Case 5
                                Call ChangeDesc(index, &H8485BFC)
                            Case 7
                                Call ChangeDesc(index, &H83BEB1D)
                        End Select
                    Case 99 'reversal
                        value = 99
                        AttackType = 7
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A359)
                            Case 3
                                Call ChangeDesc(index, &H8485679)
                            Case 4
                                Call ChangeDesc(index, &H84850E4)
                            Case 5
                                Call ChangeDesc(index, &H84857F8)
                            Case 7
                                Call ChangeDesc(index, &H83BE831)
                        End Select
                    Case 100 'spite
                        value = 100
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B1E6)
                            Case 3
                                Call ChangeDesc(index, &H84857DF)
                            Case 4
                                Call ChangeDesc(index, &H848512B)
                            Case 5
                                Call ChangeDesc(index, &H848583F)
                            Case 7
                                Call ChangeDesc(index, &H83BE862)
                        End Select
                    Case 101 'false swipe
                        value = 101
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A897)
                            Case 3
                                Call ChangeDesc(index, &H8485EE1)
                            Case 4
                                Call ChangeDesc(index, &H848582D)
                            Case 5
                                Call ChangeDesc(index, &H8485F41)
                            Case 7
                                Call ChangeDesc(index, &H83BED70)
                        End Select
                    Case 102 'heal party status
                        value = 102
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BCEB)
                            Case 3
                                Call ChangeDesc(index, &H8487B71)
                            Case 4
                                Call ChangeDesc(index, &H8485A91)
                            Case 5
                                Call ChangeDesc(index, &H84861A5)
                            Case 7
                                Call ChangeDesc(index, &H83BEF1E)
                        End Select
                    Case 103 'quick attack
                        value = 103
                        Priority = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86193BA)
                            Case 3
                                Call ChangeDesc(index, &H84841A8)
                            Case 4
                                Call ChangeDesc(index, &H8483AF4)
                            Case 5
                                Call ChangeDesc(index, &H8484208)
                            Case 7
                                Call ChangeDesc(index, &H83BD895)
                        End Select
                    Case 104 '3x hit
                        value = 104
                        AttackType = 9
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A0F7)
                            Case 3
                                Call ChangeDesc(index, &H8485446)
                            Case 4
                                Call ChangeDesc(index, &H8484D92)
                            Case 5
                                Call ChangeDesc(index, &H84854A6)
                            Case 7
                                Call ChangeDesc(index, &H83BE5CF)
                        End Select
                    Case 105 'thief
                        value = 105
                        AttackType = 8
                        EffectChance = 2
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A12D)
                            Case 3
                                Call ChangeDesc(index, &H848548B)
                            Case 4
                                Call ChangeDesc(index, &H8484DD7)
                            Case 5
                                Call ChangeDesc(index, &H84854EB)
                            Case 7
                                Call ChangeDesc(index, &H83BE605)
                        End Select
                    Case 106 'trap
                        value = 106
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A9B7)
                            Case 3
                                Call ChangeDesc(index, &H8486075)
                            Case 4
                                Call ChangeDesc(index, &H84859C1)
                            Case 5
                                Call ChangeDesc(index, &H84860D5)
                            Case 7
                                Call ChangeDesc(index, &H83BEE90)
                        End Select
                    Case 107 'nightmare
                        value = 107
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A1CE)
                            Case 3
                                Call ChangeDesc(index, &H8485560)
                            Case 4
                                Call ChangeDesc(index, &H8484EAC)
                            Case 5
                                Call ChangeDesc(index, &H84855C0)
                            Case 7
                                Call ChangeDesc(index, &H83BE6A6)
                        End Select
                    Case 108 'minimize
                        value = 108
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861956C)
                            Case 3
                                Call ChangeDesc(index, &H848442E)
                            Case 4
                                Call ChangeDesc(index, &H8483D7A)
                            Case 5
                                Call ChangeDesc(index, &H848448E)
                            Case 7
                                Call ChangeDesc(index, &H83BDA47)
                        End Select
                    Case 109 'curse
                        value = 109
                        Cato = 2
                        DoesDamage = False
                        AttackType = 13
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A261)
                            Case 3
                                Call ChangeDesc(index, &H848562F)
                            Case 4
                                Call ChangeDesc(index, &H8484F7B)
                            Case 5
                                Call ChangeDesc(index, &H848568F)
                            Case 7
                                Call ChangeDesc(index, &H83BE739)
                        End Select
                    Case 111 'protect
                        value = 111
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Priority = 3
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A3EF)
                            Case 3
                                Call ChangeDesc(index, &H8485857)
                            Case 4
                                Call ChangeDesc(index, &H84851A3)
                            Case 5
                                Call ChangeDesc(index, &H84858B7)
                            Case 7
                                Call ChangeDesc(index, &H83BE8C7)
                        End Select
                    Case 112 'spikes
                        value = 112
                        Cato = 2
                        DoesDamage = False
                        AttackType = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A5B0)
                            Case 3
                                Call ChangeDesc(index, &H8485AC1)
                            Case 4
                                Call ChangeDesc(index, &H848540D)
                            Case 5
                                Call ChangeDesc(index, &H8485B21)
                            Case 7
                                Call ChangeDesc(index, &H83BEA88)
                        End Select
                    Case 113 'foresight
                        value = 113
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A611)
                            Case 3
                                Call ChangeDesc(index, &H8485B55)
                            Case 4
                                Call ChangeDesc(index, &H84854A1)
                            Case 5
                                Call ChangeDesc(index, &H8485BB5)
                            Case 7
                                Call ChangeDesc(index, &H83BEAEA)
                        End Select
                    Case 114 'perish song
                        value = 114
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A677)
                            Case 3
                                Call ChangeDesc(index, &H8485BDE)
                            Case 4
                                Call ChangeDesc(index, &H848552A)
                            Case 5
                                Call ChangeDesc(index, &H8485C3E)
                            Case 7
                                Call ChangeDesc(index, &H83BEB50)
                        End Select
                    Case 115 'sandstorm
                        value = 115
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A7A0)
                            Case 3
                                Call ChangeDesc(index, &H8485D77)
                            Case 4
                                Call ChangeDesc(index, &H84856C3)
                            Case 5
                                Call ChangeDesc(index, &H8485DD7)
                            Case 7
                                Call ChangeDesc(index, &H83BEC79)
                        End Select
                    Case 116 'endure
                        value = 116
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Priority = 3
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A802)
                            Case 3
                                Call ChangeDesc(index, &H8485E09)
                            Case 4
                                Call ChangeDesc(index, &H8485755)
                            Case 5
                                Call ChangeDesc(index, &H8485E69)
                            Case 7
                                Call ChangeDesc(index, &H83BECDB)
                        End Select
                    Case 117 'rollout
                        value = 117
                        AttackType = 8
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A866)
                            Case 3
                                Call ChangeDesc(index, &H8485EA0)
                            Case 4
                                Call ChangeDesc(index, &H84857EC)
                            Case 5
                                Call ChangeDesc(index, &H8485F00)
                            Case 7
                                Call ChangeDesc(index, &H83BED3F)
                        End Select
                    Case 118 'swagger
                        value = 118
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A8C9)
                            Case 3
                                Call ChangeDesc(index, &H8485F24)
                            Case 4
                                Call ChangeDesc(index, &H8485870)
                            Case 5
                                Call ChangeDesc(index, &H8485F84)
                            Case 7
                                Call ChangeDesc(index, &H83BEDA2)
                        End Select
                    Case 119 'fury cutter
                        value = 119
                        AttackType = 9
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A957)
                            Case 3
                                Call ChangeDesc(index, &H8485FF5)
                            Case 4
                                Call ChangeDesc(index, &H8485941)
                            Case 5
                                Call ChangeDesc(index, &H8486055)
                            Case 7
                                Call ChangeDesc(index, &H83BEE30)
                        End Select
                    Case 120 'attract
                        value = 120
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A9EC)
                            Case 3
                                Call ChangeDesc(index, &H84860B7)
                            Case 4
                                Call ChangeDesc(index, &H8485A03)
                            Case 5
                                Call ChangeDesc(index, &H8486117)
                            Case 7
                                Call ChangeDesc(index, &H83BEEC5)
                        End Select
                    Case 121 'return
                        value = 121
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AA7F)
                            Case 3
                                Call ChangeDesc(index, &H8486187)
                            Case 4
                                Call ChangeDesc(index, &H8485AD3)
                            Case 5
                                Call ChangeDesc(index, &H84861E7)
                            Case 7
                                Call ChangeDesc(index, &H83BEF52)
                        End Select
                    Case 122 'present
                        value = 122
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AAB2)
                            Case 3
                                Call ChangeDesc(index, &H84861D1)
                            Case 4
                                Call ChangeDesc(index, &H8485B1D)
                            Case 5
                                Call ChangeDesc(index, &H8486231)
                            Case 7
                                Call ChangeDesc(index, &H83BEF85)
                        End Select
                    Case 123 'frustration
                        value = 123
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AAE0)
                            Case 3
                                Call ChangeDesc(index, &H848621B)
                            Case 4
                                Call ChangeDesc(index, &H8485B67)
                            Case 5
                                Call ChangeDesc(index, &H848627B)
                            Case 7
                                Call ChangeDesc(index, &H83BEFB3)
                        End Select
                    Case 124 'safeguard
                        value = 124
                        Cato = 2
                        DoesDamage = False
                        Snatchable = True
                        UserMove = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AB17)
                            Case 3
                                Call ChangeDesc(index, &H8486265)
                            Case 4
                                Call ChangeDesc(index, &H8485BB1)
                            Case 5
                                Call ChangeDesc(index, &H84862C5)
                            Case 7
                                Call ChangeDesc(index, &H83BEFEA)
                        End Select
                    Case 125 'burn + damage + thaws
                        value = 125
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A200)
                            Case 3
                                Call ChangeDesc(index, &H84855AA)
                            Case 4
                                Call ChangeDesc(index, &H8484EF6)
                            Case 5
                                Call ChangeDesc(index, &H848560A)
                            Case 7
                                Call ChangeDesc(index, &H83BE6D8)
                        End Select
                    Case 126 'magnitude
                        value = 126
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861ABAC)
                            Case 3
                                Call ChangeDesc(index, &H8486330)
                            Case 4
                                Call ChangeDesc(index, &H8485C7C)
                            Case 5
                                Call ChangeDesc(index, &H8486390)
                            Case 7
                                Call ChangeDesc(index, &H83BF07F)
                        End Select
                    Case 127 'batonpass
                        value = 127
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AC73)
                            Case 3
                                Call ChangeDesc(index, &H8486455)
                            Case 4
                                Call ChangeDesc(index, &H8485DA1)
                            Case 5
                                Call ChangeDesc(index, &H84864B5)
                            Case 7
                                Call ChangeDesc(index, &H83BF146)
                        End Select
                    Case 128 'pursuit
                        value = 128
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861ACDE)
                            Case 3
                                Call ChangeDesc(index, &H84864E8)
                            Case 4
                                Call ChangeDesc(index, &H8485E34)
                            Case 5
                                Call ChangeDesc(index, &H8486548)
                            Case 7
                                Call ChangeDesc(index, &H83BF1B1)
                        End Select
                    Case 129 'rapid spin
                        value = 129
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AD12)
                            Case 3
                                Call ChangeDesc(index, &H8486532)
                            Case 4
                                Call ChangeDesc(index, &H8485E7E)
                            Case 5
                                Call ChangeDesc(index, &H8486592)
                            Case 7
                                Call ChangeDesc(index, &H83BF1E5)
                        End Select
                    Case 130 'sonic boom
                        value = 130
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618A74)
                            Case 3
                                Call ChangeDesc(index, &H84834A8)
                            Case 4
                                Call ChangeDesc(index, &H8482DF4)
                            Case 5
                                Call ChangeDesc(index, &H8483508)
                            Case 7
                                Call ChangeDesc(index, &H83BCF4F)
                        End Select
                    Case 132 'morning sun
                        value = 132
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861ADFC)
                            Case 3
                                Call ChangeDesc(index, &H8486693)
                            Case 4
                                Call ChangeDesc(index, &H8485FDF)
                            Case 5
                                Call ChangeDesc(index, &H84866F3)
                            Case 7
                                Call ChangeDesc(index, &H83BF2CF)
                        End Select
                    Case 133 'synthesis
                        value = 133
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AE2D)
                            Case 3
                                Call ChangeDesc(index, &H84866DE)
                            Case 4
                                Call ChangeDesc(index, &H848602A)
                            Case 5
                                Call ChangeDesc(index, &H848673E)
                            Case 7
                                Call ChangeDesc(index, &H83BF300)
                        End Select
                    Case 134 'moonlight
                        value = 134
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AE5E)
                            Case 3
                                Call ChangeDesc(index, &H8486729)
                            Case 4
                                Call ChangeDesc(index, &H8486075)
                            Case 5
                                Call ChangeDesc(index, &H8486789)
                            Case 7
                                Call ChangeDesc(index, &H83BF331)
                        End Select
                    Case 135 'hidden power
                        value = 135
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AE8F)
                            Case 3
                                Call ChangeDesc(index, &H8486774)
                            Case 4
                                Call ChangeDesc(index, &H84860C0)
                            Case 5
                                Call ChangeDesc(index, &H84867D4)
                            Case 7
                                Call ChangeDesc(index, &H83BF362)
                        End Select
                    Case 136 'rain dance
                        value = 136
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AF19)
                            Case 3
                                Call ChangeDesc(index, &H848683A)
                            Case 4
                                Call ChangeDesc(index, &H8486186)
                            Case 5
                                Call ChangeDesc(index, &H848689A)
                            Case 7
                                Call ChangeDesc(index, &H83BF3EC)
                        End Select
                    Case 137 'sunny day
                        value = 137
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AF4C)
                            Case 3
                                Call ChangeDesc(index, &H848687C)
                            Case 4
                                Call ChangeDesc(index, &H84861C8)
                            Case 5
                                Call ChangeDesc(index, &H84868DC)
                            Case 7
                                Call ChangeDesc(index, &H83BF41F)
                        End Select
                    Case 138 '+def + dmg
                        value = 138
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A98A)
                            Case 3
                                Call ChangeDesc(index, &H848602B)
                            Case 4
                                Call ChangeDesc(index, &H8485977)
                            Case 5
                                Call ChangeDesc(index, &H848608B)
                            Case 7
                                Call ChangeDesc(index, &H83BEE63)
                        End Select
                    Case 139 '+atk + dmg
                        value = 139
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AD9B)
                            Case 3
                                Call ChangeDesc(index, &H8486606)
                            Case 4
                                Call ChangeDesc(index, &H8485F52)
                            Case 5
                                Call ChangeDesc(index, &H8486666)
                            Case 7
                                Call ChangeDesc(index, &H83BF26E)
                        End Select
                    Case 140 '+all + dmg
                        value = 140
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B03C)
                            Case 3
                                Call ChangeDesc(index, &H84869CF)
                            Case 4
                                Call ChangeDesc(index, &H848631B)
                            Case 5
                                Call ChangeDesc(index, &H8486A2F)
                            Case 7
                                Call ChangeDesc(index, &H83BF50F)
                        End Select
                    Case 142 'bellydrum
                        value = 142
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861A4F0)
                            Case 3
                                Call ChangeDesc(index, &H84859AE)
                            Case 4
                                Call ChangeDesc(index, &H84852FA)
                            Case 5
                                Call ChangeDesc(index, &H8485A0E)
                            Case 7
                                Call ChangeDesc(index, &H83BE9C8)
                        End Select
                    Case 143 'psych up
                        value = 143
                        Cato = 2
                        DoesDamage = False
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AFE3)
                            Case 3
                                Call ChangeDesc(index, &H8486941)
                            Case 4
                                Call ChangeDesc(index, &H848628D)
                            Case 5
                                Call ChangeDesc(index, &H84869A1)
                            Case 7
                                Call ChangeDesc(index, &H83BF4B6)
                        End Select
                    Case 144 'mirror coat
                        value = 144
                        Cato = 1
                        DoesDamage = False
                        SpecialTarget = True
                        Priority = 251
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AFAC)
                            Case 3
                                Call ChangeDesc(index, &H84868FE)
                            Case 4
                                Call ChangeDesc(index, &H848624A)
                            Case 5
                                Call ChangeDesc(index, &H848695E)
                            Case 7
                                Call ChangeDesc(index, &H83BF47F)
                        End Select
                    Case 145 'skullbash
                        value = 145
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86199CA)
                            Case 3
                                Call ChangeDesc(index, &H8484A57)
                            Case 4
                                Call ChangeDesc(index, &H84843A3)
                            Case 5
                                Call ChangeDesc(index, &H8484AB7)
                            Case 7
                                Call ChangeDesc(index, &H83BDEA3)
                        End Select
                    Case 146 'twister
                        EffectChance = 1
                        value = 146
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861AEEA)
                            Case 3
                                Call ChangeDesc(index, &H84867FB)
                            Case 4
                                Call ChangeDesc(index, &H8486147)
                            Case 5
                                Call ChangeDesc(index, &H848685B)
                            Case 7
                                Call ChangeDesc(index, &H83BF3BD)
                        End Select
                    Case 147 'earthquack
                        value = 147
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861920F)
                            Case 3
                                Call ChangeDesc(index, &H8483F44)
                            Case 4
                                Call ChangeDesc(index, &H8483890)
                            Case 5
                                Call ChangeDesc(index, &H8483FA4)
                            Case 7
                                Call ChangeDesc(index, &H83BD6EA)
                        End Select
                    Case 148 'doom desire
                        value = 148
                        AttackType = 3
                        Blockable = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B095)
                            Case 3
                                Call ChangeDesc(index, &H8486A62)
                            Case 4
                                Call ChangeDesc(index, &H8487FA6)
                            Case 5
                                Call ChangeDesc(index, &H84886BA)
                            Case 7
                                Call ChangeDesc(index, &H83C0988)
                        End Select
                    Case 149 'gust
                        value = 149
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618457)
                            Case 3
                                Call ChangeDesc(index, &H8482C16)
                            Case 4
                                Call ChangeDesc(index, &H8482562)
                            Case 5
                                Call ChangeDesc(index, &H8482C76)
                            Case 7
                                Call ChangeDesc(index, &H83BC932)
                        End Select
                    Case 150 'stomp
                        value = 150
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86185A8)
                            Case 3
                                Call ChangeDesc(index, &H8482DC8)
                            Case 4
                                Call ChangeDesc(index, &H8482714)
                            Case 5
                                Call ChangeDesc(index, &H8482E28)
                            Case 7
                                Call ChangeDesc(index, &H83BCA83)
                        End Select
                    Case 151 'solar beam
                        value = 151
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618F95)
                            Case 3
                                Call ChangeDesc(index, &H8483BDA)
                            Case 4
                                Call ChangeDesc(index, &H8483526)
                            Case 5
                                Call ChangeDesc(index, &H8483C3A)
                            Case 7
                                Call ChangeDesc(index, &H83BD470)
                        End Select
                    Case 152 'thunder
                        value = 152
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H86191BC)
                            Case 3
                                Call ChangeDesc(index, &H8483EC2)
                            Case 4
                                Call ChangeDesc(index, &H848380E)
                            Case 5
                                Call ChangeDesc(index, &H8483F22)
                            Case 7
                                Call ChangeDesc(index, &H83BD697)
                        End Select
                    Case 153 'teleport
                        value = 153
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861941D)
                            Case 3
                                Call ChangeDesc(index, &H848422E)
                            Case 4
                                Call ChangeDesc(index, &H8483B7A)
                            Case 5
                                Call ChangeDesc(index, &H848428E)
                            Case 7
                                Call ChangeDesc(index, &H83BD8F8)
                        End Select
                    Case 154 'beat up
                        value = 154
                        AttackType = 9
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B12C)
                            Case 3
                                Call ChangeDesc(index, &H8486B36)
                            Case 4
                                Call ChangeDesc(index, &H8486482)
                            Case 5
                                Call ChangeDesc(index, &H8486B96)
                            Case 7
                                Call ChangeDesc(index, &H83BF5FF)
                        End Select
                    Case 155 'dig/fly/dive etc
                        value = 155
                        random = CInt(Math.Floor((4 - 1 + 1) * Rnd())) + 1
                        Select Case random
                            Case 1 'dig
                                Select Case GameType
                                    Case 2
                                        Call ChangeDesc(index, &H8619276)
                                        Call ChangeAnim(index, &H82CCCA1)
                                    Case 3
                                        Call ChangeDesc(index, &H8483FC7)
                                        Call ChangeAnim(index, &H81CA841)
                                    Case 4
                                        Call ChangeDesc(index, &H8483913)
                                        Call ChangeAnim(index, &H81CA88D)
                                    Case 5
                                        Call ChangeDesc(index, &H8484027)
                                        Call ChangeAnim(index, &H81CA8B1)
                                    Case 7
                                        Call ChangeDesc(index, &H83BD751)
                                        Call ChangeAnim(index, &H81CB0B9)
                                End Select
                            Case 2 'fly
                                Select Case GameType
                                    Case 2
                                        Call ChangeDesc(index, &H86184EA)
                                        Call ChangeAnim(index, &H82D1FE6)
                                    Case 3
                                        Call ChangeDesc(index, &H8482CD3)
                                        Call ChangeAnim(index, &H81CFC1D)
                                    Case 4
                                        Call ChangeDesc(index, &H848261F)
                                        Call ChangeAnim(index, &H81CFC69)
                                    Case 5
                                        Call ChangeDesc(index, &H8482D33)
                                        Call ChangeAnim(index, &H81CFC8D)
                                    Case 7
                                        Call ChangeDesc(index, &H83BC9C5)
                                        Call ChangeAnim(index, &H81D0487)
                                End Select
                            Case 3 'dive
                                Select Case GameType
                                    Case 2
                                        Call ChangeDesc(index, &H861B8CA)
                                        Call ChangeAnim(index, &H82D653D)
                                    Case 3
                                        Call ChangeDesc(index, &H84875E5)
                                        Call ChangeAnim(index, &H81D4169)
                                    Case 4
                                        Call ChangeDesc(index, &H8486F31)
                                        Call ChangeAnim(index, &H81D41B5)
                                    Case 5
                                        Call ChangeDesc(index, &H8487645)
                                        Call ChangeAnim(index, &H81D41D9)
                                    Case 7
                                        Call ChangeDesc(index, &H83BFD99)
                                        Call ChangeAnim(index, &H81D49BD)
                                End Select
                            Case 4 'bounce
                                EffectChance = 1
                                Select Case GameType
                                    Case 2
                                        Call ChangeDesc(index, &H861C246)
                                        Call ChangeAnim(index, &H82D2050)
                                    Case 3
                                        Call ChangeDesc(index, &H84882FB)
                                        Call ChangeAnim(index, &H81CFC87)
                                    Case 4
                                        Call ChangeDesc(index, &H8487C47)
                                        Call ChangeAnim(index, &H81CFCD3)
                                    Case 5
                                        Call ChangeDesc(index, &H848835B)
                                        Call ChangeAnim(index, &H81CFCF7)
                                    Case 7
                                        Call ChangeDesc(index, &H83C0715)
                                        Call ChangeAnim(index, &H81D04F1)
                                End Select
                        End Select

                    Case 156 'defense curl
                        value = 156
                        Cato = 2
                        DoesDamage = False
                        Snatchable = True
                        UserMove = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861962C)
                            Case 3
                                Call ChangeDesc(index, &H848453C)
                            Case 4
                                Call ChangeDesc(index, &H8483E88)
                            Case 5
                                Call ChangeDesc(index, &H848459C)
                            Case 7
                                Call ChangeDesc(index, &H83BDB07)
                        End Select
                    Case 157 'soft boiled
                        value = 157
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8619AB4)
                            Case 3
                                Call ChangeDesc(index, &H8484BA1)
                            Case 4
                                Call ChangeDesc(index, &H84844ED)
                            Case 5
                                Call ChangeDesc(index, &H8484C01)
                            Case 7
                                Call ChangeDesc(index, &H83BDF8D)
                        End Select
                    Case 158 'fakeout
                        value = 158
                        Priority = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B159)
                            Case 3
                                Call ChangeDesc(index, &H8486B7E)
                            Case 4
                                Call ChangeDesc(index, &H84864CA)
                            Case 5
                                Call ChangeDesc(index, &H8486BDE)
                            Case 7
                                Call ChangeDesc(index, &H83BF62C)
                        End Select
                    Case 159 'uproar
                        value = 159
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B18C)
                            Case 3
                                Call ChangeDesc(index, &H8486BC7)
                            Case 4
                                Call ChangeDesc(index, &H8486513)
                            Case 5
                                Call ChangeDesc(index, &H8486C27)
                            Case 7
                                Call ChangeDesc(index, &H83BF65F)
                        End Select
                    Case 160 'stockpile
                        value = 160
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B1C2)
                            Case 3
                                Call ChangeDesc(index, &H8486C10)
                            Case 4
                                Call ChangeDesc(index, &H848655C)
                            Case 5
                                Call ChangeDesc(index, &H8486C70)
                            Case 7
                                Call ChangeDesc(index, &H83BF695)
                        End Select
                    Case 161 'Spit Up
                        value = 161
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B1E6)
                            Case 3
                                Call ChangeDesc(index, &H8486C55)
                            Case 4
                                Call ChangeDesc(index, &H84865A1)
                            Case 5
                                Call ChangeDesc(index, &H8486CB5)
                            Case 7
                                Call ChangeDesc(index, &H83BF6B9)
                        End Select
                    Case 162 'Swallow
                        value = 162
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B217)
                            Case 3
                                Call ChangeDesc(index, &H8486C95)
                            Case 4
                                Call ChangeDesc(index, &H84865E1)
                            Case 5
                                Call ChangeDesc(index, &H8486CF5)
                            Case 7
                                Call ChangeDesc(index, &H83BF6EA)
                        End Select
                    Case 164 'hail
                        value = 164
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B276)
                            Case 3
                                Call ChangeDesc(index, &H8486D1C)
                            Case 4
                                Call ChangeDesc(index, &H8486668)
                            Case 5
                                Call ChangeDesc(index, &H8486D7C)
                            Case 7
                                Call ChangeDesc(index, &H83BF749)
                        End Select
                    Case 165 'torment
                        value = 165
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B2A3)
                            Case 3
                                Call ChangeDesc(index, &H8486D64)
                            Case 4
                                Call ChangeDesc(index, &H84866B0)
                            Case 5
                                Call ChangeDesc(index, &H8486DC4)
                            Case 7
                                Call ChangeDesc(index, &H83BF776)
                        End Select
                    Case 166 'flatter
                        value = 166
                        Cato = 2
                        DoesDamage = False
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B2D8)
                            Case 3
                                Call ChangeDesc(index, &H8486DB1)
                            Case 4
                                Call ChangeDesc(index, &H84866FD)
                            Case 5
                                Call ChangeDesc(index, &H8486E11)
                            Case 7
                                Call ChangeDesc(index, &H83BF7AB)
                        End Select
                    Case 167 'burn
                        value = 167
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B302)
                            Case 3
                                Call ChangeDesc(index, &H8486DF2)
                            Case 4
                                Call ChangeDesc(index, &H848673E)
                            Case 5
                                Call ChangeDesc(index, &H8486E52)
                            Case 7
                                Call ChangeDesc(index, &H83BF7D5)
                        End Select
                    Case 168 'memento
                        value = 168
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B330)
                            Case 3
                                Call ChangeDesc(index, &H8486E37)
                            Case 4
                                Call ChangeDesc(index, &H8486783)
                            Case 5
                                Call ChangeDesc(index, &H8486E97)
                            Case 7
                                Call ChangeDesc(index, &H83BF803)
                        End Select
                    Case 169 'facade
                        value = 169
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B360)
                            Case 3
                                Call ChangeDesc(index, &H8486E79)
                            Case 4
                                Call ChangeDesc(index, &H84867C5)
                            Case 5
                                Call ChangeDesc(index, &H8486ED9)
                            Case 7
                                Call ChangeDesc(index, &H83BF833)
                        End Select
                    Case 170 'focus punch
                        value = 170
                        Priority = 253
                        AttackType = 4
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B393)
                            Case 3
                                Call ChangeDesc(index, &H8486EBE)
                            Case 4
                                Call ChangeDesc(index, &H848680A)
                            Case 5
                                Call ChangeDesc(index, &H8486F1E)
                            Case 7
                                Call ChangeDesc(index, &H83BF866)
                        End Select
                    Case 171 'smelling salt
                        value = 171
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B3C8)
                            Case 3
                                Call ChangeDesc(index, &H8486F04)
                            Case 4
                                Call ChangeDesc(index, &H8486850)
                            Case 5
                                Call ChangeDesc(index, &H8486F64)
                            Case 7
                                Call ChangeDesc(index, &H83BF89B)
                        End Select
                    Case 172 'follow me
                        value = 172
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Priority = 3
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B3FE)
                            Case 3
                                Call ChangeDesc(index, &H8486F50)
                            Case 4
                                Call ChangeDesc(index, &H848689C)
                            Case 5
                                Call ChangeDesc(index, &H8486FB0)
                            Case 7
                                Call ChangeDesc(index, &H83BF8D1)
                        End Select
                    Case 173 'nature power
                        value = 173
                        AttackType = 14
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B431)
                            Case 3
                                Call ChangeDesc(index, &H8486F96)
                            Case 4
                                Call ChangeDesc(index, &H84868E2)
                            Case 5
                                Call ChangeDesc(index, &H8486FF6)
                            Case 7
                                Call ChangeDesc(index, &H83BF904)
                        End Select
                    Case 174 'charge
                        value = 174
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B466)
                            Case 3
                                Call ChangeDesc(index, &H8486FD4)
                            Case 4
                                Call ChangeDesc(index, &H8486920)
                            Case 5
                                Call ChangeDesc(index, &H8487034)
                            Case 7
                                Call ChangeDesc(index, &H83BF939)
                        End Select
                    Case 175 'taunt
                        value = 175
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B49A)
                            Case 3
                                Call ChangeDesc(index, &H8487014)
                            Case 4
                                Call ChangeDesc(index, &H8486960)
                            Case 5
                                Call ChangeDesc(index, &H8487074)
                            Case 7
                                Call ChangeDesc(index, &H83BF96D)
                        End Select
                    Case 176 'helping hand
                        value = 176
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Blockable = False
                        Priority = 5
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B4C7)
                            Case 3
                                Call ChangeDesc(index, &H848705C)
                            Case 4
                                Call ChangeDesc(index, &H84869A8)
                            Case 5
                                Call ChangeDesc(index, &H84870BC)
                            Case 7
                                Call ChangeDesc(index, &H83BF99A)
                        End Select
                    Case 177 'trick
                        value = 177
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B4F2)
                            Case 3
                                Call ChangeDesc(index, &H848709B)
                            Case 4
                                Call ChangeDesc(index, &H84869E7)
                            Case 5
                                Call ChangeDesc(index, &H84870FB)
                            Case 7
                                Call ChangeDesc(index, &H83BF9C5)
                        End Select
                    Case 178 'role play
                        value = 178
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B51A)
                            Case 3
                                Call ChangeDesc(index, &H84870DD)
                            Case 4
                                Call ChangeDesc(index, &H8486A29)
                            Case 5
                                Call ChangeDesc(index, &H848713D)
                            Case 7
                                Call ChangeDesc(index, &H83BF9ED)
                        End Select
                    Case 179 'wish
                        value = 179
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B54C)
                            Case 3
                                Call ChangeDesc(index, &H848711E)
                            Case 4
                                Call ChangeDesc(index, &H8486A6A)
                            Case 5
                                Call ChangeDesc(index, &H848717E)
                            Case 7
                                Call ChangeDesc(index, &H83BFA1F)
                        End Select
                    Case 180 'assist
                        value = 180
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B57C)
                            Case 3
                                Call ChangeDesc(index, &H8487163)
                            Case 4
                                Call ChangeDesc(index, &H8486AAF)
                            Case 5
                                Call ChangeDesc(index, &H84871C3)
                            Case 7
                                Call ChangeDesc(index, &H83BFA4F)
                        End Select
                    Case 181 'ingrain
                        value = 181
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B5AE)
                            Case 3
                                Call ChangeDesc(index, &H84871A1)
                            Case 4
                                Call ChangeDesc(index, &H8486AED)
                            Case 5
                                Call ChangeDesc(index, &H8487201)
                            Case 7
                                Call ChangeDesc(index, &H83BFA81)
                        End Select
                    Case 182 'damage + -atk & def
                        value = 182
                        AttackType = 3
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B5E5)
                            Case 3
                                Call ChangeDesc(index, &H84871E9)
                            Case 4
                                Call ChangeDesc(index, &H8486B35)
                            Case 5
                                Call ChangeDesc(index, &H8487249)
                            Case 7
                                Call ChangeDesc(index, &H83BFAB8)
                        End Select
                    Case 183 'magic coat
                        value = 183
                        Cato = 2
                        DoesDamage = False
                        SpecialTarget = True
                        Priority = 4
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B614)
                            Case 3
                                Call ChangeDesc(index, &H8487234)
                            Case 4
                                Call ChangeDesc(index, &H8486B80)
                            Case 5
                                Call ChangeDesc(index, &H8487294)
                            Case 7
                                Call ChangeDesc(index, &H83BFAE7)
                        End Select
                    Case 184 'recycle
                        value = 184
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B643)
                            Case 3
                                Call ChangeDesc(index, &H8487276)
                            Case 4
                                Call ChangeDesc(index, &H8486BC2)
                            Case 5
                                Call ChangeDesc(index, &H84872D6)
                            Case 7
                                Call ChangeDesc(index, &H83BFB16)
                        End Select
                    Case 185 'revenge
                        value = 185
                        Priority = 252
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B66A)
                            Case 3
                                Call ChangeDesc(index, &H84872AA)
                            Case 4
                                Call ChangeDesc(index, &H8486BF6)
                            Case 5
                                Call ChangeDesc(index, &H848730A)
                            Case 7
                                Call ChangeDesc(index, &H83BFB3D)
                        End Select
                    Case 186 'brick break
                        value = 186
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B69C)
                            Case 3
                                Call ChangeDesc(index, &H84872F2)
                            Case 4
                                Call ChangeDesc(index, &H8486C3E)
                            Case 5
                                Call ChangeDesc(index, &H8487352)
                            Case 7
                                Call ChangeDesc(index, &H83BFB6F)
                        End Select
                    Case 187 'yawn
                        value = 187
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B6D1)
                            Case 3
                                Call ChangeDesc(index, &H8487338)
                            Case 4
                                Call ChangeDesc(index, &H8486C84)
                            Case 5
                                Call ChangeDesc(index, &H8487398)
                            Case 7
                                Call ChangeDesc(index, &H83BFBA4)
                        End Select
                    Case 188 'knock off
                        value = 188
                        EffectChance = 2
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B706)
                            Case 3
                                Call ChangeDesc(index, &H8487378)
                            Case 4
                                Call ChangeDesc(index, &H8486CC4)
                            Case 5
                                Call ChangeDesc(index, &H84873D8)
                            Case 7
                                Call ChangeDesc(index, &H83BFBD9)
                        End Select
                    Case 189 'endeavour
                        value = 189
                        DoesDamage = False
                        AttackType = 7
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B73A)
                            Case 3
                                Call ChangeDesc(index, &H84873BE)
                            Case 4
                                Call ChangeDesc(index, &H8486D0A)
                            Case 5
                                Call ChangeDesc(index, &H848741E)
                            Case 7
                                Call ChangeDesc(index, &H83BFC0D)
                        End Select
                    Case 190 'erruption
                        value = 190
                        AttackType = 6
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B773)
                            Case 3
                                Call ChangeDesc(index, &H84873FB)
                            Case 4
                                Call ChangeDesc(index, &H8486D47)
                            Case 5
                                Call ChangeDesc(index, &H848745B)
                            Case 7
                                Call ChangeDesc(index, &H83BFC46)
                        End Select
                    Case 191 'skill swap
                        value = 191
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B7A5)
                            Case 3
                                Call ChangeDesc(index, &H848743C)
                            Case 4
                                Call ChangeDesc(index, &H8486D88)
                            Case 5
                                Call ChangeDesc(index, &H848749C)
                            Case 7
                                Call ChangeDesc(index, &H83BFC78)
                        End Select
                    Case 192 'Imprision
                        value = 192
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B7D7)
                            Case 3
                                Call ChangeDesc(index, &H848747F)
                            Case 4
                                Call ChangeDesc(index, &H8486DCB)
                            Case 5
                                Call ChangeDesc(index, &H84874DF)
                            Case 7
                                Call ChangeDesc(index, &H83BFCAA)
                        End Select
                    Case 193 'refresh
                        value = 193
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B809)
                            Case 3
                                Call ChangeDesc(index, &H84874C1)
                            Case 4
                                Call ChangeDesc(index, &H8486E0D)
                            Case 5
                                Call ChangeDesc(index, &H8487521)
                            Case 7
                                Call ChangeDesc(index, &H83BFCDC)
                        End Select
                    Case 194 'grudge
                        value = 194
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B830)
                            Case 3
                                Call ChangeDesc(index, &H848750D)
                            Case 4
                                Call ChangeDesc(index, &H8486E59)
                            Case 5
                                Call ChangeDesc(index, &H848756D)
                            Case 7
                                Call ChangeDesc(index, &H83BFD03)
                        End Select
                    Case 195 'snatch
                        value = 195
                        Cato = 2
                        DoesDamage = False
                        SpecialTarget = True
                        Blockable = False
                        Priority = 4
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B867)
                            Case 3
                                Call ChangeDesc(index, &H8487558)
                            Case 4
                                Call ChangeDesc(index, &H8486EA4)
                            Case 5
                                Call ChangeDesc(index, &H84875B8)
                            Case 7
                                Call ChangeDesc(index, &H83BFD39)
                        End Select
                    Case 196 'lowkick
                        value = 196
                        DoesDamage = False
                        AttackType = 15
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618DDA)
                            Case 3
                                Call ChangeDesc(index, &H848396E)
                            Case 4
                                Call ChangeDesc(index, &H84832BA)
                            Case 5
                                Call ChangeDesc(index, &H84839CE)
                            Case 7
                                Call ChangeDesc(index, &H83BD2B5)
                        End Select
                    Case 197 'secret power
                        value = 197
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B89C)
                            Case 3
                                Call ChangeDesc(index, &H848759A)
                            Case 4
                                Call ChangeDesc(index, &H8486EE6)
                            Case 5
                                Call ChangeDesc(index, &H84875FA)
                            Case 7
                                Call ChangeDesc(index, &H83BFD6B)
                        End Select
                    Case 198 'volt-tackle/double-edge
                        value = 198
                        AttackType = 3
                        random = CInt(Math.Floor((3 - 1 + 1) * Rnd())) + 1
                        If random = 1 Then
                            EffectChance = 1
                        Else
                            EffectChance = 0
                        End If
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C300)
                            Case 3
                                Call ChangeDesc(index, &H8488408)
                            Case 4
                                Call ChangeDesc(index, &H8487D54)
                            Case 5
                                Call ChangeDesc(index, &H8488468)
                            Case 7
                                Call ChangeDesc(index, &H83C07CF)
                        End Select
                    Case 199 'teeter dance
                        value = 199
                        DoesDamage = False
                        Cato = 2
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BA33)
                            Case 3
                                Call ChangeDesc(index, &H84877BB)
                            Case 4
                                Call ChangeDesc(index, &H8487107)
                            Case 5
                                Call ChangeDesc(index, &H848781B)
                            Case 7
                                Call ChangeDesc(index, &H83BFF02)
                        End Select
                    Case 200 'burn + crit
                        value = 200
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BA56)
                            Case 3
                                Call ChangeDesc(index, &H84877F3)
                            Case 4
                                Call ChangeDesc(index, &H848713F)
                            Case 5
                                Call ChangeDesc(index, &H8487853)
                            Case 7
                                Call ChangeDesc(index, &H83BFF25)
                        End Select
                    Case 201 'mudsport
                        value = 201
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BA90)
                            Case 3
                                Call ChangeDesc(index, &H848783A)
                            Case 4
                                Call ChangeDesc(index, &H8487186)
                            Case 5
                                Call ChangeDesc(index, &H848789A)
                            Case 7
                                Call ChangeDesc(index, &H83BFF5F)
                        End Select
                    Case 202 'poison + crit
                        value = 202
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BB87)
                            Case 3
                                Call ChangeDesc(index, &H8487976)
                            Case 4
                                Call ChangeDesc(index, &H84872C2)
                            Case 5
                                Call ChangeDesc(index, &H84879D6)
                            Case 7
                                Call ChangeDesc(index, &H83C0056)
                        End Select
                    Case 203 'weather ball
                        value = 203
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BCB8)
                            Case 3
                                Call ChangeDesc(index, &H8487B2F)
                            Case 4
                                Call ChangeDesc(index, &H848747B)
                            Case 5
                                Call ChangeDesc(index, &H8487B8F)
                            Case 7
                                Call ChangeDesc(index, &H83C0187)
                        End Select
                    Case 204 'overheat -sp.atk
                        value = 204
                        AttackType = 3
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BD82)
                            Case 3
                                Call ChangeDesc(index, &H8487C46)
                            Case 4
                                Call ChangeDesc(index, &H8487592)
                            Case 5
                                Call ChangeDesc(index, &H8487CA6)
                            Case 7
                                Call ChangeDesc(index, &H83C0251)
                        End Select
                    Case 205 'tickle
                        value = 205
                        Cato = 2
                        DoesDamage = False
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BEB4)
                            Case 3
                                Call ChangeDesc(index, &H8487DEF)
                            Case 4
                                Call ChangeDesc(index, &H848773B)
                            Case 5
                                Call ChangeDesc(index, &H8487E4F)
                            Case 7
                                Call ChangeDesc(index, &H83C0383)
                        End Select
                    Case 206 '+1def & sp.def
                        value = 206
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BEE5)
                            Case 3
                                Call ChangeDesc(index, &H8487E30)
                            Case 4
                                Call ChangeDesc(index, &H848777C)
                            Case 5
                                Call ChangeDesc(index, &H8487E90)
                            Case 7
                                Call ChangeDesc(index, &H83C03B4)
                        End Select
                    Case 207 'sky uppercut
                        value = 207
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861BFDA)
                            Case 3
                                Call ChangeDesc(index, &H8487F76)
                            Case 4
                                Call ChangeDesc(index, &H84878C2)
                            Case 5
                                Call ChangeDesc(index, &H8487FD6)
                            Case 7
                                Call ChangeDesc(index, &H83C04A9)
                        End Select
                    Case 208 '+1def & atk
                        value = 208
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C212)
                            Case 3
                                Call ChangeDesc(index, &H84882B4)
                            Case 4
                                Call ChangeDesc(index, &H8487C00)
                            Case 5
                                Call ChangeDesc(index, &H8488314)
                            Case 7
                                Call ChangeDesc(index, &H83C06E1)
                        End Select
                    Case 209 'toxic + crit
                        value = 209
                        EffectChance = 1
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C2A1)
                            Case 3
                                Call ChangeDesc(index, &H8488383)
                            Case 4
                                Call ChangeDesc(index, &H8487CCF)
                            Case 5
                                Call ChangeDesc(index, &H84883E3)
                            Case 7
                                Call ChangeDesc(index, &H83C0770)
                        End Select
                    Case 210 'watersport
                        value = 210
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C367)
                            Case 3
                                Call ChangeDesc(index, &H848848A)
                            Case 4
                                Call ChangeDesc(index, &H8487DD6)
                            Case 5
                                Call ChangeDesc(index, &H84884EA)
                            Case 7
                                Call ChangeDesc(index, &H83C0836)
                        End Select
                    Case 211 '+1 sp.atk & sp.def
                        value = 211
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C39C)
                            Case 3
                                Call ChangeDesc(index, &H84884C5)
                            Case 4
                                Call ChangeDesc(index, &H8487E11)
                            Case 5
                                Call ChangeDesc(index, &H8488525)
                            Case 7
                                Call ChangeDesc(index, &H83C086B)
                        End Select
                    Case 212 '+1 atk & spd
                        value = 212
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        Snatchable = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861C401)
                            Case 3
                                Call ChangeDesc(index, &H848854F)
                            Case 4
                                Call ChangeDesc(index, &H8487E9B)
                            Case 5
                                Call ChangeDesc(index, &H84885AF)
                            Case 7
                                Call ChangeDesc(index, &H83C08D0)
                        End Select
                    Case 213 'camouflage
                        value = 213
                        Cato = 2
                        DoesDamage = False
                        UserMove = True
                        AttackType = 11
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H861B938)
                            Case 3
                                Call ChangeDesc(index, &H848766B)
                            Case 4
                                Call ChangeDesc(index, &H8486FB7)
                            Case 5
                                Call ChangeDesc(index, &H84876CB)
                            Case 7
                                Call ChangeDesc(index, &H83BFE07)
                        End Select
                    Case Else 'nothing
                        value = 0
                        effect = 0
                        Select Case GameType
                            Case 2
                                Call ChangeDesc(index, &H8618786)
                            Case 3
                                Call ChangeDesc(index, &H848305C)
                            Case 4
                                Call ChangeDesc(index, &H84829A8)
                            Case 5
                                Call ChangeDesc(index, &H84830BC)
                            Case 7
                                Call ChangeDesc(index, &H83BCC61)
                        End Select
                End Select
                If rndeffect.Checked Then
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                End If
                'Move Power
                address += 1
                If rndpower.Checked Then
                    If DoesDamage = True Then
                        If balancestats.Checked Then
                            Select Case AttackType
                                Case 2 'selfdestruct type moves
                                    value = CInt(Math.Floor((250 - 100 + 1) * Rnd())) + 100
                                Case 3, 6 'recoil moves/more dmg w/ more hp
                                    value = CInt(Math.Floor((175 - 90 + 1) * Rnd())) + 90
                                Case 4 'charge moves
                                    value = CInt(Math.Floor((175 - 100 + 1) * Rnd())) + 100
                                Case 5 'nevermiss moves
                                    value = CInt(Math.Floor((80 - 15 + 1) * Rnd())) + 15
                                Case 7 'do more damage with less health
                                    value = CInt(0)
                                Case 8 'double hit moves
                                    value = CInt(Math.Floor((45 - 20 + 1) * Rnd())) + 20
                                Case 9, 10 'triple hit moves and 2-5 hit moves
                                    value = CInt(Math.Floor((25 - 10 + 1) * Rnd())) + 10
                                Case 12 '1-hit ko moves
                                    value = CInt(0)
                                Case 14 'nature power
                                    value = CInt(0)
                                Case (15) 'Hidden power and other unique formula moves
                                    value = CInt(0)
                                Case Else
                                    value = CInt(Math.Floor((150 - 15 + 1) * Rnd())) + 15
                            End Select
                        Else
                            If rounder.Checked Then
                                value = (CInt(Math.Floor((51 - 1 + 1) * Rnd())) + 1) * 5
                            Else
                                value = CInt(Math.Floor((255 - 1 + 1) * Rnd())) + 1
                            End If
                    End If
                    Else
                        value = 0
                    End If
                    If rounder.Checked And value > 0 Then
                        value = value / 5
                        value = value * 5
                        If value < 5 Then
                            value = 5
                        End If
                    End If
                    Power = value
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Power = br.ReadByte()
                End If

                'Move Type
                address += 1
                If rndtype.Checked Then
                    value = CInt(Math.Floor((17 - 0 + 1) * Rnd())) + 0
                    If value = 9 And (Power <= 1) = False Then '??? type is coded to always use 10 base power
                        Power = 10
                        br.BaseStream.Seek(address, SeekOrigin.Begin)
                        bw.Write(CInt(10))
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                    Typing = value
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Typing = br.ReadByte()
                End If

                If rndcat.Checked = False And Cato < 0 Then
                    If Typing <= 9 Then
                        Cato = 0
                    ElseIf Typing > 9 And Typing <= 17 Then
                        Cato = 1
                    End If
                End If

                'Move Accuracy
                address += 1
                If rndaccurate.Checked Then
                    If balancestats.Checked Then
                        If (Power >= 1) Then
                            Select Case AttackType
                                Case 2 'selfdestruct type moves
                                    value = CInt(Math.Floor((150 - 125 + 1) * Rnd())) + 125
                                Case 3 'recoil moves
                                    value = CInt(Math.Floor((125 - 100 + 1) * Rnd())) + 100
                                Case 4 'charge moves
                                    value = CInt(Math.Floor((150 - 125 + 1) * Rnd())) + 125
                                Case 6 'do more damage with more health
                                    value = CInt(Math.Floor((125 - 100 + 1) * Rnd())) + 100
                                Case 7, 14, 15 'do more damage with less health, nature and hidden power
                                    value = CInt(Math.Floor((100 - 95 + 1) * Rnd())) + 95
                                Case 12 '1-hit ko moves
                                    value = CInt(Math.Floor((75 - 40 + 1) * Rnd())) + 40
                                Case Else
                                    value = CInt(Math.Floor((110 - 90 + 1) * Rnd())) + 90
                            End Select
                            random = Math.Floor(value - (Power / 5))
                            value = random Mod 256
                        ElseIf UserMove Then
                            value = CInt(100)
                        Else
                            value = CInt(Math.Floor((110 - 85 + 1) * Rnd())) + 85
                        End If
                        If (value > 100) Then
                            value = 100
                        End If
                    End If
                    If rounder.Checked And value > 0 Then
                        value = value / 5
                        value = value * 5
                        If value < 5 Then
                            value = 5
                        End If
                    End If
                    Accuracy = value
                    If AttackType = 5 Then 'never miss
                        value = CInt(0)
                        Accuracy = 100
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Accuracy = br.ReadByte()
                End If

                'Move PP
                address += 1
                If rndpp.Checked Then
                    If balancestats.Checked Then
                        Select Case AttackType
                            Case 3, 4, 6 'recoil moves, charge moves, more damage with more hp moves
                                value = CInt(Math.Floor((45 - 35 + 1) * Rnd())) + 35
                            Case 2 'self destruct
                                value = CInt(Math.Floor((7 - 3 + 1) * Rnd())) + 3
                            Case 7, 14, 15 'more damage with less health, nature and hidden power
                                value = CInt(Math.Floor((20 - 15 + 1) * Rnd())) + 15
                            Case 11, 1 'Non-damaging moves with strong or situational effects
                                value = CInt(Math.Floor((18 - 12 + 1) * Rnd())) + 12
                            Case 12 '1-hit ko moves
                                value = CInt(Math.Floor((8 - 3 + 1) * Rnd())) + 3
                            Case Else
                                value = CInt(Math.Floor((35 - 25 + 1) * Rnd())) + 25
                        End Select

                        If (AttackType = 2) = False Then
                            random = Math.Floor(value * (1.0 - (Power / 200)))
                            If random > 255 Then
                                random = 255
                            ElseIf random < 1 Then
                                random = 1
                            End If
                            value = random Mod 256
                        End If
                        random = Math.Floor(value * (1.0 - (Accuracy / 400)))
                        If random > 255 Then
                            random = 255
                        ElseIf random < 1 Then
                            random = 1
                        End If
                        value = random Mod 256
                        If value <= 0 Then
                            value = 1
                        End If
                    Else
                        value = CInt(Math.Floor((99 - 1 + 1) * Rnd())) + 1
                    End If
                    If rounder.Checked And value > 0 Then
                        value = value / 5
                        value = value * 5
                        If value < 5 Then
                            value = 5
                        End If
                    End If
                    PP = value
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    PP = br.ReadByte()
                End If

                'Effect Chance
                address += 1
                If rndeffect.Checked Then
                    If balancestats.Checked Then
                        If EffectChance > 0 Then
                            If Power <= 80 Then
                                EffectChance += 1
                            End If
                            If Power <= 40 Then
                                EffectChance += 1
                            End If
                            If Accuracy <= 75 Then
                                EffectChance += 1
                            End If
                            If EffectChance > 3 Then
                                EffectChance = 3
                            End If
                        End If
                        Select Case EffectChance
                            Case 1 'low chance
                                value = CInt(Math.Floor((20 - 10 + 1) * Rnd())) + 10
                            Case 2 'medium chance
                                value = CInt(Math.Floor((60 - 25 + 1) * Rnd())) + 25
                            Case 3 'high chance
                                value = CInt(Math.Floor((100 - 75 + 1) * Rnd())) + 75
                            Case Else
                                value = CInt(0)
                        End Select
                    Else
                        value = CInt(Math.Floor((100 - 1 + 1) * Rnd())) + 1
                    End If
                    If rounder.Checked And value > 0 Then
                        value = value / 5
                        value = value * 5
                        If value < 5 Then
                            value = 5
                        End If
                    End If
                    EffectProc = value
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    EffectProc = br.ReadByte()
                End If

                'Targets
                address += 1
                If rndtarget.Checked Then
                    If UserMove = True Then
                        value = CInt(16)
                    ElseIf AttackType = 1 Then
                        value = CInt(64)
                    ElseIf SpecialTarget = True Then
                        value = CInt(1)
                    Else
                        random = CInt(Math.Floor((9 - 1 + 1) * Rnd())) + 1
                        Select Case random
                            Case 1 'Random
                                value = CInt(4)
                            Case 2 'Random
                                value = CInt(4)
                            Case 3 'Both
                                value = CInt(8)
                            Case 4 'Both
                                value = CInt(8)
                            Case 5 'Both and Partner
                                value = CInt(32)
                            Case Else 'select target
                                value = CInt(0)
                        End Select
                    End If

                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                    Targets = value
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Targets = br.ReadByte()
                End If

                'Move Priority
                address += 1
                If rndeffect.Checked Then
                    value = CInt(Priority)
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                End If

                'Move Category
                address += 3
                If Cato >= 0 Then
                    value = CInt(Cato)
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                ElseIf rndcat.Checked Then
                    value = CInt(Math.Floor((1 - 0 + 1) * Rnd())) + 0
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                ElseIf rndeffect.Checked = False And Cato >= 0 Then
                    value = CInt(Cato)
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                End If

                br.BaseStream.Seek(address, SeekOrigin.Begin)
                Cato = br.ReadByte()

                'Flags
                address -= 2
                If rndeffect.Checked Then
                    value = 0
                    If Blockable = True Then
                        value += CInt(2)
                    End If

                    If DoesDamage = True Then
                        If Cato = 0 Then
                            random = CInt(Math.Floor((4 - 1 + 1) * Rnd())) + 1
                        ElseIf Cato = 1 Then 'special attacks are less likely to make contact
                            random = CInt(Math.Floor((20 - 1 + 1) * Rnd())) + 1
                        End If

                        Select Case random
                            Case 1, 2, 3 'Makes contact
                                value += CInt(1)
                        End Select
                        value += CInt(32) 'King's rock
                    Else
                        'I think it's safe to assume that magic coat only
                        'deflects status moves that actually hit the user
                        value += CInt(4) 'magic coat
                    End If
                    If UserMove = False Then
                        value += CInt(16) 'Bright powder
                    End If
                    If Snatchable = True Then
                        value += CInt(8) 'Can be snatched
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(value)
                End If

                '//////////
                '//NAMING//
                '//////////
                '$247094
                Select Case GameType
                    Case 2
                        address = &H31977C + (13 * index)
                    Case 3
                        address = &H247094 + (13 * index)
                    Case 4
                        address = &H2470E0 + (13 * index)
                    Case 5
                        address = &H247104 + (13 * index)
                    Case 7
                        address = &H1F8338 + (13 * index)
                    Case 8
                        address = &H1F82C8 + (13 * index)
                End Select
                If rndname.Checked Then
                    Call NameAttack(address)
                Else
                    Call ReadAttack(address)
                End If

                '///////////
                '//LOGGING//
                '///////////
                If System.IO.File.Exists(spoilerfile) Then
                    movedesc = "----" & index & "." & MoveName & "----"
                    sr.WriteLine(movedesc)
                    Select Case Typing
                        Case 0
                            sr.WriteLine("Type: Normal")
                        Case 1
                            sr.WriteLine("Type: Fighting")
                        Case 2
                            sr.WriteLine("Type: Flying")
                        Case 3
                            sr.WriteLine("Type: Poison")
                        Case 4
                            sr.WriteLine("Type: Ground")
                        Case 5
                            sr.WriteLine("Type: Rock")
                        Case 6
                            sr.WriteLine("Type: Bug")
                        Case 7
                            sr.WriteLine("Type: Ghost")
                        Case 8
                            sr.WriteLine("Type: Steel")
                        Case 10
                            sr.WriteLine("Type: Fire")
                        Case 11
                            sr.WriteLine("Type: Water")
                        Case 12
                            sr.WriteLine("Type: Grass")
                        Case 13
                            sr.WriteLine("Type: Electric")
                        Case 14
                            sr.WriteLine("Type: Psychic")
                        Case 15
                            sr.WriteLine("Type: Ice")
                        Case 16
                            sr.WriteLine("Type: Dragon")
                        Case 17
                            sr.WriteLine("Type: Dark")
                        Case Else
                            sr.WriteLine("Type: ???")
                    End Select
                    sr.WriteLine("Power: " & Power)
                    sr.WriteLine("Accuracy: " & Accuracy)
                    sr.WriteLine("PP: " & PP)
                    Select Case Cato
                        Case 0
                            sr.WriteLine("Category: Physical")
                        Case 1
                            sr.WriteLine("Category: Special")
                        Case 2
                            sr.WriteLine("Category: Status")
                    End Select
                    Select Case Targets
                        Case 0
                            sr.WriteLine("Target: Selected Foe")
                        Case 1
                            sr.WriteLine("Target: Contextual")
                        Case 4
                            sr.WriteLine("Target: Random Foe")
                        Case 8
                            sr.WriteLine("Target: Both Foes")
                        Case 16
                            sr.WriteLine("Target: User")
                        Case 32
                            sr.WriteLine("Target: Both Foes & Partner")
                        Case 64
                            sr.WriteLine("Target: Field")
                        Case Else
                            sr.WriteLine("Target: ")
                    End Select
                    Select Case effect
                        Case 1
                            sr.WriteLine("Effect: Puts target to sleep")
                        Case 2
                            sr.WriteLine("Effect: Can poison target")
                        Case 3
                            sr.WriteLine("Effect: Drains HP")
                        Case 4
                            sr.WriteLine("Effect: Can burn target")
                        Case 5
                            sr.WriteLine("Effect: Can freeze target")
                        Case 6
                            sr.WriteLine("Effect: Can paralyze target")
                        Case 7
                            sr.WriteLine("Effect: Faints user")
                        Case 8
                            sr.WriteLine("Effect: Drains HP of sleeping targets")
                        Case 9
                            sr.WriteLine("Effect: Mirror Move")
                        Case 10
                            sr.WriteLine("Effect: Raises ATK by 1 stage")
                        Case 11
                            sr.WriteLine("Effect: Raises DEF by 1 stage")
                        Case 13
                            sr.WriteLine("Effect: Raises SP.ATK by 1 stage")
                        Case 16
                            sr.WriteLine("Effect: Raises evasion by 1 stage")
                        Case 17
                            sr.WriteLine("Effect: Never misses")
                        Case 18
                            sr.WriteLine("Effect: Lowers ATK by 1 stage")
                        Case 19
                            sr.WriteLine("Effect: Lowers DEF by 1 stage")
                        Case 20
                            sr.WriteLine("Effect: Lowers SPEED by 1 stage")
                        Case 23
                            sr.WriteLine("Effect: Lowers accuracy by 1 stage")
                        Case 24
                            sr.WriteLine("Effect: Lowers evasion by 1 stage")
                        Case 25
                            sr.WriteLine("Effect: Clears stat changes")
                        Case 26
                            sr.WriteLine("Effect: Endures damage for 2 turns then counters")
                        Case 27
                            sr.WriteLine("Effect: Uses move 2-3 times in a row then becomes confused")
                        Case 28
                            sr.WriteLine("Effect: Switches out target/Scares away wild Pokemon")
                        Case 29
                            sr.WriteLine("Effect: Hits 2-5 times")
                        Case 30
                            sr.WriteLine("Effect: Conversion")
                        Case 31
                            sr.WriteLine("Effect: Flinch chance")
                        Case 32
                            sr.WriteLine("Effect: Recovers 50% of max HP")
                        Case 33
                            sr.WriteLine("Effect: Badly poisons target")
                        Case 34
                            sr.WriteLine("Effect: Increases prize money")
                        Case 35
                            sr.WriteLine("Effect: Lightscreen")
                        Case 36
                            sr.WriteLine("Effect: Can burn, paralyze or freeze")
                        Case 37
                            sr.WriteLine("Effect: Heals and puts user to sleep")
                        Case 38
                            sr.WriteLine("Effect: 1-Hit KO")
                        Case 39
                            sr.WriteLine("Effect: Razor Wind")
                        Case 40
                            sr.WriteLine("Effect: Halves target's HP")
                        Case 41
                            sr.WriteLine("Effect: Deals 40 damage")
                        Case 42
                            sr.WriteLine("Effect: Traps and does damage over time")
                        Case 43
                            sr.WriteLine("Effect: High crit ratio")
                        Case 44
                            sr.WriteLine("Effect: Hits 2 times")
                        Case 45
                            sr.WriteLine("Effect: 1/8 recoil when misses")
                        Case 46
                            sr.WriteLine("Effect: Protects party from stat reductions for a few turns")
                        Case 47
                            sr.WriteLine("Effect: Raises crit ratio")
                        Case 48
                            sr.WriteLine("Effect: 1/4 recoil")
                        Case 49
                            sr.WriteLine("Effect: Confuses target")
                        Case 50
                            sr.WriteLine("Effect: Raises ATK by 2 stages")
                        Case 51
                            sr.WriteLine("Effect: Raises DEF by 2 stages")
                        Case 52
                            sr.WriteLine("Effect: Raises SPEED by 2 stages")
                        Case 53
                            sr.WriteLine("Effect: Raises SP.ATK by 2 stages")
                        Case 54
                            sr.WriteLine("Effect: Raises SP.DEF by 2 stages")
                        Case 57
                            sr.WriteLine("Effect: Transforms into target")
                        Case 58
                            sr.WriteLine("Effect: Lowers ATK by 2 stages")
                        Case 59
                            sr.WriteLine("Effect: Lowers DEF by 2 stages")
                        Case 60
                            sr.WriteLine("Effect: Lowers SPEED by 2 stages")
                        Case 62
                            sr.WriteLine("Effect: Lowers SP.DEF by 2 stages")
                        Case 65
                            sr.WriteLine("Effect: Reflect")
                        Case 66
                            sr.WriteLine("Effect: Poisons target")
                        Case 67
                            sr.WriteLine("Effect: Paralyzes target")
                        Case 68
                            sr.WriteLine("Effect: Can lower target's ATK by 1 stage")
                        Case 69
                            sr.WriteLine("Effect: Can lower target's DEF by 1 stage")
                        Case 70
                            sr.WriteLine("Effect: Can lower target's SPEED by 1 stage")
                        Case 71
                            sr.WriteLine("Effect: Can lower target's SP.ATK by 1 stage")
                        Case 72
                            sr.WriteLine("Effect: Can lower target's SP.DEF by 1 stage")
                        Case 73
                            sr.WriteLine("Effect: Can lower target's accuracy by 1 stage")
                        Case 75
                            sr.WriteLine("Effect: Sky Attack")
                        Case 76
                            sr.WriteLine("Effect: Can confuse target")
                        Case 77
                            sr.WriteLine("Effect: Hits 2 times, can poison target")
                        Case 78
                            sr.WriteLine("Effect: Never misses, reduced priority")
                        Case 79
                            sr.WriteLine("Effect: Substitute")
                        Case 80
                            sr.WriteLine("Effect: User recharges after successful use")
                        Case 81
                            sr.WriteLine("Effect: Raises user's ATK by 1 stage if hit")
                        Case 82
                            sr.WriteLine("Effect: Copies target's attack for the battle")
                        Case 83
                            sr.WriteLine("Effect: Uses a random move")
                        Case 84
                            sr.WriteLine("Effect: Drains HP")
                        Case 86
                            sr.WriteLine("Effect: Disables target's last move")
                        Case 87
                            sr.WriteLine("Effect: Deals damage equal to user's level")
                        Case 88
                            sr.WriteLine("Effect: Psywave")
                        Case 89
                            sr.WriteLine("Effect: Counter")
                        Case 90
                            sr.WriteLine("Effect: Gives the target an encore")
                        Case 91
                            sr.WriteLine("Effect: Pain Split")
                        Case 92
                            sr.WriteLine("Effect: Works while asleep")
                        Case 93
                            sr.WriteLine("Effect: Conversion 2")
                        Case 94
                            sr.WriteLine("Effect: Ensures the users attack next round won't miss the target")
                        Case 95
                            sr.WriteLine("Effect: Permanently copies the target's last move")
                        Case 97
                            sr.WriteLine("Effect: Picks a random known attack while sleeping")
                        Case 98
                            sr.WriteLine("Effect: Destiny Bond")
                        Case 99
                            sr.WriteLine("Effect: Deals more damage with less health")
                        Case 100
                            sr.WriteLine("Effect: Lowers the PP of the target's last used move")
                        Case 101
                            sr.WriteLine("Effect: Will always leave the target with 1 HP left")
                        Case 102
                            sr.WriteLine("Effect: Heals the party's status effects")
                        Case 103
                            sr.WriteLine("Effect: +1 Priority")
                        Case 104
                            sr.WriteLine("Effect: Hits 3 times, each with double the last's power")
                        Case 105
                            sr.WriteLine("Effect: Steals target's held item")
                        Case 106
                            sr.WriteLine("Effect: Traps target")
                        Case 107
                            sr.WriteLine("Effect: Nightmare")
                        Case 108
                            sr.WriteLine("Effect: Minimize")
                        Case 109
                            sr.WriteLine("Effect: Curse")
                        Case 111
                            sr.WriteLine("Effect: Protect")
                        Case 112
                            sr.WriteLine("Effect: Scatters spikes on the enemy's field")
                        Case 113
                            sr.WriteLine("Effect: Foresight")
                        Case 114
                            sr.WriteLine("Effect: Perish Song")
                        Case 115
                            sr.WriteLine("Effect: Sandstorm")
                        Case 116
                            sr.WriteLine("Effect: Endure")
                        Case 117
                            sr.WriteLine("Effect: Rollout")
                        Case 118
                            sr.WriteLine("Effect: Swagger")
                        Case 119
                            sr.WriteLine("Effect: Fury Cutter")
                        Case 120
                            sr.WriteLine("Effect: Attract")
                        Case 121
                            sr.WriteLine("Effect: Return")
                        Case 122
                            sr.WriteLine("Effect: Present")
                        Case 123
                            sr.WriteLine("Effect: Frustration")
                        Case 124
                            sr.WriteLine("Effect: Protects party from status effects for a few turns")
                        Case 125
                            sr.WriteLine("Effect: Thaws user, Can burn target")
                        Case 126
                            sr.WriteLine("Effect: Magnitude")
                        Case 127
                            sr.WriteLine("Effect: Baton Pass")
                        Case 128
                            sr.WriteLine("Effect: Pursuit")
                        Case 129
                            sr.WriteLine("Effect: Rapid Spin")
                        Case 130
                            sr.WriteLine("Effect: Deals 20 damage")
                        Case 132
                            sr.WriteLine("Effect: Morning Sun")
                        Case 133
                            sr.WriteLine("Effect: Synthesis")
                        Case 134
                            sr.WriteLine("Effect: Moonlight")
                        Case 135
                            sr.WriteLine("Effect: Hidden Power")
                        Case 136
                            sr.WriteLine("Effect: Rain")
                        Case 137
                            sr.WriteLine("Effect: Harsh Sunlight")
                        Case 138
                            sr.WriteLine("Effect: Can raise user's DEF by 1 stage")
                        Case 139
                            sr.WriteLine("Effect: Can raise user's ATK by 1 stage")
                        Case 140
                            sr.WriteLine("Effect: Can raise all of the user's stats by 1 stage")
                        Case 142
                            sr.WriteLine("Effect: Bellydrum")
                        Case 143
                            sr.WriteLine("Effect: Copies target's stat changes")
                        Case 144
                            sr.WriteLine("Effect: Counters special attacks")
                        Case 145
                            sr.WriteLine("Effect: Skull Bash")
                        Case 146
                            sr.WriteLine("Effect: Flinch chance, deals 2x damage to flying targets")
                        Case 147
                            sr.WriteLine("Effect: Double damage to digging targets")
                        Case 148
                            sr.WriteLine("Effect: Future Sight/Doom Desire")
                        Case 149
                            sr.WriteLine("Effect: Deals 2x damage to flying targets")
                        Case 150
                            sr.WriteLine("Effect: Flinch chance, deals 2x damage to flying targets")
                        Case 151
                            sr.WriteLine("Effect: Solar Beam")
                        Case 152
                            sr.WriteLine("Effect: Paralysis chance, hits flying targets, never misses in rain, halved accuracy in harsh sunlight")
                        Case 153
                            sr.WriteLine("Effect: Flees from battle")
                        Case 154
                            sr.WriteLine("Effect: Beat Up")
                        Case 155
                            sr.WriteLine("Effect: Dive/Dig/Fly/Bounce")
                        Case 156
                            sr.WriteLine("Effect: Defense Curl")
                        Case 157
                            sr.WriteLine("Effect: Soft Boiled")
                        Case 158
                            sr.WriteLine("Effect: Fakeout")
                        Case 159
                            sr.WriteLine("Effect: Uproar")
                        Case 160
                            sr.WriteLine("Effect: Stockpile")
                        Case 161
                            sr.WriteLine("Effect: Spit Up")
                        Case 162
                            sr.WriteLine("Effect: Swallow")
                        Case 164
                            sr.WriteLine("Effect: Hail")
                        Case 165
                            sr.WriteLine("Effect: Torment")
                        Case 166
                            sr.WriteLine("Effect: Flatter")
                        Case 167
                            sr.WriteLine("Effect: Burns target")
                        Case 168
                            sr.WriteLine("Effect: Memento")
                        Case 169
                            sr.WriteLine("Effect: Facade")
                        Case 170
                            sr.WriteLine("Effect: Focus Punch")
                        Case 171
                            sr.WriteLine("Effect: Smelling Salts")
                        Case 172
                            sr.WriteLine("Effect: Follow Me")
                        Case 173
                            sr.WriteLine("Effect: Nature Power")
                        Case 174
                            sr.WriteLine("Effect: Charge")
                        Case 175
                            sr.WriteLine("Effect: Taunt")
                        Case 176
                            sr.WriteLine("Effect: Helping Hand")
                        Case 177
                            sr.WriteLine("Effect: Trick")
                        Case 178
                            sr.WriteLine("Effect: Copy target's ability")
                        Case 179
                            sr.WriteLine("Effect: Wish")
                        Case 180
                            sr.WriteLine("Effect: Assist")
                        Case 181
                            sr.WriteLine("Effect: Ingrain")
                        Case 182
                            sr.WriteLine("Effect: Lowers user's ATK & DEF by 1 stage")
                        Case 183
                            sr.WriteLine("Effect: Magic Coat (Deflect status moves)")
                        Case 184
                            sr.WriteLine("Effect: Recycle")
                        Case 185
                            sr.WriteLine("Effect: Revenge")
                        Case 186
                            sr.WriteLine("Effect: Brick Break")
                        Case 187
                            sr.WriteLine("Effect: Yawn")
                        Case 188
                            sr.WriteLine("Effect: Knock Off")
                        Case 189
                            sr.WriteLine("Effect: Endeavour")
                        Case 190
                            sr.WriteLine("Effect: Less damage with less HP")
                        Case 191
                            sr.WriteLine("Effect: Skill Swap")
                        Case 192
                            sr.WriteLine("Effect: Imprison")
                        Case 193
                            sr.WriteLine("Effect: Refresh")
                        Case 194
                            sr.WriteLine("Effect: Grudge")
                        Case 195
                            sr.WriteLine("Effect: Snatch")
                        Case 196
                            sr.WriteLine("Effect: Low Kick")
                        Case 197
                            sr.WriteLine("Effect: Secret Power")
                        Case 198
                            If EffectProc = 0 Then
                                sr.WriteLine("Effect: 1/3 Recoil")
                            Else
                                sr.WriteLine("Effect: 1/3 Recoil, can paralyze target")
                            End If
                        Case 199
                            sr.WriteLine("Effect: Teeter Dance")
                        Case 200
                            sr.WriteLine("Effect: Can burn, high crit ratio")
                        Case 201
                            sr.WriteLine("Effect: Mud Sport")
                        Case 202
                            sr.WriteLine("Effect: Can badly poison, high crit ratio")
                        Case 203
                            sr.WriteLine("Effect: Weather Ball")
                        Case 204
                            sr.WriteLine("Effect: Lowers user's SP.ATK by 2 stages")
                        Case 205
                            sr.WriteLine("Effect: Lowers target's ATK and DEF by 1 stage")
                        Case 206
                            sr.WriteLine("Effect: Raises target's DEF and SP.DEF")
                        Case 207
                            sr.WriteLine("Effect: Can hit flying targets")
                        Case 208
                            sr.WriteLine("Effect: Raises target's ATK and DEF by 1 stage")
                        Case 209
                            sr.WriteLine("Effect: Can poison, high crit ratio")
                        Case 210
                            sr.WriteLine("Effect: Water Sport")
                        Case 211
                            sr.WriteLine("Effect: Raises target's SP.ATK and SP.DEF by 1 stage")
                        Case 212
                            sr.WriteLine("Effect: Raises target's ATK and SPEED by 1 stage")
                        Case 213
                            sr.WriteLine("Effect: Camouflage")
                        Case Else
                            sr.WriteLine("Effect: None")
                    End Select
                    If EffectProc >= 1 Then
                        sr.WriteLine("Effect Chance: " & EffectProc & "%")
                    End If
                End If

                index += 1
            Loop
            bw.Close()
            sr.Close()
            MsgBox("Randomization Complete")
        Else
            If My.Computer.FileSystem.FileExists(patchfile.Text) Then
                MsgBox("File doesn't exist!")
            ElseIf GameType < 0 Then
                MsgBox("ROM version not specified, please manually correct this.")
            End If
        End If
    End Sub
    Sub SetupNameArray(ByVal unusedval As String)
        Dim LineData As String
        Dim srNames As StreamReader
        maxfirst = -1
        maxbug = -1
        maxdark = -1
        maxdragon = -1
        maxelectric = -1
        maxfight = -1
        maxfire = -1
        maxflying = -1
        maxghost = -1
        maxgrass = -1
        maxground = -1
        maxice = -1
        maxnormal = -1
        maxpoison = -1
        maxpsychic = -1
        maxrock = -1
        maxsteel = -1
        maxwater = -1
        maxphy(0) = -1
        maxphy(1) = -1
        maxphy(2) = -1
        maxphy(3) = -1
        maxphy(4) = -1
        maxphy(5) = -1
        maxphy(6) = -1
        maxphy(7) = -1
        maxspe(0) = -1
        maxspe(1) = -1
        maxspe(2) = -1
        maxspe(3) = -1
        maxspe(4) = -1
        maxspe(5) = -1
        maxspe(6) = -1
        maxspe(7) = -1
        maxstatus(0) = -1
        maxstatus(1) = -1
        maxstatus(2) = -1
        maxstatus(3) = -1
        maxstatus(4) = -1
        maxstatus(5) = -1
        maxstatus(6) = -1
        maxstatus(7) = -1
        maxuserstatus(0) = -1
        maxuserstatus(1) = -1
        maxuserstatus(2) = -1
        maxuserstatus(3) = -1
        maxuserstatus(4) = -1
        maxuserstatus(5) = -1
        maxuserstatus(6) = -1
        maxuserstatus(7) = -1
        maxsecond(0) = -1
        maxsecond(1) = -1
        maxsecond(2) = -1
        maxsecond(3) = -1
        maxsecond(4) = -1
        maxsecond(5) = -1
        maxsecond(6) = -1
        maxsecond(7) = -1

        srNames = File.OpenText(Bugtext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxbug += 1
            bugarray(maxbug) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Darktext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxdark += 1
            darkarray(maxdark) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Dragontext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxdragon += 1
            dragonarray(maxdragon) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Electrictext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxelectric += 1
            electricarray(maxelectric) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Fighttext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxfight += 1
            fightarray(maxfight) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Firetext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxfire += 1
            firearray(maxfire) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Flyingtext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxflying += 1
            flyingarray(maxflying) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Ghosttext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxghost += 1
            ghostarray(maxghost) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Grasstext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxgrass += 1
            grassarray(maxgrass) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Groundtext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxground += 1
            groundarray(maxground) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Icetext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxice += 1
            icearray(maxice) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Normaltext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxnormal += 1
            normalarray(maxnormal) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Poisontext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxpoison += 1
            poisonarray(maxpoison) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Psychictext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxpsychic += 1
            psychicarray(maxpsychic) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Rocktext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxrock += 1
            rockarray(maxrock) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Steeltext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxsteel += 1
            steelarray(maxsteel) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Watertext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            maxwater += 1
            waterarray(maxwater) = LineData
            maxfirst += 1
            firstwordarry(maxfirst) = LineData
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Phytext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            Select Case LineData.Length
                Case 1
                    maxsecond(0) += 1
                    secondwordarray(0, maxsecond(0)) = LineData
                    maxphy(0) += 1
                    physicalarray(0, maxphy(0)) = LineData
                Case 2
                    maxsecond(1) += 1
                    secondwordarray(1, maxsecond(1)) = LineData
                    maxphy(1) += 1
                    physicalarray(1, maxphy(1)) = LineData
                Case 3
                    maxsecond(2) += 1
                    secondwordarray(2, maxsecond(2)) = LineData
                    maxphy(2) += 1
                    physicalarray(2, maxphy(2)) = LineData
                Case 4
                    maxsecond(3) += 1
                    secondwordarray(3, maxsecond(3)) = LineData
                    maxphy(3) += 1
                    physicalarray(3, maxphy(3)) = LineData
                Case 5
                    maxsecond(4) += 1
                    secondwordarray(4, maxsecond(4)) = LineData
                    maxphy(4) += 1
                    physicalarray(4, maxphy(4)) = LineData
                Case 6
                    maxsecond(5) += 1
                    secondwordarray(5, maxsecond(5)) = LineData
                    maxphy(5) += 1
                    physicalarray(5, maxphy(5)) = LineData
                Case 7
                    maxsecond(6) += 1
                    secondwordarray(6, maxsecond(6)) = LineData
                    maxphy(6) += 1
                    physicalarray(6, maxphy(6)) = LineData
                Case 8
                    maxsecond(7) += 1
                    secondwordarray(7, maxsecond(7)) = LineData
                    maxphy(7) += 1
                    physicalarray(7, maxphy(7)) = LineData
            End Select
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Spetext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            Select Case LineData.Length
                Case 1
                    maxsecond(0) += 1
                    secondwordarray(0, maxsecond(0)) = LineData
                    maxspe(0) += 1
                    specialarray(0, maxspe(0)) = LineData
                Case 2
                    maxsecond(1) += 1
                    secondwordarray(1, maxsecond(1)) = LineData
                    maxspe(1) += 1
                    specialarray(1, maxspe(1)) = LineData
                Case 3
                    maxsecond(2) += 1
                    secondwordarray(2, maxsecond(2)) = LineData
                    maxspe(2) += 1
                    specialarray(2, maxspe(2)) = LineData
                Case 4
                    maxsecond(3) += 1
                    secondwordarray(3, maxsecond(3)) = LineData
                    maxspe(3) += 1
                    specialarray(3, maxspe(3)) = LineData
                Case 5
                    maxsecond(4) += 1
                    secondwordarray(4, maxsecond(4)) = LineData
                    maxspe(4) += 1
                    specialarray(4, maxspe(4)) = LineData
                Case 6
                    maxsecond(5) += 1
                    secondwordarray(5, maxsecond(5)) = LineData
                    maxspe(5) += 1
                    specialarray(5, maxspe(5)) = LineData
                Case 7
                    maxsecond(6) += 1
                    secondwordarray(6, maxsecond(6)) = LineData
                    maxspe(6) += 1
                    specialarray(6, maxspe(6)) = LineData
                Case 8
                    maxsecond(7) += 1
                    secondwordarray(7, maxsecond(7)) = LineData
                    maxspe(7) += 1
                    specialarray(7, maxspe(7)) = LineData
            End Select
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Statustext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            Select Case LineData.Length
                Case 1
                    maxsecond(0) += 1
                    secondwordarray(0, maxsecond(0)) = LineData
                    maxstatus(0) += 1
                    statusarray(0, maxstatus(0)) = LineData
                Case 2
                    maxsecond(1) += 1
                    secondwordarray(1, maxsecond(1)) = LineData
                    maxstatus(1) += 1
                    statusarray(1, maxstatus(1)) = LineData
                Case 3
                    maxsecond(2) += 1
                    secondwordarray(2, maxsecond(2)) = LineData
                    maxstatus(2) += 1
                    statusarray(2, maxstatus(2)) = LineData
                Case 4
                    maxsecond(3) += 1
                    secondwordarray(3, maxsecond(3)) = LineData
                    maxstatus(3) += 1
                    statusarray(3, maxstatus(3)) = LineData
                Case 5
                    maxsecond(4) += 1
                    secondwordarray(4, maxsecond(4)) = LineData
                    maxstatus(4) += 1
                    statusarray(4, maxstatus(4)) = LineData
                Case 6
                    maxsecond(5) += 1
                    secondwordarray(5, maxsecond(5)) = LineData
                    maxstatus(5) += 1
                    statusarray(5, maxstatus(5)) = LineData
                Case 7
                    maxsecond(6) += 1
                    secondwordarray(6, maxsecond(6)) = LineData
                    maxstatus(6) += 1
                    statusarray(6, maxstatus(6)) = LineData
                Case 8
                    maxsecond(7) += 1
                    secondwordarray(7, maxsecond(7)) = LineData
                    maxstatus(7) += 1
                    statusarray(7, maxstatus(7)) = LineData
            End Select
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()

        srNames = File.OpenText(Userstatustext)
        LineData = srNames.ReadLine()
        Do Until LineData Is Nothing
            Select Case LineData.Length
                Case 1
                    maxsecond(0) += 1
                    secondwordarray(0, maxsecond(0)) = LineData
                    maxuserstatus(0) += 1
                    userstatusarray(0, maxuserstatus(0)) = LineData
                Case 2
                    maxsecond(1) += 1
                    secondwordarray(1, maxsecond(1)) = LineData
                    maxuserstatus(1) += 1
                    userstatusarray(1, maxuserstatus(1)) = LineData
                Case 3
                    maxsecond(2) += 1
                    secondwordarray(2, maxsecond(2)) = LineData
                    maxuserstatus(2) += 1
                    userstatusarray(2, maxuserstatus(2)) = LineData
                Case 4
                    maxsecond(3) += 1
                    secondwordarray(3, maxsecond(3)) = LineData
                    maxuserstatus(3) += 1
                    userstatusarray(3, maxuserstatus(3)) = LineData
                Case 5
                    maxsecond(4) += 1
                    secondwordarray(4, maxsecond(4)) = LineData
                    maxuserstatus(4) += 1
                    userstatusarray(4, maxuserstatus(4)) = LineData
                Case 6
                    maxsecond(5) += 1
                    secondwordarray(5, maxsecond(5)) = LineData
                    maxuserstatus(5) += 1
                    userstatusarray(5, maxuserstatus(5)) = LineData
                Case 7
                    maxsecond(6) += 1
                    secondwordarray(6, maxsecond(6)) = LineData
                    maxuserstatus(6) += 1
                    userstatusarray(6, maxuserstatus(6)) = LineData
                Case 8
                    maxsecond(7) += 1
                    secondwordarray(7, maxsecond(7)) = LineData
                    maxuserstatus(7) += 1
                    userstatusarray(7, maxuserstatus(7)) = LineData
            End Select
            LineData = srNames.ReadLine()
        Loop
        srNames.Close()
    End Sub
    Sub ChangeAnim(ByVal index As Integer, ByVal offset As String)
        If rndeffect.Checked Then 'yeah I'm lazy
            Dim b() As Byte
            Dim offsetint As Int32
            Dim offsetstring As String
            Dim hexaddress As String
            Select Case GameType
                Case 2
                    hexaddress = &H2C8D6C + (4 * index)
                Case 3
                    hexaddress = &H1C68F4 + (4 * index)
                Case 4
                    hexaddress = &H1C6940 + (4 * index)
                Case 5
                    hexaddress = &H1C6964 + (4 * index)
                Case 7
                    hexaddress = &H1C7180 + (4 * index)
                Case 8
                    hexaddress = &H1C7110 + (4 * index)
            End Select
            offsetint = offset
            b = BitConverter.GetBytes(offsetint)
            offsetstring = String.Format("{0:X1}{1:X2}{2:X2}{3:X2}", b(0), b(1), b(2), b(3))
            offsetint = BitConverter.ToInt32(b, 0)
            br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
            bw.Write(offsetint)
        End If
    End Sub
    Sub ChangeDesc(ByVal index As Integer, ByVal offset As String)
        If rndeffect.Checked Then 'yeah I'm lazy
            Dim b() As Byte
            Dim offsetint As Int32
            Dim offsetstring As String
            Dim hexaddress As String
            Select Case GameType
                Case 2
                    hexaddress = &H61C520 + (4 * index)
                Case 3
                    hexaddress = &H4886E4 + (4 * index)
                Case 4
                    hexaddress = &H488030 + (4 * index)
                Case 5
                    hexaddress = &H488744 + (4 * index)
                Case 7
                    hexaddress = &H3C09F0 + (4 * index)
                Case 8
                    hexaddress = &H3C0A4C + (4 * index)
            End Select
            offsetint = offset
            b = BitConverter.GetBytes(offsetint)
            offsetstring = String.Format("{0:X1}{1:X2}{2:X2}{3:X2}", b(0), b(1), b(2), b(3))
            offsetint = BitConverter.ToInt32(b, 0)
            br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
            bw.Write(offsetint)
        End If
    End Sub
    Sub NameAttack(ByVal hexaddress As String)
        Dim Chars As Integer = 1
        Dim value As Byte
        Dim strlength As Integer
        Dim random As Integer

        

        Dim validwordlength(7) As Integer
        Dim arraymax As Integer = 0


        If context.Checked Then
            Select Case Typing
                Case 1 'fight
                    random = CInt(Math.Floor((maxfight - 0 + 1) * Rnd())) + 0
                    MoveName = fightarray(random)
                Case 2 'flying
                    random = CInt(Math.Floor((maxflying - 0 + 1) * Rnd())) + 0
                    MoveName = flyingarray(random)
                Case 3 'poison
                    random = CInt(Math.Floor((maxpoison - 0 + 1) * Rnd())) + 0
                    MoveName = poisonarray(random)
                Case 4 'ground
                    random = CInt(Math.Floor((maxground - 0 + 1) * Rnd())) + 0
                    MoveName = groundarray(random)
                Case 5 'rock
                    random = CInt(Math.Floor((maxrock - 0 + 1) * Rnd())) + 0
                    MoveName = rockarray(random)
                Case 6 'bug
                    random = CInt(Math.Floor((maxbug - 0 + 1) * Rnd())) + 0
                    MoveName = bugarray(random)
                Case 7 'ghost
                    random = CInt(Math.Floor((maxghost - 0 + 1) * Rnd())) + 0
                    MoveName = ghostarray(random)
                Case 8 'steel
                    random = CInt(Math.Floor((maxsteel - 0 + 1) * Rnd())) + 0
                    MoveName = steelarray(random)
                Case 10 'fire
                    random = CInt(Math.Floor((maxfire - 0 + 1) * Rnd())) + 0
                    MoveName = firearray(random)
                Case 11 'water
                    random = CInt(Math.Floor((maxwater - 0 + 1) * Rnd())) + 0
                    MoveName = waterarray(random)
                Case 12 'grass
                    random = CInt(Math.Floor((maxgrass - 0 + 1) * Rnd())) + 0
                    MoveName = grassarray(random)
                Case 13 'electric
                    random = CInt(Math.Floor((maxelectric - 0 + 1) * Rnd())) + 0
                    MoveName = electricarray(random)
                Case 14 'psychic
                    random = CInt(Math.Floor((maxpsychic - 0 + 1) * Rnd())) + 0
                    MoveName = psychicarray(random)
                Case 15 'ice
                    random = CInt(Math.Floor((maxice - 0 + 1) * Rnd())) + 0
                    MoveName = icearray(random)
                Case 16 'dragon
                    random = CInt(Math.Floor((maxdragon - 0 + 1) * Rnd())) + 0
                    MoveName = dragonarray(random)
                Case 17 'dark
                    random = CInt(Math.Floor((maxdark - 0 + 1) * Rnd())) + 0
                    MoveName = darkarray(random)
                Case Else 'normal & ??? type
                    random = CInt(Math.Floor((maxnormal - 0 + 1) * Rnd())) + 0
                    MoveName = normalarray(random)
            End Select
            Select Case Cato
                Case 0 'physical
                    If maxphy(0) >= 0 Then
                        validwordlength(arraymax) = 1
                        arraymax += 1
                    End If
                    If maxphy(1) >= 0 Then
                        validwordlength(arraymax) = 2
                        arraymax += 1
                    End If
                    If maxphy(2) >= 0 Then
                        validwordlength(arraymax) = 3
                        arraymax += 1
                    End If
                    If maxphy(3) >= 0 Then
                        validwordlength(arraymax) = 4
                        arraymax += 1
                    End If
                    If maxphy(4) >= 0 Then
                        validwordlength(arraymax) = 5
                        arraymax += 1
                    End If
                    If maxphy(5) >= 0 Then
                        validwordlength(arraymax) = 6
                        arraymax += 1
                    End If
                    If maxphy(6) >= 0 Then
                        validwordlength(arraymax) = 7
                        arraymax += 1
                    End If
                    If maxphy(7) >= 0 Then
                        validwordlength(arraymax) = 8
                        arraymax += 1
                    End If
                Case 1 'special
                    If maxspe(0) >= 0 Then
                        validwordlength(arraymax) = 1
                        arraymax += 1
                    End If
                    If maxspe(1) >= 0 Then
                        validwordlength(arraymax) = 2
                        arraymax += 1
                    End If
                    If maxspe(2) >= 0 Then
                        validwordlength(arraymax) = 3
                        arraymax += 1
                    End If
                    If maxspe(3) >= 0 Then
                        validwordlength(arraymax) = 4
                        arraymax += 1
                    End If
                    If maxspe(4) >= 0 Then
                        validwordlength(arraymax) = 5
                        arraymax += 1
                    End If
                    If maxspe(5) >= 0 Then
                        validwordlength(arraymax) = 6
                        arraymax += 1
                    End If
                    If maxspe(6) >= 0 Then
                        validwordlength(arraymax) = 7
                        arraymax += 1
                    End If
                    If maxspe(7) >= 0 Then
                        validwordlength(arraymax) = 8
                        arraymax += 1
                    End If
                Case 2 'status
                    If Targets = 16 Then
                        If maxuserstatus(0) >= 0 Then
                            validwordlength(arraymax) = 1
                            arraymax += 1
                        End If
                        If maxuserstatus(1) >= 0 Then
                            validwordlength(arraymax) = 2
                            arraymax += 1
                        End If
                        If maxuserstatus(2) >= 0 Then
                            validwordlength(arraymax) = 3
                            arraymax += 1
                        End If
                        If maxuserstatus(3) >= 0 Then
                            validwordlength(arraymax) = 4
                            arraymax += 1
                        End If
                        If maxuserstatus(4) >= 0 Then
                            validwordlength(arraymax) = 5
                            arraymax += 1
                        End If
                        If maxuserstatus(5) >= 0 Then
                            validwordlength(arraymax) = 6
                            arraymax += 1
                        End If
                        If maxuserstatus(6) >= 0 Then
                            validwordlength(arraymax) = 7
                            arraymax += 1
                        End If
                        If maxuserstatus(7) >= 0 Then
                            validwordlength(arraymax) = 8
                            arraymax += 1
                        End If
                    Else
                        If maxstatus(0) >= 0 Then
                            validwordlength(arraymax) = 1
                            arraymax += 1
                        End If
                        If maxstatus(1) >= 0 Then
                            validwordlength(arraymax) = 2
                            arraymax += 1
                        End If
                        If maxstatus(2) >= 0 Then
                            validwordlength(arraymax) = 3
                            arraymax += 1
                        End If
                        If maxstatus(3) >= 0 Then
                            validwordlength(arraymax) = 4
                            arraymax += 1
                        End If
                        If maxstatus(4) >= 0 Then
                            validwordlength(arraymax) = 5
                            arraymax += 1
                        End If
                        If maxstatus(5) >= 0 Then
                            validwordlength(arraymax) = 6
                            arraymax += 1
                        End If
                        If maxstatus(6) >= 0 Then
                            validwordlength(arraymax) = 7
                            arraymax += 1
                        End If
                        If maxstatus(7) >= 0 Then
                            validwordlength(arraymax) = 8
                            arraymax += 1
                        End If
                    End If
            End Select

            arraymax -= 1

            'MsgBox("ArrayMax1: " & arraymax)

            Dim maxcarlength As Integer = 12 - MoveName.Length
            Dim loopcheck As Integer = 0
            Do While loopcheck <= arraymax
                If validwordlength(loopcheck) > maxcarlength Then
                    arraymax = loopcheck - 1
                End If
                loopcheck += 1
            Loop

            'MsgBox("ArrayMax2: " & arraymax)

            Select Case Cato
                Case 0 'physical
                    random = CInt(Math.Floor((arraymax - 0 + 1) * Rnd())) + 0
                    Select Case validwordlength(random)
                        Case 1
                            random = CInt(Math.Floor((maxphy(0) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(0, random)
                        Case 2
                            random = CInt(Math.Floor((maxphy(1) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(1, random)
                        Case 3
                            random = CInt(Math.Floor((maxphy(2) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(2, random)
                        Case 4
                            random = CInt(Math.Floor((maxphy(3) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(3, random)
                        Case 5
                            random = CInt(Math.Floor((maxphy(4) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(4, random)
                        Case 6
                            random = CInt(Math.Floor((maxphy(5) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(5, random)
                        Case 7
                            random = CInt(Math.Floor((maxphy(6) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(6, random)
                        Case 8
                            random = CInt(Math.Floor((maxphy(7) - 0 + 1) * Rnd())) + 0
                            MoveName &= physicalarray(7, random)
                        Case Else
                            'MsgBox("Unable to give second word!")
                    End Select
                Case 1 'special
                    random = CInt(Math.Floor((arraymax - 0 + 1) * Rnd())) + 0
                    Select Case validwordlength(random)
                        Case 1
                            random = CInt(Math.Floor((maxspe(0) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(0, random)
                        Case 2
                            random = CInt(Math.Floor((maxspe(1) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(1, random)
                        Case 3
                            random = CInt(Math.Floor((maxspe(2) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(2, random)
                        Case 4
                            random = CInt(Math.Floor((maxspe(3) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(3, random)
                        Case 5
                            random = CInt(Math.Floor((maxspe(4) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(4, random)
                        Case 6
                            random = CInt(Math.Floor((maxspe(5) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(5, random)
                        Case 7
                            random = CInt(Math.Floor((maxspe(6) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(6, random)
                        Case 8
                            random = CInt(Math.Floor((maxspe(7) - 0 + 1) * Rnd())) + 0
                            MoveName &= specialarray(7, random)
                        Case Else
                            'MsgBox("Unable to give second word!")
                    End Select
                Case 2 'status
                    random = CInt(Math.Floor((arraymax - 0 + 1) * Rnd())) + 0
                    If Targets = 16 Then
                        Select Case validwordlength(random)
                            Case 1
                                random = CInt(Math.Floor((maxuserstatus(0) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(0, random)
                            Case 2
                                random = CInt(Math.Floor((maxuserstatus(1) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(1, random)
                            Case 3
                                random = CInt(Math.Floor((maxuserstatus(2) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(2, random)
                            Case 4
                                random = CInt(Math.Floor((maxuserstatus(3) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(3, random)
                            Case 5
                                random = CInt(Math.Floor((maxuserstatus(4) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(4, random)
                            Case 6
                                random = CInt(Math.Floor((maxuserstatus(5) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(5, random)
                            Case 7
                                random = CInt(Math.Floor((maxuserstatus(6) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(6, random)
                            Case 8
                                random = CInt(Math.Floor((maxuserstatus(7) - 0 + 1) * Rnd())) + 0
                                MoveName &= userstatusarray(7, random)
                            Case Else
                                MsgBox("ArrayMax2: " & arraymax)
                                'MsgBox("Unable to give second word!")
                        End Select
                    Else
                        Select Case validwordlength(random)
                            Case 1
                                random = CInt(Math.Floor((maxstatus(0) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(0, random)
                            Case 2
                                random = CInt(Math.Floor((maxstatus(1) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(1, random)
                            Case 3
                                random = CInt(Math.Floor((maxstatus(2) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(2, random)
                            Case 4
                                random = CInt(Math.Floor((maxstatus(3) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(3, random)
                            Case 5
                                random = CInt(Math.Floor((maxstatus(4) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(4, random)
                            Case 6
                                random = CInt(Math.Floor((maxstatus(5) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(5, random)
                            Case 7
                                random = CInt(Math.Floor((maxstatus(6) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(6, random)
                            Case 8
                                random = CInt(Math.Floor((maxstatus(7) - 0 + 1) * Rnd())) + 0
                                MoveName &= statusarray(7, random)
                            Case Else
                                'MsgBox("Unable to give second word!")
                        End Select
                    End If
            End Select

        Else
            random = CInt(Math.Floor((maxfirst - 0 + 1) * Rnd())) + 0
            MoveName = firstwordarry(random)
            If maxsecond(0) >= 0 Then
                validwordlength(arraymax) = 1
                arraymax += 1
            End If
            If maxsecond(1) >= 0 Then
                validwordlength(arraymax) = 2
                arraymax += 1
            End If
            If maxsecond(2) >= 0 Then
                validwordlength(arraymax) = 3
                arraymax += 1
            End If
            If maxsecond(3) >= 0 Then
                validwordlength(arraymax) = 4
                arraymax += 1
            End If
            If maxsecond(4) >= 0 Then
                validwordlength(arraymax) = 5
                arraymax += 1
            End If
            If maxsecond(5) >= 0 Then
                validwordlength(arraymax) = 6
                arraymax += 1
            End If
            If maxsecond(6) >= 0 Then
                validwordlength(arraymax) = 7
                arraymax += 1
            End If
            If maxsecond(7) >= 0 Then
                validwordlength(arraymax) = 8
                arraymax += 1
            End If

            arraymax -= 1

            'MsgBox("ArrayMax1: " & arraymax)

            Dim maxcarlength As Integer = 12 - MoveName.Length
            Dim loopcheck As Integer = 0
            Do While loopcheck <= arraymax
                If validwordlength(loopcheck) > maxcarlength Then
                    arraymax = loopcheck - 1
                End If
                loopcheck += 1
            Loop

            'MsgBox("ArrayMax2: " & arraymax)

            random = CInt(Math.Floor((arraymax - 0 + 1) * Rnd())) + 0
            Select Case validwordlength(random)
                Case 1
                    random = CInt(Math.Floor((maxsecond(0) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(0, random)
                Case 2
                    random = CInt(Math.Floor((maxsecond(1) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(1, random)
                Case 3
                    random = CInt(Math.Floor((maxsecond(2) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(2, random)
                Case 4
                    random = CInt(Math.Floor((maxsecond(3) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(3, random)
                Case 5
                    random = CInt(Math.Floor((maxsecond(4) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(4, random)
                Case 6
                    random = CInt(Math.Floor((maxsecond(5) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(5, random)
                Case 7
                    random = CInt(Math.Floor((maxsecond(6) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(6, random)
                Case 8
                    random = CInt(Math.Floor((maxsecond(7) - 0 + 1) * Rnd())) + 0
                    MoveName &= secondwordarray(7, random)
                Case Else
                    'MsgBox("Unable to give second word!")
            End Select

        End If

        strlength = MoveName.Length

        Do While (Chars <= 13)
            If Chars = strlength + 1 Then
                value = &HFF
                br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                bw.Write(value)
            ElseIf Chars > strlength + 1 Then
                value = &H0
                br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                bw.Write(value)
            Else
                Select Case Mid(MoveName, Chars, 1)
                    Case " "
                        value = &H0
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "-"
                        value = &HAE
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "A"
                        value = &HBB
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "B"
                        value = &HBC
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "C"
                        value = &HBD
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "D"
                        value = &HBE
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "E"
                        value = &HBF
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "F"
                        value = &HC0
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "G"
                        value = &HC1
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "H"
                        value = &HC2
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "I"
                        value = &HC3
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "J"
                        value = &HC4
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "K"
                        value = &HC5
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "L"
                        value = &HC6
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "M"
                        value = &HC7
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "N"
                        value = &HC8
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "O"
                        value = &HC9
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "P"
                        value = &HCA
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "Q"
                        value = &HCB
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "R"
                        value = &HCC
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "S"
                        value = &HCD
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "T"
                        value = &HCE
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "U"
                        value = &HCF
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "V"
                        value = &HD0
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "W"
                        value = &HD1
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "X"
                        value = &HD2
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "Y"
                        value = &HD3
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "Z"
                        value = &HD4
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "a"
                        value = &HD5
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "b"
                        value = &HD6
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "c"
                        value = &HD7
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "d"
                        value = &HD8
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "e"
                        value = &HD9
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "f"
                        value = &HDA
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "g"
                        value = &HDB
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "h"
                        value = &HDC
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "i"
                        value = &HDD
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "j"
                        value = &HDE
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "k"
                        value = &HDF
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "l"
                        value = &HE0
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "m"
                        value = &HE1
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "n"
                        value = &HE2
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "o"
                        value = &HE3
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "p"
                        value = &HE4
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "q"
                        value = &HE5
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "r"
                        value = &HE6
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "s"
                        value = &HE7
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "t"
                        value = &HE8
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "u"
                        value = &HE9
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "v"
                        value = &HEA
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "w"
                        value = &HEB
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "x"
                        value = &HEC
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "y"
                        value = &HED
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                    Case "z"
                        value = &HEE
                        br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
                        bw.Write(value)
                End Select
            End If
            Chars += 1
            hexaddress += 1
        Loop


    End Sub

    Sub ReadAttack(ByVal hexaddress As String)
        Dim Chars As Integer = 1
        Dim value As Byte
        MoveName = ""
        Do While (Chars <= 12)
            br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
            value = br.ReadByte()
            Select Case value
                Case &H0
                    value = &H0
                    MoveName &= " "
                Case &HAE
                    MoveName &= "-"
                Case &HBB
                    MoveName &= "A"
                Case &HBC
                    MoveName &= "B"
                Case &HBD
                    MoveName &= "C"
                Case &HBE
                    MoveName &= "D"
                Case &HBF
                    MoveName &= "E"
                Case &HC0
                    MoveName &= "F"
                Case &HC1
                    MoveName &= "G"
                Case &HC2
                    MoveName &= "H"
                Case &HC3
                    MoveName &= "I"
                Case &HC4
                    MoveName &= "J"
                Case &HC5
                    MoveName &= "K"
                Case &HC6
                    MoveName &= "L"
                Case &HC7
                    MoveName &= "M"
                Case &HC8
                    MoveName &= "N"
                Case &HC9
                    MoveName &= "O"
                Case &HCA
                    MoveName &= "P"
                Case &HCB
                    MoveName &= "Q"
                Case &HCC
                    MoveName &= "R"
                Case &HCD
                    MoveName &= "S"
                Case &HCE
                    MoveName &= "T"
                Case &HCF
                    MoveName &= "U"
                Case &HD0
                    MoveName &= "V"
                Case &HD1
                    MoveName &= "W"
                Case &HD2
                    MoveName &= "X"
                Case &HD3
                    MoveName &= "Y"
                Case &HD4
                    MoveName &= "Z"
                Case &HD5
                    MoveName &= "a"
                Case &HD6
                    MoveName &= "b"
                Case &HD7
                    MoveName &= "c"
                Case &HD8
                    MoveName &= "d"
                Case &HD9
                    MoveName &= "e"
                Case &HDA
                    MoveName &= "f"
                Case &HDB
                    MoveName &= "g"
                Case &HDC
                    MoveName &= "h"
                Case &HDD
                    MoveName &= "i"
                Case &HDE
                    MoveName &= "j"
                Case &HDF
                    MoveName &= "k"
                Case &HE0
                    MoveName &= "l"
                Case &HE1
                    MoveName &= "m"
                Case &HE2
                    MoveName &= "n"
                Case &HE3
                    MoveName &= "o"
                Case &HE4
                    MoveName &= "p"
                Case &HE5
                    MoveName &= "q"
                Case &HE6
                    MoveName &= "r"
                Case &HE7
                    MoveName &= "s"
                Case &HE8
                    MoveName &= "t"
                Case &HE9
                    MoveName &= "u"
                Case &HEA
                    MoveName &= "v"
                Case &HEB
                    MoveName &= "w"
                Case &HEC
                    MoveName &= "x"
                Case &HED
                    MoveName &= "y"
                Case &HEE
                    MoveName &= "z"
                Case &HFF
                    Chars = 14
            End Select
            Chars += 1
            hexaddress += 1
        Loop


    End Sub


    Private Sub rndpower_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndpower.CheckedChanged
        If rndpower.Checked = False Then
            balancestats.Checked = False
        End If
    End Sub

    Private Sub rndaccurate_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndaccurate.CheckedChanged
        If rndaccurate.Checked = False Then
            balancestats.Checked = False
        End If
    End Sub

    Private Sub rndpp_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndpp.CheckedChanged
        If rndpp.Checked = False Then
            balancestats.Checked = False
        End If
    End Sub

    Private Sub balancestats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles balancestats.CheckedChanged
        If balancestats.Checked Then
            rndpower.Checked = True
            rndaccurate.Checked = True
            rndpp.Checked = True
        End If
    End Sub

    Private Sub lstboxgame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstboxgame.SelectedIndexChanged
        Select Case lstboxgame.Text
            Case "Ruby (U) 1.0"
                GameType = 0
            Case "Sapphire (U) 1.0"
                GameType = 1
            Case "Emerald (U)"
                GameType = 2
            Case "Fire Red (U) 1.0"
                GameType = 3
            Case "Leaf Green (U) 1.1"
                GameType = 4
            Case "Fire Red (U) 1.1"
                GameType = 5
            Case "Leaf Green (U) 1.0"
                GameType = 6
            Case "Ruby (U) 1.1"
                GameType = 7
            Case "Sapphire (U) 1.1"
                GameType = 8
            Case Else
                GameType = -1
        End Select
    End Sub
End Class
