import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable } from 'rxjs';
import { League } from '../models/league.model';
import { LeagueService } from '../services/league.service';

@Injectable({
  providedIn: 'root'
})
export class SingleLeagueResolver implements Resolve<League> {

  constructor(private leagueService: LeagueService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<League> {
    return this.leagueService.getLeagueById(route.params.id);
  }
}
