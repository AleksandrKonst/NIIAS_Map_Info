import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IUser} from "../Model/Auth/IUser";
import {map, Observable} from "rxjs";
import {JwtHelperService} from "@auth0/angular-jwt";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = "api/v1.0/identity";

  helper = new JwtHelperService();
  
  currentUser: IUser = {
    username: "",
    email: "",
    role: "",
    jobtitle: "",
  };
  
  constructor(private http: HttpClient) {}

  login(model: any): Observable<IUser> {
    return this.http.post(this.baseUrl + '/login', model).pipe(
        map((response: any) => {
          const decodedToken = this.helper.decodeToken(response.token);

          this.currentUser.username = decodedToken.given_name;
          this.currentUser.email = decodedToken.email;
          this.currentUser.jobtitle = decodedToken.JobTitle;
          this.currentUser.role = decodedToken.role;

          localStorage.setItem('token', response.token);
          
          return this.currentUser;
        })
    );
  }
  
  logout() {
      this.currentUser = {
          username: "",
          email: "",
          role: "",
          jobtitle: "",
      };
      localStorage.removeItem('token');
  }
  
  register(model: any) {
    return this.http.post(this.baseUrl + '/register', model);
  }

  loggedIn(): boolean {
     const token = localStorage.getItem('token');
     return !this.helper.isTokenExpired(token);
  }
  
  reload(){
      const decodedToken = this.helper.decodeToken(localStorage.getItem("token" ) as any);
      this.currentUser.username = decodedToken.given_name;
      this.currentUser.email = decodedToken.email;
      this.currentUser.role = decodedToken.role;
      this.currentUser.jobtitle = decodedToken.JobTitle;
  }
  confirmEmail(model: any) {
      return this.http.post(this.baseUrl + '/confirmemail', model);
  }
}