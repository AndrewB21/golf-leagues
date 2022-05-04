import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { League } from '../models/league.model';
import { LeagueService } from '../services/league.service';

@Component({
  selector: 'app-league-creator',
  templateUrl: './league-creator.component.html',
  styleUrls: ['./league-creator.component.css']
})
export class LeagueCreatorComponent {
  @Output() public leagueSubmitted: EventEmitter<League> = new EventEmitter<League>();
  public minDate: Date;
  public maxEndDate: Date;
  public leagueForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });

  constructor(
    private leagueService: LeagueService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent> 
  ) {
    this.minDate = new Date();
    this.maxEndDate = new Date(this.minDate.getFullYear() + 1, this.minDate.getMonth(), this.minDate.getDate());
    console.log(this.maxEndDate);
  }

  public submitForm () {
    const formValues = this.leagueForm.value;

    // Convert Moment objects to Date objects
    formValues.startDate = formValues.startDate.toDate();
    formValues.endDate = formValues.endDate.toDate();
    
    const newLeague = new League(formValues.name, formValues.description, undefined, formValues.startDate, formValues.endDate, []);
    try {
      this.leagueService.createLeague(newLeague).subscribe((leagueFromDb: League) => {
      if(leagueFromDb) {
        this.dialogRef.close();
      }
      });
    } catch {
      console.warn("An error occurred while submitting a league.")
    }
  }

}
