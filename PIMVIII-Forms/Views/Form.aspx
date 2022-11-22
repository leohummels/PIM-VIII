<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="PIMVIII_Forms.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 27px;
            width: 185px;
        }
        .Labels{
            font-size: 2em;
        }
        .container {
            height: 505px;
        }
        .contentLabel {
            height: 250px;
        }
        .labelClass {
            height: 46px;
        }
    </style>
</head>
<body style="height: 598px">
    <form id="form1" runat="server">
        <div class="container">
            <div class="CadastroPessoas"><h1>Cadastro Pesssoas</h1></div>
            <div class="content">
                <div class="labelClass">
                    <asp:Label class="Labels" runat="server" Text="Pessoa"></asp:Label>
                </div>
                <div class="row">
                    <h3>Nome</h3>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                 <div class="row">
                    <h3>CPF</h3>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="content">
                <div class="labelClass">
                    <asp:Label class="Labels" runat="server" Text="Endereço"></asp:Label>
                </div>
               <div class="row">
                    <h3>Tipo</h3>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <h3>Logradouro</h3>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                 <div class="row">
                    <h3>Bairro</h3>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <h3>Cidade</h3>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <h3>Numero</h3>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <h3>Estado</h3>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="content">
                <div class="labelClass">
                    <asp:Label class="Labels" runat="server" Text="Telefone"></asp:Label>
                </div>
                <div class="row">
                    <h3>Numero</h3>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </div>
                 <div class="row">
                    <h3>DDD</h3>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
