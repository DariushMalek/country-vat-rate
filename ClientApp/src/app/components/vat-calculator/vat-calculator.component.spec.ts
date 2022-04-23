import { DebugElement } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { By } from '@angular/platform-browser';
import { BehaviorSubject, observable, Observable } from 'rxjs';
import { CountryVatRateInfoService } from 'src/app/services/country-vat-rate-info/country-vat-rate-info.service';
import { VatCalculatorService } from 'src/app/services/vat-calculator/vat-calculator.service';
import { VatCalculatorComponent } from './vat-calculator.component';

describe('VatCalculatorComponent', () => {
  let component: VatCalculatorComponent;
  let fixture: ComponentFixture<VatCalculatorComponent>;
  let countryVatRateInfoService: CountryVatRateInfoService;
  let countryVatRateInfoServiceStub: Partial<CountryVatRateInfoService>;
  let fakeCountries$: BehaviorSubject<any>;
  let fakeCountryRates$: BehaviorSubject<any>;
  let vatCalculatorService: VatCalculatorService;

  beforeEach(async () => {
    fakeCountries$ = new BehaviorSubject([{id: 1, countryName: 'Austria', isDefault: true}]);
    fakeCountryRates$ = new BehaviorSubject([{id: 1, rateTitle: '%5', rate: 5, countryId: 1}]);
    countryVatRateInfoServiceStub = {
      getCountries(): Observable<any> {
        return fakeCountries$;
      },
      getCountryRates(): Observable<any> {
        return fakeCountryRates$;
      }
    };
    await TestBed.configureTestingModule({
      declarations: [ VatCalculatorComponent ],
       providers: [ { provide: CountryVatRateInfoService, useValue: countryVatRateInfoServiceStub }, FormBuilder ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VatCalculatorComponent);
    countryVatRateInfoService = TestBed.inject(CountryVatRateInfoService);
    vatCalculatorService = TestBed.inject(VatCalculatorService);
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

  it('getCountryRates should return current country rates', () => {
    component.getCountryRates(1);
    fixture.detectChanges();
    expect(component.rates).toBe(fakeCountryRates$.getValue());
  });

  it('when country is changes countrySelectedChange should be called', () => {
    const debugElement = fixture.debugElement;
    spyOn(component, 'getCountryRates')
    const matSelect = debugElement.query(By.css('.mat-select-country'));
    expect(matSelect).toBeTruthy();

    matSelect.triggerEventHandler('selectionChange',{value:{id:2}});
    expect(component.getCountryRates).toHaveBeenCalled();
  });

  it('when net value is changes onNetChange should be called', () => {
    const debugElement = fixture.debugElement;
    spyOn(component, 'onNetChange')
    const input = debugElement.query(By.css('.net-input'));
    expect(input).toBeTruthy();

    input.triggerEventHandler('input',null);
    expect(component.onNetChange).toHaveBeenCalled();
  });

  it('when vat value is changes onVatChange should be called', () => {
    const debugElement = fixture.debugElement;
    spyOn(component, 'onVatChange')
    const input = debugElement.query(By.css('.vat-input'));
    expect(input).toBeTruthy();

    input.triggerEventHandler('input',null);
    expect(component.onVatChange).toHaveBeenCalled();
  });

  it('when gross value is changes onGrossChange should be called', () => {
    const debugElement = fixture.debugElement;
    spyOn(component, 'onGrossChange')
    const input = debugElement.query(By.css('.gross-input'));
    expect(input).toBeTruthy();

    input.triggerEventHandler('input',null);
    expect(component.onGrossChange).toHaveBeenCalled();
  });
});
