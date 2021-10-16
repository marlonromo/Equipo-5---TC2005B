const boton = document.getElementById('boton');

boton.addEventListener('click', () => {
  console.log('Hola');
  axios({
    method: 'GET',
    url: 'http://localhost:4000/api/getPlayers'
  })
    .then(res => {
      console.log(res.data);
      const list = document.getElementById('list');
      const fragment = document.createDocumentFragment();
      for (const userInfo of res.data) {
        const listItem = document.createElement('LI');
        listItem.textContent = `${userInfo.Nombre} `;
        fragment.appendChild(listItem);
      }
      list.appendChild(fragment);
    })
    .catch(err => console.log(err));
});
