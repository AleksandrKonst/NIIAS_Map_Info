import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertService } from '@full-fledged/alerts';
import {AuthService} from "../../Service/auth.service";

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.scss'],
})
export class ConfirmEmailComponent implements OnInit {
  emailConfirmed: boolean = false;
  urlParams: any = {};

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  ngOnInit() {
    this.urlParams.token = this.route.snapshot.queryParamMap.get('token');
    this.urlParams.userid = this.route.snapshot.queryParamMap.get('userid');
    this.confirmEmail();
  }

  confirmEmail() {
    this.authService.confirmEmail(this.urlParams).subscribe(
      () => {
        console.log('success');
        this.alertService.danger('Email Confirmed');
        this.emailConfirmed = true;
      },
      (error:any) => {
        console.log(error);
        this.alertService.danger('Unable to confirm email');
        this.emailConfirmed = false;
      }
    );
  }
}
