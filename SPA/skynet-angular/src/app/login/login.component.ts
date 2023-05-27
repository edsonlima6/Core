import { Component } from '@angular/core';
import { HttpProviderService } from '../Core/Services/http-provider.service';
import { UserModel } from '../Core/Models/userModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private httpService: HttpProviderService){
    
  }

  ngOnInit() {
   
  }
}
