import { TestBed } from '@angular/core/testing';

import { FinancialApiService } from './financial-api.service';

describe('FinancialApiService', () => {
  let service: FinancialApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FinancialApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
