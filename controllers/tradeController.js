const { sql,poolPromise } = require('../database/db')

class MainController {

    async getTrade(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .query("EXECUTE SPGetTrade @playerID")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async createTrade(req, res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('playerToTradeID', sql.Int, req.params.playerToTradeID)
            .input('steelAmount', sql.Int, req.body.steelAmount)
            .input('steelCost', sql.Int, req.body.steelCost)
            .query("EXECUTE SPCreateTrade @playerID, @playerToTradeID, @steelAmount, @steelCost")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async modifyTrade(req, res){
        try {
            console.log(req.body)
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('playerToTradeID', sql.Int, req.params.playerToTradeID)
            .input('newSteelAmount', sql.Int, req.body.steelAmount)
            .input('newSteelCost', sql.Int, req.body.steelCost)
            .input('acceptTradeP1', sql.Int, req.body.acceptTrade1)
            .input('acceptTradeP2', sql.Int, req.body.acceptTrade2)
            .query("EXECUTE SPModifyTrade @playerID, @playerToTradeID, @newSteelAmount, @newSteelCost, @acceptTradeP1, @acceptTradeP2")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async acceptTrade(req, res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('playerToTradeID', sql.Int, req.params.playerToTradeID)
            .query("EXECUTE SPAcceptTrade @playerID, @playerToTradeID")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }

    async deleteTrade(req, res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('playerToTradeID', sql.Int, req.params.playerToTradeID)
            .query("EXECUTE SPDeleteTrade @playerID, @playerToTradeID")
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
}

const tradeController = new MainController()
module.exports = tradeController;