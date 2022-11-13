import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { off } from 'process';
import { BehaviorSubject, Observable } from 'rxjs';
import { login_return_dto } from '../data/dtos/login_return_dto';
import { login_send_dto } from '../data/dtos/login_send_dto';
import { register_return_dto } from '../data/dtos/register_return_dto';
import { register_send_dto } from '../data/dtos/register_send_dto';
import { profile_generic_data } from '../data/interfaces/profile_generic_data';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  
  public loggedIn = new BehaviorSubject<boolean>(false);
  loggedIn$ = this.loggedIn.asObservable();

  constructor(private httpClient: HttpClient) { }

  public saveUserId(id: string): void {
    localStorage.setItem("id", id);
  }

  public clearUserId(): void {
    localStorage.removeItem("id");
  }

  public getUserId(): string {
    let id = localStorage.getItem("id");

    return id == null ? "" : id;
  }

  public saveUserType(type: number) {
    localStorage.setItem("type", type.toString());
  }

  public clearUserType() {
    localStorage.removeItem("type");
  }

  public isUserOfTypeOrg(): boolean {
    var value = localStorage.getItem("type");
    return value ? (Number.parseInt(value) == 1 ? true : false) : false;
  }

  public isLoggedIn(): boolean {
    return localStorage.getItem("type") != null ? true : false;
  }

  public logIn(login_dto: login_send_dto): Observable<login_return_dto> {
    let url = `http://localhost:5000/api/IdentityController/LogIn`;

    let headers = { 'Content-Type': 'application/json' }

    return this.httpClient.post<login_return_dto>(url, login_dto, { headers: headers });
  }

  public register(register_dto: register_send_dto, is_user: boolean): Observable<register_return_dto> {
    let url = `http://localhost:5000/api/IdentityController/Register${is_user ? 'User' : 'Org'}`;

    let headers = { 'Content-Type': 'application/json' }

    return this.httpClient.post<register_return_dto>(url, register_dto, { headers: headers });
  }

  public logout() : void {
    this.clearUserId();
    this.clearUserType();
    this.loggedIn.next(false);
  }

  public getGenericData(id: string): Observable<profile_generic_data> {
    let url = `http://localhost:5000/api/IdentityController/GetById/${id}`;

    return this.httpClient.get<profile_generic_data>(url);
  }

  public deleteAccount(): Observable<void> {

    let url = `http://localhost:5000/api/IdentityController/Delete/${this.getUserId()}`;

    return this.httpClient.delete<void>(url);
  }

}
