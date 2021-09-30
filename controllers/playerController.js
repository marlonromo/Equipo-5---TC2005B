// import express from 'express'

const { sql,poolPromise } = require('../database/db')

class MainController {

    async getPlayer(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('id',sql.Int, req.params.id)
            .query("EXECUTE SPGetPlayer @id")
            var id = req.params.id
            console.log('hola:' + id)
            res.json(result.recordset)
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
    async addPlayer(req , res){
        try {
            if(req.body.IDJugador != null && req.body.experiencePlayer != null && req.body.playerName != null && req.body.scoreMoney != null && req.body.scoreIron != null && req.body.scoreUnpackageSteel != null && req.body.scoreSteel != null && req.body.difficulty !=null) {
            const pool = await poolPromise
            const result = await pool.request()
            .input('IDJugador',sql.Int, req.body.IDJugador)
            .input('experiencePlayer',sql.Int, req.body.experiencePlayer)
            .input('playerName',sql.VarChar, req.body.playerName)
            .input('scoreMoney',sql.Int, req.body.scoreMoney)
            .input('scoreIron',sql.Int, req.body.scoreIron)
            .input('scoreUnpackageSteel',sql.Int, req.body.scoreUnpackageSteel)
            .input('scoreSteel',sql.Int, req.body.scoreSteel)
            .query("insert into [dbo].[Player] values(@IDJugador, @experiencePlayer, @playerName, @scoreMoney, @scoreIron, @scoreUnpackageSteel, @scoreSteel, @difficulty)")
            res.json(result)
            } else {
                res.send('Por favor llena todos los datos!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
    async updatePlayer(req, res){
        try {
            if(req.params.id != null && req.body.playerExperience != null && req.body.playerName != null && req.body.scoreMoney != null && req.body.scoreIron != null && req.body.scoreUnpackageSteel != null && req.body.scoreSteel != null && req.body.difficulty !=null) {
                const pool = await poolPromise
                const result = await pool.request()
                .input('playerID',sql.Int , req.params.id)
                .input('playerExperience',sql.Int , req.body.playerExperience)
                .input('playerName',sql.VarChar , req.body.playerName)
                .input('scoreMoney',sql.Int , req.body.scoreMoney)
                .input('scoreIron',sql.Float , req.body.scoreIron)
                .input('scoreUnpackageSteel',sql.Float, req.body.scoreUnpackageSteel)
                .input('scoreSteel',sql.Float, req.body.scoreSteel)
                .input('difficulty',sql.Int, req.body.difficulty)          
                .query("EXECUTE SPUpdatePlayer @playerID, @playerExperience, @playerName, @scoreMoney, @scoreIron, @scoreUnpackageSteel, @scoreSteel,@difficulty")
                res.json(result)
            } else {
                res.send('Todos los campos obligatorios!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
    async deletePlayer(req , res){
        try {
            if(req.params.IDJugador != null ) {
                const pool = await poolPromise
                const result = await pool.request()
                .input('id',sql.VarChar, req.params.id)
                .query("delete from [dbo].[Player] where id = @id")
                res.json(result)
                } else {
                res.send('Agrega el id del jugador!')
            }
        } catch (error) {
            res.status(500)
            res.send(error.message)
        }
    }
}

const playerController = new MainController()
module.exports = playerController;