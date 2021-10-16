const botonAgregar = document.getElementById('botonAgregar');
const botonEliminar = document.getElementById('botonEliminar');
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
