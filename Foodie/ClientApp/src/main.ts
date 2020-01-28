import 'hammerjs';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import { NgModule, LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

registerLocaleData(localePl);

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'LOCALE_ID', useValue: 'pl' }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
