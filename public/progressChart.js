const radioExperiencia = document.getElementById('flexRadioExperiencia');
const radioDinero = document.getElementById('flexRadioDinero');
const radioMetal = document.getElementById('flexRadioMetal');
const radioContratos = document.getElementById('flexRadioContratos');

const boton = document.getElementById('boton');
const input = document.getElementById('datepicker');

const url = window.location.href;
const id = url.split('=')[1];

boton.addEventListener('click', () => {
  var array = [];
  var date = [];
  axios({
    method: 'GET',
    url: 'http://localhost:4000/api/json/getStatisticsID/' + id
  })
    .then(res => {
      var i;
      for (i = 0; i < res.data.length; i++) {
        if (
          radioDinero.checked &&
          res.data[i].timeDate.substring(0, 7) == input.value
        ) {
          addDataToArray(res.data[i].totalMoney, res.data[i].timeDate);
        } else if (
          radioExperiencia.checked &&
          res.data[i].timeDate.substring(0, 7) == input.value
        ) {
          addDataToArray(res.data[i].playerExperience, res.data[i].timeDate);
        } else if (
          radioMetal.checked &&
          res.data[i].timeDate.substring(0, 7) == input.value
        ) {
          addDataToArray(res.data[i].totalSteel, res.data[i].timeDate);
        } else if (
          radioContratos.checked &&
          res.data[i].timeDate.substring(0, 7) == input.value
        ) {
          addDataToArray(res.data[i].totalContract, res.data[i].timeDate);
        }
      }
      graficar(array, date);
    })
    .catch(err => console.log(err));

  function addDataToArray(data, fecha) {
    array.push(data);
    date.push(fecha.substring(0, 10));
  }

  function graficar(data, fechas) {
    var texto;
    var month;
    if (radioDinero.checked) {
      texto = 'Dinero';
    } else if (radioExperiencia.checked) {
      texto = 'Experiencia';
    } else if (radioMetal.checked) {
      texto = 'Metal';
    } else if (radioContratos.checked) {
      texto = 'Contratos';
    }

    if (input.value.substring(5, 7) == 01) {
      month = 'enero';
    } else if (input.value.substring(5, 7) == 02) {
      month = 'febrero';
    } else if (input.value.substring(5, 7) == 03) {
      month = 'marzo';
    } else if (input.value.substring(5, 7) == 04) {
      month = 'abril';
    } else if (input.value.substring(5, 7) == 05) {
      month = 'mayo';
    } else if (input.value.substring(5, 7) == 06) {
      month = 'junio';
    } else if (input.value.substring(5, 7) == 07) {
      month = 'julio';
    } else if (input.value.substring(5, 7) == 08) {
      month = 'agosto';
    } else if (input.value.substring(5, 7) == 09) {
      month = 'septiembre';
    } else if (input.value.substring(5, 7) == 10) {
      month = 'octubre';
    } else if (input.value.substring(5, 7) == 11) {
      month = 'noviembre';
    } else if (input.value.substring(5, 7) == 12) {
      month = 'diciembre';
    }

    Highcharts.chart('container', {
      chart: {
        type: 'line'
      },
      title: {
        text: 'Progreso del jugador en ' + month
      },
      xAxis: {
        categories: fechas
      },
      yAxis: {
        title: {
          text: texto
        }
      },
      plotOptions: {
        line: {
          dataLabels: {
            enabled: true
          },
          enableMouseTracking: false
        }
      },
      series: [
        {
          name: 'Cantidad',
          data: array
        }
      ]
    });
  }
});
