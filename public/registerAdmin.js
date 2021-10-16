const boton = document.getElementById('boton');

const userName = document.getElementById('nameInput');
const lastName = document.getElementById('lastnameInput');
const email = document.getElementById('emailInput');
const password = document.getElementById('passwordInput');

const headers = {
  'Content-Type': 'application/json',
  Authorization: 'JWT fefege...'
};

boton.addEventListener('click', () => {
  if(userName.value =="" || lastName.value =="" || email.value=="" || password.value==""){
    alert("Error, favor de llenar todos los datos");
  }
  else{
    axios({
      method: 'POST',
      url: 'http://localhost:4000/api/addPlayer',
      data: {
        Nombre: userName.value,
        Apellido: lastName.value,
        Email: email.value,
        Password: password.value,
        EsAdministrador: true
      },
      headers: headers
    })
      .then(res => {
        alert(`Registrado.`);
        console.log(res.data);
      })
      .catch(err => console.log(err));
    }
});
