using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using FBV.DataAccessLayer;
/// <summary>
/// Summary description for VolunteerNames
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class VolunteerNames : System.Web.Services.WebService
{
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();

    [WebMethod]
    public string[] GetVolunteerNamesList(string prefixText, int count)
    {
        List<string> VolunteerNames = _AssociatedVolunteersManager.GetVolunteerNames  (prefixText);
        return VolunteerNames.ToArray();
    }

}

