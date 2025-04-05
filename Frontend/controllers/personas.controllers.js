const { TYPES } = require('mssql');
var getConection = require('../index');

const obtenerUsuarios = async (req, res) =>{
    const pool = await getConection.conector();
    const result = await pool.request().query('SELECT * FROM usuario');
    // console.log(result.recordset);
    res.send(result.recordset);
}


exports.obtenerUsuarios = obtenerUsuarios;

const insertarPersona = async (req,res) =>{
    const {dni, 
        primerNombre, 
        segundoNombre, 
        primerApellido, 
        segundoApellido, 
        edad,
        fechaNacimiento,
        rtn}=req.body;
    const pool = await getConection.conector();
    const result = await pool
    .request()
    .input('dni', TYPES.VarChar, dni)
    .input('primerNombre', TYPES.VarChar, primerNombre)
    .input('segundoNombre', TYPES.VarChar, segundoNombre)
    .input('primerApellido', TYPES.VarChar, primerApellido)
    .input('segundoApellido', TYPES.VarChar, segundoApellido)
    .input('edad', TYPES.Int, edad)
    .input('fechaNacimiento', TYPES.Date, fechaNacimiento)
    .input('rtn', TYPES.VarChar, rtn)
    .query(`INSERT INTO persona (
        dni, primerNombre, segundoNombre, primerApellido, segundoApellido,
        edad, fechaNacimiento, rtn) 
    VALUES (
        @dni, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido,
        @edad, @fechaNacimiento, @rtn)`
        );
//    console.log('Usuario creado exitosamente');
   res.send('usuario creado');
}
exports.insertarPersona = insertarPersona;

const insertarUsuario = async (req,res) =>{
    const {dni, 
        email, 
        contraseña}=req.body;
    const pool = await getConection.conector();
    const result = await pool
    .request()
    .input('dni', TYPES.VarChar, dni)
    .input('email', TYPES.VarChar, email)
    .input('contraseña', TYPES.VarChar, contraseña)
    // .input('idRol', TYPES.Int, 3)
    .query(`INSERT INTO usuario(
        email, contraseña, dni
    )
    values(
        @email, @contraseña, @dni
    )`
    );
    res.send('usuario insertado');
}

exports.insertarUsuario = insertarUsuario