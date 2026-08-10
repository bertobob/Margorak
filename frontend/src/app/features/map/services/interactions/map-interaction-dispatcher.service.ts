import { inject, Injectable } from '@angular/core';
import { TeleporterInteractionHandler } from './teleporter-interaction-handler.service';
import { MapInteractionDto } from '../../dto/map-interaction.dto';
import { ShopInteractionHandlerService } from './shop-interaction-handler.service';
import { EncounterInteractionHandlerService } from './encounter-interaction-handler.service';

@Injectable({
  providedIn: 'root',
})
export class MapInteractionDispatcherService {
  private teleporterHandler = inject(TeleporterInteractionHandler);
  private shopHandler = inject(ShopInteractionHandlerService);
  private encounterHandler = inject(EncounterInteractionHandlerService);

  private handlers = [this.teleporterHandler, this.shopHandler, this.encounterHandler];

  handle(interaction: MapInteractionDto): void {
    const handler = this.handlers.find((handler) => handler.type == interaction.type);

    if (!handler) {
      console.error(
        `No handler registered for map interaction type "${interaction.type}".`,
        interaction
      );
      return;
    }

    handler?.handle(interaction);
  }
}
