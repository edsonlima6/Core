import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StocksDailyComponent } from './stocks-daily.component';

describe('StocksDailyComponent', () => {
  let component: StocksDailyComponent;
  let fixture: ComponentFixture<StocksDailyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StocksDailyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StocksDailyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
