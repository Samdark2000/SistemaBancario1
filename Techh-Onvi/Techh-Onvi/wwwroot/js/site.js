// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var clientes = new Clientes();
var cuentas = new Cuentas();


let screen = document.getElementById('screen');
const buttons = document.querySelectorAll("#buttons a");

for (const button of buttons) {
    button.addEventListener('click', function (e) {
        e.preventDefault();

        if (e.target.dataset.key == 'equal') {
            screen.textContent = eval(screen.textContent);
            if (screen.textContent.length > 8) {
                screen.textContent = eval(screen.textContent).toFixed(8);
            }
        } else if (e.target.dataset.key == 'clear') {
            screen.textContent = '';
        } else {
            screen.textContent = screen.textContent + e.target.dataset.key;
        }
    });
}

//$(function () {
//    $("#loaderbody").addClass('hide');

//    $(document).bind('ajaxStart', function () {
//        $("#loaderbody").removeClass('hide');
//    }).bind('ajaxStop', function () {
//        $("#loaderbody").addClass('hide');
//    });
//});


showInPopup = (url, title) => {
    $.ajax({
        type: "Get",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');
                    $.notify('Se envio correctamente', { globalPosition: 'top center', className:'success' });
                   
                }
                else
                    $("#form-modal .modal-body").html(res.html);
            },
            error: function (err) {
                console.log(err)
            }

        })
    } catch (e) {
        console.log(e);
    }
    return false;
}


jQueryAjaxDelete = form => {
    if (confirm('Estas Seguro de que quiere borrar esta transaccion?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData:false,
                success: function (res) {
                   
                    $("#view-all").html(res.html);
                    $.notify('Se borro correctamente', { globalPosition: 'top center', className: 'success' });

                   },
                    error: function(err) {
                        console.log(err);
                    }
                })

        } catch (e) {
            console.log(e);
        }
    }

    return false;
}