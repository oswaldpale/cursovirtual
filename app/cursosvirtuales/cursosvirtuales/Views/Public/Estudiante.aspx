<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" Inherits="cursosvirtuales.Views.Public.Estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 <form runat="server">
       <ext:ResourceManager runat="server" Theme="Neptune"  />
    <ext:Viewport runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
            <ext:FormPanel runat="server"  Width="650" Height="360"  Icon="User"  Title="Datos del Estudiante" BodyPadding="10" AutoScroll="true">
          
                <Items>
                    <ext:FieldSet runat="server" Title="Información Usuario" Layout="HBoxLayout" >
                        <Items>
                            <ext:Container runat="server">
                                <Items>
                                    <ext:TextField  runat="server" ID="TUSUARIO" AllowBlank="false" FieldLabel="Usuario" Flex="1" LabelWidth="110" MarginSpec="0 0 10 10" />
                                    <ext:TextField  runat="server" ID="TCORREO" AllowBlank="false" FieldLabel="Correo"  Vtype="email" Flex="1" LabelWidth="110" MarginSpec="0 0 10 10" />
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" >
                                <Items>
                                    <ext:TextField runat="server" ID="TCONTRASENA" AllowBlank="false"  FieldLabel="Contraseña" EmptyText="password" InputType="password" Flex="1" LabelWidth="110" MarginSpec="0 0 10 10" >
                                        <Listeners>
                                            <ValidityChange Handler="this.next().validate();" />
                                            <Blur Handler="this.next().validate();" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="TVERIFICACION" AllowBlank="false"  FieldLabel="Verificación" EmptyText="password" Vtype="password" InputType="password"   MsgTarget="Side" Flex="1" LabelWidth="110"  MarginSpec="0 0 10 10" >
                                        <CustomConfig>
                                            <ext:ConfigItem Name="initialPassField" Value="TCONTRASENA" Mode="Value" />
                                        </CustomConfig>
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                         
                        </Items>
                    </ext:FieldSet>

                    <ext:FieldSet runat="server" Title="Información Personal"   >
                        <Items>
                            <ext:Container runat="server" Layout="HBoxLayout"  >
                                <Items>
                                    <ext:Container runat="server">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="CTIPDOC" FieldLabel="Tipo Documento"  DisplayField="name" ValueField="abbr" EmptyText="Seleccione.." LabelWidth="110" Flex="1"  MarginSpec="0 0 10 10" >
                                                <Items>
                                                    <ext:ListItem Text="CEDULA" Value="CC" />
                                                    <ext:ListItem Text="TARJETA IDENTIDAD" Value="TI" />
                                                </Items>
                                            </ext:ComboBox>
                                            <ext:TextField runat="server" ID="TNOMBRE" FieldLabel="Nombres" LabelWidth="110" MarginSpec="0 0 10 10" Flex="1" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container runat="server">
                                        <Items>
                                              <ext:TextField runat="server" ID="TIDENTIFICACION" FieldLabel="N° Identificación" MaskRe="[1-9]" LabelWidth="110" Flex="1" MarginSpec="0 0 10 10" IsRemoteValidation="true">
                                                 <RemoteValidation DirectFn="App.direct.validarIdent" />
                                            </ext:TextField>
                                            <ext:TextField runat="server" ID="TAPELLIDO" FieldLabel="Apellidos" LabelWidth="110" MarginSpec="0 0 10 10" Flex="1" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="HBoxLayout">
                                <Items>
                                    <ext:Container runat="server">
                                        <Items>
                                            <ext:DateField runat="server" ID="DFECHA" FieldLabel="Fecha Nacimiento" AllowBlank="false" MaxDate="<%# DateTime.Today %>" LabelWidth="110" MarginSpec="0 0 10 10"  />
                                            <ext:TextField runat="server" ID="TTELEFONO" FieldLabel="Telefono" MaskRe="[1-9]" LabelWidth="110" Flex="1" MarginSpec="0 0 10 10" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container runat="server">
                                        <Items>
                                            <ext:TextField runat="server" ID="TDIRECCION" FieldLabel="Direccion" LabelWidth="110" MarginSpec="0 0 10 10" Flex="1" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                           
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button runat="server"   Text="Finalizar" Disabled="true" FormBind="true">
                        <Listeners>
                            <Click Handler="App.direct.registrarEstudiante(App.DFECHA.rawValue);"/>
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
  </form>
</body>

</html>
