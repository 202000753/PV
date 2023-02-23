import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-league-create',
  templateUrl: './league-create.component.html',
  styleUrls: ['./league-create.component.css']
})
export class LeagueCreateComponent implements OnInit {

  createLeagueForm = this.formBuilder.group({
    name: '',
    country: ''
  });

  constructor(private http: HttpClient,
    private formBuilder: FormBuilder,) {

  }

  onSubmit(): void {
    console.log("submitted");
    let league: League = {
      name: this.createLeagueForm.controls.name.value!,
      country: this.createLeagueForm.controls.country.value!
    }
    this.createLeague(league);
  }

  createLeague(league: League) {
    this.http.post<League>('api/LeaguesApi', league)
      .pipe(catchError(this.handleError))
      .subscribe();
  }

  ngOnInit(): void {
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}

interface League {
  name: string;
  country: string;
}

