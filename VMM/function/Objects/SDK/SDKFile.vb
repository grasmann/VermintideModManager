Public Class SDKFile

    Public Enum SDKFileType
        Unit
        Script
        Package
        Material
        Particles
        ShadingEnv
        VectorField
        Wwise_Dep
        Font
        MouseCursor
        Texture
        PhysicsProp
    End Enum

    Public Property Type As SDKFileType

End Class
