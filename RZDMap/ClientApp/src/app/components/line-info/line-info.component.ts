import { Component } from '@angular/core';
import {Subscription} from "rxjs";
import {DataService} from "../../Service/data.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-line-info',
  templateUrl: './line-info.component.html',
  styleUrls: ['./line-info.component.css']
})
export class LineInfoComponent {
  private routeSub: Subscription = new Subscription();
  line: any;
  stationOneId: number = 0;
  stationTwoId: number = 0;
  constructor(private route: ActivatedRoute) { }
  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.stationOneId = params['stOneId']
      this.stationTwoId = params['stTwoId']
    });
  }
}
