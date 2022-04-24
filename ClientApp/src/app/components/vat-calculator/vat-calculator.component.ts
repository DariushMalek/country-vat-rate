import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs';
import { Amounts } from 'src/app/models/amounts.model';
import { CountryRate } from 'src/app/models/country-rate.model';
import { Country } from 'src/app/models/country.model';
import { CountryVatRateInfoService } from 'src/app/services/country-vat-rate-info/country-vat-rate-info.service';
import { VatCalculatorService } from 'src/app/services/vat-calculator/vat-calculator.service';

@Component({
  selector: 'app-vat-calculator',
  templateUrl: './vat-calculator.component.html',
  styleUrls: ['./vat-calculator.component.css']
})
export class VatCalculatorComponent implements OnInit {

  countries: Country[] = [];
  rates: CountryRate[] = [];
  currentRate: any;
  currentCountry: any;

  vatCalcForm = this.formBuilder.group({
    gross: [0, [
      Validators.required,
      Validators.min(Number.MIN_VALUE)
    ]],
    net: [0, [
      Validators.required,
      Validators.min(Number.MIN_VALUE)
    ]],
    vat: [0, [
      Validators.required,
      Validators.min(Number.MIN_VALUE)
    ]]
  });

  constructor(private countryVatRateInfoService: CountryVatRateInfoService,
    private vatCalculatorService: VatCalculatorService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getCountries();
  }

  get gross() { return this.vatCalcForm.get('gross'); }

  get net() { return this.vatCalcForm.get('net'); }

  get vat() { return this.vatCalcForm.get('vat'); }

  getCountries(){
    this.countryVatRateInfoService.getCountries().subscribe({
      next: (data: any) => {
        this.countries = data;
        this.currentCountry = this.countries.filter(n=> n.isDefault)[0];       
        this.getCountryRates(this.currentCountry.id);
      },
      error: (err) => console.log(err) 
    })
  }

  getCountryRates(id: number){
    this.countryVatRateInfoService.getCountryRates(id).subscribe({
      next: (data: any) => {
        this.rates = data;
        this.currentRate = this.rates[0];
      },
      error: (err) => console.log(err) 
    })
  }

  countrySelectedChange(event: { id: number; }){
    this.getCountryRates(event.id);
  }

  onNetChange(amounts: Amounts){
    const newAmounts = this.vatCalculatorService.calcByNet(amounts.net, this.currentRate.rate);
    this.vatCalcForm.setValue(newAmounts);
  }

  onVatChange(amounts: Amounts){
    const newAmounts = this.vatCalculatorService.calcByVat(amounts.vat, this.currentRate.rate);
    this.vatCalcForm.setValue(newAmounts);
  }

  onGrossChange(amounts: Amounts){
    const newAmounts = this.vatCalculatorService.calcByGross(amounts.gross, this.currentRate.rate);
    this.vatCalcForm.setValue(newAmounts);
  }

  onRateChange(){
    const amounts = this.vatCalcForm.value;
    const newAmounts = this.vatCalculatorService.calcByNet(amounts.net, this.currentRate.rate);
    this.vatCalcForm.setValue(newAmounts);
  }
}
