/*let nomvehiculo= localStorage.getItem("vehiculo");
//console.log(nomvehiculo);
let idPropiedadFactura = localStorage.getItem("propiedad");
let hhh=  JSON.parse(idPropiedadFactura);
console.log(hhh);
let nomClienteCompleto= localStorage.getItem("clientecomleto");
let yy=JSON.parse(nomClienteCompleto);
console.log(yy);

let rtr=localStorage.getItem("begii");

console.log(rtr);



let nomCrrr= localStorage.getItem("ppreee");
let norrr= localStorage.getItem("totaVehiculo");
wee=(parseFloat(nomCrrr))+(parseFloat(norrr));

const renderizaTargetaFactura= () =>{  
    document.getElementById("Factura").innerHTML= "";
   
        document.getElementById("Factura").innerHTML = 
        `  <img src="${hhh.urlImagen}" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">${hhh.nombre}</h5>
          <p class="card-text">S${hhh.descripcion}</p>
        </div>
        <ul class="list-group list-group-flush">
          <li class="list-group-item">Auto: ${rtr} </li>
         
        </ul>
        <div class="card-body">
          <a >Total:</a>
          <a > ${wee}</a>
        </div>     
        `
    
}
renderizaTargetaFactura();

const renderizalaMeraFactura= () =>{  

  document.getElementById("FtotalPago").innerHTML=  `${wee}`;
  document.getElementById("FimpPago").innerHTML=  `${wee*0.13}`;
  document.getElementById("FsubtotalPago").innerHTML=  `${wee-(wee*0.13)}`;



 



  
}
renderizalaMeraFactura();
 */

// Obtener datos
// Obtener datos del localStorage
const propiedad = JSON.parse(localStorage.getItem("propiedad"));
const cliente = JSON.parse(localStorage.getItem("clientecomleto"));
const vehiculos = JSON.parse(localStorage.getItem("vehiculosSeleccionados")) || [];
const fechaInicio = localStorage.getItem("fechaCheckIn") || "-";
const fechaFin = localStorage.getItem("Ffinal") || "-";
const total = parseFloat(localStorage.getItem("totalFinalPago")) || 0;
const dias = parseInt(localStorage.getItem("difDias")) || 1;

// Renderizar tarjeta resumen (parte izquierda)
const renderizaTargetaFactura = () => {
  const contenedor = document.getElementById("Factura");

  contenedor.innerHTML = `
    <img src="${propiedad?.imagenUrl || "assets/img/casa.jpg"}" class="card-img-top" alt="...">
    <div class="card-body">
      <h5 class="card-title">${propiedad?.nombre || "Propiedad"}</h5>
      <p class="card-text">${propiedad?.descripcion || "Sin descripción"}</p>
    </div>
    <ul class="list-group list-group-flush">
      <li class="list-group-item">Vehículos alquilados: ${vehiculos.length}</li>
      <li class="list-group-item">Días de estadía: ${dias}</li>
    </ul>
    <div class="card-body">
      <strong>Total:</strong> L. ${total.toFixed(2)}
    </div>
  `;
};

// Renderizar tabla de servicios (parte derecha)
const renderizarServicios = () => {
  const tabla = document.getElementById("tablaServicios");
  tabla.innerHTML = "";

  if (propiedad) {
    tabla.innerHTML += `
      <tr>
        <td>${propiedad.nombre} (${dias} noche${dias > 1 ? "s" : ""})</td>
        <td>${fechaInicio}</td>
        <td>${fechaFin}</td>
        <td>L. ${(propiedad.precioPorNoche * dias).toFixed(2)}</td>
      </tr>
    `;
  }

  vehiculos.forEach(v => {
    tabla.innerHTML += `
      <tr>
        <td>Vehículo ${v.idModelo} (${v.año})</td>
        <td>${fechaInicio}</td>
        <td>${fechaFin}</td>
        <td>L. ${(v.precioDia * dias).toFixed(2)}</td>
      </tr>
    `;
  });
};

// Mostrar totales
const renderizarTotales = () => {
  const impuesto = total * 0.13;
  const subtotal = total - impuesto;

  document.getElementById("FtotalPago").textContent = `L. ${total.toFixed(2)}`;
  document.getElementById("FimpPago").textContent = `L. ${impuesto.toFixed(2)}`;
  document.getElementById("FsubtotalPago").textContent = `L. ${subtotal.toFixed(2)}`;
};

// Mostrar cliente
const renderizarCliente = () => {
  const nombre = `${cliente?.persona?.primerNombre || ""} ${cliente?.persona?.primerApellido || ""}`;
  const rtn = cliente?.persona?.rtn || "No disponible";
  const rol = cliente?.rol?.descripcion || "No asignado";

  document.getElementById("nombreCliente").textContent = nombre;
  document.getElementById("rtnCliente").textContent = rtn;
  document.getElementById("rolCliente").textContent = rol;
};

// Fecha emisión
document.getElementById("fechaFactura").textContent = new Date().toLocaleDateString();

// Ejecutar todo
renderizaTargetaFactura();
renderizarServicios();
renderizarTotales();
renderizarCliente();
