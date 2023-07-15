import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";
import {AlertService} from "ngx-alerts";
import {NgForm} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(
      private authService: AuthService,
      private alertService: AlertService, 
      private router: Router
  ) {}

  ngOnInit(): void {}

  onSubmit(f: NgForm) {
    this.alertService.danger('Check login information');

    const loginObserver = {
      next: (x:any) => {
        this.alertService.danger('Welcome back ' + x.username);
        this.router.navigate(['/']);
      },
      error: (err:any) => {
        this.alertService.danger("Unable to login");
      },
    };
    
    this.authService.login(f.value).subscribe(loginObserver);
  }
}
