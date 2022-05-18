import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { EventCreatorComponent } from '../event-creator/event-creator.component';
import { LeagueCreatorComponent } from '../league-creator/league-creator.component';
import { LeagueEvent } from '../models/league-event.model';
import { League } from '../models/league.model';
import { Player } from '../models/player.model';
import { PlayerCreatorComponent } from '../player-creator/player-creator.component';
import { LeagueService } from '../services/league.service';
import { PlayerService } from '../services/player.service';
import { SnackBarService } from '../services/snack-bar.service';

@Component({
  selector: 'app-league-details',
  templateUrl: './league-details.component.html',
  styleUrls: ['./league-details.component.css']
})
export class LeagueDetailsComponent {
  public league: League;
  public players: MatTableDataSource<Player>;
  public playerColumns: string[] = ['name', 'handicap', 'points', 'actions'];
  public events: MatTableDataSource<LeagueEvent>;
  public eventColumns: string[] = ['date', 'course'];
  public moment = moment;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog,
    private leagueService: LeagueService,
    private playerService: PlayerService,
    private snackBarService: SnackBarService
  ) { 
    this.league = this.route.snapshot.data['league'];
    this.players = new MatTableDataSource<Player>(this.league.players);
    this.events = new MatTableDataSource<LeagueEvent>(this.league.events);
  }

  public refreshLeague() {
    this.leagueService.getLeagueById(this.league.id!).subscribe(league => {
      this.league = league;
      this.players.data = this.league.players;
      this.events.data = this.league.events;
    })
  }

  public updateLeague() {
    const dialogRef = this.dialog.open(LeagueCreatorComponent, {
      width: '400px',
      data: { league: this.league, isEditing: true }
    })

    dialogRef.afterClosed().subscribe(updatedLeague => {
      this.refreshLeague();
    });
  }

  public deleteLeague() {
    const deleteConfirmed = confirm("This will delete the league and all data associated with it. Press OK to continue.");
    if (deleteConfirmed) {
      this.leagueService.deleteLeague(this.league.id!).subscribe((deletedLeague) => {
        if (deletedLeague) {
          this.snackBarService.openSnackBar(`${deletedLeague.name} deleted successfully.`);
          this.router.navigateByUrl('dashboard');
        }
      });
    }
  }

  public addPlayer() {
    const dialogRef = this.dialog.open(PlayerCreatorComponent, {
      width: '400px',
      data: { league: this.league }
    });

    dialogRef.afterClosed().subscribe(updatedLeague => {
      this.refreshLeague();
    });
  }

  public editPlayer(player: Player) {
    const dialogRef = this.dialog.open(PlayerCreatorComponent, {
      width: '400px',
      data: { league: this.league, player: player }
    });

    dialogRef.afterClosed().subscribe(updatedLeague => {
      this.refreshLeague();
    });
  }

  public addEvent() {
    const dialogRef = this.dialog.open(EventCreatorComponent, {
      width: '400px',
      data: { league: this.league, event: new LeagueEvent(new Date(), null, null) }
    });

    dialogRef.afterClosed().subscribe(newEvent => {
      this.refreshLeague();
      console.log('The dialog was closed');
    });
  }

  public editEvent(event: LeagueEvent) {
    const dialogRef = this.dialog.open(EventCreatorComponent, {
      width: '400px',
      data: { league: this.league, event: event }
    });

    dialogRef.afterClosed().subscribe(updatedEvent => {
      this.refreshLeague();
    });
  }

  public getPointsForPlayer(player: Player) {
    return player.playerPoints?.find(el => el.leagueId = this.league.id!)?.points;
  }

  public removePlayer(player: Player) {
    const deleteConfirm = confirm(`This will remove ${player.firstName} ${player.lastName} from this league. Press OK to continue.`)
    if (deleteConfirm) {
      this.playerService.removePlayerFromLeague(player.id!, this.league.id!).subscribe(playerFromDb => {
        this.snackBarService.openSnackBar("Player Removed Successfully.");
        this.refreshLeague();
      });
    }
  }
}
