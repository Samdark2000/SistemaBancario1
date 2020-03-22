class Clientes {

    constructor() {
        this.ClienteID = 0;
    }

    //  Este metodo es para Registrar los clientes atraves HttpPost

    Registrar() {
        $.post(
            "GetCliente",
            $('.formCliente').serialize(),
            (response) => {

                try {

                    var item = JSON.parse(response);
                    if (item.Code == "Done") {
                        window.location.href = "Clientes";
                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description;
                    }

                } catch (e) {
                    document.getElementById("mensaje").innerHTML = response;
                }
            }
        );
    }

    EditCliente(data) {
        document.getElementById("Ccedula").value = data.Cedula;
        document.getElementById("CNombre").value = data.Nombre;
        document.getElementById("CApellido").value = data.Apellido;
        document.getElementById("CTelefono").value = data.Telefono;
        document.getElementById("CDireccion").value = data.Direccion;
        document.getElementById("CEstado").checked = data.Estado;
        document.getElementById("CClienteID").value = data.ClienteID;



        console.log(data);
    }

    GetCliente(data) {
        document.getElementById("titleCategoria").innerHTML = data.Nombre;
        this.ClienteID = data.ClienteID;
    }

    EliminarCliente() {
        $.post(
            "EliminarCliente",
            { ClienteID: this.ClienteID },
            (response) => {
                var item = JSON.parse(response);
                if (item.Description == "Done") {
                    window.location.href = "Clientes";
                } else {
                    document.getElementById("mensajeEliminar").innerHTML = item.Description;
                }
            }
        );
    }

    //Restablecer() {

    //    document.getElementById("CatNombre").value = "";
    //    document.getElementById("CatDescripcion").value = "";
    //    document.getElementById("CatEstado").checked = false;
    //    document.getElementById("CatCategoriaID").value = 0;
    //}
}
