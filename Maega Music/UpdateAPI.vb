Module UpdateAPI

    'Software: Maega Innovation Hub
    'Module: UpdateAPI.vb
    'Description: Update Backend for Maega Products
    'Developer: Tristan Gauci
    'Organisation: Maega

    Public Const AppID As String = "4"
    Public Const CurrentVer As Decimal = 1.01
    Public Const AppName As String = "Maega Muse"

    Public Const RegLoc As String = "HKEY_CURRENT_USER\Software\Maega\" + AppID + "\"
    Public Const MIHLoc As String = "HKEY_CURRENT_USER\Software\Maega\2\" '2 is the ID of MIH
    Dim rapp As String, rupdate As String, rforce As String, rverify As Decimal, appindex As Integer, rcalc As Decimal, rmessage As String = Nothing, rlver As Decimal, rfname As String, regverval As String
    Dim verified As Boolean = False
    Dim vericode As String
    Dim verifyfactor As Decimal = 7.38
    Dim apiserver As String = "https://update.maeganetwork.com/api.php" 'This should point to the API backend on the update server
    Function LatestVer()
        PerformCheck(appid)
        If verified = True Then
            Return CDec(rlver)
        Else
            MsgBox("Server verification failed. The connection to the update server may have been tampered with.", MsgBoxStyle.Critical)
            Exit Function
        End If
    End Function

    Sub PerformCheck(appid As String)
        Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + " - " + "Info: Performing Update Check")
        'Generate a 7 digit validation code.
        vericode = String.Empty
        Dim AllowedChars() As String = {"0123456789"}
        Dim rnd = New Random()
        While vericode.Length < 8
            Dim rndSet As Integer = rnd.Next(0, AllowedChars.Length)
            vericode &= AllowedChars(rndSet).Substring(rnd.Next(0, AllowedChars(rndSet).Length), 1)
        End While

        'Create query and submit
        Dim apiquery As String = "?app=" + appid.ToLower + "&verify=" + vericode

        Try
            Dim apiresponse As String = New System.Net.WebClient().DownloadString(apiserver + apiquery)
            'Check API response for errors
            If apiresponse.Contains("MISSINGAPPCODE") Then
                'This should never happen - it means the API query is missing the ?app value
                MsgBox("The app code is missing. Something has gone very wrong. Please check the application source code.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf apiresponse.Contains("MISSINGVERCODE") Then
                'This should also never happen - it means the API query is missing the ?ver value
                MsgBox("The version code is missing. Something has gone very wrong. Please check the application source code.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf apiresponse.Contains("MISSINGVERIFYCODE") Then
                'This too, should never happen - it means the API query is missing the ?verify value
                MsgBox("The verification code is missing. Something has gone very wrong. Please check the application source code.", MsgBoxStyle.Critical)
                Exit Sub
            ElseIf apiresponse.Contains("INVALIDAPPCODE") Then
                MsgBox("The API doesn't recognise the app name you provided.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Set variables according to the API response - removes the response headers and sets variables to the corresponding responses.
            appindex = apiresponse.IndexOf("APP=")
            rapp = apiresponse.Substring(appindex + 4, apiresponse.IndexOf(";", appindex + 1) - appindex - 4)
            appindex = apiresponse.IndexOf("LVER=")
            rlver = apiresponse.Substring(appindex + 5, apiresponse.IndexOf(";", appindex + 1) - appindex - 5)
            appindex = apiresponse.IndexOf("FNAME=")
            rfname = apiresponse.Substring(appindex + 6, apiresponse.IndexOf(";", appindex + 1) - appindex - 6)
            If apiresponse.Contains("MESSAGE=") Then
                appindex = apiresponse.IndexOf("MESSAGE=")
                rmessage = apiresponse.Substring(appindex + 8, apiresponse.IndexOf(";", appindex + 1) - appindex - 8)
            End If
            appindex = apiresponse.IndexOf("VERIFY=")
            'Convert the verification code to decimal and truncate to no decimal places
            rverify = Math.Truncate(CDec(apiresponse.Substring(appindex + 7, apiresponse.IndexOf(";", appindex + 1) - appindex - 7)))
            'Perform arithmetic verification operation
            rcalc = Math.Truncate(CDec(vericode) / verifyfactor)
            'Check if the arithmetic operation performed on the server matches the one performed locally, if it does, set the 'verified' boolean to True
            If rcalc = rverify Then verified = True
            If Not rmessage = Nothing And rupdate = 1 Then
                'This is where we would output the message pulled from the server.
                'Main.News.Text = rmessage
                'Main.News.Text = Main.News.Text.Replace("/\", vbNewLine)
            End If
            'Set rmessage back to nothing in case the next query doesn't contain a message; if it doesn't, and this wasn't here, the application would output "Message: ". Likewise do the same for the 'verified' boolean
            'rmessage = Nothing
            'verified = False
        Catch ex As Exception
            MsgBox("We weren't able to connect to the update servers. Please check your connection and try again later.", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub
End Module