import { inject, Injectable } from '@angular/core';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class ClientSessionService {
  private readonly localStorageService = inject(LocalStorageService);

  getOrCreateClientId(): string {
    const storedId = this.localStorageService.getItem('clientId');

    if (storedId) {
      return storedId;
    }

    const clientId = crypto.randomUUID();
    this.localStorageService.setItem('clientId', clientId);

    return clientId;
  }
}
