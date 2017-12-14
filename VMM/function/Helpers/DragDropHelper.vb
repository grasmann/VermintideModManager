Imports System.Text
Imports System.Runtime.InteropServices

Namespace Utilities
    Public Class ElevatedDragDropManager
        Implements IMessageFilter

#Region "P/Invoke"
        <DllImport("user32.dll")>
        Private Shared Function ChangeWindowMessageFilterEx(hWnd As IntPtr, msg As UInteger, action As ChangeWindowMessageFilterExAction, ByRef changeInfo As CHANGEFILTERSTRUCT) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")>
        Private Shared Function ChangeWindowMessageFilter(msg As UInteger, flags As ChangeWindowMessageFilterFlags) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("shell32.dll")>
        Private Shared Sub DragAcceptFiles(hwnd As IntPtr, fAccept As Boolean)
        End Sub

        <DllImport("shell32.dll")>
        Private Shared Function DragQueryFile(hDrop As IntPtr, iFile As UInteger, <Out()> lpszFile As StringBuilder, cch As UInteger) As UInteger
        End Function

        <DllImport("shell32.dll")>
        Private Shared Function DragQueryPoint(hDrop As IntPtr, ByRef lppt As POINT) As Boolean
        End Function

        <DllImport("shell32.dll")>
        Private Shared Sub DragFinish(hDrop As IntPtr)
        End Sub

        <StructLayout(LayoutKind.Sequential)>
        Private Structure POINT
            Public X As Integer
            Public Y As Integer

            Public Sub New(newX As Integer, newY As Integer)
                X = newX
                Y = newY
            End Sub

            Public Shared Widening Operator CType(p As POINT) As Drawing.Point
                Return New Drawing.Point(p.X, p.Y)
            End Operator

            Public Shared Widening Operator CType(p As Drawing.Point) As POINT
                Return New POINT(p.X, p.Y)
            End Operator
        End Structure

        Private Enum MessageFilterInfo As UInteger
            None
            AlreadyAllowed
            AlreadyDisAllowed
            AllowedHigher
        End Enum

        Private Enum ChangeWindowMessageFilterExAction As UInteger
            Reset
            Allow
            Disallow
        End Enum

        Private Enum ChangeWindowMessageFilterFlags As UInteger
            Add = 1
            Remove = 2
        End Enum

        <StructLayout(LayoutKind.Sequential)>
        Private Structure CHANGEFILTERSTRUCT
            Public cbSize As UInteger
            Public ExtStatus As MessageFilterInfo
        End Structure
#End Region

        Public Shared Instance As New ElevatedDragDropManager()
        Public Event ElevatedDragDrop As EventHandler(Of ElevatedDragDropArgs)

        Private Const WM_DROPFILES As UInteger = &H233
        Private Const WM_COPYDATA As UInteger = &H4A
        Private Const WM_COPYGLOBALDATA As UInteger = &H49

        Private ReadOnly IsVistaOrHigher As Boolean = Environment.OSVersion.Version.Major >= 6
        Private ReadOnly Is7OrHigher As Boolean = (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 1) OrElse Environment.OSVersion.Version.Major > 6

        Protected Sub New()
            Application.AddMessageFilter(Me)
        End Sub

        Public Sub EnableDragDrop(hWnd As IntPtr)
            If Is7OrHigher Then
                Dim changeStruct As New CHANGEFILTERSTRUCT()
                changeStruct.cbSize = CUInt(Marshal.SizeOf(GetType(CHANGEFILTERSTRUCT)))
                ChangeWindowMessageFilterEx(hWnd, WM_DROPFILES, ChangeWindowMessageFilterExAction.Allow, changeStruct)
                ChangeWindowMessageFilterEx(hWnd, WM_COPYDATA, ChangeWindowMessageFilterExAction.Allow, changeStruct)
                ChangeWindowMessageFilterEx(hWnd, WM_COPYGLOBALDATA, ChangeWindowMessageFilterExAction.Allow, changeStruct)
            ElseIf IsVistaOrHigher Then
                ChangeWindowMessageFilter(WM_DROPFILES, ChangeWindowMessageFilterFlags.Add)
                ChangeWindowMessageFilter(WM_COPYDATA, ChangeWindowMessageFilterFlags.Add)
                ChangeWindowMessageFilter(WM_COPYGLOBALDATA, ChangeWindowMessageFilterFlags.Add)
            End If

            DragAcceptFiles(hWnd, True)
        End Sub

        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            If m.Msg = WM_DROPFILES Then
                HandleDragDropMessage(m)
                Return True
            End If

            Return False
        End Function

        Private Sub HandleDragDropMessage(m As Message)
            Dim sb = New StringBuilder(260)
            Dim numFiles As UInteger = DragQueryFile(m.WParam, &HFFFFFFFFUI, sb, 0)
            Dim list = New List(Of String)()

            For i As UInteger = 0 To numFiles - 1
                If DragQueryFile(m.WParam, i, sb, CUInt(sb.Capacity) * 2) > 0 Then
                    list.Add(sb.ToString())
                End If
            Next

            Dim p As POINT
            DragQueryPoint(m.WParam, p)
            DragFinish(m.WParam)

            Dim args = New ElevatedDragDropArgs()
            args.HWnd = m.HWnd
            args.Files = list
            args.X = p.X
            args.Y = p.Y

            RaiseEvent ElevatedDragDrop(Me, args)
        End Sub
    End Class

    Public Class ElevatedDragDropArgs
        Inherits EventArgs
        Public Property HWnd() As IntPtr
            Get
                Return m_HWnd
            End Get
            Set(value As IntPtr)
                m_HWnd = value
            End Set
        End Property
        Private m_HWnd As IntPtr
        Public Property Files() As List(Of String)
            Get
                Return m_Files
            End Get
            Set(value As List(Of String))
                m_Files = value
            End Set
        End Property
        Private m_Files As List(Of String)
        Public Property X() As Integer
            Get
                Return m_X
            End Get
            Set(value As Integer)
                m_X = value
            End Set
        End Property
        Private m_X As Integer
        Public Property Y() As Integer
            Get
                Return m_Y
            End Get
            Set(value As Integer)
                m_Y = value
            End Set
        End Property
        Private m_Y As Integer

        Public Sub New()
            Files = New List(Of String)()
        End Sub
    End Class
End Namespace
