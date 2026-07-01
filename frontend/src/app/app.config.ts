import {
  ApplicationConfig,
  provideAppInitializer,
  inject
} from '@angular/core';

import { provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { AppInitService } from './core/services/app-init-service';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClient(),

    provideAppInitializer(() => {
      inject(AppInitService).init();
    })
  ]
};