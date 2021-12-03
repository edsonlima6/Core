import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'sky-netang';
  items: MenuItem[] = [];

  ngOnInit() { 
    this.items = [
        {
            label: 'Managment',
            items: [{
                    label: 'User', 
                    icon: 'pi pi-fw pi-plus',
                    items: [
                        {label: 'Create'},
                        {label: 'Users'},
                    ]
                },
                {label: 'Open'},
                {label: 'Quit'}
            ]
        },
        {
            label: 'Home',
            icon: 'pi pi-fw pi-home',
            // items: [
            //     {label: 'Delete', icon: 'pi pi-fw pi-trash'},
            //     {label: 'Refresh', icon: 'pi pi-fw pi-refresh'}
            // ]
        }
    ];
}
  
}
