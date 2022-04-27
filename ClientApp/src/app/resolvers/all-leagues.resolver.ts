import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { League } from '../models/league.model';
import { LeagueService } from '../services/league.service';

@Injectable({
  providedIn: 'root'
})
export class AllLeaguesResolver implements Resolve<League[]> {

  public constructor(private leagueService: LeagueService) { }

  public resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<League[]> {
    return this.leagueService.getAllLeagues();
  }
}
