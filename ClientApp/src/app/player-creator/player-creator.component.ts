import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
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
  public playerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    handicap: new FormControl(0)
  });

  constructor(
    public leagueService: LeagueService,
    private playerService: PlayerService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent> 
  ) {
  }

  ngOnInit(): void {
  }

  public submitForm () {
    const formValues = this.playerForm.value;
    const player: Player = new Player(formValues.firstName, formValues.lastName, formValues.handicap);
    this.leagueService.getLeagueById(1).subscribe((league) => {
      player.leagues = [league]
      this.playerService.createPlayer(player).subscribe(playerFromDb => {
        console.log(playerFromDb);
      });
    });
  }
}
