import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { League } from '../models/league.model';

@Component({
  selector: 'app-league-details',
  templateUrl: './league-details.component.html',
  styleUrls: ['./league-details.component.css']
})
export class LeagueDetailsComponent implements OnInit {
  public league: League;
  public moment = moment;
  constructor(private route: ActivatedRoute) { 
    this.league = this.route.snapshot.data['league'];
  }

  ngOnInit(): void {
  }

  public addPlayer() {
    
  }

}
