import { Component } from '@angular/core';
import {AuthService} from "../../Service/auth.service";
import { AlertService } from 'ngx-alerts';
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  roleOptions: string[] = ['Administrator', 'Manager', 'NoRole'];
  developerType: string[] = ['Developer', 'Employee'];

  model: any = {
    username: null,
    email: null,
    password: null,
    role: 'Administrator',
    jobtitle: 'Developer',
  };
  constructor(private alertService: AlertService, 
              private authService: AuthService,
              private router: Router) {}

  ngOnInit(): void {}

  onSubmit() {
    this.alertService.danger('Creating new user');
    
    const registerObserver = {
      next: (x:any) => {
        this.alertService.danger('Account Created');
        this.router.navigate(['/login']);
      },
      error: (err:any) => {
        this.alertService.danger(err.error.errors[0].description);
      },
    };

    this.authService.register(this.model).subscribe(registerObserver);
  }

  roleChange(value:any) {
    this.model.role = value;
  }

  claimChange(value:any) {
    this.model.jobtitle = value;
  }
}
