import { HttpService } from 'src/Core/Services/HttpService';
import { Component } from '@angular/core';

@Component({
  selector: 'app-stocks-daily',
  standalone: true,
  imports: [],
  templateUrl: './stocks-daily.component.html',
  styleUrl: './stocks-daily.component.scss'
})
export class StocksDailyComponent {

  constructor(private httpService: HttpService){

  }

  getEnvironment(){
    return this.httpService.getStocks().subscribe(x => {
      console.log(x);
    });
  }

}
