import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-pereg-loss-chart',
  templateUrl: './pereg-loss-chart.component.html',
  styleUrls: ['./pereg-loss-chart.component.css']
})
export class PeregLossChartComponent implements OnInit {
  public chart: any;
  ngOnInit(): void {
    this.createChart();
  }

  createChart() {
    this.chart = new Chart('tranLossChart', {
      type: 'bar',
      data: {
        labels: ['2017', '2018', '2019', '2020', '2021', '2022', '2023'],
        datasets: [
          {
            label: 'Э',
            data: [
              '0.8778082191780814',
              '0.7758904109589064',
              '0.2136986301369901',
              '1.666849315068494',
              '0.3945205479452021',
              '0.4493150684931515',
              '0.46136986301369953',
            ],
            backgroundColor: 'blue',
          },
          {
            label: 'Ш',
            data: [
              '0.060273972602740145',
              '0.05150684931506655',
              '0.03945205479451852',
              '0.07232876712328817',
              '0.0339726027397278',
              '0.1413698630137019',
              '0.07452054794520446',
            ],
            backgroundColor: 'yellow',
          },
          {
            label: 'Т',
            data: [
              '6.239999999999996',
              '7.866301369863013',
              '10.058082191780821',
              '12.886575342465758',
              '11.404931506849318',
              '27.504657534246576',
              '28.3813698630137',
            ],
            backgroundColor: 'red',
          },
          {
            label: 'Прочие',
            data: [
              '6.523835616438358',
              '4.8865753424657505',
              '3.1035616438356173',
              '2.839452054794519',
              '2.6410958904109596',
              '15.646027397260273',
              '18.81205479452055',
            ],
            backgroundColor: 'orange',
          },
          {
            label: 'П',
            data: [
              '3.400547945205477',
              '6.747397260273971',
              '9.567123287671235',
              '10.106301369863013',
              '10.359452054794522',
              '7.772054794520545',
              '5.026849315068494',
            ],
            backgroundColor: 'darkblue',
          },
          {
            label: 'В',
            data: [
              '1.6504109589041134',
              '0.933698630136989',
              '1.2865753424657562',
              '0.6553424657534261',
              '0.7627397260274003',
              '1.5495890410958881',
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
            text: 'Потери пропускной способности по перегонам',
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
            max: 60,
          },
        },
      },
    });
    this.chart.canvas.parentNode.style.height = '400px';
    this.chart.canvas.parentNode.style.width = '600px';
  }
}
