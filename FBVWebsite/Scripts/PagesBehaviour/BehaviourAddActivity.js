///<reference path ="..\jquery-1.3.1-vsdoc.js" />
///<reference path ="..\jquery.blockUI.js" />
///<reference name ="MicrosoftAjax.js" />
Sys.Application.add_load(AppLoad);
var divRequestHeight=0;
var divVolunteers=0;
var divEvaluation=0;

function AppLoad() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);

    InitiateDatePicker();
    InitiateCollapsiblePanels();
}

function BeginRequest(sender, args) {
    var elem = args.get_postBackElement();
    var strElem = elem.toString();

    if (strElem.indexOf('lnkAddDayDetails') > 0 ||
    strElem.indexOf('lnkAddDepartment') > 0 ||
    strElem.indexOf('imgBtnEditActivityDepartment') > 0 ||
    strElem.indexOf('lnkActivityDepartmentEvaluation') > 0 ||
    strElem.indexOf('lnkVolunteerDepartmentEvaluation') > 0 
    ) {
        $.blockUI({ message: '<h2>... جارى التحميل</h2>', fadeIn:0, css: { border: 'none', padding: '15px', backgroundColor: '#000', opacity: '.5', color: '#fff', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', filter: 'alpha(opacity=70)'} });
    }
}

function EndRequest(sender, args) {

    $.unblockUI({ fadeOut: 0 });
}


function InitiateDatePicker() {
    $('#FBV_cph_txtActivityRequestDate').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy', buttonImageOnly: true });
    $('#FBV_cph_txtActivityDateFrom').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy', buttonImageOnly: true });
    $('#FBV_cph_txtActivityDateTo').datepicker({ showOn: 'button', buttonImage: 'images/calendar_icon.gif', buttonImageOnly: true, changeMonth: true, changeYear: true, showAnim: 'slideDown', buttonText: '', dateFormat: 'dd/mm/yy', buttonImageOnly: true });
}

function InitiateCollapsiblePanels(){

    $('#tdRequest').click(function(){
      var currentHeight=$('#divRequest').height();
      if( currentHeight>0)  {
      divRequestHeight=currentHeight;
     $('#divRequest'). css("height","0");
     }
     else
     {
        $('#divRequest'). css("height",divRequestHeight);
     }
    });
    
      $('#tdVolunteers').click(function(){
      var currentHeight=$('#divVolunteers').height();
      if( currentHeight>0)  {
      divVolunteers=currentHeight;
     $('#divVolunteers'). css("height","0");
     }
     else
     {
        $('#divVolunteers'). css("height",divVolunteers);
     }
    });
    
     $('#tdEvaluation').click(function(){
  
      var currentHeight=$('#divVolunteersEvaluation').height();
      if( currentHeight>0)  {
      divEvaluation=currentHeight;
     
     $('#divVolunteersEvaluation'). css("height","0");
     }
     else
     {
        $('#divVolunteersEvaluation'). css("height",divEvaluation);
     }
    });
}