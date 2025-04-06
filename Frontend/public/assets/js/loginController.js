let usuarios = [];

const obtenerUsuarios = async () => {
    try {
        const respuesta = await fetch("http://localhost:5139/api/usuarios", {
            method: "GET",
        });
        usuarios = await respuesta.json();
        console.log("usuarios cargados:", usuarios);
    } catch (error) {
        console.error("Error al obtener los usuarios:", error);
        alert("No se pudo conectar al servidor.");
    }
};

// Llamar al inicio
obtenerUsuarios();

const compararUsuarios = () => {
    // Capturar valores actuales al momento de hacer clic
    const valorCorreo = document.querySelector('#correo').value.trim();
    const valorContraseña = document.querySelector('#password').value.trim();

    // Validar que no estén vacíos
    if (!valorCorreo || !valorContraseña) {
        alert("Por favor, completa todos los campos.");
        return;
    }

    let encontrado = false;

    usuarios.forEach(element => {
        if (element.email === valorCorreo /*&& element.password === valorContraseña*/) {
            encontrado = true;

            localStorage.setItem("usuarioCompleto", JSON.stringify(element));
            localStorage.setItem("usuario", element.id);
            localStorage.setItem("email", element.email);

            alert("Inicio de sesión exitoso.");
            window.location.href = "menu.html";
        }
    });

    if (!encontrado) {
        alert("Correo o contraseña incorrectos.");
    }
};
