import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';
import { login_send_dto } from '../data/dtos/login_send_dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup:FormGroup;


  constructor(private formBuilder:FormBuilder, private identityService: IdentityService, private router:Router) {

    this.formGroup = formBuilder.group({
      email: ["",Validators.required],
      password: ["",Validators.required]
    });
   }

  ngOnInit(): void {
    this.formGroup.reset();
  }

  async onLogin(): Promise<void> {
    let dto: login_send_dto = {
      Email: this.formGroup.get('email')?.value,
      Password: this.formGroup.get('password')?.value
    }


    this.identityService.logIn(dto).subscribe(
      next => {
        console.log(next);
        this.identityService.saveUserId(next.id);
        this.identityService.saveUserType(next.userType);
        this.identityService.loggedIn.next(true);
        this.router.navigate(['/profile',this.identityService.getUserId()]);
      }
    );
  }

}
