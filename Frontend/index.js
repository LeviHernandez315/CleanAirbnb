const express = require('express');
const sql = require('mssql');
const BD = require('./utils/database');
const cors=require('cors');
const bodyParser= require('body-parser');
const personasRaouter = require('./routes/personas.routes');
const vehiculosRouters =require('./routes/vehiculos.routers');
const propiedadesRouters=require('./routes/propiedades.routes');
const metodoPagoRouters = require('./routes/metodoPago.routes');
const reservasRouters = require('./routes/reservas.routers');
const puerto=3001;


const app = express();

//mildrewers
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended:true}));


app.get('/', (req, res) => {
    res.send('Probando backend de Airbnb');
});

app.listen(puerto, () => {
	console.log(`Servidor Levantado en https://localhost:${puerto}`);
});



app.use('/personas', personasRaouter);
app.use('/vehiculos', vehiculosRouters);
app.use('/propiedad', propiedadesRouters);
app.use('/metodoPago', metodoPagoRouters);
app.use('/reservas', reservasRouters);



async function conector() {
    try {
    const pool = await sql.connect(BD);
    console.log('Conexión exitosa a SQL Server');
    // Consulta SQL
      // const query = 'SELECT * FROM usuarios';
  
      // Ejecutar la consulta
    //  const result = await sql.query(query);
  
      // Imprimir los resultados
      // console.log(result.recordset);
      return pool;
    } catch (error) {
    console.error('Error al conectar a SQL Server:', error);
    }
}

conector();

exports.conector = conector;

// module.exports = conector

