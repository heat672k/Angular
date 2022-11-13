import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { register_send_dto } from '../data/dtos/register_send_dto';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  formGroup: FormGroup;

  constructor(private formBuilder:FormBuilder, private identityService:IdentityService, private router:Router) {
    this.formGroup = this.formBuilder.group({
      email: ["",Validators.required],
      password: ["",Validators.required],
      name: ["",Validators.required],
      type_choice:  ["",Validators.required]
    });
  }

  ngOnInit(): void {
  }

  async onRegister(): Promise<void> {
    let is_user:boolean = (this.formGroup.get('type_choice')?.value == true)? true: false;

    let dto: register_send_dto = {
      Email: this.formGroup.get('email')?.value,
      Name: this.formGroup.get('name')?.value,
      Password: this.formGroup.get('password')?.value
    }

    this.identityService.register(dto,is_user).subscribe(next => {
      
      this.identityService.saveUserId(next.id);
      this.identityService.saveUserType(next.userType);
      
      this.router.navigate(['/profile',this.identityService.getUserId()])
    })
  }
}
