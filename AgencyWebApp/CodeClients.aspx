﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CodeClients.aspx.cs" Inherits="AgencyWebApp.CodeClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
<table border="0">
    <tr>
    <td>
    <asp:Label ID="LabelFindClient" runat="server" Text="Label">Клиент</asp:Label><asp:TextBox ID="TextBoxFindClient" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonFindClient" runat="server" Text="Найти" OnClick="ButtonFindClient_Click" />
    <br />        
        <asp:GridView ID="GridViewClient" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" 
            AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" 
            OnRowCancelingEdit="GridViewClient_RowCancelingEdit" 
            OnRowDeleting="GridViewClient_RowDeleting" 
            OnRowEditing="GridViewClient_RowEditing" 
            OnRowUpdating="GridViewClient_RowUpdating" PageSize="15" 
            OnPageIndexChanging="GridViewClient_PageIndexChanging"
            Caption="Клиенты" 
            EmptyDataText="Нет данных" CaptionAlign="Top" PageIndex="0">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Код" SortExpression="Id" />
                <asp:BoundField DataField="FullName" HeaderText="ФИО" SortExpression="FullName" />
                <asp:BoundField DataField="Gender" HeaderText="Пол" SortExpression="Gender" />
                <asp:BoundField DataField="Phone" HeaderText="Название" SortExpression="Phone" />
                <asp:TemplateField HeaderText="Дата дождения" SortExpression="DateOfBirth">
                    <EditItemTemplate>
                        <asp:Calendar ID="ReleaseDateCalendar" runat="server" SelectedDate='<%# Bind("DateOfBirth") %>'></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DateOfBirth" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Adress" HeaderText="Адрес" SortExpression="Adress" />
                <asp:BoundField DataField="SerialNumber" HeaderText="Серийный номер" SortExpression="SerialNumber" />
                <asp:BoundField DataField="Residence" HeaderText="Резиденция" SortExpression="Residence" />
            </Columns>
            
    </asp:GridView>
        </td>
        <td>
        <strong>Добавить нового клиента:</strong>
            <br />
            <asp:label runat="server">Имя:</asp:label><asp:TextBox ID="TextBoxClientName" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Пол:</asp:label><asp:TextBox ID="TextBoxGender" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Номер:</asp:label><asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Дата рождения:</asp:label><asp:Calendar ID="TextBoxDateOfBirth" runat="server"></asp:Calendar>
            <br />
            <asp:label runat="server">Адрес:</asp:label><asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Серийный номер:</asp:label><asp:TextBox ID="TextBoxNumber" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Резиденция:</asp:label><asp:TextBox ID="TextBoxResidence" runat="server"></asp:TextBox>
            <br />
        </td>
        <td>
            <asp:Button ID="ButtonAddClient" runat="server" Text="Добавить" OnClick="ButtonAddClient_Click" />

        </td>
</tr>
</table>
    </asp:Content>

