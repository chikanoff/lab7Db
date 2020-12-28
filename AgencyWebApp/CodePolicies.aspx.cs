using AgencyIdentity.Data;
using AgencyIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace AgencyWebApp
{
    public partial class CodePolicies : System.Web.UI.Page
    {
        private courseworkDbContext _db = new courseworkDbContext();
        private string strFindPolicy = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                strFindPolicy = TextBoxFindPolicy.Text;
                ShowData(strFindPolicy);
            }

        }

        protected void GridViewPolicy_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPolicy.EditIndex = e.NewEditIndex;
            ShowData(strFindPolicy);

        }


        protected void GridViewPolicy_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = GridViewPolicy.Rows[e.RowIndex];
            int id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
            Policy Policy = _db.Policies.Where(f => f.Id == id).FirstOrDefault();
            Policy.ClientId = int.Parse(e.NewValues["ClientId"].ToString());
            Policy.RegistredAt = Convert.ToDateTime(e.NewValues["RegistredAt"].ToString());
            Policy.Finish = Convert.ToDateTime(e.NewValues["Finish"].ToString());
            Policy.TypeOfInsuranceId = int.Parse(e.NewValues["TypeOfInsuranceId"].ToString());
            _db.SaveChanges();
            GridViewPolicy.EditIndex = -1;

            ShowData(strFindPolicy);

        }

        protected void GridViewPolicy_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewPolicy.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            Policy Policy = _db.Policies.Where(f => f.Id == id).FirstOrDefault();
            _db.Policies.Remove(Policy);

            _db.SaveChanges();
            GridViewPolicy.EditIndex = -1;

            ShowData(strFindPolicy);

        }


        protected void GridViewPolicy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPolicy.EditIndex = 1;
            ShowData(strFindPolicy);
        }


        protected void ButtonFindPolicy_Click(object sender, EventArgs e)
        {
            strFindPolicy = TextBoxFindPolicy.Text;
            ShowData(strFindPolicy);
        }

        protected void ButtonAddPolicy_Click(object sender, EventArgs e)
        {
            int clientId = int.Parse(ClientDropDownList.SelectedValue);
            DateTime registeretAd = Convert.ToDateTime(TextBoxRegisteredAt.SelectedDate);
            DateTime finish = Convert.ToDateTime(TextBoxFinish.SelectedDate);
            int typeId = int.Parse(TypeOfInsuranceDropDownList.SelectedValue);
            Policy Policy = new Policy
            {
                ClientId = clientId,
                RegistredAt = registeretAd,
                Finish = finish,
                TypeOfInsuranceId = typeId,
            };

            _db.Policies.Add(Policy);
            _db.SaveChanges();
            TextBoxRegisteredAt = default;
            TextBoxFinish = default;
            ShowData(strFindPolicy);
        }
        protected void GridViewPolicy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPolicy.PageIndex = e.NewPageIndex;
            ShowData(strFindPolicy);

        }
        protected void ShowData(string strFindPolicy = "")
        {

            List<Policy> Policys = _db.Policies.Include(p => p.Client).Include(p => p.TypeOfInsurance).Where(s => s.Client.FullName.Contains(strFindPolicy)).ToList();
            GridViewPolicy.DataSource = Policys;
            GridViewPolicy.DataBind();
        }
    }
}