import {Component, Input} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Subscription} from "rxjs";
import {DataService} from "../../Service/data.service";

@Component({
  selector: 'app-station-info',
  templateUrl: './station-info.component.html',
  styleUrls: ['./station-info.component.css']
})
export class StationInfoComponent {
   private routeSub: Subscription = new Subscription();
   station: any;
   constructor(private dataService: DataService, private route: ActivatedRoute) { }
   loadStations(id: number) {
        this.dataService
            .getStation(id)
            .subscribe(data  => {
                this.station = data;
            }
        );
   }
   
   ngOnInit() {
       this.routeSub = this.route.params.subscribe(params => {
           this.loadStations(params['id'])
       });
   }
}
