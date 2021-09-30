

const { sql,poolPromise } = require('../database/db')

class MainController {

    async getContract(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('contractID', sql.Int, req.params.id)
            .query("EXECUTE SPGetLastContract @contractID")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
    async updateContract(req , res){
        try {
            console.log(req.body)
            if(req.params.id != null && req.params.contractID != null && req.body.title != null && req.body.description != null && req.body.steelRequirement != null && req.body.moneyReward != null && req.body.timeRemaining != null && req.body.penalization != null && req.body.success != null && req.body.isActive != null){
                console.log(req.body.playerID + ',' + req.body.contractGameID + ',' + req.body.title + ',' + req.body.description + ',' + req.body.steelRequirement + ',' +req.body.moneyReward + ',' + req.body.timeRemaining + ',' + req.body.penalization + ',' + req.body.success + ',' + req.body.isActive)
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID', sql.Int, req.params.id)
                .input('contractID', sql.Int, req.params.contractID)
                .input('title', sql.VarChar, req.body.title)
                .input('description', sql.VarChar, req.body.description)
                .input('steelRequirement', sql.Int, req.body.steelRequirement)
                .input('moneyReward', sql.Int, req.body.moneyReward)
                .input('timeRemaining', sql.Float, req.body.timeRemaining)
                .input('penalization', sql.Float, req.body.penalization)
                .input('success', sql.Int, req.body.success)
                .input('isActive', sql.Int, req.body.isActive)
                .query("EXECUTE SPUpdateContract @playerID, @contractID, @title, @description, @steelRequirement, @moneyReward, @timeRemaining, @penalization, @success, @isActive")
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

const contractController = new MainController()
module.exports = contractController;