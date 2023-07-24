import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Chart, registerables } from 'chart.js';
Chart.register(...registerables);
@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  public chart: any;

  ngOnInit(): void {
    this.createChart();
  }

  createChart() {
    this.chart = new Chart('stanLossChart', {
      type: 'bar',
      data: {
        labels: ['2017', '2018', '2019', '2020', '2021', '2022', '2023'],
        datasets: [
          {
            label: 'Э',
            data: [
              '2.995068493150685',
              '1.8663013698630113',
              '1.5276712328767084',
              '2.375890410958903',
              '1.4093150684931528',
              '1.525479452054792',
              '0.46136986301369953',
            ],
            backgroundColor: 'blue',
          },
          {
            label: 'Ш',
            data: [
              '0.25643835616438304',
              '0.21041095890410721',
              '0.2805479452054791',
              '0.31561643835616504',
              '0.2213698630136971',
              '0.29589041095890156',
              '0.07452054794520446',
            ],
            backgroundColor: 'yellow',
          },
          {
            label: 'Т',
            data: [
              '14.865753424657534',
              '22.39232876712329',
              '35.97698630136986',
              '31.96054794520548',
              '25.786301369863015',
              '64.89643835616438',
              '28.3813698630137',
            ],
            backgroundColor: 'red',
          },
          {
            label: 'Прочие',
            data: [
              '17.21315068493151',
              '13.514520547945207',
              '9.112328767123284',
              '7.5463013698630155',
              '7.93972602739726',
              '43.3358904109589',
              '18.81205479452055',
            ],
            backgroundColor: 'orange',
          },
          {
            label: 'П',
            data: [
              '9.572602739726026',
              '21.84657534246576',
              '24.933698630136988',
              '24.962191780821918',
              '25.92657534246576',
              '19.708493150684934',
              '5.026849315068494',
            ],
            backgroundColor: 'darkblue',
          },
          {
            label: 'В',
            data: [
              '2.7199999999999966',
              '2.260821917808222',
              '2.3024657534246566',
              '1.3797260273972576',
              '1.4871232876712317',
              '3.342465753424653',
              '1.4980821917808216',
            ],
            backgroundColor: 'brown ',
          },
        ],
      },
      options: {
        plugins: {
          title: {
            display: true,
            text: 'Потери пропускной способности по станциям',
          },
        },
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          x: {
            stacked: true,
          },
          y: {
            stacked: true,
            beginAtZero: true,
            max: 140,
          },
        },
      },
    });
    this.chart.canvas.parentNode.style.height = '400px';
    this.chart.canvas.parentNode.style.width = '600px';
  }
}
