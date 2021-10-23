const { sql,poolPromise } = require('../database/db')

class MainController{
    async getMission(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .query("EXECUTE SPGetMission @playerID")
            res.json(result.recordset)
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }
    async updateMission(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.playerID)
            .input('missionID', sql.Int, req.params.missionID)
            .query("EXECUTE SPUpdateMission @playerID, @missionID")
            res.json(result.recordset)
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }
}

const missionController = new MainController()
module.exports = missionController;

