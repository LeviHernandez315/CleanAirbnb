var express = require('express');
var router = express.Router();

var meotodoPagoController = require('../controllers/metodoPago.controllers')

router.get('/', meotodoPagoController.obtenerMetodoPago);


module.exports = router;