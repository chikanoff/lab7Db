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
    public partial class CodeTypesOfInsurance : System.Web.UI.Page
    {
        private courseworkDbContext _db = new courseworkDbContext();
        private string strFindTypeOfInsurance = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindTypeOfInsurance = TextBoxFindTypeOfInsurance.Text;
                ShowData(strFindTypeOfInsurance);
            }

        }

        protected void GridViewTypeOfInsurance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTypeOfInsurance.EditIndex = e.NewEditIndex;
            ShowData(strFindTypeOfInsurance);

        }


        protected void GridViewTypeOfInsurance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewTypeOfInsurance.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            TypeOfInsurance TypeOfInsurance = _db.TypesOfInsurance.Where(f => f.Id == id).FirstOrDefault();
            TypeOfInsurance.Name = ((TextBox)(row.Cells[2].Controls[0])).Text;
            TypeOfInsurance.Description = ((TextBox)(row.Cells[3].Controls[0])).Text;
            TypeOfInsurance.Price = int.Parse(((TextBox)(row.Cells[4].Controls[0])).Text);
            TypeOfInsurance.Payment = int.Parse(((TextBox)(row.Cells[5].Controls[0])).Text);
            _db.SaveChanges();
            GridViewTypeOfInsurance.EditIndex = -1;

            ShowData(strFindTypeOfInsurance);

        }

        protected void GridViewTypeOfInsurance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewTypeOfInsurance.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            TypeOfInsurance TypeOfInsurance = _db.TypesOfInsurance.Where(f => f.Id == id).FirstOrDefault();
            _db.TypesOfInsurance.Remove(TypeOfInsurance);

            _db.SaveChanges();
            GridViewTypeOfInsurance.EditIndex = -1;

            ShowData(strFindTypeOfInsurance);

        }


        protected void GridViewTypeOfInsurance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTypeOfInsurance.EditIndex = 1;
            ShowData(strFindTypeOfInsurance);
        }


        protected void ButtonFindTypeOfInsurance_Click(object sender, EventArgs e)
        {
            strFindTypeOfInsurance = TextBoxFindTypeOfInsurance.Text;
            ShowData(strFindTypeOfInsurance);
        }

        protected void ButtonAddTypeOfInsurance_Click(object sender, EventArgs e)
        {
            string nameTypeOfInsurance = TextBoxTypeOfInsuranceName.Text ?? "";
            string description = TextBoxDescription.Text ?? "";
            decimal price = int.Parse(TextBoxPrice.Text);
            decimal payment = int.Parse(TextBoxPayment.Text);
            TypeOfInsurance TypeOfInsurance = new TypeOfInsurance
            {
                Name = nameTypeOfInsurance,
                Description = description,
                Price = price,
                Payment = payment,
            };

            _db.TypesOfInsurance.Add(TypeOfInsurance);
            _db.SaveChanges();
            TextBoxTypeOfInsuranceName.Text = "";
            TextBoxDescription.Text = "";
            TextBoxPrice.Text = "";
            TextBoxPayment.Text = "";
            ShowData(strFindTypeOfInsurance);
        }
        protected void GridViewTypeOfInsurance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTypeOfInsurance.PageIndex = e.NewPageIndex;
            ShowData(strFindTypeOfInsurance);

        }
        protected void ShowData(string strFindTypeOfInsurance = "")
        {

            List<TypeOfInsurance> TypesOfInsurance = _db.TypesOfInsurance.Where(s => s.Name.Contains(strFindTypeOfInsurance)).ToList();
            GridViewTypeOfInsurance.DataSource = TypesOfInsurance;
            GridViewTypeOfInsurance.DataBind();
        }
    }
}