import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchemaChartComponent } from './schema-chart.component';

describe('SchemaChartComponent', () => {
  let component: SchemaChartComponent;
  let fixture: ComponentFixture<SchemaChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SchemaChartComponent]
    });
    fixture = TestBed.createComponent(SchemaChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
