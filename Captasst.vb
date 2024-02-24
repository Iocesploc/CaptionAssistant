Public Class Captasst
    Dim CaptionLines As List(Of CaptionLine)

    Dim TBCaption As TextBox()
    Dim CBSpacelessCaption As CheckBox()
    Dim CBShortDuration As CheckBox()
    Dim CBLongDuration As CheckBox()
    Dim CBAdjacentToPrevious As CheckBox()
    Dim CBAdjacentToNext As CheckBox()
    Dim LBDurationData As Label()
    Dim LBLengthData As Label()
    Dim LBMergeWithAbove As Label()
    Dim LBDelete As Label()
    Dim LBSplit As Label()
    Dim BtnStartTime As Button()
    Dim BtnEndTime As Button()

    Dim GFX As Graphics
    Dim NeedsSetup As Boolean

    Private Sub Captasst_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim LV As Integer
        If Not NeedsSetup Then
            For LV = 0 To 9
                RemoveHandler TBCaption(LV).TextChanged, AddressOf TBCaptionTextChanged
                RemoveHandler LBMergeWithAbove(LV).Click, AddressOf MergeWithAbove
                RemoveHandler LBDelete(LV).Click, AddressOf DeleteSubtitle
                RemoveHandler LBSplit(LV).MouseUp, AddressOf SplitSubtitle
                RemoveHandler BtnStartTime(LV).KeyPress, AddressOf StartTimeAdjust
                RemoveHandler BtnEndTime(LV).KeyPress, AddressOf EndTimeAdjust
            Next
        End If
    End Sub

    Private Sub LoadUp(Filename As String)
        Dim Alltext As String
        Dim Allcaptions As String()
        Dim LV As Integer
        Dim Splitter As String = vbNewLine & vbNewLine

        Alltext = System.IO.File.ReadAllText(Filename)
        Alltext = Alltext.Replace(Splitter, "ÿ")
        Allcaptions = Alltext.Substring(0, Alltext.Length - 2).Split("ÿ")  'two newlines back 2 back.

        For LV = 0 To Allcaptions.GetUpperBound(0)
            CaptionLines.Add(New CaptionLine(Allcaptions(LV)))
        Next


        Label2.Text = "Loaded " & CaptionLines.Count & " captions."

        If NeedsSetup Then


            For LV = 0 To 9
                TBCaption(LV) = New TextBox
                TBCaption(LV).Multiline = True
                TBCaption(LV).SetBounds(12, 84 + 72 * LV, 264, 64)
                TBCaption(LV).Visible = True
                TBCaption(LV).Tag = LV
                AddHandler TBCaption(LV).TextChanged, AddressOf TBCaptionTextChanged
                Me.Controls.Add(TBCaption(LV))

                CBSpacelessCaption(LV) = New CheckBox
                CBSpacelessCaption(LV).Enabled = False
                CBSpacelessCaption(LV).SetBounds(282, 84 + 72 * LV, 64, 21)
                CBSpacelessCaption(LV).Visible = True
                CBSpacelessCaption(LV).Text = "Word"
                CBSpacelessCaption(LV).Appearance = Appearance.Button
                CBSpacelessCaption(LV).ForeColor = Color.Red
                Me.Controls.Add(CBSpacelessCaption(LV))

                CBShortDuration(LV) = New CheckBox
                CBShortDuration(LV).Enabled = False
                CBShortDuration(LV).SetBounds(282, 100 + 72 * LV, 64, 21)
                CBShortDuration(LV).Visible = True
                CBShortDuration(LV).Text = "Short"
                CBShortDuration(LV).Appearance = Appearance.Button
                CBShortDuration(LV).ForeColor = Color.Green
                Me.Controls.Add(CBShortDuration(LV))

                CBLongDuration(LV) = New CheckBox
                CBLongDuration(LV).Enabled = False
                CBLongDuration(LV).SetBounds(282, 116 + 72 * LV, 64, 21)
                CBLongDuration(LV).Visible = True
                CBLongDuration(LV).Text = "Long"
                CBLongDuration(LV).Appearance = Appearance.Button
                CBLongDuration(LV).ForeColor = Color.LightBlue
                Me.Controls.Add(CBLongDuration(LV))

                CBAdjacentToPrevious(LV) = New CheckBox
                CBAdjacentToPrevious(LV).Enabled = False
                CBAdjacentToPrevious(LV).SetBounds(346, 84 + 72 * LV, 64, 21)
                CBAdjacentToPrevious(LV).Visible = True
                CBAdjacentToPrevious(LV).Text = "Above"
                CBAdjacentToPrevious(LV).Appearance = Appearance.Button
                CBAdjacentToPrevious(LV).ForeColor = Color.DarkGoldenrod
                Me.Controls.Add(CBAdjacentToPrevious(LV))


                CBAdjacentToNext(LV) = New CheckBox
                CBAdjacentToNext(LV).Enabled = False
                CBAdjacentToNext(LV).SetBounds(346, 116 + 72 * LV, 64, 21)
                CBAdjacentToNext(LV).Visible = True
                CBAdjacentToNext(LV).Text = "Below"
                CBAdjacentToNext(LV).Appearance = Appearance.Button
                CBAdjacentToNext(LV).ForeColor = Color.DarkGoldenrod
                Me.Controls.Add(CBAdjacentToNext(LV))


                LBDurationData(LV) = New Label
                LBDurationData(LV).Text = "-"
                LBDurationData(LV).SetBounds(412, 84 + 72 * LV, 50, 17)
                LBDurationData(LV).AutoSize = True
                LBDurationData(LV).Visible = True
                Me.Controls.Add(LBDurationData(LV))

                LBLengthData(LV) = New Label
                LBLengthData(LV).Text = "-"
                LBLengthData(LV).SetBounds(412, 116 + 72 * LV, 50, 17)
                LBLengthData(LV).AutoSize = True
                LBLengthData(LV).Visible = True
                Me.Controls.Add(LBLengthData(LV))

                LBMergeWithAbove(LV) = New Label
                LBMergeWithAbove(LV).Text = "Merge with Above^"
                LBMergeWithAbove(LV).SetBounds(620, 84 + 72 * LV, 150, 17)
                LBMergeWithAbove(LV).BorderStyle = BorderStyle.FixedSingle
                LBMergeWithAbove(LV).Visible = True
                LBMergeWithAbove(LV).Tag = LV
                AddHandler LBMergeWithAbove(LV).Click, AddressOf MergeWithAbove
                Me.Controls.Add(LBMergeWithAbove(LV))

                LBDelete(LV) = New Label
                LBDelete(LV).Text = "Delete<"
                LBDelete(LV).SetBounds(620, 101 + 72 * LV, 150, 17)
                LBDelete(LV).BorderStyle = BorderStyle.FixedSingle
                LBDelete(LV).Visible = True
                LBDelete(LV).Tag = LV
                AddHandler LBDelete(LV).Click, AddressOf DeleteSubtitle
                Me.Controls.Add(LBDelete(LV))

                LBSplit(LV) = New Label
                LBSplit(LV).Text = "Spl/it"
                LBSplit(LV).SetBounds(620, 118 + 72 * LV, 150, 17)
                LBSplit(LV).BorderStyle = BorderStyle.FixedSingle
                LBSplit(LV).Visible = True
                LBSplit(LV).Tag = LV
                AddHandler LBSplit(LV).MouseUp, AddressOf SplitSubtitle
                Me.Controls.Add(LBSplit(LV))

                BtnStartTime(LV) = New Button
                BtnStartTime(LV).Text = "Unset"
                BtnStartTime(LV).SetBounds(780, 84 + 72 * LV, 120, 25)
                BtnStartTime(LV).Tag = LV
                BtnStartTime(LV).Visible = True
                AddHandler BtnStartTime(LV).KeyPress, AddressOf StartTimeAdjust
                Me.Controls.Add(BtnStartTime(LV))

                BtnEndTime(LV) = New Button
                BtnEndTime(LV).Text = "Unset"
                BtnEndTime(LV).SetBounds(780, 109 + 72 * LV, 120, 25)
                BtnEndTime(LV).Tag = LV
                BtnEndTime(LV).Visible = True
                AddHandler BtnEndTime(LV).KeyPress, AddressOf EndTimeAdjust
                Me.Controls.Add(BtnEndTime(LV))
            Next

            GFX = PB.CreateGraphics
            NeedsSetup = False

        End If

        Button2.Enabled = True 'Allow saving
        NUD.Enabled = True 'Allow the subtitles to scroll.
        PB.Enabled = True 'Allow the subtitles to scroll.

        NUD.Maximum = CaptionLines.Count - 10
        NUD.Minimum = 0
        NUD.Value = 0
        NUD_ValueChanged(Me, Nothing)

    End Sub

    Private Sub Captasst_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CaptionLines = New List(Of CaptionLine)

        TBCaption = New TextBox(9) {}
        CBSpacelessCaption = New CheckBox(9) {}
        CBShortDuration = New CheckBox(9) {}
        CBLongDuration = New CheckBox(9) {}
        CBAdjacentToPrevious = New CheckBox(9) {}
        CBAdjacentToNext = New CheckBox(9) {}
        LBDurationData = New Label(9) {}
        LBLengthData = New Label(9) {}
        LBMergeWithAbove = New Label(9) {}
        LBDelete = New Label(9) {}
        LBSplit = New Label(9) {}
        BtnStartTime = New Button(9) {}
        BtnEndTime = New Button(9) {}

        NeedsSetup = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadUp(OFD.FileName)
        End If


    End Sub

    Private Sub StartTimeAdjust(Sender As Object, E As KeyPressEventArgs)
        Dim Idx As Integer
        Dim SenderBtn As Button = Sender
        Dim CST As CaptionLine

        Idx = SenderBtn.Tag + NUD.Value
        CST = CaptionLines(Idx)
        Select Case E.KeyChar
            Case "1"c
                CST.StartTime = CST.StartTime.AddSeconds(-4)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "2"c
                CST.StartTime = CST.StartTime.AddSeconds(-1)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "3"c
                CST.StartTime = CST.StartTime.AddMilliseconds(-250)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "4"c
                CST.StartTime = CST.StartTime.AddMilliseconds(-100)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "5"c
                CST.StartTime = CST.StartTime.AddMilliseconds(-10)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "6"c
                CST.StartTime = CST.StartTime.AddMilliseconds(+10)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "7"c
                CST.StartTime = CST.StartTime.AddMilliseconds(+100)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "8"c
                CST.StartTime = CST.StartTime.AddMilliseconds(+250)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "9"c
                CST.StartTime = CST.StartTime.AddSeconds(+1)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "0"c
                CST.StartTime = CST.StartTime.AddSeconds(+4)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case Else
                Beep()
        End Select
    End Sub
    Private Sub EndTimeAdjust(Sender As Object, E As KeyPressEventArgs)
        Dim Idx As Integer
        Dim SenderBtn As Button = Sender
        Dim CST As CaptionLine

        Idx = SenderBtn.Tag + NUD.Value
        CST = CaptionLines(Idx)
        Select Case E.KeyChar
            Case "1"c
                CST.EndTime = CST.EndTime.AddSeconds(-4)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "2"c
                CST.EndTime = CST.EndTime.AddSeconds(-1)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "3"c
                CST.EndTime = CST.EndTime.AddMilliseconds(-250)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "4"c
                CST.EndTime = CST.EndTime.AddMilliseconds(-100)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "5"c
                CST.EndTime = CST.EndTime.AddMilliseconds(-10)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "6"c
                CST.EndTime = CST.EndTime.AddMilliseconds(+10)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "7"c
                CST.EndTime = CST.EndTime.AddMilliseconds(+100)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "8"c
                CST.EndTime = CST.EndTime.AddMilliseconds(+250)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "9"c
                CST.EndTime = CST.EndTime.AddSeconds(+1)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case "0"c
                CST.EndTime = CST.EndTime.AddSeconds(+4)
                CaptionLines(Idx) = CST
                NUD_ValueChanged(Sender, E)
            Case Else
                Beep()
        End Select
    End Sub

    Private Sub MergeWithAbove(Sender As Object, E As EventArgs)
        Dim Idx As Integer
        Dim SenderLabel As Label = Sender
        Dim LHS, RHS, Sum As CaptionLine

        Idx = SenderLabel.Tag + NUD.Value
        If Idx > 0 Then
            LHS = CaptionLines(Idx - 1)
            RHS = CaptionLines(Idx)
            Sum.Caption = String.Format("{0} {1}", LHS.Caption, RHS.Caption)
            Sum.StartTime = LHS.StartTime
            Sum.EndTime = RHS.EndTime
            CaptionLines.RemoveAt(Idx - 1)
            CaptionLines.RemoveAt(Idx - 1)
            CaptionLines.Insert(Idx - 1, Sum)
            NUD.Maximum = NUD.Maximum - 1
            If NUD.Value > NUD.Maximum Then
                NUD.Value = NUD.Maximum
            End If
            NUD_ValueChanged(Sender, E)
        End If
    End Sub
    Private Sub DeleteSubtitle(Sender As Object, E As EventArgs)
        Dim Idx As Integer
        Dim SenderLabel As Label = Sender

        Idx = SenderLabel.Tag + NUD.Value

        CaptionLines.RemoveAt(Idx)
        NUD.Maximum = NUD.Maximum - 1
        If NUD.Value > NUD.Maximum Then
            NUD.Value = NUD.Maximum
        End If
        NUD_ValueChanged(Sender, E)
    End Sub
    Private Sub SplitSubtitle(Sender As Object, E As MouseEventArgs)
        Dim Idx As Integer
        Dim SenderLabel As Label = Sender
        Dim AssocTxtbox As TextBox
        Dim Subtxt1, Subtxt2 As String
        Dim Fraction As Single
        Dim SplitPoint As DateTime
        Dim LHS, RHS As CaptionLine

        Idx = SenderLabel.Tag + NUD.Value
        AssocTxtbox = TBCaption(SenderLabel.Tag)

        Subtxt1 = AssocTxtbox.Text.Substring(0, AssocTxtbox.SelectionStart)
        Subtxt2 = AssocTxtbox.Text.Substring(AssocTxtbox.SelectionStart)

        Fraction = E.X / SenderLabel.Width
        SplitPoint = CaptionLines(Idx).StartTime.AddMilliseconds(CaptionLines(Idx).Duration.TotalMilliseconds * Fraction)

        LHS.StartTime = CaptionLines(Idx).StartTime
        LHS.EndTime = SplitPoint
        LHS.Caption = Subtxt1.Trim
        RHS.StartTime = SplitPoint
        RHS.EndTime = CaptionLines(Idx).EndTime
        RHS.Caption = Subtxt2.Trim

        CaptionLines.RemoveAt(Idx)
        CaptionLines.Insert(Idx, RHS)
        CaptionLines.Insert(Idx, LHS)

        NUD.Maximum = NUD.Maximum + 1
        NUD_ValueChanged(Sender, E)
    End Sub

    Private Sub NUD_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NUD.ValueChanged
        Dim LV As Integer
        Dim R As Rectangle
        For LV = 0 To 9
            TBCaption(LV).Text = CaptionLines(NUD.Value + LV).Caption
            CBSpacelessCaption(LV).Checked = CaptionLines(NUD.Value + LV).HasNoSpaces
            If CBSpacelessCaption(LV).Checked Then
                CBSpacelessCaption(LV).BackColor = Color.Red
            Else
                CBSpacelessCaption(LV).BackColor = Color.LightGray
            End If
            CBShortDuration(LV).Checked = CaptionLines(NUD.Value + LV).DurationShorterThan(NUDMinimum.Value)
            If CBShortDuration(LV).Checked Then
                CBShortDuration(LV).BackColor = Color.Green
            Else
                CBShortDuration(LV).BackColor = Color.LightGray
            End If
            CBLongDuration(LV).Checked = CaptionLines(NUD.Value + LV).DurationLongerThan(NUDMaximum.Value)
            If CBLongDuration(LV).Checked Then
                CBLongDuration(LV).BackColor = Color.Blue
            Else
                CBLongDuration(LV).BackColor = Color.LightGray
            End If
            If NUD.Value + LV > 0 Then
                If (CaptionLines(NUD.Value + LV).StartTime < CaptionLines(NUD.Value + LV - 1).EndTime) Then
                    CBAdjacentToPrevious(LV).BackColor = Color.DarkGoldenrod
                    CBAdjacentToPrevious(LV).Checked = True
                ElseIf (CaptionLines(NUD.Value + LV).StartTime = CaptionLines(NUD.Value + LV - 1).EndTime) Then
                    CBAdjacentToPrevious(LV).BackColor = Color.SkyBlue
                    CBAdjacentToPrevious(LV).Checked = True
                Else
                    CBAdjacentToPrevious(LV).BackColor = Color.LightGray
                    CBAdjacentToPrevious(LV).Checked = False
                End If
            Else
                CBAdjacentToPrevious(LV).BackColor = Color.LightGray
                CBAdjacentToPrevious(LV).Checked = False
            End If

            If NUD.Value + LV + 1 < CaptionLines.Count Then
                If (CaptionLines(NUD.Value + LV).EndTime > CaptionLines(NUD.Value + LV + 1).StartTime) Then
                    CBAdjacentToNext(LV).BackColor = Color.DarkGoldenrod
                    CBAdjacentToNext(LV).Checked = True
                ElseIf (CaptionLines(NUD.Value + LV).EndTime = CaptionLines(NUD.Value + LV + 1).StartTime) Then
                    CBAdjacentToNext(LV).BackColor = Color.SkyBlue
                    CBAdjacentToNext(LV).Checked = True
                Else
                    CBAdjacentToNext(LV).BackColor = Color.LightGray
                    CBAdjacentToNext(LV).Checked = False
                End If
            Else
                CBAdjacentToNext(LV).BackColor = Color.LightGray
                CBAdjacentToNext(LV).Checked = False
            End If
            LBDurationData(LV).Text = CaptionLines(NUD.Value + LV).ToString1("Interval", Nothing)
            LBLengthData(LV).Text = CaptionLines(NUD.Value + LV).ToString1("AllLength", Nothing)
            BtnStartTime(LV).Text = CaptionLines(NUD.Value + LV).StartTime.ToString("H:mm:ss.fff")
            BtnEndTime(LV).Text = CaptionLines(NUD.Value + LV).EndTime.ToString("H:mm:ss.fff")

        Next

        R = PB.ClientRectangle
        GFX.FillRectangle(Brushes.DarkGray, Rectangle.FromLTRB(0, 0, 18, R.Height))
        R = Rectangle.FromLTRB(0, NUD.Value * R.Height \ CaptionLines.Count, R.Width, (NUD.Value + 10) * R.Height \ CaptionLines.Count)
        GFX.FillRectangle(Brushes.LightGray, R)
        GFX.DrawRectangle(Pens.Black, R)

        Label1.Text = String.Format("Showing {0} to {1} of {2}.", NUD.Value + 1, NUD.Value + 10, CaptionLines.Count)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim LV As Integer
        Dim SB As System.Text.StringBuilder
        Dim SR As System.IO.StreamWriter

        Me.Cursor = Cursors.WaitCursor

        SFD.FileName = OFD.FileName
        If SFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SB = New System.Text.StringBuilder
            For LV = 0 To CaptionLines.Count - 2

                SB.AppendLine(CaptionLines(LV).ToString1("Out", Nothing))

            Next
            SB.Append(CaptionLines(LV).ToString1("Out", Nothing))

            SR = New System.IO.StreamWriter(SFD.FileName)
            SR.Write(SB.ToString)
            SR.Close()

            Label2.Text = "Saved " & CaptionLines.Count & " captions."

            'System.IO.File.WriteAllText(SFD.FileName, SB.ToString())
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TBCaptionTextChanged(sender As System.Object, e As System.EventArgs)
        Dim TB As TextBox
        Dim Idx As Integer
        Dim CL As CaptionLine

        TB = sender

        Idx = TB.Tag + NUD.Value

        CL = CaptionLines(Idx)
        CL.Caption = TB.Text.Trim
        CaptionLines(Idx) = CL

    End Sub


    Private Sub PB_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB.MouseUp
        Dim V As Integer

        V = NUD.Maximum * (e.Y / PB.ClientSize.Height)
        NUD.Value = V
    End Sub

    Private Sub Captasst_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim L As Integer
        Dim Filename As String
        L = Environment.CommandLine.IndexOf(""" """)
        If L >= 0 Then
            Me.Text = Environment.CommandLine
            Filename = Environment.CommandLine.Substring(L + 3).Replace("""", "")  'remove quotes from the filename.
            MessageBox.Show(Environment.CommandLine)
            MessageBox.Show(Filename)
            LoadUp(Filename)
        End If
    End Sub

    Private Sub BtnI_Click(sender As System.Object, e As System.EventArgs) Handles BtnI.Click
        Dim LV As Integer
        Dim Linedata As CaptionLine

        For LV = 0 To CaptionLines.Count - 1
            Linedata = CaptionLines(LV)
            Linedata.Caption = Linedata.Caption.Replace(" i ", " I ")
            Linedata.Caption = Linedata.Caption.Replace(" i'm ", " I'm ")
            Linedata.Caption = Linedata.Caption.Replace(" i'd ", " I'd ")
            Linedata.Caption = Linedata.Caption.Replace(" i've ", " I've ")
            CaptionLines(LV) = Linedata
        Next

        NUD_ValueChanged(Me, e)
    End Sub

    Private Sub BtnCaps_Click(sender As System.Object, e As System.EventArgs) Handles BtnCaps.Click
        Dim LV, ILV As Integer
        Dim Linedata As CaptionLine
        Dim PeriodLoc As Integer = 0
        Dim AfterPeriod As String
        Dim Done As Boolean

        For LV = 0 To CaptionLines.Count - 1
            Linedata = CaptionLines(LV)
            Linedata.Caption = Linedata.Caption.Substring(0, 1).ToUpperInvariant & Linedata.Caption.Substring(1)

            PeriodLoc = Linedata.Caption.IndexOfAny("!?.", PeriodLoc + 1)
            Do Until PeriodLoc = -1
                AfterPeriod = Linedata.Caption.Substring(PeriodLoc + 1)

                ILV = 0
                Done = False
                Do Until Done OrElse ILV >= AfterPeriod.Length
                    If AscW(AfterPeriod.Chars(ILV)) > 32 Then
                        Done = True
                    End If
                    ILV += 1
                Loop
                If Done Then
                    AfterPeriod = AfterPeriod.Substring(0, ILV - 1) & AfterPeriod.Substring(ILV - 1, 1).ToUpperInvariant & AfterPeriod.Substring(ILV)

                    Linedata.Caption = Linedata.Caption.Substring(0, PeriodLoc + 1) & AfterPeriod

                End If
                PeriodLoc = Linedata.Caption.IndexOfAny("!?.", PeriodLoc + 1)
            Loop
            CaptionLines(LV) = Linedata
        Next

        NUD_ValueChanged(Me, e)
    End Sub
End Class

Public Structure CaptionLine
    Implements IFormattable


    Public StartTime As DateTime
    Public EndTime As DateTime

    Public Caption As String


    '0:00:53.352,0:00:54.853
    'in in in in in in in in in the
    'in

    Public Sub New(ClosedCaption As String)
        Dim TimeString As String
        Dim SemicolonPos As Integer
        Dim StartTimeText, EndTimeText As String

        TimeString = ClosedCaption.Substring(0, ClosedCaption.IndexOf(vbCr))

        SemicolonPos = TimeString.IndexOf(",")
        StartTimeText = TimeString.Substring(0, SemicolonPos)
        EndTimeText = TimeString.Substring(SemicolonPos + 1)
        Caption = ClosedCaption.Substring(ClosedCaption.IndexOf(vbCr) + 2)

        StartTime = DateTime.Parse(StartTimeText)

        EndTime = DateTime.Parse(EndTimeText)
    End Sub
    Public ReadOnly Property HasNoSpaces As Boolean
        Get
            Return (Caption.IndexOf(" ") = -1)
        End Get
    End Property
    Public ReadOnly Property Duration As TimeSpan
        Get
            Return EndTime - StartTime
        End Get
    End Property

    Public Function DurationShorterThan(Millis As Double) As Boolean
        Dim M As Double
        M = (EndTime - StartTime).TotalMilliseconds
        Return (M < Millis)
    End Function
    Public Function DurationLongerThan(Millis As Double) As Boolean
        Dim M As Double
        M = (EndTime - StartTime).TotalMilliseconds
        Return (M > Millis)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("[{0:H:mm:ss.fff}][{1:H:mm:ss.fff}] {2}", StartTime, EndTime, Caption)
    End Function

    Public Function ToString1(format As String, formatProvider As System.IFormatProvider) As String Implements System.IFormattable.ToString
        Dim Retval As String
        Dim TS As TimeSpan
        If format = "Duration" Then
            Retval = (EndTime - StartTime).ToString("H:mm:ss.fff")
        ElseIf format = "Interval" Then
            Retval = String.Format("{0} to {1}", StartTime.ToString("H:mm:ss.fff"), EndTime.ToString("H:mm:ss.fff"))
        ElseIf format = "AllLength" Then
            TS = EndTime - StartTime
            Retval = String.Format("{0} for {1}({2:0.##}).", Caption.Length, TS.ToString("mm\:ss\.fff"), Caption.Length / TS.TotalSeconds)
        ElseIf format = "Out" Then
            Retval = String.Format("{0:H:mm:ss.fff},{1:H:mm:ss.fff}{2}{3}{2}", StartTime, EndTime, vbNewLine, Caption)
        Else
            Retval = ToString()
        End If
        Return Retval
    End Function
End Structure