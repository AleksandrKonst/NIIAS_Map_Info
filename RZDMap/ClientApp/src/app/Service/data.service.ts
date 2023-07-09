import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Station} from "../Model/Station";

@Injectable({providedIn: 'root'})
export class DataService {

    private url = "api/v1.0/get";

    constructor(private http: HttpClient) {
    }

    getStations() {
        return this.http.get<Station[]>(this.url + '/stations');
    }

    getStation(id: number) {
        return this.http.get<Station>(this.url + '/station/' + id);
    }
}