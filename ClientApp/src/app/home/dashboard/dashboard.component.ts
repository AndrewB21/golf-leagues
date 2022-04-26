import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { League } from 'src/app/models/league.model';
import * as moment from 'moment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public displayedColumns: string[] = ['league-name', 'start-date', 'end-date', 'next-event-date'];
  public dataSource: MatTableDataSource<League> = new MatTableDataSource<League>();
  public moment = moment; // Used for formatting dates
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.httpClient.get<League[]>('/leagues/all').subscribe(leagues => {
      this.dataSource = new MatTableDataSource<League>(leagues);
    })
  }

}
