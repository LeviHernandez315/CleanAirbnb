
let vehiculos=[];
let ListaVehiculos=[];
let uiui=[];

let nomCliente= localStorage.getItem("email");
let fechaCheckIn1 = localStorage.getItem("fechaCheckIn")
let idPropiedad1 = localStorage.getItem("idPropiedad")
let idHuesped1 = localStorage.getItem("idHuesped")
let difDias1 = localStorage.getItem("difDias")
let idReserva;

// console.log(localStorage.getItem("qqqqq"));


const renderizaNombreUser= () =>{  

    document.getElementById("nombreUsee").innerHTML= ""; 
    document.getElementById("nombreUsee").innerHTML += 
        `
       ${ nomCliente}
        `
}
renderizaNombreUser();

const obtenerReserva = async () => {
    const respuesta = await fetch(`http://localhost:3001/reservas/casa`,{
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            fechaCheckIn1: fechaCheckIn1,
            idPropiedad1: idPropiedad1,
            idHuesped1: idHuesped1,
        }),
    });
    idReserva = respuesta;
    console.log('idReserva', idReserva);
}

obtenerReserva();

console.log(localStorage.getItem("propiedad"));

const obtenerVehiculos = async () => {
	const respuesta = await fetch("http://localhost:3001/vehiculos", {
		method: "get",
	});
	vehiculos = await respuesta.json();
    veheiculoSeleccionado=vehiculos;
	console.log("vehiculos", vehiculos);
    renderizaVehiculos();
}



const renderizaVehiculos= () =>{  

    document.getElementById("idparaRendVehi").innerHTML= "";
    for( i=0; i<vehiculos.length;i++){
        document.getElementById("idparaRendVehi").innerHTML += 
        `
        <div  class="col-md-3 border-primary">
        <div class="card mb-4">
          <img src="${vehiculos[i].urlImagen}" class="imgCar" alt="Vehicle 1">
          <div class="card-body">
            <h5 value="${vehiculos[i].idModelo}" class="card-title text-black">${vehiculos[i].marca} ${vehiculos[i].modelo}</h5>
            <p class="card-text text-black">${vehiculos[i].tipoVehiculo}</p>
            <p class="card-text text-black">Precio por día: L.${vehiculos[i].precioDia}</p>
            <button onclick="agregarVehiculo(${i})" type="button" class="btn btn-primary">Agregar</button>
          </div>
        </div>
    </div>
        `

    }

}
obtenerVehiculos();




const agregarVehiculo=(j)=>{
  //  JSON.stringify(propiedades[o])
  //  uiui.push(JSON.stringify(veheiculoSeleccionado[j]));
  const objeto1 = { nombre:  `${veheiculoSeleccionado[j].marca}`, precio:  `${veheiculoSeleccionado[j].precioDia}`};
  uiui.push(objeto1);
  let poo=uiui.length;
  localStorage.setItem("begii", poo);

    console.log(poo);
    renderizarListaVehiculos();
}

const renderizarListaVehiculos=()=>{
    var jeyes=0;
    document.getElementById("listaCarros").innerHTML="";
    for( i=0; i<uiui.length ;i++){
        t=parseFloat(uiui[i].precio);
       jeyes+=t;
        document.getElementById("listaCarros").innerHTML+=
        `
        <div class="card-footer">
             ${uiui[i].nombre} valor: ${uiui[i].precio}
            </div>
    
        `
        document.getElementById("prex").innerHTML=` Valor Total: ${jeyes} 
        <button id="mz" type="button" value=${jeyes} class="btn btn-primary" onclick="irAPagina()">Pagar</button>`
    }
   ;
}

const irAPagina=()=>{
    localStorage.setItem("totaVehiculo", document.getElementById("mz").value);
    window.location.href = "pago.html";
    
    console.log(document.getElementById("mz").value);
};


const pasarFactura=(m)=>{
    //propiedades[o].id;
    localStorage.setItem("vehiculo", vehiculos[m]);
   // window.location.href = "factura.html";
};




const obtenerMarca = async () => {
	const respuesta = await fetch("http://localhost:3001/vehiculos/marca", {
		method: "get",
	});
	marca = await respuesta.json();
	console.log("marca", marca);
    //renderizaVehiculos();
};

obtenerMarca();

const obtenerModelo = async () => {
	const respuesta = await fetch("http://localhost:3001/vehiculos/modelo", {
		method: "get",
	});
	modelo = await respuesta.json();
	console.log("marca", modelo);
    //renderizaVehiculos();
};

obtenerModelo();


const obtenerTipoVe = async () => {
	const respuesta = await fetch("http://localhost:3001/vehiculos/modelo", {
		method: "get",
	});
	tipoVeh = await respuesta.json();
	console.log("marca", tipoVeh );
    //renderizaVehiculos();
};

obtenerTipoVe();

const obtenerrrrrr = async () => {
	const respuesta = await fetch("http://localhost:3001/reservas/casass", {
		method: "get",
	});
	metodosrrrr = await respuesta.json();
    console.log("Metoress", metodosrrrr);
   // listaMetodosPago();
};

obtenerrrrrr();


  




