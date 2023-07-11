import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private auth: AuthService) {
  }

  username: any = "";
  password: any = "";
  confirmPassword: any = "";

  login(){
    return this.auth.registerUser({
      username: this.username,
      password: this.password,
      confirmPassword: this.confirmPassword
    })
  }
}
