const express = require("express");
const account = express.Router();
const cors = require("cors");
const db = require("../database/config");
const csrf = require('csurf');
const config = require('../database/config.json');

const security = require('../database/security');

account.post('/save', (req, res) => {
    db.sequelize.query("CALL sp_account_save(:id, :name, :email, :username, :password, :user_role)", {
        replacements: {
            id: parseInt(req.body.id),
            name: req.body.name,
            email: req.body.email,
            username: req.body.username,
            password: req.body.password,
            user_role: req.body.user_role,
        }
    }).then(data => {
        ret = data[0]["_ret"];
        if (ret === "add_successfully") {
            res.send(`User Successfully added.`);
        } else if (ret === "edit_successfully") {
            res.send(`User Successfully updated.`);
        } else if (ret === "username_duplicate") {
            res.send(`Username already taken.`);
        } else {
            res.send(`Unknown error.`);
        }
    }).catch(err => {
        res.send({ error: true, message: `Error 767: ${err}` });
    });
});


account.post('/login', (req, res) => {
    db.sequelize.query('CALL sp_account_login(:username, :password)', {
        type: db.sequelize.QueryTypes.SELECT,
        replacements: {
            username: req.body.username,
            password: req.body.password
        }
    }).then((data) => {
        const data_ret = db.MultiQueryResult(data);
        let details = data_ret.result0[0].hasOwnProperty('_ret') ? false : data_ret.result0;
        res.send(details ? details : 'No data found');
    }).catch(err => {
        res.send('No data found');
    });
});

module.exports = account;