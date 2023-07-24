import {Component, ElementRef, OnInit} from '@angular/core';
import {AlertService} from "@full-fledged/alerts";
import {DataService} from "../../Service/data.service";
import {MapLine} from "../../Model/MapLine";
import {Station} from "../../Model/Station";
import {Router} from "@angular/router";
import {LatLngExpression} from "leaflet";
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
  private lines: MapLine[] = []
  
  constructor(private dataService: DataService, private alertService: AlertService, 
              private elementRef: ElementRef, private router: Router) { }

  loadStations() {
    this.alertService.danger('Загрузка станций');
    this.dataService
        .getStations()
        .subscribe(data  => {
          this.alertService.danger('Загрузка станций завершена');
          this.stations = data;
          this.initMap();
          this.addMarkers();
          this.loadMapLines();
        });
  }

  loadMapLines() {
    this.dataService
        .getMapLines()
        .subscribe(data  => {
          this.lines = data;
          this.addLine()
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
      minZoom:4,
      className: "test"
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
        <button type="button" class="btn btn-danger info">Инфо</button>
        <button type="button" class="btn btn-secondary route">Маршруты</button>
      `;

      marker.bindPopup(popupContent)
          .on("popupopen", e => {
          this.elementRef.nativeElement
              .querySelector(".info")
              .addEventListener("click", () => {
                this.infoStation(station.esr);
              });
          })
          .on("popupopen", e => {
              this.elementRef.nativeElement
                 .querySelector(".route")
                 .addEventListener("click", () => {
                   this.addRoute(station.esr);
              });
          });
      markers.addLayer(marker);
    });
    this.map.addLayer(markers)
  }

  private addLine(): void {
    var ways: L.Polyline[]  = []
    this.lines.forEach(line => {
      var way :LatLngExpression[] = [new L.LatLng(line.latSt1, line.lonSt1), new L.LatLng(line.latSt2, line.lonSt2)];
      var polyline = new L.Polyline(way, {
        color: 'crimson',
        weight: 6,
        opacity: 1,
        smoothFactor: 1
      });

      const popupContent = `
        <h3>Перегон ${line.stan1Id} - ${line.stan2Id}</h3>
        <p>ID Ст1 - ${line.stan1Id}</p>
        <p>Широта Ст1 - ${line.latSt1}</p>
        <p>Долгота Ст1 - ${line.lonSt1}</p>
        <p>ID Ст2 - ${line.stan2Id}</p>
        <p>Широта Ст2 - ${line.latSt2}</p>
        <p>Долгота Ст2 - ${line.lonSt2}</p>
        <button type="button" class="btn btn-danger infoLine">Инфо</button>
      `;

        polyline.bindPopup(popupContent)
          .on("popupopen", e => {
            this.elementRef.nativeElement
                .querySelector(".infoLine")
                .addEventListener("click", () => {
                  this.infoLine(line.stan1Id, line.stan2Id);
                });
          });
      
      ways.push(polyline);
    });
    

    var lineGroup = L.layerGroup(ways);
    
    var baseMaps = {};
    var overlayMaps = {
      "ЖД пути": lineGroup
    };
    
    var layerControl = L.control.layers(baseMaps, overlayMaps).addTo(this.map)
  }
  infoStation(esr: number) {
    this.router.navigate(['/station/' + esr]);
  }
  private infoLine(stan1Id: number, stan2Id: number) {
     this.router.navigate(['/line/' + stan1Id + '/' +stan2Id]);
  }
  private addRoute(esr: number) {
    alert(esr);
  }
}
