import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BehaviorSubject, observable, Observable } from 'rxjs';
import { CountryVatRateInfoService } from 'src/app/services/country-vat-rate-info/country-vat-rate-info.service';
import { VatCalculatorComponent } from './vat-calculator.component';

describe('VatCalculatorComponent', () => {
  let component: VatCalculatorComponent;
  let fixture: ComponentFixture<VatCalculatorComponent>;
  let countryVatRateInfoService: CountryVatRateInfoService;
  let countryVatRateInfoServiceStub: Partial<CountryVatRateInfoService>;
  let fakeCountries$: BehaviorSubject<any>;
  
  beforeEach(async () => {
    fakeCountries$ = new BehaviorSubject([{id: 1, countryName: 'Austria', isDefault: true}]);
    countryVatRateInfoServiceStub = {
      getCountries(): Observable<any> {
        return fakeCountries$;
      }
    };
    await TestBed.configureTestingModule({
      declarations: [ VatCalculatorComponent ],
       providers: [ { provide: CountryVatRateInfoService, useValue: countryVatRateInfoServiceStub } ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VatCalculatorComponent);
    countryVatRateInfoService = TestBed.inject(CountryVatRateInfoService);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('getCountries should return countries', () => {
    component.getCountries();
    fixture.detectChanges();
    expect(component.countries).toBe(fakeCountries$.getValue());
  });
});
