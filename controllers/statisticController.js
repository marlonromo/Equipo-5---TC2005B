const { sql,poolPromise } = require('../database/db')

class MainController {

    async newStatistic(req, res){
        try {
            console.log("Test")
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('inputTransform', sql.Int, req.params.inputTransform)
            .query("EXECUTE SPInsertStatistic @playerID, @inputTransform")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
}

const statisticController = new MainController()
module.exports = statisticController;