import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CountryVatRateInfoService } from './country-vat-rate-info.service';

describe('CountryVatRateInfoService', () => {
  let service: CountryVatRateInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [
      HttpClientTestingModule 
    ],
    providers: [
      { provide: 'BASE_URL', useValue: 'http://localhost' }
    ]});
    service = TestBed.inject(CountryVatRateInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
