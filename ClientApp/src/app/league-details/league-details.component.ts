import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { EventCreatorComponent } from '../event-creator/event-creator.component';
import { LeagueEvent } from '../models/league-event.model';
import { League } from '../models/league.model';
import { Player } from '../models/player.model';
import { PlayerCreatorComponent } from '../player-creator/player-creator.component';
import { LeagueService } from '../services/league.service';

@Component({
  selector: 'app-league-details',
  templateUrl: './league-details.component.html',
  styleUrls: ['./league-details.component.css']
})
export class LeagueDetailsComponent {
  public league: League;
  public players: MatTableDataSource<Player>;
  public playerColumns: string[] = ['name', 'handicap', 'points'];
  public events: MatTableDataSource<LeagueEvent>;
  public eventColumns: string[] = ['date', 'course'];
  public moment = moment;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog,
    private leagueService: LeagueService
  ) { 
    this.league = this.route.snapshot.data['league'];
    this.players = new MatTableDataSource<Player>(this.league.players);
    this.events = new MatTableDataSource<LeagueEvent>(this.league.events);
  }

  public refreshLeague() {
    this.leagueService.getLeagueById(this.league.id!).subscribe(league => {
      this.league = league;
      this.players = new MatTableDataSource<Player>(this.league.players);
      this.events = new MatTableDataSource<LeagueEvent>(this.league.events);
    })
  }

  public addPlayer() {
    const dialogRef = this.dialog.open(PlayerCreatorComponent, {
      width: '400px',
      data: { league: this.league }
    });

    dialogRef.afterClosed().subscribe(updatedLeague => {
      if (updatedLeague) {
        console.log('updated league', updatedLeague);
        this.league = updatedLeague;
        this.players.data = updatedLeague.players;
      }
      console.log('The dialog was closed');
    });
  }

  public editPlayer(player: Player) {
    const dialogRef = this.dialog.open(PlayerCreatorComponent, {
      width: '400px',
      data: { league: this.league, player: player }
    });

    dialogRef.afterClosed().subscribe(updatedLeague => {
      if (updatedLeague) {
        this.league = updatedLeague;
        this.players.data = updatedLeague.players;
      }
      console.log('The dialog was closed');
    });
  }

  public addEvent() {
    const dialogRef = this.dialog.open(EventCreatorComponent, {
      width: '400px',
      data: { league: this.league, event: new LeagueEvent(new Date(), null, null) }
    });

    dialogRef.afterClosed().subscribe(newEvent => {
      if (newEvent) {
        // Wait for the new event to be submitted and returned with course info
        const eventWithCourseObserver = new Observable<LeagueEvent>(subscriber => {
          setInterval(() => {
            if (newEvent.course != null) {
              subscriber.next(newEvent);
              subscriber.complete();
            }
          }, 200);
        });
        // Add the event to the data array
        eventWithCourseObserver.subscribe((eventWithCourse: LeagueEvent) => {
          this.league.events.push(eventWithCourse);
          this.events.data = this.league.events;
        });
      }
      console.log('The dialog was closed');
    });
  }

  public editEvent(event: LeagueEvent) {
    const dialogRef = this.dialog.open(EventCreatorComponent, {
      width: '400px',
      data: { league: this.league, event: event }
    });

    dialogRef.afterClosed().subscribe(updatedEvent => {
      if (updatedEvent) {
        const eventIndex = this.league.events.findIndex(el => el.id === updatedEvent.id)!;
        this.league.events[eventIndex] = updatedEvent;
        this.events.data = this.league.events;
      }
      console.log('The dialog was closed');
    });
  }

  public deleteLeague() {
    const deleteConfirmed = confirm("This will delete the league and all data associated with it. Press OK to continue.");
    if (deleteConfirmed) {
      this.leagueService.deleteLeague(this.league.id!).subscribe((deletedLeague) => {
        if (deletedLeague) {
          console.log(`${deletedLeague.name} deleted successfully.`);
          this.router.navigateByUrl('/dashboard');
        }
      });
    }
  }

  public getPointsForPlayer(player: Player) {
    return player.playerPoints?.find(el => el.leagueId = this.league.id!)?.points;
  }

}
