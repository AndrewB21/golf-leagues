import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { LeagueEvent } from '../models/league-event.model';
@Injectable({
  providedIn: 'root'
})
export class EventService {
  constructor(private httpClient: HttpClient) { }

  public getAllEvents(): Observable<LeagueEvent[]> {
    return this.httpClient.get<LeagueEvent[]>('/events/all');
  }

  public createEvent(newEvent: LeagueEvent): Observable<LeagueEvent> {
    return this.httpClient.post<LeagueEvent>(
      '/events/create',
      newEvent,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }

  public updateEvent(updatedEvent: LeagueEvent): Observable<LeagueEvent> {
    return this.httpClient.put<LeagueEvent>(
      '/events/update',
      updatedEvent,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }
}
