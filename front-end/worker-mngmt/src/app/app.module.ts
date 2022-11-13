import { NgModule } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { ProfileOffersComponent } from './profile-offers/profile-offers.component';
import { ProfileApplicationsComponent } from './profile-applications/profile-applications.component';
import { OfferComponent } from './offer/offer.component';
import { ListComponent } from './list/list.component';
import { OfferApplicantsComponent } from './offer-applicants/offer-applicants.component';
import { OfferNewComponent } from './offer-new/offer-new.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    RegisterComponent,
    ProfileComponent,
    ProfileOffersComponent,
    ProfileApplicationsComponent,
    OfferComponent,
    ListComponent,
    OfferApplicantsComponent,
    OfferNewComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
