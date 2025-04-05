let usuarios2 = [];


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