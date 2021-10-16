const { sql,poolPromise } = require('../database/db')

class MainController {

    async getBuilding(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .query("EXECUTE SPGetBuilding @playerID")
            res.json(result.recordset)
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }

    async updateBuilding(req , res){
        try {
            if(req.body.playerID != null && req.body.buildingGameID != null && req.body.buildingType != null && req.body.posX != null && req.body.posZ != null && req.body.rotation != null && req.body.attributeBuildingData != null){
                
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID', sql.Int, req.body.playerID)
                .input('buildingGameID', sql.Int, req.body.buildingGameID)
                .input('buildingType', sql.VarChar, req.body.buildingType)
                .input('posX', sql.Float, req.body.posX)
                .input('posZ', sql.Float, req.body.posZ)
                .input('rotation', sql.Float, req.body.rotation)
                .input('attributeBuildingData', sql.VarChar, req.body.attributeBuildingData)
                .query("EXECUTE SPUpdateBuilding @playerID, @buildingGameID, @buildingType, @posX, @posZ, @rotation, @attributeBuildingData")
                res.json(result.recordset)
                console.log("HECHO")
            }
            else{
                res.send('Todos los campos son obligadorios!')
            }
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }

    async deleteBuilding(req , res){
        try {
            console.log(req.params.playerID + ',' + req.params.buildingGameID)
            if(req.params.playerID != null && req.params.buildingGameID){
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID', sql.Int, req.params.playerID)
                .input('buildingGameID', sql.Int, req.params.buildingGameID)
                .query("EXECUTE SPDeleteBuilding @playerID, @buildingGameID")
                res.json(result.recordset)
            }
            else{
                res.send('Todos los campos son obligatorios!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
}

const buildingController = new MainController()
module.exports = buildingController;