import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { provideHttpClient } from '@angular/common/http';
import 'zone.js';

bootstrapApplication(App, {
  providers: [
    provideHttpClient() // ✅ New functional provider
  ]
}).catch(err => console.error(err));
