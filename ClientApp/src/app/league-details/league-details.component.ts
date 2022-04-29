import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { League } from '../models/league.model';
import { PlayerCreatorComponent } from '../player-creator/player-creator.component';

@Component({
  selector: 'app-league-details',
  templateUrl: './league-details.component.html',
  styleUrls: ['./league-details.component.css']
})
export class LeagueDetailsComponent implements OnInit {
  public league: League;
  public moment = moment;
  constructor(
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) { 
    this.league = this.route.snapshot.data['league'];
    console.log(this.league);
  }

  ngOnInit(): void {
  }

  public addPlayer() {
    const dialogRef = this.dialog.open(PlayerCreatorComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
