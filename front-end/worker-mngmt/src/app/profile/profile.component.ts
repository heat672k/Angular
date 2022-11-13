import { Component, OnInit } from '@angular/core';
import { profile_generic_data } from '../data/interfaces/profile_generic_data';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile_data:profile_generic_data | undefined;
  isOrgLoggedIn: boolean = false;
  
  constructor(
    private identityService: IdentityService
    ) { }

  ngOnInit(): void {
    this.identityService.getGenericData(this.identityService.getUserId()).subscribe(next => this.profile_data = next );
    this.isOrgLoggedIn = this.identityService.isUserOfTypeOrg();
  }

}
