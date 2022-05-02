import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(private httpClient: HttpClient) { }

  public getAllCourses(): Observable<Course[]> {
    return this.httpClient.get<Course[]>('/courses/all');
  }

  public createCourse(newCourse: Course): Observable<Course> {
    return this.httpClient.post<Course>(
      '/courses/create',
      newCourse,
      {
        headers: new HttpHeaders({
        'Content-Type': 'application/json',
        })
      }
    )
  }
}
