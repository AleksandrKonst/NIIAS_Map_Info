import {Component, OnInit} from '@angular/core';
import {DataService} from "../../Service/data.service";
import {Station} from "../../Model/Station";
import * as L from 'leaflet';
import 'leaflet.markercluster';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit{
  private map: any;
  private stations: Station[] = []
  
  constructor(private dataService: DataService) { }

  loadStations() {
    this.dataService
        .getStations()
        .subscribe(data  => {
          this.stations = data;
          this.initMap();
          this.addMarkers();
        });
    
  }
  
  ngOnInit() {
    this.loadStations();
  }

  private initMap(): void {
    this.map = L.map('map', {
      attributionControl: false,
      center: [55.7522, 37.6156],
      zoom: 10
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '©OpenStreetMap',
      maxZoom: 18,
      minZoom:4
    }).addTo(this.map);
  }

  private addMarkers(): void {
    let myIcon = L.icon({
      iconUrl: 'assets/images/train_icon.png',
      iconSize: [30, 30]
    });
    let markers = L.markerClusterGroup({
      iconCreateFunction: function(cluster) {
        let childCount = cluster.getChildCount();
        if (childCount < 1000) {
          return L.divIcon({
            html: '<div style="background: white; border: crimson 4px solid;text-align: center; ' +
                'font-size: 12px; border-radius:  50%; height: 100%; vertical-align: middle; padding-top: 8px">' + childCount + '</div>',
            className: 'mycluster',
            iconSize: L.point(40, 40)
          });
        } else {
          return L.divIcon({
            html: '<div style="background: white; border: crimson 4px solid; text-align: center; ' +
                'font-size: 12px; border-radius:  50%; height: 100%; vertical-align: middle; padding-top:12px">' + childCount + '</div>',
            className: 'mycluster',
            iconSize: L.point(50, 50)
          });
        }
        
      }
    });
    
    this.stations.forEach(station => {
      const marker = L.marker([station.lat, station.lon], {title: station.name, icon: myIcon});

      const popupContent = `
        <h3>${station.name}</h3>
        <p>Единая сетевая разметка - ${station.esr}</p>
        <p>ID OSM - ${station.osmId}</p>
        <p>Широта - ${station.lat}</p>
        <p>Долгота - ${station.lon}</p>
        <p>user - ${station.user}</p>
        <button type="button" class="btn btn-danger">Инфо</button>
      `;

      marker.bindPopup(popupContent);
      markers.addLayer(marker);
    });

    this.map.addLayer(markers);
  }
}
