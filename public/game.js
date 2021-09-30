const boton = document.getElementById('progreso');
const url = window.location.href;
const id = url.split('=')[1];

progreso.addEventListener('click', () => {
  window.location = '../cart.html?user_id=' + id;
});
