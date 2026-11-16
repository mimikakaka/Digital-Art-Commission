Imports System.Configuration

' Shared MySQL connection settings for the application.
Module DatabaseConfig
    Public ReadOnly Property ConnectionString As String
        Get
            Dim configured As ConnectionStringSettings =
                ConfigurationManager.ConnectionStrings("DigitalArtDatabase")
            If configured Is Nothing OrElse String.IsNullOrWhiteSpace(configured.ConnectionString) Then
                Throw New ConfigurationErrorsException(
                    "The DigitalArtDatabase connection string is missing from App.config.")
            End If
            Return configured.ConnectionString
        End Get
    End Property
End Module
