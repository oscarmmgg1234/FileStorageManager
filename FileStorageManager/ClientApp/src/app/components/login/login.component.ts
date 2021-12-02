import { Component, OnInit } from '@angular/core';
import { LoginUser } from '../../Shared/Models/login-user.model';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginUser: LoginUser = { email: "", password: "" }
  success: boolean = false;
  
  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.accountService.signIn(this.loginUser)
      .subscribe(result => {
        if (result) {
          this.success = true;
        }
      });
  }

}
