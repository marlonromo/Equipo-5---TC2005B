Highcharts.chart('container', {
  chart: {
    type: 'line'
  },
  title: {
    text: 'Progreso del jugador en enero'
  },
  xAxis: {
    categories: [
      '1',
      '2',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      '10',
      '11',
      '12',
      '13',
      '14',
      '15',
      '16',
      '17',
      '18',
      '19',
      '20',
      '21',
      '22',
      '23',
      '24',
      '25',
      '26',
      '27',
      '28',
      '29',
      '30'
    ]
  },
  yAxis: {
    title: {
      text: 'Experiencia'
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
      data: [
        7.0,
        6.9,
        9.5,
        14.5,
        18.4,
        21.5,
        25.2,
        26.5,
        23.3,
        18.3,
        13.9,
        9.6,
        7.0,
        6.9,
        9.5,
        14.5,
        18.4,
        21.5,
        25.2,
        26.5,
        23.3,
        18.3,
        13.9,
        9.6,
        23.3,
        18.3,
        13.9,
        9.6
      ]
    }
  ]
});
