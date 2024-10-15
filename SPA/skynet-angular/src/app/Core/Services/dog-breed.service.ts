import { HttpProviderService } from './http-provider.service';
import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
})
export class DogBreedService{

    dog: any = [];
    apiUrl: string = "https://api.thedogapi.com/v1/breeds/";

    constructor(private httpService: HttpProviderService){

    }

    get Dogs(){
        return this.httpService.GetBasedURL(this.apiUrl);
    }


}