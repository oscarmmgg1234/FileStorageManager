import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from '../Shared/config.service';
import { LoginUser } from '../Shared/Models/login-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private configService: ConfigService ) { }

  register(userRegistration: any) {
    return this.http.post(this.configService.authApiURL + "/account", userRegistration);
  }

  signIn(loginUser: any) {
    return this.http.get(this.configService.authApiURL + "/account", loginUser);
  }

}

