const boton = document.getElementById('boton_ing');

let players=[];

boton.addEventListener('click', () => {
    axios({
    method: 'GET',
    url: 'http://localhost:4000/api/getPlayers' 
    })
    .then(res => {
      //const userInfo = res.data;
        for (var i = 0; i <= res.data.length; i++) {
            //console.log(res.data[i].namePlayer);
            players[i]=res.data[i].namePlayer;
            console.log(players[i]);
        }
    })
    .catch(err => console.log(err))
});
