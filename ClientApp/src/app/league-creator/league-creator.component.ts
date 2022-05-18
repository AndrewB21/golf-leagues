import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LeagueEvent } from '../models/league-event.model';
import { League } from '../models/league.model';
import { LeagueService } from '../services/league.service';
import { cloneDeep } from 'lodash-es';

@Component({
  selector: 'app-league-creator',
  templateUrl: './league-creator.component.html',
  styleUrls: ['./league-creator.component.css']
})
export class LeagueCreatorComponent {
  @Output() public leagueSubmitted: EventEmitter<League> = new EventEmitter<League>();
  public leagueToEdit: League;
  public minDate: Date;
  public maxEndDate: Date;
  public leagueForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });

  // TODO Update Component to use isEditing, use model binding like in other creators

  constructor(
    private leagueService: LeagueService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {league: League, isEditing: boolean }
  ) {
    this.minDate = new Date();
    this.maxEndDate = new Date(this.minDate.getFullYear() + 1, this.minDate.getMonth(), this.minDate.getDate());
    if (this.data.isEditing) {
      this.leagueToEdit = cloneDeep(this.data.league);
    } else {
      this.leagueToEdit = new League('New League', '', [], this.minDate, this.maxEndDate, []);
    }
    console.log(this.leagueToEdit);
  }

  public submitForm () {
    try {
      if (this.data.isEditing) {
        this.leagueService.updateLeague(this.leagueToEdit).subscribe((leagueFromDb: League) => {
          console.log("League updated");
          this.dialogRef.close();
        })
      } else {
        this.leagueService.createLeague(this.leagueToEdit).subscribe((leagueFromDb: League) => {
          console.log("League submitted");
          this.dialogRef.close();
        });
      }
    } catch {
      console.warn("An error occurred while submitting a league.")
    }
  }

}
