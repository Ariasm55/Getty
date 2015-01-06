Imports MySql.Data.MySqlClient

Module moduleExample

    Public sqlcon2 As New MySqlConnection("server=" & srv_ip & ";Database=" & srv_db & ";User ID=" & srv_root & ";Password=" & srv_dbpass & ";")

    Public Function exConnection()
        Try
            sqlcon2.Open()
            sqlcon2.Close()
            sqlcon2.Dispose()
            MsgBox("WOW!")
            Return True
        Catch ex As Exception
            MsgBox("Can't connect to server.", vbCritical, "System Message")
            Return False
        End Try
    End Function

End Module
