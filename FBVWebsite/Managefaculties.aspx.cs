using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FBV.DataAccessLayer;
using FBV.DataMapping;

public partial class Managefaculties :System.Web.UI .Page 
{
    FacUniversitiesManager _AssociatedUniversitiesManager = new FacUniversitiesManager();
    EduFacultiesManager _AssociatedEduFacultiesManager = new EduFacultiesManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUniversitiesDataGrid();
        }
    }

    private void BindUniversitiesDataGrid()
    {
        DataTable AllUniversities = _AssociatedUniversitiesManager.GetAllFacUniversities();
        if (AllUniversities.Rows.Count > 0)
        {
            grdUniversities.DataSource = AllUniversities;
            grdUniversities.DataBind();
        }
        else 
        {
            grdUniversities.DataBind();
        }
    
    }
    protected void lnkAddUnivresities_Click(object sender, EventArgs e)
    {
        mpeUniversities.Show();
    }

    protected void lnkUniveristiesname_Command(object sender, CommandEventArgs e)
    {
        int universityId = int.Parse(e.CommandArgument.ToString());
        DataTable facaultiesTable = _AssociatedEduFacultiesManager.GetFacultiesByUniversityId(universityId);
        if (facaultiesTable.Rows.Count > 0)
        {
            grdFaculties.DataSource = facaultiesTable;
            grdFaculties.DataBind();
        }
        else
        {
            grdFaculties.DataBind();
        }
    }
}
