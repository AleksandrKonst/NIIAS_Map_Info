import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(public auth: AuthService) {
  }
  
  username: any;
  
  async ngOnInit(){
    const user = await this.auth.loadUser()
    this.username = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']
  }
  
  logout() {
    return this.auth.logoutUser()
  }
}
