import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { applicant } from '../data/interfaces/applicant';
import { offer } from '../data/models/offer';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  constructor(private httpClient:HttpClient) {

   }

   public getById(id: string):Observable<offer> {
    let url = `http://localhost:5000/api/OfferController/GetById/${id}`;

    return this.httpClient.get<offer>(url);
   }

   public getApplicants(id: string | undefined) : Observable<applicant[]> {
    let url = `http://localhost:5000/api/OfferController/GetApplicants/${id}`;

    return this.httpClient.get<applicant[]>(url);
   }

   public getOffers(id: string | undefined) : Observable<offer[]> {
    let url = `http://localhost:5000/api/OfferController/GetOffers/${id}`;

    return this.httpClient.get<offer[]>(url);
   }

   public giveReview(isPositive: boolean, id: string | undefined, userId: string) : Observable<number> {
    let url = `http://localhost:5000/api/OfferController/AddReview`;

    let body = {"ReviewerId":userId, "OfferId":id, "IsPositive":isPositive };
    let headers= {'Content-Type': 'application/json'}

    return this.httpClient.post<number>(url,body, { headers: headers});
   }

   public getAll() : Observable<offer[]> {
    let url = `http://localhost:5000/api/OfferController/GetAll`;

    return this.httpClient.get<offer[]>(url);
   }

   public apply(id: string | undefined, userId: string) : Observable<void> {
    let url = `http://localhost:5000/api/OfferController/Apply`;

    let body = {"UserId":userId, "OfferId":id};
    let headers= {'Content-Type': 'application/json'}

    return this.httpClient.post<void>(url,body, { headers: headers});
   }

   public giveApplicantResponse(isApproved: boolean, candidateId: string, offerId: string | undefined): Observable<string> {
    let url = `http://localhost:5000/api/OfferController/GiveApplicantResponse`;

    let body = {"isApproved":isApproved, "OfferId":offerId, "CandidateId": candidateId};
    let headers= {'Content-Type': 'application/json'}

    return this.httpClient.post<string>(url,body, { headers: headers});
   }

   public newOffer(title: string, description: string, type: string, category: string, orgId: string) : Observable<offer> {
    let url = `http://localhost:5000/api/OfferController/NewOffer`;
    
    let body = {"Title": title, "Description": description, "Type": type, "Category": category, "OrgId": orgId };
    let headers= {'Content-Type': 'application/json'}

    return this.httpClient.post<offer>(url, body, { headers: headers});
   }
}
