import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'], 
  standalone: true, 
  imports: [
    ButtonModule
  ]
})
export class LoginComponent {

}
