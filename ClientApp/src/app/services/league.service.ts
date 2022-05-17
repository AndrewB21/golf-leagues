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

  public getLeagueById(id: number): Observable<League> {
    return this.httpClient.get<League>(`/leagues/${id}`);
  }

  public createLeague(newLeague: League): Observable<League> {
    return this.httpClient.post<League>(
      '/leagues',
      newLeague,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }

  public updateLeague(updatedLeague: League): Observable<League> {
    return this.httpClient.put<League>(
      '/leagues',
      updatedLeague,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }

  public deleteLeague(leagueId: number): Observable<League> {
    return this.httpClient.delete<League>(`/leagues/${leagueId}`);
  }
}
