//class Cuentas {

//    RegistrarCurso() {
//        var data = new FormData();

//        data.append('Input.Numero_Cuenta', $("#CNumero").val());
//        data.append('Input.Estado', document.getElementById("CEstado").checked)
//        data.append('Input.ClienteID', $("#curClientes").val());


//        //$.each($('input[type=file]')[0].files, (i, file) => {
//        //    data.append('AvatarImage', file);
//        //});

//        $.ajax({
//            url: "GetCuentas",
//            data: data,
//            cache: false,
//            contextType: false,
//            processData: false,
//            type: 'POST',
//            success: (data) => {
//                try {
//                    var item = JSON.parse(data);

//                    if (item.Code == "Done") {
//                        window.location.href = "Cuentas";
//                    } else {
//                        document.getElementById("mensaje").innerHTML = item.Description;
//                    }

//                } catch (e) {
//                    document.getElementById("mensaje").innerHTML = data;
//                }

//                console.log(data);
//            }
//        });
//    }
//}


class Cuentas {

    constructor() {
        this.CuentaID = 0;
    }

    RegistrarCuentas() {
        var data = new FormData();
        data.append('Input.Numero_Cuenta', $("#CNumero").val());
        data.append('Input.Estado', document.getElementById("CEstado").checked);
        data.append('Input.ClienteID', $("#curClientes").val());

        data.append('Input.CuentaID', $("CCuentaID").val());
    
        $.ajax({
            url: "GetCuentas",
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: (result) => {
                try {
                    var item = JSON.parse(result);
                    if (item.Code == "Done") {
                        window.location.href = "Cuentas";
                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description;
                    }
                } catch (e) {
                    document.getElementById("mensaje").innerHTML = result;
                }
                console.log(result);
            }
        });
    }
    EditCuentas(cuentas, cli) {

        let j = 1;

        $("#CNumero").val(cuentas.Numero_Cuenta);
        $("#CEstado").prop("checked", cuentas.Estado);
        $("#CCuentaID").val(cuentas.CuentaID);

        let x = document.getElementById("curClientes");
        x.options.length = 0;

        for (var i = 0; i < cli.length; i++) {
            if (cli[i].Value == cuentas.ClienteID) {
             
                x.options[0] = new Option(cli[i].Text, cli[i].Value);
                x.selectedIndex = 0;
                j = i;
                
            } else {
               
                x.options[i] = new Option(cli[i].Text, cli[i].Value);
            }
           
        }
        x.options[j] = new Option(cli[0].Text, cli[0].Value);
       // x.remove(j);



        console.log(cuentas);
        console.log(cli);
    }

    GetCuentas(cuenta) {
        document.getElementById("titleCuentas").innerHTML = cuenta.Numero_Cuenta;
        this.CuentaID = cuenta.CuentaID
    }

    EliminarCuenta() {
        $.post(
            "EliminarCuenta",
            { CuentaID: this.CuentaID },
            (response) => {
                var item = JSON.parse(response);
                if (item.Description == "Done") {
                    window.location.href = "Cuentas";
                } else {
                    document.getElementById("mensajeEliminar").innerHTML = item.Description;
                }
            }
        );
    }
}













