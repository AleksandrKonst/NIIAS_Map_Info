import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Station} from "../Model/Station";

@Injectable({providedIn: 'root'})
export class DataService {

    private url = "api/v1.0/get";

    constructor(private http: HttpClient) {
    }

    getStations() {
        return this.http.get<Station[]>(this.url + '/stations',
            this.getHttpOptions());
    }

    getStation(id: number) {
        return this.http.get<Station>(this.url + '/station/' + id,
            this.getHttpOptions());
    }

    getHttpOptions() {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer ' + localStorage.getItem('token'),
            }),
        };

        return httpOptions;
    }
}