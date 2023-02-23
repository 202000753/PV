import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-leagues',
  templateUrl: './leagues.component.html',
  styleUrls: ['./leagues.component.css']
})
export class LeaguesComponent implements OnInit {

  public leagues: League[] = [];
  constructor(private http: HttpClient,) {
    this.http.get<League[]>('api/LeaguesApi').subscribe(result => {
      console.log(result);
      this.leagues = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

  deleteLeague(leagueId: Number) {
    console.log("delete", leagueId);
    this.http.delete<League>(`api/LeaguesApi/${leagueId}`).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    const index = this.leagues.findIndex((league) => league.leagueId == leagueId);
    this.leagues.splice(index, 1);
  }

}

interface League {
  leagueId: number;
  name: string;
  country: string;
}
