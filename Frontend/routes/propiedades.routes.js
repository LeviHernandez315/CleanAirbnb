var express = require('express');
var router = express.Router();

var propiedadController = require('../controllers/propiedades.controllers')

router.get('/', propiedadController.obtenerPropiedades);


module.exports = router;