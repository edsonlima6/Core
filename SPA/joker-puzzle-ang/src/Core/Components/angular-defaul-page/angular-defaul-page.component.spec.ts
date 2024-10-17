import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AngularDefaulPageComponent } from './angular-defaul-page.component';

describe('AngularDefaulPageComponent', () => {
  let component: AngularDefaulPageComponent;
  let fixture: ComponentFixture<AngularDefaulPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AngularDefaulPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AngularDefaulPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
