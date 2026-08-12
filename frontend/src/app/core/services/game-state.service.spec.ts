import { TestBed } from '@angular/core/testing';

import { GameStateService } from './game-state.service';

describe('GameStateService', () => {
  let service: GameStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GameStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should clear the active shop when it is closed', () => {
    service.activeShop.set({} as never);
    service.activeShopInteractionId.set(42);

    service.closeShop();

    expect(service.activeShop()).toBeNull();
    expect(service.activeShopInteractionId()).toBeNull();
  });
});
