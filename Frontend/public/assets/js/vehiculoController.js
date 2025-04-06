let vehiculos = [];
let modelos = [];
let tiposVehiculo = [];
let vehiculosSeleccionados = [];

const emailCliente = localStorage.getItem("email");

// Mostrar el nombre del usuario
const renderizarNombreUsuario = () => {
  document.getElementById("nombreUsee").textContent = emailCliente || "Invitado";
};

// Cargar datos desde el backend
const cargarDatos = async () => {
  try {
    const [resVehiculos, resModelos, resTipos] = await Promise.all([
      fetch("http://localhost:5139/api/vehiculos"),
      fetch("http://localhost:5139/api/modelos"),
      fetch("http://localhost:5139/api/tipovehiculo")
    ]);

    vehiculos = await resVehiculos.json();
    modelos = await resModelos.json();
    tiposVehiculo = await resTipos.json();

    renderizarVehiculos();
  } catch (error) {
    console.error("Error al cargar datos:", error);
    alert("Error al conectar con el servidor.");
  }
};

// Obtener el nombre del modelo
const getNombreModelo = (idModelo) => {
  const modelo = modelos.find(m => m.id === idModelo);
  return modelo ? modelo.descripcion : "Modelo desconocido";
};

// Obtener el tipo de vehículo
const getNombreTipo = (idTipo) => {
  const tipo = tiposVehiculo.find(t => t.id === idTipo);
  return tipo ? tipo.descripcion : "Tipo desconocido";
};

// Renderizar tarjetas de vehículos
const renderizarVehiculos = () => {
  const contenedor = document.getElementById("idparaRendVehi");
  contenedor.innerHTML = "";

  vehiculos.forEach((vehiculo, index) => {
    contenedor.innerHTML += `
      <div class="col">
        <div class="card h-100">
          <img src="${vehiculo.imagenUrl}" class="imgCar" alt="Vehículo">
          <div class="card-body">
            <h5 class="card-title text-black">${getNombreModelo(vehiculo.idModelo)}</h5>
            <p class="card-text text-black">Año: ${vehiculo.año}</p>
            <p class="card-text text-black">Tipo: ${getNombreTipo(vehiculo.idTipoVehiculo)}</p>
            <p class="card-text text-black">Precio por día: L. ${vehiculo.precioDia}</p>
            <button onclick="agregarVehiculo(${index})" type="button" class="btn btn-primary">Agregar</button>
          </div>
        </div>
      </div>
    `;
  });
};

// Agregar vehículo a la lista de seleccionados
const agregarVehiculo = (index) => {
  const vehiculo = vehiculos[index];
  const yaAgregado = vehiculosSeleccionados.some(v => v.id === vehiculo.id);

  if (!yaAgregado) {
    vehiculosSeleccionados.push(vehiculo);
    renderizarVehiculosSeleccionados();
  }
};

// Mostrar vehículos agregados en el sidebar
const renderizarVehiculosSeleccionados = () => {
  const lista = document.getElementById("listaCarros");
  lista.innerHTML = "";

  vehiculosSeleccionados.forEach((v, i) => {
    lista.innerHTML += `
      <div class="text-black p-2 border-bottom">
        <p>${getNombreModelo(v.idModelo)} - L. ${v.precioDia}</p>
        <button onclick="removerVehiculo(${i})" class="btn btn-sm btn-danger">Quitar</button>
      </div>
    `;
  });

  localStorage.setItem("vehiculosSeleccionados", JSON.stringify(vehiculosSeleccionados));
};

// Quitar vehículo de la lista
const removerVehiculo = (index) => {
  vehiculosSeleccionados.splice(index, 1);
  renderizarVehiculosSeleccionados();
};

// Redirigir a la siguiente página
const pasarFactura = () => {
  if (vehiculosSeleccionados.length === 0) {
    alert("Debes seleccionar al menos un vehículo.");
    return;
  }

  window.location.href = "pago.html";
};

// Inicialización
renderizarNombreUsuario();
cargarDatos();
