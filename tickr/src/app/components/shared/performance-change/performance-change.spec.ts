import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerformanceChange } from './performance-change';

describe('PerformanceChange', () => {
  let component: PerformanceChange;
  let fixture: ComponentFixture<PerformanceChange>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PerformanceChange]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PerformanceChange);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
