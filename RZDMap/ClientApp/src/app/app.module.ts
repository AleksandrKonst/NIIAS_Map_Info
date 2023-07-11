import { NgModule }      from '@angular/core';
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
@NgModule({
    imports:      [ BrowserModule, FormsModule, HttpClientModule, AppRoutingModule],
    declarations: [ AppComponent, HeaderComponent, MapComponent, FooterComponent, MainPageComponent, LoginComponent, RegisterComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }