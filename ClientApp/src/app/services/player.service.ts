import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  constructor(private httpClient: HttpClient) { }

  public getAllPlayers(): Observable<Player[]> {
    return this.httpClient.get<Player[]>('/players/all');
  }

  public getPlayerById(id: number): Observable<Player> {
    return this.httpClient.get<Player>(`/players/${id}`);
  }

  public createPlayer(newPlayer: Player): Observable<Player> {
    console.log(newPlayer);
    return this.httpClient.post<Player>(
      '/players/create',
      newPlayer,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }

  public updatePlayer(updatedPlayer: Player): Observable<Player> {
    return this.httpClient.post<Player>(
      `/players/update`,
      updatedPlayer,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    );
  }

  public removePlayerFromLeague(playerId: number, leagueId: number) {
    return this.httpClient.delete<Player>(`/players/remove/${playerId}/${leagueId}`);
  }
}
