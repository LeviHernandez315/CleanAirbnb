let usuarios = [];
let valorCorreo;
let valorContraseña;

const obtenerUsuarios = async () => {
	const respuesta = await fetch("http://localhost:3001/personas", {
		method: "get",
	});
	usuarios = await respuesta.json();
	console.log("usuarios", usuarios);
};

obtenerUsuarios();

const validarCorreo = () => {
    valorCorreo = document.querySelector('#correo').value
    console.log(valorCorreo);
};

const validarContraseña = () => {
    valorContraseña = document.querySelector('#password').value
    console.log(valorContraseña);
};


const compararUsuarios=()=>{
    
    usuarios.forEach(element => {
        if((element.email == valorCorreo)&&(element.contraseña== valorContraseña)){
            // console.log('usuario aceptado');
            localStorage.setItem("clientecomleto", JSON.stringify(element));
             localStorage.setItem("cliente", element.id);
             localStorage.setItem("email", element.email);
            window.location.href = "menu.html";
            // console.log('usuario aceptado');
        }
    });
    // console.log(usuarios[0].correo)
}