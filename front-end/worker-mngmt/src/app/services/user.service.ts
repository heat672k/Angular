import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { profile_application } from '../data/interfaces/profile_application';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getApplications(id: string): Observable<profile_application[]> {
    let url = `http://localhost:5000/api/UserController/GetApplications/${id}`;
    
    return this.httpClient.get<profile_application[]>(url);
  }
}
