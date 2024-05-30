Imports System.Threading
Imports System.Threading.Tasks
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form1
    ' Devine GUI created by billybanana v 1.0.0
    ' This application does not interact directly with any streaming service.

    ' The python Function(s) invoked are created by the devine team.
    ' More information is available at GitHub.
    ' https://github.com/devine-dl/devine


    'this contains all of the RadioButtons in the 1st main groupbox
    Dim firstMainGroupboxRadioButtons() As RadioButton
    'this contains all of the RadioButtons in the 2nd main groupbox
    Dim secondMainGroupboxRadioButtons() As RadioButton



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ToolTip1.SetToolTip(Button7, "Click to clear selected Service & Action")
        ToolTip1.SetToolTip(btnReset, "Click to kill Command window and clear selected Service & Action")
        ToolTip1.SetToolTip(Button3, "Click to choose Options")
        ToolTip1.SetToolTip(Button4, "Click to view Help")
        ToolTip1.SetToolTip(btnFavorites, "Click to view Favorites")
        ToolTip1.SetToolTip(TBcompletecommand, "Displays the complete string passed through to the Command Prompt")
        ToolTip1.SetToolTip(GroupBox5, "Choose resolution if you wish to change from default = best")
        ToolTip1.SetToolTip(GroupBox1, "Selecting the streaming service is required for all functions")
        ToolTip1.SetToolTip(GroupBox9, "Select the dropdown box to choose a Proxy")

        ' Uncheck all RadioButtons in the groupBox2
        For Each radioButton As RadioButton In GroupBox2.Controls.OfType(Of RadioButton)()
            radioButton.Checked = False
        Next

        ' Uncheck all RadioButtons in the groupBox1
        For Each radioButton As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)()
            radioButton.Checked = False
        Next

        ' Uncheck all RadioButtons in the groupBox5
        For Each radioButton As RadioButton In GroupBox5.Controls.OfType(Of RadioButton)()
            radioButton.Checked = False
        Next

        ' Clear the tbCustom TextBox
        tbCustom.Clear()

        'here i setup the handler methods + load the arrays
        Array.ForEach(GroupBox1.Controls.OfType(Of GroupBox).ToArray, Sub(gb) Array.ForEach(gb.Controls.OfType(Of RadioButton).ToArray, Sub(rb) AddHandler rb.CheckedChanged, AddressOf firstMainGroupboxRadioButtons_checkedchanged))
        Dim gbs() As GroupBox = GroupBox1.Controls.OfType(Of GroupBox).ToArray
        firstMainGroupboxRadioButtons = gbs(0).Controls.OfType(Of RadioButton).ToArray
        For x As Integer = 1 To gbs.GetUpperBound(0)
            firstMainGroupboxRadioButtons = firstMainGroupboxRadioButtons.Concat(gbs(x).Controls.OfType(Of RadioButton)).ToArray
        Next
        Array.ForEach(GroupBox2.Controls.OfType(Of GroupBox).ToArray, Sub(gb) Array.ForEach(gb.Controls.OfType(Of RadioButton).ToArray, Sub(rb) AddHandler rb.CheckedChanged, AddressOf secondMainGroupboxRadioButtons_checkedchanged))
        gbs = GroupBox2.Controls.OfType(Of GroupBox).ToArray
        secondMainGroupboxRadioButtons = gbs(0).Controls.OfType(Of RadioButton).ToArray
        For x As Integer = 1 To gbs.GetUpperBound(0)
            secondMainGroupboxRadioButtons = secondMainGroupboxRadioButtons.Concat(gbs(x).Controls.OfType(Of RadioButton)).ToArray
        Next

        '___________________________________________________________________________________________________

        'Show the Devine folder location in Label 5
        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath
        Form2.TBfolder2.Text = My.Settings.FolderPath2

        ' Set ToolStrip text to the folder path from TBfolder
        ToolStripStatusLabel1.Text = "Devine folder:"
        ToolStripStatusLabel2.Text = Form2.TBfolder.Text

        If Form2.TBfolder.Text = "" Then
            ToolStripStatusLabel2.Text = "Please set your Devine folder location in Options"
        End If

        '___________________________________________________________________________________________________

        ' Load the contents of the queue
        ' Specify the path to the queue.bat file
        Dim queuePath As String = Form2.TBfolder.Text + "\queue.bat"

        ' Check if the file exists
        If File.Exists(queuePath) Then
            ' Read the content of the queue.txt file
            Dim queueContent As String = File.ReadAllText(queuePath)

            ' Display the content in the RichTextBox
            rtbQueue.Text = queueContent
        End If

        '___________________________________________________________________________________________________

        ' Find the current Devine version number by reading the "__init__.py" file
        ToolStripStatusLabel3.Text = "Devine version:"

        ' Specify the path to the __init__.py file
        Dim filePath2 As String = Path.Combine(Form2.TBfolder.Text, "devine\core\__init__.py")

        If File.Exists(filePath2) Then

            ' Read the content of the __init__.py file
            Dim fileContent2 As String = File.ReadAllText(filePath2)
            Dim versionValue As String = ExtractversionValue(fileContent2, "__version__ = ""(\d+\.\d+\.\d+)""")

            ' Check if the versionValue is numeric, in the sense of formatting (version numbers are not purely numeric but formatted with dots)
            If IsNumeric(versionValue.Replace(".", "")) Then
                ' Populate the label based on the extracted version
                ToolStripStatusLabel4.Text = versionValue
            Else
                ' Handle the case where versionValue does not contain "v"
                ToolStripStatusLabel4.Text = "Devine folder not set"
                MessageBox.Show("Please set your Devine folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
        '___________________________________________________________________________________________________

    End Sub

    Function ExtractversionValue(content As String, pattern As String) As String
        Dim match As Match = Regex.Match(content, pattern)

        If match.Success Then
            ' The version value is captured in the first group
            Return match.Groups(1).Value
        Else
            ' Return an empty string or handle the case where no match is found
            Return String.Empty
        End If
    End Function

    'this is the handler for the 1st main groupbox's radiobuttons
    'it ensures only 1 radiobutton in this main group can be checked
    Private Sub firstMainGroupboxRadioButtons_checkedchanged(sender As System.Object, e As System.EventArgs)
        Dim current As RadioButton = DirectCast(sender, RadioButton)
        If current.Checked Then
            Array.ForEach(firstMainGroupboxRadioButtons.ToArray(), Sub(rb) rb.Checked = If(rb IsNot current, False, True))
            tbCustom.Clear()
            tbCustom.Enabled = False
        Else
            tbCustom.Enabled = True
        End If
    End Sub

    'this is the handler for the 2nd main groupbox's radiobuttons
    'it ensures only 1 radiobutton in this main group can be checked
    Private Sub secondMainGroupboxRadioButtons_checkedchanged(sender As System.Object, e As System.EventArgs)
        Dim current As RadioButton = DirectCast(sender, RadioButton)
        If current.Checked Then
            Array.ForEach(secondMainGroupboxRadioButtons.ToArray(), Sub(rb) rb.Checked = If(rb IsNot current, False, True))
        End If
    End Sub

    Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
        ' Open Command Window to download videos from the selected service

        ' Load the saved devine folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        ' Devine folder
        Dim folderPath As String = Form2.TBfolder.Text
        ' downloads folder
        Dim downloadPath As String = Form2.TBfolder2.Text

        ' Determine which option is selected and construct the arguments accordingly
        Dim wantedArguments As String = ""
        Dim searchArguments As String = ""
        Dim serviceArguments As String = ""
        Dim subtitleArguments As String = ""
        Dim resolutionArguments As String = ""
        Dim dlArguments As String = ""
        Dim skipdlArguments As String = ""
        Dim proxyArguments As String = ""
        Dim secondsArguments As String = ""
        Dim nofolderArguments As String = ""
        Dim threadsArguments As String = ""
        Dim ncArguments As String = ""
        Dim episodeArguments As String = ""
        Dim listArguments As String = ""
        Dim versionArguments As String = ""
        Dim subsArguments As String = ""
        Dim tagArguments As String = ""
        Dim videocodecArguments As String = ""
        Dim audiocodecArguments As String = ""
        Dim decryptArguments As String = ""
        Dim videobitrateArguments As String = ""
        Dim subsformatArguments As String = ""

        Select Case True
            Case BtnInfo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                listArguments = "--list"
            Case BtnTitles.Checked
                dlArguments = "dl"
                wantedArguments = "--list-titles"
                    ' episode/2160
            Case BtnEpisode.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-r HLG"
                    ' episode/1080
            Case BtnEpisode.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                    ' episode/720
            Case BtnEpisode.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                    ' episode/576
            Case BtnEpisode.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                     ' episode/540
            Case BtnEpisode.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                    ' episode/450
            Case BtnEpisode.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                    ' episode/360
            Case BtnEpisode.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                    ' episode
            Case BtnEpisode.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
            Case BtnAudioandVideo.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "--r HLG"
                    ' audio and video only/1080
            Case BtnAudioandVideo.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/720
            Case BtnAudioandVideo.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/576
            Case BtnAudioandVideo.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                subtitleArguments = "--audio-only --video-only"
                     ' audio and video only/540
            Case BtnAudioandVideo.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/450
            Case BtnAudioandVideo.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/360
            Case BtnAudioandVideo.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                subtitleArguments = "--audio-only --video-only"
                    ' video only/2160
            Case BtnVideo.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-r HLG"
                subtitleArguments = "--video-only"
                    ' video only/1080
            Case BtnVideo.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                subtitleArguments = "--video-only"
                    ' video only/720
            Case BtnVideo.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                subtitleArguments = "--video-only"
                    ' video only/576
            Case BtnVideo.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                subtitleArguments = "--video-only"
                     ' video only/540
            Case BtnVideo.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                subtitleArguments = "--video-only"
                    ' video only/450
            Case BtnVideo.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                subtitleArguments = "--video-only"
                    ' video only/360
            Case BtnVideo.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                subtitleArguments = "--video-only"
                    ' subtitles only
            Case BtnSubs.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--subs-only"
                ' video only
            Case BtnVideo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--video-only"
                ' audio only
            Case BtnAudio.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--audio-only"
                ' audio and video
            Case BtnAudioandVideo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--audio-only --video-only"
            Case BtnHelp.Checked
                dlArguments = "dl"
                wantedArguments = "-h"
            Case BtnVersion.Checked
                wantedArguments = "-v"
            Case BtnSearch.Checked
                searchArguments = "search"
            Case BtnClearCache.Checked
                searchArguments = "env clear cache"
        End Select

        ' Check additional service-specific options
        Select Case True
            Case BBCBtn.Checked
                serviceArguments = "iP"
            Case ITVBtn.Checked
                serviceArguments = "itv"
            Case C4Btn.Checked
                serviceArguments = "ALL4"
            Case C5Btn.Checked
                serviceArguments = "my5"
            Case STVBtn.Checked
                serviceArguments = "stv"
            Case SVTBtn.Checked
                serviceArguments = "svt"
            Case tv4Btn.Checked
                serviceArguments = "tv4"
            Case TubiBtn.Checked
                serviceArguments = "tubi"
            Case UKTVBtn.Checked
                serviceArguments = "uktv"
            Case BtnCBCGem.Checked
                serviceArguments = "cbc"
            Case BtnCTV.Checked
                serviceArguments = "ctv"
            Case BtnCrackle.Checked
                serviceArguments = "CRKL"
            Case BtnPluto.Checked
                serviceArguments = "PLU"
            Case BtnRoku.Checked
                serviceArguments = "roku"
            Case BtnABC.Checked
                serviceArguments = "abc"
            Case BtnCWTV.Checked
                serviceArguments = "cwtv"
            Case BtnTVNZ.Checked
                serviceArguments = "tvnz"
            Case btnRTE.Checked
                serviceArguments = "rte"
            Case btnCBS.Checked
                serviceArguments = "cbs"
            Case BtnSeven.Checked
                serviceArguments = "SVN"
            Case BtnNine.Checked
                serviceArguments = "NINE"
            Case BtnSBS.Checked
                serviceArguments = "SBS"
            Case BtnThree.Checked
                serviceArguments = "threenow"
            Case BtnVirgin.Checked
                serviceArguments = "virgin"
            Case tbCustom.Text IsNot ""
                serviceArguments = tbCustom.Text


                ' Add more conditions for other service-specific options if needed
        End Select

        ' Check if Video Codec options are checked
        Select Case True
            Case btn264.Checked
                videocodecArguments = "--vcodec H.264"
            Case btn265.Checked
                videocodecArguments = "--vcodec H.265"
            Case btnVC1.Checked
                videocodecArguments = "--vcodec VC-1"
            Case btnVP8.Checked
                videocodecArguments = "--vcodec VP8"
            Case btnVP9.Checked
                videocodecArguments = "--vcodec VP9"
            Case btnAV1.Checked
                videocodecArguments = "--vcodec AV1"

        End Select

        ' Check if Audio Codec options are checked
        Select Case True
            Case btnAAC.Checked
                audiocodecArguments = "--acodec AAC"
            Case btnDD.Checked
                audiocodecArguments = "--acodec DD"
            Case btnDDPlus.Checked
                audiocodecArguments = "--acodec DD+"
            Case btnOPUS.Checked
                audiocodecArguments = "--acodec OPUS"
            Case btnVORB.Checked
                audiocodecArguments = "--acodec VORB"
            Case btnDTS.Checked
                audiocodecArguments = "--acodec DTS"
            Case btnALAC.Checked
                audiocodecArguments = "--acodec ALAC"
            Case btnFLAC.Checked
                audiocodecArguments = "--acodec FLAC"

        End Select

        ' Check if Subtitle Format options are checked
        Select Case True
            Case btnSRT.Checked
                subsformatArguments = "--sub-format SRT"
            Case btnSSA.Checked
                subsformatArguments = "--sub-format SSA"
            Case btnASS.Checked
                subsformatArguments = "--sub-format ASS"
            Case btnTTML.Checked
                subsformatArguments = "--sub-format TTML"
            Case btnVTT.Checked
                subsformatArguments = "--sub-format VTT"
            Case btnSTPP.Checked
                subsformatArguments = "--sub-format STPP"
            Case btnWVTT.Checked
                subsformatArguments = "--sub-format WVTT"

        End Select

        ' Check if Decryption options are checked
        Select Case True
            Case btnCDM.Checked
                decryptArguments = "--cdm-only"
            Case btnVault.Checked
                decryptArguments = "--vaults-only"

        End Select

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then

            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Quote the TextBox value and include it in the arguments
            Dim textBoxValue As String = GroupBox3.Controls("TextBox1").Text
            Dim quotedTextBoxValue As String = $"{textBoxValue}"

            ' Check if ComboBox1.Text is empty
            If ComboBox1.Text = "" Then
                proxyArguments = ""
            ElseIf ComboBox1.Text.ToLower().StartsWith("http") Then
                ' If ComboBox1.Text starts with "http", set proxyArguments to the ComboBox1.Text
                proxyArguments = "--proxy " + ComboBox1.Text
            Else
                ' Handle proxyArguments based on ComboBox1.Text
                Select Case ComboBox1.Text.ToLower()
                    Case "no proxy"
                        proxyArguments = "--no-proxy"
                    Case "au - australia"
                        proxyArguments = "--proxy AU"
                    Case "ca - canada"
                        proxyArguments = "--proxy CA"
                    Case "dk - denmark"
                        proxyArguments = "--proxy DK"
                    Case "de - germany"
                        proxyArguments = "--proxy DE"
                    Case "fi - finland"
                        proxyArguments = "--proxy FI"
                    Case "gb - great britain"
                        proxyArguments = "--proxy GB"
                    Case "ie - ireland"
                        proxyArguments = "--proxy IE"
                    Case "il - israel"
                        proxyArguments = "--proxy IL"
                    Case "it - italy"
                        proxyArguments = "--proxy IT"
                    Case "nl - netherlands"
                        proxyArguments = "--proxy NL"
                    Case "nz - new zealand"
                        proxyArguments = "--proxy NZ"
                    Case "pl - poland"
                        proxyArguments = "--proxy PL"
                    Case "ru - russia"
                        proxyArguments = "--proxy RU"
                    Case "es - spain"
                        proxyArguments = "--proxy ES"
                    Case "se - sweden"
                        proxyArguments = "--proxy SE"
                    Case "tr - turkey"
                        proxyArguments = "--proxy TR"
                    Case "us - united states"
                        proxyArguments = "--proxy US"
                        ' Add more cases as needed
                End Select
            End If


            ' Check if cbSubs.Text is empty
            If cbSubs.Text = "" Then
                subsArguments = ""
            Else
                ' Handle subtitleArguments based on cbSubs.Text
                Select Case cbSubs.Text
                    Case "en - English"
                        subsArguments = "-sl en"
                    Case "cs - Czech"
                        subsArguments = "-sl cs"
                    Case "da - Danish"
                        subsArguments = "-sl da"
                    Case "de - German"
                        subsArguments = "-sl de"
                    Case "es - Spanish"
                        subsArguments = "-sl es"
                    Case "fi - Finnish"
                        subsArguments = "-sl fi"
                    Case "fr - French"
                        subsArguments = "-sl fr"
                    Case "he - Hebrew"
                        subsArguments = "-sl he"
                    Case "ja - Japanese"
                        subsArguments = "-sl ja"
                    Case "ko - Korean"
                        subsArguments = "-sl ko"
                    Case "nl - netherlands"
                        subsArguments = "-sl nl"
                    Case "pl - Polish"
                        subsArguments = "-sl pl"
                    Case "ru - russia"
                        subsArguments = "-sl ru"
                        ' Add more cases as needed
                End Select
            End If

            ' Check if tbTags.Text is empty
            If tbTags.Text = "" Then
                tagArguments = ""
            Else
                tagArguments = "--tag " + tbTags.Text
            End If

            ' Check if Slow Option is checked
            If BtnSlow.Checked = False Then
                secondsArguments = ""
            Else
                secondsArguments = "--slow"
            End If

            ' Check if No Folder Option is checked
            If Btnfolder.Checked = False Then
                nofolderArguments = ""
            Else
                nofolderArguments = "--no-folder"
            End If

            ' Check if Use Skip Download Option is checked
            If Btnskip.Checked = False Then
                skipdlArguments = ""
            Else
                skipdlArguments = "--skip-dl"
                wantedArguments = "-w"
            End If

            ' Check if Threads Option is empty
            If tbThreads.Text = "" Then
                threadsArguments = ""
            Else
                ' Specify the number of threads entered
                threadsArguments = "--workers " + tbThreads.Text
            End If

            ' Check if Episode Number/Range is empty
            If tbEpisodes.Text = "" Then
                episodeArguments = ""
            Else
                ' Specify the episode numner/range
                episodeArguments = tbEpisodes.Text
            End If

            ' Check if Video Bitrate Option is empty
            If tbVideoBitrate.Text = "" Then
                videobitrateArguments = ""
            Else
                ' Specify the number of threads entered
                videobitrateArguments = "-vb " + tbVideoBitrate.Text
            End If

            ' Construct the complete command with quoted TextBox value
            Dim completeCommand As String = $"devine {dlArguments} {nofolderArguments} {proxyArguments} {tagArguments} {threadsArguments} {skipdlArguments} {resolutionArguments} {videocodecArguments} {audiocodecArguments} {videobitrateArguments} {decryptArguments} {searchArguments} {wantedArguments} {episodeArguments} {secondsArguments} {subtitleArguments} {subsArguments} {subsformatArguments} {listArguments} {serviceArguments} {quotedTextBoxValue}"

            ' Display the complete command in TextBox Complete Command
            TBcompletecommand.Text = completeCommand

            ' Set the command for the Command Prompt process
            process.StartInfo.Arguments = $"/k " & completeCommand

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter
        Me.AcceptButton = BtnGo
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Clears all the button selections on the form

        TextBox1.Text = ""
        TBcompletecommand.Text = ""

        tbThreads.Text = ""
        tbEpisodes.Text = ""
        tbCustom.Text = ""
        cbSubs.Text = ""
        tbTags.Text = ""
        tbVideoBitrate.Text = ""

        BtnABC.Checked = False
        C4Btn.Checked = False
        BBCBtn.Checked = False
        ITVBtn.Checked = False
        C5Btn.Checked = False
        STVBtn.Checked = False
        SVTBtn.Checked = False
        TubiBtn.Checked = False
        UKTVBtn.Checked = False
        BtnCBCGem.Checked = False
        BtnCTV.Checked = False
        BtnCrackle.Checked = False
        BtnPluto.Checked = False
        BtnRoku.Checked = False
        BtnCWTV.Checked = False
        tv4Btn.Checked = False
        BtnTVNZ.Checked = False
        btnRTE.Checked = False
        btnCBS.Checked = False
        BtnNine.Checked = False
        BtnSeven.Checked = False
        BtnSBS.Checked = False
        BtnThree.Checked = False
        BtnVirgin.Checked = False


        BtnInfo.Checked = False
        BtnTitles.Checked = False
        BtnEpisode.Checked = False
        BtnSubs.Checked = False
        BtnHelp.Checked = False
        BtnSearch.Checked = False
        BtnVersion.Checked = False
        ComboBox1.SelectedIndex = -1
        BtnAudioandVideo.Checked = False
        BtnAudio.Checked = False
        BtnVideo.Checked = False
        BtnClearCache.Checked = False

        btn2160.Checked = False
        btn1080.Checked = False
        btn720.Checked = False
        btn576.Checked = False
        btn540.Checked = False
        btn450.Checked = False
        btn360.Checked = False
        Btnfolder.Checked = False
        btnSource.Checked = False
        BtnSlow.Checked = False
        Btnskip.Checked = False
        btn264.Checked = False
        btn265.Checked = False
        btnVC1.Checked = False
        btnVP8.Checked = False
        btnVP9.Checked = False
        btnAV1.Checked = False
        btnAAC.Checked = False
        btnDD.Checked = False
        btnDDPlus.Checked = False
        btnOPUS.Checked = False
        btnVORB.Checked = False
        btnDTS.Checked = False
        btnFLAC.Checked = False
        btnCDM.Checked = False
        btnVault.Checked = False
        btnSRT.Checked = False
        btnSSA.Checked = False
        btnASS.Checked = False
        btnTTML.Checked = False
        btnVTT.Checked = False
        btnSTPP.Checked = False
        btnWVTT.Checked = False


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Open the Options form
        Form2.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub


    Private Sub ABCIViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABCIViewToolStripMenuItem.Click
        'Open ABC iView
        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://iview.abc.net.au/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub All4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles All4ToolStripMenuItem.Click
        'Open All 4
        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.channel4.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub BBCIPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BBCIPlayerToolStripMenuItem.Click
        'Open BBC iPlayer

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.bbc.co.uk/iplayer"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub CBCGemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CBCGemToolStripMenuItem.Click
        'Open CBC Gem

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://gem.cbc.ca/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub CrackleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrackleToolStripMenuItem.Click
        'Open Crackle

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.crackle.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub CTVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CTVToolStripMenuItem.Click
        'Open CTV

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.ctv.ca/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub ITVXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITVXToolStripMenuItem.Click
        'Open ITV Hub

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.itv.com/watch/categories"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub My5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles My5ToolStripMenuItem.Click
        'Open My5

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.channel5.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub PlutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlutoToolStripMenuItem.Click
        'Open Pluto

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://web.pluto.tv/on-demand"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub TheRokuChannelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TheRokuChannelToolStripMenuItem.Click
        'Open The Roku Channel

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "http://therokuchannel.roku.com"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub STVPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STVPlayerToolStripMenuItem.Click
        'Open STV Player

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://player.stv.tv/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub TubiTVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TubiTVToolStripMenuItem.Click
        'Open Tubi TV

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://tubitv.com/home"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub UKTVPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UKTVPlayToolStripMenuItem.Click
        'Open UKTV Play

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://uktvplay.co.uk/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        'Open the Help information for devine in the Command Prompt

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then

            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k devine -h"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CWTVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CWTVToolStripMenuItem.Click
        'Open CWTV

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.cwtv.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub FreevineExternalCommandPromptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FreevineExternalCommandPromptToolStripMenuItem.Click
        'Open Devine in the External Command Prompt

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then
            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Start the process
            process.Start()


        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'Clears all the button selections on the form

        TextBox1.Text = ""
        TBcompletecommand.Text = ""
        tbThreads.Text = ""
        tbEpisodes.Text = ""
        tbCustom.Text = ""
        cbSubs.Text = ""
        tbTags.Text = ""
        tbVideoBitrate.Text = ""

        BtnABC.Checked = False
        C4Btn.Checked = False
        BBCBtn.Checked = False
        ITVBtn.Checked = False
        C5Btn.Checked = False
        STVBtn.Checked = False
        SVTBtn.Checked = False
        TubiBtn.Checked = False
        UKTVBtn.Checked = False
        BtnCBCGem.Checked = False
        BtnCTV.Checked = False
        BtnCrackle.Checked = False

        BtnPluto.Checked = False
        BtnRoku.Checked = False
        BtnCWTV.Checked = False
        tv4Btn.Checked = False
        BtnTVNZ.Checked = False
        btnRTE.Checked = False
        btnCBS.Checked = False
        BtnNine.Checked = False
        BtnSeven.Checked = False
        BtnSBS.Checked = False
        BtnThree.Checked = False
        BtnVirgin.Checked = False

        BtnInfo.Checked = False
        BtnTitles.Checked = False
        BtnEpisode.Checked = False
        BtnSubs.Checked = False
        BtnHelp.Checked = False
        BtnVersion.Checked = False
        BtnSearch.Checked = False
        ComboBox1.SelectedIndex = -1
        BtnAudioandVideo.Checked = False
        BtnAudio.Checked = False
        BtnVideo.Checked = False
        BtnClearCache.Checked = False

        btn2160.Checked = False
        btn1080.Checked = False
        btn720.Checked = False
        btn576.Checked = False
        btn540.Checked = False
        btn450.Checked = False
        btn360.Checked = False
        Btnfolder.Checked = False
        btnSource.Checked = False
        BtnSlow.Checked = False
        Btnskip.Checked = False
        btn264.Checked = False
        btn265.Checked = False
        btnVC1.Checked = False
        btnVP8.Checked = False
        btnVP9.Checked = False
        btnAV1.Checked = False
        btnAAC.Checked = False
        btnDD.Checked = False
        btnDDPlus.Checked = False
        btnOPUS.Checked = False
        btnVORB.Checked = False
        btnDTS.Checked = False
        btnFLAC.Checked = False
        btnCDM.Checked = False
        btnVault.Checked = False
        btnSRT.Checked = False
        btnSSA.Checked = False
        btnASS.Checked = False
        btnTTML.Checked = False
        btnVTT.Checked = False
        btnSTPP.Checked = False
        btnWVTT.Checked = False


        ' Find all processes with the name "WindowsTerminal.exe"
        Dim processes() As Process = Process.GetProcessesByName("WindowsTerminal")

        ' Iterate through the list of processes and kill each one
        For Each process As Process In processes
            process.Kill()
        Next
    End Sub

    Private Sub btnFavorites_Click(sender As Object, e As EventArgs) Handles btnFavorites.Click
        ' Open Favorites form
        Form3.Show()
    End Sub


    Private Sub SVTPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SVTPlayToolStripMenuItem.Click
        'Open SVT Player

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.svtplay.se/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub



    Private Sub TV4PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TV4PlayToolStripMenuItem.Click
        'Open TV4 Play

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.tv4play.se/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub TVNZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TVNZToolStripMenuItem.Click
        'Open TVNZ

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.tvnz.co.nz/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub TestCDMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestCDMToolStripMenuItem.Click
        ' Open CDM and Test your CDM in the Command Prompt
        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text + "\wvds"

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then
            ' Get files with the .wvd extension in the specified directory
            Dim wvdFiles As String() = Directory.GetFiles(folderPath, "*.wvd")

            If wvdFiles.Length > 0 Then
                ' Take the first .wvd file (you can modify this logic as needed)
                Dim wvdFilePath As String = wvdFiles(0)

                ' Start a new Command Prompt process
                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"

                ' Set the working directory for the Command Prompt process
                process.StartInfo.WorkingDirectory = folderPath

                ' Construct the complete command with quoted TextBox value
                process.StartInfo.Arguments = $"/k pywidevine test ""{wvdFilePath}"""

                ' Start the process
                process.Start()
            Else
                ' Display an error message if no .wvd files are found
                MessageBox.Show("No .wvd files found in the specified directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RTEPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RTEPlayerToolStripMenuItem.Click
        'Open RTE Player

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.rte.ie/player/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub CBSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CBSToolStripMenuItem.Click
        'Open CBS

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.cbs.com/shows/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub DevineGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevineGitHubToolStripMenuItem.Click
        'Open Devine GitHub

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://github.com/devine-dl/devine"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub ConfigDocumentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigDocumentationToolStripMenuItem.Click
        'Open Devine Config Documentation

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://github.com/devine-dl/devine/blob/master/CONFIG.md"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub



    Private Sub BBCIPlayerUltraHDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BBCIPlayerUltraHDToolStripMenuItem.Click
        ' Open BBC iPlayer list of 4K programming

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.bbc.co.uk/iplayer/help/questions/programme-availability/uhd-content"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub EmptyTempFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmptyTempFolderToolStripMenuItem.Click

        Dim folderPath As String = Form2.TBfolder.Text
        Dim tempPath As String = Form2.TBfolder.Text + "\temp"

        If Directory.Exists(tempPath) Then
            ' Deleting all files in the directory
            For Each filePath As String In Directory.GetFiles(tempPath)
                File.Delete(filePath)
            Next

            ' Deleting all subdirectories in the directory
            For Each directoryPath As String In Directory.GetDirectories(tempPath)
                Directory.Delete(directoryPath, True)
            Next

            MessageBox.Show("All files and subdirectories have been deleted!", "Success")
        Else
            MessageBox.Show($"The directory {tempPath} does not exist.", "Error")
        End If

    End Sub

    Private Sub UpgradeDevineVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpgradeDevineVersionToolStripMenuItem.Click
        'Open Devine in the External Command Prompt and run Upgrade command

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then
            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k pip install --upgrade devine"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EnvInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvInfoToolStripMenuItem.Click
        ' Show Devine Environment Info
        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then
            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k devine env info"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ListConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListConfigToolStripMenuItem.Click
        ' List Devine Configuration
        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then
            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k devine cfg --list"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AmazonPrimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmazonPrimeToolStripMenuItem.Click
        ' Open Amazon Prime Video

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.primevideo.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub NowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NowToolStripMenuItem.Click
        'Open 9 Now

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.9now.com.au"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub PlusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlusToolStripMenuItem.Click
        'Open 7 Plus

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.7plus.com.au"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub SBSOnDemandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SBSOnDemandToolStripMenuItem.Click
        ' Open SBS On Demand

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.sbs.com.au/ondemand/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub UpdateRichTextBox()
        ' Specify the path to the queue.bat file
        Dim queuePath As String = Form2.TBfolder.Text + "\queue.bat"

        ' Check if the file exists
        If File.Exists(queuePath) Then
            ' Read the content of the queue.bat file
            Dim queueContent As String = File.ReadAllText(queuePath)

            ' Display the content in the RichTextBox
            rtbQueue.Text = queueContent
        End If
    End Sub


    Private Sub clearQueue_Click(sender As Object, e As EventArgs) Handles clearQueue.Click
        ' Show the Devine folder location in TBfolder
        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Specify the path to the queue.txt file
        Dim queuePath As String = Form2.TBfolder.Text + "\queue.bat"

        ' Check if the file exists
        If File.Exists(queuePath) Then
            ' Clear the contents of the queue.txt file
            File.WriteAllText(queuePath, String.Empty)

            ' Update the RichTextBox with the cleared content
            UpdateRichTextBox()

            'Clear the main command text box
            TextBox1.Text = ""
            TBcompletecommand.Text = ""

        End If
    End Sub

    Private Sub processQueue_Click(sender As Object, e As EventArgs) Handles processQueue.Click
        ' Process the contents of queue.bat

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Specify the path to the queue.bat file
        Dim queuePath As String = Path.Combine(folderPath, "queue.bat")


        ' Check if the file exists
        If File.Exists(queuePath) Then
            ' Read the content of the queue.txt file
            Dim queueContent As String = File.ReadAllText(queuePath)

            ' Display the content in the RichTextBox
            rtbQueue.Text = queueContent

            ' Check if the folder path exists
            If Directory.Exists(folderPath) Then

                ' Start a new Command Prompt process
                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"

                ' Set the working directory for the Command Prompt process
                process.StartInfo.WorkingDirectory = folderPath

                ' Construct the complete command to run the .bat file
                Dim processCommand As String = $"/k ""{queuePath}"""

                ' Set the command for the Command Prompt process
                process.StartInfo.Arguments = processCommand

                ' Start the process
                process.Start()

            Else
                ' Display an error message if the folder path doesn't exist
                MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub addQueue_Click(sender As Object, e As EventArgs) Handles addQueue.Click
        ' Load the saved freevine folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        ' Devine folder
        Dim folderPath As String = Form2.TBfolder.Text
        ' downloads folder
        Dim downloadPath As String = Form2.TBfolder2.Text

        ' Specify the path to the queue.bat file
        Dim queuePath As String = Form2.TBfolder.Text + "\queue.bat"

        ' Check if the file exists
        If Not File.Exists(queuePath) Then
            ' If the file doesn't exist, create it
            File.Create(queuePath).Dispose()
        End If

        ' Read the existing content of the queue.bat file
        Dim queueEntries As New List(Of String)(File.ReadAllLines(queuePath))


        ' Determine which option is selected and construct the arguments accordingly
        Dim wantedArguments As String = ""
        Dim searchArguments As String = ""
        Dim serviceArguments As String = ""
        Dim subtitleArguments As String = ""
        Dim resolutionArguments As String = ""
        Dim dlArguments As String = ""
        Dim skipdlArguments As String = ""
        Dim proxyArguments As String = ""
        Dim secondsArguments As String = ""
        Dim nofolderArguments As String = ""
        Dim nosourceArguments As String = ""
        Dim threadsArguments As String = ""
        Dim ncArguments As String = ""
        Dim episodeArguments As String = ""
        Dim listArguments As String = ""
        Dim versionArguments As String = ""
        Dim subsArguments As String = ""
        Dim tagArguments As String = ""
        Dim videocodecArguments As String = ""
        Dim audiocodecArguments As String = ""
        Dim decryptArguments As String = ""
        Dim videobitrateArguments As String = ""
        Dim subsformatArguments As String = ""

        Select Case True
            Case BtnInfo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                listArguments = "--list"
            Case BtnTitles.Checked
                dlArguments = "dl"
                wantedArguments = "--list-titles"
                    ' episode/2160
            Case BtnEpisode.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-r HLG"
                    ' episode/1080
            Case BtnEpisode.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                    ' episode/720
            Case BtnEpisode.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                    ' episode/576
            Case BtnEpisode.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                     ' episode/540
            Case BtnEpisode.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                    ' episode/450
            Case BtnEpisode.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                    ' episode/360
            Case BtnEpisode.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                    ' episode
            Case BtnEpisode.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
            Case BtnAudioandVideo.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "--r HLG"
                    ' audio and video only/1080
            Case BtnAudioandVideo.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/720
            Case BtnAudioandVideo.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/576
            Case BtnAudioandVideo.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                subtitleArguments = "--audio-only --video-only"
                     ' audio and video only/540
            Case BtnAudioandVideo.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/450
            Case BtnAudioandVideo.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                subtitleArguments = "--audio-only --video-only"
                    ' audio and video only/360
            Case BtnAudioandVideo.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                subtitleArguments = "--audio-only --video-only"
                    ' video only/2160
            Case BtnVideo.Checked And btn2160.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-r HLG"
                subtitleArguments = "--video-only"
                    ' video only/1080
            Case BtnVideo.Checked And btn1080.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 1080"
                subtitleArguments = "--video-only"
                    ' video only/720
            Case BtnVideo.Checked And btn720.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 720"
                subtitleArguments = "--video-only"
                    ' video only/576
            Case BtnVideo.Checked And btn576.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 576"
                subtitleArguments = "--video-only"
                     ' video only/540
            Case BtnVideo.Checked And btn540.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 540"
                subtitleArguments = "--video-only"
                    ' video only/450
            Case BtnVideo.Checked And btn450.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 450"
                subtitleArguments = "--video-only"
                    ' video only/360
            Case BtnVideo.Checked And btn360.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                resolutionArguments = "-q 360"
                subtitleArguments = "--video-only"
                    ' subtitles only
            Case BtnSubs.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--subs-only"
                ' video only
            Case BtnVideo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--video-only"
                ' audio only
            Case BtnAudio.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--audio-only"
                ' audio and video
            Case BtnAudioandVideo.Checked
                dlArguments = "dl"
                wantedArguments = "-w"
                subtitleArguments = "--audio-only --video-only"
            Case BtnHelp.Checked
                dlArguments = "dl"
                wantedArguments = "-h"
            Case BtnVersion.Checked
                wantedArguments = "-v"
            Case BtnSearch.Checked
                searchArguments = "search"
            Case BtnClearCache.Checked
                searchArguments = "env clear cache"
        End Select

        ' Check additional service-specific options
        Select Case True
            Case BBCBtn.Checked
                serviceArguments = "iP"
            Case ITVBtn.Checked
                serviceArguments = "itv"
            Case C4Btn.Checked
                serviceArguments = "ALL4"
            Case C5Btn.Checked
                serviceArguments = "my5"
            Case STVBtn.Checked
                serviceArguments = "stv"
            Case SVTBtn.Checked
                serviceArguments = "svt"
            Case tv4Btn.Checked
                serviceArguments = "tv4"
            Case TubiBtn.Checked
                serviceArguments = "tubi"
            Case UKTVBtn.Checked
                serviceArguments = "uktv"
            Case BtnCBCGem.Checked
                serviceArguments = "cbc"
            Case BtnCTV.Checked
                serviceArguments = "ctv"
            Case BtnCrackle.Checked
                serviceArguments = "CRKL"
            Case BtnPluto.Checked
                serviceArguments = "PLU"
            Case BtnRoku.Checked
                serviceArguments = "roku"
            Case BtnABC.Checked
                serviceArguments = "abc"
            Case BtnCWTV.Checked
                serviceArguments = "cwtv"
            Case BtnTVNZ.Checked
                serviceArguments = "tvnz"
            Case btnRTE.Checked
                serviceArguments = "rte"
            Case btnCBS.Checked
                serviceArguments = "cbs"
            Case BtnSeven.Checked
                serviceArguments = "SVN"
            Case BtnNine.Checked
                serviceArguments = "NINE"
            Case BtnSBS.Checked
                serviceArguments = "SBS"
            Case BtnThree.Checked
                serviceArguments = "threenow"
            Case BtnVirgin.Checked
                serviceArguments = "virgin"
            Case tbCustom.Text IsNot ""
                serviceArguments = tbCustom.Text

                ' Add more conditions for other service-specific options if needed
        End Select

        ' Check if Video Codec options are checked
        Select Case True
            Case btn264.Checked
                videocodecArguments = "--vcodec H.264"
            Case btn265.Checked
                videocodecArguments = "--vcodec H.265"
            Case btnVC1.Checked
                videocodecArguments = "--vcodec VC-1"
            Case btnVP8.Checked
                videocodecArguments = "--vcodec VP8"
            Case btnVP9.Checked
                videocodecArguments = "--vcodec VP9"
            Case btnAV1.Checked
                videocodecArguments = "--vcodec AV1"

        End Select

        ' Check if Audio Codec options are checked
        Select Case True
            Case btnAAC.Checked
                audiocodecArguments = "--acodec AAC"
            Case btnDD.Checked
                audiocodecArguments = "--acodec DD"
            Case btnDDPlus.Checked
                audiocodecArguments = "--acodec DD+"
            Case btnOPUS.Checked
                audiocodecArguments = "--acodec OPUS"
            Case btnVORB.Checked
                audiocodecArguments = "--acodec VORB"
            Case btnDTS.Checked
                audiocodecArguments = "--acodec DTS"
            Case btnALAC.Checked
                audiocodecArguments = "--acodec ALAC"
            Case btnFLAC.Checked
                audiocodecArguments = "--acodec FLAC"

        End Select

        ' Check if Subtitle Format options are checked
        Select Case True
            Case btnSRT.Checked
                subsformatArguments = "--sub-format SRT"
            Case btnSSA.Checked
                subsformatArguments = "--sub-format SSA"
            Case btnASS.Checked
                subsformatArguments = "--sub-format ASS"
            Case btnTTML.Checked
                subsformatArguments = "--sub-format TTML"
            Case btnVTT.Checked
                subsformatArguments = "--sub-format VTT"
            Case btnSTPP.Checked
                subsformatArguments = "--sub-format STPP"
            Case btnWVTT.Checked
                subsformatArguments = "--sub-format WVTT"

        End Select

        ' Check if Decryption options are checked
        Select Case True
            Case btnCDM.Checked
                decryptArguments = "--cdm-only"
            Case btnVault.Checked
                decryptArguments = "--vaults-only"

        End Select

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then

            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Quote the TextBox value and include it in the arguments
            Dim textBoxValue As String = GroupBox3.Controls("TextBox1").Text
            Dim quotedTextBoxValue As String = $"{textBoxValue}"

            ' Check if ComboBox1.Text is empty
            If ComboBox1.Text = "" Then
                proxyArguments = ""
            ElseIf ComboBox1.Text.ToLower().StartsWith("http") Then
                ' If ComboBox1.Text starts with "http", set proxyArguments to the ComboBox1.Text
                proxyArguments = "--proxy " + ComboBox1.Text
            Else
                ' Handle proxyArguments based on ComboBox1.Text
                Select Case ComboBox1.Text.ToLower()
                    Case "no proxy"
                        proxyArguments = "--no-proxy"
                    Case "au - australia"
                        proxyArguments = "--proxy AU"
                    Case "ca - canada"
                        proxyArguments = "--proxy CA"
                    Case "dk - denmark"
                        proxyArguments = "--proxy DK"
                    Case "de - germany"
                        proxyArguments = "--proxy DE"
                    Case "fi - finland"
                        proxyArguments = "--proxy FI"
                    Case "gb - great britain"
                        proxyArguments = "--proxy GB"
                    Case "ie - ireland"
                        proxyArguments = "--proxy IE"
                    Case "il - israel"
                        proxyArguments = "--proxy IL"
                    Case "it - italy"
                        proxyArguments = "--proxy IT"
                    Case "nl - netherlands"
                        proxyArguments = "--proxy NL"
                    Case "nz - new zealand"
                        proxyArguments = "--proxy NZ"
                    Case "pl - poland"
                        proxyArguments = "--proxy PL"
                    Case "ru - russia"
                        proxyArguments = "--proxy RU"
                    Case "es - spain"
                        proxyArguments = "--proxy ES"
                    Case "se - sweden"
                        proxyArguments = "--proxy SE"
                    Case "tr - turkey"
                        proxyArguments = "--proxy TR"
                    Case "us - united states"
                        proxyArguments = "--proxy US"
                        ' Add more cases as needed
                End Select
            End If

            ' Check if cbSubs.Text is empty
            If cbSubs.Text = "" Then
                subsArguments = ""
            Else
                ' Handle subtitleArguments based on cbSubs.Text
                Select Case cbSubs.Text
                    Case "en - English"
                        subsArguments = "-sl en"
                    Case "cs - Czech"
                        subsArguments = "-sl cs"
                    Case "da - Danish"
                        subsArguments = "-sl da"
                    Case "de - German"
                        subsArguments = "-sl de"
                    Case "es - Spanish"
                        subsArguments = "-sl es"
                    Case "fi - Finnish"
                        subsArguments = "-sl fi"
                    Case "fr - French"
                        subsArguments = "-sl fr"
                    Case "he - Hebrew"
                        subsArguments = "-sl he"
                    Case "ja - Japanese"
                        subsArguments = "-sl ja"
                    Case "ko - Korean"
                        subsArguments = "-sl ko"
                    Case "nl - netherlands"
                        subsArguments = "-sl nl"
                    Case "pl - Polish"
                        subsArguments = "-sl pl"
                    Case "ru - russia"
                        subsArguments = "-sl ru"
                        ' Add more cases as needed
                End Select
            End If

            ' Check if tbTags.Text is empty
            If tbTags.Text = "" Then
                tagArguments = ""
            Else
                tagArguments = "--tag " + tbTags.Text
            End If

            ' Check if Slow Option is checked
            If BtnSlow.Checked = False Then
                secondsArguments = ""
            Else
                secondsArguments = "--slow"
            End If

            ' Check if No Folder Option is checked
            If Btnfolder.Checked = False Then
                nofolderArguments = ""
            Else
                nofolderArguments = "--no-folder"
            End If

            ' Check if No Source Option is checked
            If btnSource.Checked = False Then
                nosourceArguments = ""
            Else
                nosourceArguments = "--no-source"
            End If

            ' Check if Use Skip Download Option is checked
            If Btnskip.Checked = False Then
                skipdlArguments = ""
            Else
                skipdlArguments = "--skip-dl"
                wantedArguments = "-w"
            End If

            ' Check if Threads Option is empty
            If tbThreads.Text = "" Then
                threadsArguments = ""
            Else
                ' Specify the number of threads entered
                threadsArguments = "--workers " + tbThreads.Text
            End If

            ' Check if Episode Number/Range is empty
            If tbEpisodes.Text = "" Then
                episodeArguments = ""
            Else
                ' Specify the episode numner/range
                episodeArguments = tbEpisodes.Text
            End If

            ' Check if Video Bitrate Option is empty
            If tbVideoBitrate.Text = "" Then
                videobitrateArguments = ""
            Else
                ' Specify the number of threads entered
                videobitrateArguments = "-vb " + tbVideoBitrate.Text
            End If

            ' Construct the complete command with quoted TextBox value
            Dim completeCommand As String = $"devine {dlArguments} {nofolderArguments} {nosourceArguments} {tagArguments} {proxyArguments} {threadsArguments} {skipdlArguments} {resolutionArguments} {videocodecArguments} {audiocodecArguments} {videobitrateArguments} {decryptArguments} {searchArguments} {wantedArguments} {episodeArguments} {secondsArguments} {subtitleArguments} {subsArguments} {subsformatArguments} {listArguments} {serviceArguments} {quotedTextBoxValue}"

            ' Update the queue content (add new entry or modify as needed)
            Dim newQueueEntry As String = completeCommand

            ' Append the new entry to the end of the list
            queueEntries.Add(newQueueEntry)

            ' Write the modified content back to the queue.txt file
            File.WriteAllLines(queuePath, queueEntries)

            ' Update the RichTextBox with the updated content
            UpdateRichTextBox()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HighlightWords()
        ' List of words to highlight and their respective colors
        Dim wordsToHighlight As New Dictionary(Of String, Color) From {
        {"directories:", Color.DarkBlue},
        {"cdm:", Color.DarkBlue},
        {"credentials:", Color.DarkBlue},
        {"key_vaults:", Color.DarkBlue},
        {"tag:", Color.DarkBlue},
        {"downloader:", Color.DarkBlue},
        {"profiles:", Color.DarkBlue},
        {"dl:", Color.DarkBlue},
        {"services:", Color.DarkBlue},
        {"temp:", Color.DarkBlue},
        {"downloads:", Color.DarkBlue},
        {"cookies:", Color.DarkBlue},
        {"cache:", Color.DarkBlue},
        {"logs:", Color.DarkBlue},
        {"wvds:", Color.DarkBlue},
        {"default:", Color.DarkBlue},
        {"ALL4:", Color.DarkBlue},
        {"ROKU:", Color.DarkBlue},
        {"DSNP:", Color.DarkBlue},
        {"DSCP:", Color.DarkBlue},
        {"MY5:", Color.DarkBlue},
        {"TUBI:", Color.DarkBlue},
        {"CTV:", Color.DarkBlue},
        {"- type:", Color.DarkBlue},
        {"name:", Color.DarkBlue},
        {"path:", Color.DarkBlue},
        {"sub_format:", Color.DarkBlue},
        {"iP:", Color.DarkBlue},
        {"cert:", Color.DarkBlue},
        {"AMZN:", Color.DarkBlue},
        {"CR:", Color.DarkBlue},
        {"CRKL:", Color.DarkBlue},
        {"HM:", Color.DarkBlue},
        {"HULU:", Color.DarkBlue},
        {"PLAPL:", Color.DarkBlue},
        {"PLU:", Color.DarkBlue},
        {"RBOX:", Color.DarkBlue},
        {"SPOT:", Color.DarkBlue},
        {"TFC:", Color.DarkBlue},
        {"VIKI:", Color.DarkBlue}
    }

        ' List of line and occurrence exclusions (line number and occurrence index)
        Dim exclusions As New Dictionary(Of String, List(Of Tuple(Of Integer, Integer))) From {
        {"services", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(2, 2)}}, ' Example: exclude 2nd occurrence on line 2 for "services" - line number is the first number 
        {"temp", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(3, 2)}},
        {"downloads", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(4, 2)}},
        {"cookies", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(5, 2)}},
        {"cache", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(6, 2)}},
        {"logs", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(7, 2)}},
        {"wvds", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(8, 2)}},
        {"cert", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(35, 2)}},
        {"iplayer", New List(Of Tuple(Of Integer, Integer)) From {Tuple.Create(35, 1)}}
        }

        ' Save the current selection
        Dim originalSelectionStart As Integer = Config.rtbConfig.SelectionStart
        Dim originalSelectionLength As Integer = Config.rtbConfig.SelectionLength
        Dim originalColor As Color = Config.rtbConfig.SelectionColor
        Dim originalFont As Font = Config.rtbConfig.SelectionFont

        ' Loop through each word and apply the color
        For Each kvp As KeyValuePair(Of String, Color) In wordsToHighlight
            Dim word As String = kvp.Key
            Dim color As Color = kvp.Value

            ' Start from the beginning of the text
            Config.rtbConfig.SelectionStart = 0
            Config.rtbConfig.SelectionLength = 0
            Config.rtbConfig.SelectionColor = Config.rtbConfig.ForeColor
            Config.rtbConfig.SelectionFont = Config.rtbConfig.Font
            ' Find and highlight all occurrences of the word, excluding specified instances
            Dim startIndex As Integer = 0
            Dim occurrenceCount As Integer = 0
            While startIndex < Config.rtbConfig.TextLength
                startIndex = Config.rtbConfig.Find(word, startIndex, RichTextBoxFinds.None)
                If startIndex = -1 Then Exit While

                ' Get the line number for the current occurrence
                Dim lineIndex As Integer = Config.rtbConfig.GetLineFromCharIndex(startIndex)

                ' Increment the occurrence count for this word on the current line
                occurrenceCount += 1

                ' Check if the current occurrence should be excluded
                If exclusions.ContainsKey(word) AndAlso exclusions(word).Any(Function(t) t.Item1 = lineIndex + 1 AndAlso t.Item2 = occurrenceCount) Then
                    startIndex += word.Length
                    Continue While
                End If

                ' Highlight and bold the word

                Config.rtbConfig.SelectionStart = startIndex
                Config.rtbConfig.SelectionLength = word.Length
                Config.rtbConfig.SelectionColor = color
                Config.rtbConfig.SelectionFont = New Font(Config.rtbConfig.Font, FontStyle.Bold)
                startIndex += word.Length
            End While
        Next

        ' Restore the original selection
        Config.rtbConfig.SelectionStart = originalSelectionStart
        Config.rtbConfig.SelectionLength = originalSelectionLength
        Config.rtbConfig.SelectionColor = originalColor
        Config.rtbConfig.SelectionFont = originalFont
    End Sub

    Private Sub OpenConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenConfigFileToolStripMenuItem.Click
        ' Open Config File
        ' Construct the path to the devine.yaml file in the %LOCALAPPDATA%\devine directory
        Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim devineYamlPath As String = Path.Combine(localAppDataPath, "devine", "devine.yaml")

        ' Check if the file exists
        If File.Exists(devineYamlPath) Then
            ' Read the content of the devine.yaml file
            Dim yamlContent As String = File.ReadAllText(devineYamlPath)

            ' Display the content in the RichTextBox or handle it as needed
            Config.rtbConfig.Text = yamlContent

            ' Highlight specific words
            HighlightWords()

            Config.Show()
        Else
            ' Display an error message if the file doesn't exist
            MessageBox.Show("The devine.yaml file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HolaListCountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolaListCountriesToolStripMenuItem.Click
        ' List current Hola proxy countries

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then

            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k hola-proxy -list-countries"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HolaVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolaVersionToolStripMenuItem.Click
        ' List current Hola version

        ' Load the saved folder path from application settings
        Form2.TBfolder.Text = My.Settings.FolderPath

        ' Get the folder path from TBfolder.Text
        Dim folderPath As String = Form2.TBfolder.Text

        ' Check if the folder path exists
        If System.IO.Directory.Exists(folderPath) Then

            ' Start a new Command Prompt process
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"

            ' Set the working directory for the Command Prompt process
            process.StartInfo.WorkingDirectory = folderPath

            ' Construct the complete command with quoted TextBox value
            process.StartInfo.Arguments = $"/k hola-proxy -version"

            ' Start the process
            process.Start()

        Else
            ' Display an error message if the folder path doesn't exist
            MessageBox.Show("Please set your Devine folder location in Options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ThreeNowNZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThreeNowNZToolStripMenuItem.Click
        'Open Three Now NZ

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.threenow.co.nz/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub DisneyPlusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisneyPlusToolStripMenuItem.Click
        'Open Disney Plus

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://www.disneyplus.com/"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub

    Private Sub VideoForumThreadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VideoForumThreadToolStripMenuItem.Click
        'Open DevineGUI GitHub

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = "https://github.com/billybanana80/DevineGUI"
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()
    End Sub
End Class
