let nomvehiculo= localStorage.getItem("vehiculo");
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
