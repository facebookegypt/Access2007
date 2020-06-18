Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports CrystalDecisions.Shared

Public Class CrystalForm
    Dim cryRpt As New ReportDocument
    Dim crtableLogoninfos As New TableLogOnInfos
    Dim crtableLogoninfo As New TableLogOnInfo
    Dim crConnectionInfo As New ConnectionInfo
    Dim CrTables As Tables
    Dim CrTable As Table
    Private Sub CrystlalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CMDSelect As String = ("SELECT * FROM BasicInfo LEFT JOIN MaritalStatus ON MaritalStatus.MStatusID = BasicInfo.MStatusID " &
                "ORDER BY BasicInfo.UserID ASC")
        Try
            Using DT As New DataTable
                Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
                    CN.Open()
                    Using DataAdapt As New OleDbDataAdapter(CMDSelect, CN)
                        DataAdapt.Fill(DT)
                    End Using
                End Using
                cryRpt.Load(Application.StartupPath & "\MyInfo.rpt")
                AssignConnection(cryRpt)
                cryRpt.SetDataSource(DT)
                CrystalReportViewer1.ReportSource = cryRpt
            End Using
        Catch ex As EngineException
            MsgBox("Report Load Error : " & ex.Message)
        End Try
    End Sub
    Private Sub AssignConnection(rpt As ReportDocument)
        Try
            Dim ThisConnection As New ConnectionInfo()
            With ThisConnection
                .DatabaseName = ""    'When using OleDB, you need to use Blank value here
                .ServerName = ""      'When using OleDB, you need to use Blank value here
                .UserID = "admin"
                .Password = "evry1falls"
            End With
            ' First we assign the connection to all tables in the main report
            For Each table As Table In rpt.Database.Tables  'CrystalDecisions.CrystalReports.Engine
                AssignTableConnection(table, ThisConnection)
            Next
            ' Now loop through all the sections and its objects to do the same for the subreports
            For Each section As Section In rpt.ReportDefinition.Sections    'CrystalDecisions.CrystalReports.Engine
                ' In each section we need to loop through all the reporting objects
                For Each reportObject As ReportObject In section.ReportObjects  'CrystalDecisions.CrystalReports.Engine
                    If reportObject.Kind = ReportObjectKind.SubreportObject Then
                        Dim subReport As SubreportObject = DirectCast(reportObject, SubreportObject)
                        Dim subDocument As ReportDocument = subReport.OpenSubreport(subReport.SubreportName)
                        For Each table As Table In subDocument.Database.Tables  'CrystalDecisions.CrystalReports.Engine
                            AssignTableConnection(table, ThisConnection)
                        Next
                        subDocument.SetDatabaseLogon(ThisConnection.UserID,
                                                     ThisConnection.Password,
                                                     ThisConnection.ServerName,
                                                     ThisConnection.DatabaseName)
                    End If
                Next
            Next
            rpt.SetDatabaseLogon(ThisConnection.UserID,
                                 ThisConnection.Password,
                                 ThisConnection.ServerName,
                                 ThisConnection.DatabaseName)
        Catch ex As EngineException
            MsgBox("Load Report Error : " & ex.Message)
        End Try
    End Sub
    Private Sub AssignTableConnection(ByVal table As Table, ByVal connection As ConnectionInfo)
        Try
            ' Cache the logon info block
            Dim logOnInfo As TableLogOnInfo = table.LogOnInfo
            connection.Type = logOnInfo.ConnectionInfo.Type
            ' Set the connection
            logOnInfo.ConnectionInfo = connection
            ' Apply the connection to the table!
            With table.LogOnInfo.ConnectionInfo
                .DatabaseName = connection.DatabaseName
                .ServerName = connection.ServerName
                .UserID = connection.UserID
                .Password = connection.Password
                .Type = connection.Type
            End With
            table.ApplyLogOnInfo(logOnInfo)
        Catch ex As EngineException
            MsgBox("Load Table Error : " & ex.Message)
        End Try
    End Sub
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub CrystalForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub
End Class