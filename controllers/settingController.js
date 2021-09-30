

const { sql,poolPromise } = require('../database/db')

class MainController {

    async getSetting(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .query("EXECUTE SPGetSetting @playerID")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async updateSetting(req , res){
        try {
            if(req.params.id != null && req.body.volumeMusic != null && req.body.cameraSensibility != null && req.body.cameraSpeed != null){
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID', sql.Int, req.params.id)
                .input('volumeMusic', sql.Float, req.body.volumeMusic)
                .input('cameraSensibility', sql.Float, req.body.cameraSensibility)
                .input('cameraSpeed', sql.Float, req.body.cameraSpeed)
                .query("EXECUTE SPUpdateSetting @playerID, @volumeMusic, @cameraSensibility, @cameraSpeed")
                res.json(result.recordset)
            }
            else{
                res.send('Todos los campos son obligadorios!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async addSetting(req , res){
        try {
            if(req.body.playerID != null && req.body.volumeMusic != null && req.body.cameraSensibility != null && req.body.cameraSpeed != null){
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID', sql.Int, req.body.playerID)
                .input('volumeMusic', sql.Int, req.body.volumeMusic)
                .input('cameraSensibility', sql.Int, req.body.cameraSensibility)
                .input('cameraSpeed', sql.Int, req.body.cameraSpeed)
                .query("EXECUTE SPInsertSetting @playerID, @volumeMusic, @cameraSensibility, @cameraSpeed")
                res.json(result.recordset)
            }
            else{
                res.send('Todos los campos son obligadorios!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
}

const settingController = new MainController()
module.exports = settingController;