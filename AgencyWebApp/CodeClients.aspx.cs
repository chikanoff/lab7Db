using AgencyIdentity.Data;
using AgencyIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgencyWebApp
{
    public partial class CodeClients : System.Web.UI.Page
    {
        private courseworkDbContext _db = new courseworkDbContext();
        private string strFindClient = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindClient = TextBoxFindClient.Text;
                ShowData(strFindClient);
            }

        }

        protected void GridViewClient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewClient.EditIndex = e.NewEditIndex;
            ShowData(strFindClient);

        }


        protected void GridViewClient_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update the values.
            GridViewRow row = GridViewClient.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Client client = _db.Clients.Where(f => f.Id == id).FirstOrDefault();
            client.FullName = ((TextBox)(row.Cells[2].Controls[0])).Text;
            client.Gender = ((TextBox)(row.Cells[3].Controls[0])).Text;
            client.Phone = ((TextBox)(row.Cells[4].Controls[0])).Text;
            client.DateOfBirth = Convert.ToDateTime(e.NewValues["DateOfBirth"].ToString());
            client.Adress = ((TextBox)(row.Cells[6].Controls[0])).Text;
            client.SerialNumber = ((TextBox)(row.Cells[7].Controls[0])).Text;
            client.Residence = ((TextBox)(row.Cells[8].Controls[0])).Text;
            _db.SaveChanges();
            GridViewClient.EditIndex = -1;

            ShowData(strFindClient);

        }

        protected void GridViewClient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewClient.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Client client = _db.Clients.Where(f => f.Id == id).FirstOrDefault();
            _db.Clients.Remove(client);

            _db.SaveChanges();
            GridViewClient.EditIndex = -1;

            ShowData(strFindClient);

        }


        protected void GridViewClient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewClient.EditIndex = 1;
            ShowData(strFindClient);
        }


        protected void ButtonFindClient_Click(object sender, EventArgs e)
        {
            strFindClient = TextBoxFindClient.Text;
            ShowData(strFindClient);
        }

        protected void ButtonAddClient_Click(object sender, EventArgs e)
        {
            string nameOfClient = TextBoxClientName.Text ?? "";
            string gender = TextBoxGender.Text ?? "";
            string Phone = TextBoxPhone.Text ?? "";
            DateTime dateOfBirth = TextBoxDateOfBirth.SelectedDate;
            string address = TextBoxAddress.Text ?? "";
            string serialNumber = TextBoxNumber.Text ?? "";
            string residence = TextBoxResidence.Text ?? "";
            if (nameOfClient != "")
            {
                Client Client = new Client
                {
                    FullName = nameOfClient,
                    Gender = gender,
                    Phone = Phone,
                    DateOfBirth = dateOfBirth,
                    Adress = address,
                    SerialNumber = serialNumber,
                    Residence = residence
                };

                _db.Clients.Add(Client);
                _db.SaveChanges();
                TextBoxClientName.Text = "";
                TextBoxGender.Text = "";
                TextBoxPhone.Text = "";
                TextBoxDateOfBirth = default;
                TextBoxAddress.Text = "";
                TextBoxNumber.Text = "";
                TextBoxResidence.Text = "";
                ShowData(strFindClient);

            }


        }
        protected void GridViewClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewClient.PageIndex = e.NewPageIndex;
            ShowData(strFindClient);

        }
        protected void ShowData(string strFindClient = "")
        {

            List<Client> Clients = _db.Clients.Where(s => s.FullName.Contains(strFindClient)).ToList();
            GridViewClient.DataSource = Clients;
            GridViewClient.DataBind();
        }
    }
}