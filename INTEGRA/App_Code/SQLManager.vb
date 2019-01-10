'**************************************************************************************
'*      Class Name         :    SQLManager.vb
'*      Class Description  :    Provided Data Access Functionality
'*      Core Table         :    N/A
'**************************************************************************************

Imports System.Data
Imports System.Data.SqlClient ' To Use SQL 
Imports System.ComponentModel ' To Use Type Descriptor class
Imports System.Xml
Imports System.IO

Public MustInherit Class SQLManager

    ' Declare and Initializes Global variables
    'Dim conMain As String = ConfigurationSettings.AppSettings("ConMain")
    'Dim conUsers As String = ConfigurationSettings.AppSettings("ConUsers")
    'Dim conDoctors As String = ConfigurationSettings.AppSettings("ConDoctors")

    ' Declare Enumerators

    Public Enum DataTypes
        ByteType = 1
        ShortType = 2
        IntegerType = 3
        LongType = 4
        DecimalType = 5
        CharType = 6
        StringType = 7
        DateType = 8
    End Enum

    Public Enum StatusTypes
        InActive = 0
        Active = 1
        All = 2
    End Enum

    Public DatabaseDefaultDate As DateTime = DateTime.Now   '#1/1/1900 12:01:00 AM#
    

    'Decalare member varables
    Protected m_strPrimaryFieldName As String
    Protected m_strTableName As String
    Protected m_enPrimaryFieldDataType As DataTypes


    ' The function returns the table name of current class
    Private Function GetTableName() As String
        'Just return the value of member variable which is filled from child class
        Return m_strTableName
    End Function

    ' The function returns the Primary Field Name of the table
    Private Function GetPrimaryFieldName() As String
        'Just return the value of member variable which is filled from child class
        Return m_strPrimaryFieldName
    End Function

    ' The function returns the PrimaryId of table of the current class
    Private Function GetId() As Long
        'Get the collection of all properties in the Property Descriptor Collection
        Dim colProperties As PropertyDescriptorCollection = GetProperties()

        'Get the value of Primary field of the Current record
        Return colProperties.Item(m_strPrimaryFieldName).GetValue(Me)

    End Function

    ' The function returns the Collection of the properties of the current class
    Private Function GetProperties() As PropertyDescriptorCollection
        Return TypeDescriptor.GetProperties(Me)
    End Function

    ' Procedure that Opens a connection for particular database
    Private Sub OpenConnection(ByRef objSqlConnection As SqlConnection)

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
        'Dim strConnection As String = System.Configuration.ConfigurationSettings.AppSettings("dbConnection")

        objSqlConnection.ConnectionString = strConnection
        objSqlConnection.Open()

    End Sub
    Private Sub ClosedConnection(ByRef objSqlConnection As SqlConnection)

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString


        objSqlConnection.ConnectionString = strConnection
        objSqlConnection.Close()

    End Sub
    ' Function thar returns the Data Table after executing a particular query
    Protected Function GetDataTable(ByVal strSql As String) As DataTable

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim objDataTable As New DataTable()
        Dim objSqlDataAdapter As SqlDataAdapter

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = New SqlCommand(strSql, objSqlConnection)
            objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
            objSqlCommand.CommandTimeout = 5000
            objSqlDataAdapter.Fill(objDataTable)
            Return objDataTable
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
         
            objSqlConnection.Close()
        End Try

    End Function

    ' Function thar returns the Data Reader after executing a particular query
    Protected Function GetDataReader(ByVal strSql As String) As SqlDataReader

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim objSqlDataReader As SqlDataReader

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = New SqlCommand(strSql, objSqlConnection)
            objSqlDataReader = objSqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
        End Try

        Return objSqlDataReader
    End Function
   
    Protected Function GetScaler(ByVal strSql As String) As String

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim strReturned As String

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = New SqlCommand(strSql, objSqlConnection)
            strReturned = objSqlCommand.ExecuteScalar()
            objSqlConnection.Close()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally

        End Try

        Return strReturned
    End Function

    ' Function thar returns the Data Reader after executing a particular query
    Protected Overloads Function IsRecordExists(ByVal strFieldName As String, ByVal enDataType As DataTypes, _
                                        ByVal strValueToCompare As String) As Boolean

        ' Declare Objects locally
        Dim strSql As String
        Dim objDataTable As New DataTable()

        Try
            strSql = "Select * from " & Me.GetTableName & " where " & strFieldName & " = "

            If enDataType = DataTypes.StringType Or enDataType = DataTypes.DateType Then
                strSql = strSql & "'" & strValueToCompare & "'"
            Else
                strSql = strSql & strValueToCompare
            End If

            objDataTable = GetDataTable(strSql)
            If objDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try

    End Function

    ' Function thar returns the Data Reader after executing a particular query
    Protected Overloads Function IsRecordExists(ByVal strSql As String) As Boolean

        ' Declare Objects locally
        Dim objDataTable As New DataTable()

        Try
            objDataTable = GetDataTable(strSql)
            If objDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try

    End Function

    ' Function thar returns the Data Reader after executing a particular query
    Protected Function GetCurrentId(Optional ByVal strTableName As String = "") As Long

        ' Declare Objects locally
        Dim objDataTable As New DataTable()
        Dim strSql As String

        Try
            If strTableName = "" Then
                strTableName = GetTableName()
            End If
            ' Define the query for getting newly added Id
            strSql = "Select IDENT_CURRENT('" & strTableName & "') "
            objDataTable = GetDataTable(strSql)
            If objDataTable.Rows.Count > 0 Then
                Return objDataTable.Rows(0).Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try

    End Function

    ' Procedure that executes particular query without returning any value
    Protected Sub ExecuteNonQuery(ByVal strSql As String)

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
         Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = New SqlCommand(strSql, objSqlConnection)
            objSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try

    End Sub

    ' Function that executes particular Stored Procedure and returns a boolean
    Protected Function ExecuteScalarStoredProcedure(ByVal strStoredProcedureName As String, ByVal objSqlParameter() As SqlParameter) As Boolean

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim bIsExist As Boolean
        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = SetSQLCommand(strStoredProcedureName, objSqlParameter, objSqlConnection)
            objSqlCommand.ExecuteScalar()
            bIsExist = objSqlCommand.Parameters.Item(objSqlCommand.Parameters.Count - 1).Value
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try
        Return bIsExist

    End Function

    ' Function that executes particular Stored Procedure and returns a boolean
    Protected Function strExecuteScalarStoredProcedure(ByVal strStoredProcedureName As String, ByVal objSqlParameter() As SqlParameter) As String

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim strReturn As String

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = SetSQLCommand(strStoredProcedureName, objSqlParameter, objSqlConnection)
            objSqlCommand.ExecuteScalar()
            strReturn = objSqlCommand.Parameters.Item(objSqlCommand.Parameters.Count - 1).Value
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try
        Return strReturn

    End Function

    ' Function that executes particular Stored Procedure and returns a datatable
    Protected Overloads Function ExecuteStoredProcedure(ByVal strStoredProcedureName As String, ByVal objSqlParameter() As SqlParameter) As DataTable

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim objSqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
        Dim objDataTable As New DataTable()

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = SetSQLCommand(strStoredProcedureName, objSqlParameter, objSqlConnection)
            objSqlDataAdapter.SelectCommand = objSqlCommand
            objSqlDataAdapter.Fill(objDataTable)
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally

            objSqlConnection.Close()
        End Try
        Return objDataTable

    End Function

    '****************************************************************************************************
    'This function is called to Execute a Stored Procedure to return a Set of Result in form of DataTable
    '****************************************************************************************************
    Public Overloads Function ExecuteStoredProcedure(ByRef colParameters As Collections.ArrayList, ByVal strStoredProcedureName As String) As DataTable

        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        ' Declare SqlParameter Object
        Dim objSqlParameter As SqlParameter
        'Declare SQL Dat aAdapter
        Dim objDataAdapter As SqlDataAdapter = New SqlDataAdapter()
        'Declare DataTable
        Dim objDataTable As New DataTable()
        'Declaring Local Variables
        Dim nIndex As Integer

        Try
            Me.OpenConnection(objSqlConnection)
            ' Instantiate the Command Object
            objSqlCommand = New SqlCommand(strStoredProcedureName, objSqlConnection)

            'Set the Command Timeout
            objSqlCommand.CommandTimeout = 900

            'Command to be Executed is Stored Procedure
            objSqlCommand.CommandType = CommandType.StoredProcedure

            'Add all the Sql Parameters in the Parameter Collection of Command Object
            For Each objSqlParameter In colParameters
                objSqlCommand.Parameters.Add(objSqlParameter)
            Next

            'Give command object to Data Adapter
            objDataAdapter.SelectCommand = objSqlCommand
            'Fill the data table by executing command
            objDataAdapter.Fill(objDataTable)

        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try

        ' Returns the DataTable Object as the Return value of the Function
        Return objDataTable

    End Function

    ' Function that executes particular Stored Procedure and returns a XML String
    Protected Function ExecuteXMLStoredProcedure(ByVal strStoredProcedureName As String, ByVal objSqlParameter() As SqlParameter) As XmlDocument

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        Dim objSqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
        Dim objDataSet As New DataSet()
        Dim ObjXmlDoc As New XmlDocument()
        Dim objXMLReader As XmlTextReader
        Dim objXMLTextWriter As XmlTextWriter
        Dim objStringWriter As StringWriter
        Dim strXMLResult As String

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = SetSQLCommand(strStoredProcedureName, objSqlParameter, objSqlConnection)
            'objSqlDataAdapter.SelectCommand = objSqlCommand
            'objSqlDataAdapter.Fill(objDataTable)
            objXMLReader = objSqlCommand.ExecuteXmlReader

            'Initialize the text reader 
            objStringWriter = New StringWriter()
            objXMLTextWriter = New XmlTextWriter(objStringWriter)

            'Write the document element and root node etc etc.
            objXMLTextWriter.WriteStartDocument()
            objXMLTextWriter.WriteStartElement("RootNode", "")

            'Get the result raw XML into a string.
            While (Not objXMLReader.EOF)
                objXMLReader.MoveToContent()
                objXMLTextWriter.WriteNode(objXMLReader, False)
            End While
            objXMLReader.Close()

            'Write the end of the document
            objXMLTextWriter.WriteEndElement()
            objXMLTextWriter.WriteEndDocument()

            'Close the XmlTextWriter
            objXMLTextWriter.Close()
            strXMLResult = objStringWriter.ToString()

            'Load the xmldocument
            ObjXmlDoc.LoadXml(strXMLResult)
            'objDataSet.ReadXml(objXMLReader, XmlReadMode.Fragment)
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try
        Return ObjXmlDoc

    End Function

    ' Function that executes particular Stored Procedure and Inserts new record
    Protected Function ExecuteNonQuery(ByVal strStoredProcedureName As String, ByVal objSqlParameter() As SqlParameter)

        ' Declare Objects locally
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand

        Try
            Me.OpenConnection(objSqlConnection)
            objSqlCommand = SetSQLCommand(strStoredProcedureName, objSqlParameter, objSqlConnection)
            objSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try

    End Function

    ' Function that sets the command object values
    Private Function SetSQLCommand(ByVal strStoredProcedureName As String, ByRef objSqlParameter() As SqlParameter, ByRef objSqlConnection As SqlConnection) As SqlCommand

        ' Declare Objects locally
        Dim objSqlCommand As SqlCommand = New SqlCommand()
        Dim nCounter As Int16


        objSqlCommand.Connection = objSqlConnection
        objSqlCommand.CommandType = CommandType.StoredProcedure
        objSqlCommand.CommandText = strStoredProcedureName
        Try
            If Not (objSqlParameter Is Nothing) Then
                For nCounter = 0 To objSqlParameter.Length - 1
                    objSqlCommand.Parameters.Add(objSqlParameter(nCounter))
                Next
            End If
            Return objSqlCommand
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Function

    ' The function that Add / Edit the single Object contents to the database
    Protected Overridable Function Save()

        'Declaring local Objects & Variables
        Dim objDataTable As New DataTable()
        Dim objDataRow As DataRow
        Dim objSqlConnection As New SqlConnection()
        Dim strSql As String

        Try
            ' Define a Select Query
            strSql = "Select * from " & Me.GetTableName & _
                     " where " + Me.GetPrimaryFieldName + "= " + Me.GetId().ToString

            ' Declare and Instantiate the SqlDataAdapter
            Dim objSqlDataAdapter As New SqlDataAdapter(strSql, objSqlConnection)
            ' Automatically generating single-table commands using SqlCommandBuilder
            Dim objSqlCommandBuilder As New SqlCommandBuilder(objSqlDataAdapter)

            ' Open Databse Connection
            Me.OpenConnection(objSqlConnection)
            'Fill up the Datatable with passed query
            objSqlDataAdapter.Fill(objDataTable)

            ' Check if either the Id is 0 or no rows was fetched from query
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                'Create a new row to the DataTable and assigned to objDataRow
                objDataRow = objDataTable.NewRow()
            Else
                ' Extracting the DataRow from the DataTable
                objDataRow = objDataTable.Rows(0)
            End If

            'Get the values from the properties and set to the Data Row
            GetValues(objDataTable, objDataRow)

            ' Add DataRow to the DataTable
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                objDataTable.Rows.Add(objDataRow)
            End If

            ' Update the dataset through Command            
            objSqlDataAdapter.Update(objDataTable)

        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlConnection.Close()
        End Try

    End Function

    Protected Overridable Function SaveCustomerRole()

        'Declaring local Objects & Variables
        Dim objDataTable As New DataTable()
        Dim objDataRow As DataRow
        Dim objSqlConnection As New SqlConnection()
        Dim strSql As String

        Try
            ' Define a Select Query
            strSql = "Select * from " & Me.GetTableName & _
                     " where " + Me.GetPrimaryFieldName + "= " + Me.GetId().ToString

            ' Declare and Instantiate the SqlDataAdapter
            Dim objSqlDataAdapter As New SqlDataAdapter(strSql, objSqlConnection)
            ' Automatically generating single-table commands using SqlCommandBuilder
            Dim objSqlCommandBuilder As New SqlCommandBuilder(objSqlDataAdapter)

            ' Open Databse Connection
            Me.OpenConnection(objSqlConnection)
            'Fill up the Datatable with passed query
            objSqlDataAdapter.Fill(objDataTable)

            ' Check if either the Id is 0 or no rows was fetched from query
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                'Create a new row to the DataTable and assigned to objDataRow
                objDataRow = objDataTable.NewRow()
            Else
                ' Extracting the DataRow from the DataTable
                objDataRow = objDataTable.Rows(0)
            End If

            'Get the values from the properties and set to the Data Row
            GetValues(objDataTable, objDataRow)

            ' Add DataRow to the DataTable
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                objDataTable.Rows.Add(objDataRow)
            End If

            ' Update the dataset through Command            
            objSqlDataAdapter.Update(objDataTable)

        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlConnection.Close()
        End Try

    End Function

    Protected Overridable Function SaveStyleRole()

        'Declaring local Objects & Variables
        Dim objDataTable As New DataTable()
        Dim objDataRow As DataRow
        Dim objSqlConnection As New SqlConnection()
        Dim strSql As String

        Try
            ' Define a Select Query
            strSql = "Select * from " & Me.GetTableName & _
                     " where " + Me.GetPrimaryFieldName + "= " + Me.GetId().ToString

            ' Declare and Instantiate the SqlDataAdapter
            Dim objSqlDataAdapter As New SqlDataAdapter(strSql, objSqlConnection)
            ' Automatically generating single-table commands using SqlCommandBuilder
            Dim objSqlCommandBuilder As New SqlCommandBuilder(objSqlDataAdapter)

            ' Open Databse Connection
            Me.OpenConnection(objSqlConnection)
            'Fill up the Datatable with passed query
            objSqlDataAdapter.Fill(objDataTable)

            ' Check if either the Id is 0 or no rows was fetched from query
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                'Create a new row to the DataTable and assigned to objDataRow
                objDataRow = objDataTable.NewRow()
            Else
                ' Extracting the DataRow from the DataTable
                objDataRow = objDataTable.Rows(0)
            End If

            'Get the values from the properties and set to the Data Row
            GetValues(objDataTable, objDataRow)

            ' Add DataRow to the DataTable
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                objDataTable.Rows.Add(objDataRow)
            End If

            ' Update the dataset through Command            
            objSqlDataAdapter.Update(objDataTable)

        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlConnection.Close()
        End Try

    End Function


    ' The function gets any object by providing the particular Id
    Protected Overloads Function GetById(ByVal lIdToGet As Long) As Object

        'Declaring local Objects & Variables
        Dim objDataReader As SqlDataReader
        Dim strSql As String

        Try
            ' Defining Select Query
            strSql = "Select * from " & GetTableName() & " where " + GetPrimaryFieldName() + " = "

            If m_enPrimaryFieldDataType = DataTypes.StringType Or m_enPrimaryFieldDataType = DataTypes.DateType Then
                strSql = strSql & "'" & lIdToGet & "'"
            Else
                strSql = strSql & lIdToGet
            End If

            ' Get the datareader filled by above query
            objDataReader = Me.GetDataReader(strSql)

            While (objDataReader.Read)
                'Set the values to the properties getting from Datareader
                SetValues(objDataReader)
            End While


            ' Catch any error
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Function

    ' The function gets any object by providing the particular FieldName and FieldDataType
    Protected Overloads Function GetById(ByVal strSql As String) As Object

        'Declaring local Objects & Variables
        Dim objDataReader As SqlDataReader


        Try
            ' Defining Select Query
            'strSql = "Select * from " & GetTableName() & " where " + strFieldName + " = "

            'If strFieldDataType = DataTypes.StringType Or strFieldDataType = DataTypes.DateType Then
            '    strSql = strSql & "'" & strIdToGet & "'"
            'Else
            '    strSql = strSql & strIdToGet
            'End If

            ' Get the datareader filled by above query
            objDataReader = Me.GetDataReader(strSql)

            While (objDataReader.Read)
                'Set the values to the properties getting from Datareader
                SetValues(objDataReader)
            End While


            ' Catch any error
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Function

    ' Procedure that Get the values from the properties and set to the Data Row
    Private Sub GetValues(ByRef objDataTable As DataTable, ByRef objDataRow As DataRow)

        ' Declare Variables locally
        Dim nIndex As Integer
        Dim strPropertyName As String

        Try
            ' Declare and Get the Collecetion Properties
            Dim colProperties As PropertyDescriptorCollection = Me.GetProperties()

            'Traverse between Properties
            For nIndex = 0 To colProperties.Count - 1
                ' Getting property name
                strPropertyName = colProperties.Item(nIndex).Name
                ' Check for ReadOnly property
                If Not objDataTable.Columns.Item(strPropertyName).ReadOnly Then
                    'Assign property's value to DataRow
                    objDataRow(strPropertyName) = colProperties.Item(strPropertyName).GetValue(Me)
                End If
            Next
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Sub

    ' Procedure that Set the values to the properties getting from Datareader
    Private Sub SetValues(ByRef objDataReader As SqlDataReader)

        ' Declare Variables locally
        Dim nIndex As Integer
        Dim strPropertyName As String

        Try
            ' Declare and Get the Collecetion Properties
            Dim colProperties As PropertyDescriptorCollection = GetProperties()

            'Traverse between Properties
            For nIndex = 0 To colProperties.Count - 1
                ' Getting property name
                strPropertyName = colProperties.Item(nIndex).Name

                If Not System.Convert.IsDBNull(objDataReader.Item(strPropertyName)) Then
                    'Sets the value to the item of the Prperty Collection
                    colProperties.Item(nIndex).SetValue(Me, objDataReader.Item(strPropertyName))
                End If
            Next
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Sub

    ' The function that Add / Edit the single Object contents to the database
    Protected Overridable Function SaveWithoutConnection(ByRef objSqlConnection As SqlConnection)

        'Declaring local Objects & Variables
        Dim objDataTable As New DataTable
        Dim objDataRow As DataRow
        '        Dim objSqlConnection As New SqlConnection
        Dim strSql As String

        Try
            ' Define a Select Query
            strSql = "Select * from " & Me.GetTableName & _
                     " where " + Me.GetPrimaryFieldName + "= " + Me.GetId().ToString

            ' Declare and Instantiate the SqlDataAdapter
            Dim objSqlDataAdapter As New SqlDataAdapter(strSql, objSqlConnection)
            ' Automatically generating single-table commands using SqlCommandBuilder
            Dim objSqlCommandBuilder As New SqlCommandBuilder(objSqlDataAdapter)

            ' Open Databse Connection
            ' Me.OpenConnection(objSqlConnection)
            'Fill up the Datatable with passed query
            objSqlDataAdapter.Fill(objDataTable)

            ' Check if either the Id is 0 or no rows was fetched from query
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                'Create a new row to the DataTable and assigned to objDataRow
                objDataRow = objDataTable.NewRow()
            Else
                ' Extracting the DataRow from the DataTable
                objDataRow = objDataTable.Rows(0)
            End If

            'Get the values from the properties and set to the Data Row
            GetValues(objDataTable, objDataRow)

            ' Add DataRow to the DataTable
            If Me.GetId = 0 Or objDataTable.Rows.Count() = 0 Then
                objDataTable.Rows.Add(objDataRow)
            End If

            ' Update the dataset through Command            
            objSqlDataAdapter.Update(objDataTable)

        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlConnection.Close()
        End Try

    End Function


    '****************************************************************************************************
    'This function is called to Execute a Stored Procedure to Execute Qurey
    '****************************************************************************************************
    Public Overloads Function ExecuteNoQureyStoredProcedure(ByRef colParameters As Collections.ArrayList, ByVal strStoredProcedureName As String) As DataTable
        Dim objSqlConnection As New SqlConnection()
        Dim objSqlCommand As SqlCommand
        ' Declare SqlParameter Object
        Dim objSqlParameter As SqlParameter
        'Declare SQL Dat aAdapter
        Dim objDataAdapter As SqlDataAdapter = New SqlDataAdapter()
        'Declare DataTable
        Dim objDataTable As New DataTable()
        Try
            Me.OpenConnection(objSqlConnection)
            ' Instantiate the Command Object
            objSqlCommand = New SqlCommand(strStoredProcedureName, objSqlConnection)

            'Set the Command Timeout
            objSqlCommand.CommandTimeout = 900

            'Command to be Executed is Stored Procedure
            objSqlCommand.CommandType = CommandType.StoredProcedure
            'Add all the Sql Parameters in the Parameter Collection of Command Object
            For Each objSqlParameter In colParameters
                objSqlCommand.Parameters.Add(objSqlParameter)
            Next
            'Give command object to Data Adapter
            objDataAdapter.SelectCommand = objSqlCommand
            '   ' executing command
            objSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        Finally
            objSqlCommand.Dispose()
            objSqlConnection.Close()
        End Try
    End Function
End Class
