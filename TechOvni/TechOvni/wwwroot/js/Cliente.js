class Cliente {

    constructor() {
        this.Cliente = 0;
    }

    Registrar() {
        $.post(
            "GetCliente",
            $('.formCliente').serialize(),
            (response) => {

                try {

                    var item = JSON.parse(response);
                    if (item.Code == "Done") {
                        window.location.href = "Cliente";
                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description;
                    }

                } catch (e) {
                    document.getElementById("mensaje").innerHTML = response;
                }
            }
        );
    }
}