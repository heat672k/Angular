import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { offer } from '../data/models/offer';
import { IdentityService } from '../services/identity.service';
import { OfferService } from '../services/offer.service';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {

  offer: offer | undefined;
  isPublisherLoggedIn: boolean = false;
  isUserApplied: boolean = false;

  constructor(
    private identityService:IdentityService,
    private offerService: OfferService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      switchMap(params => {
        let id = String(params.get('id'));
        return this.offerService.getById(id);
      })).subscribe(res=>{
        
        this.offer = res;
        
        this.isUserApplied = res.candidatesId.find(id => id == this.identityService.getUserId())? false: !this.identityService.isUserOfTypeOrg();
        this.isPublisherLoggedIn = this.identityService.getUserId() == this.offer?.orgId;
      });

  }

  giveReview(isPositive: boolean, id: string | undefined): void {
    this.offerService.giveReview(isPositive, id, this.identityService.getUserId()).subscribe(next =>{
      console.log(next);
      if(this.offer) this.offer.likes = next;
    });
  }

  apply(id: string | undefined): void {
    this.offerService.apply(id, this.identityService.getUserId()).subscribe(() => this.ngOnInit());
  }
}
