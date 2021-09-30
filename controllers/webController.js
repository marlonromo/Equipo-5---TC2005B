const { query } = require('express');
const { sql, poolPromise } = require('../database/db');

class MainController {
  async getPlayers(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .query('select namePlayer from [dbo].[Players]');
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async getPlayer(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .input('id', sql.Int, req.params.id)
        .query('select * from [dbo].[Usuario] where idUsuario = @id');
      var id = req.params.id;
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async addPlayer(req, res) {
    try {
      if (
        req.body.Nombre != null &&
        req.body.Apellido != null &&
        req.body.Email != null &&
        req.body.Password != null &&
        req.body.EsAdministrador != null
      ) {
        const pool = await poolPromise;
        const result = await pool
          .request()
          .input('nombre', sql.VarChar, req.body.Nombre)
          .input('apellido', sql.VarChar, req.body.Apellido)
          .input('email', sql.VarChar, req.body.Email)
          .input('pass', sql.VarChar, req.body.Password)
          .input('admin', sql.Bit, req.body.EsAdministrador)
          .query(
            'insert into [dbo].[Usuario] values(@nombre, @apellido, @email, @pass, @admin) EXECUTE SPUpdatePlayer 0, 0, @nombre, 3000, 0, 0, 0 , 1'
          );
        res.json(result);
      } else {
        res.send('Por favor llena todos los datos!');
      }
    } catch (error) {
      console.log(error);
      res.status(500);
      res.send(error.message);
    }
  }
  async updatePlayer(req, res) {
    try {
      if (
        req.body.idUsuario != null &&
        req.body.Nombre != null &&
        req.body.Apellido != null &&
        req.body.Email != null &&
        req.body.Contraseña != null &&
        req.body.EsAdministrador != null
      ) {
        const pool = await poolPromise;
        const result = await pool
          .request()
          .input('id', sql.Int, req.body.idUsuario)
          .input('newNombre', sql.VarChar, req.body.Nombre)
          .input('newApellido', sql.VarChar, req.body.Apellido)
          .input('newEmail', sql.VarChar, req.body.Email)
          .input('newPass', sql.VarChar, req.body.Contraseña)
          .input('newAdmin', sql.Bit, req.body.EsAdministrador)
          .query(
            'update [dbo].[Usuario] set Nombre = @newNombre, Apellido = @newApellido, Email = @newEmail, Contraseña = @newPass, EsAdministrador = @newAdmin where idUsuario = @id'
          );
        res.json(result);
      } else {
        res.send('Todos los campos obligatorios!');
      }
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async deletePlayer(req, res) {
    try {
      if (req.params.id != null) {
        const pool = await poolPromise;
        const result = await pool
          .request()
          .input('id', sql.Int, req.params.id)
          .query('delete from [dbo].[Usuario] where idUsuario = @id');
        res.json(result);
      } else {
        res.send('Agrega el id del jugador!');
      }
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async getWord(req, res) {
    /*la operación que manda hacer el swagger, es en la que se pone el query */
    try {
      const pool = await poolPromise;
      const result = await pool.request().query('select * from [dbo].[Quiz]');
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async login(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .input('email', sql.VarChar, req.params.email)
        .query(
          'SELECT Email, Pass, IsAdmin, IDUsuario FROM [dbo].[Usuario] WHERE Email = @email'
        );
      var email = req.params.email;
      res.json(result.recordset);
    } catch (error) {
      console.log(error);
      res.status(500);
      res.send(error.message);
    }
  }
  async getStatistics(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .query('SELECT Statistic.*, Usuario.Nombre, Usuario.Apellido, Usuario.EsAdministrador FROM Statistic INNER JOIN Usuario ON Usuario.IDUsuario = Statistic.playerID  WHERE Usuario.EsAdministrador = 0');
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async getStatisticsName(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .input('playerName', sql.VarChar, req.params.name)
        .query(
          'SELECT s.playerID, s.statisticID, s.timeDate, s.constructionNumber, s.totalMoney, s.totalSteel, s.totalContract, s.playerExperience,s.totalIron,s.totalUnpackageSteel, s.ironToSteelTransform, u.IDUsuario, u.EsAdministrador FROM Statistic AS s join Player AS p ON s.playerID = p.playerID join Usuario AS u ON s.playerID = u.IDUsuario WHERE p.playerName = @playerName AND u.EsAdministrador = 0'
        );
      var id = req.params.name;
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async getStatisticsID(req, res) {
    try {
      const pool = await poolPromise;
      const result = await pool
        .request()
        .input('id', sql.VarChar, req.params.id)
        .query('SELECT * FROM [dbo].[Statistic] WHERE playerID = @id');
      var id = req.params.id;
      res.json(result.recordset);
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  } 
  async addImg(req, res) {
    try {
      if (req.body.questionImage != null) {
        const pool = await poolPromise;
        const result = await pool
          .request()
          .input('questionImage', sql.VarChar, req.body.questionImage)
          .query(
            'insert into [dbo].[Quiz] values(@questionImage, @questionImage)'
          );
        res.json(result);
      } else {
        res.send('Error, llena los datos');
      }
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
  async deleteImg(req, res) {
    try {
      if (req.params.questionImage != null) {
        const pool = await poolPromise;
        const result = await pool
          .request()
          .input('questionImage', sql.VarChar, req.params.questionImage)
          .query(
            'delete from [dbo].[Quiz] where questionImage = @questionImage'
          );
        res.json(result);
      } else {
        res.send('Agrega el nombre de la imagen!');
      }
    } catch (error) {
      res.status(500);
      res.send(error.message);
    }
  }
}

const webController = new MainController();
module.exports = webController;
