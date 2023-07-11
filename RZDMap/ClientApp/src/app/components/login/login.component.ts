import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private auth: AuthService) {
  }

  username: any = "";
  password: any = "";
  
  login(){
    return this.auth.loginUser({
      username: this.username,
      password: this.password
    })
  }
}
