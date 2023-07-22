import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MapComponent} from "./components/map/map.component";
import {MainPageComponent} from "./components/main-page/main-page.component";
import {LoginComponent} from "./components/login/login.component";
import {RegisterComponent} from "./components/register/register.component";
import {StationInfoComponent} from "./components/station-info/station-info.component";
import {ConfirmEmailComponent} from "./components/confirm-email/confirm-email.component";
import {LineInfoComponent} from "./components/line-info/line-info.component";

const appRoutes: Routes =[
  { path: '', component: MainPageComponent},
  { path: 'map', component: MapComponent},
  { path: 'route', component: MapComponent},
  { path: 'privacy', component: MainPageComponent},
  { path: 'about', component: MainPageComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'station/:id', component: StationInfoComponent },
  { path: 'line/:stOneId/:stTwoId', component: LineInfoComponent },
  { path: 'confirmemail', component: ConfirmEmailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
