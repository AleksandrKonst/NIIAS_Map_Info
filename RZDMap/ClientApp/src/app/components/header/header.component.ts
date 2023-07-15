import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(public auth: AuthService, private router: Router) {
  }

  logout() {
    this.auth.logout();
    this.router.navigate(['/']);
  }
  ngOnInit(){
    if(this.auth.loggedIn()){
      this.auth.reload()
    }
  }
}
