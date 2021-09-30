Highcharts.chart('container', {
  chart: {
    type: 'areaspline'
  },
  title: {
    text: 'Nivel del jugador'
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
      'Monday',
      'Tuesday',
      'Wednesday',
      'Thursday',
      'Friday',
      'Saturday',
      'Sunday'
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
      name: 'Promedio Actual',
      data: [3, 4, 6, 8, 10, 10, 12]
    },
    {
      name: 'Promedio Semana Pasada',
      data: [1, 3, 4, 4, 5, 6, 6]
    }
  ]
});
