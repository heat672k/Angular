import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  isLoggedIn: boolean = false;

  constructor(private identitiyService:IdentityService, private router: Router) { }

  ngOnInit(): void {
    this.identitiyService.loggedIn$.subscribe(next=>this.isLoggedIn = next );
  }

  logout(): void {
    this.identitiyService.logout();
    this.router.navigate(["/login"]);
  }

  routeToProfile(): void {
    this.router.navigate(["/profile",this.identitiyService.getUserId()]);
  }
  
  deleteAccount(): void {
    this.identitiyService.deleteAccount().subscribe(() =>{

      this.identitiyService.clearUserId();
      this.identitiyService.clearUserType();
      this.identitiyService.loggedIn.next(false);

      this.router.navigate(["/login"]);
    });
  }
}
