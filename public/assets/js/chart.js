
const boton = document.getElementById('buscar');

var click = false;

boton.addEventListener('click', () => {
  click =true;
  const  date=[];
  const experience=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  const inicioSesion=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  const contratos=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  var steel = 0;
  var iron = 0;
  var unpackageSteel = 0;
  const id = document.getElementById('playerName');
  axios({
    method: 'GET',
    url: 'http://localhost:4000/api/json/statistics/' + id.value
    })
    .then(res => {
        if(res.data.length == 0){
          alert("El usuario no existe");
        }
        else{
          for (var i = 0; i < res.data.length; i++) {
            date.push(res.data[i].timeDate);
            steel = steel + res.data[i].totalSteel;
            iron = iron + res.data[i].totalIron;
            unpackageSteel = unpackageSteel + res.data[i].totalUnpackageSteel;
            if( date[i].substring(5,7) == "01"){
              experience[0] = experience[0] + res.data[i].playerExperience;
              inicioSesion[0] = inicioSesion[0] + 1;
              contratos[0] = contratos[0] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "02"){
              experience[1] = experience[1] + res.data[i].playerExperience;
              inicioSesion[1] = inicioSesion[1] + 1;
              contratos[1] = contratos[1] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "03"){
              experience[2] = experience[2] + res.data[i].playerExperience;
              inicioSesion[2] = inicioSesion[2] + 1;
              contratos[2] = contratos[2] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "04"){
              experience[3] = experience[3] + res.data[i].playerExperience;
              inicioSesion[3] = inicioSesion[3] + 1;
              contratos[3] = contratos[3] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "05"){
              experience[4] = experience[4] + res.data[i].playerExperience;
              inicioSesion[4] = inicioSesion[4] + 1;
              contratos[4] = contratos[4] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "06"){
              experience[5] = experience[5] + res.data[i].playerExperience;
              inicioSesion[5] = inicioSesion[5] + 1;
              contratos[5] = contratos[5] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "07"){
              experience[6] = experience[6] + res.data[i].playerExperience;
              inicioSesion[6] = inicioSesion[6] + 1;
              contratos[6] = contratos[6] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "08"){
              experience[7] = experience[7] + res.data[i].playerExperience;
              inicioSesion[7] = inicioSesion[7] + 1;
              contratos[7] = contratos[7] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "09"){
              experience[8] = experience[8] + res.data[i].playerExperience;
              inicioSesion[8] = inicioSesion[8] + 1;
              contratos[8] = contratos[8] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "10"){
              experience[9] = experience[9] + res.data[i].playerExperience;
              inicioSesion[9] = inicioSesion[9] + 1;
              contratos[9] = contratos[9] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "11"){
              experience[10] = experience[10] + res.data[i].playerExperience;
              inicioSesion[10] = inicioSesion[10] + 1;
              contratos[10] = contratos[10] + res.data[i].totalContract;
            }
            else if( date[i].substring(5,7) == "12"){
              experience[11] = experience[11] + res.data[i].playerExperience;
              inicioSesion[11] = inicioSesion[11] + 1;
              contratos[11] = contratos[11] + res.data[i].totalContract;
            }
          }
          graficar(experience, date, inicioSesion, contratos, iron, steel, unpackageSteel, id.value);
        }
        
    })
    .catch(err => console.log(err))
});

