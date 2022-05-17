import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LeagueCreatorComponent } from '../league-creator/league-creator.component';
import { League } from '../models/league.model';
import { Player } from '../models/player.model';
import { PlayerPoints } from '../models/playerpoints.model';
import { LeagueService } from '../services/league.service';
import { PlayerService } from '../services/player.service';
import { cloneDeep } from 'lodash-es'

@Component({
  selector: 'app-player-creator',
  templateUrl: './player-creator.component.html',
  styleUrls: ['./player-creator.component.css']
})
export class PlayerCreatorComponent {
  @Output() public leagueSubmitted: EventEmitter<League> = new EventEmitter<League>();
  public isCreatingNewPlayer: boolean;
  public playerToEdit: Player;
  public playerPoints!: PlayerPoints;

  constructor(
    public leagueService: LeagueService,
    private playerService: PlayerService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {league: League, player?: Player}
  ) {
      this.isCreatingNewPlayer = this.data.player ? false : true;
      if (!this.data.player) {
        this.data.player = new Player('New', 'Player', 0);
        this.data.player.playerPoints = [new PlayerPoints(this.data.league.id!, 0)]
      }
      this.playerToEdit = cloneDeep(this.data.player);
      this.playerPoints = this.playerToEdit.playerPoints?.find(el => el.leagueId === this.data.league.id)!;
      console.log(this.playerToEdit);
  }

  public submitForm () {
    console.log(this.playerToEdit);
    if (this.isCreatingNewPlayer) {
      this.leagueService.getLeagueById(this.data.league.id!).subscribe((league) => {
        this.playerToEdit.leagues = [league]
        this.playerService.createPlayer(this.playerToEdit).subscribe(playerFromDb => {
          if (playerFromDb) {
            // Update the client side league so changes are reflected
            this.data.league.players.push(playerFromDb);
            console.log(this.data.league);
          }
        });
      });
    } else {
      this.playerService.updatePlayer(this.playerToEdit).subscribe(playerFromDb => {
        if(playerFromDb) {
          // Update the client side league so changes are reflected
          const playerIndex = this.data.league.players.findIndex(p => p.id == playerFromDb.id);
          this.data.league.players[playerIndex] = playerFromDb;
        }
      });
    }
  }


}
