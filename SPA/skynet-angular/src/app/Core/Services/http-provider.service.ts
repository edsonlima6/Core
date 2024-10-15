import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs'
import { UserModel } from '../Models/userModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private httpHost: HttpClient) {
    console.log(environment.apiUrl)
   }

  getAll<T>(uri: string){
    return this.httpHost.get<T>(environment.apiUrl + `${uri}`); 
  }

  post<T>(uri: string, J: any){
    return this.httpHost.post<T>(environment.apiUrl + `${uri}`, J); 
  }


  GetBasedURL<T>(uri: string){
    return this.httpHost.get<T>(`${uri}`); 
  }
}
