import { Injectable } from "@angular/core";
import { environment } from '../../Environments/environment';
import { HttpClient } from "@angular/common/http";
import { WebApiClientRequest } from "../Entities/WebApiClient";
import { nameof, stock_function_param } from "../Entities/utility";

@Injectable({
    // declares that this service should be created
    // by the root application injector.
    providedIn: 'root'
})

export class HttpService {

    private baseUrl!: string;
    private endPoint!: string;
    private stockApiParam: WebApiClientRequest | undefined;

    constructor(private http: HttpClient){
        this.baseUrl = environment.alphaVanStockApi;
    }

    getStocks(){

        this.stockApiParam = new WebApiClientRequest();
        this.stockApiParam.function = stock_function_param.SimbolSearch;
        this.stockApiParam.apikey = environment.alphaVanStockKey;
        this.stockApiParam.interval = "1min";
        this.stockApiParam.symbol = "klbn";
        let endPoint = this.stockApiParam.getSymbolSearch("KLBN");

        console.log(`${this.baseUrl}${endPoint}`);
        return this.http.get(`${this.baseUrl}${endPoint}`);
    }
    
}