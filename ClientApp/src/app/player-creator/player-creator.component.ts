import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LeagueCreatorComponent } from '../league-creator/league-creator.component';
import { League } from '../models/league.model';
import { Player } from '../models/player.model';
import { LeagueService } from '../services/league.service';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-player-creator',
  templateUrl: './player-creator.component.html',
  styleUrls: ['./player-creator.component.css']
})
export class PlayerCreatorComponent implements OnInit {
  @Output() public leagueSubmitted: EventEmitter<League> = new EventEmitter<League>();
  public isCreatingNewPlayer: boolean;

  constructor(
    public leagueService: LeagueService,
    private playerService: PlayerService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {league: League, player?: Player}
  ) {
      this.isCreatingNewPlayer = this.data.player ? false : true;
      if (!this.data.player) {
        this.data.player = new Player('New', 'Player', 0);
      }
  }

  ngOnInit(): void {
  }

  public submitForm () {
    const player = this.data.player!;
    this.leagueService.getLeagueById(this.data.league.id!).subscribe((league) => {
      player.leagues = [league]
      this.playerService.createPlayer(player).subscribe(playerFromDb => {
        if (playerFromDb) {
          this.dialogRef.close();
        }
      });
    });
  }
}
