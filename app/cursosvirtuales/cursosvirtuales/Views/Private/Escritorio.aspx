<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escritorio.aspx.cs" Inherits="cursosvirtuales.Views.Escritorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Plataforma de Cursos</title>
    <link rel="shortcut icon" href="http://lineadecodigo.com/wp-content/uploads/2007/03/favicon.ico">
   
    <style type="text/css">
        /**/
	    #unlicensed{
		    display: none !important;
	    }
    </style>
     
    <script src="../../Content/js/winEscritorio.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <%--Desktop Manager--%>
   <ext:ResourceManager runat="server" Theme="Crisp" />

    <ext:Desktop runat="server" ID="Desktop1">
        <StartMenu Title="Menu" Icon="Book" Height="350" Width="350" >
            <ToolConfig>
                <ext:Toolbar runat="server" Width="130">
                    <Items>
                        <ext:Hidden ID="NombreUsuario" runat="server" />
                        <ext:Button runat="server" Text="Cerrar Sesión" Icon="Key">
                            <DirectEvents>
                                <Click OnEvent="Logout_Click">
                                    <EventMask ShowMask="true" Msg="Cerrando Sesión" MinDelay="1000" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </ToolConfig>
        </StartMenu>

        <TaskBar Dock="None" HideTray="true" HideQuickStart="false" >
         <CustomConfig>
                <ext:ConfigItem Name="startBtnText" Value="Inicio" Mode="Value" />
            </CustomConfig>
             <TrayClock Dock="Left" TimeFormat="dddd, dd \de MMMM \de yyyy  hh:mm:ss tt" RefreshInterval="1">
            </TrayClock>
            
        </TaskBar>

        <DesktopConfig Wallpaper="../../content/img/fondo.jpg" WallpaperStretch="true" ShortcutDragSelector="true" />
    </ext:Desktop>
    </form>
</body>
</html>
