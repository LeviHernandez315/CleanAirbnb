
var metodos='';
let nomCrrr= localStorage.getItem("ppreee");
let norrr= localStorage.getItem("totaVehiculo");

console.log(nomCrrr);
console.log(norrr);
//localStorage.setItem("ppreee", uu);

const obtenerMetodoPago = async () => {
	const respuesta = await fetch("http://localhost:3001/metodoPago", {
		method: "get",
	});
	metodosdePago = await respuesta.json();
    console.log("Metodos de Pago", metodosdePago);
    listaMetodosPago();
};

obtenerMetodoPago();


function listaMetodosPago() {
    document.getElementById('metodoActual').innerHTML=`<option selected >Selecciona el Metodo</option>`;
    for (let i = 0; i < metodosdePago.length; i++) {
        document.getElementById('metodoActual').innerHTML+=
    ` <option "value="${i+1}">${metodosdePago[i].nombre}</option>`

    }
   
}

function mostrarTarjetas() {

    document.getElementById('contenedor-principal').style.display='block';
    
}

// var selectElemen = document.getElementById("metodoActual");
// var selecValue = selectElemen.value;
document.getElementById("metodoActual").addEventListener("change", function() {
    var selectElement = document.getElementById("metodoActual");
    var selectedValue = selectElement.value;
    //var selectedText = selectElement.options[selectElement.selectedIndex].text;
  
    //console.log("Opción seleccionada: " + selectedText + " (Valor: " + selectedValue + ")");
    console.log(selectedValue);
  });
// const obtenerMetddd = (o) => {
//     valormett = document.querySelector( `#password `).value
//     console.log(valormett);
// };


var checkbox1 = document.getElementById("flexCheckDefault");
var checkbox2 = document.getElementById("flexCheckChecked");

checkbox1.addEventListener("change", function() {
  if (checkbox1.checked) {
    checkbox2.checked = false;
    console.log("50% de la reserva");
    
 }
    wee=(parseFloat(nomCrrr))+(parseFloat(norrr));
    document.getElementById('tao').innerHTML=`Total a Pagar es: ${wee/2}`; 
  
});

checkbox2.addEventListener("change", function() {
  if (checkbox2.checked) {
    ;
   
    checkbox1.checked = false;
    console.log("total de la reserva");
    if (norrr!==""){
        wee=(parseFloat(nomCrrr))+(parseFloat(norrr));
    document.getElementById('tao').innerHTML=`Total a Pagar es: ${wee}`; }
    else{document.getElementById('tao').innerHTML=`Total a Pagar es: ${nomCrrr}`}
  }
});

checkbox1.checked = false;
checkbox2.checked = false;





const cambiar= () =>{  
    if ((checkbox1.checked == false) && (checkbox2.checked == false)){
        console.log("seleccion el porcentaje");
    }
    
    else {window.location.href = "factura.html";}

}

const obtenerrrrrr = async () => {
	const respuesta = await fetch("http://localhost:3001/reservas/casass", {
		method: "get",
	});
	metodosrrrr = await respuesta.json();
    console.log("Metoress", metodosrrrr);
   // listaMetodosPago();
};

obtenerrrrrr();