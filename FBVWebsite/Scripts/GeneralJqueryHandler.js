///<reference path ="jquery-1.3.1-vsdoc.js" />
///<reference path ="jquery.blockUI.js" />
///<reference name ="MicrosoftAjax.js" />
Sys.Application.add_load(AppLoad);

function AppLoad() {

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
}

function BeginRequest(sender, args) {
    $.blockUI({ message: '<h2>... جارى التحميل</h2>', css: { border: 'none', padding: '15px', backgroundColor: '#000', opacity: '.5', color: '#fff', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', filter: 'alpha(opacity=70)'} });
}

function EndRequest(sender, args) {

    $.unblockUI();
}

