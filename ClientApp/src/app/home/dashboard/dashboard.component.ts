import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { League } from 'src/app/models/league.model';
import * as moment from 'moment';
import { LeagueCreatorComponent } from 'src/app/league-creator/league-creator.component';
import { LeagueService } from 'src/app/services/league.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public displayedColumns: string[] = ['league-name', 'start-date', 'end-date', 'next-event-date'];
  public dataSource: MatTableDataSource<League> = new MatTableDataSource<League>();
  public moment = moment; // Used for formatting dates
  constructor(
    private leagueService: LeagueService, 
    public dialog: MatDialog,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.dataSource = this.route.snapshot.data['leagues'];
  }

  public updateLeagueDataSource() {
    this.leagueService.getAllLeagues().subscribe(leagues => {
      this.dataSource = new MatTableDataSource<League>(leagues);
    })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(LeagueCreatorComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.updateLeagueDataSource();
    });
  }
}
