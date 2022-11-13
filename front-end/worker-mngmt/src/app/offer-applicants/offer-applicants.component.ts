import { Component, Input, OnInit } from '@angular/core';
import { applicant } from '../data/interfaces/applicant';
import { profile_application } from '../data/interfaces/profile_application';
import { OfferService } from '../services/offer.service';


@Component({
  selector: 'app-offer-applicants',
  templateUrl: './offer-applicants.component.html',
  styleUrls: ['./offer-applicants.component.css']
})
export class OfferApplicantsComponent implements OnInit {

  @Input() id: string | undefined;

  displayedColumns: string[] = ['Name', 'Email', 'Status', 'Response'];
  applicants!: applicant[];
  
  constructor(
    private offerService: OfferService
  ) { }

  ngOnInit(): void {
    this.offerService.getApplicants(this.id).subscribe(next => this.applicants = next);
    console.log(this.id);
  }

  handleApplicantResponse(isApproved: boolean, candidateId: string) : void {
    this.offerService.giveApplicantResponse(isApproved, candidateId, this.id).subscribe(() => this.ngOnInit());
  }
}
