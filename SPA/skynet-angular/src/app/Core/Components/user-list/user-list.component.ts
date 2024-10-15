import { Component } from '@angular/core';
import { UserModel } from '../../Models/userModel';
import { HttpProviderService } from '../../Services/http-provider.service';
import { DogBreedService } from '../../Services/dog-breed.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent {

  public _userModel: UserModel[] = [];

  constructor(private httpService: HttpProviderService, private dogService: DogBreedService){

  }
  ngOnInit() {
    this.httpService.getAll<UserModel[]>("user/users")
    .subscribe(c => {
      this._userModel = c;
      console.log(c);
    });
    
  }
}
