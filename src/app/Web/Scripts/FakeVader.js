/// <reference path='jquery-1.4.4.js'/>
$(document).ready(function () {
    $('a[href=#]').attr('href', 'javascript:void(0)');

    $('a[href!=javascript]')
        .not('#footer a')
        .filter(function () { return this.hostname && this.hostname !== location.hostname; })
        .after('<span class="ui-icon ui-icon-extlink" style="display: inline-block !important;"></span>')
        .click(function(event) {
          event.preventDefault();
          $('#confirm-dialog').dialog('option', 'href', this.href).dialog('open');
        });

    $('body').append("<div id='confirm-dialog' title='Leaving?'><p><span class='ui-icon ui-icon-alert' style='float:left; margin:20px 7px 20px 0;'></span>There is no escape. Don't make me destroy you.</p></div>");
    $('#confirm-dialog').dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        closeOnEscape: false,
        overlay: {
            backgroundColor: '#000',
            opacity: 0.5
        },
        buttons: {
            Stay: function () {
                $(this).dialog('close');
            },
            Flee: function () {
                window.location.href = $(this).dialog('option', 'href');
            }
        }
    });
});