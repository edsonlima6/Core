import { nameof } from "./utility";

/** Fills parameters to send request to API */
export class WebApiClientRequest {
    /**The time series of your choice. In this case, function=TIME_SERIES_INTRADAY */
    function!: string;
    /**The name of the equity of your choice. For example: symbol=IBM */
    symbol!: string;
    /**Time interval between two consecutive data points in the time series. The following values are supported: 1min, 5min, 15min, 30min, 60min */
    interval!: string;
    /** Your API key. Claim your free API key */
    apikey!: string;

    keywords!: string;

    getSymbolSearch(keyword: string | undefined){
        // https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=klbn&apikey=LPRROUBZ5VMIYUY2
        let functionParam = nameof<WebApiClientRequest>("function");
        let keywords = nameof<WebApiClientRequest>("keywords");
        let apiKeyParam = nameof<WebApiClientRequest>("apikey");

        return `${ functionParam }=${ this.function }&${ keywords }=${ keyword }&${ apiKeyParam }=${ this.apikey }`;
    }
}