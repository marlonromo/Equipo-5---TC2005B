const botonAgregar = document.getElementById('botonAgregar');
const botonEliminar = document.getElementById('botonEliminar');
const botonAgregarPregunta = document.getElementById('botonAgregarPregunta');

const question = document.getElementById('question');
const rightAnswer = document.getElementById('rightAnswer');
const wrongAnswers = document.getElementsByClassName('wrongAnswer');
const imgN = document.getElementById('imgInput');


botonAgregar.addEventListener('click', () => {
  axios({
    method: 'POST',
    url: 'http://localhost:4000/api/addImg',
    data: {
      questionImage: imgN.value
    }
  })
    .then(res => {
      alert(`Imagen agregada con exito`);
    })
    .catch(err => console.log(err));
});

botonEliminar.addEventListener('click', () => {
  axios({
    method: 'delete',
    url: 'http://localhost:4000/api/deleteImg/' + imgN.value,
    data: {
      questionImage: imgN.value
    }
  })
    .then(res => {
      alert(`Imagen eliminada con exito`);
    })
    .catch(err => console.log(err));
});


botonAgregarPregunta.addEventListener('click', () => {

  axios({
    method: 'POST',
    url: 'http://localhost:4000/api/addQuestion/',
    data: {
      question: question.value,
      rightAnswer: rightAnswer.value,
      wrongAnswers: [wrongAnswers[0].value, wrongAnswers[1].value, wrongAnswers[2].value]
    }
  })
    .then(res => {
      alert(`Pregunta añadida con exito`);
    })
    .catch(err => console.log(err));
});
