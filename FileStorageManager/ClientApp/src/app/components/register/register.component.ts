import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { RegisterUser } from '../../Shared/Models/register-user';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  userRegistration: RegisterUser = { firstName: '', lastName: '', email: '', password: '' }
  success: boolean;

  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.accountService.register(this.userRegistration)
      .subscribe(result => {
        if (result) {
          this.success = true;
        }
      });
  }

}