if(click == false){
  const  date=[];
  const experience=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  const inicioSesion=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  const contratos=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  var steel = 0;
  var iron = 0;
  var unpackageSteel = 0;
  const id = "todos los usuarios";
  axios({
    method: 'GET',
    url: 'http://localhost:4000/api/json/getStatistics' 
    })
    .then(res => {
        for (var i = 0; i < res.data.length; i++) {
          date.push(res.data[i].timeDate);
          steel = steel + res.data[i].totalSteel;
          iron = iron + res.data[i].totalIron;
          unpackageSteel = unpackageSteel + res.data[i].totalUnpackageSteel;
          if( date[i].substring(5,7) == "01"){
            experience[0] = experience[0] + res.data[i].playerExperience;
            inicioSesion[0] = inicioSesion[0] + 1;
            contratos[0] = contratos[0] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "02"){
            experience[1] = experience[1] + res.data[i].playerExperience;
            inicioSesion[1] = inicioSesion[1] + 1;
            contratos[1] = contratos[1] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "03"){
            experience[2] = experience[2] + res.data[i].playerExperience;
            inicioSesion[2] = inicioSesion[2] + 1;
            contratos[2] = contratos[2] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "04"){
            experience[3] = experience[3] + res.data[i].playerExperience;
            inicioSesion[3] = inicioSesion[3] + 1;
            contratos[3] = contratos[3] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "05"){
            experience[4] = experience[4] + res.data[i].playerExperience;
            inicioSesion[4] = inicioSesion[4] + 1;
            contratos[4] = contratos[4] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "06"){
            experience[5] = experience[5] + res.data[i].playerExperience;
            inicioSesion[5] = inicioSesion[5] + 1;
            contratos[5] = contratos[5] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "07"){
            experience[6] = experience[6] + res.data[i].playerExperience;
            inicioSesion[6] = inicioSesion[6] + 1;
            contratos[6] = contratos[6] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "08"){
            experience[7] = experience[7] + res.data[i].playerExperience;
            inicioSesion[7] = inicioSesion[7] + 1;
            contratos[7] = contratos[7] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "09"){
            experience[8] = experience[8] + res.data[i].playerExperience;
            inicioSesion[8] = inicioSesion[8] + 1;
            contratos[8] = contratos[8] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "10"){
            experience[9] = experience[9] + res.data[i].playerExperience;
            inicioSesion[9] = inicioSesion[9] + 1;
            contratos[9] = contratos[9] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "11"){
            experience[10] = experience[10] + res.data[i].playerExperience;
            inicioSesion[10] = inicioSesion[10] + 1;
            contratos[10] = contratos[10] + res.data[i].totalContract;
          }
          else if( date[i].substring(5,7) == "12"){
            experience[11] = experience[11] + res.data[i].playerExperience;
            inicioSesion[11] = inicioSesion[11] + 1;
            contratos[11] = contratos[11] + res.data[i].totalContract;
          }
        }
        graficar(experience, date, inicioSesion, contratos, iron, steel, unpackageSteel, id);
    })
    .catch(err => console.log(err))
}


function graficar(experienceData, dateData, inicioSesion, contratos, iron, steel, unpackageSteel, id) {

  Highcharts.chart('container', {
    chart: {
      type: 'column'
    },
    title: {
      text: 'Acomulado de contratos y experiencia de '+id
    },
    subtitle: {
      text: ''
    },
    xAxis: {
      categories: [
        'Jan',
        'Feb',
        'Mar',
        'Apr',
        'May',
        'Jun',
        'Jul',
        'Aug',
        'Sep',
        'Oct',
        'Nov',
        'Dec'
      ],
      crosshair: true
    },
    yAxis: {
      min: 0,
      title: {
        text: 'Cantidad'
      }
    },
    tooltip: {
      headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
      pointFormat:
        '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
        '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
      footerFormat: '</table>',
      shared: true,
      useHTML: true
    },
    plotOptions: {
      column: {
        pointPadding: 0.2,
        borderWidth: 0
      }
    },
    series: [
      {
        name: 'Contratos',
        data: contratos
      },
      {
        name: 'Experiencia',
        data: experienceData 
      }
    ]
  });
  
  Highcharts.chart('container2', {
    chart: {
      type: 'areaspline'
    },
    title: {
      text: 'Inicios de sesión de ' + id
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
      categories: [
        'Jan',
        'Feb',
        'Mar',
        'Apr',
        'May',
        'Jun',
        'Jul',
        'Aug',
        'Sep',
        'Oct',
        'Nov',
        'Dec'
      ],
      plotBands: [
        {
          // visualize the weekend
          from: 4.5,
          to: 6.5,
          color: 'rgba(68, 170, 213, .2)'
        }
      ]
    },
    yAxis: {
      title: {
        text: 'Nivel'
      }
    },
    tooltip: {
      shared: true,
      valueSuffix: ' Nivel'
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
        data: inicioSesion 
      },
    ]
  });
  Highcharts.chart('container3', {
    chart: {
      plotBackgroundColor: null,
      plotBorderWidth: null,
      plotShadow: false,
      type: 'pie'
    },
    title: {
      text: 'Recursos de ' + id
    },
    tooltip: {
      pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    accessibility: {
      point: {
        valueSuffix: '%'
      }
    },
    plotOptions: {
      pie: {
        allowPointSelect: true,
        cursor: 'pointer',
        dataLabels: {
          enabled: false
        },
        showInLegend: true
      }
    },
    series: [
      {
        name: 'Categorias',
        colorByPoint: true,
        data: [
          {
            name: 'Acero',
            y:steel,
          },
          {
            name: 'Hierro',
            y: iron
          },
          {
            name: 'Acero no empacado',
            y: unpackageSteel
          }
        ]
      }
    ]
  });
}
