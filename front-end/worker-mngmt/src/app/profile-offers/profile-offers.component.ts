import { Component, OnInit } from '@angular/core';
import { offer } from '../data/models/offer';
import { IdentityService } from '../services/identity.service';
import { OfferService } from '../services/offer.service';

@Component({
  selector: 'app-profile-offers',
  templateUrl: './profile-offers.component.html',
  styleUrls: ['./profile-offers.component.css']
})
export class ProfileOffersComponent implements OnInit {

  offers!: offer[];

  displayedColumns: string[] = ['Title', 'Category', 'Type', 'Go to'];

  constructor(
    private offerService:OfferService,
    private identityService:IdentityService
  ) { }

  ngOnInit(): void {
    this.offerService.getOffers(this.identityService.getUserId()).subscribe(next => this.offers = next);
  }

}
