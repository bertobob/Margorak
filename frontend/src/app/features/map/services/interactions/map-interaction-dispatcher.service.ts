import { inject, Injectable } from '@angular/core';
import { TeleporterInteractionHandler } from './teleporter-interaction-handler.service';
import { MapInteractionDto } from '../../dto/map-interaction.dto';

@Injectable({
  providedIn: 'root',
})
export class MapInteractionDispatcherService {
  private teleporterHandler = inject(TeleporterInteractionHandler);

  private handlers = [this.teleporterHandler];

  handle(interaction: MapInteractionDto): void {
    const handler = this.handlers.find((handler) => handler.type == interaction.type);

    if (!handler) {
      return;
    }

    handler?.handle(interaction);
  }
}
