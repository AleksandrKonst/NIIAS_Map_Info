import {NgModule, OnInit} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppComponent }   from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { MapComponent } from './components/map/map.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import {AppRoutingModule} from "./app-routing.module";
import { MainPageComponent } from './components/main-page/main-page.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {AlertModule} from "ngx-alerts";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { StationInfoComponent } from './components/station-info/station-info.component';
@NgModule({
    imports:      [ BrowserModule, FormsModule, HttpClientModule, AppRoutingModule,  BrowserAnimationsModule
        , AlertModule.forRoot({maxMessages: 2, timeout: 3000, positionX: 'right'})],
    declarations: [ AppComponent, HeaderComponent, MapComponent, FooterComponent, MainPageComponent, LoginComponent, RegisterComponent, StationInfoComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule {}