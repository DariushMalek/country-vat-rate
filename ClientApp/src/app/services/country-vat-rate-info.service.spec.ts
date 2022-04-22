import { TestBed } from '@angular/core/testing';

import { CountryVatRateInfoService } from './country-vat-rate-info.service';

describe('CountryVatRateInfoService', () => {
  let service: CountryVatRateInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CountryVatRateInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
