﻿Public Class ModContent

    Public Sub ListContent(VermintideMod As VermintideMod)
        TreeView1.Nodes.Clear()

        Dim root As TreeNode = TreeView1.Nodes.Add(VermintideMod.mod_name, VermintideMod.mod_name)
        root.ImageIndex = 4
        root.SelectedImageIndex = 4
        root.StateImageIndex = 4
        root.ContextMenuStrip = ContextMenuStrip1
        root.Tag = VermintideMod.path
        For Each Content As String In VermintideMod.content
            'Debug.Print(Content)
            Dim _content As List(Of String) = Content.Split("/").ToList
            Dim p As TreeNode = Nothing
            For Each c As String In _content
                If Not String.IsNullOrEmpty(c) Then
                    Dim Node As TreeNode

                    Dim nodes As TreeNode() = TreeView1.Nodes.Find(c, True)
                    If nodes.Count > 0 Then
                        Node = nodes(0)
                    Else
                        If IsNothing(p) Then
                            Node = root.Nodes.Add(c, c)
                        Else
                            Node = p.Nodes.Add(c, c)
                        End If

                    End If

                    Dim img_index As Integer = 0
                    If InStr(c, ".lua") Then
                        img_index = 1
                    ElseIf InStr(c, ".bat") Then
                        img_index = 3
                    ElseIf InStr(c, ".") Then
                        img_index = 2
                    End If
                    Node.ImageIndex = img_index
                    Node.SelectedImageIndex = img_index
                    Node.StateImageIndex = img_index
                    Node.Tag = Content.ToString
                    If img_index > 0 Then Node.ContextMenuStrip = ContextMenuStrip1

                    p = Node

                End If
            Next
        Next

        TreeView1.ExpandAll()
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node
        End If
    End Sub

    Private Sub OpenContent()
        If Not IsNothing(TreeView1.SelectedNode) Then
            Dim path As String = TreeView1.Nodes(0).Tag
            If My.Computer.FileSystem.FileExists(path) Then
                Debug.Print(path)
                ModHelper.OpenFile(path, TreeView1.SelectedNode.Tag)
                'Dim file As String = String.Format("{1}", PathHelper.Mods, TreeView1.SelectedNode.Tag)
                'Debug.Print(file)
            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenContent()
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        If Not IsNothing(e.Node.ContextMenuStrip) Then OpenContent()
    End Sub

End Class