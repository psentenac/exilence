import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';

import { Player } from '../../../../shared/interfaces/player.interface';
import { PartyService } from '../../../../shared/providers/party.service';

@Component({
  selector: 'app-player-badge',
  templateUrl: './player-badge.component.html',
  styleUrls: ['./player-badge.component.scss']
})
export class PlayerBadgeComponent implements OnInit, OnDestroy {
  @Input() player: Player;
  @Input() localPlayer = false;
  selectedPlayer: Player;
  selectedGenericPlayer: Player;
  private selectedPlayerSub: Subscription;
  private selectedGenPlayerSub: Subscription;

  constructor(private partyService: PartyService) { }

  ngOnInit() {
    if (!this.localPlayer) {
      this.selectedPlayerSub = this.partyService.selectedPlayer.subscribe(res => {
        this.selectedPlayer = res;
      });
    } else {
      this.selectedGenPlayerSub = this.partyService.selectedGenericPlayer.subscribe(res => {
        this.selectedGenericPlayer = res;
      });
    }
  }

  ngOnDestroy() {
    if (this.selectedPlayerSub !== undefined) {
      this.selectedPlayerSub.unsubscribe();
    }
    if (this.selectedGenPlayerSub !== undefined) {
      this.selectedGenPlayerSub.unsubscribe();
    }
  }

  selectPlayer() {
    if (!this.localPlayer) {
      this.partyService.selectedPlayer.next(this.player);
      this.partyService.selectedFilter.next(this.player.character.name);
    }
    if (this.localPlayer) {
      this.partyService.selectedGenericPlayer.next(this.player);
    }
  }

  getRanking() {
    return this.player.overallRank !== undefined ? this.player.overallRank : '';
  }

}
