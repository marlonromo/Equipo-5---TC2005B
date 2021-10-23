const sql = require('mssql');

const config = {
    user: 'admintsteel',
    password: 'equipo5*',
    database: 'equipo5tsteel',
    server: 'terniumserver.database.windows.net',
    options: {
    trustedConnection: true
    }
};

const poolPromise = new sql.ConnectionPool(config)
  .connect()
  .then(pool => {
    console.log('Connected to MSSQL');
    return pool;
  })
  .catch(err => console.log('Database Connection Failed! Bad Config: ', err));

module.exports = {
  sql,
  poolPromise
};
