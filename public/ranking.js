var nombre1 = document.getElementById("nombre1");
var nombre2 = document.getElementById("nombre2");
var nombre3 = document.getElementById("nombre3");
var nombre4 = document.getElementById("nombre4");
var nombre5 = document.getElementById("nombre5");
var nombre6 = document.getElementById("nombre6");
var nombre7 = document.getElementById("nombre7");
var nombre8 = document.getElementById("nombre8");
var nombre9 = document.getElementById("nombre9");
var nombre10 = document.getElementById("nombre10");

var searchBar = document.getElementById("buscarRanking");
console.log(searchBar.value);


http://localhost:4000/api/json/statistics/1
axios({
method: 'GET',
url: 'http://localhost:8080/api/json/getStatistics'
})
.then(res => {
    var d = new Date();
    var i = 0;
    var tablaPuntosJugadores = [];
    var nombresId = [];
    while(res.data.length>i){
      tablaPuntosJugadores[i]=0;
      i++

    }
    i=0;
    while(res.data.length>i){
      if((d.getMonth()+1) == parseInt(((res.data[i].timeDate).substring(5,7)))){
        tablaPuntosJugadores[res.data[i].playerID]+=res.data[i].playerExperience;
        
      }
      nombresId[res.data[i].playerID] = res.data[i].Nombre;
      i++;
    }
    i=0;
    var j = 0;
    var topJugadores = [];
    var primerElemento=res.data[0].playerId;
    var auxiliar = 0;
    var auxiliarId = 0;
    var tablaPuntos = [];
    var tablaId = [];
    var tablaNombres = [];
    while(10>i){
      auxiliar = 0;
      auxiliarId=0;
      j=0;
      while(res.data.length>j){
        
        if(tablaPuntosJugadores[j]>auxiliar){
          auxiliar=tablaPuntosJugadores[j];
          auxiliarId=j;
          
        }
        j++;
      }
      tablaId[i]=auxiliarId;
      tablaPuntos[i]=tablaPuntosJugadores[auxiliarId];
      tablaNombres[i]=nombresId[auxiliarId];
      tablaPuntosJugadores[auxiliarId]=0;
      i++;
    }
    //tabla de ranking 
    if((tablaNombres[0]!=undefined))nombre1.innerHTML = String(tablaNombres[0] + "   -   " + tablaPuntos[0]);
    if((tablaNombres[1]!=undefined))nombre2.innerHTML = String(tablaNombres[1] + "   -   " + tablaPuntos[1]);
    if((tablaNombres[2]!=undefined))nombre3.innerHTML = String(tablaNombres[2] + "   -   " + tablaPuntos[2]);
    if((tablaNombres[3]!=undefined))nombre4.innerHTML = String(tablaNombres[3] + "   -   " + tablaPuntos[3]);
    if((tablaNombres[4]!=undefined))nombre5.innerHTML = String(tablaNombres[4] + "   -   " + tablaPuntos[4]);
    if((tablaNombres[5]!=undefined))nombre6.innerHTML = String(tablaNombres[5] + "   -   " + tablaPuntos[5]);
    if((tablaNombres[6]!=undefined))nombre7.innerHTML = String(tablaNombres[6] + "   -   " + tablaPuntos[6]);
    if((tablaNombres[7]!=undefined))nombre8.innerHTML = String(tablaNombres[7] + "   -   " + tablaPuntos[7]);
    if((tablaNombres[8]!=undefined))nombre9.innerHTML = String(tablaNombres[8] + "   -   " + tablaPuntos[8]);
    if((tablaNombres[9]!=undefined))nombre10.innerHTML = String(tablaNombres[9] + "   -   " + tablaPuntos[9]);
  })


//graficas del ranking

function aniadir(){

    var nombre = document.getElementById('buscarRanking');
    console.log(nombre.value);
  http://localhost:4000/api/json/statistics/1
  axios({
  method: 'GET',
  url: 'http://localhost:8080/api/json/getStatistics' 
  //nombre.value
  })
  .then(res => {
      var d = new Date();

      var i = 0;
      while(i<d.getMonth()){
        console.log(i);
        i++;
      }

      var j = 0;
      var tablaDeDatos = [];
      var iniciador = 0;
      
      while(iniciador<d.getDate()){
        tablaDeDatos[iniciador]=0;
        iniciador++;
      }
      var k = 0;
      var usuarioError = 0;
      while(j<d.getDate()){
        k = 0;
        while(k<res.data.length){
          console.log(j, " ", parseInt((res.data[k].timeDate).substring(8,10)));
          if(j+1 == parseInt((res.data[k].timeDate).substring(8,10)) ){
              if((res.data[k].Nombre == nombre.value)){
                usuarioError++;
                tablaDeDatos[j]+=(res.data[k].playerExperience);
              }
          }
          k++;
        }
        j++;
      }
      if (usuarioError== 0){
        alert("El usuario no existe");

      }else{
        k = 0;
        var masAltoDate = 0;
        var masAlto = 0;
        var promedio = 0;
        while(k<d.getDate()){
          promedio+=tablaDeDatos[k];
          if(masAlto<tablaDeDatos[k]){
            masAltoDate=k;
            masAlto=tablaDeDatos[k];
          }
          k++;
        }

        promedio/=d.getDate();
        i = 0;
        var tablaDias = [];
        while(i<d.getDate()){
          tablaDias[i]=i+1;
          i++;
        }
        
          Highcharts.chart('container', {
            chart: {
              type: 'areaspline'
            },
            title: {
              text: 'Experiencia ganada durante el mes'
            },
            legend: {
              layout: 'vertical',
              align: 'left',
              verticalAlign: 'top',
              x: 150,
              y: 100,
              floating: true,
              borderWidth: 1,
              backgroundColor:
                Highcharts.defaultOptions.legend.backgroundColor || '#FFFFFF'
            },
            xAxis: {
              categories: tablaDias,
              plotBands: [
                {
                  // visualize the weekend
                  from: (masAltoDate-.5),
                  to: (masAltoDate+.5),
                  color: 'rgba(98, 203, 49, .5)'
                }
              ]
            },
            yAxis: {
              title: {
                text: 'Experiencia del jugador'
              }
            },
            tooltip: {
              shared: true,
              valueSuffix: ' Experiencia'
            },
            credits: {
              enabled: false
            },
            plotOptions: {
              areaspline: {
                fillOpacity: 0.5
              }
            },
            series: [
              {
                name: 'Promedio Actual: ' + Math.ceil(promedio),
                
                data: tablaDeDatos
              }
            ]
          });
  }})
}