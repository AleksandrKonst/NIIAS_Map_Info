import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: any = null;
  login: boolean = false;

  constructor(private http: HttpClient) {

  }

  loggedIn(): boolean {
        return this.login;
  }
  async loadUser(){
      const user = await firstValueFrom(
          this.http.get<any>("/api/user")
      )
      if('http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name' in user) {
          this.user = user
          this.login = true
      }
      return user;
  }
  loginUser(loginForm: any){
    return this.http.post<any>("/api/login", loginForm, {withCredentials: true})
        .subscribe(_ => {
            this.loadUser()
            window.location.reload();
        })
  }
  registerUser(registerForm: any){
      return this.http.post<any>("/api/registry", registerForm, {withCredentials: true})
          .subscribe(_ => {
              this.loadUser()
              window.location.reload();
          })
  }
  logoutUser(){
    return this.http.get("api/logout")
        .subscribe(_ => {
            this.user = null
            window.location.reload();
        })
  }
}