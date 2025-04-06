let usuarios = [];
let valorCorreo;
let valorContraseña;

const obtenerUsuarios = async () => {
	const respuesta = await fetch("http://localhost:5139/api/usuarios", {
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
        if((element.Email == valorCorreo)&&(element.Password== valorContraseña)){
            // console.log('usuario aceptado');
            localStorage.setItem("usuarioCompleto", JSON.stringify(element));
             localStorage.setItem("usuario", element.id);
             localStorage.setItem("email", element.Email);
            window.location.href = "menu.html";
            // console.log('usuario aceptado');
        }
    });
    // console.log(usuarios[0].correo)
}