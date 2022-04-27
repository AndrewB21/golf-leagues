import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { League } from '../models/league.model';

@Injectable({
  providedIn: 'root'
})
export class LeagueService {

  constructor(private httpClient: HttpClient) { }

  public getAllLeagues(): Observable<League[]> {
    return this.httpClient.get<League[]>('/leagues/all');
  }

  public createLeague(newLeague: League): Observable<League> {
    return this.httpClient.post<League>(
      '/leagues/create',
      newLeague,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }
}
