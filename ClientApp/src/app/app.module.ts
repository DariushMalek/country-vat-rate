import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { VatCalculatorComponent } from './components/vat-calculator/vat-calculator.component';

@NgModule({
  declarations: [
    AppComponent,
    VatCalculatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  let host = window.location.protocol + "//" + window.location.hostname;
  return host + ':5035';
}
