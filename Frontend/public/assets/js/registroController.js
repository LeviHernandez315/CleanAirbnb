/*let usuarios2 = [];


const obtenerValores = () => {
    let dni 				=   document.querySelector('#dni').value;
    let primerNombre 		=   document.querySelector('#primerNombre').value;
	let segundoNombre 		=   document.querySelector('#segundoNombre').value;
    let primerApellido 		=   document.querySelector('#primerApellido').value;
	let segundoApellido 	=   document.querySelector('#segundoApellido').value;
    let edad 				=   document.querySelector('#edad').value;
	let fechaNacimiento 	=   document.querySelector('#fechaNacimiento').value;
	let rtn 				=   document.querySelector('#rtn').value;
	let correo 				=   document.querySelector('#correo').value;
	let contraseña 			=   document.querySelector('#password').value;
    // console.log(document.querySelector('#nombre').value);
    if ((dni != "")&&(primerNombre != "")&&(primerApellido != "")&&(edad != "")){
        crearPersona(dni, primerNombre, segundoNombre, primerApellido, segundoApellido,
			edad, fechaNacimiento, rtn, correo, contraseña);

			// crearTelefono(telefono)
        // window.location.href = "menu.html";
    }else{
        console.log('Uno de los datos no ha sido llenado');
    }
}

const crearPersona = async (dni, primerNombre, segundoNombre, 
	primerApellido, segundoApellido, edad,
	fechaNacimiento, rtn, correo, contraseña) => {
	const respuesta = await fetch(`http://localhost:3001/personas`,
		{
			method: "post",
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				dni: dni,
				primerNombre: primerNombre,
				segundoNombre: segundoNombre,
				primerApellido: primerApellido,
				segundoApellido: segundoApellido,
                edad: edad,
				fechaNacimiento: fechaNacimiento,
				rtn: rtn
			}),
		}
	);
	crearUsuario(dni, correo, contraseña);
	// console.log('usuario insertado exitosa mente');
	// const resJSON = await respuesta.json();
	// console.log('Respuesta de agregar un cliente',resJSON);
	console.log('usuario insertado exitosa mente');
	
};

const crearUsuario = async (dni, correo, contraseña) =>{
	const respuesta = await fetch(`http://localhost:3001/personas/usuarios`,
		{
			method: "post",
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				dni: dni,
				email: correo,
				contraseña: contraseña
			}),
		}
	);
	window.location.href = "menu.html";
	// obtenerUsuarios3();
}

const obtenerUsuarios3 = async () => {
	const respuesta = await fetch("http://localhost:3001/personas", {
		method: "get",
	});
	usuarios2 = await respuesta.json();
	console.log("usuarios", usuarios2);
	comparar();
};


const comparar=()=>{
	usuarios2.forEach(element => {
        if((element.mail == document.querySelector('#correo').value)&&(element.contraseña == document.querySelector('#password').value)){
            // console.log('usuario aceptado');
            localStorage.setItem("usuario", element.id);
            // window.location.href = "menu.html";
            // console.log('usuario aceptado');
        }
    });
    // console.log(clientes[0].correo)
}

*/

const obtenerValores = async () => {
    // Obtener valores del formulario
    const dni = document.getElementById("dni").value.trim();
    const rtn = document.getElementById("rtn").value.trim();
    const primerNombre = document.getElementById("primerNombre").value.trim();
    const segundoNombre = document.getElementById("segundoNombre").value.trim();
    const primerApellido = document.getElementById("primerApellido").value.trim();
    const segundoApellido = document.getElementById("segundoApellido").value.trim();
    const correo = document.getElementById("correo").value.trim();
    const password = document.getElementById("password").value.trim();
    const edad = document.getElementById("edad").value.trim();
    const fechaNacimiento = document.getElementById("fechaNacimiento").value;
    const telefono = document.getElementById("telefono").value.trim();

    // Validar que los campos obligatorios estén llenos
    if (!dni || !primerNombre || !primerApellido || !correo || !password || !edad || !fechaNacimiento /*|| !telefono*/) {
        alert("Por favor completa todos los campos obligatorios.");
        return;
    }

    try {
        // 1. Crear Persona
        const personaResponse = await fetch("http://localhost:5139/api/personas", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                dni,
                rtn: rtn || null,
                primerNombre,
                segundoNombre: segundoNombre || null,
                primerApellido,
                segundoApellido: segundoApellido || null,
                edad: parseInt(edad),
                fechaNacimiento
            })
        });

        if (!personaResponse.ok) throw new Error("Error al registrar la persona.");

        // 2. Crear Teléfono
       /* const telefonoResponse = await fetch("http://localhost:5139/api/telefonos", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                numTelefono: telefono,
                idPersona: dni,
                personaDNI: dni
            })
        });*/

        //if (!telefonoResponse.ok) throw new Error("Error al registrar el teléfono.");

        // 3. Crear Usuario
        const usuarioResponse = await fetch("http://localhost:5139/api/usuarios", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: correo,
                password,
                dni,
                rolId: 1 // Cliente
            })
        });

        if (!usuarioResponse.ok) throw new Error("Error al registrar el usuario.");

        alert("Registro exitoso. Ahora puedes iniciar sesión.");
        window.location.href = "login.html";

    } catch (error) {
        console.error("Error en el registro:", error);
        alert("Ocurrió un error durante el registro:\n" + error.message);
    }
};
