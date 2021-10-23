const boton = document.getElementById('boton_ing');

const email = document.getElementById('email');
const password = document.getElementById('password');

boton.addEventListener('click', () => {
  axios({
    method: 'GET',
    url: 'http://localhost:4000/api/json/loginPlayer/' + email.value
  })
    .then(res => {
      //const userInfo = res.data;
      console.log(password.value);
      console.log(res.data);

      if (res.data[0].Pass == password.value && res.data[0].IsAdmin==1) {
        window.location = 'admin.html';
      } 
      else if(res.data[0].Pass == password.value && res.data[0].IsAdmin==0){
        console.log("here");
        window.location = 'GameF/index.html?user_id=' + res.data[0].IDUsuario;
      }
      else {
        alert(`Datos incorrectos`);
      }
    })
    .catch(err => console.log(err));
});
