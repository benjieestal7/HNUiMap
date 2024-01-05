const express = require("express");
const building = express.Router();
//const cors = require("cors");
const db = require("../database/config");
//const csrf = require('csurf');
//const config = require('../database/config.json');

//const security = require('../database/security');

building.get('/get', (req, res) => {
    db.sequelize.query('CALL sp_building_get(:pin_category)', {
        replacements: {
            pin_category: req.query.pin_category
        }
    }).then((data) => {
        res.json(data);
    }).catch(err => {
        res.send({ error: true, message: `Error 767: ${err}` });
    });
});

module.exports = building;