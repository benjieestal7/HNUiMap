const express = require("express");
const auth = express.Router();
const cors = require("cors");
const jwt = require("jsonwebtoken");
const db = require("../database/config");
const csrf = require('csurf');
const csrfProtection = csrf({ cookie: true });
const security = require('../database/security');
var cookieParser = require('cookie-parser')

auth.use(cors());
auth.use(cookieParser())
require('dotenv').config()
const corsOptions = {
    origin: true,
    credentials: true,
}
auth.use(cors());
// auth.use(csrfProtection);
// auth.use(security.verifyCSRF);

auth.get('/csrf', (req, res) => {
    res.send({ csrfToken: req.csrfToken(), error: false, });
});

auth.post('/login', (req, res) => {
    db.sequelize.query('CALL sp_users_login(:username, :password)', {
        type: db.sequelize.QueryTypes.SELECT,
        replacements: {
            username: req.body.username,
            password: req.body.password
        }
    }).then((user) => {
        if (user.length > 0) {
            const data = db.MultiQueryResult(user);
            if (data.result0.length > 0) {
                const token = jwt.sign({ data: data.result0[0] }, process.env.PUBLICVAPIDKEY, { expiresIn: '8h' });
                const privileges = user[1];
                const units = data.result2;
                res.json({ error: false, token, privileges, units });
            } else {
                res.send({ error: true, message: `User Not Found!` });
            }
        } else {
            res.send({ error: true, message: `User Not Found!` });
        }
    }).catch(err => {
        res.send({ error: true, message: `Error 767: ${err}` });
    });
});

auth.post('/validatelogin', (req, res) => {
    db.sequelize.query('CALL sp_users_login2(:username, :password)', {
        replacements: {
            username: req.body.username,
            password: req.body.password
        }
    }).then((data) => {
        res.json({ error: false, returnd: 'validated' });
    }).catch(err => {
        res.send({ error: true, message: `Error 767: ${err}` });
    });
});


auth.post('/authCheck', (req, res) => {
    jwt.verify(req.body.session, process.env.PUBLICVAPIDKEY, (err, decoded) => {
        if (err) {
            res.send({ sessionValidate: false, error: true, errormsg: `${err.name}: ${err.message}: ${err.expiredAt}` });
        } else {
            res.send({ sessionValidate: true, error: false, });
            db.sequelize.query('CALL sp_users_login2(:username, :password)', {
                replacements: {
                    username: decoded.data.username,
                    password: decoded.data.password
                }
            }).then(data => {
                if (data.length > 0) {
                    res.send({ sessionValidate: true, error: false, });
                } else {
                    res.set('Content-Type', 'text/plain')
                    res.send({ error: true, message: "Error Code 505: Forbidden Access. Please re-login" });
                }
            }).catch(err => {
                res.send({ error: true, message: `Error 504: ${err}` });
            });
        }
    });
});

module.exports = auth;