import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { League } from '../models/league.model';

@Component({
  selector: 'app-league-details',
  templateUrl: './league-details.component.html',
  styleUrls: ['./league-details.component.css']
})
export class LeagueDetailsComponent implements OnInit {
  public league: League;
  constructor(private route: ActivatedRoute) { 
    this.league = this.route.snapshot.data['league'];
  }

  ngOnInit(): void {
  }

}
