///<reference path ="..\jquery-1.3.1-vsdoc.js" />
///<reference path ="..\jquery.blockUI.js" />
///<reference path ="..\daterangepicker.jQuery.js" />
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
    $('#FBV_cph_txtBirthDateFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' });
    $('#FBV_cph_txtBirthDateTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' })
    $('#FBV_cph_txtRegisterDate').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' })
    $('#FBV_cph_txtFirstContactDate').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy' }); ; ;
   }
