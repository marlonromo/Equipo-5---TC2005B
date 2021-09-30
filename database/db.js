const sql = require('mssql');
// Server=tcp:equipo5.database.windows.net,1433;Initial Catalog=equipo5Web;Persist Security Info=False;User ID=equipo5Admin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
const config = {
    user: 'equipo5Admin',
    password: 'equipo5*',
    database: 'equipo5Web',
    server: 'equipo5.database.windows.net',
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
