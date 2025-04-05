const { TYPES } = require('mssql');
var getConection = require('../index');

const obtenerVehiculos = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query(`select * from datos_vehiculos`);
    // console.log(result.recordset);
    res.send(result.recordset);
}



exports.obtenerVehiculos = obtenerVehiculos;


const obtenerTipoVehoculo = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT * FROM tipoVehiculo');
    // console.log(result.recordset);
    res.send(result.recordset);
}



exports.obtenerTipoVehoculos = obtenerTipoVehoculo;

const obtenerModeloVehiculo = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT * FROM modelo');
    // console.log(result.recordset);
    res.send(result.recordset);
}

exports.obtenerModeloVehiculo = obtenerModeloVehiculo;


const obtenerMarcaVehiculo = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT * FROM marca');
    // console.log(result.recordset);
    res.send(result.recordset);
}

exports.obtenerMarcaVehiculo = obtenerMarcaVehiculo;

const insertarReservaVehiculo = async (req,res) =>{
    const {idVehiculo, 
        idReserva, 
        precioVehiculo, 
        impuestoVehiculo}=req.body;
    const pool = await getConection.conector();
    const result = await pool
    .request()
    .input('idVehiculo', TYPES.VarChar, idVehiculo)
    .input('idReserva', TYPES.VarChar, idReserva)
    .input('precioVehiculo', TYPES.VarChar, precioVehiculo)
    .input('impuestoVehiculo', TYPES.VarChar, impuestoVehiculo)
    .query(`INSERT INTO persona (
        idVehiculo, idReserva, precioVehiculo, impuestoVehiculo) 
    VALUES (
        @idVehiculo, @idReserva, @precioVehiculo, @impuestoVehiculo)`
        );
//    console.log('Usuario creado exitosamente');
   res.send('vehiculo reservado');
}

exports.insertarReservaVehiculo = insertarReservaVehiculo