import { Component } from '@angular/core';
import {AuthService} from "./Service/auth.service";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    name= '';
}