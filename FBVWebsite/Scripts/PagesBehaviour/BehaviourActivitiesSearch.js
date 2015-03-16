///<reference path ="..\jquery-1.3.1-vsdoc.js" />
///<reference path ="..\jquery.blockUI.js" />
///<reference name ="MicrosoftAjax.js" />
Sys.Application.add_load(AppLoad);

function AppLoad() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);

    InitiateDatePicker();
}

function BeginRequest(sender, args) {


}

function EndRequest(sender, args) {

    $.unblockUI();
}

function InitiateDatePicker() {
  
    $('#FBV_cph_txtRequestDateFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtRequestDateTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityDayFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityDayTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityEntryFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtActivityEntryTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });

}
