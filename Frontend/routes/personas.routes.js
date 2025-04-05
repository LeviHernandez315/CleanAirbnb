var express = require('express');
var router = express.Router();
var personasController = require('../controllers/personas.controllers')

router.get('/', personasController.obtenerUsuarios);
router.post('/', personasController.insertarPersona);
router.post('/usuarios', personasController.insertarUsuario);

module.exports = router;