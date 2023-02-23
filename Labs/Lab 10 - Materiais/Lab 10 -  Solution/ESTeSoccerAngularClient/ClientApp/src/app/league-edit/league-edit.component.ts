import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-league-edit',
  templateUrl: './league-edit.component.html',
  styleUrls: ['./league-edit.component.css']
})
export class LeagueEditComponent implements OnInit, OnDestroy {
  id: number = 0;
  league!: League;
  private sub: any;

  createLeagueForm = this.formBuilder.group({
    name: '',
    country: ''
  });

  constructor(private http: HttpClient,
    private formBuilder: FormBuilder, private route: ActivatedRoute) {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];

      this.http.get<League>(`api/LeaguesApi/${this.id}`).subscribe(result => {
        console.log(result);
        this.league = result;
        this.createLeagueForm.controls.name.patchValue(this.league.name);
        this.createLeagueForm.controls.country.patchValue(this.league.country);
      }, error => console.error(error));
    });
  }

  ngOnInit(): void {
   
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }


  onSubmit(): void {
    console.log("submitted");
    this.league.leagueId = this.id;
    this.league.name = this.createLeagueForm.controls.name.value!;
    this.league.country = this.createLeagueForm.controls.country.value!;

    this.EditLeague(this.league);
  }

  EditLeague(league: League) {
    this.http.put<League>(`api/LeaguesApi/${this.id}`, league)
      .pipe(catchError(this.handleError))
      .subscribe();
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
  leagueId: number;
  name: string;
  country: string;
}

