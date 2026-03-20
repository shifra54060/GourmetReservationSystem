// app.config.ts (החזרת הקריאות המקוריות והשארת provideHttpClient)

import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http'; 

import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(), // החזרת קריאה זו
    provideZonelessChangeDetection(),     // החזרת קריאה זו
    provideRouter(routes),
    provideHttpClient(),
  ]
};