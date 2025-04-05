const { TYPES } = require('mssql');
var getConection = require('../index');



const obtenerMetodoPago = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT * FROM metodoPago');
    // console.log(result.recordset);
    res.send(result.recordset);
}

exports.obtenerMetodoPago = obtenerMetodoPago;