import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mega-menu',
  templateUrl: './mega-menu.component.html',
  styleUrl: './mega-menu.component.css',
})
export class MegaMenuComponent {
  items: MenuItem[] | undefined;

  constructor(private routing: Router){
  }

  ngOnInit() {
      this.items = [
          { label: 'Dashboard', icon: 'pi pi-home', command: () => this.onNavigate('') },
          { label: 'Assets', icon: 'pi pi-chart-line', command: () => this.onNavigate('assets') },
          { label: 'Reports', icon: 'pi pi-list', command: () => this.onNavigate('dashboard') },
          { label: 'Wallet', icon: 'pi pi-inbox' },
          { label: 'About', icon: 'pi pi-inbox' },
          { label: 'Contact', icon: 'pi pi-inbox' }
      ]
  }

  onNavigate(path: string){
    this.routing.navigate([`${path}`]);
  }
}
