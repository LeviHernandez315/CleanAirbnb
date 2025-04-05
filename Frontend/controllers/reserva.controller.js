const { TYPES } = require('mssql');
var getConection = require('../index');

const insertarRerserva = async (req,res) =>{
    const {fechaCheckIn, 
        fechaCheckOut, 
        cantidadPersonas,
        idPropiedad,
        idHuesped}=req.body;
    const pool = await getConection.conector();
    const result = await pool
    .request()
    .input('fechaCheckIn', TYPES.Date, fechaCheckIn)
    .input('fechaCheckOut', TYPES.Date, fechaCheckOut)
    .input('numeroHuespedes', TYPES.Int, cantidadPersonas)
    .input('idPropiedad', TYPES.Int, idPropiedad)
    .input('idHuesped', TYPES.Int, idHuesped)
    .query(`INSERT INTO reserva(
        fechaCheckIn, fechaCheckOut, numeroHuespedes, idPropiedad, idHuesped
    )
    values(
        @fechaCheckIn, @fechaCheckOut, @numeroHuespedes, @idPropiedad, @idHuesped
    )`
    );
    res.send('reserva insertado');
}

exports.insertarRerserva = insertarRerserva

const obtenerIdReservaCasa = async (req, res) =>{
    const {
        fechaCheckIn1,
        idPropiedad1,
        idHuesped1} = req.body
    const pool = await getConection.conector();
    const result = await pool
    .request()
    .input('fechaCheckIn', TYPES.Date, fechaCheckIn1)
    .input('idPropiedad', TYPES.Int, idPropiedad1)
    .input('idHuesped', TYPES.Int, idHuesped1)
    .query(` select id from reserva where FechaCheckIn = @fechaCheckIn
            and idPropiedad = @idPropiedad
            and idHuesped = @idHuesped`
        );
//    console.log('Usuario creado exitosamente');
    const idencontrado = result.recordset[0]
   res.send(idencontrado);
}

exports.obtenerIdReservaCasa = obtenerIdReservaCasa

const obtenerredddd = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT TOP 1 * FROM reserva ORDER BY id DESC');
    // console.log(result.recordset);
    res.send(result.recordset);
}

exports.obtenerredddd = obtenerredddd;