<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cursosvirtuales.Views.Public.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login</title>
    <link href="../../Content/css/Loginstyle.css" rel="stylesheet" />
</head>
<body >
    <ext:ResourceManager runat="server" Theme="Crisp" />
    <ext:Viewport runat="server"  Layout="Fit">
        <Items>
            <ext:Panel runat="server" BodyCls="borderLayer">
                <LayoutConfig>
                    <ext:CenterLayoutConfig DefaultValueMode="RenderExplicit" />
                </LayoutConfig>
                     <Items>
            <ext:FormPanel  runat="server"  Width="490"  Height="330"  BodyPadding="10"  Frame="true" UI="Info" DefaultAnchor="100%">
                <Items>
                    <ext:Panel runat="server">
                        <Items>
                            <ext:FieldSet runat="server" Title="Sistema de Cursos Virtuales" Cls="titleLogin" BaseCls="titleLogin"  >
                                <Items>
                                    <ext:Panel ID="PDESCRIPCION" runat="server">
                                        <Items>
                                            <ext:ToolbarSpacer runat="server" Height="10" />
                                            <ext:Label runat="server" Text=" Por favor, inicie sesión con su nombre de usuario y su contraseña . Pulse 'Acceder' cuando esté listo." Cls="descriptionLogin" />
                                            <ext:ToolbarSpacer runat="server" Height="10" />
                                            <ext:Label runat="server" Text="¿No tiene una cuenta todavía? regístrese  " Cls="descriptionLogin" />
                                            <ext:Hyperlink runat="server" Icon="UserGo"  IconAlign="Left" Target="_blank" NavigateUrl="Estudiante.aspx" Text="Aqui" Cls="linkRegister" />
                                            <ext:ToolbarSpacer runat="server" Height="20" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:FormPanel ID="FLOGIN" runat="server">
                                        <Items>
                                            <ext:TextField runat="server" FieldLabel="Usuario" ID="TUSUARIO" Width="330" Cls="nickLogin" AllowBlank="false" />
                                            <ext:TextField runat="server" AllowBlank="false" FieldLabel="Contraseña" ID="TPASSWORD" InputType="Password" Flex="3" Width="330" Cls="nickLogin" />
                                            <ext:ToolbarSpacer runat="server" Height="10" />
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:Image runat="server" ImageUrl="../../Content/img/BorderLogin.png" Height="70" />
                                </Items>
                            </ext:FieldSet>
                           <ext:ToolbarSpacer runat="server" Height="3" />
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Acceder" Icon="Key"  UI="Success" >
                        <Listeners>
                            <Click Handler="if(App.FLOGIN.isValid()){ App.direct.ingresarUsuario(
                                                App.TUSUARIO.getValue(),
                                                App.TPASSWORD.getValue());
                                            }else{
                                               Ext.Msg.info({ui: 'danger', title: 'Advertencia', html: 'Usuario o Contraseña nula', iconCls: '#Exclamation'});
                                            } " />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
            </ext:Panel>
        </Items>
   
    </ext:Viewport>
</body>
</html>

