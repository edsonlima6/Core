export const stock_function_param = {
    Daily: "TIME_SERIES_DAILY",
    Intraday: "TIME_SERIES_INTRADAY",
    Weekly: "TIME_SERIES_WEEKLY",
    SimbolSearch: "SYMBOL_SEARCH", 
    MarketStatus: "MARKET_STATUS"
}

export const nameof = <T>(name: keyof T) => name;