import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MapComponent} from "./components/map/map.component";
import {MainPageComponent} from "./components/main-page/main-page.component";

const appRoutes: Routes =[
  { path: '', component: MainPageComponent},
  { path: 'map', component: MapComponent},
  { path: 'route', component: MapComponent},
  { path: 'privacy', component: MainPageComponent},
  { path: 'about', component: MainPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
