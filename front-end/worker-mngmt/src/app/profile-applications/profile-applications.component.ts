import { Component, OnInit } from '@angular/core';
import { profile_application } from '../data/interfaces/profile_application';
import { IdentityService } from '../services/identity.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-profile-applications',
  templateUrl: './profile-applications.component.html',
  styleUrls: ['./profile-applications.component.css']
})
export class ProfileApplicationsComponent implements OnInit {

  applications!: profile_application[];

  displayedColumns: string[] = ['Title', 'Publisher', 'Status', 'Go to'];

  constructor(
    private identityService: IdentityService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.getApplications(this.identityService.getUserId()).subscribe(next =>{
      this.applications = next;
      console.log(next);
    }  );
  }

}
