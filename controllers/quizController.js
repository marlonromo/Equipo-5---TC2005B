const { sql,poolPromise } = require('../database/db')

class MainController{
    async getChoiceQuiz(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .query("EXECUTE SPGetChoiceQuiz @playerID")
            res.json(result.recordset)
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }
    async updateChoiceQuiz(req , res){
        try {
            const pool = await poolPromise
            const result = await pool.request()
            .input('playerID', sql.Int, req.params.id)
            .input('quizID', sql.Int, req.params.quizID)
            .query("EXECUTE SPUpdateChoiceQuiz @playerID, @quizID")
            res.json(result.recordset)
        } catch (error) {
            console.log(error)
            res.status(500)
            res.send(error.message)
        }
    }
}

const quizController = new MainController()
module.exports = quizController;