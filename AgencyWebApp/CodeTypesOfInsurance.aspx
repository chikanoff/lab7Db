﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CodeTypesOfInsurance.aspx.cs" Inherits="AgencyWebApp.CodeTypesOfInsurance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
<table border="0">
    <tr>
    <td>
    <asp:Label ID="LabelFindTypeOfInsurance" runat="server" Text="Label">Тип</asp:Label><asp:TextBox ID="TextBoxFindTypeOfInsurance" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonFindTypeOfInsurance" runat="server" Text="Найти" OnClick="ButtonFindTypeOfInsurance_Click" />
    <br />        
        <asp:GridView ID="GridViewTypeOfInsurance" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" 
            AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" 
            OnRowCancelingEdit="GridViewTypeOfInsurance_RowCancelingEdit" 
            OnRowDeleting="GridViewTypeOfInsurance_RowDeleting" 
            OnRowEditing="GridViewTypeOfInsurance_RowEditing" 
            OnRowUpdating="GridViewTypeOfInsurance_RowUpdating" PageSize="15" 
            OnPageIndexChanging="GridViewTypeOfInsurance_PageIndexChanging"
            Caption="Тип страховки" 
            EmptyDataText="Нет данных" CaptionAlign="Top" PageIndex="0">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Код" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Нименование" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Описание" SortExpression="Description" />
                <asp:BoundField DataField="Price" HeaderText="Стоимость" SortExpression="Price" />
                <asp:BoundField DataField="Payment" HeaderText="Платёж" SortExpression="Payment" />
            </Columns>
            
    </asp:GridView>
        </td>
        <td>
        <strong>Добавить новый тип:</strong>
            <br />
            <asp:label runat="server">Наименование:</asp:label><asp:TextBox ID="TextBoxTypeOfInsuranceName" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Описание:</asp:label><asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Стоимость:</asp:label><asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
            <br />
            <asp:label runat="server">Платёж:</asp:label><asp:TextBox ID="TextBoxPayment" runat="server"></asp:TextBox>
            <br />
        </td>
        <td>
            <asp:Button ID="ButtonAddTypeOfInsurance" runat="server" Text="Добавить" OnClick="ButtonAddTypeOfInsurance_Click" />

        </td>
</tr>
</table>
    </asp:Content>


