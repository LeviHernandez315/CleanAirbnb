var express = require('express');
var router = express.Router();
var vehiculosController = require('../controllers/vehiculos.controllers')

router.get('/', vehiculosController.obtenerVehiculos);
router.get('/marca', vehiculosController.obtenerMarcaVehiculo);
router.get('/modelo', vehiculosController.obtenerModeloVehiculo);
router.get('/tipovehiculo', vehiculosController.obtenerTipoVehoculos);


router.get('/obtenerVehiculoPorId', vehiculosController.obtenerVehiculos);
module.exports = router;

