import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PeregLossChartComponent } from './pereg-loss-chart.component';

describe('PeregLossChartComponent', () => {
  let component: PeregLossChartComponent;
  let fixture: ComponentFixture<PeregLossChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PeregLossChartComponent]
    });
    fixture = TestBed.createComponent(PeregLossChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
