Imports System.IO

Public Class Form1
    Enum MoveDataIndex
        Effect = 0
        Power = 1
        Type = 2
        Accuracy = 3
        PP = 4
        EffectChance = 5
        Target = 6
        Priority = 7
        Flags = 8
        Unused1 = 9
        Category = 10
        Unused2 = 12
    End Enum
    Enum AnimationDataIndex
        AnimAdress = 0
        Type = 1
        Bracket = 2
        AnimFlags = 3
    End Enum
    Enum EffectDataIndex
        EffectIndex = 0
        UsePower = 1
        UseAccuracy = 2
        UseEffectChance = 3
        FixedPower = 4
        MaxPower = 5
        MaxAccuracy = 6
        Category = 7
        Priority = 8
        BaseFlags = 9
        IgnoreFlags = 10
        ForcedTarget = 11
        Limited = 12
        FixedEffectChance = 13
        BonusPoints = 14
        EffectFlags = 15
    End Enum

    Enum TargetFlags
        Selected = 0
        Contextual = 1
        RandomFoe = 4
        BothFoes = 8
        User = 16
        EveryoneElse = 32
        Field = 64
    End Enum
    Enum MoveFlags
        None = 0
        MakeContact = 1
        CanBlock = 2
        CanMagicCoat = 4
        CanSnatch = 8
        AllowMirrorMove = 16
        AllowKingRock = 32
    End Enum
    Enum EffectFlags
        None = 0
        SemiMove = 1
        MultiHit = 2
    End Enum
    Enum AnimFlags
        None = 0
        IsLong = 1
    End Enum
    Enum TypeIndex
        Normal = 0
        Fighting = 1
        Flying = 2
        Poison = 3
        Ground = 4
        Rock = 5
        Bug = 6
        Ghost = 7
        Steel = 8
        Typeless = 9
        Fire = 10
        Water = 11
        Grass = 12
        Electric = 13
        Psychic = 14
        Ice = 15
        Dragon = 16
        Dark = 17
        Fairy = 18
        MaxTypes = 19
    End Enum

    Dim fs As FileStream
    Dim br As BinaryReader
    Dim bw As BinaryWriter

    Dim sr As StreamWriter

    Dim MoveName As String = String.Empty

    Dim RngTypeArray As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17}

    Dim GameType As Integer = -1
    '0 = none/unsupported
    '1 = custom
    '2 = fire red usa 1.0
    '3 = emerald usa

    'Name Data and Spoiler File
    Dim spoilerfile As String = Application.StartupPath & "\spoilers.txt"
    Dim NameData_Path As String = Application.StartupPath & "\RandomNames\"
    Dim NameData_Type_Bug As String = NameData_Path & "Bug.txt"
    Dim NameData_Type_Dark As String = NameData_Path & "Dark.txt"
    Dim NameData_Type_Dragon As String = NameData_Path & "Dragon.txt"
    Dim NameData_Type_Electric As String = NameData_Path & "Electric.txt"
    Dim NameData_Type_Fighting As String = NameData_Path & "Fight.txt"
    Dim NameData_Type_Fire As String = NameData_Path & "Fire.txt"
    Dim NameData_Type_Flying As String = NameData_Path & "Flying.txt"
    Dim NameData_Type_Ghost As String = NameData_Path & "Ghost.txt"
    Dim NameData_Type_Grass As String = NameData_Path & "Grass.txt"
    Dim NameData_Type_Ice As String = NameData_Path & "Ice.txt"
    Dim NameData_Type_Poison As String = NameData_Path & "Poison.txt"
    Dim NameData_Type_Psychic As String = NameData_Path & "Psychic.txt"
    Dim NameData_Type_Rock As String = NameData_Path & "Rock.txt"
    Dim NameData_Type_Ground As String = NameData_Path & "Ground.txt"
    Dim NameData_Type_Steel As String = NameData_Path & "Steel.txt"
    Dim NameData_Type_Water As String = NameData_Path & "Water.txt"
    Dim NameData_Type_Normal As String = NameData_Path & "Neutral.txt"
    Dim NameData_Category_Physical As String = NameData_Path & "2Physical.txt"
    Dim NameData_Category_Special As String = NameData_Path & "2Special.txt"
    Dim NameData_Category_Debuff As String = NameData_Path & "2Status.txt"
    Dim NameData_Category_Buff As String = NameData_Path & "2SelfStatus.txt"
    Dim MaxWordEntries = 300
    Dim MaxSecondWordLength = 9
    'Better name array stuff, hit me
    Dim FirstWordArray(17, 300) As String
    '17 = the Type
    '300 = the word, index 0 is used to track the max entries
    Dim SecondWordArray(4, 9, 300) As String
    '4 = the category
    '8 = the word length (max is 8 characters long)
    '300 = the word, index 0 is used to track the max entries

    'VersionInfo Data
    Dim GameData_Path As String = Application.StartupPath & "\Presets\"
    Dim PresetData_Path As String = GameData_Path & "Presets.txt"
    Dim FireRedUSA10 As String = GameData_Path & "Fire Red USA 1.0.txt"
    Dim GameData_MoveTable_StartAddress As String
    Dim GameData_NameTable_StartAddress As String
    Dim GameData_DescTable_StartAddress As String
    Dim GameData_AnimTable_StartAddress As String
    Dim GameData_TotalMoves As Integer
    Dim GameData_NameLength As Integer
    Dim GameData_DescLength As Integer
    Dim GameData_AnimLength As Integer
    Dim GameData_Effects(300, 15) As Integer
    'index 0, 0 is reserved as the max count tracker
    'For spoilers text
    Dim GameData_Effects_Strings(300, 3) As String
    '0 = Description Hex Address
    '1 = Force Animation Hex Address
    '2 = Spoiler Description Text

    Dim GameData_AnimAddress(1000, 5) As Integer
    '1000 = the animation index, index 0 is reserved as the max count tracker

    Dim GameData_NaturePower_Name(100) As String
    Dim GameData_NaturePower_Index(100) As Integer
    '0 is used as the max count tracker
    Dim MoveIndex_BlackList(500) As Integer
    Dim SemiMove_BlackList(500) As Integer
    '
    Dim LookTable_Power() = {0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255}
    Dim LookTable_Power_Multi() = {0, 5, 10, 15, 18, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255}
    Dim LookTable_Accuracy() = {0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195, 200, 205, 210, 215, 220, 225, 230, 235, 240, 245, 250, 255}
    Dim LookTable_PP() = {0, 5, 10, 15, 20, 25, 30, 35, 40}
    Dim LookTable_EffectChance() = {0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100}
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
                            GameType = 3
                            lstboxgame.SelectedIndex = 3
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
                            GameType = 2
                            lstboxgame.SelectedIndex = 2
                        Else
                            MessageBox.Show("This appears to be a Pokemon Fire Red ROM," & vbNewLine & "however its either not a US ROM or the version is unsupported." & vbNewLine & "Try correcting this with the ROM Version/Info dropbox", "Unknown/Unsupported ROM version")
                        End If
                    Case Else
                        GameType = 0
                        lstboxgame.SelectedIndex = 0
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
        If My.Computer.FileSystem.FileExists(patchfile.Text) And GameType > -1 Then
            Randomize()
            Dim address As String
            fs = New FileStream(patchfile.Text, FileMode.Open)
            br = New BinaryReader(fs)
            bw = New BinaryWriter(fs)

            Dim index As Integer = 1
            Dim movedesc As String
            Dim textline As Integer = 0
            Dim canRename As Boolean = False

            SetupGameData(lstboxgame.Text)

            If GameData_MoveTable_StartAddress < 1 Or GameData_TotalMoves < 1 Then
                MessageBox.Show("Missing or unreadable data for MoveAddress or TotalMoves, cannot continue.", "Presets Error")
                Return
            End If

            If GameData_NameTable_StartAddress < 1 Or GameData_NameLength < 1 Then
                MessageBox.Show("Missing or unreadable data for NameAddress or NameLength, cannot continue.", "Presets Error")
                Return
            End If

            If GameData_DescTable_StartAddress < 1 Or GameData_DescLength < 1 Then
                MessageBox.Show("Missing or unreadable data for DescAddress or DescLength, cannot continue.", "Presets Error")
                Return
            End If

            If GameData_AnimTable_StartAddress < 1 Or GameData_AnimLength < 1 Then
                MessageBox.Show("Missing or unreadable data for AnimAddress or AnimLength, cannot continue.", "Presets Error")
                Return
            End If

            If System.IO.File.Exists(spoilerfile) Then
                sr = New StreamWriter(spoilerfile)
            Else
                File.Create(spoilerfile).Dispose()
                sr = New StreamWriter(spoilerfile)
            End If

            If checkbox_rnd_name.Checked Then
                canRename = SetupNameArray()
                If canRename = False Then
                    checkbox_rnd_name.Checked = False
                    MsgBox("Missing renaming file(s), cannot rename moves!")
                End If
            End If

            Dim UsedEffect_Pool(TypeIndex.MaxTypes + 1, 255)
            Dim Log_NaturePower As Boolean = GameData_NaturePower_Index(0) > 0
            Dim NaturePower_LogList(100) As String

            Do While (index <= GameData_TotalMoves)
                address = GameData_MoveTable_StartAddress + (12 * index)
                Dim EffectIndex = 0

                address = SeekMoveData(index, MoveDataIndex.Effect)
                br.BaseStream.Seek(address, SeekOrigin.Begin)
                EffectIndex = br.ReadByte()

                Dim Check_RandomEffect = False
                Dim Check_Balance = False
                Dim Check_RandomCategory = False
                Dim Check_RandomPower = False
                Dim Check_RandomAccuracy = False
                Dim Check_RandomPP = False
                Dim Check_RandomAnim = False
                Dim Check_RandomName = False
                Dim Check_RandomElement = False

                If CanModifyMove(index, EffectIndex) Then
                    Check_RandomEffect = checkbox_rnd_effect.Checked
                    Check_Balance = checkbox_balance.Checked
                    Check_RandomCategory = checkbox_rnd_category.Checked
                    Check_RandomPower = checkbox_rnd_power.Checked
                    Check_RandomAccuracy = checkbox_rnd_accuracy.Checked
                    Check_RandomPP = checkbox_rnd_pp.Checked
                    Check_RandomAnim = canRename And checkbox_rnd_anim.Checked
                    Check_RandomName = checkbox_rnd_name.Checked
                    Check_RandomElement = checkbox_rnd_element.Checked
                End If

                Dim LogScale = False
                Dim MoveFlagString = ""
                Dim Priority = 0
                Dim UsePower = True
                Dim UseAccuracy = True
                Dim UseEffectChance = True
                Dim FixedPower = -1
                Dim ForcedTarget = -1
                Dim BaseFlags = 2
                Dim IgnoreFlags = 0
                Dim EffectChance = 0
                Dim FixedEffectChance = 0
                Dim Category = -1
                Dim Power = 0
                Dim Accuracy = 0
                Dim PP = 0
                Dim DataIndex = -1
                Dim Typing = 9
                Dim randomVal As Integer
                Dim MaxPower As Integer = 51
                Dim MaxAccuracy As Integer = 20
                Dim ThisEffectFlags As Integer = 0
                Dim ThisPowerTable = LookTable_Power

                Dim movePoints As Integer = 0
                Dim maxPoints As Integer = 0
                Dim minrollPoints As Integer = 22
                Dim maxrollPoints As Integer = 31
                Dim rollPoints As Integer = 0
                Dim investMethod As Integer = 0
                Dim focusStat As Integer = -1
                '0 = does not tamper with the weights
                '1 = as points are put into a stat it becomes less likely to pick it.
                '2 = as points are put into a stat it becomes more likely to pick it.
                '3 = it will try to max out the first stat it picks, maxing out being 100 or 40 in the case of PP

                'Assign the type first
                address = SeekMoveData(index, MoveDataIndex.Type)
                If Check_RandomElement Then
                    Typing = RngTypeArray(RandomRange(0, RngTypeArray.Length - 1))
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(Typing))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Typing = br.ReadByte()
                End If

                'Roll an Effect Index or get the current one depending on settings.
                address = SeekMoveData(index, MoveDataIndex.Effect)
                If Check_RandomEffect Then
                    DataIndex = RollEffectData(Typing, UsedEffect_Pool)
                    EffectIndex = GameData_Effects(DataIndex, EffectDataIndex.EffectIndex)
                    ChangeDesc(index, GameData_Effects_Strings(DataIndex, EffectDataIndex.EffectIndex))
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(EffectIndex))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    EffectIndex = br.ReadByte()
                    DataIndex = FindDataIndexFromEffectIndex(EffectIndex)
                End If

                If DataIndex > 0 Then
                    'Draw base values for the move from our effect data table.
                    UsePower = GameData_Effects(DataIndex, EffectDataIndex.UsePower)
                    UseAccuracy = GameData_Effects(DataIndex, EffectDataIndex.UseAccuracy)
                    UseEffectChance = GameData_Effects(DataIndex, EffectDataIndex.UseEffectChance)
                    FixedPower = GameData_Effects(DataIndex, EffectDataIndex.FixedPower)
                    If FixedPower > -1 Then
                        Power = FixedPower
                        UsePower = False
                    End If
                    Category = GameData_Effects(DataIndex, EffectDataIndex.Category)
                    If Category > 1 Then
                        UsePower = False
                    End If
                    MaxPower = GameData_Effects(DataIndex, EffectDataIndex.MaxPower)
                    MaxAccuracy = GameData_Effects(DataIndex, EffectDataIndex.MaxAccuracy)
                    If MaxAccuracy < 1 Then
                        UseAccuracy = False
                    End If
                    If MaxAccuracy > 51 Then
                        MaxAccuracy = 51
                    End If
                    Priority = GameData_Effects(DataIndex, EffectDataIndex.Priority)
                    BaseFlags = GameData_Effects(DataIndex, EffectDataIndex.BaseFlags)
                    IgnoreFlags = GameData_Effects(DataIndex, EffectDataIndex.IgnoreFlags)
                    If BaseFlags < 0 Then
                        BaseFlags = 0
                        BaseFlags = TryAddFlags(BaseFlags, MoveFlags.CanBlock, IgnoreFlags)
                    End If
                    ForcedTarget = GameData_Effects(DataIndex, EffectDataIndex.ForcedTarget)
                    If ShouldBypassAccuracy(ForcedTarget) Then
                        UseAccuracy = False
                    End If
                    FixedEffectChance = GameData_Effects(DataIndex, EffectDataIndex.FixedEffectChance)
                    If FixedEffectChance > 0 Then
                        EffectChance = FixedEffectChance
                        UseEffectChance = False
                    End If
                    movePoints = GameData_Effects(DataIndex, EffectDataIndex.BonusPoints)
                    ThisEffectFlags = GameData_Effects(DataIndex, EffectDataIndex.EffectFlags)
                    If ValueHasFlag(ThisEffectFlags, EffectFlags.MultiHit) Then
                        ThisPowerTable = LookTable_Power_Multi
                    End If
                End If

                'Setup targeting data
                address = SeekMoveData(index, MoveDataIndex.Target)
                If Check_RandomEffect Then
                    If ForcedTarget < 0 Then
                        randomVal = RandomRange(1, 40)
                        ForcedTarget = TargetFlags.Selected
                        If randomVal = 1 Then
                            ForcedTarget = TargetFlags.RandomFoe
                        End If
                        If randomVal = 2 Then
                            ForcedTarget = TargetFlags.BothFoes
                        End If
                        If randomVal = 3 Then
                            ForcedTarget = TargetFlags.EveryoneElse
                        End If
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(ForcedTarget))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    ForcedTarget = br.ReadByte()
                End If

                If Check_Balance Then
                    LogScale = True
                    Dim divider = 1
                    Dim investPower = 1000
                    Dim investAccuracy = 1000
                    Dim investEffectChance = 300
                    Dim investPP = 1000
                    rollPoints = RandomRange(minrollPoints, maxrollPoints)
                    maxPoints += rollPoints

                    'Give a small point bonus if the targeting is poor.
                    If (ForcedTarget And TargetFlags.RandomFoe) Or (ForcedTarget And TargetFlags.EveryoneElse) Then
                        maxPoints += 2
                    End If

                    movePoints += maxPoints
                    'Set up base values
                    If UsePower Then
                        Power = 2
                    Else
                        'movePoints -= 8
                        divider += 1
                        investPower = 0
                    End If
                    Accuracy = 0
                    If UseAccuracy Then
                        Accuracy = 10
                        If Accuracy > MaxAccuracy Then
                            Accuracy = MaxAccuracy
                        End If
                    Else
                        'movePoints -= 8
                        divider += 1
                        investAccuracy = 0
                    End If
                    PP = 1
                    investPP = Math.Ceiling(5000 / maxPoints)
                    If UseEffectChance Then
                        EffectChance = 2
                    Else
                        investEffectChance = 0
                    End If

                    movePoints = Math.Ceiling(movePoints / divider)

                    maxPoints = movePoints
                    If movePoints < 0 Then
                        movePoints = 0
                    End If

                    If Priority = 0 And checkbox_mod_priority.Checked Then
                        If movePoints >= 8 And rollPoints >= RandomRange(1, maxrollPoints * 32) Then
                            movePoints -= 8
                            Priority += 1
                        End If
                    End If

                    'Slightly weight the investment values based on the total movePoints
                    If Category < 2 Then
                        If checkbox_buff_normal.Checked And Typing = TypeIndex.Normal Then
                            maxPoints += RandomRange(0, 2)
                        End If
                        If UsePower And UseAccuracy Then
                            investMethod = RandomRange(0, 2)
                            If investMethod > 0 Then
                                investMethod = RandomRange(1, 3)
                            End If
                        End If
                    End If


                    Do While movePoints > 0
                        Dim weightArray() As Integer = {-1, -1, -1, -1}
                        Dim maxRange = 0
                        If Power >= MaxPower Then
                            investPower = 0
                        End If
                        If investPower > 0 Then
                            weightArray(0) = 0
                            If focusStat = 0 Then
                                maxRange += 999999
                            Else
                                maxRange += investPower
                            End If
                        End If
                        If Accuracy >= MaxAccuracy Then
                            investAccuracy = 0
                        End If
                        If investAccuracy > 0 Then
                            weightArray(1) = maxRange
                            If focusStat = 1 Then
                                maxRange += 999999
                            Else
                                maxRange += investAccuracy
                            End If
                        End If
                        If PP > 7 Or movePoints < 2 Then
                            investPP = 0
                        End If
                        If investPP > 0 Then
                            weightArray(2) = maxRange
                            If focusStat = 2 Then
                                maxRange += 999999
                            Else
                                maxRange += investPP
                            End If
                        End If
                        If investEffectChance > 0 Then
                            weightArray(3) = maxRange
                            If focusStat = 3 Then
                                maxRange += 999999
                            Else
                                maxRange += investEffectChance
                            End If
                        End If


                        If maxRange > 0 Then
                            'MessageBox.Show("Range = " & maxRange)
                            maxRange = RandomRange(1, maxRange)
                            Dim outCome = weightArray.Length
                            Do While outCome > 0
                                outCome -= 1
                                If weightArray(outCome) > -1 And maxRange > weightArray(outCome) Then
                                    Exit Do
                                End If
                            Loop
                            'MessageBox.Show("outcome = " & outCome)
                            Select Case outCome
                                Case 0
                                    Power += 1
                                    movePoints -= 1
                                    If Power > ThisPowerTable.Length - 2 Then
                                        investPower = 0
                                        focusStat = -1
                                    ElseIf Power >= 20 Then
                                        focusStat = -1
                                    End If
                                    investPower = InvestPoint_Tamper(investMethod, investPower)
                                Case 1
                                    Accuracy += 1
                                    movePoints -= 1
                                    If Accuracy >= 20 Then
                                        focusStat = -1
                                    End If
                                    If Accuracy = 20 Then
                                        If checkbox_mod_accuracy.Checked Then
                                            If movePoints >= 8 And rollPoints >= RandomRange(1, maxrollPoints * 28) Then
                                                investAccuracy = 0
                                                movePoints -= 8
                                                Accuracy = 0
                                                UseAccuracy = False
                                            End If
                                        End If
                                    End If
                                    investAccuracy = InvestPoint_Tamper(investMethod, investAccuracy)
                                Case 2
                                    If movePoints > 1 Then
                                        movePoints -= 2
                                        PP += 1
                                    End If
                                    investPP = InvestPoint_Tamper(investMethod, investPP)
                                Case 3
                                    EffectChance += 1
                                    movePoints -= 1
                                    If EffectChance > LookTable_EffectChance.Length - 2 Then
                                        investEffectChance = 0
                                    End If
                                    investEffectChance = InvestPoint_Tamper(investMethod, investEffectChance)
                            End Select
                            If investMethod = 3 Then
                                investMethod = 0
                                focusStat = outCome
                            End If
                        Else
                            Exit Do
                        End If
                    Loop
                Else
                    If checkbox_rnd_effect.Checked Then
                        If Priority = 0 And checkbox_mod_priority.Checked Then
                            If RandomRange(1, 128) = 1 Then
                                Priority += 1
                            End If
                        End If
                    End If
                    If checkbox_rnd_accuracy.Checked Then
                        If UseAccuracy And checkbox_mod_accuracy.Checked Then
                            If RandomRange(1, 96) = 1 Then
                                Accuracy = 0
                                UseAccuracy = False
                            End If
                        End If
                    End If
                End If

                'Figure out the Category based on pre Gen 4 typings.
                If Check_RandomCategory = False And Category < 0 Then
                    If Typing < 10 Then
                        Category = 0
                    ElseIf Typing > 9 And Typing <= 17 Then
                        Category = 1
                    End If
                End If
                If Category = 2 Then
                    UsePower = False
                End If

                'Move Power
                address = SeekMoveData(index, MoveDataIndex.Power)
                If Check_RandomPower Then
                    If Check_Balance = False Then
                        Power = RandomRange(1, ThisPowerTable.Length - 2)
                    End If

                    If FixedPower < 0 Then
                        If Power < 1 And Category < 2 Then
                            Power = 1
                        Else
                            If Power > ThisPowerTable.Length - 2 Then
                                Power = ThisPowerTable.Length - 1
                            End If
                            Power = ThisPowerTable(Power)
                        End If
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(Power))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Power = br.ReadByte()
                End If

                'Move Accuracy
                address = SeekMoveData(index, MoveDataIndex.Accuracy)
                If Check_RandomAccuracy Then
                    If Check_Balance = False Then
                        If UseAccuracy = False Then
                            Accuracy = 0
                        Else
                            Accuracy = RandomRange(1, 40)
                        End If
                    End If
                    Accuracy *= 5
                    If Accuracy > 255 Then
                        Accuracy = 255
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(Accuracy))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Accuracy = br.ReadByte()
                End If

                'Move PP
                address = SeekMoveData(index, MoveDataIndex.PP)
                If Check_RandomPP Then
                    If Check_Balance = False Then
                        PP = RandomRange(1, 10)
                    End If
                    PP *= 5
                    If PP > 40 Then
                        PP = PP
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(PP))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    PP = br.ReadByte()
                End If

                'Effect Chance
                address = SeekMoveData(index, MoveDataIndex.EffectChance)
                If Check_RandomEffect Then
                    If Check_Balance = False Then
                        If UseEffectChance Then
                            EffectChance = RandomRange(1, LookTable_EffectChance.Length - 1)
                        End If
                    End If
                    If EffectChance > LookTable_EffectChance.Length - 2 Then
                        EffectChance = LookTable_EffectChance.Length - 1
                    End If
                    EffectChance = LookTable_EffectChance(EffectChance)
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(EffectChance))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    EffectChance = br.ReadByte()
                End If

                'Move Priority
                address = SeekMoveData(index, MoveDataIndex.Priority)
                If Check_RandomEffect Then
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(Priority))
                Else
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    Priority = br.ReadByte()
                End If

                'Move Category
                address = SeekMoveData(index, MoveDataIndex.Category)
                If Check_RandomCategory Then
                    If Category < 0 Then
                        Category = RandomRange(0, 1)
                    End If
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(Category))
                End If
                'Flags
                'MoveFlags are:
                '1 = Makes Contact
                '2 = Can be Blocked
                '4 = Affected by Magic Coat
                '8 = Can be stolen by Snatch
                '16 = Can be copied by Mirror Move
                '32 = Can proc King's Rock
                address = SeekMoveData(index, MoveDataIndex.Flags)
                If Check_RandomEffect Then
                    'Roll a random chance for Physical and Special moves to make contact.
                    'Also make every Physical and Special move trigger King's Rock.
                    If Category = 0 Then
                        If RandomRange(1, 8) < 8 Then
                            BaseFlags = TryAddFlags(BaseFlags, MoveFlags.MakeContact, IgnoreFlags)
                        End If
                        BaseFlags = TryAddFlags(BaseFlags, MoveFlags.AllowKingRock, IgnoreFlags)
                    ElseIf Category = 1 Then
                        If RandomRange(1, 128) = 1 Then
                            BaseFlags = TryAddFlags(BaseFlags, MoveFlags.MakeContact, IgnoreFlags)
                        End If
                        BaseFlags = TryAddFlags(BaseFlags, MoveFlags.AllowKingRock, IgnoreFlags)
                    Else
                        If ForcedTarget And TargetFlags.User Then
                            'Ignore protect if we target ourself.
                            If BaseFlags And MoveFlags.CanBlock Then
                                BaseFlags -= MoveFlags.CanBlock
                            End If
                        ElseIf ForcedTarget And TargetFlags.Contextual Then
                        Else
                            'Add Magic Coat if we don't target ourself.
                            BaseFlags = TryAddFlags(BaseFlags, MoveFlags.CanMagicCoat, IgnoreFlags)
                        End If
                    End If
                    If ShouldMirrorMove(ForcedTarget) Then
                        BaseFlags = TryAddFlags(BaseFlags, MoveFlags.AllowMirrorMove, IgnoreFlags)
                    End If

                    'Snatch is handled per effect in the data table
                    br.BaseStream.Seek(address, SeekOrigin.Begin)
                    bw.Write(Convert.ToByte(BaseFlags))
                End If

                If (BaseFlags And MoveFlags.MakeContact) = MoveFlags.MakeContact Then
                    MoveFlagString += "Contact"
                End If
                If (BaseFlags And MoveFlags.CanBlock) = MoveFlags.CanBlock Then
                    If MoveFlagString.Length > 0 Then
                        MoveFlagString += "/"
                    End If
                    MoveFlagString += "Blockable"
                End If
                If (BaseFlags And MoveFlags.CanMagicCoat) = MoveFlags.CanMagicCoat Then
                    If MoveFlagString.Length > 0 Then
                        MoveFlagString += "/"
                    End If
                    MoveFlagString += "Magic Coat"
                End If

                If (BaseFlags And MoveFlags.CanSnatch) = MoveFlags.CanSnatch Then
                    If MoveFlagString.Length > 0 Then
                        MoveFlagString += "/"
                    End If
                    MoveFlagString += "Snatch"
                End If

                If (BaseFlags And MoveFlags.AllowMirrorMove) = MoveFlags.AllowMirrorMove Then
                    If MoveFlagString.Length > 0 Then
                        MoveFlagString += "/"
                    End If
                    MoveFlagString += "Mirror Move"
                End If

                If (BaseFlags And MoveFlags.AllowKingRock) = MoveFlags.AllowKingRock Then
                    If MoveFlagString.Length > 0 Then
                        MoveFlagString += "/"
                    End If
                    MoveFlagString += "King's Rock"
                End If

                'Remove from the Pool
                UsedEffect_Pool(Typing, DataIndex) += 1
                UsedEffect_Pool(TypeIndex.MaxTypes, DataIndex) += 1

                '/////////////
                '//ANIMATION//
                '/////////////
                If Check_RandomAnim Then
                    AnimateMove(DataIndex, index, Power, Typing, Category, ForcedTarget, ThisEffectFlags)
                End If

                '//////////
                '//NAMING//
                '//////////
                address = GameData_NameTable_StartAddress + (GameData_NameLength * index)
                If Check_RandomName And canRename Then
                    MoveName = CreateMoveName(Typing, Category, ForcedTarget)
                    ChangeMoveName(MoveName, index)
                Else
                    ReadAttack(address)
                End If

                '///////////
                '//LOGGING//
                '///////////
                If File.Exists(spoilerfile) Then
                    sr.WriteLine("----" & index & "." & MoveName & "----")
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
                    Select Case Category
                        Case 0
                            sr.WriteLine("Category: Physical")
                        Case 1
                            sr.WriteLine("Category: Special")
                        Case 2
                            sr.WriteLine("Category: Status")
                    End Select
                    Select Case ForcedTarget
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
                    If Priority <> 0 Then
                        sr.WriteLine("Priority: " & Priority)
                    End If
                    If DataIndex > 0 Then
                        sr.WriteLine("Effect: " & GameData_Effects_Strings(DataIndex, 2))
                    End If
                    If EffectChance > 0 Then
                        sr.WriteLine("Effect Chance: " & EffectChance & "%")
                    End If
                    If MoveFlagString.Length > 0 Then
                        sr.WriteLine("Flags: " & MoveFlagString)
                    Else
                        sr.WriteLine("Flags: None")
                    End If

                    If LogScale Then
                        If GameData_Effects(DataIndex, EffectDataIndex.BonusPoints) > -1 Then
                            sr.WriteLine("Points Roll: " & rollPoints & "+" & GameData_Effects(DataIndex, EffectDataIndex.BonusPoints) & " (" & minrollPoints & "-" & maxrollPoints & ")")
                        ElseIf GameData_Effects(DataIndex, EffectDataIndex.BonusPoints) < 0 Then
                            sr.WriteLine("Points Roll: " & rollPoints & GameData_Effects(DataIndex, EffectDataIndex.BonusPoints) & " (" & minrollPoints & "-" & maxrollPoints & ")")
                        End If
                        sr.WriteLine("Points Spent: " & maxPoints - movePoints & "/" & maxPoints)
                    End If

                    If Log_NaturePower Then
                        Dim natureIndex = GetNaturePower_ByMoveIndex(index)
                        If natureIndex > 0 Then
                            NaturePower_LogList(natureIndex) = GameData_NaturePower_Name(natureIndex) & " = " & index & "." & MoveName
                        End If
                    End If
                End If
                index += 1
            Loop

            If Log_NaturePower Then
                sr.WriteLine("=========================")
                sr.WriteLine("----NATURE POWER LIST----")
                Dim i As Integer = 1
                Do While i < NaturePower_LogList.Length
                    If String.IsNullOrEmpty(NaturePower_LogList(i)) Then
                    Else
                        If NaturePower_LogList(i).Length > 0 Then
                            sr.WriteLine(NaturePower_LogList(i))
                        End If
                    End If
                    i += 1
                Loop
            End If
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
    Function FindDataIndexFromEffectIndex(effectIndex As Integer)
        Dim dataIndex = 0
        Dim dataList(255)
        Do Until dataIndex > GameData_Effects(0, 0)
            If GameData_Effects(dataIndex, EffectDataIndex.EffectIndex) = effectIndex Then
                dataList(0) += 1
                dataList(dataList(0)) = dataIndex
            End If
            dataIndex += 1
        Loop
        If dataIndex < 1 Then
            Return 0
        End If
        Return dataList(RandomRange(1, dataList(0)))
    End Function
    Sub SetupGameData(DataFile As String)
        DataFile = GameData_Path & DataFile & ".txt"
        If File.Exists(DataFile) Then
            Dim LineData As String
            Dim srDataFile As StreamReader
            srDataFile = File.OpenText(DataFile)

            GameData_MoveTable_StartAddress = -1
            GameData_NameTable_StartAddress = -1
            GameData_DescTable_StartAddress = -1
            GameData_AnimTable_StartAddress = -1
            GameData_TotalMoves = -1
            GameData_NameLength = -1
            GameData_DescLength = -1
            GameData_AnimLength = -1
            GameData_Effects(0, 0) = 0

            GameData_AnimAddress(0, 0) = 0
            Dim ResetIndex = 0

            ResetIndex = 0
            Do While (ResetIndex < MoveIndex_BlackList.Length)
                MoveIndex_BlackList(ResetIndex) = 0
                ResetIndex += 1
            Loop

            ResetIndex = 0
            Do While (ResetIndex < SemiMove_BlackList.Length)
                SemiMove_BlackList(ResetIndex) = 0
                ResetIndex += 1
            Loop

            LineData = srDataFile.ReadLine()

            Do Until LineData Is Nothing
                Dim commentIndex As Integer = LineData.IndexOf("//")
                Dim UncommentData = LineData
                If commentIndex > 0 Then
                    UncommentData = UncommentData.Substring(0, commentIndex)
                End If
                Dim UnitData() As String = UncommentData.Split("|")
                If UnitData.Length > 1 Then
                    Select Case UnitData(0)
                        Case "MoveAddress"
                            GameData_LineRead_MoveAddress(UnitData)
                        Case "TotalMoves"
                            GameData_LineRead_TotalMoves(UnitData)
                        Case "NameAddress"
                            GameData_LineRead_NameAddress(UnitData)
                        Case "NameLength"
                            GameData_LineRead_NameLength(UnitData)
                        Case "DescAddress"
                            GameData_LineRead_DescAddress(UnitData)
                        Case "DescLength"
                            GameData_LineRead_DescLength(UnitData)
                        Case "AnimAddress"
                            GameData_LineRead_AnimAddress(UnitData)
                        Case "AnimLength"
                            GameData_LineRead_AnimLength(UnitData)
                        Case "AnimIndex"
                            GameData_LineRead_RegisterAnimData(UnitData)
                        Case "EffectIndex"
                            GameData_LineRead_RegisterEffectData(UnitData)
                        Case "NaturePower"
                            GameData_LineRead_RegisterNaturePowerData(UnitData)
                        Case "StruggleIndex"
                            If checkbox_ignore_struggle.Checked Then
                                GameData_LineRead_RegisterMoveBlackList(UnitData)
                            End If
                        Case "SemiMoveIndex"
                            GameData_LineRead_RegisterSemiMoveBlackList(UnitData)
                    End Select
                End If
                LineData = srDataFile.ReadLine()
            Loop
            srDataFile.Close()
        Else
            MessageBox.Show("File " & DataFile & ".txt cannot be found.", "Missing Presets File")
        End If
    End Sub
    Sub GameData_LineRead_MoveAddress(UnitData() As String)
        Dim address = Convert.ToInt32(UnitData(1), 16)
        If address > 0 Then
            GameData_MoveTable_StartAddress = address
        End If
    End Sub
    Sub GameData_LineRead_TotalMoves(UnitData() As String)
        Dim total = Convert.ToInt32(UnitData(1))
        If total > 0 Then
            GameData_TotalMoves = total
        End If
    End Sub
    Sub GameData_LineRead_NameAddress(UnitData() As String)
        Dim address = Convert.ToInt32(UnitData(1), 16)
        If address > 0 Then
            GameData_NameTable_StartAddress = address
        End If
    End Sub
    Sub GameData_LineRead_NameLength(UnitData() As String)
        Dim total = Convert.ToInt32(UnitData(1))
        If total > 0 Then
            GameData_NameLength = total
        End If
    End Sub
    Sub GameData_LineRead_DescAddress(UnitData() As String)
        Dim address = Convert.ToInt32(UnitData(1), 16)
        If address > 0 Then
            GameData_DescTable_StartAddress = address
        End If
    End Sub
    Sub GameData_LineRead_DescLength(UnitData() As String)
        Dim total = Convert.ToInt32(UnitData(1))
        If total > 0 Then
            GameData_DescLength = total
        End If
    End Sub
    Sub GameData_LineRead_AnimAddress(UnitData() As String)
        Dim address = Convert.ToInt32(UnitData(1), 16)
        If address > 0 Then
            GameData_AnimTable_StartAddress = address
        End If
    End Sub
    Sub GameData_LineRead_AnimLength(UnitData() As String)
        Dim total = Convert.ToInt32(UnitData(1))
        If total > 0 Then
            GameData_AnimLength = total
        End If
    End Sub
    Sub GameData_LineRead_RegisterNaturePowerData(UnitData() As String)
        If UnitData.Length = 3 Then
            Dim index = GameData_NaturePower_Index(0) + 1
            If index < GameData_NaturePower_Index.Length Then
                Dim moveIndex = Convert.ToInt32(UnitData(2))
                If moveIndex > 0 Then
                    GameData_NaturePower_Name(index) = UnitData(1)
                    GameData_NaturePower_Index(index) = UnitData(2)
                    GameData_NaturePower_Index(0) = index
                End If
            End If
        End If
    End Sub

    Sub GameData_LineRead_RegisterSemiMoveBlackList(UnitData() As String)
        If UnitData.Length = 2 Then
            Dim effectIndex = Convert.ToInt32(UnitData(1))
            If effectIndex < SemiMove_BlackList.Length Then
                If effectIndex > 0 Then
                    SemiMove_BlackList(effectIndex) = 1
                End If
            End If
        End If
    End Sub

    Sub GameData_LineRead_RegisterMoveBlackList(UnitData() As String)
        If UnitData.Length = 2 Then
            Dim moveIndex = Convert.ToInt32(UnitData(1))
            If moveIndex < MoveIndex_BlackList.Length Then
                If moveIndex > 0 Then
                    MoveIndex_BlackList(moveIndex) = 1
                End If
            End If
        End If
    End Sub
    Sub GameData_LineRead_RegisterAnimData(UnitData() As String)
        If UnitData.Length > 3 Then

            Dim Typing = -1
            Dim Bracket = -1
            Dim Address = -1
            Dim Flags = 0

            Dim index = 1
            Do Until index + 1 > UnitData.Length
                Select Case UnitData(index)
                    Case "Normal"
                        Typing = 0
                    Case "Fighting"
                        Typing = 1
                    Case "Flying"
                        Typing = 2
                    Case "Poison"
                        Typing = 3
                    Case "Ground"
                        Typing = 4
                    Case "Rock"
                        Typing = 5
                    Case "Bug"
                        Typing = 6
                    Case "Ghost"
                        Typing = 7
                    Case "Steel"
                        Typing = 8
                    Case "Fire"
                        Typing = 10
                    Case "Water"
                        Typing = 11
                    Case "Grass"
                        Typing = 12
                    Case "Electric"
                        Typing = 13
                    Case "Psychic"
                        Typing = 14
                    Case "Ice"
                        Typing = 15
                    Case "Dragon"
                        Typing = 16
                    Case "Dark"
                        Typing = 17
                    Case "Low"
                        Bracket = 0
                    Case "Mid"
                        Bracket = 1
                    Case "High"
                        Bracket = 2
                    Case "Buff"
                        Bracket = 3
                    Case "Debuff"
                        Bracket = 4
                    Case "Long"
                        Flags = TryAddFlags(Flags, AnimFlags.IsLong)
                    Case "AnimAdress"
                        Address = Convert.ToInt32(UnitData(index + 1), 16)
                        index += 1
                End Select
                index += 1
            Loop
            If Typing > -1 And Bracket > -1 And Address > 0 Then
                index = GameData_AnimAddress(0, 0) + 1
                If index < 1000 Then
                    GameData_AnimAddress(0, 0) += 1
                    GameData_AnimAddress(index, AnimationDataIndex.AnimAdress) = Address
                    GameData_AnimAddress(index, AnimationDataIndex.Type) = Typing
                    GameData_AnimAddress(index, AnimationDataIndex.Bracket) = Bracket
                    GameData_AnimAddress(index, AnimationDataIndex.AnimFlags) = Flags
                    'MessageBox.Show("Animation #" & Address & " registered to Type " & Typing & " Bracket " & Bracket & " at Index " & index, "RegisterAnimData")
                End If
            End If
        End If
    End Sub
    Sub GameData_LineRead_RegisterEffectData(UnitData() As String)
        If UnitData.Length > 1 Then
            Dim EffectIndex = Convert.ToInt32(UnitData(1))
            Dim Priority = 0
            Dim ForcedTarget = -1
            Dim IgnoreFlags = 0
            Dim BaseFlags = -1
            Dim Category = -1
            Dim UsePower = True
            Dim UseAccuracy = True
            Dim FixedPower = -1
            Dim UseEffectChance = False
            Dim MaxPower = 51
            Dim MaxAccuracy = 20
            Dim Limited = 0
            Dim FixedEffectChance = 0
            Dim BonusPoints = 0
            Dim DescAddress = -1
            Dim ForcedAnim = -1
            Dim DescLog = ""
            Dim EffectFlags = 0

            Dim index = 2
            Do Until index + 1 > UnitData.Length
                Select Case UnitData(index)
                    Case "UsePower"
                        If UnitData(index + 1) = "False" Then
                            UsePower = False
                        End If
                    Case "UseAccuracy"
                        If UnitData(index + 1) = "False" Then
                            UseAccuracy = False
                        End If
                    Case "UseEffectChance"
                        If UnitData(index + 1) = "True" Then
                            UseEffectChance = True
                        End If
                    Case "FixedPower"
                        FixedPower = Convert.ToInt32(UnitData(index + 1))
                        If FixedPower > 255 Then
                            FixedPower = 255
                        End If
                    Case "Category"
                        Select Case UnitData(index + 1)
                            Case "Physical"
                                Category = 0
                            Case "Special"
                                Category = 1
                            Case "Status"
                                Category = 2
                        End Select
                    Case "MaxPower"
                        MaxPower = Convert.ToInt32(UnitData(index + 1))
                    Case "MaxAccuracy"
                        MaxAccuracy = Convert.ToInt32(UnitData(index + 1))
                    Case "Priority"
                        Priority = Convert.ToInt32(UnitData(index + 1))
                    Case "BaseFlags"
                        BaseFlags = Convert.ToInt32(UnitData(index + 1))
                    Case "IgnoreFlags"
                        IgnoreFlags = Convert.ToInt32(UnitData(index + 1))
                    Case "ForcedTarget"
                        ForcedTarget = Convert.ToInt32(UnitData(index + 1))
                    Case "Limited"
                        Limited = Convert.ToInt32(UnitData(index + 1))
                    Case "EffectFlags"
                        EffectFlags = Convert.ToInt32(UnitData(index + 1))
                    Case "FixedEffectChance"
                        FixedEffectChance = Convert.ToInt32(UnitData(index + 1))
                    Case "BonusPoints"
                        BonusPoints = Convert.ToInt32(UnitData(index + 1))
                    Case "DescAddress"
                        DescAddress = Convert.ToInt32(UnitData(index + 1), 16)
                    Case "ForcedAnim"
                        ForcedAnim = Convert.ToInt32(UnitData(index + 1), 16)
                    Case "DescLog"
                        DescLog = UnitData(index + 1)
                End Select
                index += 2
            Loop

            If EffectIndex > -1 Then
                index = GameData_Effects(0, 0) + 1
                If index < 256 Then
                    GameData_Effects(0, 0) = index
                    GameData_Effects(index, EffectDataIndex.EffectIndex) = EffectIndex
                    GameData_Effects(index, EffectDataIndex.UsePower) = UsePower
                    GameData_Effects(index, EffectDataIndex.UseAccuracy) = UseAccuracy
                    GameData_Effects(index, EffectDataIndex.UseEffectChance) = UseEffectChance
                    GameData_Effects(index, EffectDataIndex.FixedPower) = FixedPower
                    GameData_Effects(index, EffectDataIndex.MaxPower) = MaxPower
                    GameData_Effects(index, EffectDataIndex.MaxAccuracy) = MaxAccuracy
                    GameData_Effects(index, EffectDataIndex.Category) = Category
                    GameData_Effects(index, EffectDataIndex.Priority) = Priority
                    GameData_Effects(index, EffectDataIndex.BaseFlags) = BaseFlags
                    GameData_Effects(index, EffectDataIndex.IgnoreFlags) = IgnoreFlags
                    GameData_Effects(index, EffectDataIndex.ForcedTarget) = ForcedTarget
                    GameData_Effects(index, EffectDataIndex.Limited) = Limited
                    GameData_Effects(index, EffectDataIndex.FixedEffectChance) = FixedEffectChance
                    GameData_Effects(index, EffectDataIndex.BonusPoints) = BonusPoints
                    GameData_Effects(index, EffectDataIndex.EffectFlags) = EffectFlags
                    GameData_Effects_Strings(index, 0) = DescAddress
                    GameData_Effects_Strings(index, 1) = ForcedAnim
                    GameData_Effects_Strings(index, 2) = DescLog
                    'MessageBox.Show("Effect #" & EffectIndex & " at Index " & index, "RegisterEffectData")
                End If
            End If
        End If
    End Sub
    Function SetupNameArray()
        Dim iteratorA = 0
        'Clean up the arrays.
        Do While iteratorA < 17
            FirstWordArray(iteratorA, 0) = 0
            iteratorA += 1
        Loop
        iteratorA = 0
        Do While iteratorA < 4
            Dim iteratorB = 0
            Do While iteratorB < 7
                SecondWordArray(iteratorA, iteratorB, 0) = 0
                iteratorB += 1
            Loop
            iteratorA += 1
        Loop
        'Check if all files are here
        If File.Exists(NameData_Type_Normal) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Fighting) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Flying) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Rock) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Ground) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Bug) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Ghost) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Steel) = False Then
            Return False
        End If

        If File.Exists(NameData_Type_Fire) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Water) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Grass) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Electric) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Ice) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Psychic) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Dragon) = False Then
            Return False
        End If
        If File.Exists(NameData_Type_Dark) = False Then
            Return False
        End If

        If File.Exists(NameData_Category_Physical) = False Then
            Return False
        End If
        If File.Exists(NameData_Category_Special) = False Then
            Return False
        End If
        If File.Exists(NameData_Category_Buff) = False Then
            Return False
        End If
        If File.Exists(NameData_Category_Debuff) = False Then
            Return False
        End If
        'Now start to build array
        BuildFirstWordArrayFromFile(NameData_Type_Normal, TypeIndex.Normal)
        BuildFirstWordArrayFromFile(NameData_Type_Fighting, TypeIndex.Fighting)
        BuildFirstWordArrayFromFile(NameData_Type_Flying, TypeIndex.Flying)
        BuildFirstWordArrayFromFile(NameData_Type_Poison, TypeIndex.Poison)
        BuildFirstWordArrayFromFile(NameData_Type_Ground, TypeIndex.Ground)
        BuildFirstWordArrayFromFile(NameData_Type_Rock, TypeIndex.Rock)
        BuildFirstWordArrayFromFile(NameData_Type_Bug, TypeIndex.Bug)
        BuildFirstWordArrayFromFile(NameData_Type_Ghost, TypeIndex.Ghost)
        BuildFirstWordArrayFromFile(NameData_Type_Steel, TypeIndex.Steel)

        BuildFirstWordArrayFromFile(NameData_Type_Fire, TypeIndex.Fire)
        BuildFirstWordArrayFromFile(NameData_Type_Water, TypeIndex.Water)
        BuildFirstWordArrayFromFile(NameData_Type_Grass, TypeIndex.Grass)
        BuildFirstWordArrayFromFile(NameData_Type_Electric, TypeIndex.Electric)
        BuildFirstWordArrayFromFile(NameData_Type_Psychic, TypeIndex.Psychic)
        BuildFirstWordArrayFromFile(NameData_Type_Ice, TypeIndex.Ice)
        BuildFirstWordArrayFromFile(NameData_Type_Dragon, TypeIndex.Dragon)
        BuildFirstWordArrayFromFile(NameData_Type_Dark, TypeIndex.Dark)
        'MessageBox.Show("First Word Array Built")
        BuildSecondWordArrayFromFile(NameData_Category_Physical, 0)
        BuildSecondWordArrayFromFile(NameData_Category_Special, 1)
        BuildSecondWordArrayFromFile(NameData_Category_Debuff, 2)
        BuildSecondWordArrayFromFile(NameData_Category_Buff, 3)
        'MessageBox.Show("Second Word Array Built")
        Return True
    End Function
    Sub BuildFirstWordArrayFromFile(TargetFile As String, index As Integer)
        Dim LineData As String
        Dim streamReader As StreamReader
        streamReader = File.OpenText(TargetFile)
        LineData = streamReader.ReadLine()
        Dim maxIndex = 0
        Do Until maxIndex >= MaxWordEntries Or LineData Is Nothing
            maxIndex += 1
            FirstWordArray(index, maxIndex) = LineData
            LineData = streamReader.ReadLine()
        Loop
        streamReader.Close()
        FirstWordArray(index, 0) = maxIndex
        If maxIndex < 0 Then
            MessageBox.Show("Zero name entries found for: " & TypeToString(index) & ".txt", "Warning")
        End If
    End Sub

    Sub BuildSecondWordArrayFromFile(TargetFile As String, index As Integer)
        Dim LineData As String
        Dim streamReader As StreamReader
        streamReader = File.OpenText(TargetFile)
        LineData = streamReader.ReadLine()
        Dim maxIndex(MaxSecondWordLength)
        Do Until LineData Is Nothing
            Dim wordLength = LineData.Length
            If wordLength < MaxSecondWordLength Then
                Dim nextIndex = maxIndex(wordLength) + 1
                If nextIndex < MaxWordEntries Then
                    maxIndex(wordLength) += 1
                    SecondWordArray(index, wordLength, maxIndex(wordLength)) = LineData
                    SecondWordArray(index, wordLength, 0) = maxIndex(wordLength)
                End If
            End If
            LineData = streamReader.ReadLine()
        Loop
        streamReader.Close()
    End Sub
    Sub AnimateMove(ByVal dataIndex As Integer, ByVal moveIndex As Integer, ByVal Power As Integer, ByVal Typing As Integer, ByVal Category As Integer, ByVal ForcedTarget As Integer, ByVal ThisEffectFlags As Integer)
        If dataIndex > 0 Then
            Dim writeLocation = GameData_AnimTable_StartAddress + (GameData_AnimLength * moveIndex)
            Dim writeValue As Integer = GameData_Effects_Strings(dataIndex, 1)
            If writeValue < 0 Then
                Dim Bracket = 0
                Dim OnlyFlags = 0
                If checkbox_rnd_anim_context.Checked Then
                    If Category > 1 Then
                        Bracket = 4
                        If ForcedTarget And TargetFlags.User Then
                            Bracket = 3
                        End If
                    Else
                        If Power >= 100 Then
                            Bracket = 2
                        ElseIf Power <= 1 Or Power >= 60 Then
                            Bracket = 1
                        End If
                    End If
                Else
                    Bracket = RandomRange(0, 4)
                    Typing = RngTypeArray(RandomRange(0, RngTypeArray.Length))
                End If
                If ValueHasFlag(ThisEffectFlags, EffectFlags.MultiHit) Then
                    OnlyFlags = TryAddFlags(OnlyFlags, AnimFlags.IsLong)
                    Bracket = 0
                    'MessageBox.Show("Has Multi: " & OnlyFlags)
                End If
                Dim animIndex = RollAnimation(Typing, Bracket, OnlyFlags)
                If animIndex > 0 Then
                    writeValue = GameData_AnimAddress(animIndex, AnimationDataIndex.AnimAdress)
                End If
            End If
            If writeValue > 0 Then
                br.BaseStream.Seek(writeLocation, SeekOrigin.Begin)
                bw.Write(writeValue)
            End If
        End If
    End Sub
    Sub ChangeDesc(ByVal index As Integer, ByVal descAddress As String)
        Dim writeValue As Integer = descAddress
        If writeValue > 0 Then
            Dim writeLocation = GameData_DescTable_StartAddress + (GameData_DescLength * index)
            Dim b() As Byte = BitConverter.GetBytes(writeValue)
            writeValue = BitConverter.ToInt32(b, 0)
            br.BaseStream.Seek(writeLocation, SeekOrigin.Begin)
            bw.Write(writeValue)
        End If
    End Sub
    Function CreateMoveName(Typing As Integer, Category As Integer, ForcedTarget As Integer)
        Dim ErrorName = "ERRORNAME"
        Dim newName = "ERRORNAME"
        Dim maxNameLength = GameData_NameLength - 1
        If checkbox_rnd_name_context.Checked Then
            If Category > 1 Then
                If ForcedTarget And TargetFlags.User Then
                    Category = 3
                End If
            End If
        Else
            Typing = RngTypeArray(RandomRange(0, RngTypeArray.Length))
            Category = RandomRange(0, 3)
        End If
        Dim maxRange = FirstWordArray(Typing, 0)
        If maxRange > 0 Then
            newName = FirstWordArray(Typing, RandomRange(1, maxRange))
            Dim charsLeft = Math.Max(0, maxNameLength - newName.Length)
            charsLeft = Math.Min(charsLeft, MaxSecondWordLength - 1)
            If charsLeft > 0 Then
                Dim validArray(charsLeft)
                Dim i = 1
                'Get an array of as many usable words as possible
                Do While i < validArray.Length
                    maxRange = SecondWordArray(Category, i, 0)
                    If maxRange > 0 Then
                        validArray(0) += 1
                        validArray(validArray(0)) = i
                    End If
                    i += 1
                Loop
                'Now try to give it a second word
                Dim attempts = 5
                Do While attempts > 0
                    attempts -= 1
                    Dim chosenLength = validArray(RandomRange(1, validArray(0)))
                    maxRange = SecondWordArray(Category, chosenLength, 0)
                    If maxRange > 0 Then
                        Dim secondWord = SecondWordArray(Category, chosenLength, RandomRange(1, maxRange))
                        'try again if it's the same as the first word
                        If secondWord <> newName Then
                            newName += secondWord
                            Exit Do
                        End If
                    End If
                Loop
            End If
        Else
            Return ErrorName
        End If
        If newName.Length > GameData_NameLength - 1 Then
            Return ErrorName
        End If
        Return newName
    End Function
    Sub ChangeMoveName(nameString As String, moveIndex As Integer)
        If nameString.Length > GameData_NameLength - 1 Then
            nameString = "ERRORNAME"
        End If
        Dim writeLocation = GameData_NameTable_StartAddress + (GameData_NameLength * moveIndex)
        Dim writeValue As Byte
        Dim nameLength = nameString.Length
        Dim charIndex = 0
        Do While charIndex < GameData_NameLength
            writeValue = &H0
            If charIndex = nameLength Then
                writeValue = &HFF
            ElseIf charIndex > nameLength Then
                writeValue = &H0
            Else
                writeValue = CharacterToHex(nameString(charIndex))
            End If
            br.BaseStream.Seek(writeLocation, SeekOrigin.Begin)
            bw.Write(Convert.ToByte(writeValue))
            charIndex += 1
            writeLocation += 1
        Loop
    End Sub
    Function CharacterToHex(Character As Char)
        Select Case Character
            Case "-"
                Return &HAE
            Case "A"
                Return &HBB
            Case "B"
                Return &HBC
            Case "C"
                Return &HBD
            Case "D"
                Return &HBE
            Case "E"
                Return &HBF
            Case "F"
                Return &HC0
            Case "G"
                Return &HC1
            Case "H"
                Return &HC2
            Case "I"
                Return &HC3
            Case "J"
                Return &HC4
            Case "K"
                Return &HC5
            Case "L"
                Return &HC6
            Case "M"
                Return &HC7
            Case "N"
                Return &HC8
            Case "O"
                Return &HC9
            Case "P"
                Return &HCA
            Case "Q"
                Return &HCB
            Case "R"
                Return &HCC
            Case "S"
                Return &HCD
            Case "T"
                Return &HCE
            Case "U"
                Return &HCF
            Case "V"
                Return &HD0
            Case "W"
                Return &HD1
            Case "X"
                Return &HD2
            Case "Y"
                Return &HD3
            Case "Z"
                Return &HD4
            Case "a"
                Return &HD5
            Case "b"
                Return &HD6
            Case "c"
                Return &HD7
            Case "d"
                Return &HD8
            Case "e"
                Return &HD9
            Case "f"
                Return &HDA
            Case "g"
                Return &HDB
            Case "h"
                Return &HDC
            Case "i"
                Return &HDD
            Case "j"
                Return &HDE
            Case "k"
                Return &HDF
            Case "l"
                Return &HE0
            Case "m"
                Return &HE1
            Case "n"
                Return &HE2
            Case "o"
                Return &HE3
            Case "p"
                Return &HE4
            Case "q"
                Return &HE5
            Case "r"
                Return &HE6
            Case "s"
                Return &HE7
            Case "t"
                Return &HE8
            Case "u"
                Return &HE9
            Case "v"
                Return &HEA
            Case "w"
                Return &HEB
            Case "x"
                Return &HEC
            Case "y"
                Return &HED
            Case "z"
                Return &HEE
        End Select
        Return &H0 'This = " "
    End Function
    Sub ReadAttack(ByVal hexaddress As String)
        Dim Chars As Integer = 1
        Dim value As Byte
        MoveName = ""
        Do While (Chars <= 12)
            br.BaseStream.Seek(hexaddress, SeekOrigin.Begin)
            value = br.ReadByte()
            Select Case value
                Case &H0
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


    Private Sub rndpower_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkbox_rnd_power.CheckedChanged
        If checkbox_rnd_power.Checked = False Then
            checkbox_balance.Checked = False
        End If
    End Sub

    Private Sub rndaccurate_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkbox_rnd_accuracy.CheckedChanged
        If checkbox_rnd_accuracy.Checked = False Then
            checkbox_balance.Checked = False
            checkbox_mod_accuracy.Checked = False
        End If
    End Sub

    Private Sub rndpp_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkbox_rnd_pp.CheckedChanged
        If checkbox_rnd_pp.Checked = False Then
            checkbox_balance.Checked = False
        End If
    End Sub
    Private Sub checkbox_rnd_effect_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_rnd_effect.CheckedChanged
        If checkbox_rnd_effect.Checked = False Then
            checkbox_balance.Checked = False
            checkbox_limit_effects.Checked = False
            checkbox_mod_priority.Checked = False
        End If
    End Sub

    Private Sub balancestats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkbox_balance.CheckedChanged
        If checkbox_balance.Checked Then
            checkbox_rnd_power.Checked = True
            checkbox_rnd_accuracy.Checked = True
            checkbox_rnd_pp.Checked = True
            checkbox_rnd_effect.Checked = True
        End If
    End Sub

    Private Sub checkbox_limitstatus_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_limit_effects.CheckedChanged
        If checkbox_limit_effects.Checked Then
            checkbox_rnd_effect.Checked = True
        End If
    End Sub
    Private Sub checkbox_mod_priority_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_mod_priority.CheckedChanged
        If checkbox_mod_priority.Checked Then
            checkbox_rnd_effect.Checked = True
        End If
    End Sub

    Private Sub checkbox_mod_accuracy_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_mod_accuracy.CheckedChanged
        If checkbox_mod_accuracy.Checked Then
            checkbox_rnd_accuracy.Checked = True
        End If
    End Sub

    Private Sub lstboxgame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstboxgame.SelectedIndexChanged
        Select Case lstboxgame.Text
            Case "Unsupported"
                GameType = -1
            Case "Fire Red USA 1.0"
                GameType = 1
            Case "Emerald USA"
                GameType = 2
            Case Else
                GameType = 0
        End Select
    End Sub
    Function SeekMoveData(moveIndex As Integer, dataIndex As MoveDataIndex)
        Return CInt(GameData_MoveTable_StartAddress + (12 * moveIndex) + dataIndex)
    End Function
    Function RandomRange(minRange As Integer, maxRange As Integer)
        Return CInt(Math.Floor(((maxRange - minRange) + 1) * Rnd())) + minRange
    End Function
    Function TryAddFlags(currentFlags As Integer, addedFlag As Integer, Optional ignoredFlags As Integer = 0)
        If ValueHasFlag(ignoredFlags, addedFlag) Then
            Return currentFlags
        End If
        Return currentFlags Or addedFlag
    End Function

    Function ValueHasFlag(currentFlags As Integer, theFlag As Integer)
        Return (currentFlags And theFlag) = theFlag
    End Function

    Function CanModifyMove(moveIndex As Integer, effectIndex As Integer)
        If MoveIndex_BlackList(moveIndex) <> 0 Then
            Return False
        End If
        If SemiMove_BlackList(effectIndex) <> 0 Then
            Return False
        End If
        Return True
    End Function
    '
    Function TypeToString(typing As Integer)
        Dim returnString = "Error:NoType"
        Select Case typing
            Case TypeIndex.Normal
                returnString = "Normal"
            Case TypeIndex.Fighting
                returnString = "Fighting"
            Case TypeIndex.Flying
                returnString = "Flying"
            Case TypeIndex.Poison
                returnString = "Poison"
            Case TypeIndex.Ground
                returnString = "Ground"
            Case TypeIndex.Rock
                returnString = "Rock"
            Case TypeIndex.Bug
                returnString = "Bug"
            Case TypeIndex.Ghost
                returnString = "Ghost"
            Case TypeIndex.Steel
                returnString = "Steel"
            Case TypeIndex.Fire
                returnString = "Fire"
            Case TypeIndex.Water
                returnString = "Water"
            Case TypeIndex.Grass
                returnString = "Grass"
            Case TypeIndex.Electric
                returnString = "Electric"
            Case TypeIndex.Psychic
                returnString = "Psychic"
            Case TypeIndex.Ice
                returnString = "Ice"
            Case TypeIndex.Dragon
                returnString = "Dragon"
            Case TypeIndex.Dark
                returnString = "Dark"
            Case TypeIndex.Typeless
                returnString = "???"
        End Select
        Return returnString
    End Function
    Function ShouldMirrorMove(flags As Integer)
        If flags < 0 Then
            Return True
        End If
        If flags And TargetFlags.User Then
            Return False
        End If
        If flags And TargetFlags.Contextual Then
            Return False
        End If
        If flags And TargetFlags.Field Then
            Return False
        End If
        Return True
    End Function
    Function ShouldBypassAccuracy(flags As Integer)
        If flags < 0 Then
            Return False
        End If
        If flags And TargetFlags.User Then
            Return True
        End If
        If flags And TargetFlags.Field Then
            Return True
        End If
        Return False
    End Function
    Function GetNaturePower_ByMoveIndex(Moveindex As Integer)
        Dim i As Integer = 1
        Do Until i > GameData_NaturePower_Index(0)
            If GameData_NaturePower_Index(i) = Moveindex Then
                Return i
            End If
            i += 1
        Loop
        Return -1
    End Function

    Function InvestPoint_Tamper(method As Integer, weight As Integer)
        If weight < 1 Or method < 1 Then
            Return weight
        End If
        Select Case method
            Case 1
                weight -= Math.Ceiling(weight * 0.2)
            Case 2
                weight += Math.Ceiling(weight * 0.2)
        End Select
        Return weight
    End Function

    Function RollEffectData(TypeFilter As Integer, UsedEffects As Object)
        Dim returnIndex = 0
        Dim ValidEffectList(300)
        Dim iIndex = 1
        Do Until iIndex > GameData_Effects(0, 0)
            Dim isValid = True
            If checkbox_limit_effects.Checked Then
                Dim effectLimit = GameData_Effects(iIndex, EffectDataIndex.Limited)
                If effectLimit > 0 Then
                    If UsedEffects(TypeIndex.MaxTypes, iIndex) > 0 Or UsedEffects(TypeFilter, iIndex) > 0 Then
                        isValid = False
                    End If

                End If
            End If
            If checkbox_tweak_semi.Checked And ValueHasFlag(GameData_Effects(iIndex, EffectDataIndex.EffectFlags), EffectFlags.SemiMove) Then
                isValid = False
            End If
            If isValid Then
                ValidEffectList(0) += 1
                ValidEffectList(ValidEffectList(0)) = iIndex
            End If
            iIndex += 1
        Loop
        If ValidEffectList(0) > 0 Then
            returnIndex = ValidEffectList(RandomRange(1, ValidEffectList(0)))
        End If
        Return returnIndex
    End Function

    Function RollAnimation(TypeFilter As Integer, Bracket As Integer, OnlyFlag As Integer)
        Dim returnIndex = 0
        Dim ValidAnimList(1000)
        Dim iIndex = 1

        Do Until iIndex > GameData_AnimAddress(0, 0)
            Dim isValid = False
            If GameData_AnimAddress(iIndex, AnimationDataIndex.Type) = TypeFilter Then
                If GameData_AnimAddress(iIndex, AnimationDataIndex.Bracket) = Bracket Then
                    If OnlyFlag > 0 Then
                        If ValueHasFlag(GameData_AnimAddress(iIndex, AnimationDataIndex.AnimFlags), OnlyFlag) = False Then
                            isValid = True
                        End If
                    Else
                        isValid = True
                    End If
                End If
            End If

            If isValid Then
                ValidAnimList(0) += 1
                ValidAnimList(ValidAnimList(0)) = iIndex
            End If
            iIndex += 1
        Loop
        If ValidAnimList(0) > 0 Then
            returnIndex = ValidAnimList(RandomRange(1, ValidAnimList(0)))
        End If
        Return returnIndex
    End Function
    Private Sub checkbox_rnd_name_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_rnd_name.CheckedChanged
        If checkbox_rnd_name.Checked = False Then
            checkbox_rnd_name_context.Checked = False
        End If
    End Sub
    Private Sub checkbox_rnd_name_context_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_rnd_name_context.CheckedChanged
        If checkbox_rnd_name_context.Checked Then
            checkbox_rnd_name.Checked = True
        End If
    End Sub
    Private Sub checkbox_rnd_anim_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_rnd_anim.CheckedChanged
        If checkbox_rnd_anim.Checked = False Then
            checkbox_rnd_anim_context.Checked = False
        End If
    End Sub
    Private Sub checkbox_rnd_anim_context_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_rnd_anim_context.CheckedChanged
        If checkbox_rnd_anim_context.Checked Then
            checkbox_rnd_anim.Checked = True
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupPresetList(PresetData_Path)
        If lstboxgame.Items.Count < 2 Then
            MessageBox.Show("Unable to find any Preset Files, make sure to have the Preset Folder along with the appropriate files.", "Preset Error")
        End If
    End Sub

    Sub SetupPresetList(TargetFile)
        If File.Exists(TargetFile) Then
            lstboxgame.Items.Clear()
            lstboxgame.Items.Add("Unsupported")
            Dim LineData As String
            Dim streamReader As StreamReader
            streamReader = File.OpenText(TargetFile)
            LineData = streamReader.ReadLine()
            Do Until LineData Is Nothing
                If LineData <> "Unsupported" And File.Exists(GameData_Path & LineData & ".txt") Then
                    lstboxgame.Items.Add(LineData)
                End If
                LineData = streamReader.ReadLine()
            Loop
            streamReader.Close()
        End If
    End Sub
End Class
