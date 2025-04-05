var express = require('express');
var router = express.Router();
var reservasController = require('../controllers/reserva.controller')

// router.get('/', reservasController.obtenerUsuarios);
router.post('/', reservasController.insertarRerserva);
router.post('/casa', reservasController.obtenerIdReservaCasa);
router.get('/casass', reservasController.obtenerredddd);

module.exports = router;