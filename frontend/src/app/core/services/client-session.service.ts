import { inject, Injectable } from '@angular/core';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class ClientSessionService {
  private localStorage = inject(LocalStorageService);

  getOrCreateClientId(): string {
    const storedId = this.localStorage.getItem('clientId');

    if (storedId) {
      return storedId;
    }

    const clientId = crypto.randomUUID();
    this.localStorage.setItem('clientId', clientId);

    return clientId;
  }
}
