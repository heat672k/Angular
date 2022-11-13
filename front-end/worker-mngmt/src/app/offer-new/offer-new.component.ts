import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';
import { OfferService } from '../services/offer.service';

@Component({
  selector: 'app-offer-new',
  templateUrl: './offer-new.component.html',
  styleUrls: ['./offer-new.component.css']
})
export class OfferNewComponent implements OnInit {
  formGroup!: FormGroup;
  
  constructor(
    private formBuilder: FormBuilder,
    private identityService: IdentityService,
    private offerService: OfferService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      title: ["",Validators.required],
      description: ["",Validators.required],
      type: ["",Validators.required],
      category:  ["",Validators.required]
    });
  }

  onSubmit(): void {
    var title = this.formGroup.get("title")?.value;
    var description = this.formGroup.get("description")?.value;
    var type = this.formGroup.get("type")?.value;
    var category = this.formGroup.get("category")?.value;

    this.offerService.newOffer(title, description, type, category, this.identityService.getUserId()).subscribe(next => {
      this.router.navigate(['/offer', next.id]);
    });

  }

}
