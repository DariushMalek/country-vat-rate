import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { Country } from 'src/app/models/country.model';
import { CountryVatRateInfoService } from 'src/app/services/country-vat-rate-info/country-vat-rate-info.service';

@Component({
  selector: 'app-vat-calculator',
  templateUrl: './vat-calculator.component.html',
  styleUrls: ['./vat-calculator.component.css']
})
export class VatCalculatorComponent implements OnInit {

  countries: Country[] = []

  constructor(private countryVatRateInfoService: CountryVatRateInfoService) { }

  ngOnInit(): void {
    this.getCountries();
  }

  getCountries(){
    this.countryVatRateInfoService.getCountries().subscribe({
      next: (data: any) => this.countries = data,
      error: (err) => console.log(err) 
    })
  }
}
