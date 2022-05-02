import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LeagueCreatorComponent } from '../league-creator/league-creator.component';
import { Course } from '../models/course.model';
import { LeagueEvent } from '../models/league-event.model';
import { League } from '../models/league.model';
import { CourseService } from '../services/course.service';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-event-creator',
  templateUrl: './event-creator.component.html',
  styleUrls: ['./event-creator.component.css']
})
export class EventCreatorComponent implements OnInit {
  @Output() public eventSubmitted: EventEmitter<LeagueEvent> = new EventEmitter<LeagueEvent>();
  public minDate: Date = new Date();
  public courses: Course[] = [];
  public filteredCourses: Course[] = [];
  public isCreatingNewEvent: boolean;

  constructor(
    private eventService: EventService,
    private courseService: CourseService,
    public dialogRef: MatDialogRef<LeagueCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {league: League, event: LeagueEvent }
  ) {
    this.minDate = new Date();
    this.courseService.getAllCourses().subscribe(courses => {
      this.courses = courses;
      this.filteredCourses = courses;
    });
    this.isCreatingNewEvent = this.data.event.id ? false : true;
  }

  ngOnInit(): void {
  }

  public submitForm () {
    const newEvent = this.data.event;
    newEvent.leagueId = this.data.league.id!;
    console.log(newEvent);
    try {
      this.eventService.createEvent(newEvent).subscribe((eventFromDb: LeagueEvent) => {
      if(eventFromDb) {
        this.dialogRef.close();
      }
      });
    } catch {
      console.warn("An error occurred while submitting a league.")
    }
  }

}
